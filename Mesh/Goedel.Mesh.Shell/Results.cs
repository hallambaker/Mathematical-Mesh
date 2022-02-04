
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
//  This file was automatically generated at 03-Feb-22 5:54:33 PM
//   
//  Changes to this file may be overwritten without warning
//  
//  Generator:  protogen version 3.0.0.774
//      Goedel Script Version : 0.1   Generated 
//      Goedel Schema Version : 0.1   Generated
//  
//      Copyright : © 2015-2021
//  
//  Build Platform: Win32NT 10.0.19042.0
//  
//  
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Goedel.Protocol;

#pragma warning disable IDE0079
#pragma warning disable IDE1006
#pragma warning disable CA2255 // The 'ModuleInitializer' attribute should not be used in libraries

using Goedel.Mesh;
using Goedel.Mesh.Client;
using Goedel.Cryptography.Dare;


namespace Goedel.Mesh.Shell;


	/// <summary>
	///
	/// Classes to be used to test serialization an deserialization.
	/// </summary>
public abstract partial class ShellResult : global::Goedel.Protocol.JsonObject {

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag =>__Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "ShellResult";

	/// <summary>
    /// Dictionary mapping tags to factory methods
    /// </summary>
	public static Dictionary<string, JsonFactoryDelegate> _TagDictionary=> _tagDictionary;
	static Dictionary<string, JsonFactoryDelegate> _tagDictionary = 
			new () {

	    {"Result", Result._Factory},
	    {"ResultFail", ResultFail._Factory},
	    {"ResultKey", ResultKey._Factory},
	    {"ResultDigest", ResultDigest._Factory},
	    {"ResultFile", ResultFile._Factory},
	    {"ResultKeyFile", ResultKeyFile._Factory},
	    {"ResultListLog", ResultListLog._Factory},
	    {"ResultLog", ResultLog._Factory},
	    {"ResultArchive", ResultArchive._Factory},
	    {"ResultFileDare", ResultFileDare._Factory},
	    {"ResultFileEARL", ResultFileEARL._Factory},
	    {"ResultDump", ResultDump._Factory},
	    {"ResultList", ResultList._Factory},
	    {"ResultAccountConnect", ResultAccountConnect._Factory},
	    {"ResultPublish", ResultPublish._Factory},
	    {"ResultPublishDevice", ResultPublishDevice._Factory},
	    {"ResultCreateDevice", ResultCreateDevice._Factory},
	    {"ResultCreatePersonal", ResultCreatePersonal._Factory},
	    {"ResultCreateAccount", ResultCreateAccount._Factory},
	    {"ResultDeleteAccount", ResultDeleteAccount._Factory},
	    {"ResultRegisterService", ResultRegisterService._Factory},
	    {"ResultRecover", ResultRecover._Factory},
	    {"ResultStatus", ResultStatus._Factory},
	    {"ResultSync", ResultSync._Factory},
	    {"ResultEscrow", ResultEscrow._Factory},
	    {"ResultMachine", ResultMachine._Factory},
	    {"ResultPIN", ResultPIN._Factory},
	    {"ResultHello", ResultHello._Factory},
	    {"ResultSequence", ResultSequence._Factory},
	    {"LogEntry", LogEntry._Factory},
	    {"ResultEntry", ResultEntry._Factory},
	    {"ResultEntrySent", ResultEntrySent._Factory},
	    {"ResultMail", ResultMail._Factory},
	    {"ResultSSH", ResultSSH._Factory},
	    {"ResultGroupCreate", ResultGroupCreate._Factory},
	    {"ResultSent", ResultSent._Factory},
	    {"ResultPending", ResultPending._Factory},
	    {"ResultAuthorize", ResultAuthorize._Factory},
	    {"ResultProcess", ResultProcess._Factory},
	    {"ResultConnect", ResultConnect._Factory},
	    {"ResultTransactionRequest", ResultTransactionRequest._Factory},
	    {"ResultReceived", ResultReceived._Factory},
	    {"ResultApplication", ResultApplication._Factory},
	    {"ResultApplicationList", ResultApplicationList._Factory}
		};

    [ModuleInitializer]

    internal static void _Initialize() => AddDictionary(ref _tagDictionary);


	/// <summary>
    /// Construct an instance from the specified tagged JsonReader stream.
    /// </summary>
    /// <param name="jsonReader">Input stream</param>
    /// <param name="result">The created object</param>
    public static void Deserialize(JsonReader jsonReader, out JsonObject result) => 
		result = jsonReader.ReadTaggedObject(_TagDictionary);

	}



// Service Dispatch Classes



	// Transaction Classes
	/// <summary>
	/// </summary>
public partial class Result : ShellResult {
	bool								__Success = false;
	private bool						_Success;
        /// <summary>
        /// </summary>

	public virtual bool						Success {
		get => _Success;
		set {_Success = value; __Success = true; }
		}
        /// <summary>
        /// </summary>

	public virtual string						Reason  {get; set;}
		
	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "Result";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new Result();


    /// <summary>
    /// Serialize this object to the specified output stream.
    /// </summary>
    /// <param name="writer">Output stream</param>
    /// <param name="wrap">If true, output is wrapped with object
    /// start and end sequences '{ ... }'.</param>
    /// <param name="first">If true, item is the first entry in a list.</param>
	public override void Serialize (Writer writer, bool wrap, ref bool first) =>
		SerializeX (writer, wrap, ref first);


    /// <summary>
    /// Serialize this object to the specified output stream.
    /// Unlike the Serlialize() method, this method is not inherited from the
    /// parent class allowing a specific version of the method to be called.
    /// </summary>
    /// <param name="_writer">Output stream</param>
    /// <param name="_wrap">If true, output is wrapped with object
    /// start and end sequences '{ ... }'.</param>
    /// <param name="_first">If true, item is the first entry in a list.</param>
	public new void SerializeX (Writer _writer, bool _wrap, ref bool _first) {
		PreEncode();
		if (_wrap) {
			_writer.WriteObjectStart ();
			}
		if (__Success){
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Success", 1);
				_writer.WriteBoolean (Success);
			}
		if (Reason != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Reason", 1);
				_writer.WriteString (Reason);
			}
		if (_wrap) {
			_writer.WriteObjectEnd ();
			}
		}

    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new Result FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as Result;
			}
		var Result = new Result ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			case "Success" : {
				Success = jsonReader.ReadBoolean ();
				break;
				}
			case "Reason" : {
				Reason = jsonReader.ReadString ();
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
public partial class ResultFail : Result {
		
	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "ResultFail";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ResultFail();


    /// <summary>
    /// Serialize this object to the specified output stream.
    /// </summary>
    /// <param name="writer">Output stream</param>
    /// <param name="wrap">If true, output is wrapped with object
    /// start and end sequences '{ ... }'.</param>
    /// <param name="first">If true, item is the first entry in a list.</param>
	public override void Serialize (Writer writer, bool wrap, ref bool first) =>
		SerializeX (writer, wrap, ref first);


    /// <summary>
    /// Serialize this object to the specified output stream.
    /// Unlike the Serlialize() method, this method is not inherited from the
    /// parent class allowing a specific version of the method to be called.
    /// </summary>
    /// <param name="_writer">Output stream</param>
    /// <param name="_wrap">If true, output is wrapped with object
    /// start and end sequences '{ ... }'.</param>
    /// <param name="_first">If true, item is the first entry in a list.</param>
	public new void SerializeX (Writer _writer, bool _wrap, ref bool _first) {
		PreEncode();
		if (_wrap) {
			_writer.WriteObjectStart ();
			}
		((Result)this).SerializeX(_writer, false, ref _first);
		if (_wrap) {
			_writer.WriteObjectEnd ();
			}
		}

    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ResultFail FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ResultFail;
			}
		var Result = new ResultFail ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			default : {
				base.DeserializeToken(jsonReader, tag);
				break;
				}
			}
		// check up that all the required elements are present
		}


	}

	/// <summary>
	/// </summary>
public partial class ResultKey : Result {
        /// <summary>
        /// </summary>

	public virtual string						Key  {get; set;}
        /// <summary>
        /// </summary>

	public virtual string						Identifier  {get; set;}
        /// <summary>
        /// </summary>

	public virtual List<string>				Shares  {get; set;}
		
	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "ResultKey";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ResultKey();


    /// <summary>
    /// Serialize this object to the specified output stream.
    /// </summary>
    /// <param name="writer">Output stream</param>
    /// <param name="wrap">If true, output is wrapped with object
    /// start and end sequences '{ ... }'.</param>
    /// <param name="first">If true, item is the first entry in a list.</param>
	public override void Serialize (Writer writer, bool wrap, ref bool first) =>
		SerializeX (writer, wrap, ref first);


    /// <summary>
    /// Serialize this object to the specified output stream.
    /// Unlike the Serlialize() method, this method is not inherited from the
    /// parent class allowing a specific version of the method to be called.
    /// </summary>
    /// <param name="_writer">Output stream</param>
    /// <param name="_wrap">If true, output is wrapped with object
    /// start and end sequences '{ ... }'.</param>
    /// <param name="_first">If true, item is the first entry in a list.</param>
	public new void SerializeX (Writer _writer, bool _wrap, ref bool _first) {
		PreEncode();
		if (_wrap) {
			_writer.WriteObjectStart ();
			}
		((Result)this).SerializeX(_writer, false, ref _first);
		if (Key != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Key", 1);
				_writer.WriteString (Key);
			}
		if (Identifier != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Identifier", 1);
				_writer.WriteString (Identifier);
			}
		if (Shares != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Shares", 1);
			_writer.WriteArrayStart ();
			bool _firstarray = true;
			foreach (var _index in Shares) {
				_writer.WriteArraySeparator (ref _firstarray);
				_writer.WriteString (_index);
				}
			_writer.WriteArrayEnd ();
			}

		if (_wrap) {
			_writer.WriteObjectEnd ();
			}
		}

    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ResultKey FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ResultKey;
			}
		var Result = new ResultKey ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			case "Key" : {
				Key = jsonReader.ReadString ();
				break;
				}
			case "Identifier" : {
				Identifier = jsonReader.ReadString ();
				break;
				}
			case "Shares" : {
				// Have a sequence of values
				bool _Going = jsonReader.StartArray ();
				Shares = new List <string> ();
				while (_Going) {
					string _Item = jsonReader.ReadString ();
					Shares.Add (_Item);
					_Going = jsonReader.NextArray ();
					}
				break;
				}
			default : {
				base.DeserializeToken(jsonReader, tag);
				break;
				}
			}
		// check up that all the required elements are present
		}


	}

	/// <summary>
	/// </summary>
public partial class ResultDigest : Result {
        /// <summary>
        /// </summary>

	public virtual string						Digest  {get; set;}
        /// <summary>
        /// </summary>

	public virtual string						Key  {get; set;}
	bool								__Verified = false;
	private bool						_Verified;
        /// <summary>
        /// </summary>

	public virtual bool						Verified {
		get => _Verified;
		set {_Verified = value; __Verified = true; }
		}
		
	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "ResultDigest";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ResultDigest();


    /// <summary>
    /// Serialize this object to the specified output stream.
    /// </summary>
    /// <param name="writer">Output stream</param>
    /// <param name="wrap">If true, output is wrapped with object
    /// start and end sequences '{ ... }'.</param>
    /// <param name="first">If true, item is the first entry in a list.</param>
	public override void Serialize (Writer writer, bool wrap, ref bool first) =>
		SerializeX (writer, wrap, ref first);


    /// <summary>
    /// Serialize this object to the specified output stream.
    /// Unlike the Serlialize() method, this method is not inherited from the
    /// parent class allowing a specific version of the method to be called.
    /// </summary>
    /// <param name="_writer">Output stream</param>
    /// <param name="_wrap">If true, output is wrapped with object
    /// start and end sequences '{ ... }'.</param>
    /// <param name="_first">If true, item is the first entry in a list.</param>
	public new void SerializeX (Writer _writer, bool _wrap, ref bool _first) {
		PreEncode();
		if (_wrap) {
			_writer.WriteObjectStart ();
			}
		((Result)this).SerializeX(_writer, false, ref _first);
		if (Digest != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Digest", 1);
				_writer.WriteString (Digest);
			}
		if (Key != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Key", 1);
				_writer.WriteString (Key);
			}
		if (__Verified){
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Verified", 1);
				_writer.WriteBoolean (Verified);
			}
		if (_wrap) {
			_writer.WriteObjectEnd ();
			}
		}

    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ResultDigest FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ResultDigest;
			}
		var Result = new ResultDigest ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			case "Digest" : {
				Digest = jsonReader.ReadString ();
				break;
				}
			case "Key" : {
				Key = jsonReader.ReadString ();
				break;
				}
			case "Verified" : {
				Verified = jsonReader.ReadBoolean ();
				break;
				}
			default : {
				base.DeserializeToken(jsonReader, tag);
				break;
				}
			}
		// check up that all the required elements are present
		}


	}

	/// <summary>
	/// </summary>
public partial class ResultFile : Result {
        /// <summary>
        /// </summary>

	public virtual string						Filename  {get; set;}
	bool								__TotalBytes = false;
	private int						_TotalBytes;
        /// <summary>
        /// </summary>

	public virtual int						TotalBytes {
		get => _TotalBytes;
		set {_TotalBytes = value; __TotalBytes = true; }
		}
	bool								__Verified = false;
	private bool						_Verified;
        /// <summary>
        /// </summary>

