
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
	/// Describe network configuration information.
	/// </summary>
	public abstract partial class MeshNetwork : global::Goedel.Protocol.JSONObject {

        /// <summary>
        /// Schema tag.
        /// </summary>
        /// <returns>The tag value</returns>
		public override string Tag () {
			return "MeshNetwork";
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

				case "NetworkProfile" : {
					Out = new NetworkProfile ();
					Out.Deserialize (JSONReader);
					break;
					}


				case "NetworkProfilePrivate" : {
					Out = new NetworkProfilePrivate ();
					Out.Deserialize (JSONReader);
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
		public static new NetworkProfile From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
		/// Create a new instance from untagged string input.
		/// i.e. {... data ... }
        /// </summary>	
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new NetworkProfile From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			var Result = new NetworkProfile ();
			Result.Deserialize (JSONReader);
			return Result;
			// return new NetworkProfile (JSONReader);
			}

        /// <summary>
		/// Create a new instance from tagged byte input.
		/// i.e. { "NetworkProfile" : {... data ... } }
        /// </summary>	
        /// <param name="_Data">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new NetworkProfile FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// Create a new instance from tagged string input.
		/// i.e. { "NetworkProfile" : {... data ... } }
        /// </summary>
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>		
		public static new NetworkProfile FromTagged (string _Input) {
			//NetworkProfile _Result;
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
        public static new NetworkProfile  FromTagged (JSONReader JSONReader) {
			NetworkProfile Out = null;

			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                return null;
                }

			string token = JSONReader.ReadToken ();

			switch (token) {

				case "NetworkProfile" : {
					Out = new NetworkProfile ();
					Out.Deserialize (JSONReader);
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
	/// Describes the network profile to follow
	/// </summary>
	public partial class NetworkProfilePrivate : MeshNetwork {
        /// <summary>
        ///DNS name of sites to which profile applies *.example.com matches www.example.com
        ///etc.		
        /// </summary>

		public virtual List<string>				Sites  {get; set;}
        /// <summary>
        ///DNS Resolution Services
        /// </summary>

		public virtual List<Connection>				DNS  {get; set;}
        /// <summary>
        ///DNS prefixes to search
        /// </summary>

		public virtual List<string>				Prefix  {get; set;}
        /// <summary>
        ///Certificate Trust List giving WebPKI roots to trust
        /// </summary>

		public virtual byte[]						CTL  {get; set;}
        /// <summary>
        ///List of UDF fingerprints of keys making up the trust roots
        ///to be accepted for Web PKI purposes.
        /// </summary>

		public virtual List<string>				WebPKI  {get; set;}

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "NetworkProfilePrivate";
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
		/// Create a new instance from untagged byte input.
		/// i.e. {... data ... }
        /// </summary>	
        /// <param name="_Data">The input data.</param>
        /// <returns>The created object.</returns>		
		public static new NetworkProfilePrivate From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
		/// Create a new instance from untagged string input.
		/// i.e. {... data ... }
        /// </summary>	
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new NetworkProfilePrivate From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			var Result = new NetworkProfilePrivate ();
			Result.Deserialize (JSONReader);
			return Result;
			// return new NetworkProfilePrivate (JSONReader);
			}

        /// <summary>
		/// Create a new instance from tagged byte input.
		/// i.e. { "NetworkProfilePrivate" : {... data ... } }
        /// </summary>	
        /// <param name="_Data">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new NetworkProfilePrivate FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// Create a new instance from tagged string input.
		/// i.e. { "NetworkProfilePrivate" : {... data ... } }
        /// </summary>
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>		
		public static new NetworkProfilePrivate FromTagged (string _Input) {
			//NetworkProfilePrivate _Result;
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
        public static new NetworkProfilePrivate  FromTagged (JSONReader JSONReader) {
			NetworkProfilePrivate Out = null;

			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                return null;
                }

			string token = JSONReader.ReadToken ();

			switch (token) {

				case "NetworkProfilePrivate" : {
					Out = new NetworkProfilePrivate ();
					Out.Deserialize (JSONReader);
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
				case "Sites" : {
					// Have a sequence of values
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
					// Have a sequence of values
					bool _Going = JSONReader.StartArray ();
					DNS = new List <Connection> ();
					while (_Going) {
						// an untagged structure.
						var _Item = new  Connection ();
						_Item.Deserialize (JSONReader);
						// var _Item = new Connection (JSONReader);
						DNS.Add (_Item);
						_Going = JSONReader.NextArray ();
						}
					break;
					}
				case "Prefix" : {
					// Have a sequence of values
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
					// Have a sequence of values
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

	}

