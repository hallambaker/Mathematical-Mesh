
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
	/// Mesh profile for SSH applications.
	/// </summary>
	public abstract partial class MeshSSH : global::Goedel.Protocol.JSONObject {

        /// <summary>
        /// Schema tag.
        /// </summary>
        /// <returns>The tag value</returns>
		public override string Tag () {
			return "MeshSSH";
			}

        /// <summary>
        /// Default constructor.
        /// </summary>
		public MeshSSH () {
			_Initialize () ;
			}

        /// <summary>
        /// Construct an instance from a JSON encoded stream.
        /// </summary>
        /// <param name="JSONReader">Input stream</param>
		public MeshSSH (JSONReader JSONReader) {
			Deserialize (JSONReader);
			_Initialize () ;
			}

        /// <summary>
        /// Construct an instance from a JSON encoded string.
        /// </summary>
        /// <param name="_String">Input string</param>
		public MeshSSH (string _String) {
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

				case "SSHProfile" : {
					var Result = new SSHProfile ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "SSHProfilePrivate" : {
					var Result = new SSHProfilePrivate ();
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


				case "HostEntry" : {
					var Result = new HostEntry ();
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
	/// Application profile for SSH. This is an initial cut of the 
	/// profile and will need revision. In particular, a sysadmin with 
	/// a very large number of hosts they are accessing will need some means
	/// of avoiding combinatorial explosion.
	/// </summary>
	public partial class SSHProfile : ApplicationProfile {

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "SSHProfile";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public SSHProfile () {
			_Initialize ();
			}
        /// <summary>
		/// Initialize class from JSONReader stream.
        /// </summary>		
        /// <param name="JSONReader">Input stream</param>	
		public SSHProfile (JSONReader JSONReader) {
			Deserialize (JSONReader);
			}

        /// <summary> 
		/// Initialize class from a JSON encoded class.
        /// </summary>		
        /// <param name="_String">Input string</param>
		public SSHProfile (string _String) {
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
		public static new SSHProfile From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
		/// Create a new instance from untagged string input.
		/// i.e. {... data ... }
        /// </summary>	
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new SSHProfile From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new SSHProfile (JSONReader);
			}

        /// <summary>
		/// Create a new instance from tagged byte input.
		/// i.e. { "SSHProfile" : {... data ... } }
        /// </summary>	
        /// <param name="_Data">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new SSHProfile FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// Create a new instance from tagged string input.
		/// i.e. { "SSHProfile" : {... data ... } }
        /// </summary>
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>		
		public static new SSHProfile FromTagged (string _Input) {
			//SSHProfile _Result;
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
        public static new SSHProfile  FromTagged (JSONReader JSONReader) {
			SSHProfile Out = null;

			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                return null;
                }

			string token = JSONReader.ReadToken ();

			switch (token) {

				case "SSHProfile" : {
					var Result = new SSHProfile ();
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
	/// Private portion or profile.
	/// </summary>
	public partial class SSHProfilePrivate : ApplicationProfilePrivate {
        /// <summary>
        ///The account to which the profile is bound
        /// </summary>

		public virtual string						Account {
			get {return _Account;}			
			set {_Account = value;}
			}
		string						_Account ;
        /// <summary>
        ///Devices bound to the profile
        /// </summary>

		public virtual List<DeviceEntry>				DeviceEntries {
			get {return _DeviceEntries;}			
			set {_DeviceEntries = value;}
			}
		List<DeviceEntry>				_DeviceEntries;
        /// <summary>
        ///Hosts bound to the profile
        /// </summary>

		public virtual List<HostEntry>				HostEntries {
			get {return _HostEntries;}			
			set {_HostEntries = value;}
			}
		List<HostEntry>				_HostEntries;

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "SSHProfilePrivate";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public SSHProfilePrivate () {
			_Initialize ();
			}
        /// <summary>
		/// Initialize class from JSONReader stream.
        /// </summary>		
        /// <param name="JSONReader">Input stream</param>	
		public SSHProfilePrivate (JSONReader JSONReader) {
			Deserialize (JSONReader);
			}

        /// <summary> 
		/// Initialize class from a JSON encoded class.
        /// </summary>		
        /// <param name="_String">Input string</param>
		public SSHProfilePrivate (string _String) {
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
			((ApplicationProfilePrivate)this).SerializeX(_Writer, false, ref _first);
			if (Account != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Account", 1);
					_Writer.WriteString (Account);
				}
			if (DeviceEntries != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("DeviceEntries", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in DeviceEntries) {
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

			if (HostEntries != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("HostEntries", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in HostEntries) {
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
		public static new SSHProfilePrivate From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
		/// Create a new instance from untagged string input.
		/// i.e. {... data ... }
        /// </summary>	
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new SSHProfilePrivate From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new SSHProfilePrivate (JSONReader);
			}

        /// <summary>
		/// Create a new instance from tagged byte input.
		/// i.e. { "SSHProfilePrivate" : {... data ... } }
        /// </summary>	
        /// <param name="_Data">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new SSHProfilePrivate FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// Create a new instance from tagged string input.
		/// i.e. { "SSHProfilePrivate" : {... data ... } }
        /// </summary>
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>		
		public static new SSHProfilePrivate FromTagged (string _Input) {
			//SSHProfilePrivate _Result;
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
        public static new SSHProfilePrivate  FromTagged (JSONReader JSONReader) {
			SSHProfilePrivate Out = null;

			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                return null;
                }

			string token = JSONReader.ReadToken ();

			switch (token) {

				case "SSHProfilePrivate" : {
					var Result = new SSHProfilePrivate ();
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
				case "Account" : {
					Account = JSONReader.ReadString ();
					break;
					}
				case "DeviceEntries" : {
					// Have a sequence of values
					bool _Going = JSONReader.StartArray ();
					DeviceEntries = new List <DeviceEntry> ();
					while (_Going) {
						// an untagged structure.
						var _Item = new DeviceEntry (JSONReader);
						DeviceEntries.Add (_Item);
						_Going = JSONReader.NextArray ();
						}
					break;
					}
				case "HostEntries" : {
					// Have a sequence of values
					bool _Going = JSONReader.StartArray ();
					HostEntries = new List <HostEntry> ();
					while (_Going) {
						// an untagged structure.
						var _Item = new HostEntry (JSONReader);
						HostEntries.Add (_Item);
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
	/// Describe connection of a device to the SSH profile. This is a 
	/// device on which the user will use an SSH credential.
	/// </summary>
	public partial class DeviceEntry : Entry {
        /// <summary>
        ///Device profile fingerprint.
        /// </summary>

		public virtual string						UDF {
			get {return _UDF;}			
			set {_UDF = value;}
			}
		string						_UDF ;
        /// <summary>
        ///Keys authorized for this device. The private key is generated and stored on 
        ///the device.
        /// </summary>

		public virtual List<PublicKey>				UserKeys {
			get {return _UserKeys;}			
			set {_UserKeys = value;}
			}
		List<PublicKey>				_UserKeys;

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
		/// Initialize class from JSONReader stream.
        /// </summary>		
        /// <param name="JSONReader">Input stream</param>	
		public DeviceEntry (JSONReader JSONReader) {
			Deserialize (JSONReader);
			}

        /// <summary> 
		/// Initialize class from a JSON encoded class.
        /// </summary>		
        /// <param name="_String">Input string</param>
		public DeviceEntry (string _String) {
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
			((Entry)this).SerializeX(_Writer, false, ref _first);
			if (UDF != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("UDF", 1);
					_Writer.WriteString (UDF);
				}
			if (UserKeys != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("UserKeys", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in UserKeys) {
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
		public static new DeviceEntry From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
		/// Create a new instance from untagged string input.
		/// i.e. {... data ... }
        /// </summary>	
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new DeviceEntry From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new DeviceEntry (JSONReader);
			}

        /// <summary>
		/// Create a new instance from tagged byte input.
		/// i.e. { "DeviceEntry" : {... data ... } }
        /// </summary>	
        /// <param name="_Data">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new DeviceEntry FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// Create a new instance from tagged string input.
		/// i.e. { "DeviceEntry" : {... data ... } }
        /// </summary>
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>		
		public static new DeviceEntry FromTagged (string _Input) {
			//DeviceEntry _Result;
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
        public static new DeviceEntry  FromTagged (JSONReader JSONReader) {
			DeviceEntry Out = null;

			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                return null;
                }

			string token = JSONReader.ReadToken ();

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

			return Out;
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
				case "UserKeys" : {
					// Have a sequence of values
					bool _Going = JSONReader.StartArray ();
					UserKeys = new List <PublicKey> ();
					while (_Going) {
						// an untagged structure.
						var _Item = new PublicKey (JSONReader);
						UserKeys.Add (_Item);
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
	/// Describe a host connected to the SSH profile. This is a machine 
	/// that the user will access using the credential.
	/// </summary>
	public partial class HostEntry : Entry {
        /// <summary>
        ///Describe the means of accessing the host (DNS, IP, account, etc.).
        /// </summary>

		public virtual List<Connection>				HostConnection {
			get {return _HostConnection;}			
			set {_HostConnection = value;}
			}
		List<Connection>				_HostConnection;
        /// <summary>
        ///The public keys that are to be added to the host when this profile is
        ///conected.
        /// </summary>

		public virtual List<PublicKey>				HostKeys {
			get {return _HostKeys;}			
			set {_HostKeys = value;}
			}
		List<PublicKey>				_HostKeys;

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "HostEntry";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public HostEntry () {
			_Initialize ();
			}
        /// <summary>
		/// Initialize class from JSONReader stream.
        /// </summary>		
        /// <param name="JSONReader">Input stream</param>	
		public HostEntry (JSONReader JSONReader) {
			Deserialize (JSONReader);
			}

        /// <summary> 
		/// Initialize class from a JSON encoded class.
        /// </summary>		
        /// <param name="_String">Input string</param>
		public HostEntry (string _String) {
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
			((Entry)this).SerializeX(_Writer, false, ref _first);
			if (HostConnection != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("HostConnection", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in HostConnection) {
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

			if (HostKeys != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("HostKeys", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in HostKeys) {
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
		public static new HostEntry From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
		/// Create a new instance from untagged string input.
		/// i.e. {... data ... }
        /// </summary>	
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new HostEntry From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new HostEntry (JSONReader);
			}

        /// <summary>
		/// Create a new instance from tagged byte input.
		/// i.e. { "HostEntry" : {... data ... } }
        /// </summary>	
        /// <param name="_Data">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new HostEntry FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// Create a new instance from tagged string input.
		/// i.e. { "HostEntry" : {... data ... } }
        /// </summary>
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>		
		public static new HostEntry FromTagged (string _Input) {
			//HostEntry _Result;
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
        public static new HostEntry  FromTagged (JSONReader JSONReader) {
			HostEntry Out = null;

			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                return null;
                }

			string token = JSONReader.ReadToken ();

			switch (token) {

				case "HostEntry" : {
					var Result = new HostEntry ();
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
				case "HostConnection" : {
					// Have a sequence of values
					bool _Going = JSONReader.StartArray ();
					HostConnection = new List <Connection> ();
					while (_Going) {
						// an untagged structure.
						var _Item = new Connection (JSONReader);
						HostConnection.Add (_Item);
						_Going = JSONReader.NextArray ();
						}
					break;
					}
				case "HostKeys" : {
					// Have a sequence of values
					bool _Going = JSONReader.StartArray ();
					HostKeys = new List <PublicKey> ();
					while (_Going) {
						// an untagged structure.
						var _Item = new PublicKey (JSONReader);
						HostKeys.Add (_Item);
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

