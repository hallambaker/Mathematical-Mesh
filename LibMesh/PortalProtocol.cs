
//  Test
//  
//  This file was automatically generated at 11/5/2015 12:29:07 AM
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
using Goedel.Mesh;


namespace Goedel.Mesh {


    /// <summary>
    /// 
    /// </summary>
	public abstract partial class Portal : Goedel.Protocol.JSONObject {

        /// <summary>
        /// 
        /// </summary>
		public override string Tag () {
			return "Portal";
			}

        /// <summary>
        /// Default constructor.
        /// </summary>
		public Portal () {
			_Initialize () ;
			}

        /// <summary>
        /// Construct an instance from a JSON encoded stream.
        /// </summary>
		public Portal (JSONReader JSONReader) {
			Deserialize (JSONReader);
			_Initialize () ;
			}

        /// <summary>
        /// Construct an instance from a JSON encoded string.
        /// </summary>
		public Portal (string _String) {
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

				case "PortalEntry" : {
					Out = null;
					throw new Exception ("Can't create abstract type");
					}


				case "Account" : {
					var Result = new Account ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "AccountProfile" : {
					var Result = new AccountProfile ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "ConnectionsPending" : {
					var Result = new ConnectionsPending ();
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
	abstract public partial class PortalEntry : Portal {
		bool								__Created = false;
		private DateTime						_Created;
        /// <summary>
        /// 
        /// </summary>
		public DateTime						Created {
			get {return _Created;}
			set {_Created = value; __Created = true; }
			}
		bool								__Modified = false;
		private DateTime						_Modified;
        /// <summary>
        /// 
        /// </summary>
		public DateTime						Modified {
			get {return _Modified;}
			set {_Modified = value; __Modified = true; }
			}

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "PortalEntry";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public PortalEntry () {
			_Initialize ();
			}
        /// <summary>
        /// </summary>		
		public PortalEntry (JSONReader JSONReader) {
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
			if (__Created){
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Created", 1);
					_Writer.WriteDateTime (Created);
				}
			if (__Modified){
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Modified", 1);
					_Writer.WriteDateTime (Modified);
				}
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}



        /// <summary>
        /// </summary>		
		public static new PortalEntry FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new PortalEntry FromTagged (string _Input) {
			PortalEntry _Result;
			Deserialize (_Input, out _Result);
			return _Result;
			}


        /// <summary>
        /// 
        /// </summary>
        /// <param name="_Input"></param>
        /// <param name="Out"></param>
        public static void Deserialize(string _Input, out PortalEntry Out) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);

			Deserialize (JSONReader, out Out);
			}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Out"></param>
        public static void Deserialize(JSONReader JSONReader, out PortalEntry Out) {
	
			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                Out = null;
                return;
                }

			string token = JSONReader.ReadToken ();
			Out = null;

			switch (token) {

				case "PortalEntry" : {
					Out = null;
					throw new Exception ("Can't create abstract type");
					}

				case "Account" : {
					var Result = new Account ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "AccountProfile" : {
					var Result = new AccountProfile ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "ConnectionsPending" : {
					var Result = new ConnectionsPending ();
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
				case "Created" : {
					Created = JSONReader.ReadDateTime ();
					break;
					}
				case "Modified" : {
					Modified = JSONReader.ReadDateTime ();
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
	/// Entry containing the 
	/// UniqueID is Account[Name]-[Portal]
	/// Indexed by [Name], [UserProfileUDF] [Most recent open]
	/// </summary>
	public partial class Account : PortalEntry {
        /// <summary>
        /// 
        /// </summary>
		public string						AccountID;
        /// <summary>
        /// 
        /// </summary>
		public string						UserProfileUDF;
        /// <summary>
        /// 
        /// </summary>
		public string						Status;

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "Account";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public Account () {
			_Initialize ();
			}
        /// <summary>
        /// </summary>		
		public Account (JSONReader JSONReader) {
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
			((PortalEntry)this).SerializeX(_Writer, false, ref _first);
			if (AccountID != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("AccountID", 1);
					_Writer.WriteString (AccountID);
				}
			if (UserProfileUDF != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("UserProfileUDF", 1);
					_Writer.WriteString (UserProfileUDF);
				}
			if (Status != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Status", 1);
					_Writer.WriteString (Status);
				}
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}



        /// <summary>
        /// </summary>		
		public static new Account From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new Account From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new Account (JSONReader);
			}

        /// <summary>
        /// </summary>		
		public static new Account FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new Account FromTagged (string _Input) {
			Account _Result;
			Deserialize (_Input, out _Result);
			return _Result;
			}


        /// <summary>
        /// 
        /// </summary>
        /// <param name="_Input"></param>
        /// <param name="Out"></param>
        public static void Deserialize(string _Input, out Account Out) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);

			Deserialize (JSONReader, out Out);
			}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Out"></param>
        public static void Deserialize(JSONReader JSONReader, out Account Out) {
	
			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                Out = null;
                return;
                }

			string token = JSONReader.ReadToken ();
			Out = null;

			switch (token) {

				case "Account" : {
					var Result = new Account ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "AccountProfile" : {
					var Result = new AccountProfile ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "ConnectionsPending" : {
					var Result = new ConnectionsPending ();
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
				case "AccountID" : {
					AccountID = JSONReader.ReadString ();
					break;
					}
				case "UserProfileUDF" : {
					UserProfileUDF = JSONReader.ReadString ();
					break;
					}
				case "Status" : {
					Status = JSONReader.ReadString ();
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
	public partial class AccountProfile : Account {
        /// <summary>
        /// 
        /// </summary>
		public SignedPersonalProfile						Profile;

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "AccountProfile";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public AccountProfile () {
			_Initialize ();
			}
        /// <summary>
        /// </summary>		
		public AccountProfile (JSONReader JSONReader) {
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
			((Account)this).SerializeX(_Writer, false, ref _first);
			if (Profile != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Profile", 1);
					Profile.Serialize (_Writer, false);
				}
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}



        /// <summary>
        /// </summary>		
		public static new AccountProfile From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new AccountProfile From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new AccountProfile (JSONReader);
			}

        /// <summary>
        /// </summary>		
		public static new AccountProfile FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new AccountProfile FromTagged (string _Input) {
			AccountProfile _Result;
			Deserialize (_Input, out _Result);
			return _Result;
			}


        /// <summary>
        /// 
        /// </summary>
        /// <param name="_Input"></param>
        /// <param name="Out"></param>
        public static void Deserialize(string _Input, out AccountProfile Out) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);

			Deserialize (JSONReader, out Out);
			}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Out"></param>
        public static void Deserialize(JSONReader JSONReader, out AccountProfile Out) {
	
			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                Out = null;
                return;
                }

			string token = JSONReader.ReadToken ();
			Out = null;

			switch (token) {

				case "AccountProfile" : {
					var Result = new AccountProfile ();
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
				case "Profile" : {
					// Field does not have 
					Profile = new SignedPersonalProfile (JSONReader);
					//SignedPersonalProfile.Deserialize(JSONReader, out Profile) ;
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
	/// Object containing the list of currently pending device connection requests
	/// for the specified account. 
	/// Unique-ID is ConnectionsPending-[UserProfileUDF]
	/// </summary>
	public partial class ConnectionsPending : Account {
		/// <summary>
        /// 
        /// </summary>
		public List<SignedConnectionRequest>				Requests;

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "ConnectionsPending";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public ConnectionsPending () {
			_Initialize ();
			}
        /// <summary>
        /// </summary>		
		public ConnectionsPending (JSONReader JSONReader) {
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
			((Account)this).SerializeX(_Writer, false, ref _first);
			if (Requests != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Requests", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in Requests) {
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
		public static new ConnectionsPending From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new ConnectionsPending From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new ConnectionsPending (JSONReader);
			}

        /// <summary>
        /// </summary>		
		public static new ConnectionsPending FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new ConnectionsPending FromTagged (string _Input) {
			ConnectionsPending _Result;
			Deserialize (_Input, out _Result);
			return _Result;
			}


        /// <summary>
        /// 
        /// </summary>
        /// <param name="_Input"></param>
        /// <param name="Out"></param>
        public static void Deserialize(string _Input, out ConnectionsPending Out) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);

			Deserialize (JSONReader, out Out);
			}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Out"></param>
        public static void Deserialize(JSONReader JSONReader, out ConnectionsPending Out) {
	
			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                Out = null;
                return;
                }

			string token = JSONReader.ReadToken ();
			Out = null;

			switch (token) {

				case "ConnectionsPending" : {
					var Result = new ConnectionsPending ();
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
				case "Requests" : {
					bool _Going = JSONReader.StartArray ();
					Requests = new List <SignedConnectionRequest> ();
					while (_Going) {
						var _Item = new SignedConnectionRequest (JSONReader);
						//SignedConnectionRequest _Item;
                        //SignedConnectionRequest.Deserialize(JSONReader, out _Item);

						Requests.Add (_Item);
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

	}

