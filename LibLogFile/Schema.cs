
//  Test
//  
//  This file was automatically generated at 11/9/2015 11:31:26 PM
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






namespace Goedel.Persistence {


    /// <summary>
    /// 
    /// </summary>
	public abstract partial class LogEntry : Goedel.Protocol.JSONObject {

        /// <summary>
        /// 
        /// </summary>
		public override string Tag () {
			return "LogEntry";
			}

        /// <summary>
        /// Default constructor.
        /// </summary>
		public LogEntry () {
			_Initialize () ;
			}

        /// <summary>
        /// Construct an instance from a JSON encoded stream.
        /// </summary>
		public LogEntry (JSONReader JSONReader) {
			Deserialize (JSONReader);
			_Initialize () ;
			}

        /// <summary>
        /// Construct an instance from a JSON encoded string.
        /// </summary>
		public LogEntry (string _String) {
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

				case "DataItem" : {
					var Result = new DataItem ();
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


				case "Delta" : {
					var Result = new Delta ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "IndexTerm" : {
					var Result = new IndexTerm ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "Final" : {
					var Result = new Final ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "Terminal" : {
					var Result = new Terminal ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "IndexIndex" : {
					var Result = new IndexIndex ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "Index" : {
					var Result = new Index ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "IndexEntry" : {
					var Result = new IndexEntry ();
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
	public partial class DataItem : LogEntry {
        /// <summary>
        /// 
        /// </summary>
		public string						TransactionID;
        /// <summary>
        /// 
        /// </summary>
		public string						PrimaryKey;
        /// <summary>
        /// 
        /// </summary>
		public string						PriorTransactionID;
        /// <summary>
        /// 
        /// </summary>
		public string						Action;
		bool								__Added = false;
		private DateTime						_Added;
        /// <summary>
        /// 
        /// </summary>
		public DateTime						Added {
			get {return _Added;}
			set {_Added = value; __Added = true; }
			}
		/// <summary>
        /// 
        /// </summary>
		public List<IndexTerm>				Keys;
        /// <summary>
        /// 
        /// </summary>
		public byte[]						Data;
        /// <summary>
        /// 
        /// </summary>
		public string						Text;
		bool								__Pending = false;
		private bool						_Pending;
        /// <summary>
        /// 
        /// </summary>
		public bool						Pending {
			get {return _Pending;}
			set {_Pending = value; __Pending = true; }
			}
		bool								__Commit = false;
		private bool						_Commit;
        /// <summary>
        /// 
        /// </summary>
		public bool						Commit {
			get {return _Commit;}
			set {_Commit = value; __Commit = true; }
			}
		bool								__Rollback = false;
		private bool						_Rollback;
        /// <summary>
        /// 
        /// </summary>
		public bool						Rollback {
			get {return _Rollback;}
			set {_Rollback = value; __Rollback = true; }
			}

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "DataItem";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public DataItem () {
			_Initialize ();
			}
        /// <summary>
        /// </summary>		
		public DataItem (JSONReader JSONReader) {
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
			if (TransactionID != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("TransactionID", 1);
					_Writer.WriteString (TransactionID);
				}
			if (PrimaryKey != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("PrimaryKey", 1);
					_Writer.WriteString (PrimaryKey);
				}
			if (PriorTransactionID != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("PriorTransactionID", 1);
					_Writer.WriteString (PriorTransactionID);
				}
			if (Action != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Action", 1);
					_Writer.WriteString (Action);
				}
			if (__Added){
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Added", 1);
					_Writer.WriteDateTime (Added);
				}
			if (Keys != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Keys", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in Keys) {
					_Writer.WriteArraySeparator (ref _firstarray);
                    _Writer.WriteObjectStart();
                    _Writer.WriteToken(_index.Tag(), 1);
					bool firstinner = true;
					_index.Serialize (_Writer, true, ref firstinner);
                    _Writer.WriteObjectEnd();
					}
				_Writer.WriteArrayEnd ();
				}

			if (Data != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Data", 1);
					_Writer.WriteBinary (Data);
				}
			if (Text != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Text", 1);
					_Writer.WriteString (Text);
				}
			if (__Pending){
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Pending", 1);
					_Writer.WriteBoolean (Pending);
				}
			if (__Commit){
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Commit", 1);
					_Writer.WriteBoolean (Commit);
				}
			if (__Rollback){
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Rollback", 1);
					_Writer.WriteBoolean (Rollback);
				}
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}



        /// <summary>
        /// </summary>		
		public static new DataItem From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new DataItem From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new DataItem (JSONReader);
			}

        /// <summary>
        /// </summary>		
		public static new DataItem FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new DataItem FromTagged (string _Input) {
			DataItem _Result;
			Deserialize (_Input, out _Result);
			return _Result;
			}


        /// <summary>
        /// 
        /// </summary>
        /// <param name="_Input"></param>
        /// <param name="Out"></param>
        public static void Deserialize(string _Input, out DataItem Out) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);

			Deserialize (JSONReader, out Out);
			}

        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader"></param>
        public static DataItem  DeserializeTagged (JSONReader JSONReader) {
			DataItem Result;
			Deserialize (JSONReader, out Result);
			return Result;
			}

        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Out"></param>
        public static void Deserialize(JSONReader JSONReader, out DataItem Out) {
	
			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                Out = null;
                return;
                }

			string token = JSONReader.ReadToken ();
			Out = null;

			switch (token) {

				case "DataItem" : {
					var Result = new DataItem ();
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
				case "TransactionID" : {
					TransactionID = JSONReader.ReadString ();
					break;
					}
				case "PrimaryKey" : {
					PrimaryKey = JSONReader.ReadString ();
					break;
					}
				case "PriorTransactionID" : {
					PriorTransactionID = JSONReader.ReadString ();
					break;
					}
				case "Action" : {
					Action = JSONReader.ReadString ();
					break;
					}
				case "Added" : {
					Added = JSONReader.ReadDateTime ();
					break;
					}
				case "Keys" : {
					bool _Going = JSONReader.StartArray ();
					Keys = new List <IndexTerm> ();
					while (_Going) {
						IndexTerm _Item;
                        IndexTerm.Deserialize(JSONReader, out _Item);
						Keys.Add (_Item);
						_Going = JSONReader.NextArray ();
						}

					break;
					}
				case "Data" : {
					Data = JSONReader.ReadBinary ();
					break;
					}
				case "Text" : {
					Text = JSONReader.ReadString ();
					break;
					}
				case "Pending" : {
					Pending = JSONReader.ReadBoolean ();
					break;
					}
				case "Commit" : {
					Commit = JSONReader.ReadBoolean ();
					break;
					}
				case "Rollback" : {
					Rollback = JSONReader.ReadBoolean ();
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
	public partial class Header : LogEntry {
        /// <summary>
        /// 
        /// </summary>
		public string						Type;
        /// <summary>
        /// 
        /// </summary>
		public string						Content;
        /// <summary>
        /// 
        /// </summary>
		public string						Comment;
        /// <summary>
        /// 
        /// </summary>
		public string						Digest;
        /// <summary>
        /// 
        /// </summary>
		public byte[]						LastDigest;
        /// <summary>
        /// 
        /// </summary>
		public Delta						Delta;

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
			if (Type != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Type", 1);
					_Writer.WriteString (Type);
				}
			if (Content != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Content", 1);
					_Writer.WriteString (Content);
				}
			if (Comment != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Comment", 1);
					_Writer.WriteString (Comment);
				}
			if (Digest != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Digest", 1);
					_Writer.WriteString (Digest);
				}
			if (LastDigest != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("LastDigest", 1);
					_Writer.WriteBinary (LastDigest);
				}
			if (Delta != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Delta", 1);
					Delta.Serialize (_Writer, false);
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
				case "Type" : {
					Type = JSONReader.ReadString ();
					break;
					}
				case "Content" : {
					Content = JSONReader.ReadString ();
					break;
					}
				case "Comment" : {
					Comment = JSONReader.ReadString ();
					break;
					}
				case "Digest" : {
					Digest = JSONReader.ReadString ();
					break;
					}
				case "LastDigest" : {
					LastDigest = JSONReader.ReadBinary ();
					break;
					}
				case "Delta" : {
					// Field does not have 
					Delta = new Delta (JSONReader);
					//Delta.Deserialize(JSONReader, out Delta) ;
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
	public partial class Delta : LogEntry {
        /// <summary>
        /// 
        /// </summary>
		public string						Parent;
        /// <summary>
        /// 
        /// </summary>
		public string						Previous;

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "Delta";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public Delta () {
			_Initialize ();
			}
        /// <summary>
        /// </summary>		
		public Delta (JSONReader JSONReader) {
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
			if (Parent != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Parent", 1);
					_Writer.WriteString (Parent);
				}
			if (Previous != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Previous", 1);
					_Writer.WriteString (Previous);
				}
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}



        /// <summary>
        /// </summary>		
		public static new Delta From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new Delta From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new Delta (JSONReader);
			}

        /// <summary>
        /// </summary>		
		public static new Delta FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new Delta FromTagged (string _Input) {
			Delta _Result;
			Deserialize (_Input, out _Result);
			return _Result;
			}


        /// <summary>
        /// 
        /// </summary>
        /// <param name="_Input"></param>
        /// <param name="Out"></param>
        public static void Deserialize(string _Input, out Delta Out) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);

			Deserialize (JSONReader, out Out);
			}

        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader"></param>
        public static Delta  DeserializeTagged (JSONReader JSONReader) {
			Delta Result;
			Deserialize (JSONReader, out Result);
			return Result;
			}

        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Out"></param>
        public static void Deserialize(JSONReader JSONReader, out Delta Out) {
	
			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                Out = null;
                return;
                }

			string token = JSONReader.ReadToken ();
			Out = null;

			switch (token) {

				case "Delta" : {
					var Result = new Delta ();
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
				case "Parent" : {
					Parent = JSONReader.ReadString ();
					break;
					}
				case "Previous" : {
					Previous = JSONReader.ReadString ();
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
	public partial class IndexTerm : LogEntry {
        /// <summary>
        /// 
        /// </summary>
		public string						Type;
        /// <summary>
        /// 
        /// </summary>
		public string						Term;

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "IndexTerm";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public IndexTerm () {
			_Initialize ();
			}
        /// <summary>
        /// </summary>		
		public IndexTerm (JSONReader JSONReader) {
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
			if (Type != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Type", 1);
					_Writer.WriteString (Type);
				}
			if (Term != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Term", 1);
					_Writer.WriteString (Term);
				}
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}



        /// <summary>
        /// </summary>		
		public static new IndexTerm From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new IndexTerm From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new IndexTerm (JSONReader);
			}

        /// <summary>
        /// </summary>		
		public static new IndexTerm FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new IndexTerm FromTagged (string _Input) {
			IndexTerm _Result;
			Deserialize (_Input, out _Result);
			return _Result;
			}


        /// <summary>
        /// 
        /// </summary>
        /// <param name="_Input"></param>
        /// <param name="Out"></param>
        public static void Deserialize(string _Input, out IndexTerm Out) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);

			Deserialize (JSONReader, out Out);
			}

        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader"></param>
        public static IndexTerm  DeserializeTagged (JSONReader JSONReader) {
			IndexTerm Result;
			Deserialize (JSONReader, out Result);
			return Result;
			}

        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Out"></param>
        public static void Deserialize(JSONReader JSONReader, out IndexTerm Out) {
	
			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                Out = null;
                return;
                }

			string token = JSONReader.ReadToken ();
			Out = null;

			switch (token) {

				case "IndexTerm" : {
					var Result = new IndexTerm ();
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
				case "Type" : {
					Type = JSONReader.ReadString ();
					break;
					}
				case "Term" : {
					Term = JSONReader.ReadString ();
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
	public partial class Final : LogEntry {
        /// <summary>
        /// 
        /// </summary>
		public byte[]						Digest;

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "Final";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public Final () {
			_Initialize ();
			}
        /// <summary>
        /// </summary>		
		public Final (JSONReader JSONReader) {
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
			if (Digest != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Digest", 1);
					_Writer.WriteBinary (Digest);
				}
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}



        /// <summary>
        /// </summary>		
		public static new Final From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new Final From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new Final (JSONReader);
			}

        /// <summary>
        /// </summary>		
		public static new Final FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new Final FromTagged (string _Input) {
			Final _Result;
			Deserialize (_Input, out _Result);
			return _Result;
			}


        /// <summary>
        /// 
        /// </summary>
        /// <param name="_Input"></param>
        /// <param name="Out"></param>
        public static void Deserialize(string _Input, out Final Out) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);

			Deserialize (JSONReader, out Out);
			}

        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader"></param>
        public static Final  DeserializeTagged (JSONReader JSONReader) {
			Final Result;
			Deserialize (JSONReader, out Result);
			return Result;
			}

        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Out"></param>
        public static void Deserialize(JSONReader JSONReader, out Final Out) {
	
			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                Out = null;
                return;
                }

			string token = JSONReader.ReadToken ();
			Out = null;

			switch (token) {

				case "Final" : {
					var Result = new Final ();
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
				case "Digest" : {
					Digest = JSONReader.ReadBinary ();
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
	public partial class Terminal : LogEntry {
		/// <summary>
        /// 
        /// </summary>
		public List<IndexIndex>				Indexes;

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "Terminal";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public Terminal () {
			_Initialize ();
			}
        /// <summary>
        /// </summary>		
		public Terminal (JSONReader JSONReader) {
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
			if (Indexes != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Indexes", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in Indexes) {
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
		public static new Terminal From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new Terminal From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new Terminal (JSONReader);
			}

        /// <summary>
        /// </summary>		
		public static new Terminal FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new Terminal FromTagged (string _Input) {
			Terminal _Result;
			Deserialize (_Input, out _Result);
			return _Result;
			}


        /// <summary>
        /// 
        /// </summary>
        /// <param name="_Input"></param>
        /// <param name="Out"></param>
        public static void Deserialize(string _Input, out Terminal Out) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);

			Deserialize (JSONReader, out Out);
			}

        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader"></param>
        public static Terminal  DeserializeTagged (JSONReader JSONReader) {
			Terminal Result;
			Deserialize (JSONReader, out Result);
			return Result;
			}

        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Out"></param>
        public static void Deserialize(JSONReader JSONReader, out Terminal Out) {
	
			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                Out = null;
                return;
                }

			string token = JSONReader.ReadToken ();
			Out = null;

			switch (token) {

				case "Terminal" : {
					var Result = new Terminal ();
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
				case "Indexes" : {
					bool _Going = JSONReader.StartArray ();
					Indexes = new List <IndexIndex> ();
					while (_Going) {
						var _Item = new IndexIndex (JSONReader);
						//IndexIndex _Item;
                        //IndexIndex.Deserialize(JSONReader, out _Item);

						Indexes.Add (_Item);
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
	public partial class IndexIndex : LogEntry {
        /// <summary>
        /// 
        /// </summary>
		public string						Key;
		bool								__Offset = false;
		private int						_Offset;
        /// <summary>
        /// 
        /// </summary>
		public int						Offset {
			get {return _Offset;}
			set {_Offset = value; __Offset = true; }
			}

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "IndexIndex";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public IndexIndex () {
			_Initialize ();
			}
        /// <summary>
        /// </summary>		
		public IndexIndex (JSONReader JSONReader) {
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
			if (Key != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Key", 1);
					_Writer.WriteString (Key);
				}
			if (__Offset){
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Offset", 1);
					_Writer.WriteInteger32 (Offset);
				}
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}



        /// <summary>
        /// </summary>		
		public static new IndexIndex From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new IndexIndex From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new IndexIndex (JSONReader);
			}

        /// <summary>
        /// </summary>		
		public static new IndexIndex FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new IndexIndex FromTagged (string _Input) {
			IndexIndex _Result;
			Deserialize (_Input, out _Result);
			return _Result;
			}


        /// <summary>
        /// 
        /// </summary>
        /// <param name="_Input"></param>
        /// <param name="Out"></param>
        public static void Deserialize(string _Input, out IndexIndex Out) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);

			Deserialize (JSONReader, out Out);
			}

        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader"></param>
        public static IndexIndex  DeserializeTagged (JSONReader JSONReader) {
			IndexIndex Result;
			Deserialize (JSONReader, out Result);
			return Result;
			}

        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Out"></param>
        public static void Deserialize(JSONReader JSONReader, out IndexIndex Out) {
	
			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                Out = null;
                return;
                }

			string token = JSONReader.ReadToken ();
			Out = null;

			switch (token) {

				case "IndexIndex" : {
					var Result = new IndexIndex ();
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
				case "Key" : {
					Key = JSONReader.ReadString ();
					break;
					}
				case "Offset" : {
					Offset = JSONReader.ReadInteger32 ();
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
	public partial class Index : LogEntry {
        /// <summary>
        /// 
        /// </summary>
		public string						Key;
		/// <summary>
        /// 
        /// </summary>
		public List<IndexEntry>				Entries;

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "Index";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public Index () {
			_Initialize ();
			}
        /// <summary>
        /// </summary>		
		public Index (JSONReader JSONReader) {
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
			if (Key != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Key", 1);
					_Writer.WriteString (Key);
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
		public static new Index From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new Index From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new Index (JSONReader);
			}

        /// <summary>
        /// </summary>		
		public static new Index FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new Index FromTagged (string _Input) {
			Index _Result;
			Deserialize (_Input, out _Result);
			return _Result;
			}


        /// <summary>
        /// 
        /// </summary>
        /// <param name="_Input"></param>
        /// <param name="Out"></param>
        public static void Deserialize(string _Input, out Index Out) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);

			Deserialize (JSONReader, out Out);
			}

        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader"></param>
        public static Index  DeserializeTagged (JSONReader JSONReader) {
			Index Result;
			Deserialize (JSONReader, out Result);
			return Result;
			}

        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Out"></param>
        public static void Deserialize(JSONReader JSONReader, out Index Out) {
	
			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                Out = null;
                return;
                }

			string token = JSONReader.ReadToken ();
			Out = null;

			switch (token) {

				case "Index" : {
					var Result = new Index ();
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
				case "Key" : {
					Key = JSONReader.ReadString ();
					break;
					}
				case "Entries" : {
					bool _Going = JSONReader.StartArray ();
					Entries = new List <IndexEntry> ();
					while (_Going) {
						var _Item = new IndexEntry (JSONReader);
						//IndexEntry _Item;
                        //IndexEntry.Deserialize(JSONReader, out _Item);

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
	/// </summary>
	public partial class IndexEntry : LogEntry {
        /// <summary>
        /// 
        /// </summary>
		public string						Data;
		/// <summary>
        /// 
        /// </summary>
		public List<int>				Offset;

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "IndexEntry";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public IndexEntry () {
			_Initialize ();
			}
        /// <summary>
        /// </summary>		
		public IndexEntry (JSONReader JSONReader) {
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
					_Writer.WriteString (Data);
				}
			if (Offset != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Offset", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in Offset) {
					_Writer.WriteArraySeparator (ref _firstarray);
					_Writer.WriteInteger32 (_index);
					}
				_Writer.WriteArrayEnd ();
				}

			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}



        /// <summary>
        /// </summary>		
		public static new IndexEntry From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new IndexEntry From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new IndexEntry (JSONReader);
			}

        /// <summary>
        /// </summary>		
		public static new IndexEntry FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new IndexEntry FromTagged (string _Input) {
			IndexEntry _Result;
			Deserialize (_Input, out _Result);
			return _Result;
			}


        /// <summary>
        /// 
        /// </summary>
        /// <param name="_Input"></param>
        /// <param name="Out"></param>
        public static void Deserialize(string _Input, out IndexEntry Out) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);

			Deserialize (JSONReader, out Out);
			}

        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader"></param>
        public static IndexEntry  DeserializeTagged (JSONReader JSONReader) {
			IndexEntry Result;
			Deserialize (JSONReader, out Result);
			return Result;
			}

        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Out"></param>
        public static void Deserialize(JSONReader JSONReader, out IndexEntry Out) {
	
			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                Out = null;
                return;
                }

			string token = JSONReader.ReadToken ();
			Out = null;

			switch (token) {

				case "IndexEntry" : {
					var Result = new IndexEntry ();
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
					Data = JSONReader.ReadString ();
					break;
					}
				case "Offset" : {
					bool _Going = JSONReader.StartArray ();
					Offset = new List <int> ();
					while (_Going) {
						int _Item = JSONReader.ReadInteger32 ();
						Offset.Add (_Item);
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