	public virtual bool						Verified {
		get => _Verified;
		set {_Verified = value; __Verified = true; }
		}
		
	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "ResultFile";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ResultFile();


    /// <summary>
    /// Serialize this object to the specified output stream.
    /// </summary>
    /// <param name="writer">Output stream</param>
    /// <param name="wrap">If true, output is wrapped with object
    /// start and end sequences '{ ... }'.</param>
    /// <param name="first">If true, item is the first entry in a list.</param>
	public override void Serialize (Writer writer, bool wrap, ref bool first) =>
		SerializeX (writer, wrap, ref first);


    /// <summary>
    /// Serialize this object to the specified output stream.
    /// Unlike the Serlialize() method, this method is not inherited from the
    /// parent class allowing a specific version of the method to be called.
    /// </summary>
    /// <param name="_writer">Output stream</param>
    /// <param name="_wrap">If true, output is wrapped with object
    /// start and end sequences '{ ... }'.</param>
    /// <param name="_first">If true, item is the first entry in a list.</param>
	public new void SerializeX (Writer _writer, bool _wrap, ref bool _first) {
		PreEncode();
		if (_wrap) {
			_writer.WriteObjectStart ();
			}
		((Result)this).SerializeX(_writer, false, ref _first);
		if (Filename != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Filename", 1);
				_writer.WriteString (Filename);
			}
		if (__TotalBytes){
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("TotalBytes", 1);
				_writer.WriteInteger32 (TotalBytes);
			}
		if (__Verified){
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Verified", 1);
				_writer.WriteBoolean (Verified);
			}
		if (_wrap) {
			_writer.WriteObjectEnd ();
			}
		}

    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ResultFile FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ResultFile;
			}
		var Result = new ResultFile ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			case "Filename" : {
				Filename = jsonReader.ReadString ();
				break;
				}
			case "TotalBytes" : {
				TotalBytes = jsonReader.ReadInteger32 ();
				break;
				}
			case "Verified" : {
				Verified = jsonReader.ReadBoolean ();
				break;
				}
			default : {
				base.DeserializeToken(jsonReader, tag);
				break;
				}
			}
		// check up that all the required elements are present
		}


	}

	/// <summary>
	/// </summary>
public partial class ResultKeyFile : ResultFile {
        /// <summary>
        /// </summary>

	public virtual string						Udf  {get; set;}
	bool								__Private = false;
	private bool						_Private;
        /// <summary>
        /// </summary>

	public virtual bool						Private {
		get => _Private;
		set {_Private = value; __Private = true; }
		}
        /// <summary>
        /// </summary>

	public virtual string						Algorithm  {get; set;}
        /// <summary>
        /// </summary>

	public virtual string						Format  {get; set;}
		
	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "ResultKeyFile";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ResultKeyFile();


    /// <summary>
    /// Serialize this object to the specified output stream.
    /// </summary>
    /// <param name="writer">Output stream</param>
    /// <param name="wrap">If true, output is wrapped with object
    /// start and end sequences '{ ... }'.</param>
    /// <param name="first">If true, item is the first entry in a list.</param>
	public override void Serialize (Writer writer, bool wrap, ref bool first) =>
		SerializeX (writer, wrap, ref first);


    /// <summary>
    /// Serialize this object to the specified output stream.
    /// Unlike the Serlialize() method, this method is not inherited from the
    /// parent class allowing a specific version of the method to be called.
    /// </summary>
    /// <param name="_writer">Output stream</param>
    /// <param name="_wrap">If true, output is wrapped with object
    /// start and end sequences '{ ... }'.</param>
    /// <param name="_first">If true, item is the first entry in a list.</param>
	public new void SerializeX (Writer _writer, bool _wrap, ref bool _first) {
		PreEncode();
		if (_wrap) {
			_writer.WriteObjectStart ();
			}
		((ResultFile)this).SerializeX(_writer, false, ref _first);
		if (Udf != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Udf", 1);
				_writer.WriteString (Udf);
			}
		if (__Private){
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Private", 1);
				_writer.WriteBoolean (Private);
			}
		if (Algorithm != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Algorithm", 1);
				_writer.WriteString (Algorithm);
			}
		if (Format != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Format", 1);
				_writer.WriteString (Format);
			}
		if (_wrap) {
			_writer.WriteObjectEnd ();
			}
		}

    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ResultKeyFile FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ResultKeyFile;
			}
		var Result = new ResultKeyFile ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			case "Udf" : {
				Udf = jsonReader.ReadString ();
				break;
				}
			case "Private" : {
				Private = jsonReader.ReadBoolean ();
				break;
				}
			case "Algorithm" : {
				Algorithm = jsonReader.ReadString ();
				break;
				}
			case "Format" : {
				Format = jsonReader.ReadString ();
				break;
				}
			default : {
				base.DeserializeToken(jsonReader, tag);
				break;
				}
			}
		// check up that all the required elements are present
		}


	}

	/// <summary>
	/// </summary>
public partial class ResultListLog : Result {
        /// <summary>
        /// </summary>

	public virtual string						Filename  {get; set;}
	bool								__Count = false;
	private int						_Count;
        /// <summary>
        /// </summary>

	public virtual int						Count {
		get => _Count;
		set {_Count = value; __Count = true; }
		}
		
	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "ResultListLog";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ResultListLog();


    /// <summary>
    /// Serialize this object to the specified output stream.
    /// </summary>
    /// <param name="writer">Output stream</param>
    /// <param name="wrap">If true, output is wrapped with object
    /// start and end sequences '{ ... }'.</param>
    /// <param name="first">If true, item is the first entry in a list.</param>
	public override void Serialize (Writer writer, bool wrap, ref bool first) =>
		SerializeX (writer, wrap, ref first);


    /// <summary>
    /// Serialize this object to the specified output stream.
    /// Unlike the Serlialize() method, this method is not inherited from the
    /// parent class allowing a specific version of the method to be called.
    /// </summary>
    /// <param name="_writer">Output stream</param>
    /// <param name="_wrap">If true, output is wrapped with object
    /// start and end sequences '{ ... }'.</param>
    /// <param name="_first">If true, item is the first entry in a list.</param>
	public new void SerializeX (Writer _writer, bool _wrap, ref bool _first) {
		PreEncode();
		if (_wrap) {
			_writer.WriteObjectStart ();
			}
		((Result)this).SerializeX(_writer, false, ref _first);
		if (Filename != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Filename", 1);
				_writer.WriteString (Filename);
			}
		if (__Count){
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Count", 1);
				_writer.WriteInteger32 (Count);
			}
		if (_wrap) {
			_writer.WriteObjectEnd ();
			}
		}

    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ResultListLog FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ResultListLog;
			}
		var Result = new ResultListLog ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			case "Filename" : {
				Filename = jsonReader.ReadString ();
				break;
				}
			case "Count" : {
				Count = jsonReader.ReadInteger32 ();
				break;
				}
			default : {
				base.DeserializeToken(jsonReader, tag);
				break;
				}
			}
		// check up that all the required elements are present
		}


	}

	/// <summary>
	/// </summary>
public partial class ResultLog : Result {
	bool								__Count = false;
	private int						_Count;
        /// <summary>
        /// </summary>

	public virtual int						Count {
		get => _Count;
		set {_Count = value; __Count = true; }
		}
		
	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "ResultLog";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ResultLog();


    /// <summary>
    /// Serialize this object to the specified output stream.
    /// </summary>
    /// <param name="writer">Output stream</param>
    /// <param name="wrap">If true, output is wrapped with object
    /// start and end sequences '{ ... }'.</param>
    /// <param name="first">If true, item is the first entry in a list.</param>
	public override void Serialize (Writer writer, bool wrap, ref bool first) =>
		SerializeX (writer, wrap, ref first);


    /// <summary>
    /// Serialize this object to the specified output stream.
    /// Unlike the Serlialize() method, this method is not inherited from the
    /// parent class allowing a specific version of the method to be called.
    /// </summary>
    /// <param name="_writer">Output stream</param>
    /// <param name="_wrap">If true, output is wrapped with object
    /// start and end sequences '{ ... }'.</param>
    /// <param name="_first">If true, item is the first entry in a list.</param>
	public new void SerializeX (Writer _writer, bool _wrap, ref bool _first) {
		PreEncode();
		if (_wrap) {
			_writer.WriteObjectStart ();
			}
		((Result)this).SerializeX(_writer, false, ref _first);
		if (__Count){
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Count", 1);
				_writer.WriteInteger32 (Count);
			}
		if (_wrap) {
			_writer.WriteObjectEnd ();
			}
		}

    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ResultLog FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ResultLog;
			}
		var Result = new ResultLog ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			case "Count" : {
				Count = jsonReader.ReadInteger32 ();
				break;
				}
			default : {
				base.DeserializeToken(jsonReader, tag);
				break;
				}
			}
		// check up that all the required elements are present
		}


	}

	/// <summary>
	/// </summary>
public partial class ResultArchive : Result {
        /// <summary>
        /// </summary>

	public virtual List<FileEntry>				Entries  {get; set;}
	bool								__Frames = false;
	private int						_Frames;
        /// <summary>
        /// </summary>

	public virtual int						Frames {
		get => _Frames;
		set {_Frames = value; __Frames = true; }
		}
	bool								__Deleted = false;
	private int						_Deleted;
        /// <summary>
        /// </summary>

	public virtual int						Deleted {
		get => _Deleted;
		set {_Deleted = value; __Deleted = true; }
		}
	bool								__IndexFrame = false;
	private int						_IndexFrame;
        /// <summary>
        /// </summary>

	public virtual int						IndexFrame {
		get => _IndexFrame;
		set {_IndexFrame = value; __IndexFrame = true; }
		}
		
	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "ResultArchive";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ResultArchive();


    /// <summary>
    /// Serialize this object to the specified output stream.
    /// </summary>
    /// <param name="writer">Output stream</param>
    /// <param name="wrap">If true, output is wrapped with object
    /// start and end sequences '{ ... }'.</param>
    /// <param name="first">If true, item is the first entry in a list.</param>
	public override void Serialize (Writer writer, bool wrap, ref bool first) =>
		SerializeX (writer, wrap, ref first);


    /// <summary>
    /// Serialize this object to the specified output stream.
    /// Unlike the Serlialize() method, this method is not inherited from the
    /// parent class allowing a specific version of the method to be called.
    /// </summary>
    /// <param name="_writer">Output stream</param>
    /// <param name="_wrap">If true, output is wrapped with object
    /// start and end sequences '{ ... }'.</param>
    /// <param name="_first">If true, item is the first entry in a list.</param>
	public new void SerializeX (Writer _writer, bool _wrap, ref bool _first) {
		PreEncode();
		if (_wrap) {
			_writer.WriteObjectStart ();
			}
		((Result)this).SerializeX(_writer, false, ref _first);
		if (Entries != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Entries", 1);
			_writer.WriteArrayStart ();
			bool _firstarray = true;
			foreach (var _index in Entries) {
				_writer.WriteArraySeparator (ref _firstarray);
				// This is an untagged structure. Cannot inherit.
                //_writer.WriteObjectStart();
                //_writer.WriteToken(_index._Tag, 1);
				bool firstinner = true;
				_index.Serialize (_writer, true, ref firstinner);
                //_writer.WriteObjectEnd();
				}
			_writer.WriteArrayEnd ();
			}

		if (__Frames){
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Frames", 1);
				_writer.WriteInteger32 (Frames);
			}
		if (__Deleted){
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Deleted", 1);
				_writer.WriteInteger32 (Deleted);
			}
		if (__IndexFrame){
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("IndexFrame", 1);
				_writer.WriteInteger32 (IndexFrame);
			}
		if (_wrap) {
			_writer.WriteObjectEnd ();
			}
		}

    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ResultArchive FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ResultArchive;
			}
		var Result = new ResultArchive ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			case "Entries" : {
				// Have a sequence of values
				bool _Going = jsonReader.StartArray ();
				Entries = new List <FileEntry> ();
				while (_Going) {
					// an untagged structure.
					var _Item = new  FileEntry ();
					_Item.Deserialize (jsonReader);
					// var _Item = new FileEntry (jsonReader);
					Entries.Add (_Item);
					_Going = jsonReader.NextArray ();
					}
				break;
				}
			case "Frames" : {
				Frames = jsonReader.ReadInteger32 ();
				break;
				}
			case "Deleted" : {
				Deleted = jsonReader.ReadInteger32 ();
				break;
				}
			case "IndexFrame" : {
				IndexFrame = jsonReader.ReadInteger32 ();
				break;
				}
			default : {
				base.DeserializeToken(jsonReader, tag);
				break;
				}
			}
		// check up that all the required elements are present
		}


	}

	/// <summary>
	/// </summary>
public partial class ResultFileDare : ResultFile {
        /// <summary>
        /// </summary>

	public virtual DareEnvelope						Envelope  {get; set;}
		
	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "ResultFileDare";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ResultFileDare();


    /// <summary>
    /// Serialize this object to the specified output stream.
    /// </summary>
    /// <param name="writer">Output stream</param>
    /// <param name="wrap">If true, output is wrapped with object
    /// start and end sequences '{ ... }'.</param>
    /// <param name="first">If true, item is the first entry in a list.</param>
	public override void Serialize (Writer writer, bool wrap, ref bool first) =>
		SerializeX (writer, wrap, ref first);


