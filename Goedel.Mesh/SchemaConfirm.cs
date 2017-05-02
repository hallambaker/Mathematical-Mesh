
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
	/// Mesh profile for Confirm applications.
	/// </summary>
	public abstract partial class MeshConfirm : global::Goedel.Protocol.JSONObject {

        /// <summary>
        /// Schema tag.
        /// </summary>
        /// <returns>The tag value</returns>
		public override string Tag () {
			return "MeshConfirm";
			}

        /// <summary>
        /// Default constructor.
        /// </summary>
		public MeshConfirm () {
			_Initialize () ;
			}

        /// <summary>
        /// Construct an instance from a JSON encoded stream.
        /// </summary>
        /// <param name="JSONReader">Input stream</param>
		public MeshConfirm (JSONReader JSONReader) {
			Deserialize (JSONReader);
			_Initialize () ;
			}

        /// <summary>
        /// Construct an instance from a JSON encoded string.
        /// </summary>
        /// <param name="_String">Input string</param>
		public MeshConfirm (string _String) {
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

				case "ConfirmProfile" : {
					var Result = new ConfirmProfile ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "ConfirmPrivate" : {
					var Result = new ConfirmPrivate ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "ConfirmDevicePublic" : {
					var Result = new ConfirmDevicePublic ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "ConfirmDevicePrivate" : {
					var Result = new ConfirmDevicePrivate ();
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
	/// Application profile for Confirm
	/// </summary>
	public partial class ConfirmProfile : ApplicationProfile {
        /// <summary>
        ///The account to which the profile is bound
        /// </summary>

		public virtual string						Account  {get; set;}
        /// <summary>
        ///Authorized Authentication keys for this account. Authentication
        ///keys provide authentication without providing non-repudiability.
        ///This permits their use in cases where it is desirable to avoid
        ///the possibility of contractual binding.
        /// </summary>

		public virtual List<PublicKey>				Authentication  {get; set;}
        /// <summary>
        ///Authorized Signature keys for this account.Signature keys
        ///provide non-repudiable authentication of a response. This permits
        ///their use in cases where it is desirable to provide the possibility
        ///of contractual binding.
        /// </summary>

		public virtual List<PublicKey>				Signature  {get; set;}

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "ConfirmProfile";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public ConfirmProfile () {
			_Initialize ();
			}
        /// <summary>
		/// Initialize class from JSONReader stream.
        /// </summary>		
        /// <param name="JSONReader">Input stream</param>	
		public ConfirmProfile (JSONReader JSONReader) {
			Deserialize (JSONReader);
			}

        /// <summary> 
		/// Initialize class from a JSON encoded class.
        /// </summary>		
        /// <param name="_String">Input string</param>
		public ConfirmProfile (string _String) {
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
			if (Account != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Account", 1);
					_Writer.WriteString (Account);
				}
			if (Authentication != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Authentication", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in Authentication) {
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

			if (Signature != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Signature", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in Signature) {
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
		public static new ConfirmProfile From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
		/// Create a new instance from untagged string input.
		/// i.e. {... data ... }
        /// </summary>	
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new ConfirmProfile From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new ConfirmProfile (JSONReader);
			}

        /// <summary>
		/// Create a new instance from tagged byte input.
		/// i.e. { "ConfirmProfile" : {... data ... } }
        /// </summary>	
        /// <param name="_Data">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new ConfirmProfile FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// Create a new instance from tagged string input.
		/// i.e. { "ConfirmProfile" : {... data ... } }
        /// </summary>
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>		
		public static new ConfirmProfile FromTagged (string _Input) {
			//ConfirmProfile _Result;
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
        public static new ConfirmProfile  FromTagged (JSONReader JSONReader) {
			ConfirmProfile Out = null;

			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                return null;
                }

			string token = JSONReader.ReadToken ();

			switch (token) {

				case "ConfirmProfile" : {
					var Result = new ConfirmProfile ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				default : {
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
				case "Authentication" : {
					// Have a sequence of values
					bool _Going = JSONReader.StartArray ();
					Authentication = new List <PublicKey> ();
					while (_Going) {
						// an untagged structure.
						var _Item = new PublicKey (JSONReader);
						Authentication.Add (_Item);
						_Going = JSONReader.NextArray ();
						}
					break;
					}
				case "Signature" : {
					// Have a sequence of values
					bool _Going = JSONReader.StartArray ();
					Signature = new List <PublicKey> ();
					while (_Going) {
						// an untagged structure.
						var _Item = new PublicKey (JSONReader);
						Signature.Add (_Item);
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
	/// Private portion of profile. Currently empty.
	/// </summary>
	public partial class ConfirmPrivate : ApplicationProfilePrivate {

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "ConfirmPrivate";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public ConfirmPrivate () {
			_Initialize ();
			}
        /// <summary>
		/// Initialize class from JSONReader stream.
        /// </summary>		
        /// <param name="JSONReader">Input stream</param>	
		public ConfirmPrivate (JSONReader JSONReader) {
			Deserialize (JSONReader);
			}

        /// <summary> 
		/// Initialize class from a JSON encoded class.
        /// </summary>		
        /// <param name="_String">Input string</param>
		public ConfirmPrivate (string _String) {
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
		public static new ConfirmPrivate From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
		/// Create a new instance from untagged string input.
		/// i.e. {... data ... }
        /// </summary>	
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new ConfirmPrivate From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new ConfirmPrivate (JSONReader);
			}

        /// <summary>
		/// Create a new instance from tagged byte input.
		/// i.e. { "ConfirmPrivate" : {... data ... } }
        /// </summary>	
        /// <param name="_Data">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new ConfirmPrivate FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// Create a new instance from tagged string input.
		/// i.e. { "ConfirmPrivate" : {... data ... } }
        /// </summary>
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>		
		public static new ConfirmPrivate FromTagged (string _Input) {
			//ConfirmPrivate _Result;
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
        public static new ConfirmPrivate  FromTagged (JSONReader JSONReader) {
			ConfirmPrivate Out = null;

			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                return null;
                }

			string token = JSONReader.ReadToken ();

			switch (token) {

				case "ConfirmPrivate" : {
					var Result = new ConfirmPrivate ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				default : {
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
	/// Public data specific to the device
	/// </summary>
	public partial class ConfirmDevicePublic : ApplicationDevicePublic {
        /// <summary>
        ///A private keypair or keypair contribution created for exclusive use 
        ///of this device.
        /// </summary>

		public virtual PublicKey						SignPublicKey  {get; set;}
        /// <summary>
        ///A private keypair or keypair contribution created for exclusive use 
        ///of this device.
        /// </summary>

		public virtual PublicKey						AuthPublicKey  {get; set;}

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "ConfirmDevicePublic";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public ConfirmDevicePublic () {
			_Initialize ();
			}
        /// <summary>
		/// Initialize class from JSONReader stream.
        /// </summary>		
        /// <param name="JSONReader">Input stream</param>	
		public ConfirmDevicePublic (JSONReader JSONReader) {
			Deserialize (JSONReader);
			}

        /// <summary> 
		/// Initialize class from a JSON encoded class.
        /// </summary>		
        /// <param name="_String">Input string</param>
		public ConfirmDevicePublic (string _String) {
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
			((ApplicationDevicePublic)this).SerializeX(_Writer, false, ref _first);
			if (SignPublicKey != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("SignPublicKey", 1);
					SignPublicKey.Serialize (_Writer, false);
				}
			if (AuthPublicKey != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("AuthPublicKey", 1);
					AuthPublicKey.Serialize (_Writer, false);
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
		public static new ConfirmDevicePublic From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
		/// Create a new instance from untagged string input.
		/// i.e. {... data ... }
        /// </summary>	
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new ConfirmDevicePublic From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new ConfirmDevicePublic (JSONReader);
			}

        /// <summary>
		/// Create a new instance from tagged byte input.
		/// i.e. { "ConfirmDevicePublic" : {... data ... } }
        /// </summary>	
        /// <param name="_Data">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new ConfirmDevicePublic FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// Create a new instance from tagged string input.
		/// i.e. { "ConfirmDevicePublic" : {... data ... } }
        /// </summary>
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>		
		public static new ConfirmDevicePublic FromTagged (string _Input) {
			//ConfirmDevicePublic _Result;
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
        public static new ConfirmDevicePublic  FromTagged (JSONReader JSONReader) {
			ConfirmDevicePublic Out = null;

			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                return null;
                }

			string token = JSONReader.ReadToken ();

			switch (token) {

				case "ConfirmDevicePublic" : {
					var Result = new ConfirmDevicePublic ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				default : {
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
				case "SignPublicKey" : {
					// An untagged structure
					SignPublicKey = new PublicKey (JSONReader);
 
					break;
					}
				case "AuthPublicKey" : {
					// An untagged structure
					AuthPublicKey = new PublicKey (JSONReader);
 
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
	public partial class ConfirmDevicePrivate : ApplicationDevicePrivate {
        /// <summary>
        ///A private keypair or keypair contribution created for exclusive use 
        ///of this device.
        /// </summary>

		public virtual PublicKey						SignPrivateKey  {get; set;}
        /// <summary>
        ///A private keypair or keypair contribution created for exclusive use 
        ///of this device.
        /// </summary>

		public virtual PublicKey						AuthPrivateKey  {get; set;}

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "ConfirmDevicePrivate";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public ConfirmDevicePrivate () {
			_Initialize ();
			}
        /// <summary>
		/// Initialize class from JSONReader stream.
        /// </summary>		
        /// <param name="JSONReader">Input stream</param>	
		public ConfirmDevicePrivate (JSONReader JSONReader) {
			Deserialize (JSONReader);
			}

        /// <summary> 
		/// Initialize class from a JSON encoded class.
        /// </summary>		
        /// <param name="_String">Input string</param>
		public ConfirmDevicePrivate (string _String) {
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
			((ApplicationDevicePrivate)this).SerializeX(_Writer, false, ref _first);
			if (SignPrivateKey != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("SignPrivateKey", 1);
					SignPrivateKey.Serialize (_Writer, false);
				}
			if (AuthPrivateKey != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("AuthPrivateKey", 1);
					AuthPrivateKey.Serialize (_Writer, false);
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
		public static new ConfirmDevicePrivate From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
		/// Create a new instance from untagged string input.
		/// i.e. {... data ... }
        /// </summary>	
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new ConfirmDevicePrivate From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new ConfirmDevicePrivate (JSONReader);
			}

        /// <summary>
		/// Create a new instance from tagged byte input.
		/// i.e. { "ConfirmDevicePrivate" : {... data ... } }
        /// </summary>	
        /// <param name="_Data">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new ConfirmDevicePrivate FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// Create a new instance from tagged string input.
		/// i.e. { "ConfirmDevicePrivate" : {... data ... } }
        /// </summary>
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>		
		public static new ConfirmDevicePrivate FromTagged (string _Input) {
			//ConfirmDevicePrivate _Result;
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
        public static new ConfirmDevicePrivate  FromTagged (JSONReader JSONReader) {
			ConfirmDevicePrivate Out = null;

			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                return null;
                }

			string token = JSONReader.ReadToken ();

			switch (token) {

				case "ConfirmDevicePrivate" : {
					var Result = new ConfirmDevicePrivate ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				default : {
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
				case "SignPrivateKey" : {
					// An untagged structure
					SignPrivateKey = new PublicKey (JSONReader);
 
					break;
					}
				case "AuthPrivateKey" : {
					// An untagged structure
					AuthPrivateKey = new PublicKey (JSONReader);
 
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

