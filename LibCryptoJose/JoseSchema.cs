
//  Test
//  
//  This file was automatically generated at 11/9/2015 11:31:27 PM
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






namespace Goedel.Cryptography.Jose {


    /// <summary>
    /// 
    /// </summary>
	public abstract partial class Jose : Goedel.Protocol.JSONObject {

        /// <summary>
        /// 
        /// </summary>
		public override string Tag () {
			return "Jose";
			}

        /// <summary>
        /// Default constructor.
        /// </summary>
		public Jose () {
			_Initialize () ;
			}

        /// <summary>
        /// Construct an instance from a JSON encoded stream.
        /// </summary>
		public Jose (JSONReader JSONReader) {
			Deserialize (JSONReader);
			_Initialize () ;
			}

        /// <summary>
        /// Construct an instance from a JSON encoded string.
        /// </summary>
		public Jose (string _String) {
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

				case "JoseWebSignature" : {
					var Result = new JoseWebSignature ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "JoseWebEncryption" : {
					var Result = new JoseWebEncryption ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "Signed" : {
					var Result = new Signed ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "Encrypted" : {
					var Result = new Encrypted ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "KeyData" : {
					var Result = new KeyData ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "Header" : {
					var Result = new Header ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "Key" : {
					var Result = new Key ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "Recipient" : {
					var Result = new Recipient ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "PublicKeyRSA" : {
					var Result = new PublicKeyRSA ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "PrivateKeyRSA" : {
					var Result = new PrivateKeyRSA ();
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
	public partial class JoseWebSignature : Jose {
        /// <summary>
        /// 
        /// </summary>
		public byte[]						Protected;
        /// <summary>
        /// 
        /// </summary>
		public byte[]						Header;
        /// <summary>
        /// 
        /// </summary>
		public byte[]						Payload;
        /// <summary>
        /// 
        /// </summary>
		public byte[]						Signature;

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "JoseWebSignature";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public JoseWebSignature () {
			_Initialize ();
			}
        /// <summary>
        /// </summary>		
		public JoseWebSignature (JSONReader JSONReader) {
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
			if (Protected != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("protected", 1);
					_Writer.WriteBinary (Protected);
				}
			if (Header != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("header", 1);
					_Writer.WriteBinary (Header);
				}
			if (Payload != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("payload", 1);
					_Writer.WriteBinary (Payload);
				}
			if (Signature != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("signature", 1);
					_Writer.WriteBinary (Signature);
				}
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}



        /// <summary>
        /// </summary>		
		public static new JoseWebSignature From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new JoseWebSignature From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new JoseWebSignature (JSONReader);
			}

        /// <summary>
        /// </summary>		
		public static new JoseWebSignature FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new JoseWebSignature FromTagged (string _Input) {
			JoseWebSignature _Result;
			Deserialize (_Input, out _Result);
			return _Result;
			}


        /// <summary>
        /// 
        /// </summary>
        /// <param name="_Input"></param>
        /// <param name="Out"></param>
        public static void Deserialize(string _Input, out JoseWebSignature Out) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);

			Deserialize (JSONReader, out Out);
			}

        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader"></param>
        public static JoseWebSignature  DeserializeTagged (JSONReader JSONReader) {
			JoseWebSignature Result;
			Deserialize (JSONReader, out Result);
			return Result;
			}

        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Out"></param>
        public static void Deserialize(JSONReader JSONReader, out JoseWebSignature Out) {
	
			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                Out = null;
                return;
                }

			string token = JSONReader.ReadToken ();
			Out = null;

			switch (token) {

				case "JoseWebSignature" : {
					var Result = new JoseWebSignature ();
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
				case "protected" : {
					Protected = JSONReader.ReadBinary ();
					break;
					}
				case "header" : {
					Header = JSONReader.ReadBinary ();
					break;
					}
				case "payload" : {
					Payload = JSONReader.ReadBinary ();
					break;
					}
				case "signature" : {
					Signature = JSONReader.ReadBinary ();
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
	public partial class JoseWebEncryption : Jose {
        /// <summary>
        /// 
        /// </summary>
		public byte[]						Protected;
        /// <summary>
        /// 
        /// </summary>
		public byte[]						Unprotected;
        /// <summary>
        /// 
        /// </summary>
		public byte[]						IV;
        /// <summary>
        /// 
        /// </summary>
		public byte[]						CipherText;
        /// <summary>
        /// 
        /// </summary>
		public byte[]						JTag;
        /// <summary>
        /// 
        /// </summary>
		public byte[]						AdditionalAuthenticatedData;
		/// <summary>
        /// 
        /// </summary>
		public List<Recipient>				Recipients;

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "JoseWebEncryption";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public JoseWebEncryption () {
			_Initialize ();
			}
        /// <summary>
        /// </summary>		
		public JoseWebEncryption (JSONReader JSONReader) {
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
			if (Protected != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("protected", 1);
					_Writer.WriteBinary (Protected);
				}
			if (Unprotected != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("unprotected", 1);
					_Writer.WriteBinary (Unprotected);
				}
			if (IV != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("iv", 1);
					_Writer.WriteBinary (IV);
				}
			if (CipherText != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("ciphertext", 1);
					_Writer.WriteBinary (CipherText);
				}
			if (JTag != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("tag", 1);
					_Writer.WriteBinary (JTag);
				}
			if (AdditionalAuthenticatedData != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("aad", 1);
					_Writer.WriteBinary (AdditionalAuthenticatedData);
				}
			if (Recipients != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("recipients", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in Recipients) {
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
		public static new JoseWebEncryption From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new JoseWebEncryption From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new JoseWebEncryption (JSONReader);
			}

        /// <summary>
        /// </summary>		
		public static new JoseWebEncryption FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new JoseWebEncryption FromTagged (string _Input) {
			JoseWebEncryption _Result;
			Deserialize (_Input, out _Result);
			return _Result;
			}


        /// <summary>
        /// 
        /// </summary>
        /// <param name="_Input"></param>
        /// <param name="Out"></param>
        public static void Deserialize(string _Input, out JoseWebEncryption Out) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);

			Deserialize (JSONReader, out Out);
			}

        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader"></param>
        public static JoseWebEncryption  DeserializeTagged (JSONReader JSONReader) {
			JoseWebEncryption Result;
			Deserialize (JSONReader, out Result);
			return Result;
			}

        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Out"></param>
        public static void Deserialize(JSONReader JSONReader, out JoseWebEncryption Out) {
	
			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                Out = null;
                return;
                }

			string token = JSONReader.ReadToken ();
			Out = null;

			switch (token) {

				case "JoseWebEncryption" : {
					var Result = new JoseWebEncryption ();
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
				case "protected" : {
					Protected = JSONReader.ReadBinary ();
					break;
					}
				case "unprotected" : {
					Unprotected = JSONReader.ReadBinary ();
					break;
					}
				case "iv" : {
					IV = JSONReader.ReadBinary ();
					break;
					}
				case "ciphertext" : {
					CipherText = JSONReader.ReadBinary ();
					break;
					}
				case "tag" : {
					JTag = JSONReader.ReadBinary ();
					break;
					}
				case "aad" : {
					AdditionalAuthenticatedData = JSONReader.ReadBinary ();
					break;
					}
				case "recipients" : {
					bool _Going = JSONReader.StartArray ();
					Recipients = new List <Recipient> ();
					while (_Going) {
						var _Item = new Recipient (JSONReader);
						//Recipient _Item;
                        //Recipient.Deserialize(JSONReader, out _Item);

						Recipients.Add (_Item);
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
	public partial class Signed : Jose {
        /// <summary>
        /// 
        /// </summary>
		public Header						Header;
        /// <summary>
        /// 
        /// </summary>
		public byte[]						Payload;
        /// <summary>
        /// 
        /// </summary>
		public byte[]						Signature;

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "Signed";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public Signed () {
			_Initialize ();
			}
        /// <summary>
        /// </summary>		
		public Signed (JSONReader JSONReader) {
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
			if (Header != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("header", 1);
					Header.Serialize (_Writer, false);
				}
			if (Payload != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("payload", 1);
					_Writer.WriteBinary (Payload);
				}
			if (Signature != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("signature", 1);
					_Writer.WriteBinary (Signature);
				}
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}



        /// <summary>
        /// </summary>		
		public static new Signed From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new Signed From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new Signed (JSONReader);
			}

        /// <summary>
        /// </summary>		
		public static new Signed FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new Signed FromTagged (string _Input) {
			Signed _Result;
			Deserialize (_Input, out _Result);
			return _Result;
			}


        /// <summary>
        /// 
        /// </summary>
        /// <param name="_Input"></param>
        /// <param name="Out"></param>
        public static void Deserialize(string _Input, out Signed Out) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);

			Deserialize (JSONReader, out Out);
			}

        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader"></param>
        public static Signed  DeserializeTagged (JSONReader JSONReader) {
			Signed Result;
			Deserialize (JSONReader, out Result);
			return Result;
			}

        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Out"></param>
        public static void Deserialize(JSONReader JSONReader, out Signed Out) {
	
			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                Out = null;
                return;
                }

			string token = JSONReader.ReadToken ();
			Out = null;

			switch (token) {

				case "Signed" : {
					var Result = new Signed ();
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
				case "header" : {
					// Field does not have 
					Header = new Header (JSONReader);
					//Header.Deserialize(JSONReader, out Header) ;
					break;
					}
				case "payload" : {
					Payload = JSONReader.ReadBinary ();
					break;
					}
				case "signature" : {
					Signature = JSONReader.ReadBinary ();
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
	public partial class Encrypted : Jose {
        /// <summary>
        /// 
        /// </summary>
		public Header						Header;
        /// <summary>
        /// 
        /// </summary>
		public byte[]						IV;
        /// <summary>
        /// 
        /// </summary>
		public byte[]						CipherText;
        /// <summary>
        /// 
        /// </summary>
		public byte[]						Signature;

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "Encrypted";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public Encrypted () {
			_Initialize ();
			}
        /// <summary>
        /// </summary>		
		public Encrypted (JSONReader JSONReader) {
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
			if (Header != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("header", 1);
					Header.Serialize (_Writer, false);
				}
			if (IV != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("iv", 1);
					_Writer.WriteBinary (IV);
				}
			if (CipherText != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("ciphertext", 1);
					_Writer.WriteBinary (CipherText);
				}
			if (Signature != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("signature", 1);
					_Writer.WriteBinary (Signature);
				}
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}



        /// <summary>
        /// </summary>		
		public static new Encrypted From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new Encrypted From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new Encrypted (JSONReader);
			}

        /// <summary>
        /// </summary>		
		public static new Encrypted FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new Encrypted FromTagged (string _Input) {
			Encrypted _Result;
			Deserialize (_Input, out _Result);
			return _Result;
			}


        /// <summary>
        /// 
        /// </summary>
        /// <param name="_Input"></param>
        /// <param name="Out"></param>
        public static void Deserialize(string _Input, out Encrypted Out) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);

			Deserialize (JSONReader, out Out);
			}

        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader"></param>
        public static Encrypted  DeserializeTagged (JSONReader JSONReader) {
			Encrypted Result;
			Deserialize (JSONReader, out Result);
			return Result;
			}

        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Out"></param>
        public static void Deserialize(JSONReader JSONReader, out Encrypted Out) {
	
			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                Out = null;
                return;
                }

			string token = JSONReader.ReadToken ();
			Out = null;

			switch (token) {

				case "Encrypted" : {
					var Result = new Encrypted ();
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
				case "header" : {
					// Field does not have 
					Header = new Header (JSONReader);
					//Header.Deserialize(JSONReader, out Header) ;
					break;
					}
				case "iv" : {
					IV = JSONReader.ReadBinary ();
					break;
					}
				case "ciphertext" : {
					CipherText = JSONReader.ReadBinary ();
					break;
					}
				case "signature" : {
					Signature = JSONReader.ReadBinary ();
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
	public partial class KeyData : Jose {
        /// <summary>
        /// 
        /// </summary>
		public string						enc;
        /// <summary>
        /// 
        /// </summary>
		public string						alg;
        /// <summary>
        /// 
        /// </summary>
		public string						kid;
        /// <summary>
        /// 
        /// </summary>
		public string						x5u;
        /// <summary>
        /// 
        /// </summary>
		public byte[]						x5c;
        /// <summary>
        /// 
        /// </summary>
		public byte[]						x5t;
        /// <summary>
        /// 
        /// </summary>
		public byte[]						x5tS256;

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "KeyData";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public KeyData () {
			_Initialize ();
			}
        /// <summary>
        /// </summary>		
		public KeyData (JSONReader JSONReader) {
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
			if (enc != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("enc", 1);
					_Writer.WriteString (enc);
				}
			if (alg != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("alg", 1);
					_Writer.WriteString (alg);
				}
			if (kid != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("kid", 1);
					_Writer.WriteString (kid);
				}
			if (x5u != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("x5u", 1);
					_Writer.WriteString (x5u);
				}
			if (x5c != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("x5c", 1);
					_Writer.WriteBinary (x5c);
				}
			if (x5t != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("x5t", 1);
					_Writer.WriteBinary (x5t);
				}
			if (x5tS256 != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("x5t#S256", 1);
					_Writer.WriteBinary (x5tS256);
				}
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}



        /// <summary>
        /// </summary>		
		public static new KeyData From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new KeyData From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new KeyData (JSONReader);
			}

        /// <summary>
        /// </summary>		
		public static new KeyData FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new KeyData FromTagged (string _Input) {
			KeyData _Result;
			Deserialize (_Input, out _Result);
			return _Result;
			}


        /// <summary>
        /// 
        /// </summary>
        /// <param name="_Input"></param>
        /// <param name="Out"></param>
        public static void Deserialize(string _Input, out KeyData Out) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);

			Deserialize (JSONReader, out Out);
			}

        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader"></param>
        public static KeyData  DeserializeTagged (JSONReader JSONReader) {
			KeyData Result;
			Deserialize (JSONReader, out Result);
			return Result;
			}

        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Out"></param>
        public static void Deserialize(JSONReader JSONReader, out KeyData Out) {
	
			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                Out = null;
                return;
                }

			string token = JSONReader.ReadToken ();
			Out = null;

			switch (token) {

				case "KeyData" : {
					var Result = new KeyData ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "Header" : {
					var Result = new Header ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "Key" : {
					var Result = new Key ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "PublicKeyRSA" : {
					var Result = new PublicKeyRSA ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "PrivateKeyRSA" : {
					var Result = new PrivateKeyRSA ();
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
				case "enc" : {
					enc = JSONReader.ReadString ();
					break;
					}
				case "alg" : {
					alg = JSONReader.ReadString ();
					break;
					}
				case "kid" : {
					kid = JSONReader.ReadString ();
					break;
					}
				case "x5u" : {
					x5u = JSONReader.ReadString ();
					break;
					}
				case "x5c" : {
					x5c = JSONReader.ReadBinary ();
					break;
					}
				case "x5t" : {
					x5t = JSONReader.ReadBinary ();
					break;
					}
				case "x5t#S256" : {
					x5tS256 = JSONReader.ReadBinary ();
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
	public partial class Header : KeyData {
        /// <summary>
        /// 
        /// </summary>
		public string						jku;
        /// <summary>
        /// 
        /// </summary>
		public string						jwk;
        /// <summary>
        /// 
        /// </summary>
		public string						typ;
        /// <summary>
        /// 
        /// </summary>
		public string						cty;
        /// <summary>
        /// 
        /// </summary>
		public string						crit;

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "Header";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public Header () {
			_Initialize ();
			}
        /// <summary>
        /// </summary>		
		public Header (JSONReader JSONReader) {
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
			((KeyData)this).SerializeX(_Writer, false, ref _first);
			if (jku != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("jku", 1);
					_Writer.WriteString (jku);
				}
			if (jwk != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("jwk", 1);
					_Writer.WriteString (jwk);
				}
			if (typ != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("typ", 1);
					_Writer.WriteString (typ);
				}
			if (cty != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("cty", 1);
					_Writer.WriteString (cty);
				}
			if (crit != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("crit", 1);
					_Writer.WriteString (crit);
				}
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}



        /// <summary>
        /// </summary>		
		public static new Header From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new Header From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new Header (JSONReader);
			}

        /// <summary>
        /// </summary>		
		public static new Header FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new Header FromTagged (string _Input) {
			Header _Result;
			Deserialize (_Input, out _Result);
			return _Result;
			}


        /// <summary>
        /// 
        /// </summary>
        /// <param name="_Input"></param>
        /// <param name="Out"></param>
        public static void Deserialize(string _Input, out Header Out) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);

			Deserialize (JSONReader, out Out);
			}

        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader"></param>
        public static Header  DeserializeTagged (JSONReader JSONReader) {
			Header Result;
			Deserialize (JSONReader, out Result);
			return Result;
			}

        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Out"></param>
        public static void Deserialize(JSONReader JSONReader, out Header Out) {
	
			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                Out = null;
                return;
                }

			string token = JSONReader.ReadToken ();
			Out = null;

			switch (token) {

				case "Header" : {
					var Result = new Header ();
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
				case "jku" : {
					jku = JSONReader.ReadString ();
					break;
					}
				case "jwk" : {
					jwk = JSONReader.ReadString ();
					break;
					}
				case "typ" : {
					typ = JSONReader.ReadString ();
					break;
					}
				case "cty" : {
					cty = JSONReader.ReadString ();
					break;
					}
				case "crit" : {
					crit = JSONReader.ReadString ();
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
	public partial class Key : KeyData {
        /// <summary>
        /// 
        /// </summary>
		public string						kty;
        /// <summary>
        /// 
        /// </summary>
		public string						use;
        /// <summary>
        /// 
        /// </summary>
		public string						key_ops;
        /// <summary>
        /// 
        /// </summary>
		public byte[]						k;

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "Key";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public Key () {
			_Initialize ();
			}
        /// <summary>
        /// </summary>		
		public Key (JSONReader JSONReader) {
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
			((KeyData)this).SerializeX(_Writer, false, ref _first);
			if (kty != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("kty", 1);
					_Writer.WriteString (kty);
				}
			if (use != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("use", 1);
					_Writer.WriteString (use);
				}
			if (key_ops != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("key_ops", 1);
					_Writer.WriteString (key_ops);
				}
			if (k != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("k", 1);
					_Writer.WriteBinary (k);
				}
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}



        /// <summary>
        /// </summary>		
		public static new Key From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new Key From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new Key (JSONReader);
			}

        /// <summary>
        /// </summary>		
		public static new Key FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new Key FromTagged (string _Input) {
			Key _Result;
			Deserialize (_Input, out _Result);
			return _Result;
			}


        /// <summary>
        /// 
        /// </summary>
        /// <param name="_Input"></param>
        /// <param name="Out"></param>
        public static void Deserialize(string _Input, out Key Out) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);

			Deserialize (JSONReader, out Out);
			}

        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader"></param>
        public static Key  DeserializeTagged (JSONReader JSONReader) {
			Key Result;
			Deserialize (JSONReader, out Result);
			return Result;
			}

        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Out"></param>
        public static void Deserialize(JSONReader JSONReader, out Key Out) {
	
			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                Out = null;
                return;
                }

			string token = JSONReader.ReadToken ();
			Out = null;

			switch (token) {

				case "Key" : {
					var Result = new Key ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "PublicKeyRSA" : {
					var Result = new PublicKeyRSA ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "PrivateKeyRSA" : {
					var Result = new PrivateKeyRSA ();
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
				case "kty" : {
					kty = JSONReader.ReadString ();
					break;
					}
				case "use" : {
					use = JSONReader.ReadString ();
					break;
					}
				case "key_ops" : {
					key_ops = JSONReader.ReadString ();
					break;
					}
				case "k" : {
					k = JSONReader.ReadBinary ();
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
	public partial class Recipient : Jose {
        /// <summary>
        /// 
        /// </summary>
		public Header						Header;
        /// <summary>
        /// 
        /// </summary>
		public byte[]						EncryptedKey;

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "Recipient";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public Recipient () {
			_Initialize ();
			}
        /// <summary>
        /// </summary>		
		public Recipient (JSONReader JSONReader) {
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
			if (Header != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Header", 1);
					Header.Serialize (_Writer, false);
				}
			if (EncryptedKey != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("encrypted_key", 1);
					_Writer.WriteBinary (EncryptedKey);
				}
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}



        /// <summary>
        /// </summary>		
		public static new Recipient From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new Recipient From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new Recipient (JSONReader);
			}

        /// <summary>
        /// </summary>		
		public static new Recipient FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new Recipient FromTagged (string _Input) {
			Recipient _Result;
			Deserialize (_Input, out _Result);
			return _Result;
			}


        /// <summary>
        /// 
        /// </summary>
        /// <param name="_Input"></param>
        /// <param name="Out"></param>
        public static void Deserialize(string _Input, out Recipient Out) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);

			Deserialize (JSONReader, out Out);
			}

        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader"></param>
        public static Recipient  DeserializeTagged (JSONReader JSONReader) {
			Recipient Result;
			Deserialize (JSONReader, out Result);
			return Result;
			}

        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Out"></param>
        public static void Deserialize(JSONReader JSONReader, out Recipient Out) {
	
			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                Out = null;
                return;
                }

			string token = JSONReader.ReadToken ();
			Out = null;

			switch (token) {

				case "Recipient" : {
					var Result = new Recipient ();
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
				case "Header" : {
					// Field does not have 
					Header = new Header (JSONReader);
					//Header.Deserialize(JSONReader, out Header) ;
					break;
					}
				case "encrypted_key" : {
					EncryptedKey = JSONReader.ReadBinary ();
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
	public partial class PublicKeyRSA : Key {
        /// <summary>
        /// 
        /// </summary>
		public byte[]						n;
        /// <summary>
        /// 
        /// </summary>
		public byte[]						e;

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "PublicKeyRSA";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public PublicKeyRSA () {
			_Initialize ();
			}
        /// <summary>
        /// </summary>		
		public PublicKeyRSA (JSONReader JSONReader) {
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
			((Key)this).SerializeX(_Writer, false, ref _first);
			if (n != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("n", 1);
					_Writer.WriteBinary (n);
				}
			if (e != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("e", 1);
					_Writer.WriteBinary (e);
				}
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}



        /// <summary>
        /// </summary>		
		public static new PublicKeyRSA From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new PublicKeyRSA From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new PublicKeyRSA (JSONReader);
			}

        /// <summary>
        /// </summary>		
		public static new PublicKeyRSA FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new PublicKeyRSA FromTagged (string _Input) {
			PublicKeyRSA _Result;
			Deserialize (_Input, out _Result);
			return _Result;
			}


        /// <summary>
        /// 
        /// </summary>
        /// <param name="_Input"></param>
        /// <param name="Out"></param>
        public static void Deserialize(string _Input, out PublicKeyRSA Out) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);

			Deserialize (JSONReader, out Out);
			}

        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader"></param>
        public static PublicKeyRSA  DeserializeTagged (JSONReader JSONReader) {
			PublicKeyRSA Result;
			Deserialize (JSONReader, out Result);
			return Result;
			}

        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Out"></param>
        public static void Deserialize(JSONReader JSONReader, out PublicKeyRSA Out) {
	
			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                Out = null;
                return;
                }

			string token = JSONReader.ReadToken ();
			Out = null;

			switch (token) {

				case "PublicKeyRSA" : {
					var Result = new PublicKeyRSA ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "PrivateKeyRSA" : {
					var Result = new PrivateKeyRSA ();
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
				case "n" : {
					n = JSONReader.ReadBinary ();
					break;
					}
				case "e" : {
					e = JSONReader.ReadBinary ();
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
	public partial class PrivateKeyRSA : PublicKeyRSA {
        /// <summary>
        /// 
        /// </summary>
		public byte[]						d;
        /// <summary>
        /// 
        /// </summary>
		public byte[]						p;
        /// <summary>
        /// 
        /// </summary>
		public byte[]						q;
        /// <summary>
        /// 
        /// </summary>
		public byte[]						dp;
        /// <summary>
        /// 
        /// </summary>
		public byte[]						dq;
        /// <summary>
        /// 
        /// </summary>
		public byte[]						qi;

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "PrivateKeyRSA";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public PrivateKeyRSA () {
			_Initialize ();
			}
        /// <summary>
        /// </summary>		
		public PrivateKeyRSA (JSONReader JSONReader) {
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
			((PublicKeyRSA)this).SerializeX(_Writer, false, ref _first);
			if (d != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("d", 1);
					_Writer.WriteBinary (d);
				}
			if (p != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("p", 1);
					_Writer.WriteBinary (p);
				}
			if (q != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("q", 1);
					_Writer.WriteBinary (q);
				}
			if (dp != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("dp", 1);
					_Writer.WriteBinary (dp);
				}
			if (dq != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("dq", 1);
					_Writer.WriteBinary (dq);
				}
			if (qi != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("qi", 1);
					_Writer.WriteBinary (qi);
				}
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}



        /// <summary>
        /// </summary>		
		public static new PrivateKeyRSA From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new PrivateKeyRSA From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new PrivateKeyRSA (JSONReader);
			}

        /// <summary>
        /// </summary>		
		public static new PrivateKeyRSA FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new PrivateKeyRSA FromTagged (string _Input) {
			PrivateKeyRSA _Result;
			Deserialize (_Input, out _Result);
			return _Result;
			}


        /// <summary>
        /// 
        /// </summary>
        /// <param name="_Input"></param>
        /// <param name="Out"></param>
        public static void Deserialize(string _Input, out PrivateKeyRSA Out) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);

			Deserialize (JSONReader, out Out);
			}

        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader"></param>
        public static PrivateKeyRSA  DeserializeTagged (JSONReader JSONReader) {
			PrivateKeyRSA Result;
			Deserialize (JSONReader, out Result);
			return Result;
			}

        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Out"></param>
        public static void Deserialize(JSONReader JSONReader, out PrivateKeyRSA Out) {
	
			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                Out = null;
                return;
                }

			string token = JSONReader.ReadToken ();
			Out = null;

			switch (token) {

				case "PrivateKeyRSA" : {
					var Result = new PrivateKeyRSA ();
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
				case "d" : {
					d = JSONReader.ReadBinary ();
					break;
					}
				case "p" : {
					p = JSONReader.ReadBinary ();
					break;
					}
				case "q" : {
					q = JSONReader.ReadBinary ();
					break;
					}
				case "dp" : {
					dp = JSONReader.ReadBinary ();
					break;
					}
				case "dq" : {
					dq = JSONReader.ReadBinary ();
					break;
					}
				case "qi" : {
					qi = JSONReader.ReadBinary ();
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