    /// <summary>
    /// Serialize this object to the specified output stream.
    /// Unlike the Serlialize() method, this method is not inherited from the
    /// parent class allowing a specific version of the method to be called.
    /// </summary>
    /// <param name="_writer">Output stream</param>
    /// <param name="_wrap">If true, output is wrapped with object
    /// start and end sequences '{ ... }'.</param>
    /// <param name="_first">If true, item is the first entry in a list.</param>
	public new void SerializeX (Writer _writer, bool _wrap, ref bool _first) {
		PreEncode();
		if (_wrap) {
			_writer.WriteObjectStart ();
			}
		((ResultFile)this).SerializeX(_writer, false, ref _first);
		if (Envelope != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Envelope", 1);
				Envelope.Serialize (_writer, false);
			}
		if (_wrap) {
			_writer.WriteObjectEnd ();
			}
		}

    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ResultFileDare FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ResultFileDare;
			}
		var Result = new ResultFileDare ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			case "Envelope" : {
				// An untagged structure
				Envelope = new DareEnvelope ();
				Envelope.Deserialize (jsonReader);
 
				break;
				}
			default : {
				base.DeserializeToken(jsonReader, tag);
				break;
				}
			}
		// check up that all the required elements are present
		}


	}

	/// <summary>
	/// </summary>
public partial class ResultFileEARL : Result {
        /// <summary>
        /// </summary>

	public virtual string						Source  {get; set;}
        /// <summary>
        /// </summary>

	public virtual string						Created  {get; set;}
        /// <summary>
        /// </summary>

	public virtual string						URI  {get; set;}
		
	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "ResultFileEARL";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ResultFileEARL();


    /// <summary>
    /// Serialize this object to the specified output stream.
    /// </summary>
    /// <param name="writer">Output stream</param>
    /// <param name="wrap">If true, output is wrapped with object
    /// start and end sequences '{ ... }'.</param>
    /// <param name="first">If true, item is the first entry in a list.</param>
	public override void Serialize (Writer writer, bool wrap, ref bool first) =>
		SerializeX (writer, wrap, ref first);


    /// <summary>
    /// Serialize this object to the specified output stream.
    /// Unlike the Serlialize() method, this method is not inherited from the
    /// parent class allowing a specific version of the method to be called.
    /// </summary>
    /// <param name="_writer">Output stream</param>
    /// <param name="_wrap">If true, output is wrapped with object
    /// start and end sequences '{ ... }'.</param>
    /// <param name="_first">If true, item is the first entry in a list.</param>
	public new void SerializeX (Writer _writer, bool _wrap, ref bool _first) {
		PreEncode();
		if (_wrap) {
			_writer.WriteObjectStart ();
			}
		((Result)this).SerializeX(_writer, false, ref _first);
		if (Source != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Source", 1);
				_writer.WriteString (Source);
			}
		if (Created != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Created", 1);
				_writer.WriteString (Created);
			}
		if (URI != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("URI", 1);
				_writer.WriteString (URI);
			}
		if (_wrap) {
			_writer.WriteObjectEnd ();
			}
		}

    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ResultFileEARL FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ResultFileEARL;
			}
		var Result = new ResultFileEARL ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			case "Source" : {
				Source = jsonReader.ReadString ();
				break;
				}
			case "Created" : {
				Created = jsonReader.ReadString ();
				break;
				}
			case "URI" : {
				URI = jsonReader.ReadString ();
				break;
				}
			default : {
				base.DeserializeToken(jsonReader, tag);
				break;
				}
			}
		// check up that all the required elements are present
		}


	}

	/// <summary>
	/// </summary>
public partial class ResultDump : Result {
        /// <summary>
        /// </summary>

	public virtual List<CatalogedEntry>				CatalogedEntries  {get; set;}
		
	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "ResultDump";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ResultDump();


    /// <summary>
    /// Serialize this object to the specified output stream.
    /// </summary>
    /// <param name="writer">Output stream</param>
    /// <param name="wrap">If true, output is wrapped with object
    /// start and end sequences '{ ... }'.</param>
    /// <param name="first">If true, item is the first entry in a list.</param>
	public override void Serialize (Writer writer, bool wrap, ref bool first) =>
		SerializeX (writer, wrap, ref first);


    /// <summary>
    /// Serialize this object to the specified output stream.
    /// Unlike the Serlialize() method, this method is not inherited from the
    /// parent class allowing a specific version of the method to be called.
    /// </summary>
    /// <param name="_writer">Output stream</param>
    /// <param name="_wrap">If true, output is wrapped with object
    /// start and end sequences '{ ... }'.</param>
    /// <param name="_first">If true, item is the first entry in a list.</param>
	public new void SerializeX (Writer _writer, bool _wrap, ref bool _first) {
		PreEncode();
		if (_wrap) {
			_writer.WriteObjectStart ();
			}
		((Result)this).SerializeX(_writer, false, ref _first);
		if (CatalogedEntries != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("CatalogedEntries", 1);
			_writer.WriteArrayStart ();
			bool _firstarray = true;
			foreach (var _index in CatalogedEntries) {
				_writer.WriteArraySeparator (ref _firstarray);
                _writer.WriteObjectStart();
                _writer.WriteToken(_index._Tag, 1);
				bool firstinner = true;
				_index.Serialize (_writer, true, ref firstinner);
                _writer.WriteObjectEnd();
				}
			_writer.WriteArrayEnd ();
			}

		if (_wrap) {
			_writer.WriteObjectEnd ();
			}
		}

    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ResultDump FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ResultDump;
			}
		var Result = new ResultDump ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			case "CatalogedEntries" : {
				// Have a sequence of values
				bool _Going = jsonReader.StartArray ();
				CatalogedEntries = new List <CatalogedEntry> ();
				while (_Going) {
					var _Item = CatalogedEntry.FromJson (jsonReader, true); // a tagged structure
					CatalogedEntries.Add (_Item);
					_Going = jsonReader.NextArray ();
					}
				break;
				}
			default : {
				base.DeserializeToken(jsonReader, tag);
				break;
				}
			}
		// check up that all the required elements are present
		}


	}

	/// <summary>
	/// </summary>
public partial class ResultList : Result {
        /// <summary>
        /// </summary>

	public virtual List<CatalogedDevice>				CatalogedDevices  {get; set;}
        /// <summary>
        /// </summary>

	public virtual List<Assertion>				Profiles  {get; set;}
		
	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "ResultList";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ResultList();


    /// <summary>
    /// Serialize this object to the specified output stream.
    /// </summary>
    /// <param name="writer">Output stream</param>
    /// <param name="wrap">If true, output is wrapped with object
    /// start and end sequences '{ ... }'.</param>
    /// <param name="first">If true, item is the first entry in a list.</param>
	public override void Serialize (Writer writer, bool wrap, ref bool first) =>
		SerializeX (writer, wrap, ref first);


    /// <summary>
    /// Serialize this object to the specified output stream.
    /// Unlike the Serlialize() method, this method is not inherited from the
    /// parent class allowing a specific version of the method to be called.
    /// </summary>
    /// <param name="_writer">Output stream</param>
    /// <param name="_wrap">If true, output is wrapped with object
    /// start and end sequences '{ ... }'.</param>
    /// <param name="_first">If true, item is the first entry in a list.</param>
	public new void SerializeX (Writer _writer, bool _wrap, ref bool _first) {
		PreEncode();
		if (_wrap) {
			_writer.WriteObjectStart ();
			}
		((Result)this).SerializeX(_writer, false, ref _first);
		if (CatalogedDevices != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("CatalogedDevices", 1);
			_writer.WriteArrayStart ();
			bool _firstarray = true;
			foreach (var _index in CatalogedDevices) {
				_writer.WriteArraySeparator (ref _firstarray);
				// This is an untagged structure. Cannot inherit.
                //_writer.WriteObjectStart();
                //_writer.WriteToken(_index._Tag, 1);
				bool firstinner = true;
				_index.Serialize (_writer, true, ref firstinner);
                //_writer.WriteObjectEnd();
				}
			_writer.WriteArrayEnd ();
			}

		if (Profiles != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Profiles", 1);
			_writer.WriteArrayStart ();
			bool _firstarray = true;
			foreach (var _index in Profiles) {
				_writer.WriteArraySeparator (ref _firstarray);
                _writer.WriteObjectStart();
                _writer.WriteToken(_index._Tag, 1);
				bool firstinner = true;
				_index.Serialize (_writer, true, ref firstinner);
                _writer.WriteObjectEnd();
				}
			_writer.WriteArrayEnd ();
			}

		if (_wrap) {
			_writer.WriteObjectEnd ();
			}
		}

    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ResultList FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ResultList;
			}
		var Result = new ResultList ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			case "CatalogedDevices" : {
				// Have a sequence of values
				bool _Going = jsonReader.StartArray ();
				CatalogedDevices = new List <CatalogedDevice> ();
				while (_Going) {
					// an untagged structure.
					var _Item = new  CatalogedDevice ();
					_Item.Deserialize (jsonReader);
					// var _Item = new CatalogedDevice (jsonReader);
					CatalogedDevices.Add (_Item);
					_Going = jsonReader.NextArray ();
					}
				break;
				}
			case "Profiles" : {
				// Have a sequence of values
				bool _Going = jsonReader.StartArray ();
				Profiles = new List <Assertion> ();
				while (_Going) {
					var _Item = Assertion.FromJson (jsonReader, true); // a tagged structure
					Profiles.Add (_Item);
					_Going = jsonReader.NextArray ();
					}
				break;
				}
			default : {
				base.DeserializeToken(jsonReader, tag);
				break;
				}
			}
		// check up that all the required elements are present
		}


	}

	/// <summary>
	/// </summary>
public partial class ResultAccountConnect : Result {
        /// <summary>
        /// </summary>

	public virtual ProfileDevice						ProfileDevice  {get; set;}
		
	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "ResultAccountConnect";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ResultAccountConnect();


    /// <summary>
    /// Serialize this object to the specified output stream.
    /// </summary>
    /// <param name="writer">Output stream</param>
    /// <param name="wrap">If true, output is wrapped with object
    /// start and end sequences '{ ... }'.</param>
    /// <param name="first">If true, item is the first entry in a list.</param>
	public override void Serialize (Writer writer, bool wrap, ref bool first) =>
		SerializeX (writer, wrap, ref first);


    /// <summary>
    /// Serialize this object to the specified output stream.
    /// Unlike the Serlialize() method, this method is not inherited from the
    /// parent class allowing a specific version of the method to be called.
    /// </summary>
    /// <param name="_writer">Output stream</param>
    /// <param name="_wrap">If true, output is wrapped with object
    /// start and end sequences '{ ... }'.</param>
    /// <param name="_first">If true, item is the first entry in a list.</param>
	public new void SerializeX (Writer _writer, bool _wrap, ref bool _first) {
		PreEncode();
		if (_wrap) {
			_writer.WriteObjectStart ();
			}
		((Result)this).SerializeX(_writer, false, ref _first);
		if (ProfileDevice != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("ProfileDevice", 1);
				ProfileDevice.Serialize (_writer, false);
			}
		if (_wrap) {
			_writer.WriteObjectEnd ();
			}
		}

    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ResultAccountConnect FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ResultAccountConnect;
			}
		var Result = new ResultAccountConnect ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			case "ProfileDevice" : {
				// An untagged structure
				ProfileDevice = new ProfileDevice ();
				ProfileDevice.Deserialize (jsonReader);
 
				break;
				}
			default : {
				base.DeserializeToken(jsonReader, tag);
				break;
				}
			}
		// check up that all the required elements are present
		}


	}

	/// <summary>
	/// </summary>
public partial class ResultPublish : ResultCreateDevice {
        /// <summary>
        /// </summary>

	public virtual string						Uri  {get; set;}
		
	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "ResultPublish";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ResultPublish();


    /// <summary>
    /// Serialize this object to the specified output stream.
    /// </summary>
    /// <param name="writer">Output stream</param>
    /// <param name="wrap">If true, output is wrapped with object
    /// start and end sequences '{ ... }'.</param>
    /// <param name="first">If true, item is the first entry in a list.</param>
	public override void Serialize (Writer writer, bool wrap, ref bool first) =>
		SerializeX (writer, wrap, ref first);


    /// <summary>
    /// Serialize this object to the specified output stream.
    /// Unlike the Serlialize() method, this method is not inherited from the
    /// parent class allowing a specific version of the method to be called.
    /// </summary>
    /// <param name="_writer">Output stream</param>
    /// <param name="_wrap">If true, output is wrapped with object
    /// start and end sequences '{ ... }'.</param>
    /// <param name="_first">If true, item is the first entry in a list.</param>
	public new void SerializeX (Writer _writer, bool _wrap, ref bool _first) {
		PreEncode();
		if (_wrap) {
			_writer.WriteObjectStart ();
			}
		((ResultCreateDevice)this).SerializeX(_writer, false, ref _first);
		if (Uri != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Uri", 1);
				_writer.WriteString (Uri);
			}
		if (_wrap) {
			_writer.WriteObjectEnd ();
			}
		}

    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ResultPublish FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ResultPublish;
			}
		var Result = new ResultPublish ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			case "Uri" : {
				Uri = jsonReader.ReadString ();
				break;
				}
			default : {
				base.DeserializeToken(jsonReader, tag);
				break;
				}
			}
		// check up that all the required elements are present
		}


	}

	/// <summary>
	/// </summary>
