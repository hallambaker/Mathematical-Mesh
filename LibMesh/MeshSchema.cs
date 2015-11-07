
//  Test
//  
//  This file was automatically generated at 11/6/2015 11:48:40 PM
//   
//  Changes to this file may be overwritten without warning
//  
//  Generator:  ProtoGen version 1.0.0.0
//      Goedel Script Version : 0.1   Generated 
//      Goedel Schema Version : 0.1   Generated
//  
//      Copyright : Copyright ©  2012
//  
//  Build Platform: Win32NT 6.2.9200.0
//  
//  
//  Copyright (c) 2014 by .
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
//  //Header

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
    /// </summary>
	public abstract partial class MeshItem : Goedel.Protocol.JSONObject {

        /// <summary>
        /// 
        /// </summary>
		public override string Tag () {
			return "MeshItem";
			}

        /// <summary>
        /// Default constructor.
        /// </summary>
		public MeshItem () {
			_Initialize () ;
			}

        /// <summary>
        /// Construct an instance from a JSON encoded stream.
        /// </summary>
		public MeshItem (JSONReader JSONReader) {
			Deserialize (JSONReader);
			_Initialize () ;
			}

        /// <summary>
        /// Construct an instance from a JSON encoded string.
        /// </summary>
		public MeshItem (string _String) {
			Deserialize (_String);
			_Initialize () ;
			}



		/// <summary>
        /// Construct an instance from the specified tagged JSONReader stream.
        /// </summary>
        public static void Deserialize(JSONReader JSONReader, out JSONObject Out) {
	
			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                Out = null;
                return;
                }

			string token = JSONReader.ReadToken ();
			Out = null;

			switch (token) {

				case "Entry" : {
					var Result = new Entry ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "SignedProfile" : {
					var Result = new SignedProfile ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "SignedDeviceProfile" : {
					var Result = new SignedDeviceProfile ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "SignedMasterProfile" : {
					var Result = new SignedMasterProfile ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "SignedPersonalProfile" : {
					var Result = new SignedPersonalProfile ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "SignedApplicationProfile" : {
					var Result = new SignedApplicationProfile ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "EncryptedProfile" : {
					var Result = new EncryptedProfile ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "Profile" : {
					Out = null;
					throw new Exception ("Can't create abstract type");
					}


				case "MasterProfile" : {
					var Result = new MasterProfile ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "PersonalProfile" : {
					var Result = new PersonalProfile ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "ApplicationProfileEntry" : {
					var Result = new ApplicationProfileEntry ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "DeviceProfile" : {
					var Result = new DeviceProfile ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "DevicePrivateProfile" : {
					var Result = new DevicePrivateProfile ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "ApplicationProfile" : {
					var Result = new ApplicationProfile ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "DeviceEntry" : {
					var Result = new DeviceEntry ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "PasswordProfile" : {
					var Result = new PasswordProfile ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "PasswordProfilePrivate" : {
					var Result = new PasswordProfilePrivate ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "PasswordEntry" : {
					var Result = new PasswordEntry ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


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


				case "NetworkProfile" : {
					var Result = new NetworkProfile ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "NetworkProfilePrivate" : {
					var Result = new NetworkProfilePrivate ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "EscrowEntry" : {
					var Result = new EscrowEntry ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "OfflineEscrowEntry" : {
					var Result = new OfflineEscrowEntry ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "OnlineEscrowEntry" : {
					var Result = new OnlineEscrowEntry ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "EscrowedKeySet" : {
					var Result = new EscrowedKeySet ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "Connection" : {
					var Result = new Connection ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "EncryptedData" : {
					var Result = new EncryptedData ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "SignedData" : {
					var Result = new SignedData ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "PublicKey" : {
					var Result = new PublicKey ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "ConnectionRequest" : {
					var Result = new ConnectionRequest ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "ConnectionResult" : {
					var Result = new ConnectionResult ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "SignedConnectionRequest" : {
					var Result = new SignedConnectionRequest ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "SignedConnectionResult" : {
					var Result = new SignedConnectionResult ();
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
	/// </summary>
	public partial class Entry : MeshItem {
        /// <summary>
        /// 
        /// </summary>
		public string						Identifier;

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "Entry";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public Entry () {
			_Initialize ();
			}
        /// <summary>
        /// </summary>		
		public Entry (JSONReader JSONReader) {
			Deserialize (JSONReader);
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
        /// </summary>		
		public static new Entry From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new Entry From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new Entry (JSONReader);
			}

        /// <summary>
        /// </summary>		
		public static new Entry FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new Entry FromTagged (string _Input) {
			Entry _Result;
			Deserialize (_Input, out _Result);
			return _Result;
			}


        /// <summary>
        /// 
        /// </summary>
        /// <param name="_Input"></param>
        /// <param name="Out"></param>
        public static void Deserialize(string _Input, out Entry Out) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);

			Deserialize (JSONReader, out Out);
			}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Out"></param>
        public static void Deserialize(JSONReader JSONReader, out Entry Out) {
	
			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                Out = null;
                return;
                }

			string token = JSONReader.ReadToken ();
			Out = null;

			switch (token) {

				case "Entry" : {
					var Result = new Entry ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "SignedProfile" : {
					var Result = new SignedProfile ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "SignedDeviceProfile" : {
					var Result = new SignedDeviceProfile ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "SignedMasterProfile" : {
					var Result = new SignedMasterProfile ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "SignedPersonalProfile" : {
					var Result = new SignedPersonalProfile ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "SignedApplicationProfile" : {
					var Result = new SignedApplicationProfile ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "SignedConnectionRequest" : {
					var Result = new SignedConnectionRequest ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "SignedConnectionResult" : {
					var Result = new SignedConnectionResult ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "EncryptedProfile" : {
					var Result = new EncryptedProfile ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "Profile" : {
					Out = null;
					throw new Exception ("Can't create abstract type");
					}

				case "MasterProfile" : {
					var Result = new MasterProfile ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "PersonalProfile" : {
					var Result = new PersonalProfile ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "DeviceProfile" : {
					var Result = new DeviceProfile ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "ApplicationProfile" : {
					var Result = new ApplicationProfile ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "PasswordProfile" : {
					var Result = new PasswordProfile ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "MailProfile" : {
					var Result = new MailProfile ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "NetworkProfile" : {
					var Result = new NetworkProfile ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "EscrowEntry" : {
					var Result = new EscrowEntry ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "OfflineEscrowEntry" : {
					var Result = new OfflineEscrowEntry ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "OnlineEscrowEntry" : {
					var Result = new OnlineEscrowEntry ();
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

			// should we check for EOF here?
            }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Tag"></param>
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
        /// 
        /// </summary>
		public JoseWebSignature						SignedData;

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "SignedProfile";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public SignedProfile () {
			_Initialize ();
			}
        /// <summary>
        /// </summary>		
		public SignedProfile (JSONReader JSONReader) {
			Deserialize (JSONReader);
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
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}



        /// <summary>
        /// </summary>		
		public static new SignedProfile From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new SignedProfile From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new SignedProfile (JSONReader);
			}

        /// <summary>
        /// </summary>		
		public static new SignedProfile FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new SignedProfile FromTagged (string _Input) {
			SignedProfile _Result;
			Deserialize (_Input, out _Result);
			return _Result;
			}


        /// <summary>
        /// 
        /// </summary>
        /// <param name="_Input"></param>
        /// <param name="Out"></param>
        public static void Deserialize(string _Input, out SignedProfile Out) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);

			Deserialize (JSONReader, out Out);
			}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Out"></param>
        public static void Deserialize(JSONReader JSONReader, out SignedProfile Out) {
	
			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                Out = null;
                return;
                }

			string token = JSONReader.ReadToken ();
			Out = null;

			switch (token) {

				case "SignedProfile" : {
					var Result = new SignedProfile ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "SignedDeviceProfile" : {
					var Result = new SignedDeviceProfile ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "SignedMasterProfile" : {
					var Result = new SignedMasterProfile ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "SignedPersonalProfile" : {
					var Result = new SignedPersonalProfile ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "SignedApplicationProfile" : {
					var Result = new SignedApplicationProfile ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "SignedConnectionRequest" : {
					var Result = new SignedConnectionRequest ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "SignedConnectionResult" : {
					var Result = new SignedConnectionResult ();
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

			// should we check for EOF here?
            }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Tag"></param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "SignedData" : {
					// Field does not have 
					SignedData = new JoseWebSignature (JSONReader);
					//JoseWebSignature.Deserialize(JSONReader, out SignedData) ;
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
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "SignedDeviceProfile";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public SignedDeviceProfile () {
			_Initialize ();
			}
        /// <summary>
        /// </summary>		
		public SignedDeviceProfile (JSONReader JSONReader) {
			Deserialize (JSONReader);
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
        /// </summary>		
		public static new SignedDeviceProfile From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new SignedDeviceProfile From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new SignedDeviceProfile (JSONReader);
			}

        /// <summary>
        /// </summary>		
		public static new SignedDeviceProfile FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new SignedDeviceProfile FromTagged (string _Input) {
			SignedDeviceProfile _Result;
			Deserialize (_Input, out _Result);
			return _Result;
			}


        /// <summary>
        /// 
        /// </summary>
        /// <param name="_Input"></param>
        /// <param name="Out"></param>
        public static void Deserialize(string _Input, out SignedDeviceProfile Out) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);

			Deserialize (JSONReader, out Out);
			}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Out"></param>
        public static void Deserialize(JSONReader JSONReader, out SignedDeviceProfile Out) {
	
			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                Out = null;
                return;
                }

			string token = JSONReader.ReadToken ();
			Out = null;

			switch (token) {

				case "SignedDeviceProfile" : {
					var Result = new SignedDeviceProfile ();
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

			// should we check for EOF here?
            }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Tag"></param>
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
	/// Contains a signed Personal master profile
	/// </summary>
	public partial class SignedMasterProfile : SignedProfile {

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "SignedMasterProfile";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public SignedMasterProfile () {
			_Initialize ();
			}
        /// <summary>
        /// </summary>		
		public SignedMasterProfile (JSONReader JSONReader) {
			Deserialize (JSONReader);
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
        /// </summary>		
		public static new SignedMasterProfile From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new SignedMasterProfile From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new SignedMasterProfile (JSONReader);
			}

        /// <summary>
        /// </summary>		
		public static new SignedMasterProfile FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new SignedMasterProfile FromTagged (string _Input) {
			SignedMasterProfile _Result;
			Deserialize (_Input, out _Result);
			return _Result;
			}


        /// <summary>
        /// 
        /// </summary>
        /// <param name="_Input"></param>
        /// <param name="Out"></param>
        public static void Deserialize(string _Input, out SignedMasterProfile Out) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);

			Deserialize (JSONReader, out Out);
			}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Out"></param>
        public static void Deserialize(JSONReader JSONReader, out SignedMasterProfile Out) {
	
			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                Out = null;
                return;
                }

			string token = JSONReader.ReadToken ();
			Out = null;

			switch (token) {

				case "SignedMasterProfile" : {
					var Result = new SignedMasterProfile ();
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

			// should we check for EOF here?
            }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Tag"></param>
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
	/// Contains a signed Personal current profile
	/// </summary>
	public partial class SignedPersonalProfile : SignedProfile {

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "SignedPersonalProfile";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public SignedPersonalProfile () {
			_Initialize ();
			}
        /// <summary>
        /// </summary>		
		public SignedPersonalProfile (JSONReader JSONReader) {
			Deserialize (JSONReader);
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
        /// </summary>		
		public static new SignedPersonalProfile From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new SignedPersonalProfile From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new SignedPersonalProfile (JSONReader);
			}

        /// <summary>
        /// </summary>		
		public static new SignedPersonalProfile FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new SignedPersonalProfile FromTagged (string _Input) {
			SignedPersonalProfile _Result;
			Deserialize (_Input, out _Result);
			return _Result;
			}


        /// <summary>
        /// 
        /// </summary>
        /// <param name="_Input"></param>
        /// <param name="Out"></param>
        public static void Deserialize(string _Input, out SignedPersonalProfile Out) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);

			Deserialize (JSONReader, out Out);
			}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Out"></param>
        public static void Deserialize(JSONReader JSONReader, out SignedPersonalProfile Out) {
	
			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                Out = null;
                return;
                }

			string token = JSONReader.ReadToken ();
			Out = null;

			switch (token) {

				case "SignedPersonalProfile" : {
					var Result = new SignedPersonalProfile ();
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

			// should we check for EOF here?
            }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Tag"></param>
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
	/// Contains a signed device profile
	/// </summary>
	public partial class SignedApplicationProfile : SignedProfile {

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "SignedApplicationProfile";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public SignedApplicationProfile () {
			_Initialize ();
			}
        /// <summary>
        /// </summary>		
		public SignedApplicationProfile (JSONReader JSONReader) {
			Deserialize (JSONReader);
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
        /// </summary>		
		public static new SignedApplicationProfile From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new SignedApplicationProfile From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new SignedApplicationProfile (JSONReader);
			}

        /// <summary>
        /// </summary>		
		public static new SignedApplicationProfile FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new SignedApplicationProfile FromTagged (string _Input) {
			SignedApplicationProfile _Result;
			Deserialize (_Input, out _Result);
			return _Result;
			}


        /// <summary>
        /// 
        /// </summary>
        /// <param name="_Input"></param>
        /// <param name="Out"></param>
        public static void Deserialize(string _Input, out SignedApplicationProfile Out) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);

			Deserialize (JSONReader, out Out);
			}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Out"></param>
        public static void Deserialize(JSONReader JSONReader, out SignedApplicationProfile Out) {
	
			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                Out = null;
                return;
                }

			string token = JSONReader.ReadToken ();
			Out = null;

			switch (token) {

				case "SignedApplicationProfile" : {
					var Result = new SignedApplicationProfile ();
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

			// should we check for EOF here?
            }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Tag"></param>
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
	/// Contains an encrypted profile entry
	/// </summary>
	public partial class EncryptedProfile : Entry {
        /// <summary>
        /// 
        /// </summary>
		public JoseWebEncryption						EncryptedData;

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "EncryptedProfile";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public EncryptedProfile () {
			_Initialize ();
			}
        /// <summary>
        /// </summary>		
		public EncryptedProfile (JSONReader JSONReader) {
			Deserialize (JSONReader);
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
        /// </summary>		
		public static new EncryptedProfile From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new EncryptedProfile From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new EncryptedProfile (JSONReader);
			}

        /// <summary>
        /// </summary>		
		public static new EncryptedProfile FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new EncryptedProfile FromTagged (string _Input) {
			EncryptedProfile _Result;
			Deserialize (_Input, out _Result);
			return _Result;
			}


        /// <summary>
        /// 
        /// </summary>
        /// <param name="_Input"></param>
        /// <param name="Out"></param>
        public static void Deserialize(string _Input, out EncryptedProfile Out) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);

			Deserialize (JSONReader, out Out);
			}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Out"></param>
        public static void Deserialize(JSONReader JSONReader, out EncryptedProfile Out) {
	
			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                Out = null;
                return;
                }

			string token = JSONReader.ReadToken ();
			Out = null;

			switch (token) {

				case "EncryptedProfile" : {
					var Result = new EncryptedProfile ();
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

			// should we check for EOF here?
            }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Tag"></param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "EncryptedData" : {
					// Field does not have 
					EncryptedData = new JoseWebEncryption (JSONReader);
					//JoseWebEncryption.Deserialize(JSONReader, out EncryptedData) ;
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
	/// Parent class from which all profile types are derrived
	/// </summary>
	abstract public partial class Profile : Entry {
		/// <summary>
        /// 
        /// </summary>
		public List<string>				Names;
		bool								__Updated = false;
		private DateTime						_Updated;
        /// <summary>
        /// 
        /// </summary>
		public DateTime						Updated {
			get {return _Updated;}
			set {_Updated = value; __Updated = true; }
			}
        /// <summary>
        /// 
        /// </summary>
		public string						NotaryToken;

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "Profile";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public Profile () {
			_Initialize ();
			}
        /// <summary>
        /// </summary>		
		public Profile (JSONReader JSONReader) {
			Deserialize (JSONReader);
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

			if (__Updated){
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
        /// </summary>		
		public static new Profile FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new Profile FromTagged (string _Input) {
			Profile _Result;
			Deserialize (_Input, out _Result);
			return _Result;
			}


        /// <summary>
        /// 
        /// </summary>
        /// <param name="_Input"></param>
        /// <param name="Out"></param>
        public static void Deserialize(string _Input, out Profile Out) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);

			Deserialize (JSONReader, out Out);
			}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Out"></param>
        public static void Deserialize(JSONReader JSONReader, out Profile Out) {
	
			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                Out = null;
                return;
                }

			string token = JSONReader.ReadToken ();
			Out = null;

			switch (token) {

				case "Profile" : {
					Out = null;
					throw new Exception ("Can't create abstract type");
					}

				case "MasterProfile" : {
					var Result = new MasterProfile ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "PersonalProfile" : {
					var Result = new PersonalProfile ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "DeviceProfile" : {
					var Result = new DeviceProfile ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "ApplicationProfile" : {
					var Result = new ApplicationProfile ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "PasswordProfile" : {
					var Result = new PasswordProfile ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "MailProfile" : {
					var Result = new MailProfile ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "NetworkProfile" : {
					var Result = new NetworkProfile ();
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

			// should we check for EOF here?
            }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Tag"></param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "Names" : {
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
	/// Describes the long term parameters associated with a personal profile.
	/// </summary>
	public partial class MasterProfile : Profile {
        /// <summary>
        /// 
        /// </summary>
		public PublicKey						MasterSignatureKey;
		/// <summary>
        /// 
        /// </summary>
		public List<PublicKey>				MasterEscrowKeys;
		/// <summary>
        /// 
        /// </summary>
		public List<PublicKey>				OnlineSignatureKeys;

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "MasterProfile";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public MasterProfile () {
			_Initialize ();
			}
        /// <summary>
        /// </summary>		
		public MasterProfile (JSONReader JSONReader) {
			Deserialize (JSONReader);
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
        /// </summary>		
		public static new MasterProfile From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new MasterProfile From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new MasterProfile (JSONReader);
			}

        /// <summary>
        /// </summary>		
		public static new MasterProfile FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new MasterProfile FromTagged (string _Input) {
			MasterProfile _Result;
			Deserialize (_Input, out _Result);
			return _Result;
			}


        /// <summary>
        /// 
        /// </summary>
        /// <param name="_Input"></param>
        /// <param name="Out"></param>
        public static void Deserialize(string _Input, out MasterProfile Out) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);

			Deserialize (JSONReader, out Out);
			}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Out"></param>
        public static void Deserialize(JSONReader JSONReader, out MasterProfile Out) {
	
			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                Out = null;
                return;
                }

			string token = JSONReader.ReadToken ();
			Out = null;

			switch (token) {

				case "MasterProfile" : {
					var Result = new MasterProfile ();
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

			// should we check for EOF here?
            }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Tag"></param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "MasterSignatureKey" : {
					// Field does not have 
					MasterSignatureKey = new PublicKey (JSONReader);
					//PublicKey.Deserialize(JSONReader, out MasterSignatureKey) ;
					break;
					}
				case "MasterEscrowKeys" : {
					bool _Going = JSONReader.StartArray ();
					MasterEscrowKeys = new List <PublicKey> ();
					while (_Going) {
						var _Item = new PublicKey (JSONReader);
						//PublicKey _Item;
                        //PublicKey.Deserialize(JSONReader, out _Item);

						MasterEscrowKeys.Add (_Item);
						_Going = JSONReader.NextArray ();
						}

					break;
					}
				case "OnlineSignatureKeys" : {
					bool _Going = JSONReader.StartArray ();
					OnlineSignatureKeys = new List <PublicKey> ();
					while (_Going) {
						var _Item = new PublicKey (JSONReader);
						//PublicKey _Item;
                        //PublicKey.Deserialize(JSONReader, out _Item);

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
	/// Describes the current applications and devices connected to a 
	/// personal master profile.
	/// </summary>
	public partial class PersonalProfile : Profile {
        /// <summary>
        /// 
        /// </summary>
		public SignedMasterProfile						SignedMasterProfile;
		/// <summary>
        /// 
        /// </summary>
		public List<SignedDeviceProfile>				Devices;
		/// <summary>
        /// 
        /// </summary>
		public List<ApplicationProfileEntry>				Applications;

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "PersonalProfile";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public PersonalProfile () {
			_Initialize ();
			}
        /// <summary>
        /// </summary>		
		public PersonalProfile (JSONReader JSONReader) {
			Deserialize (JSONReader);
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
        /// </summary>		
		public static new PersonalProfile From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new PersonalProfile From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new PersonalProfile (JSONReader);
			}

        /// <summary>
        /// </summary>		
		public static new PersonalProfile FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new PersonalProfile FromTagged (string _Input) {
			PersonalProfile _Result;
			Deserialize (_Input, out _Result);
			return _Result;
			}


        /// <summary>
        /// 
        /// </summary>
        /// <param name="_Input"></param>
        /// <param name="Out"></param>
        public static void Deserialize(string _Input, out PersonalProfile Out) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);

			Deserialize (JSONReader, out Out);
			}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Out"></param>
        public static void Deserialize(JSONReader JSONReader, out PersonalProfile Out) {
	
			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                Out = null;
                return;
                }

			string token = JSONReader.ReadToken ();
			Out = null;

			switch (token) {

				case "PersonalProfile" : {
					var Result = new PersonalProfile ();
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

			// should we check for EOF here?
            }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Tag"></param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "SignedMasterProfile" : {
					// Field does not have 
					SignedMasterProfile = new SignedMasterProfile (JSONReader);
					//SignedMasterProfile.Deserialize(JSONReader, out SignedMasterProfile) ;
					break;
					}
				case "Devices" : {
					bool _Going = JSONReader.StartArray ();
					Devices = new List <SignedDeviceProfile> ();
					while (_Going) {
						var _Item = new SignedDeviceProfile (JSONReader);
						//SignedDeviceProfile _Item;
                        //SignedDeviceProfile.Deserialize(JSONReader, out _Item);

						Devices.Add (_Item);
						_Going = JSONReader.NextArray ();
						}

					break;
					}
				case "Applications" : {
					bool _Going = JSONReader.StartArray ();
					Applications = new List <ApplicationProfileEntry> ();
					while (_Going) {
						var _Item = new ApplicationProfileEntry (JSONReader);
						//ApplicationProfileEntry _Item;
                        //ApplicationProfileEntry.Deserialize(JSONReader, out _Item);

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
	/// </summary>
	public partial class ApplicationProfileEntry : MeshItem {
        /// <summary>
        /// 
        /// </summary>
		public string						Identifier;
        /// <summary>
        /// 
        /// </summary>
		public string						Type;
        /// <summary>
        /// 
        /// </summary>
		public string						Friendly;
		/// <summary>
        /// 
        /// </summary>
		public List<string>				SignID;
		/// <summary>
        /// 
        /// </summary>
		public List<string>				DecryptID;

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "ApplicationProfileEntry";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public ApplicationProfileEntry () {
			_Initialize ();
			}
        /// <summary>
        /// </summary>		
		public ApplicationProfileEntry (JSONReader JSONReader) {
			Deserialize (JSONReader);
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
			if (SignID != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("SignID", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in SignID) {
					_Writer.WriteArraySeparator (ref _firstarray);
					_Writer.WriteString (_index);
					}
				_Writer.WriteArrayEnd ();
				}

			if (DecryptID != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("DecryptID", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in DecryptID) {
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
        /// </summary>		
		public static new ApplicationProfileEntry From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new ApplicationProfileEntry From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new ApplicationProfileEntry (JSONReader);
			}

        /// <summary>
        /// </summary>		
		public static new ApplicationProfileEntry FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new ApplicationProfileEntry FromTagged (string _Input) {
			ApplicationProfileEntry _Result;
			Deserialize (_Input, out _Result);
			return _Result;
			}


        /// <summary>
        /// 
        /// </summary>
        /// <param name="_Input"></param>
        /// <param name="Out"></param>
        public static void Deserialize(string _Input, out ApplicationProfileEntry Out) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);

			Deserialize (JSONReader, out Out);
			}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Out"></param>
        public static void Deserialize(JSONReader JSONReader, out ApplicationProfileEntry Out) {
	
			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                Out = null;
                return;
                }

			string token = JSONReader.ReadToken ();
			Out = null;

			switch (token) {

				case "ApplicationProfileEntry" : {
					var Result = new ApplicationProfileEntry ();
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

			// should we check for EOF here?
            }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Tag"></param>
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
				case "SignID" : {
					bool _Going = JSONReader.StartArray ();
					SignID = new List <string> ();
					while (_Going) {
						string _Item = JSONReader.ReadString ();
						SignID.Add (_Item);
						_Going = JSONReader.NextArray ();
						}

					break;
					}
				case "DecryptID" : {
					bool _Going = JSONReader.StartArray ();
					DecryptID = new List <string> ();
					while (_Going) {
						string _Item = JSONReader.ReadString ();
						DecryptID.Add (_Item);
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
	/// Describes a mesh device.
	/// </summary>
	public partial class DeviceProfile : Profile {
        /// <summary>
        /// 
        /// </summary>
		public string						Description;
        /// <summary>
        /// 
        /// </summary>
		public PublicKey						DeviceSignatureKey;
        /// <summary>
        /// 
        /// </summary>
		public PublicKey						DeviceAuthenticationKey;
        /// <summary>
        /// 
        /// </summary>
		public PublicKey						DeviceEncryptiontionKey;

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "DeviceProfile";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public DeviceProfile () {
			_Initialize ();
			}
        /// <summary>
        /// </summary>		
		public DeviceProfile (JSONReader JSONReader) {
			Deserialize (JSONReader);
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
        /// </summary>		
		public static new DeviceProfile From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new DeviceProfile From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new DeviceProfile (JSONReader);
			}

        /// <summary>
        /// </summary>		
		public static new DeviceProfile FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new DeviceProfile FromTagged (string _Input) {
			DeviceProfile _Result;
			Deserialize (_Input, out _Result);
			return _Result;
			}


        /// <summary>
        /// 
        /// </summary>
        /// <param name="_Input"></param>
        /// <param name="Out"></param>
        public static void Deserialize(string _Input, out DeviceProfile Out) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);

			Deserialize (JSONReader, out Out);
			}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Out"></param>
        public static void Deserialize(JSONReader JSONReader, out DeviceProfile Out) {
	
			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                Out = null;
                return;
                }

			string token = JSONReader.ReadToken ();
			Out = null;

			switch (token) {

				case "DeviceProfile" : {
					var Result = new DeviceProfile ();
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

			// should we check for EOF here?
            }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Tag"></param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "Description" : {
					Description = JSONReader.ReadString ();
					break;
					}
				case "DeviceSignatureKey" : {
					// Field does not have 
					DeviceSignatureKey = new PublicKey (JSONReader);
					//PublicKey.Deserialize(JSONReader, out DeviceSignatureKey) ;
					break;
					}
				case "DeviceAuthenticationKey" : {
					// Field does not have 
					DeviceAuthenticationKey = new PublicKey (JSONReader);
					//PublicKey.Deserialize(JSONReader, out DeviceAuthenticationKey) ;
					break;
					}
				case "DeviceEncryptiontionKey" : {
					// Field does not have 
					DeviceEncryptiontionKey = new PublicKey (JSONReader);
					//PublicKey.Deserialize(JSONReader, out DeviceEncryptiontionKey) ;
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
        /// 
        /// </summary>
		public Key						DeviceSignatureKey;
        /// <summary>
        /// 
        /// </summary>
		public Key						DeviceAuthenticationKey;
        /// <summary>
        /// 
        /// </summary>
		public Key						DeviceEncryptiontionKey;

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "DevicePrivateProfile";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public DevicePrivateProfile () {
			_Initialize ();
			}
        /// <summary>
        /// </summary>		
		public DevicePrivateProfile (JSONReader JSONReader) {
			Deserialize (JSONReader);
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
        /// </summary>		
		public static new DevicePrivateProfile From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new DevicePrivateProfile From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new DevicePrivateProfile (JSONReader);
			}

        /// <summary>
        /// </summary>		
		public static new DevicePrivateProfile FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new DevicePrivateProfile FromTagged (string _Input) {
			DevicePrivateProfile _Result;
			Deserialize (_Input, out _Result);
			return _Result;
			}


        /// <summary>
        /// 
        /// </summary>
        /// <param name="_Input"></param>
        /// <param name="Out"></param>
        public static void Deserialize(string _Input, out DevicePrivateProfile Out) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);

			Deserialize (JSONReader, out Out);
			}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Out"></param>
        public static void Deserialize(JSONReader JSONReader, out DevicePrivateProfile Out) {
	
			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                Out = null;
                return;
                }

			string token = JSONReader.ReadToken ();
			Out = null;

			switch (token) {

				case "DevicePrivateProfile" : {
					var Result = new DevicePrivateProfile ();
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

			// should we check for EOF here?
            }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Tag"></param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "DeviceSignatureKey" : {
					// Field does not have 
					DeviceSignatureKey = new Key (JSONReader);
					//Key.Deserialize(JSONReader, out DeviceSignatureKey) ;
					break;
					}
				case "DeviceAuthenticationKey" : {
					// Field does not have 
					DeviceAuthenticationKey = new Key (JSONReader);
					//Key.Deserialize(JSONReader, out DeviceAuthenticationKey) ;
					break;
					}
				case "DeviceEncryptiontionKey" : {
					// Field does not have 
					DeviceEncryptiontionKey = new Key (JSONReader);
					//Key.Deserialize(JSONReader, out DeviceEncryptiontionKey) ;
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
	/// Parent class from which all application profiles inherit.
	/// </summary>
	public partial class ApplicationProfile : Profile {
        /// <summary>
        /// 
        /// </summary>
		public JoseWebEncryption						EncryptedData;
		/// <summary>
        /// 
        /// </summary>
		public List<DeviceEntry>				Entries;

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "ApplicationProfile";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public ApplicationProfile () {
			_Initialize ();
			}
        /// <summary>
        /// </summary>		
		public ApplicationProfile (JSONReader JSONReader) {
			Deserialize (JSONReader);
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
			if (EncryptedData != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("EncryptedData", 1);
					EncryptedData.Serialize (_Writer, false);
				}
			if (Entries != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Entries", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in Entries) {
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
        /// </summary>		
		public static new ApplicationProfile From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new ApplicationProfile From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new ApplicationProfile (JSONReader);
			}

        /// <summary>
        /// </summary>		
		public static new ApplicationProfile FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new ApplicationProfile FromTagged (string _Input) {
			ApplicationProfile _Result;
			Deserialize (_Input, out _Result);
			return _Result;
			}


        /// <summary>
        /// 
        /// </summary>
        /// <param name="_Input"></param>
        /// <param name="Out"></param>
        public static void Deserialize(string _Input, out ApplicationProfile Out) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);

			Deserialize (JSONReader, out Out);
			}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Out"></param>
        public static void Deserialize(JSONReader JSONReader, out ApplicationProfile Out) {
	
			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                Out = null;
                return;
                }

			string token = JSONReader.ReadToken ();
			Out = null;

			switch (token) {

				case "ApplicationProfile" : {
					var Result = new ApplicationProfile ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "PasswordProfile" : {
					var Result = new PasswordProfile ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "MailProfile" : {
					var Result = new MailProfile ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "NetworkProfile" : {
					var Result = new NetworkProfile ();
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

			// should we check for EOF here?
            }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Tag"></param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "EncryptedData" : {
					// Field does not have 
					EncryptedData = new JoseWebEncryption (JSONReader);
					//JoseWebEncryption.Deserialize(JSONReader, out EncryptedData) ;
					break;
					}
				case "Entries" : {
					bool _Going = JSONReader.StartArray ();
					Entries = new List <DeviceEntry> ();
					while (_Going) {
						var _Item = new DeviceEntry (JSONReader);
						//DeviceEntry _Item;
                        //DeviceEntry.Deserialize(JSONReader, out _Item);

						Entries.Add (_Item);
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
	/// Contains the device specific data for an application.
	/// </summary>
	public partial class DeviceEntry : MeshItem {
        /// <summary>
        /// 
        /// </summary>
		public string						UDF;
        /// <summary>
        /// 
        /// </summary>
		public string						Protocol;
        /// <summary>
        /// 
        /// </summary>
		public byte[]						EncryptedKey;
        /// <summary>
        /// 
        /// </summary>
		public PublicKey						SignatureKey;
        /// <summary>
        /// 
        /// </summary>
		public PublicKey						AuthenticationKey;

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "DeviceEntry";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public DeviceEntry () {
			_Initialize ();
			}
        /// <summary>
        /// </summary>		
		public DeviceEntry (JSONReader JSONReader) {
			Deserialize (JSONReader);
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
			if (Protocol != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Protocol", 1);
					_Writer.WriteString (Protocol);
				}
			if (EncryptedKey != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("EncryptedKey", 1);
					_Writer.WriteBinary (EncryptedKey);
				}
			if (SignatureKey != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("SignatureKey", 1);
					SignatureKey.Serialize (_Writer, false);
				}
			if (AuthenticationKey != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("AuthenticationKey", 1);
					AuthenticationKey.Serialize (_Writer, false);
				}
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}



        /// <summary>
        /// </summary>		
		public static new DeviceEntry From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new DeviceEntry From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new DeviceEntry (JSONReader);
			}

        /// <summary>
        /// </summary>		
		public static new DeviceEntry FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new DeviceEntry FromTagged (string _Input) {
			DeviceEntry _Result;
			Deserialize (_Input, out _Result);
			return _Result;
			}


        /// <summary>
        /// 
        /// </summary>
        /// <param name="_Input"></param>
        /// <param name="Out"></param>
        public static void Deserialize(string _Input, out DeviceEntry Out) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);

			Deserialize (JSONReader, out Out);
			}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Out"></param>
        public static void Deserialize(JSONReader JSONReader, out DeviceEntry Out) {
	
			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                Out = null;
                return;
                }

			string token = JSONReader.ReadToken ();
			Out = null;

			switch (token) {

				case "DeviceEntry" : {
					var Result = new DeviceEntry ();
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

			// should we check for EOF here?
            }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Tag"></param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "UDF" : {
					UDF = JSONReader.ReadString ();
					break;
					}
				case "Protocol" : {
					Protocol = JSONReader.ReadString ();
					break;
					}
				case "EncryptedKey" : {
					EncryptedKey = JSONReader.ReadBinary ();
					break;
					}
				case "SignatureKey" : {
					// Field does not have 
					SignatureKey = new PublicKey (JSONReader);
					//PublicKey.Deserialize(JSONReader, out SignatureKey) ;
					break;
					}
				case "AuthenticationKey" : {
					// Field does not have 
					AuthenticationKey = new PublicKey (JSONReader);
					//PublicKey.Deserialize(JSONReader, out AuthenticationKey) ;
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
	/// Stores usernames and passwords
	/// </summary>
	public partial class PasswordProfile : ApplicationProfile {

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "PasswordProfile";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public PasswordProfile () {
			_Initialize ();
			}
        /// <summary>
        /// </summary>		
		public PasswordProfile (JSONReader JSONReader) {
			Deserialize (JSONReader);
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
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}



        /// <summary>
        /// </summary>		
		public static new PasswordProfile From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new PasswordProfile From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new PasswordProfile (JSONReader);
			}

        /// <summary>
        /// </summary>		
		public static new PasswordProfile FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new PasswordProfile FromTagged (string _Input) {
			PasswordProfile _Result;
			Deserialize (_Input, out _Result);
			return _Result;
			}


        /// <summary>
        /// 
        /// </summary>
        /// <param name="_Input"></param>
        /// <param name="Out"></param>
        public static void Deserialize(string _Input, out PasswordProfile Out) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);

			Deserialize (JSONReader, out Out);
			}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Out"></param>
        public static void Deserialize(JSONReader JSONReader, out PasswordProfile Out) {
	
			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                Out = null;
                return;
                }

			string token = JSONReader.ReadToken ();
			Out = null;

			switch (token) {

				case "PasswordProfile" : {
					var Result = new PasswordProfile ();
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

			// should we check for EOF here?
            }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Tag"></param>
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
	public partial class PasswordProfilePrivate : MeshItem {
		/// <summary>
        /// 
        /// </summary>
		public List<PasswordEntry>				Entries;

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "PasswordProfilePrivate";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public PasswordProfilePrivate () {
			_Initialize ();
			}
        /// <summary>
        /// </summary>		
		public PasswordProfilePrivate (JSONReader JSONReader) {
			Deserialize (JSONReader);
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
			if (Entries != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Entries", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in Entries) {
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
        /// </summary>		
		public static new PasswordProfilePrivate From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new PasswordProfilePrivate From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new PasswordProfilePrivate (JSONReader);
			}

        /// <summary>
        /// </summary>		
		public static new PasswordProfilePrivate FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new PasswordProfilePrivate FromTagged (string _Input) {
			PasswordProfilePrivate _Result;
			Deserialize (_Input, out _Result);
			return _Result;
			}


        /// <summary>
        /// 
        /// </summary>
        /// <param name="_Input"></param>
        /// <param name="Out"></param>
        public static void Deserialize(string _Input, out PasswordProfilePrivate Out) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);

			Deserialize (JSONReader, out Out);
			}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Out"></param>
        public static void Deserialize(JSONReader JSONReader, out PasswordProfilePrivate Out) {
	
			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                Out = null;
                return;
                }

			string token = JSONReader.ReadToken ();
			Out = null;

			switch (token) {

				case "PasswordProfilePrivate" : {
					var Result = new PasswordProfilePrivate ();
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

			// should we check for EOF here?
            }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Tag"></param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "Entries" : {
					bool _Going = JSONReader.StartArray ();
					Entries = new List <PasswordEntry> ();
					while (_Going) {
						var _Item = new PasswordEntry (JSONReader);
						//PasswordEntry _Item;
                        //PasswordEntry.Deserialize(JSONReader, out _Item);

						Entries.Add (_Item);
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
	/// Username password entry for a single site
	/// </summary>
	public partial class PasswordEntry : MeshItem {
		/// <summary>
        /// 
        /// </summary>
		public List<string>				Sites;
        /// <summary>
        /// 
        /// </summary>
		public string						Username;
        /// <summary>
        /// 
        /// </summary>
		public string						Password;

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "PasswordEntry";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public PasswordEntry () {
			_Initialize ();
			}
        /// <summary>
        /// </summary>		
		public PasswordEntry (JSONReader JSONReader) {
			Deserialize (JSONReader);
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
			if (Sites != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Sites", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in Sites) {
					_Writer.WriteArraySeparator (ref _firstarray);
					_Writer.WriteString (_index);
					}
				_Writer.WriteArrayEnd ();
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
        /// </summary>		
		public static new PasswordEntry From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new PasswordEntry From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new PasswordEntry (JSONReader);
			}

        /// <summary>
        /// </summary>		
		public static new PasswordEntry FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new PasswordEntry FromTagged (string _Input) {
			PasswordEntry _Result;
			Deserialize (_Input, out _Result);
			return _Result;
			}


        /// <summary>
        /// 
        /// </summary>
        /// <param name="_Input"></param>
        /// <param name="Out"></param>
        public static void Deserialize(string _Input, out PasswordEntry Out) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);

			Deserialize (JSONReader, out Out);
			}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Out"></param>
        public static void Deserialize(JSONReader JSONReader, out PasswordEntry Out) {
	
			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                Out = null;
                return;
                }

			string token = JSONReader.ReadToken ();
			Out = null;

			switch (token) {

				case "PasswordEntry" : {
					var Result = new PasswordEntry ();
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

			// should we check for EOF here?
            }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Tag"></param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "Sites" : {
					bool _Going = JSONReader.StartArray ();
					Sites = new List <string> ();
					while (_Going) {
						string _Item = JSONReader.ReadString ();
						Sites.Add (_Item);
						_Going = JSONReader.NextArray ();
						}

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
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	/// <summary>
	///
	/// Public profile describes mail receipt policy. Private describes
	/// Sending policy
	/// </summary>
	public partial class MailProfile : ApplicationProfile {
        /// <summary>
        /// 
        /// </summary>
		public PublicKey						EncryptionPGP;
        /// <summary>
        /// 
        /// </summary>
		public PublicKey						EncryptionSMIME;

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
        /// </summary>		
		public MailProfile (JSONReader JSONReader) {
			Deserialize (JSONReader);
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
        /// </summary>		
		public static new MailProfile From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new MailProfile From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new MailProfile (JSONReader);
			}

        /// <summary>
        /// </summary>		
		public static new MailProfile FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new MailProfile FromTagged (string _Input) {
			MailProfile _Result;
			Deserialize (_Input, out _Result);
			return _Result;
			}


        /// <summary>
        /// 
        /// </summary>
        /// <param name="_Input"></param>
        /// <param name="Out"></param>
        public static void Deserialize(string _Input, out MailProfile Out) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);

			Deserialize (JSONReader, out Out);
			}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Out"></param>
        public static void Deserialize(JSONReader JSONReader, out MailProfile Out) {
	
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

				default : {
					//Ignore the unknown data
                    //throw new Exception ("Not supported");
                    break;
					}
				}
			JSONReader.EndObject ();

			// should we check for EOF here?
            }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Tag"></param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "EncryptionPGP" : {
					// Field does not have 
					EncryptionPGP = new PublicKey (JSONReader);
					//PublicKey.Deserialize(JSONReader, out EncryptionPGP) ;
					break;
					}
				case "EncryptionSMIME" : {
					// Field does not have 
					EncryptionSMIME = new PublicKey (JSONReader);
					//PublicKey.Deserialize(JSONReader, out EncryptionSMIME) ;
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
	public partial class MailProfilePrivate : MeshItem {
		/// <summary>
        /// 
        /// </summary>
		public List<Connection>				Connections;
        /// <summary>
        /// 
        /// </summary>
		public Key						OpenPGPKey;
        /// <summary>
        /// 
        /// </summary>
		public Key						OpenSMIMEKey;

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
        /// </summary>		
		public MailProfilePrivate (JSONReader JSONReader) {
			Deserialize (JSONReader);
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
			if (Connections != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Connections", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in Connections) {
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

			if (OpenPGPKey != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("OpenPGPKey", 1);
					OpenPGPKey.Serialize (_Writer, false);
				}
			if (OpenSMIMEKey != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("OpenSMIMEKey", 1);
					OpenSMIMEKey.Serialize (_Writer, false);
				}
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}



        /// <summary>
        /// </summary>		
		public static new MailProfilePrivate From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new MailProfilePrivate From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new MailProfilePrivate (JSONReader);
			}

        /// <summary>
        /// </summary>		
		public static new MailProfilePrivate FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new MailProfilePrivate FromTagged (string _Input) {
			MailProfilePrivate _Result;
			Deserialize (_Input, out _Result);
			return _Result;
			}


        /// <summary>
        /// 
        /// </summary>
        /// <param name="_Input"></param>
        /// <param name="Out"></param>
        public static void Deserialize(string _Input, out MailProfilePrivate Out) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);

			Deserialize (JSONReader, out Out);
			}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Out"></param>
        public static void Deserialize(JSONReader JSONReader, out MailProfilePrivate Out) {
	
			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                Out = null;
                return;
                }

			string token = JSONReader.ReadToken ();
			Out = null;

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

			// should we check for EOF here?
            }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Tag"></param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "Connections" : {
					bool _Going = JSONReader.StartArray ();
					Connections = new List <Connection> ();
					while (_Going) {
						var _Item = new Connection (JSONReader);
						//Connection _Item;
                        //Connection.Deserialize(JSONReader, out _Item);

						Connections.Add (_Item);
						_Going = JSONReader.NextArray ();
						}

					break;
					}
				case "OpenPGPKey" : {
					// Field does not have 
					OpenPGPKey = new Key (JSONReader);
					//Key.Deserialize(JSONReader, out OpenPGPKey) ;
					break;
					}
				case "OpenSMIMEKey" : {
					// Field does not have 
					OpenSMIMEKey = new Key (JSONReader);
					//Key.Deserialize(JSONReader, out OpenSMIMEKey) ;
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
	/// Describes the network profile to follow
	/// </summary>
	public partial class NetworkProfile : ApplicationProfile {

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "NetworkProfile";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public NetworkProfile () {
			_Initialize ();
			}
        /// <summary>
        /// </summary>		
		public NetworkProfile (JSONReader JSONReader) {
			Deserialize (JSONReader);
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
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}



        /// <summary>
        /// </summary>		
		public static new NetworkProfile From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new NetworkProfile From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new NetworkProfile (JSONReader);
			}

        /// <summary>
        /// </summary>		
		public static new NetworkProfile FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new NetworkProfile FromTagged (string _Input) {
			NetworkProfile _Result;
			Deserialize (_Input, out _Result);
			return _Result;
			}


        /// <summary>
        /// 
        /// </summary>
        /// <param name="_Input"></param>
        /// <param name="Out"></param>
        public static void Deserialize(string _Input, out NetworkProfile Out) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);

			Deserialize (JSONReader, out Out);
			}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Out"></param>
        public static void Deserialize(JSONReader JSONReader, out NetworkProfile Out) {
	
			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                Out = null;
                return;
                }

			string token = JSONReader.ReadToken ();
			Out = null;

			switch (token) {

				case "NetworkProfile" : {
					var Result = new NetworkProfile ();
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

			// should we check for EOF here?
            }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Tag"></param>
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
	/// Describes the network profile to follow
	/// </summary>
	public partial class NetworkProfilePrivate : MeshItem {
		/// <summary>
        /// 
        /// </summary>
		public List<string>				Sites;
		/// <summary>
        /// 
        /// </summary>
		public List<Connection>				DNS;
		/// <summary>
        /// 
        /// </summary>
		public List<string>				Prefix;
        /// <summary>
        /// 
        /// </summary>
		public byte[]						CTL;
		/// <summary>
        /// 
        /// </summary>
		public List<string>				WebPKI;

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "NetworkProfilePrivate";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public NetworkProfilePrivate () {
			_Initialize ();
			}
        /// <summary>
        /// </summary>		
		public NetworkProfilePrivate (JSONReader JSONReader) {
			Deserialize (JSONReader);
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
			if (Sites != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Sites", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in Sites) {
					_Writer.WriteArraySeparator (ref _firstarray);
					_Writer.WriteString (_index);
					}
				_Writer.WriteArrayEnd ();
				}

			if (DNS != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("DNS", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in DNS) {
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

			if (Prefix != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Prefix", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in Prefix) {
					_Writer.WriteArraySeparator (ref _firstarray);
					_Writer.WriteString (_index);
					}
				_Writer.WriteArrayEnd ();
				}

			if (CTL != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("CTL", 1);
					_Writer.WriteBinary (CTL);
				}
			if (WebPKI != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("WebPKI", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in WebPKI) {
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
        /// </summary>		
		public static new NetworkProfilePrivate From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new NetworkProfilePrivate From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new NetworkProfilePrivate (JSONReader);
			}

        /// <summary>
        /// </summary>		
		public static new NetworkProfilePrivate FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new NetworkProfilePrivate FromTagged (string _Input) {
			NetworkProfilePrivate _Result;
			Deserialize (_Input, out _Result);
			return _Result;
			}


        /// <summary>
        /// 
        /// </summary>
        /// <param name="_Input"></param>
        /// <param name="Out"></param>
        public static void Deserialize(string _Input, out NetworkProfilePrivate Out) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);

			Deserialize (JSONReader, out Out);
			}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Out"></param>
        public static void Deserialize(JSONReader JSONReader, out NetworkProfilePrivate Out) {
	
			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                Out = null;
                return;
                }

			string token = JSONReader.ReadToken ();
			Out = null;

			switch (token) {

				case "NetworkProfilePrivate" : {
					var Result = new NetworkProfilePrivate ();
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

			// should we check for EOF here?
            }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Tag"></param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "Sites" : {
					bool _Going = JSONReader.StartArray ();
					Sites = new List <string> ();
					while (_Going) {
						string _Item = JSONReader.ReadString ();
						Sites.Add (_Item);
						_Going = JSONReader.NextArray ();
						}

					break;
					}
				case "DNS" : {
					bool _Going = JSONReader.StartArray ();
					DNS = new List <Connection> ();
					while (_Going) {
						var _Item = new Connection (JSONReader);
						//Connection _Item;
                        //Connection.Deserialize(JSONReader, out _Item);

						DNS.Add (_Item);
						_Going = JSONReader.NextArray ();
						}

					break;
					}
				case "Prefix" : {
					bool _Going = JSONReader.StartArray ();
					Prefix = new List <string> ();
					while (_Going) {
						string _Item = JSONReader.ReadString ();
						Prefix.Add (_Item);
						_Going = JSONReader.NextArray ();
						}

					break;
					}
				case "CTL" : {
					CTL = JSONReader.ReadBinary ();
					break;
					}
				case "WebPKI" : {
					bool _Going = JSONReader.StartArray ();
					WebPKI = new List <string> ();
					while (_Going) {
						string _Item = JSONReader.ReadString ();
						WebPKI.Add (_Item);
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
	/// Contains escrowed data
	/// </summary>
	public partial class EscrowEntry : Entry {
        /// <summary>
        /// 
        /// </summary>
		public JoseWebEncryption						EncryptedData;

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "EscrowEntry";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public EscrowEntry () {
			_Initialize ();
			}
        /// <summary>
        /// </summary>		
		public EscrowEntry (JSONReader JSONReader) {
			Deserialize (JSONReader);
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
        /// </summary>		
		public static new EscrowEntry From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new EscrowEntry From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new EscrowEntry (JSONReader);
			}

        /// <summary>
        /// </summary>		
		public static new EscrowEntry FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new EscrowEntry FromTagged (string _Input) {
			EscrowEntry _Result;
			Deserialize (_Input, out _Result);
			return _Result;
			}


        /// <summary>
        /// 
        /// </summary>
        /// <param name="_Input"></param>
        /// <param name="Out"></param>
        public static void Deserialize(string _Input, out EscrowEntry Out) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);

			Deserialize (JSONReader, out Out);
			}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Out"></param>
        public static void Deserialize(JSONReader JSONReader, out EscrowEntry Out) {
	
			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                Out = null;
                return;
                }

			string token = JSONReader.ReadToken ();
			Out = null;

			switch (token) {

				case "EscrowEntry" : {
					var Result = new EscrowEntry ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "OfflineEscrowEntry" : {
					var Result = new OfflineEscrowEntry ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "OnlineEscrowEntry" : {
					var Result = new OnlineEscrowEntry ();
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

			// should we check for EOF here?
            }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Tag"></param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "EncryptedData" : {
					// Field does not have 
					EncryptedData = new JoseWebEncryption (JSONReader);
					//JoseWebEncryption.Deserialize(JSONReader, out EncryptedData) ;
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
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "OfflineEscrowEntry";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public OfflineEscrowEntry () {
			_Initialize ();
			}
        /// <summary>
        /// </summary>		
		public OfflineEscrowEntry (JSONReader JSONReader) {
			Deserialize (JSONReader);
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
        /// </summary>		
		public static new OfflineEscrowEntry From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new OfflineEscrowEntry From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new OfflineEscrowEntry (JSONReader);
			}

        /// <summary>
        /// </summary>		
		public static new OfflineEscrowEntry FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new OfflineEscrowEntry FromTagged (string _Input) {
			OfflineEscrowEntry _Result;
			Deserialize (_Input, out _Result);
			return _Result;
			}


        /// <summary>
        /// 
        /// </summary>
        /// <param name="_Input"></param>
        /// <param name="Out"></param>
        public static void Deserialize(string _Input, out OfflineEscrowEntry Out) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);

			Deserialize (JSONReader, out Out);
			}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Out"></param>
        public static void Deserialize(JSONReader JSONReader, out OfflineEscrowEntry Out) {
	
			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                Out = null;
                return;
                }

			string token = JSONReader.ReadToken ();
			Out = null;

			switch (token) {

				case "OfflineEscrowEntry" : {
					var Result = new OfflineEscrowEntry ();
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

			// should we check for EOF here?
            }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Tag"></param>
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
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "OnlineEscrowEntry";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public OnlineEscrowEntry () {
			_Initialize ();
			}
        /// <summary>
        /// </summary>		
		public OnlineEscrowEntry (JSONReader JSONReader) {
			Deserialize (JSONReader);
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
        /// </summary>		
		public static new OnlineEscrowEntry From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new OnlineEscrowEntry From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new OnlineEscrowEntry (JSONReader);
			}

        /// <summary>
        /// </summary>		
		public static new OnlineEscrowEntry FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new OnlineEscrowEntry FromTagged (string _Input) {
			OnlineEscrowEntry _Result;
			Deserialize (_Input, out _Result);
			return _Result;
			}


        /// <summary>
        /// 
        /// </summary>
        /// <param name="_Input"></param>
        /// <param name="Out"></param>
        public static void Deserialize(string _Input, out OnlineEscrowEntry Out) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);

			Deserialize (JSONReader, out Out);
			}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Out"></param>
        public static void Deserialize(JSONReader JSONReader, out OnlineEscrowEntry Out) {
	
			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                Out = null;
                return;
                }

			string token = JSONReader.ReadToken ();
			Out = null;

			switch (token) {

				case "OnlineEscrowEntry" : {
					var Result = new OnlineEscrowEntry ();
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

			// should we check for EOF here?
            }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Tag"></param>
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
        /// 
        /// </summary>
		public List<Key>				PrivateKeys;

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "EscrowedKeySet";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public EscrowedKeySet () {
			_Initialize ();
			}
        /// <summary>
        /// </summary>		
		public EscrowedKeySet (JSONReader JSONReader) {
			Deserialize (JSONReader);
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
			if (PrivateKeys != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("PrivateKeys", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in PrivateKeys) {
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
        /// </summary>		
		public static new EscrowedKeySet From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new EscrowedKeySet From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new EscrowedKeySet (JSONReader);
			}

        /// <summary>
        /// </summary>		
		public static new EscrowedKeySet FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new EscrowedKeySet FromTagged (string _Input) {
			EscrowedKeySet _Result;
			Deserialize (_Input, out _Result);
			return _Result;
			}


        /// <summary>
        /// 
        /// </summary>
        /// <param name="_Input"></param>
        /// <param name="Out"></param>
        public static void Deserialize(string _Input, out EscrowedKeySet Out) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);

			Deserialize (JSONReader, out Out);
			}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Out"></param>
        public static void Deserialize(JSONReader JSONReader, out EscrowedKeySet Out) {
	
			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                Out = null;
                return;
                }

			string token = JSONReader.ReadToken ();
			Out = null;

			switch (token) {

				case "EscrowedKeySet" : {
					var Result = new EscrowedKeySet ();
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

			// should we check for EOF here?
            }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Tag"></param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "PrivateKeys" : {
					bool _Going = JSONReader.StartArray ();
					PrivateKeys = new List <Key> ();
					while (_Going) {
						var _Item = new Key (JSONReader);
						//Key _Item;
                        //Key.Deserialize(JSONReader, out _Item);

						PrivateKeys.Add (_Item);
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
	/// Describes network connection parameters
	/// </summary>
	public partial class Connection : MeshItem {
        /// <summary>
        /// 
        /// </summary>
		public string						Name;
        /// <summary>
        /// 
        /// </summary>
		public string						Address;
        /// <summary>
        /// 
        /// </summary>
		public string						Prefix;
		bool								__Port = false;
		private int						_Port;
        /// <summary>
        /// 
        /// </summary>
		public int						Port {
			get {return _Port;}
			set {_Port = value; __Port = true; }
			}
        /// <summary>
        /// 
        /// </summary>
		public string						URI;
		/// <summary>
        /// 
        /// </summary>
		public List<string>				Security;

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "Connection";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public Connection () {
			_Initialize ();
			}
        /// <summary>
        /// </summary>		
		public Connection (JSONReader JSONReader) {
			Deserialize (JSONReader);
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
			if (Name != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Name", 1);
					_Writer.WriteString (Name);
				}
			if (Address != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Address", 1);
					_Writer.WriteString (Address);
				}
			if (Prefix != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Prefix", 1);
					_Writer.WriteString (Prefix);
				}
			if (__Port){
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Port", 1);
					_Writer.WriteInteger32 (Port);
				}
			if (URI != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("URI", 1);
					_Writer.WriteString (URI);
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

			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}



        /// <summary>
        /// </summary>		
		public static new Connection From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new Connection From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new Connection (JSONReader);
			}

        /// <summary>
        /// </summary>		
		public static new Connection FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new Connection FromTagged (string _Input) {
			Connection _Result;
			Deserialize (_Input, out _Result);
			return _Result;
			}


        /// <summary>
        /// 
        /// </summary>
        /// <param name="_Input"></param>
        /// <param name="Out"></param>
        public static void Deserialize(string _Input, out Connection Out) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);

			Deserialize (JSONReader, out Out);
			}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Out"></param>
        public static void Deserialize(JSONReader JSONReader, out Connection Out) {
	
			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                Out = null;
                return;
                }

			string token = JSONReader.ReadToken ();
			Out = null;

			switch (token) {

				case "Connection" : {
					var Result = new Connection ();
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

			// should we check for EOF here?
            }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Tag"></param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "Name" : {
					Name = JSONReader.ReadString ();
					break;
					}
				case "Address" : {
					Address = JSONReader.ReadString ();
					break;
					}
				case "Prefix" : {
					Prefix = JSONReader.ReadString ();
					break;
					}
				case "Port" : {
					Port = JSONReader.ReadInteger32 ();
					break;
					}
				case "URI" : {
					URI = JSONReader.ReadString ();
					break;
					}
				case "Security" : {
					bool _Going = JSONReader.StartArray ();
					Security = new List <string> ();
					while (_Going) {
						string _Item = JSONReader.ReadString ();
						Security.Add (_Item);
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
	/// Container for JOSE encrypted data and related attributes.
	/// </summary>
	public partial class EncryptedData : MeshItem {
        /// <summary>
        /// 
        /// </summary>
		public byte[]						Data;

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "EncryptedData";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public EncryptedData () {
			_Initialize ();
			}
        /// <summary>
        /// </summary>		
		public EncryptedData (JSONReader JSONReader) {
			Deserialize (JSONReader);
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
        /// </summary>		
		public static new EncryptedData From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new EncryptedData From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new EncryptedData (JSONReader);
			}

        /// <summary>
        /// </summary>		
		public static new EncryptedData FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new EncryptedData FromTagged (string _Input) {
			EncryptedData _Result;
			Deserialize (_Input, out _Result);
			return _Result;
			}


        /// <summary>
        /// 
        /// </summary>
        /// <param name="_Input"></param>
        /// <param name="Out"></param>
        public static void Deserialize(string _Input, out EncryptedData Out) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);

			Deserialize (JSONReader, out Out);
			}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Out"></param>
        public static void Deserialize(JSONReader JSONReader, out EncryptedData Out) {
	
			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                Out = null;
                return;
                }

			string token = JSONReader.ReadToken ();
			Out = null;

			switch (token) {

				case "EncryptedData" : {
					var Result = new EncryptedData ();
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

			// should we check for EOF here?
            }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Tag"></param>
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
	/// Container for JOSE signed data and related attributes.
	/// </summary>
	public partial class SignedData : MeshItem {
        /// <summary>
        /// 
        /// </summary>
		public byte[]						Data;

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "SignedData";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public SignedData () {
			_Initialize ();
			}
        /// <summary>
        /// </summary>		
		public SignedData (JSONReader JSONReader) {
			Deserialize (JSONReader);
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
        /// </summary>		
		public static new SignedData From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new SignedData From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new SignedData (JSONReader);
			}

        /// <summary>
        /// </summary>		
		public static new SignedData FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new SignedData FromTagged (string _Input) {
			SignedData _Result;
			Deserialize (_Input, out _Result);
			return _Result;
			}


        /// <summary>
        /// 
        /// </summary>
        /// <param name="_Input"></param>
        /// <param name="Out"></param>
        public static void Deserialize(string _Input, out SignedData Out) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);

			Deserialize (JSONReader, out Out);
			}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Out"></param>
        public static void Deserialize(JSONReader JSONReader, out SignedData Out) {
	
			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                Out = null;
                return;
                }

			string token = JSONReader.ReadToken ();
			Out = null;

			switch (token) {

				case "SignedData" : {
					var Result = new SignedData ();
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

			// should we check for EOF here?
            }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Tag"></param>
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
	/// Container for public key pair data
	/// </summary>
	public partial class PublicKey : MeshItem {
        /// <summary>
        /// 
        /// </summary>
		public string						UDF;
        /// <summary>
        /// 
        /// </summary>
		public byte[]						X509Certificate;
		/// <summary>
        /// 
        /// </summary>
		public List<byte[]>				X509Chain;
        /// <summary>
        /// 
        /// </summary>
		public byte[]						X509CSR;
        /// <summary>
        /// 
        /// </summary>
		public Key						PublicParameters;

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "PublicKey";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public PublicKey () {
			_Initialize ();
			}
        /// <summary>
        /// </summary>		
		public PublicKey (JSONReader JSONReader) {
			Deserialize (JSONReader);
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
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}



        /// <summary>
        /// </summary>		
		public static new PublicKey From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new PublicKey From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new PublicKey (JSONReader);
			}

        /// <summary>
        /// </summary>		
		public static new PublicKey FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new PublicKey FromTagged (string _Input) {
			PublicKey _Result;
			Deserialize (_Input, out _Result);
			return _Result;
			}


        /// <summary>
        /// 
        /// </summary>
        /// <param name="_Input"></param>
        /// <param name="Out"></param>
        public static void Deserialize(string _Input, out PublicKey Out) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);

			Deserialize (JSONReader, out Out);
			}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Out"></param>
        public static void Deserialize(JSONReader JSONReader, out PublicKey Out) {
	
			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                Out = null;
                return;
                }

			string token = JSONReader.ReadToken ();
			Out = null;

			switch (token) {

				case "PublicKey" : {
					var Result = new PublicKey ();
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

			// should we check for EOF here?
            }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Tag"></param>
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
					//PublicParameters = new Key (JSONReader);
					Key.Deserialize(JSONReader, out PublicParameters) ;
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
	public partial class ConnectionRequest : MeshItem {
        /// <summary>
        /// 
        /// </summary>
		public string						ParentUDF;
        /// <summary>
        /// 
        /// </summary>
		public SignedDeviceProfile						Device;
        /// <summary>
        /// 
        /// </summary>
		public string						BlockToken;

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "ConnectionRequest";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public ConnectionRequest () {
			_Initialize ();
			}
        /// <summary>
        /// </summary>		
		public ConnectionRequest (JSONReader JSONReader) {
			Deserialize (JSONReader);
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
			if (BlockToken != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("BlockToken", 1);
					_Writer.WriteString (BlockToken);
				}
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}



        /// <summary>
        /// </summary>		
		public static new ConnectionRequest From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new ConnectionRequest From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new ConnectionRequest (JSONReader);
			}

        /// <summary>
        /// </summary>		
		public static new ConnectionRequest FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new ConnectionRequest FromTagged (string _Input) {
			ConnectionRequest _Result;
			Deserialize (_Input, out _Result);
			return _Result;
			}


        /// <summary>
        /// 
        /// </summary>
        /// <param name="_Input"></param>
        /// <param name="Out"></param>
        public static void Deserialize(string _Input, out ConnectionRequest Out) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);

			Deserialize (JSONReader, out Out);
			}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Out"></param>
        public static void Deserialize(JSONReader JSONReader, out ConnectionRequest Out) {
	
			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                Out = null;
                return;
                }

			string token = JSONReader.ReadToken ();
			Out = null;

			switch (token) {

				case "ConnectionRequest" : {
					var Result = new ConnectionRequest ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "ConnectionResult" : {
					var Result = new ConnectionResult ();
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

			// should we check for EOF here?
            }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Tag"></param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "ParentUDF" : {
					ParentUDF = JSONReader.ReadString ();
					break;
					}
				case "Device" : {
					// Field does not have 
					Device = new SignedDeviceProfile (JSONReader);
					//SignedDeviceProfile.Deserialize(JSONReader, out Device) ;
					break;
					}
				case "BlockToken" : {
					BlockToken = JSONReader.ReadString ();
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
	public partial class ConnectionResult : ConnectionRequest {
        /// <summary>
        /// 
        /// </summary>
		public string						Result;

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "ConnectionResult";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public ConnectionResult () {
			_Initialize ();
			}
        /// <summary>
        /// </summary>		
		public ConnectionResult (JSONReader JSONReader) {
			Deserialize (JSONReader);
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
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}



        /// <summary>
        /// </summary>		
		public static new ConnectionResult From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new ConnectionResult From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new ConnectionResult (JSONReader);
			}

        /// <summary>
        /// </summary>		
		public static new ConnectionResult FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new ConnectionResult FromTagged (string _Input) {
			ConnectionResult _Result;
			Deserialize (_Input, out _Result);
			return _Result;
			}


        /// <summary>
        /// 
        /// </summary>
        /// <param name="_Input"></param>
        /// <param name="Out"></param>
        public static void Deserialize(string _Input, out ConnectionResult Out) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);

			Deserialize (JSONReader, out Out);
			}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Out"></param>
        public static void Deserialize(JSONReader JSONReader, out ConnectionResult Out) {
	
			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                Out = null;
                return;
                }

			string token = JSONReader.ReadToken ();
			Out = null;

			switch (token) {

				case "ConnectionResult" : {
					var Result = new ConnectionResult ();
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

			// should we check for EOF here?
            }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Tag"></param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "Result" : {
					Result = JSONReader.ReadString ();
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
	/// Contains a signed connection request
	/// </summary>
	public partial class SignedConnectionRequest : SignedProfile {

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "SignedConnectionRequest";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public SignedConnectionRequest () {
			_Initialize ();
			}
        /// <summary>
        /// </summary>		
		public SignedConnectionRequest (JSONReader JSONReader) {
			Deserialize (JSONReader);
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
        /// </summary>		
		public static new SignedConnectionRequest From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new SignedConnectionRequest From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new SignedConnectionRequest (JSONReader);
			}

        /// <summary>
        /// </summary>		
		public static new SignedConnectionRequest FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new SignedConnectionRequest FromTagged (string _Input) {
			SignedConnectionRequest _Result;
			Deserialize (_Input, out _Result);
			return _Result;
			}


        /// <summary>
        /// 
        /// </summary>
        /// <param name="_Input"></param>
        /// <param name="Out"></param>
        public static void Deserialize(string _Input, out SignedConnectionRequest Out) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);

			Deserialize (JSONReader, out Out);
			}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Out"></param>
        public static void Deserialize(JSONReader JSONReader, out SignedConnectionRequest Out) {
	
			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                Out = null;
                return;
                }

			string token = JSONReader.ReadToken ();
			Out = null;

			switch (token) {

				case "SignedConnectionRequest" : {
					var Result = new SignedConnectionRequest ();
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

			// should we check for EOF here?
            }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Tag"></param>
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
	/// Contains a signed connection request
	/// </summary>
	public partial class SignedConnectionResult : SignedProfile {

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "SignedConnectionResult";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public SignedConnectionResult () {
			_Initialize ();
			}
        /// <summary>
        /// </summary>		
		public SignedConnectionResult (JSONReader JSONReader) {
			Deserialize (JSONReader);
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
        /// </summary>		
		public static new SignedConnectionResult From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new SignedConnectionResult From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new SignedConnectionResult (JSONReader);
			}

        /// <summary>
        /// </summary>		
		public static new SignedConnectionResult FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new SignedConnectionResult FromTagged (string _Input) {
			SignedConnectionResult _Result;
			Deserialize (_Input, out _Result);
			return _Result;
			}


        /// <summary>
        /// 
        /// </summary>
        /// <param name="_Input"></param>
        /// <param name="Out"></param>
        public static void Deserialize(string _Input, out SignedConnectionResult Out) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);

			Deserialize (JSONReader, out Out);
			}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Out"></param>
        public static void Deserialize(JSONReader JSONReader, out SignedConnectionResult Out) {
	
			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                Out = null;
                return;
                }

			string token = JSONReader.ReadToken ();
			Out = null;

			switch (token) {

				case "SignedConnectionResult" : {
					var Result = new SignedConnectionResult ();
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

			// should we check for EOF here?
            }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Tag"></param>
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