public partial class ResultPublishDevice : ResultCreateDevice {
        /// <summary>
        /// </summary>

	public virtual string						Uri  {get; set;}
        /// <summary>
        /// </summary>

	public virtual string						FileName  {get; set;}
        /// <summary>
        /// </summary>

	public virtual DevicePreconfigurationPublic						DevicePreconfigurationPublic  {get; set;}
        /// <summary>
        /// </summary>

	public virtual DevicePreconfigurationPrivate						DevicePreconfigurationPrivate  {get; set;}
		
	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "ResultPublishDevice";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ResultPublishDevice();


    /// <summary>
    /// Serialize this object to the specified output stream.
    /// </summary>
    /// <param name="writer">Output stream</param>
    /// <param name="wrap">If true, output is wrapped with object
    /// start and end sequences '{ ... }'.</param>
    /// <param name="first">If true, item is the first entry in a list.</param>
	public override void Serialize (Writer writer, bool wrap, ref bool first) =>
		SerializeX (writer, wrap, ref first);


    /// <summary>
    /// Serialize this object to the specified output stream.
    /// Unlike the Serlialize() method, this method is not inherited from the
    /// parent class allowing a specific version of the method to be called.
    /// </summary>
    /// <param name="_writer">Output stream</param>
    /// <param name="_wrap">If true, output is wrapped with object
    /// start and end sequences '{ ... }'.</param>
    /// <param name="_first">If true, item is the first entry in a list.</param>
	public new void SerializeX (Writer _writer, bool _wrap, ref bool _first) {
		PreEncode();
		if (_wrap) {
			_writer.WriteObjectStart ();
			}
		((ResultCreateDevice)this).SerializeX(_writer, false, ref _first);
		if (Uri != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Uri", 1);
				_writer.WriteString (Uri);
			}
		if (FileName != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("FileName", 1);
				_writer.WriteString (FileName);
			}
		if (DevicePreconfigurationPublic != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("DevicePreconfigurationPublic", 1);
				DevicePreconfigurationPublic.Serialize (_writer, false);
			}
		if (DevicePreconfigurationPrivate != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("DevicePreconfigurationPrivate", 1);
				DevicePreconfigurationPrivate.Serialize (_writer, false);
			}
		if (_wrap) {
			_writer.WriteObjectEnd ();
			}
		}

    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ResultPublishDevice FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ResultPublishDevice;
			}
		var Result = new ResultPublishDevice ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			case "Uri" : {
				Uri = jsonReader.ReadString ();
				break;
				}
			case "FileName" : {
				FileName = jsonReader.ReadString ();
				break;
				}
			case "DevicePreconfigurationPublic" : {
				// An untagged structure
				DevicePreconfigurationPublic = new DevicePreconfigurationPublic ();
				DevicePreconfigurationPublic.Deserialize (jsonReader);
 
				break;
				}
			case "DevicePreconfigurationPrivate" : {
				// An untagged structure
				DevicePreconfigurationPrivate = new DevicePreconfigurationPrivate ();
				DevicePreconfigurationPrivate.Deserialize (jsonReader);
 
				break;
				}
			default : {
				base.DeserializeToken(jsonReader, tag);
				break;
				}
			}
		// check up that all the required elements are present
		}


	}

	/// <summary>
	/// </summary>
public partial class ResultCreateDevice : Result {
	bool								__Default = false;
	private bool						_Default;
        /// <summary>
        /// </summary>

	public virtual bool						Default {
		get => _Default;
		set {_Default = value; __Default = true; }
		}
        /// <summary>
        /// </summary>

	public virtual string						DeviceUDF  {get; set;}
        /// <summary>
        /// </summary>

	public virtual CatalogedDevice						CatalogedDevice  {get; set;}
		
	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "ResultCreateDevice";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ResultCreateDevice();


    /// <summary>
    /// Serialize this object to the specified output stream.
    /// </summary>
    /// <param name="writer">Output stream</param>
    /// <param name="wrap">If true, output is wrapped with object
    /// start and end sequences '{ ... }'.</param>
    /// <param name="first">If true, item is the first entry in a list.</param>
	public override void Serialize (Writer writer, bool wrap, ref bool first) =>
		SerializeX (writer, wrap, ref first);


    /// <summary>
    /// Serialize this object to the specified output stream.
    /// Unlike the Serlialize() method, this method is not inherited from the
    /// parent class allowing a specific version of the method to be called.
    /// </summary>
    /// <param name="_writer">Output stream</param>
    /// <param name="_wrap">If true, output is wrapped with object
    /// start and end sequences '{ ... }'.</param>
    /// <param name="_first">If true, item is the first entry in a list.</param>
	public new void SerializeX (Writer _writer, bool _wrap, ref bool _first) {
		PreEncode();
		if (_wrap) {
			_writer.WriteObjectStart ();
			}
		((Result)this).SerializeX(_writer, false, ref _first);
		if (__Default){
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Default", 1);
				_writer.WriteBoolean (Default);
			}
		if (DeviceUDF != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("DeviceUDF", 1);
				_writer.WriteString (DeviceUDF);
			}
		if (CatalogedDevice != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("CatalogedDevice", 1);
				CatalogedDevice.Serialize (_writer, false);
			}
		if (_wrap) {
			_writer.WriteObjectEnd ();
			}
		}

    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ResultCreateDevice FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ResultCreateDevice;
			}
		var Result = new ResultCreateDevice ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			case "Default" : {
				Default = jsonReader.ReadBoolean ();
				break;
				}
			case "DeviceUDF" : {
				DeviceUDF = jsonReader.ReadString ();
				break;
				}
			case "CatalogedDevice" : {
				// An untagged structure
				CatalogedDevice = new CatalogedDevice ();
				CatalogedDevice.Deserialize (jsonReader);
 
				break;
				}
			default : {
				base.DeserializeToken(jsonReader, tag);
				break;
				}
			}
		// check up that all the required elements are present
		}


	}

	/// <summary>
	/// </summary>
public partial class ResultCreatePersonal : ResultCreateAccount {
        /// <summary>
        /// </summary>

	public virtual string						MeshUDF  {get; set;}
		
	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "ResultCreatePersonal";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ResultCreatePersonal();


    /// <summary>
    /// Serialize this object to the specified output stream.
    /// </summary>
    /// <param name="writer">Output stream</param>
    /// <param name="wrap">If true, output is wrapped with object
    /// start and end sequences '{ ... }'.</param>
    /// <param name="first">If true, item is the first entry in a list.</param>
	public override void Serialize (Writer writer, bool wrap, ref bool first) =>
		SerializeX (writer, wrap, ref first);


    /// <summary>
    /// Serialize this object to the specified output stream.
    /// Unlike the Serlialize() method, this method is not inherited from the
    /// parent class allowing a specific version of the method to be called.
    /// </summary>
    /// <param name="_writer">Output stream</param>
    /// <param name="_wrap">If true, output is wrapped with object
    /// start and end sequences '{ ... }'.</param>
    /// <param name="_first">If true, item is the first entry in a list.</param>
	public new void SerializeX (Writer _writer, bool _wrap, ref bool _first) {
		PreEncode();
		if (_wrap) {
			_writer.WriteObjectStart ();
			}
		((ResultCreateAccount)this).SerializeX(_writer, false, ref _first);
		if (MeshUDF != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("MeshUDF", 1);
				_writer.WriteString (MeshUDF);
			}
		if (_wrap) {
			_writer.WriteObjectEnd ();
			}
		}

    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ResultCreatePersonal FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ResultCreatePersonal;
			}
		var Result = new ResultCreatePersonal ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			case "MeshUDF" : {
				MeshUDF = jsonReader.ReadString ();
				break;
				}
			default : {
				base.DeserializeToken(jsonReader, tag);
				break;
				}
			}
		// check up that all the required elements are present
		}


	}

	/// <summary>
	/// </summary>
public partial class ResultCreateAccount : ResultCreateDevice {
        /// <summary>
        /// </summary>

	public virtual ProfileAccount						ProfileAccount  {get; set;}
        /// <summary>
        /// </summary>

	public virtual ActivationDevice						ActivationDevice  {get; set;}
		
	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "ResultCreateAccount";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ResultCreateAccount();


    /// <summary>
    /// Serialize this object to the specified output stream.
    /// </summary>
    /// <param name="writer">Output stream</param>
    /// <param name="wrap">If true, output is wrapped with object
    /// start and end sequences '{ ... }'.</param>
    /// <param name="first">If true, item is the first entry in a list.</param>
	public override void Serialize (Writer writer, bool wrap, ref bool first) =>
		SerializeX (writer, wrap, ref first);


    /// <summary>
    /// Serialize this object to the specified output stream.
    /// Unlike the Serlialize() method, this method is not inherited from the
    /// parent class allowing a specific version of the method to be called.
    /// </summary>
    /// <param name="_writer">Output stream</param>
    /// <param name="_wrap">If true, output is wrapped with object
    /// start and end sequences '{ ... }'.</param>
    /// <param name="_first">If true, item is the first entry in a list.</param>
	public new void SerializeX (Writer _writer, bool _wrap, ref bool _first) {
		PreEncode();
		if (_wrap) {
			_writer.WriteObjectStart ();
			}
		((ResultCreateDevice)this).SerializeX(_writer, false, ref _first);
		if (ProfileAccount != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("ProfileAccount", 1);
				ProfileAccount.Serialize (_writer, false);
			}
		if (ActivationDevice != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("ActivationDevice", 1);
				ActivationDevice.Serialize (_writer, false);
			}
		if (_wrap) {
			_writer.WriteObjectEnd ();
			}
		}

    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ResultCreateAccount FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ResultCreateAccount;
			}
		var Result = new ResultCreateAccount ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			case "ProfileAccount" : {
				// An untagged structure
				ProfileAccount = new ProfileAccount ();
				ProfileAccount.Deserialize (jsonReader);
 
				break;
				}
			case "ActivationDevice" : {
				// An untagged structure
				ActivationDevice = new ActivationDevice ();
				ActivationDevice.Deserialize (jsonReader);
 
				break;
				}
			default : {
				base.DeserializeToken(jsonReader, tag);
				break;
				}
			}
		// check up that all the required elements are present
		}


	}

	/// <summary>
	/// </summary>
public partial class ResultDeleteAccount : ResultCreateDevice {
        /// <summary>
        /// </summary>

	public virtual string						UDF  {get; set;}
		
	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "ResultDeleteAccount";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ResultDeleteAccount();


    /// <summary>
    /// Serialize this object to the specified output stream.
    /// </summary>
    /// <param name="writer">Output stream</param>
    /// <param name="wrap">If true, output is wrapped with object
    /// start and end sequences '{ ... }'.</param>
    /// <param name="first">If true, item is the first entry in a list.</param>
	public override void Serialize (Writer writer, bool wrap, ref bool first) =>
		SerializeX (writer, wrap, ref first);


    /// <summary>
    /// Serialize this object to the specified output stream.
    /// Unlike the Serlialize() method, this method is not inherited from the
    /// parent class allowing a specific version of the method to be called.
    /// </summary>
    /// <param name="_writer">Output stream</param>
    /// <param name="_wrap">If true, output is wrapped with object
    /// start and end sequences '{ ... }'.</param>
    /// <param name="_first">If true, item is the first entry in a list.</param>
	public new void SerializeX (Writer _writer, bool _wrap, ref bool _first) {
		PreEncode();
		if (_wrap) {
			_writer.WriteObjectStart ();
			}
		((ResultCreateDevice)this).SerializeX(_writer, false, ref _first);
		if (UDF != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("UDF", 1);
				_writer.WriteString (UDF);
			}
		if (_wrap) {
			_writer.WriteObjectEnd ();
			}
		}

    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ResultDeleteAccount FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ResultDeleteAccount;
			}
		var Result = new ResultDeleteAccount ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			case "UDF" : {
				UDF = jsonReader.ReadString ();
				break;
				}
			default : {
				base.DeserializeToken(jsonReader, tag);
				break;
				}
			}
		// check up that all the required elements are present
		}


	}

	/// <summary>
	/// </summary>
public partial class ResultRegisterService : ResultCreateAccount {
        /// <summary>
        /// </summary>

	public virtual string						AccountAddress  {get; set;}
		
	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "ResultRegisterService";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ResultRegisterService();


    /// <summary>
    /// Serialize this object to the specified output stream.
    /// </summary>
    /// <param name="writer">Output stream</param>
    /// <param name="wrap">If true, output is wrapped with object
    /// start and end sequences '{ ... }'.</param>
    /// <param name="first">If true, item is the first entry in a list.</param>
	public override void Serialize (Writer writer, bool wrap, ref bool first) =>
		SerializeX (writer, wrap, ref first);


    /// <summary>
    /// Serialize this object to the specified output stream.
    /// Unlike the Serlialize() method, this method is not inherited from the
    /// parent class allowing a specific version of the method to be called.
    /// </summary>
    /// <param name="_writer">Output stream</param>
    /// <param name="_wrap">If true, output is wrapped with object
    /// start and end sequences '{ ... }'.</param>
    /// <param name="_first">If true, item is the first entry in a list.</param>
	public new void SerializeX (Writer _writer, bool _wrap, ref bool _first) {
		PreEncode();
		if (_wrap) {
			_writer.WriteObjectStart ();
			}
		((ResultCreateAccount)this).SerializeX(_writer, false, ref _first);
		if (AccountAddress != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("AccountAddress", 1);
				_writer.WriteString (AccountAddress);
			}
		if (_wrap) {
			_writer.WriteObjectEnd ();
			}
		}

    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ResultRegisterService FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ResultRegisterService;
			}
		var Result = new ResultRegisterService ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			case "AccountAddress" : {
				AccountAddress = jsonReader.ReadString ();
				break;
				}
			default : {
				base.DeserializeToken(jsonReader, tag);
				break;
				}
			}
		// check up that all the required elements are present
		}


	}

	/// <summary>
	/// </summary>
public partial class ResultRecover : ResultCreatePersonal {
		
	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "ResultRecover";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ResultRecover();


    /// <summary>
    /// Serialize this object to the specified output stream.
    /// </summary>
    /// <param name="writer">Output stream</param>
    /// <param name="wrap">If true, output is wrapped with object
    /// start and end sequences '{ ... }'.</param>
    /// <param name="first">If true, item is the first entry in a list.</param>
	public override void Serialize (Writer writer, bool wrap, ref bool first) =>
		SerializeX (writer, wrap, ref first);


    /// <summary>
    /// Serialize this object to the specified output stream.
    /// Unlike the Serlialize() method, this method is not inherited from the
    /// parent class allowing a specific version of the method to be called.
    /// </summary>
    /// <param name="_writer">Output stream</param>
    /// <param name="_wrap">If true, output is wrapped with object
    /// start and end sequences '{ ... }'.</param>
    /// <param name="_first">If true, item is the first entry in a list.</param>
	public new void SerializeX (Writer _writer, bool _wrap, ref bool _first) {
		PreEncode();
		if (_wrap) {
			_writer.WriteObjectStart ();
			}
		((ResultCreatePersonal)this).SerializeX(_writer, false, ref _first);
		if (_wrap) {
			_writer.WriteObjectEnd ();
			}
		}

    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ResultRecover FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ResultRecover;
			}
		var Result = new ResultRecover ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			default : {
				base.DeserializeToken(jsonReader, tag);
				break;
				}
			}
		// check up that all the required elements are present
		}


	}

	/// <summary>
	/// </summary>
public partial class ResultStatus : Result {
        /// <summary>
        /// </summary>

	public virtual StatusResponse						StatusResponse  {get; set;}
		
	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "ResultStatus";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ResultStatus();


    /// <summary>
    /// Serialize this object to the specified output stream.
    /// </summary>
    /// <param name="writer">Output stream</param>
    /// <param name="wrap">If true, output is wrapped with object
    /// start and end sequences '{ ... }'.</param>
    /// <param name="first">If true, item is the first entry in a list.</param>
	public override void Serialize (Writer writer, bool wrap, ref bool first) =>
		SerializeX (writer, wrap, ref first);


    /// <summary>
    /// Serialize this object to the specified output stream.
    /// Unlike the Serlialize() method, this method is not inherited from the
    /// parent class allowing a specific version of the method to be called.
    /// </summary>
    /// <param name="_writer">Output stream</param>
    /// <param name="_wrap">If true, output is wrapped with object
    /// start and end sequences '{ ... }'.</param>
    /// <param name="_first">If true, item is the first entry in a list.</param>
	public new void SerializeX (Writer _writer, bool _wrap, ref bool _first) {
		PreEncode();
		if (_wrap) {
			_writer.WriteObjectStart ();
			}
		((Result)this).SerializeX(_writer, false, ref _first);
		if (StatusResponse != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("StatusResponse", 1);
				StatusResponse.Serialize (_writer, false);
			}
		if (_wrap) {
			_writer.WriteObjectEnd ();
			}
		}

    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ResultStatus FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ResultStatus;
			}
		var Result = new ResultStatus ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			case "StatusResponse" : {
				// An untagged structure
				StatusResponse = new StatusResponse ();
				StatusResponse.Deserialize (jsonReader);
 
				break;
				}
			default : {
				base.DeserializeToken(jsonReader, tag);
				break;
				}
			}
		// check up that all the required elements are present
		}


	}

	/// <summary>
	/// </summary>
public partial class ResultSync : Result {
	bool								__Fetched = false;
	private int						_Fetched;
        /// <summary>
        /// </summary>

	public virtual int						Fetched {
		get => _Fetched;
		set {_Fetched = value; __Fetched = true; }
		}
	bool								__ProcessedResults = false;
	private int						_ProcessedResults;
        /// <summary>
        /// </summary>

	public virtual int						ProcessedResults {
		get => _ProcessedResults;
		set {_ProcessedResults = value; __ProcessedResults = true; }
		}
        /// <summary>
        /// </summary>

	public virtual List<ProcessResult>				ProcessResults  {get; set;}
		
	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "ResultSync";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ResultSync();


    /// <summary>
    /// Serialize this object to the specified output stream.
    /// </summary>
    /// <param name="writer">Output stream</param>
    /// <param name="wrap">If true, output is wrapped with object
    /// start and end sequences '{ ... }'.</param>
    /// <param name="first">If true, item is the first entry in a list.</param>
	public override void Serialize (Writer writer, bool wrap, ref bool first) =>
		SerializeX (writer, wrap, ref first);


    /// <summary>
    /// Serialize this object to the specified output stream.
    /// Unlike the Serlialize() method, this method is not inherited from the
    /// parent class allowing a specific version of the method to be called.
    /// </summary>
    /// <param name="_writer">Output stream</param>
    /// <param name="_wrap">If true, output is wrapped with object
    /// start and end sequences '{ ... }'.</param>
    /// <param name="_first">If true, item is the first entry in a list.</param>
	public new void SerializeX (Writer _writer, bool _wrap, ref bool _first) {
		PreEncode();
		if (_wrap) {
			_writer.WriteObjectStart ();
			}
		((Result)this).SerializeX(_writer, false, ref _first);
		if (__Fetched){
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Fetched", 1);
				_writer.WriteInteger32 (Fetched);
			}
		if (__ProcessedResults){
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("ProcessedResults", 1);
				_writer.WriteInteger32 (ProcessedResults);
			}
		if (ProcessResults != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("ProcessResults", 1);
			_writer.WriteArrayStart ();
			bool _firstarray = true;
			foreach (var _index in ProcessResults) {
				_writer.WriteArraySeparator (ref _firstarray);
                _writer.WriteObjectStart();
                _writer.WriteToken(_index._Tag, 1);
				bool firstinner = true;
				_index.Serialize (_writer, true, ref firstinner);
                _writer.WriteObjectEnd();
				}
			_writer.WriteArrayEnd ();
			}

		if (_wrap) {
			_writer.WriteObjectEnd ();
			}
		}

    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ResultSync FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ResultSync;
			}
		var Result = new ResultSync ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			case "Fetched" : {
				Fetched = jsonReader.ReadInteger32 ();
				break;
				}
			case "ProcessedResults" : {
				ProcessedResults = jsonReader.ReadInteger32 ();
				break;
				}
			case "ProcessResults" : {
				// Have a sequence of values
				bool _Going = jsonReader.StartArray ();
				ProcessResults = new List <ProcessResult> ();
				while (_Going) {
					var _Item = ProcessResult.FromJson (jsonReader, true); // a tagged structure
					ProcessResults.Add (_Item);
					_Going = jsonReader.NextArray ();
					}
				break;
				}
			default : {
				base.DeserializeToken(jsonReader, tag);
				break;
				}
			}
		// check up that all the required elements are present
		}


	}

	/// <summary>
	/// </summary>
public partial class ResultEscrow : Result {
        /// <summary>
        /// </summary>

	public virtual string						Service  {get; set;}
        /// <summary>
        /// </summary>

	public virtual List<string>				Shares  {get; set;}
		
	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "ResultEscrow";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ResultEscrow();


    /// <summary>
    /// Serialize this object to the specified output stream.
    /// </summary>
    /// <param name="writer">Output stream</param>
    /// <param name="wrap">If true, output is wrapped with object
    /// start and end sequences '{ ... }'.</param>
    /// <param name="first">If true, item is the first entry in a list.</param>
	public override void Serialize (Writer writer, bool wrap, ref bool first) =>
		SerializeX (writer, wrap, ref first);


    /// <summary>
    /// Serialize this object to the specified output stream.
    /// Unlike the Serlialize() method, this method is not inherited from the
    /// parent class allowing a specific version of the method to be called.
    /// </summary>
    /// <param name="_writer">Output stream</param>
    /// <param name="_wrap">If true, output is wrapped with object
    /// start and end sequences '{ ... }'.</param>
    /// <param name="_first">If true, item is the first entry in a list.</param>
	public new void SerializeX (Writer _writer, bool _wrap, ref bool _first) {
		PreEncode();
		if (_wrap) {
			_writer.WriteObjectStart ();
			}
		((Result)this).SerializeX(_writer, false, ref _first);
		if (Service != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Service", 1);
				_writer.WriteString (Service);
			}
		if (Shares != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Shares", 1);
			_writer.WriteArrayStart ();
			bool _firstarray = true;
			foreach (var _index in Shares) {
				_writer.WriteArraySeparator (ref _firstarray);
				_writer.WriteString (_index);
				}
			_writer.WriteArrayEnd ();
			}

		if (_wrap) {
			_writer.WriteObjectEnd ();
			}
		}

    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ResultEscrow FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ResultEscrow;
			}
		var Result = new ResultEscrow ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			case "Service" : {
				Service = jsonReader.ReadString ();
				break;
				}
			case "Shares" : {
				// Have a sequence of values
				bool _Going = jsonReader.StartArray ();
				Shares = new List <string> ();
				while (_Going) {
					string _Item = jsonReader.ReadString ();
					Shares.Add (_Item);
					_Going = jsonReader.NextArray ();
					}
				break;
				}
			default : {
				base.DeserializeToken(jsonReader, tag);
				break;
				}
			}
		// check up that all the required elements are present
		}


	}

	/// <summary>
	/// </summary>
public partial class ResultMachine : Result {
        /// <summary>
        /// </summary>

	public virtual List<CatalogedMachine>				CatalogedMachines  {get; set;}
		
	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "ResultMachine";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ResultMachine();


    /// <summary>
    /// Serialize this object to the specified output stream.
    /// </summary>
    /// <param name="writer">Output stream</param>
    /// <param name="wrap">If true, output is wrapped with object
    /// start and end sequences '{ ... }'.</param>
    /// <param name="first">If true, item is the first entry in a list.</param>
	public override void Serialize (Writer writer, bool wrap, ref bool first) =>
		SerializeX (writer, wrap, ref first);


    /// <summary>
    /// Serialize this object to the specified output stream.
    /// Unlike the Serlialize() method, this method is not inherited from the
    /// parent class allowing a specific version of the method to be called.
    /// </summary>
    /// <param name="_writer">Output stream</param>
    /// <param name="_wrap">If true, output is wrapped with object
    /// start and end sequences '{ ... }'.</param>
    /// <param name="_first">If true, item is the first entry in a list.</param>
	public new void SerializeX (Writer _writer, bool _wrap, ref bool _first) {
		PreEncode();
		if (_wrap) {
			_writer.WriteObjectStart ();
			}
		((Result)this).SerializeX(_writer, false, ref _first);
		if (CatalogedMachines != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("CatalogedMachines", 1);
			_writer.WriteArrayStart ();
			bool _firstarray = true;
			foreach (var _index in CatalogedMachines) {
				_writer.WriteArraySeparator (ref _firstarray);
				// This is an untagged structure. Cannot inherit.
                //_writer.WriteObjectStart();
                //_writer.WriteToken(_index._Tag, 1);
				bool firstinner = true;
				_index.Serialize (_writer, true, ref firstinner);
                //_writer.WriteObjectEnd();
				}
			_writer.WriteArrayEnd ();
			}

		if (_wrap) {
			_writer.WriteObjectEnd ();
			}
		}

    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ResultMachine FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ResultMachine;
			}
		var Result = new ResultMachine ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			case "CatalogedMachines" : {
				// Have a sequence of values
				bool _Going = jsonReader.StartArray ();
				CatalogedMachines = new List <CatalogedMachine> ();
				while (_Going) {
					// an untagged structure.
					var _Item = new  CatalogedMachine ();
					_Item.Deserialize (jsonReader);
					// var _Item = new CatalogedMachine (jsonReader);
					CatalogedMachines.Add (_Item);
					_Going = jsonReader.NextArray ();
					}
				break;
				}
			default : {
				base.DeserializeToken(jsonReader, tag);
				break;
				}
			}
		// check up that all the required elements are present
		}


	}

	/// <summary>
	/// </summary>
public partial class ResultPIN : Result {
        /// <summary>
        /// </summary>

	public virtual MessagePin						MessagePIN  {get; set;}
        /// <summary>
        /// </summary>

	public virtual string						Uri  {get; set;}
		
	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "ResultPIN";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ResultPIN();


    /// <summary>
    /// Serialize this object to the specified output stream.
    /// </summary>
    /// <param name="writer">Output stream</param>
    /// <param name="wrap">If true, output is wrapped with object
    /// start and end sequences '{ ... }'.</param>
    /// <param name="first">If true, item is the first entry in a list.</param>
	public override void Serialize (Writer writer, bool wrap, ref bool first) =>
		SerializeX (writer, wrap, ref first);


    /// <summary>
    /// Serialize this object to the specified output stream.
    /// Unlike the Serlialize() method, this method is not inherited from the
    /// parent class allowing a specific version of the method to be called.
    /// </summary>
    /// <param name="_writer">Output stream</param>
    /// <param name="_wrap">If true, output is wrapped with object
    /// start and end sequences '{ ... }'.</param>
    /// <param name="_first">If true, item is the first entry in a list.</param>
	public new void SerializeX (Writer _writer, bool _wrap, ref bool _first) {
		PreEncode();
		if (_wrap) {
			_writer.WriteObjectStart ();
			}
		((Result)this).SerializeX(_writer, false, ref _first);
		if (MessagePIN != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("MessagePIN", 1);
				MessagePIN.Serialize (_writer, false);
			}
		if (Uri != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Uri", 1);
				_writer.WriteString (Uri);
			}
		if (_wrap) {
			_writer.WriteObjectEnd ();
			}
		}

    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ResultPIN FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ResultPIN;
			}
		var Result = new ResultPIN ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			case "MessagePIN" : {
				// An untagged structure
				MessagePIN = new MessagePin ();
				MessagePIN.Deserialize (jsonReader);
 
				break;
				}
			case "Uri" : {
				Uri = jsonReader.ReadString ();
				break;
				}
			default : {
				base.DeserializeToken(jsonReader, tag);
				break;
				}
			}
		// check up that all the required elements are present
		}


	}

	/// <summary>
	/// </summary>
public partial class ResultHello : Result {
        /// <summary>
        /// </summary>

	public virtual MeshHelloResponse						Response  {get; set;}
		
	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "ResultHello";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ResultHello();


    /// <summary>
    /// Serialize this object to the specified output stream.
    /// </summary>
    /// <param name="writer">Output stream</param>
    /// <param name="wrap">If true, output is wrapped with object
    /// start and end sequences '{ ... }'.</param>
    /// <param name="first">If true, item is the first entry in a list.</param>
	public override void Serialize (Writer writer, bool wrap, ref bool first) =>
		SerializeX (writer, wrap, ref first);


    /// <summary>
    /// Serialize this object to the specified output stream.
    /// Unlike the Serlialize() method, this method is not inherited from the
    /// parent class allowing a specific version of the method to be called.
    /// </summary>
    /// <param name="_writer">Output stream</param>
    /// <param name="_wrap">If true, output is wrapped with object
    /// start and end sequences '{ ... }'.</param>
    /// <param name="_first">If true, item is the first entry in a list.</param>
	public new void SerializeX (Writer _writer, bool _wrap, ref bool _first) {
		PreEncode();
		if (_wrap) {
			_writer.WriteObjectStart ();
			}
		((Result)this).SerializeX(_writer, false, ref _first);
		if (Response != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Response", 1);
				Response.Serialize (_writer, false);
			}
		if (_wrap) {
			_writer.WriteObjectEnd ();
			}
		}

    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ResultHello FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ResultHello;
			}
		var Result = new ResultHello ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			case "Response" : {
				// An untagged structure
				Response = new MeshHelloResponse ();
				Response.Deserialize (jsonReader);
 
				break;
				}
			default : {
				base.DeserializeToken(jsonReader, tag);
				break;
				}
			}
		// check up that all the required elements are present
		}


	}

	/// <summary>
	/// </summary>
public partial class ResultSequence : Result {
        /// <summary>
        /// </summary>

	public virtual LogEntry						Entries  {get; set;}
		
	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "ResultSequence";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ResultSequence();


    /// <summary>
    /// Serialize this object to the specified output stream.
    /// </summary>
    /// <param name="writer">Output stream</param>
    /// <param name="wrap">If true, output is wrapped with object
    /// start and end sequences '{ ... }'.</param>
    /// <param name="first">If true, item is the first entry in a list.</param>
	public override void Serialize (Writer writer, bool wrap, ref bool first) =>
		SerializeX (writer, wrap, ref first);


    /// <summary>
    /// Serialize this object to the specified output stream.
    /// Unlike the Serlialize() method, this method is not inherited from the
    /// parent class allowing a specific version of the method to be called.
    /// </summary>
    /// <param name="_writer">Output stream</param>
    /// <param name="_wrap">If true, output is wrapped with object
    /// start and end sequences '{ ... }'.</param>
    /// <param name="_first">If true, item is the first entry in a list.</param>
	public new void SerializeX (Writer _writer, bool _wrap, ref bool _first) {
		PreEncode();
		if (_wrap) {
			_writer.WriteObjectStart ();
			}
		((Result)this).SerializeX(_writer, false, ref _first);
		if (Entries != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Entries", 1);
				Entries.Serialize (_writer, false);
			}
		if (_wrap) {
			_writer.WriteObjectEnd ();
			}
		}

    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ResultSequence FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ResultSequence;
			}
		var Result = new ResultSequence ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			case "Entries" : {
				// An untagged structure
				Entries = new LogEntry ();
				Entries.Deserialize (jsonReader);
 
				break;
				}
			default : {
				base.DeserializeToken(jsonReader, tag);
				break;
				}
			}
		// check up that all the required elements are present
		}


	}

	/// <summary>
	/// </summary>
public partial class LogEntry : ShellResult {
        /// <summary>
        /// </summary>

	public virtual string						Key  {get; set;}
	bool								__Length = false;
	private int						_Length;
        /// <summary>
        /// </summary>

	public virtual int						Length {
		get => _Length;
		set {_Length = value; __Length = true; }
		}
        /// <summary>
        /// </summary>

	public virtual byte[]						Digest  {get; set;}
        /// <summary>
        /// </summary>

	public virtual DateTime?						Recorded  {get; set;}
	bool								__Encrypted = false;
	private bool						_Encrypted;
        /// <summary>
        /// </summary>

	public virtual bool						Encrypted {
		get => _Encrypted;
		set {_Encrypted = value; __Encrypted = true; }
		}
	bool								__Signed = false;
	private bool						_Signed;
        /// <summary>
        /// </summary>

	public virtual bool						Signed {
		get => _Signed;
		set {_Signed = value; __Signed = true; }
		}
	bool								__KeyExchange = false;
	private bool						_KeyExchange;
        /// <summary>
        /// </summary>

	public virtual bool						KeyExchange {
		get => _KeyExchange;
		set {_KeyExchange = value; __KeyExchange = true; }
		}
		
	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "LogEntry";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new LogEntry();


    /// <summary>
    /// Serialize this object to the specified output stream.
    /// </summary>
    /// <param name="writer">Output stream</param>
    /// <param name="wrap">If true, output is wrapped with object
    /// start and end sequences '{ ... }'.</param>
    /// <param name="first">If true, item is the first entry in a list.</param>
	public override void Serialize (Writer writer, bool wrap, ref bool first) =>
		SerializeX (writer, wrap, ref first);


    /// <summary>
    /// Serialize this object to the specified output stream.
    /// Unlike the Serlialize() method, this method is not inherited from the
    /// parent class allowing a specific version of the method to be called.
    /// </summary>
    /// <param name="_writer">Output stream</param>
    /// <param name="_wrap">If true, output is wrapped with object
    /// start and end sequences '{ ... }'.</param>
    /// <param name="_first">If true, item is the first entry in a list.</param>
	public new void SerializeX (Writer _writer, bool _wrap, ref bool _first) {
		PreEncode();
		if (_wrap) {
			_writer.WriteObjectStart ();
			}
		if (Key != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Key", 1);
				_writer.WriteString (Key);
			}
		if (__Length){
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Length", 1);
				_writer.WriteInteger32 (Length);
			}
		if (Digest != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Digest", 1);
				_writer.WriteBinary (Digest);
			}
		if (Recorded != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Recorded", 1);
				_writer.WriteDateTime (Recorded);
			}
		if (__Encrypted){
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Encrypted", 1);
				_writer.WriteBoolean (Encrypted);
			}
		if (__Signed){
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Signed", 1);
				_writer.WriteBoolean (Signed);
			}
		if (__KeyExchange){
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("KeyExchange", 1);
				_writer.WriteBoolean (KeyExchange);
			}
		if (_wrap) {
			_writer.WriteObjectEnd ();
			}
		}

    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new LogEntry FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as LogEntry;
			}
		var Result = new LogEntry ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			case "Key" : {
				Key = jsonReader.ReadString ();
				break;
				}
			case "Length" : {
				Length = jsonReader.ReadInteger32 ();
				break;
				}
			case "Digest" : {
				Digest = jsonReader.ReadBinary ();
				break;
				}
			case "Recorded" : {
				Recorded = jsonReader.ReadDateTime ();
				break;
				}
			case "Encrypted" : {
				Encrypted = jsonReader.ReadBoolean ();
				break;
				}
			case "Signed" : {
				Signed = jsonReader.ReadBoolean ();
				break;
				}
			case "KeyExchange" : {
				KeyExchange = jsonReader.ReadBoolean ();
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
public partial class ResultEntry : Result {
        /// <summary>
        /// </summary>

	public virtual CatalogedEntry						CatalogEntry  {get; set;}
		
	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "ResultEntry";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ResultEntry();


    /// <summary>
    /// Serialize this object to the specified output stream.
    /// </summary>
    /// <param name="writer">Output stream</param>
    /// <param name="wrap">If true, output is wrapped with object
    /// start and end sequences '{ ... }'.</param>
    /// <param name="first">If true, item is the first entry in a list.</param>
	public override void Serialize (Writer writer, bool wrap, ref bool first) =>
		SerializeX (writer, wrap, ref first);


    /// <summary>
    /// Serialize this object to the specified output stream.
    /// Unlike the Serlialize() method, this method is not inherited from the
    /// parent class allowing a specific version of the method to be called.
    /// </summary>
    /// <param name="_writer">Output stream</param>
    /// <param name="_wrap">If true, output is wrapped with object
    /// start and end sequences '{ ... }'.</param>
    /// <param name="_first">If true, item is the first entry in a list.</param>
	public new void SerializeX (Writer _writer, bool _wrap, ref bool _first) {
		PreEncode();
		if (_wrap) {
			_writer.WriteObjectStart ();
			}
		((Result)this).SerializeX(_writer, false, ref _first);
		if (CatalogEntry != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("CatalogEntry", 1);
				// expand this to a tagged structure
				//CatalogEntry.Serialize (_writer, false);
				{
					_writer.WriteObjectStart();
					_writer.WriteToken(CatalogEntry._Tag, 1);
					bool firstinner = true;
					CatalogEntry.Serialize (_writer, true, ref firstinner);
					_writer.WriteObjectEnd();
					}
			}
		if (_wrap) {
			_writer.WriteObjectEnd ();
			}
		}

    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ResultEntry FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ResultEntry;
			}
		var Result = new ResultEntry ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			case "CatalogEntry" : {
				CatalogEntry = CatalogedEntry.FromJson (jsonReader, true) ;  // A tagged structure
				break;
				}
			default : {
				base.DeserializeToken(jsonReader, tag);
				break;
				}
			}
		// check up that all the required elements are present
		}


	}

	/// <summary>
	/// </summary>
public partial class ResultEntrySent : Result {
        /// <summary>
        /// </summary>

	public virtual CatalogedEntry						CatalogEntry  {get; set;}
        /// <summary>
        /// </summary>

	public virtual Message						Message  {get; set;}
		
	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "ResultEntrySent";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ResultEntrySent();


    /// <summary>
    /// Serialize this object to the specified output stream.
    /// </summary>
    /// <param name="writer">Output stream</param>
    /// <param name="wrap">If true, output is wrapped with object
    /// start and end sequences '{ ... }'.</param>
    /// <param name="first">If true, item is the first entry in a list.</param>
	public override void Serialize (Writer writer, bool wrap, ref bool first) =>
		SerializeX (writer, wrap, ref first);


    /// <summary>
    /// Serialize this object to the specified output stream.
    /// Unlike the Serlialize() method, this method is not inherited from the
    /// parent class allowing a specific version of the method to be called.
    /// </summary>
    /// <param name="_writer">Output stream</param>
    /// <param name="_wrap">If true, output is wrapped with object
    /// start and end sequences '{ ... }'.</param>
    /// <param name="_first">If true, item is the first entry in a list.</param>
	public new void SerializeX (Writer _writer, bool _wrap, ref bool _first) {
		PreEncode();
		if (_wrap) {
			_writer.WriteObjectStart ();
			}
		((Result)this).SerializeX(_writer, false, ref _first);
		if (CatalogEntry != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("CatalogEntry", 1);
				// expand this to a tagged structure
				//CatalogEntry.Serialize (_writer, false);
				{
					_writer.WriteObjectStart();
					_writer.WriteToken(CatalogEntry._Tag, 1);
					bool firstinner = true;
					CatalogEntry.Serialize (_writer, true, ref firstinner);
					_writer.WriteObjectEnd();
					}
			}
		if (Message != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Message", 1);
				Message.Serialize (_writer, false);
			}
		if (_wrap) {
			_writer.WriteObjectEnd ();
			}
		}

    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ResultEntrySent FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ResultEntrySent;
			}
		var Result = new ResultEntrySent ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			case "CatalogEntry" : {
				CatalogEntry = CatalogedEntry.FromJson (jsonReader, true) ;  // A tagged structure
				break;
				}
			case "Message" : {
				// An untagged structure
				Message = new Message ();
				Message.Deserialize (jsonReader);
 
				break;
				}
			default : {
				base.DeserializeToken(jsonReader, tag);
				break;
				}
			}
		// check up that all the required elements are present
		}


	}

	/// <summary>
	/// </summary>
public partial class ResultMail : ResultEntry {
		
	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "ResultMail";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ResultMail();


    /// <summary>
    /// Serialize this object to the specified output stream.
    /// </summary>
    /// <param name="writer">Output stream</param>
    /// <param name="wrap">If true, output is wrapped with object
    /// start and end sequences '{ ... }'.</param>
    /// <param name="first">If true, item is the first entry in a list.</param>
	public override void Serialize (Writer writer, bool wrap, ref bool first) =>
		SerializeX (writer, wrap, ref first);


    /// <summary>
    /// Serialize this object to the specified output stream.
    /// Unlike the Serlialize() method, this method is not inherited from the
    /// parent class allowing a specific version of the method to be called.
    /// </summary>
    /// <param name="_writer">Output stream</param>
    /// <param name="_wrap">If true, output is wrapped with object
    /// start and end sequences '{ ... }'.</param>
    /// <param name="_first">If true, item is the first entry in a list.</param>
	public new void SerializeX (Writer _writer, bool _wrap, ref bool _first) {
		PreEncode();
		if (_wrap) {
			_writer.WriteObjectStart ();
			}
		((ResultEntry)this).SerializeX(_writer, false, ref _first);
		if (_wrap) {
			_writer.WriteObjectEnd ();
			}
		}

    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ResultMail FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ResultMail;
			}
		var Result = new ResultMail ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			default : {
				base.DeserializeToken(jsonReader, tag);
				break;
				}
			}
		// check up that all the required elements are present
		}


	}

	/// <summary>
	/// </summary>
public partial class ResultSSH : ResultEntry {
		
	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "ResultSSH";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ResultSSH();


    /// <summary>
    /// Serialize this object to the specified output stream.
    /// </summary>
    /// <param name="writer">Output stream</param>
    /// <param name="wrap">If true, output is wrapped with object
    /// start and end sequences '{ ... }'.</param>
    /// <param name="first">If true, item is the first entry in a list.</param>
	public override void Serialize (Writer writer, bool wrap, ref bool first) =>
		SerializeX (writer, wrap, ref first);


    /// <summary>
    /// Serialize this object to the specified output stream.
    /// Unlike the Serlialize() method, this method is not inherited from the
    /// parent class allowing a specific version of the method to be called.
    /// </summary>
    /// <param name="_writer">Output stream</param>
    /// <param name="_wrap">If true, output is wrapped with object
    /// start and end sequences '{ ... }'.</param>
    /// <param name="_first">If true, item is the first entry in a list.</param>
	public new void SerializeX (Writer _writer, bool _wrap, ref bool _first) {
		PreEncode();
		if (_wrap) {
			_writer.WriteObjectStart ();
			}
		((ResultEntry)this).SerializeX(_writer, false, ref _first);
		if (_wrap) {
			_writer.WriteObjectEnd ();
			}
		}

    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ResultSSH FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ResultSSH;
			}
		var Result = new ResultSSH ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			default : {
				base.DeserializeToken(jsonReader, tag);
				break;
				}
			}
		// check up that all the required elements are present
		}


	}

	/// <summary>
	/// </summary>
public partial class ResultGroupCreate : ResultEntry {
		
	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "ResultGroupCreate";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ResultGroupCreate();


    /// <summary>
    /// Serialize this object to the specified output stream.
    /// </summary>
    /// <param name="writer">Output stream</param>
    /// <param name="wrap">If true, output is wrapped with object
    /// start and end sequences '{ ... }'.</param>
    /// <param name="first">If true, item is the first entry in a list.</param>
	public override void Serialize (Writer writer, bool wrap, ref bool first) =>
		SerializeX (writer, wrap, ref first);


    /// <summary>
    /// Serialize this object to the specified output stream.
    /// Unlike the Serlialize() method, this method is not inherited from the
    /// parent class allowing a specific version of the method to be called.
    /// </summary>
    /// <param name="_writer">Output stream</param>
    /// <param name="_wrap">If true, output is wrapped with object
    /// start and end sequences '{ ... }'.</param>
    /// <param name="_first">If true, item is the first entry in a list.</param>
	public new void SerializeX (Writer _writer, bool _wrap, ref bool _first) {
		PreEncode();
		if (_wrap) {
			_writer.WriteObjectStart ();
			}
		((ResultEntry)this).SerializeX(_writer, false, ref _first);
		if (_wrap) {
			_writer.WriteObjectEnd ();
			}
		}

    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ResultGroupCreate FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ResultGroupCreate;
			}
		var Result = new ResultGroupCreate ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			default : {
				base.DeserializeToken(jsonReader, tag);
				break;
				}
			}
		// check up that all the required elements are present
		}


	}

	/// <summary>
	/// </summary>
public partial class ResultSent : Result {
        /// <summary>
        /// </summary>

	public virtual Message						Message  {get; set;}
        /// <summary>
        /// </summary>

	public virtual string						Status  {get; set;}
		
	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "ResultSent";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ResultSent();


    /// <summary>
    /// Serialize this object to the specified output stream.
    /// </summary>
    /// <param name="writer">Output stream</param>
    /// <param name="wrap">If true, output is wrapped with object
    /// start and end sequences '{ ... }'.</param>
    /// <param name="first">If true, item is the first entry in a list.</param>
	public override void Serialize (Writer writer, bool wrap, ref bool first) =>
		SerializeX (writer, wrap, ref first);


    /// <summary>
    /// Serialize this object to the specified output stream.
    /// Unlike the Serlialize() method, this method is not inherited from the
    /// parent class allowing a specific version of the method to be called.
    /// </summary>
    /// <param name="_writer">Output stream</param>
    /// <param name="_wrap">If true, output is wrapped with object
    /// start and end sequences '{ ... }'.</param>
    /// <param name="_first">If true, item is the first entry in a list.</param>
	public new void SerializeX (Writer _writer, bool _wrap, ref bool _first) {
		PreEncode();
		if (_wrap) {
			_writer.WriteObjectStart ();
			}
		((Result)this).SerializeX(_writer, false, ref _first);
		if (Message != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Message", 1);
				Message.Serialize (_writer, false);
			}
		if (Status != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Status", 1);
				_writer.WriteString (Status);
			}
		if (_wrap) {
			_writer.WriteObjectEnd ();
			}
		}

    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ResultSent FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ResultSent;
			}
		var Result = new ResultSent ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			case "Message" : {
				// An untagged structure
				Message = new Message ();
				Message.Deserialize (jsonReader);
 
				break;
				}
			case "Status" : {
				Status = jsonReader.ReadString ();
				break;
				}
			default : {
				base.DeserializeToken(jsonReader, tag);
				break;
				}
			}
		// check up that all the required elements are present
		}


	}

	/// <summary>
	/// </summary>
public partial class ResultPending : Result {
        /// <summary>
        /// </summary>

	public virtual List<Message>				Messages  {get; set;}
		
	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "ResultPending";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ResultPending();


    /// <summary>
    /// Serialize this object to the specified output stream.
    /// </summary>
    /// <param name="writer">Output stream</param>
    /// <param name="wrap">If true, output is wrapped with object
    /// start and end sequences '{ ... }'.</param>
    /// <param name="first">If true, item is the first entry in a list.</param>
	public override void Serialize (Writer writer, bool wrap, ref bool first) =>
		SerializeX (writer, wrap, ref first);


    /// <summary>
    /// Serialize this object to the specified output stream.
    /// Unlike the Serlialize() method, this method is not inherited from the
    /// parent class allowing a specific version of the method to be called.
    /// </summary>
    /// <param name="_writer">Output stream</param>
    /// <param name="_wrap">If true, output is wrapped with object
    /// start and end sequences '{ ... }'.</param>
    /// <param name="_first">If true, item is the first entry in a list.</param>
	public new void SerializeX (Writer _writer, bool _wrap, ref bool _first) {
		PreEncode();
		if (_wrap) {
			_writer.WriteObjectStart ();
			}
		((Result)this).SerializeX(_writer, false, ref _first);
		if (Messages != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Messages", 1);
			_writer.WriteArrayStart ();
			bool _firstarray = true;
			foreach (var _index in Messages) {
				_writer.WriteArraySeparator (ref _firstarray);
				// This is an untagged structure. Cannot inherit.
                //_writer.WriteObjectStart();
                //_writer.WriteToken(_index._Tag, 1);
				bool firstinner = true;
				_index.Serialize (_writer, true, ref firstinner);
                //_writer.WriteObjectEnd();
				}
			_writer.WriteArrayEnd ();
			}

		if (_wrap) {
			_writer.WriteObjectEnd ();
			}
		}

    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ResultPending FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ResultPending;
			}
		var Result = new ResultPending ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			case "Messages" : {
				// Have a sequence of values
				bool _Going = jsonReader.StartArray ();
				Messages = new List <Message> ();
				while (_Going) {
					// an untagged structure.
					var _Item = new  Message ();
					_Item.Deserialize (jsonReader);
					// var _Item = new Message (jsonReader);
					Messages.Add (_Item);
					_Going = jsonReader.NextArray ();
					}
				break;
				}
			default : {
				base.DeserializeToken(jsonReader, tag);
				break;
				}
			}
		// check up that all the required elements are present
		}


	}

	/// <summary>
	/// </summary>
public partial class ResultAuthorize : Result {
        /// <summary>
        /// </summary>

	public virtual List<ProcessResult>				Messages  {get; set;}
		
	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "ResultAuthorize";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ResultAuthorize();


    /// <summary>
    /// Serialize this object to the specified output stream.
    /// </summary>
    /// <param name="writer">Output stream</param>
    /// <param name="wrap">If true, output is wrapped with object
    /// start and end sequences '{ ... }'.</param>
    /// <param name="first">If true, item is the first entry in a list.</param>
	public override void Serialize (Writer writer, bool wrap, ref bool first) =>
		SerializeX (writer, wrap, ref first);


    /// <summary>
    /// Serialize this object to the specified output stream.
    /// Unlike the Serlialize() method, this method is not inherited from the
    /// parent class allowing a specific version of the method to be called.
    /// </summary>
    /// <param name="_writer">Output stream</param>
    /// <param name="_wrap">If true, output is wrapped with object
    /// start and end sequences '{ ... }'.</param>
    /// <param name="_first">If true, item is the first entry in a list.</param>
	public new void SerializeX (Writer _writer, bool _wrap, ref bool _first) {
		PreEncode();
		if (_wrap) {
			_writer.WriteObjectStart ();
			}
		((Result)this).SerializeX(_writer, false, ref _first);
		if (Messages != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Messages", 1);
			_writer.WriteArrayStart ();
			bool _firstarray = true;
			foreach (var _index in Messages) {
				_writer.WriteArraySeparator (ref _firstarray);
                _writer.WriteObjectStart();
                _writer.WriteToken(_index._Tag, 1);
				bool firstinner = true;
				_index.Serialize (_writer, true, ref firstinner);
                _writer.WriteObjectEnd();
				}
			_writer.WriteArrayEnd ();
			}

		if (_wrap) {
			_writer.WriteObjectEnd ();
			}
		}

    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ResultAuthorize FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ResultAuthorize;
			}
		var Result = new ResultAuthorize ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			case "Messages" : {
				// Have a sequence of values
				bool _Going = jsonReader.StartArray ();
				Messages = new List <ProcessResult> ();
				while (_Going) {
					var _Item = ProcessResult.FromJson (jsonReader, true); // a tagged structure
					Messages.Add (_Item);
					_Going = jsonReader.NextArray ();
					}
				break;
				}
			default : {
				base.DeserializeToken(jsonReader, tag);
				break;
				}
			}
		// check up that all the required elements are present
		}


	}

	/// <summary>
	/// </summary>
public partial class ResultProcess : Result {
        /// <summary>
        /// </summary>

	public virtual Message						ProcessResult  {get; set;}
		
	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "ResultProcess";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ResultProcess();


    /// <summary>
    /// Serialize this object to the specified output stream.
    /// </summary>
    /// <param name="writer">Output stream</param>
    /// <param name="wrap">If true, output is wrapped with object
    /// start and end sequences '{ ... }'.</param>
    /// <param name="first">If true, item is the first entry in a list.</param>
	public override void Serialize (Writer writer, bool wrap, ref bool first) =>
		SerializeX (writer, wrap, ref first);


    /// <summary>
    /// Serialize this object to the specified output stream.
    /// Unlike the Serlialize() method, this method is not inherited from the
    /// parent class allowing a specific version of the method to be called.
    /// </summary>
    /// <param name="_writer">Output stream</param>
    /// <param name="_wrap">If true, output is wrapped with object
    /// start and end sequences '{ ... }'.</param>
    /// <param name="_first">If true, item is the first entry in a list.</param>
	public new void SerializeX (Writer _writer, bool _wrap, ref bool _first) {
		PreEncode();
		if (_wrap) {
			_writer.WriteObjectStart ();
			}
		((Result)this).SerializeX(_writer, false, ref _first);
		if (ProcessResult != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("ProcessResult", 1);
				ProcessResult.Serialize (_writer, false);
			}
		if (_wrap) {
			_writer.WriteObjectEnd ();
			}
		}

    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ResultProcess FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ResultProcess;
			}
		var Result = new ResultProcess ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			case "ProcessResult" : {
				// An untagged structure
				ProcessResult = new Message ();
				ProcessResult.Deserialize (jsonReader);
 
				break;
				}
			default : {
				base.DeserializeToken(jsonReader, tag);
				break;
				}
			}
		// check up that all the required elements are present
		}


	}

	/// <summary>
	/// </summary>
public partial class ResultConnect : Result {
        /// <summary>
        /// </summary>

	public virtual Profile						Profile  {get; set;}
        /// <summary>
        /// </summary>

	public virtual CatalogedMachine						CatalogedMachine  {get; set;}
        /// <summary>
        /// </summary>

	public virtual ActivationDevice						ActivationDevice  {get; set;}
        /// <summary>
        /// </summary>

	public virtual ActivationAccount						ActivationAccount  {get; set;}
        /// <summary>
        /// </summary>

	public virtual RequestConnection						RequestConnection  {get; set;}
        /// <summary>
        /// </summary>

	public virtual AcknowledgeConnection						AcknowledgeConnection  {get; set;}
        /// <summary>
        /// </summary>

	public virtual RespondConnection						RespondConnection  {get; set;}
		
	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "ResultConnect";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ResultConnect();


    /// <summary>
    /// Serialize this object to the specified output stream.
    /// </summary>
    /// <param name="writer">Output stream</param>
    /// <param name="wrap">If true, output is wrapped with object
    /// start and end sequences '{ ... }'.</param>
    /// <param name="first">If true, item is the first entry in a list.</param>
	public override void Serialize (Writer writer, bool wrap, ref bool first) =>
		SerializeX (writer, wrap, ref first);


    /// <summary>
    /// Serialize this object to the specified output stream.
    /// Unlike the Serlialize() method, this method is not inherited from the
    /// parent class allowing a specific version of the method to be called.
    /// </summary>
    /// <param name="_writer">Output stream</param>
    /// <param name="_wrap">If true, output is wrapped with object
    /// start and end sequences '{ ... }'.</param>
    /// <param name="_first">If true, item is the first entry in a list.</param>
	public new void SerializeX (Writer _writer, bool _wrap, ref bool _first) {
		PreEncode();
		if (_wrap) {
			_writer.WriteObjectStart ();
			}
		((Result)this).SerializeX(_writer, false, ref _first);
		if (Profile != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Profile", 1);
				// expand this to a tagged structure
				//Profile.Serialize (_writer, false);
				{
					_writer.WriteObjectStart();
					_writer.WriteToken(Profile._Tag, 1);
					bool firstinner = true;
					Profile.Serialize (_writer, true, ref firstinner);
					_writer.WriteObjectEnd();
					}
			}
		if (CatalogedMachine != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("CatalogedMachine", 1);
				CatalogedMachine.Serialize (_writer, false);
			}
		if (ActivationDevice != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("ActivationDevice", 1);
				ActivationDevice.Serialize (_writer, false);
			}
		if (ActivationAccount != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("ActivationAccount", 1);
				ActivationAccount.Serialize (_writer, false);
			}
		if (RequestConnection != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("RequestConnection", 1);
				RequestConnection.Serialize (_writer, false);
			}
		if (AcknowledgeConnection != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("AcknowledgeConnection", 1);
				AcknowledgeConnection.Serialize (_writer, false);
			}
		if (RespondConnection != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("RespondConnection", 1);
				RespondConnection.Serialize (_writer, false);
			}
		if (_wrap) {
			_writer.WriteObjectEnd ();
			}
		}

    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ResultConnect FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ResultConnect;
			}
		var Result = new ResultConnect ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			case "Profile" : {
				Profile = Profile.FromJson (jsonReader, true) ;  // A tagged structure
				break;
				}
			case "CatalogedMachine" : {
				// An untagged structure
				CatalogedMachine = new CatalogedMachine ();
				CatalogedMachine.Deserialize (jsonReader);
 
				break;
				}
			case "ActivationDevice" : {
				// An untagged structure
				ActivationDevice = new ActivationDevice ();
				ActivationDevice.Deserialize (jsonReader);
 
				break;
				}
			case "ActivationAccount" : {
				// An untagged structure
				ActivationAccount = new ActivationAccount ();
				ActivationAccount.Deserialize (jsonReader);
 
				break;
				}
			case "RequestConnection" : {
				// An untagged structure
				RequestConnection = new RequestConnection ();
				RequestConnection.Deserialize (jsonReader);
 
				break;
				}
			case "AcknowledgeConnection" : {
				// An untagged structure
				AcknowledgeConnection = new AcknowledgeConnection ();
				AcknowledgeConnection.Deserialize (jsonReader);
 
				break;
				}
			case "RespondConnection" : {
				// An untagged structure
				RespondConnection = new RespondConnection ();
				RespondConnection.Deserialize (jsonReader);
 
				break;
				}
			default : {
				base.DeserializeToken(jsonReader, tag);
				break;
				}
			}
		// check up that all the required elements are present
		}


	}

	/// <summary>
	/// </summary>
public partial class ResultTransactionRequest : Result {
        /// <summary>
        /// </summary>

	public virtual string						Identifier  {get; set;}
		
	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "ResultTransactionRequest";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ResultTransactionRequest();


    /// <summary>
    /// Serialize this object to the specified output stream.
    /// </summary>
    /// <param name="writer">Output stream</param>
    /// <param name="wrap">If true, output is wrapped with object
    /// start and end sequences '{ ... }'.</param>
    /// <param name="first">If true, item is the first entry in a list.</param>
	public override void Serialize (Writer writer, bool wrap, ref bool first) =>
		SerializeX (writer, wrap, ref first);


    /// <summary>
    /// Serialize this object to the specified output stream.
    /// Unlike the Serlialize() method, this method is not inherited from the
    /// parent class allowing a specific version of the method to be called.
    /// </summary>
    /// <param name="_writer">Output stream</param>
    /// <param name="_wrap">If true, output is wrapped with object
    /// start and end sequences '{ ... }'.</param>
    /// <param name="_first">If true, item is the first entry in a list.</param>
	public new void SerializeX (Writer _writer, bool _wrap, ref bool _first) {
		PreEncode();
		if (_wrap) {
			_writer.WriteObjectStart ();
			}
		((Result)this).SerializeX(_writer, false, ref _first);
		if (Identifier != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Identifier", 1);
				_writer.WriteString (Identifier);
			}
		if (_wrap) {
			_writer.WriteObjectEnd ();
			}
		}

    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ResultTransactionRequest FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ResultTransactionRequest;
			}
		var Result = new ResultTransactionRequest ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			case "Identifier" : {
				Identifier = jsonReader.ReadString ();
				break;
				}
			default : {
				base.DeserializeToken(jsonReader, tag);
				break;
				}
			}
		// check up that all the required elements are present
		}


	}

	/// <summary>
	/// </summary>
public partial class ResultReceived : Result {
        /// <summary>
        /// </summary>

	public virtual string						Status  {get; set;}
        /// <summary>
        /// </summary>

	public virtual Message						Message  {get; set;}
		
	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "ResultReceived";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ResultReceived();


    /// <summary>
    /// Serialize this object to the specified output stream.
    /// </summary>
    /// <param name="writer">Output stream</param>
    /// <param name="wrap">If true, output is wrapped with object
    /// start and end sequences '{ ... }'.</param>
    /// <param name="first">If true, item is the first entry in a list.</param>
	public override void Serialize (Writer writer, bool wrap, ref bool first) =>
		SerializeX (writer, wrap, ref first);


    /// <summary>
    /// Serialize this object to the specified output stream.
    /// Unlike the Serlialize() method, this method is not inherited from the
    /// parent class allowing a specific version of the method to be called.
    /// </summary>
    /// <param name="_writer">Output stream</param>
    /// <param name="_wrap">If true, output is wrapped with object
    /// start and end sequences '{ ... }'.</param>
    /// <param name="_first">If true, item is the first entry in a list.</param>
	public new void SerializeX (Writer _writer, bool _wrap, ref bool _first) {
		PreEncode();
		if (_wrap) {
			_writer.WriteObjectStart ();
			}
		((Result)this).SerializeX(_writer, false, ref _first);
		if (Status != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Status", 1);
				_writer.WriteString (Status);
			}
		if (Message != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Message", 1);
				Message.Serialize (_writer, false);
			}
		if (_wrap) {
			_writer.WriteObjectEnd ();
			}
		}

    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ResultReceived FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ResultReceived;
			}
		var Result = new ResultReceived ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			case "Status" : {
				Status = jsonReader.ReadString ();
				break;
				}
			case "Message" : {
				// An untagged structure
				Message = new Message ();
				Message.Deserialize (jsonReader);
 
				break;
				}
			default : {
				base.DeserializeToken(jsonReader, tag);
				break;
				}
			}
		// check up that all the required elements are present
		}


	}

	/// <summary>
	/// </summary>
public partial class ResultApplication : Result {
        /// <summary>
        /// </summary>

	public virtual CatalogedApplication						Application  {get; set;}
		
	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "ResultApplication";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ResultApplication();


    /// <summary>
    /// Serialize this object to the specified output stream.
    /// </summary>
    /// <param name="writer">Output stream</param>
    /// <param name="wrap">If true, output is wrapped with object
    /// start and end sequences '{ ... }'.</param>
    /// <param name="first">If true, item is the first entry in a list.</param>
	public override void Serialize (Writer writer, bool wrap, ref bool first) =>
		SerializeX (writer, wrap, ref first);


    /// <summary>
    /// Serialize this object to the specified output stream.
    /// Unlike the Serlialize() method, this method is not inherited from the
    /// parent class allowing a specific version of the method to be called.
    /// </summary>
    /// <param name="_writer">Output stream</param>
    /// <param name="_wrap">If true, output is wrapped with object
    /// start and end sequences '{ ... }'.</param>
    /// <param name="_first">If true, item is the first entry in a list.</param>
	public new void SerializeX (Writer _writer, bool _wrap, ref bool _first) {
		PreEncode();
		if (_wrap) {
			_writer.WriteObjectStart ();
			}
		((Result)this).SerializeX(_writer, false, ref _first);
		if (Application != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Application", 1);
				// expand this to a tagged structure
				//Application.Serialize (_writer, false);
				{
					_writer.WriteObjectStart();
					_writer.WriteToken(Application._Tag, 1);
					bool firstinner = true;
					Application.Serialize (_writer, true, ref firstinner);
					_writer.WriteObjectEnd();
					}
			}
		if (_wrap) {
			_writer.WriteObjectEnd ();
			}
		}

    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ResultApplication FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ResultApplication;
			}
		var Result = new ResultApplication ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			case "Application" : {
				Application = CatalogedApplication.FromJson (jsonReader, true) ;  // A tagged structure
				break;
				}
			default : {
				base.DeserializeToken(jsonReader, tag);
				break;
				}
			}
		// check up that all the required elements are present
		}


	}

	/// <summary>
	/// </summary>
public partial class ResultApplicationList : Result {
        /// <summary>
        /// </summary>

	public virtual List<CatalogedApplication>				Applications  {get; set;}
		
	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "ResultApplicationList";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ResultApplicationList();


    /// <summary>
    /// Serialize this object to the specified output stream.
    /// </summary>
    /// <param name="writer">Output stream</param>
    /// <param name="wrap">If true, output is wrapped with object
    /// start and end sequences '{ ... }'.</param>
    /// <param name="first">If true, item is the first entry in a list.</param>
	public override void Serialize (Writer writer, bool wrap, ref bool first) =>
		SerializeX (writer, wrap, ref first);


    /// <summary>
    /// Serialize this object to the specified output stream.
    /// Unlike the Serlialize() method, this method is not inherited from the
    /// parent class allowing a specific version of the method to be called.
    /// </summary>
    /// <param name="_writer">Output stream</param>
    /// <param name="_wrap">If true, output is wrapped with object
    /// start and end sequences '{ ... }'.</param>
    /// <param name="_first">If true, item is the first entry in a list.</param>
	public new void SerializeX (Writer _writer, bool _wrap, ref bool _first) {
		PreEncode();
		if (_wrap) {
			_writer.WriteObjectStart ();
			}
		((Result)this).SerializeX(_writer, false, ref _first);
		if (Applications != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Applications", 1);
			_writer.WriteArrayStart ();
			bool _firstarray = true;
			foreach (var _index in Applications) {
				_writer.WriteArraySeparator (ref _firstarray);
                _writer.WriteObjectStart();
                _writer.WriteToken(_index._Tag, 1);
				bool firstinner = true;
				_index.Serialize (_writer, true, ref firstinner);
                _writer.WriteObjectEnd();
				}
			_writer.WriteArrayEnd ();
			}

		if (_wrap) {
			_writer.WriteObjectEnd ();
			}
		}

    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ResultApplicationList FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ResultApplicationList;
			}
		var Result = new ResultApplicationList ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			case "Applications" : {
				// Have a sequence of values
				bool _Going = jsonReader.StartArray ();
				Applications = new List <CatalogedApplication> ();
				while (_Going) {
					var _Item = CatalogedApplication.FromJson (jsonReader, true); // a tagged structure
					Applications.Add (_Item);
					_Going = jsonReader.NextArray ();
					}
				break;
				}
			default : {
				base.DeserializeToken(jsonReader, tag);
				break;
				}
			}
		// check up that all the required elements are present
		}


	}



