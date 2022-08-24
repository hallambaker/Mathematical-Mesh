
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
//  This file was automatically generated at 24-Aug-22 2:24:57 PM
//   
//  Changes to this file may be overwritten without warning
//  
//  Generator:  protogen version 3.0.0.1015
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
using Goedel.Utilities;

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
public abstract partial class MeshmanShellResult : global::Goedel.Protocol.JsonObject {

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag =>__Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "MeshmanShellResult";

	/// <summary>
    /// Dictionary mapping tags to factory methods
    /// </summary>
	public static Dictionary<string, JsonFactoryDelegate> _TagDictionary=> _tagDictionary;
	static Dictionary<string, JsonFactoryDelegate> _tagDictionary = 
			new () {

	    {"Result", Result._Factory},
	    {"ResultAbout", ResultAbout._Factory},
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
	///
	/// Placeholder class to allow insertion of application specific properties.
	/// </summary>
public partial class Result : ShellResult {


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {

			default: {
				base.Setter(tag, value);
				break;
				}
			}
		}

    ///<inheritdoc/>
    public override TokenValue Getter(
            string tag) {
        switch (tag) {

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, ShellResult._StaticAllProperties);


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;



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


	}

	/// <summary>
	/// </summary>
public partial class ResultAbout : Result {
        /// <summary>
        /// </summary>

	public virtual string						DirectoryKeys  {get; set;}
        /// <summary>
        /// </summary>

	public virtual string						DirectoryMesh  {get; set;}
        /// <summary>
        /// </summary>

	public virtual string						AssemblyTitle  {get; set;}
        /// <summary>
        /// </summary>

	public virtual string						AssemblyDescription  {get; set;}
        /// <summary>
        /// </summary>

	public virtual string						AssemblyCopyright  {get; set;}
        /// <summary>
        /// </summary>

	public virtual string						AssemblyCompany  {get; set;}
        /// <summary>
        /// </summary>

	public virtual string						AssemblyVersion  {get; set;}
        /// <summary>
        /// </summary>

	public virtual string						Build  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "DirectoryKeys" : {
				if (value is TokenValueString vvalue) {
					DirectoryKeys = vvalue.Value;
					}
				break;
				}
			case "DirectoryMesh" : {
				if (value is TokenValueString vvalue) {
					DirectoryMesh = vvalue.Value;
					}
				break;
				}
			case "AssemblyTitle" : {
				if (value is TokenValueString vvalue) {
					AssemblyTitle = vvalue.Value;
					}
				break;
				}
			case "AssemblyDescription" : {
				if (value is TokenValueString vvalue) {
					AssemblyDescription = vvalue.Value;
					}
				break;
				}
			case "AssemblyCopyright" : {
				if (value is TokenValueString vvalue) {
					AssemblyCopyright = vvalue.Value;
					}
				break;
				}
			case "AssemblyCompany" : {
				if (value is TokenValueString vvalue) {
					AssemblyCompany = vvalue.Value;
					}
				break;
				}
			case "AssemblyVersion" : {
				if (value is TokenValueString vvalue) {
					AssemblyVersion = vvalue.Value;
					}
				break;
				}
			case "Build" : {
				if (value is TokenValueString vvalue) {
					Build = vvalue.Value;
					}
				break;
				}

			default: {
				base.Setter(tag, value);
				break;
				}
			}
		}

    ///<inheritdoc/>
    public override TokenValue Getter(
            string tag) {
        switch (tag) {
			case "DirectoryKeys" : {
				return new TokenValueString (DirectoryKeys);
				}
			case "DirectoryMesh" : {
				return new TokenValueString (DirectoryMesh);
				}
			case "AssemblyTitle" : {
				return new TokenValueString (AssemblyTitle);
				}
			case "AssemblyDescription" : {
				return new TokenValueString (AssemblyDescription);
				}
			case "AssemblyCopyright" : {
				return new TokenValueString (AssemblyCopyright);
				}
			case "AssemblyCompany" : {
				return new TokenValueString (AssemblyCompany);
				}
			case "AssemblyVersion" : {
				return new TokenValueString (AssemblyVersion);
				}
			case "Build" : {
				return new TokenValueString (Build);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "DirectoryKeys", new Property (typeof(TokenValueString), false)} ,
			{ "DirectoryMesh", new Property (typeof(TokenValueString), false)} ,
			{ "AssemblyTitle", new Property (typeof(TokenValueString), false)} ,
			{ "AssemblyDescription", new Property (typeof(TokenValueString), false)} ,
			{ "AssemblyCopyright", new Property (typeof(TokenValueString), false)} ,
			{ "AssemblyCompany", new Property (typeof(TokenValueString), false)} ,
			{ "AssemblyVersion", new Property (typeof(TokenValueString), false)} ,
			{ "Build", new Property (typeof(TokenValueString), false)} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, Result._StaticAllProperties);


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;



	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "ResultAbout";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ResultAbout();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ResultAbout FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ResultAbout;
			}
		var Result = new ResultAbout ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
public partial class ResultFail : Result {


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {

			default: {
				base.Setter(tag, value);
				break;
				}
			}
		}

    ///<inheritdoc/>
    public override TokenValue Getter(
            string tag) {
        switch (tag) {

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, Result._StaticAllProperties);


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;



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


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "Key" : {
				if (value is TokenValueString vvalue) {
					Key = vvalue.Value;
					}
				break;
				}
			case "Identifier" : {
				if (value is TokenValueString vvalue) {
					Identifier = vvalue.Value;
					}
				break;
				}
			case "Shares" : {
				if (value is TokenValueListString vvalue) {
					Shares = vvalue.Value;
					}
				break;
				}

			default: {
				base.Setter(tag, value);
				break;
				}
			}
		}

    ///<inheritdoc/>
    public override TokenValue Getter(
            string tag) {
        switch (tag) {
			case "Key" : {
				return new TokenValueString (Key);
				}
			case "Identifier" : {
				return new TokenValueString (Identifier);
				}
			case "Shares" : {
				return new TokenValueListString (Shares);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Key", new Property (typeof(TokenValueString), false)} ,
			{ "Identifier", new Property (typeof(TokenValueString), false)} ,
			{ "Shares", new Property (typeof(TokenValueListString), true)} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, Result._StaticAllProperties);


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;



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
        /// <summary>
        /// </summary>

	public virtual bool?						Verified  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "Digest" : {
				if (value is TokenValueString vvalue) {
					Digest = vvalue.Value;
					}
				break;
				}
			case "Key" : {
				if (value is TokenValueString vvalue) {
					Key = vvalue.Value;
					}
				break;
				}
			case "Verified" : {
				if (value is TokenValueBoolean vvalue) {
					Verified = vvalue.Value;
					}
				break;
				}

			default: {
				base.Setter(tag, value);
				break;
				}
			}
		}

    ///<inheritdoc/>
    public override TokenValue Getter(
            string tag) {
        switch (tag) {
			case "Digest" : {
				return new TokenValueString (Digest);
				}
			case "Key" : {
				return new TokenValueString (Key);
				}
			case "Verified" : {
				return new TokenValueBoolean (Verified);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Digest", new Property (typeof(TokenValueString), false)} ,
			{ "Key", new Property (typeof(TokenValueString), false)} ,
			{ "Verified", new Property (typeof(TokenValueBoolean), false)} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, Result._StaticAllProperties);


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;



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


	}

	/// <summary>
	/// </summary>
public partial class ResultFile : Result {
        /// <summary>
        /// </summary>

	public virtual string						Filename  {get; set;}
        /// <summary>
        /// </summary>

	public virtual int?						TotalBytes  {get; set;}
        /// <summary>
        /// </summary>

	public virtual bool?						Verified  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "Filename" : {
				if (value is TokenValueString vvalue) {
					Filename = vvalue.Value;
					}
				break;
				}
			case "TotalBytes" : {
				if (value is TokenValueInteger32 vvalue) {
					TotalBytes = vvalue.Value;
					}
				break;
				}
			case "Verified" : {
				if (value is TokenValueBoolean vvalue) {
					Verified = vvalue.Value;
					}
				break;
				}

			default: {
				base.Setter(tag, value);
				break;
				}
			}
		}

    ///<inheritdoc/>
    public override TokenValue Getter(
            string tag) {
        switch (tag) {
			case "Filename" : {
				return new TokenValueString (Filename);
				}
			case "TotalBytes" : {
				return new TokenValueInteger32 (TotalBytes);
				}
			case "Verified" : {
				return new TokenValueBoolean (Verified);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Filename", new Property (typeof(TokenValueString), false)} ,
			{ "TotalBytes", new Property (typeof(TokenValueInteger32), false)} ,
			{ "Verified", new Property (typeof(TokenValueBoolean), false)} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, Result._StaticAllProperties);


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;



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


	}

	/// <summary>
	/// </summary>
public partial class ResultKeyFile : ResultFile {
        /// <summary>
        /// </summary>

	public virtual string						Udf  {get; set;}
        /// <summary>
        /// </summary>

	public virtual bool?						Private  {get; set;}
        /// <summary>
        /// </summary>

	public virtual string						Algorithm  {get; set;}
        /// <summary>
        /// </summary>

	public virtual string						Format  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "Udf" : {
				if (value is TokenValueString vvalue) {
					Udf = vvalue.Value;
					}
				break;
				}
			case "Private" : {
				if (value is TokenValueBoolean vvalue) {
					Private = vvalue.Value;
					}
				break;
				}
			case "Algorithm" : {
				if (value is TokenValueString vvalue) {
					Algorithm = vvalue.Value;
					}
				break;
				}
			case "Format" : {
				if (value is TokenValueString vvalue) {
					Format = vvalue.Value;
					}
				break;
				}

			default: {
				base.Setter(tag, value);
				break;
				}
			}
		}

    ///<inheritdoc/>
    public override TokenValue Getter(
            string tag) {
        switch (tag) {
			case "Udf" : {
				return new TokenValueString (Udf);
				}
			case "Private" : {
				return new TokenValueBoolean (Private);
				}
			case "Algorithm" : {
				return new TokenValueString (Algorithm);
				}
			case "Format" : {
				return new TokenValueString (Format);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Udf", new Property (typeof(TokenValueString), false)} ,
			{ "Private", new Property (typeof(TokenValueBoolean), false)} ,
			{ "Algorithm", new Property (typeof(TokenValueString), false)} ,
			{ "Format", new Property (typeof(TokenValueString), false)} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, ResultFile._StaticAllProperties);


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;



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


	}

	/// <summary>
	/// </summary>
public partial class ResultListLog : Result {
        /// <summary>
        /// </summary>

	public virtual string						Filename  {get; set;}
        /// <summary>
        /// </summary>

	public virtual int?						Count  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "Filename" : {
				if (value is TokenValueString vvalue) {
					Filename = vvalue.Value;
					}
				break;
				}
			case "Count" : {
				if (value is TokenValueInteger32 vvalue) {
					Count = vvalue.Value;
					}
				break;
				}

			default: {
				base.Setter(tag, value);
				break;
				}
			}
		}

    ///<inheritdoc/>
    public override TokenValue Getter(
            string tag) {
        switch (tag) {
			case "Filename" : {
				return new TokenValueString (Filename);
				}
			case "Count" : {
				return new TokenValueInteger32 (Count);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Filename", new Property (typeof(TokenValueString), false)} ,
			{ "Count", new Property (typeof(TokenValueInteger32), false)} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, Result._StaticAllProperties);


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;



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


	}

	/// <summary>
	/// </summary>
public partial class ResultLog : Result {
        /// <summary>
        /// </summary>

	public virtual int?						Count  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "Count" : {
				if (value is TokenValueInteger32 vvalue) {
					Count = vvalue.Value;
					}
				break;
				}

			default: {
				base.Setter(tag, value);
				break;
				}
			}
		}

    ///<inheritdoc/>
    public override TokenValue Getter(
            string tag) {
        switch (tag) {
			case "Count" : {
				return new TokenValueInteger32 (Count);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Count", new Property (typeof(TokenValueInteger32), false)} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, Result._StaticAllProperties);


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;



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


	}

	/// <summary>
	/// </summary>
public partial class ResultArchive : Result {
        /// <summary>
        /// </summary>

	public virtual List<FileEntry>				Entries  {get; set;}
        /// <summary>
        /// </summary>

	public virtual int?						Frames  {get; set;}
        /// <summary>
        /// </summary>

	public virtual int?						Deleted  {get; set;}
        /// <summary>
        /// </summary>

	public virtual int?						IndexFrame  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "Entries" : {
				if (value is TokenValueListStructObject vvalue) {
					Entries = vvalue.Value as List<FileEntry>;
					}
				break;
				}
			case "Frames" : {
				if (value is TokenValueInteger32 vvalue) {
					Frames = vvalue.Value;
					}
				break;
				}
			case "Deleted" : {
				if (value is TokenValueInteger32 vvalue) {
					Deleted = vvalue.Value;
					}
				break;
				}
			case "IndexFrame" : {
				if (value is TokenValueInteger32 vvalue) {
					IndexFrame = vvalue.Value;
					}
				break;
				}

			default: {
				base.Setter(tag, value);
				break;
				}
			}
		}

    ///<inheritdoc/>
    public override TokenValue Getter(
            string tag) {
        switch (tag) {
			case "Entries" : {
				return new TokenValueListStruct<FileEntry> (Entries);
				}
			case "Frames" : {
				return new TokenValueInteger32 (Frames);
				}
			case "Deleted" : {
				return new TokenValueInteger32 (Deleted);
				}
			case "IndexFrame" : {
				return new TokenValueInteger32 (IndexFrame);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Entries", new Property ( typeof(TokenValueListStruct), true,
					()=>new List<FileEntry>(), ()=>new FileEntry(), false)} ,
			{ "Frames", new Property (typeof(TokenValueInteger32), false)} ,
			{ "Deleted", new Property (typeof(TokenValueInteger32), false)} ,
			{ "IndexFrame", new Property (typeof(TokenValueInteger32), false)} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, Result._StaticAllProperties);


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;



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


	}

	/// <summary>
	/// </summary>
public partial class ResultFileDare : ResultFile {
        /// <summary>
        /// </summary>

	public virtual DareEnvelope						Envelope  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "Envelope" : {
				if (value is TokenValueStructObject vvalue) {
					Envelope = vvalue.Value as DareEnvelope;
					}
				break;
				}

			default: {
				base.Setter(tag, value);
				break;
				}
			}
		}

    ///<inheritdoc/>
    public override TokenValue Getter(
            string tag) {
        switch (tag) {
			case "Envelope" : {
				return new TokenValueStruct<DareEnvelope> (Envelope);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Envelope", new Property ( typeof(TokenValueStruct), false,
					()=>new DareEnvelope(), ()=>new DareEnvelope(), false)} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, ResultFile._StaticAllProperties);


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;



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


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "Source" : {
				if (value is TokenValueString vvalue) {
					Source = vvalue.Value;
					}
				break;
				}
			case "Created" : {
				if (value is TokenValueString vvalue) {
					Created = vvalue.Value;
					}
				break;
				}
			case "URI" : {
				if (value is TokenValueString vvalue) {
					URI = vvalue.Value;
					}
				break;
				}

			default: {
				base.Setter(tag, value);
				break;
				}
			}
		}

    ///<inheritdoc/>
    public override TokenValue Getter(
            string tag) {
        switch (tag) {
			case "Source" : {
				return new TokenValueString (Source);
				}
			case "Created" : {
				return new TokenValueString (Created);
				}
			case "URI" : {
				return new TokenValueString (URI);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Source", new Property (typeof(TokenValueString), false)} ,
			{ "Created", new Property (typeof(TokenValueString), false)} ,
			{ "URI", new Property (typeof(TokenValueString), false)} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, Result._StaticAllProperties);


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;



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


	}

	/// <summary>
	/// </summary>
public partial class ResultDump : Result {
        /// <summary>
        /// </summary>

	public virtual List<CatalogedEntry>				CatalogedEntries  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "CatalogedEntries" : {
				if (value is TokenValueListStructObject vvalue) {
					CatalogedEntries = vvalue.Value as List<CatalogedEntry>;
					}
				break;
				}

			default: {
				base.Setter(tag, value);
				break;
				}
			}
		}

    ///<inheritdoc/>
    public override TokenValue Getter(
            string tag) {
        switch (tag) {
			case "CatalogedEntries" : {
				return new TokenValueListStruct<CatalogedEntry> (CatalogedEntries);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "CatalogedEntries", new Property ( typeof(TokenValueListStruct), true,
					()=>new List<CatalogedEntry>(), null, true)} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, Result._StaticAllProperties);


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;



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


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "CatalogedDevices" : {
				if (value is TokenValueListStructObject vvalue) {
					CatalogedDevices = vvalue.Value as List<CatalogedDevice>;
					}
				break;
				}
			case "Profiles" : {
				if (value is TokenValueListStructObject vvalue) {
					Profiles = vvalue.Value as List<Assertion>;
					}
				break;
				}

			default: {
				base.Setter(tag, value);
				break;
				}
			}
		}

    ///<inheritdoc/>
    public override TokenValue Getter(
            string tag) {
        switch (tag) {
			case "CatalogedDevices" : {
				return new TokenValueListStruct<CatalogedDevice> (CatalogedDevices);
				}
			case "Profiles" : {
				return new TokenValueListStruct<Assertion> (Profiles);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "CatalogedDevices", new Property ( typeof(TokenValueListStruct), true,
					()=>new List<CatalogedDevice>(), ()=>new CatalogedDevice(), false)} ,
			{ "Profiles", new Property ( typeof(TokenValueListStruct), true,
					()=>new List<Assertion>(), null, true)} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, Result._StaticAllProperties);


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;



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


	}

	/// <summary>
	/// </summary>
public partial class ResultAccountConnect : Result {
        /// <summary>
        /// </summary>

	public virtual ProfileDevice						ProfileDevice  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "ProfileDevice" : {
				if (value is TokenValueStructObject vvalue) {
					ProfileDevice = vvalue.Value as ProfileDevice;
					}
				break;
				}

			default: {
				base.Setter(tag, value);
				break;
				}
			}
		}

    ///<inheritdoc/>
    public override TokenValue Getter(
            string tag) {
        switch (tag) {
			case "ProfileDevice" : {
				return new TokenValueStruct<ProfileDevice> (ProfileDevice);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "ProfileDevice", new Property ( typeof(TokenValueStruct), false,
					()=>new ProfileDevice(), ()=>new ProfileDevice(), false)} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, Result._StaticAllProperties);


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;



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


	}

	/// <summary>
	/// </summary>
public partial class ResultPublish : ResultCreateDevice {
        /// <summary>
        /// </summary>

	public virtual string						Uri  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "Uri" : {
				if (value is TokenValueString vvalue) {
					Uri = vvalue.Value;
					}
				break;
				}

			default: {
				base.Setter(tag, value);
				break;
				}
			}
		}

    ///<inheritdoc/>
    public override TokenValue Getter(
            string tag) {
        switch (tag) {
			case "Uri" : {
				return new TokenValueString (Uri);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Uri", new Property (typeof(TokenValueString), false)} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, ResultCreateDevice._StaticAllProperties);


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;



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


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "Uri" : {
				if (value is TokenValueString vvalue) {
					Uri = vvalue.Value;
					}
				break;
				}
			case "FileName" : {
				if (value is TokenValueString vvalue) {
					FileName = vvalue.Value;
					}
				break;
				}
			case "DevicePreconfigurationPublic" : {
				if (value is TokenValueStructObject vvalue) {
					DevicePreconfigurationPublic = vvalue.Value as DevicePreconfigurationPublic;
					}
				break;
				}
			case "DevicePreconfigurationPrivate" : {
				if (value is TokenValueStructObject vvalue) {
					DevicePreconfigurationPrivate = vvalue.Value as DevicePreconfigurationPrivate;
					}
				break;
				}

			default: {
				base.Setter(tag, value);
				break;
				}
			}
		}

    ///<inheritdoc/>
    public override TokenValue Getter(
            string tag) {
        switch (tag) {
			case "Uri" : {
				return new TokenValueString (Uri);
				}
			case "FileName" : {
				return new TokenValueString (FileName);
				}
			case "DevicePreconfigurationPublic" : {
				return new TokenValueStruct<DevicePreconfigurationPublic> (DevicePreconfigurationPublic);
				}
			case "DevicePreconfigurationPrivate" : {
				return new TokenValueStruct<DevicePreconfigurationPrivate> (DevicePreconfigurationPrivate);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Uri", new Property (typeof(TokenValueString), false)} ,
			{ "FileName", new Property (typeof(TokenValueString), false)} ,
			{ "DevicePreconfigurationPublic", new Property ( typeof(TokenValueStruct), false,
					()=>new DevicePreconfigurationPublic(), ()=>new DevicePreconfigurationPublic(), false)} ,
			{ "DevicePreconfigurationPrivate", new Property ( typeof(TokenValueStruct), false,
					()=>new DevicePreconfigurationPrivate(), ()=>new DevicePreconfigurationPrivate(), false)} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, ResultCreateDevice._StaticAllProperties);


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;



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


	}

	/// <summary>
	/// </summary>
public partial class ResultCreateDevice : Result {
        /// <summary>
        /// </summary>

	public virtual bool?						Default  {get; set;}
        /// <summary>
        /// </summary>

	public virtual string						DeviceUDF  {get; set;}
        /// <summary>
        /// </summary>

	public virtual CatalogedDevice						CatalogedDevice  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "Default" : {
				if (value is TokenValueBoolean vvalue) {
					Default = vvalue.Value;
					}
				break;
				}
			case "DeviceUDF" : {
				if (value is TokenValueString vvalue) {
					DeviceUDF = vvalue.Value;
					}
				break;
				}
			case "CatalogedDevice" : {
				if (value is TokenValueStructObject vvalue) {
					CatalogedDevice = vvalue.Value as CatalogedDevice;
					}
				break;
				}

			default: {
				base.Setter(tag, value);
				break;
				}
			}
		}

    ///<inheritdoc/>
    public override TokenValue Getter(
            string tag) {
        switch (tag) {
			case "Default" : {
				return new TokenValueBoolean (Default);
				}
			case "DeviceUDF" : {
				return new TokenValueString (DeviceUDF);
				}
			case "CatalogedDevice" : {
				return new TokenValueStruct<CatalogedDevice> (CatalogedDevice);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Default", new Property (typeof(TokenValueBoolean), false)} ,
			{ "DeviceUDF", new Property (typeof(TokenValueString), false)} ,
			{ "CatalogedDevice", new Property ( typeof(TokenValueStruct), false,
					()=>new CatalogedDevice(), ()=>new CatalogedDevice(), false)} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, Result._StaticAllProperties);


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;



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


	}

	/// <summary>
	/// </summary>
public partial class ResultCreatePersonal : ResultCreateAccount {
        /// <summary>
        /// </summary>

	public virtual string						MeshUDF  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "MeshUDF" : {
				if (value is TokenValueString vvalue) {
					MeshUDF = vvalue.Value;
					}
				break;
				}

			default: {
				base.Setter(tag, value);
				break;
				}
			}
		}

    ///<inheritdoc/>
    public override TokenValue Getter(
            string tag) {
        switch (tag) {
			case "MeshUDF" : {
				return new TokenValueString (MeshUDF);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "MeshUDF", new Property (typeof(TokenValueString), false)} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, ResultCreateAccount._StaticAllProperties);


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;



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


	}

	/// <summary>
	/// </summary>
public partial class ResultCreateAccount : ResultCreateDevice {
        /// <summary>
        /// </summary>

	public virtual ProfileAccount						ProfileAccount  {get; set;}
        /// <summary>
        /// </summary>

	public virtual ActivationAccount						ActivationAccount  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "ProfileAccount" : {
				if (value is TokenValueStructObject vvalue) {
					ProfileAccount = vvalue.Value as ProfileAccount;
					}
				break;
				}
			case "ActivationAccount" : {
				if (value is TokenValueStructObject vvalue) {
					ActivationAccount = vvalue.Value as ActivationAccount;
					}
				break;
				}

			default: {
				base.Setter(tag, value);
				break;
				}
			}
		}

    ///<inheritdoc/>
    public override TokenValue Getter(
            string tag) {
        switch (tag) {
			case "ProfileAccount" : {
				return new TokenValueStruct<ProfileAccount> (ProfileAccount);
				}
			case "ActivationAccount" : {
				return new TokenValueStruct<ActivationAccount> (ActivationAccount);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "ProfileAccount", new Property ( typeof(TokenValueStruct), false,
					()=>new ProfileAccount(), ()=>new ProfileAccount(), false)} ,
			{ "ActivationAccount", new Property ( typeof(TokenValueStruct), false,
					()=>new ActivationAccount(), ()=>new ActivationAccount(), false)} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, ResultCreateDevice._StaticAllProperties);


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;



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


	}

	/// <summary>
	/// </summary>
public partial class ResultDeleteAccount : ResultCreateDevice {
        /// <summary>
        /// </summary>

	public virtual string						UDF  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "UDF" : {
				if (value is TokenValueString vvalue) {
					UDF = vvalue.Value;
					}
				break;
				}

			default: {
				base.Setter(tag, value);
				break;
				}
			}
		}

    ///<inheritdoc/>
    public override TokenValue Getter(
            string tag) {
        switch (tag) {
			case "UDF" : {
				return new TokenValueString (UDF);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "UDF", new Property (typeof(TokenValueString), false)} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, ResultCreateDevice._StaticAllProperties);


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;



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


	}

	/// <summary>
	/// </summary>
public partial class ResultRegisterService : ResultCreateAccount {
        /// <summary>
        /// </summary>

	public virtual string						AccountAddress  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "AccountAddress" : {
				if (value is TokenValueString vvalue) {
					AccountAddress = vvalue.Value;
					}
				break;
				}

			default: {
				base.Setter(tag, value);
				break;
				}
			}
		}

    ///<inheritdoc/>
    public override TokenValue Getter(
            string tag) {
        switch (tag) {
			case "AccountAddress" : {
				return new TokenValueString (AccountAddress);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "AccountAddress", new Property (typeof(TokenValueString), false)} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, ResultCreateAccount._StaticAllProperties);


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;



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


	}

	/// <summary>
	/// </summary>
public partial class ResultRecover : ResultCreatePersonal {


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {

			default: {
				base.Setter(tag, value);
				break;
				}
			}
		}

    ///<inheritdoc/>
    public override TokenValue Getter(
            string tag) {
        switch (tag) {

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, ResultCreatePersonal._StaticAllProperties);


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;



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


	}

	/// <summary>
	/// </summary>
public partial class ResultStatus : Result {
        /// <summary>
        /// </summary>

	public virtual StatusResponse						StatusResponse  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "StatusResponse" : {
				if (value is TokenValueStructObject vvalue) {
					StatusResponse = vvalue.Value as StatusResponse;
					}
				break;
				}

			default: {
				base.Setter(tag, value);
				break;
				}
			}
		}

    ///<inheritdoc/>
    public override TokenValue Getter(
            string tag) {
        switch (tag) {
			case "StatusResponse" : {
				return new TokenValueStruct<StatusResponse> (StatusResponse);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "StatusResponse", new Property ( typeof(TokenValueStruct), false,
					()=>new StatusResponse(), ()=>new StatusResponse(), false)} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, Result._StaticAllProperties);


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;



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


	}

	/// <summary>
	/// </summary>
public partial class ResultSync : Result {
        /// <summary>
        /// </summary>

	public virtual int?						Fetched  {get; set;}
        /// <summary>
        /// </summary>

	public virtual int?						ProcessedResults  {get; set;}
        /// <summary>
        /// </summary>

	public virtual List<ProcessResult>				ProcessResults  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "Fetched" : {
				if (value is TokenValueInteger32 vvalue) {
					Fetched = vvalue.Value;
					}
				break;
				}
			case "ProcessedResults" : {
				if (value is TokenValueInteger32 vvalue) {
					ProcessedResults = vvalue.Value;
					}
				break;
				}
			case "ProcessResults" : {
				if (value is TokenValueListStructObject vvalue) {
					ProcessResults = vvalue.Value as List<ProcessResult>;
					}
				break;
				}

			default: {
				base.Setter(tag, value);
				break;
				}
			}
		}

    ///<inheritdoc/>
    public override TokenValue Getter(
            string tag) {
        switch (tag) {
			case "Fetched" : {
				return new TokenValueInteger32 (Fetched);
				}
			case "ProcessedResults" : {
				return new TokenValueInteger32 (ProcessedResults);
				}
			case "ProcessResults" : {
				return new TokenValueListStruct<ProcessResult> (ProcessResults);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Fetched", new Property (typeof(TokenValueInteger32), false)} ,
			{ "ProcessedResults", new Property (typeof(TokenValueInteger32), false)} ,
			{ "ProcessResults", new Property ( typeof(TokenValueListStruct), true,
					()=>new List<ProcessResult>(), null, true)} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, Result._StaticAllProperties);


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;



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


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "Service" : {
				if (value is TokenValueString vvalue) {
					Service = vvalue.Value;
					}
				break;
				}
			case "Shares" : {
				if (value is TokenValueListString vvalue) {
					Shares = vvalue.Value;
					}
				break;
				}

			default: {
				base.Setter(tag, value);
				break;
				}
			}
		}

    ///<inheritdoc/>
    public override TokenValue Getter(
            string tag) {
        switch (tag) {
			case "Service" : {
				return new TokenValueString (Service);
				}
			case "Shares" : {
				return new TokenValueListString (Shares);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Service", new Property (typeof(TokenValueString), false)} ,
			{ "Shares", new Property (typeof(TokenValueListString), true)} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, Result._StaticAllProperties);


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;



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


	}

	/// <summary>
	/// </summary>
public partial class ResultMachine : Result {
        /// <summary>
        /// </summary>

	public virtual List<CatalogedMachine>				CatalogedMachines  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "CatalogedMachines" : {
				if (value is TokenValueListStructObject vvalue) {
					CatalogedMachines = vvalue.Value as List<CatalogedMachine>;
					}
				break;
				}

			default: {
				base.Setter(tag, value);
				break;
				}
			}
		}

    ///<inheritdoc/>
    public override TokenValue Getter(
            string tag) {
        switch (tag) {
			case "CatalogedMachines" : {
				return new TokenValueListStruct<CatalogedMachine> (CatalogedMachines);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "CatalogedMachines", new Property ( typeof(TokenValueListStruct), true,
					()=>new List<CatalogedMachine>(), ()=>new CatalogedMachine(), false)} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, Result._StaticAllProperties);


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;



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


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "MessagePIN" : {
				if (value is TokenValueStructObject vvalue) {
					MessagePIN = vvalue.Value as MessagePin;
					}
				break;
				}
			case "Uri" : {
				if (value is TokenValueString vvalue) {
					Uri = vvalue.Value;
					}
				break;
				}

			default: {
				base.Setter(tag, value);
				break;
				}
			}
		}

    ///<inheritdoc/>
    public override TokenValue Getter(
            string tag) {
        switch (tag) {
			case "MessagePIN" : {
				return new TokenValueStruct<MessagePin> (MessagePIN);
				}
			case "Uri" : {
				return new TokenValueString (Uri);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "MessagePIN", new Property ( typeof(TokenValueStruct), false,
					()=>new MessagePin(), ()=>new MessagePin(), false)} ,
			{ "Uri", new Property (typeof(TokenValueString), false)} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, Result._StaticAllProperties);


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;



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


	}

	/// <summary>
	/// </summary>
public partial class ResultHello : Result {
        /// <summary>
        /// </summary>

	public virtual MeshHelloResponse						Response  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "Response" : {
				if (value is TokenValueStructObject vvalue) {
					Response = vvalue.Value as MeshHelloResponse;
					}
				break;
				}

			default: {
				base.Setter(tag, value);
				break;
				}
			}
		}

    ///<inheritdoc/>
    public override TokenValue Getter(
            string tag) {
        switch (tag) {
			case "Response" : {
				return new TokenValueStruct<MeshHelloResponse> (Response);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Response", new Property ( typeof(TokenValueStruct), false,
					()=>new MeshHelloResponse(), ()=>new MeshHelloResponse(), false)} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, Result._StaticAllProperties);


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;



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


	}

	/// <summary>
	/// </summary>
public partial class ResultSequence : Result {
        /// <summary>
        /// </summary>

	public virtual LogEntry						Entries  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "Entries" : {
				if (value is TokenValueStructObject vvalue) {
					Entries = vvalue.Value as LogEntry;
					}
				break;
				}

			default: {
				base.Setter(tag, value);
				break;
				}
			}
		}

    ///<inheritdoc/>
    public override TokenValue Getter(
            string tag) {
        switch (tag) {
			case "Entries" : {
				return new TokenValueStruct<LogEntry> (Entries);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Entries", new Property ( typeof(TokenValueStruct), false,
					()=>new LogEntry(), ()=>new LogEntry(), false)} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, Result._StaticAllProperties);


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;



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


	}

	/// <summary>
	/// </summary>
public partial class LogEntry : MeshmanShellResult {
        /// <summary>
        /// </summary>

	public virtual string						Key  {get; set;}
        /// <summary>
        /// </summary>

	public virtual int?						Length  {get; set;}
        /// <summary>
        /// </summary>

	public virtual byte[]						Digest  {get; set;}
        /// <summary>
        /// </summary>

	public virtual DateTime?						Recorded  {get; set;}
        /// <summary>
        /// </summary>

	public virtual bool?						Encrypted  {get; set;}
        /// <summary>
        /// </summary>

	public virtual bool?						Signed  {get; set;}
        /// <summary>
        /// </summary>

	public virtual bool?						KeyExchange  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "Key" : {
				if (value is TokenValueString vvalue) {
					Key = vvalue.Value;
					}
				break;
				}
			case "Length" : {
				if (value is TokenValueInteger32 vvalue) {
					Length = vvalue.Value;
					}
				break;
				}
			case "Digest" : {
				if (value is TokenValueBinary vvalue) {
					Digest = vvalue.Value;
					}
				break;
				}
			case "Recorded" : {
				if (value is TokenValueDateTime vvalue) {
					Recorded = vvalue.Value;
					}
				break;
				}
			case "Encrypted" : {
				if (value is TokenValueBoolean vvalue) {
					Encrypted = vvalue.Value;
					}
				break;
				}
			case "Signed" : {
				if (value is TokenValueBoolean vvalue) {
					Signed = vvalue.Value;
					}
				break;
				}
			case "KeyExchange" : {
				if (value is TokenValueBoolean vvalue) {
					KeyExchange = vvalue.Value;
					}
				break;
				}

			default: {
				base.Setter(tag, value);
				break;
				}
			}
		}

    ///<inheritdoc/>
    public override TokenValue Getter(
            string tag) {
        switch (tag) {
			case "Key" : {
				return new TokenValueString (Key);
				}
			case "Length" : {
				return new TokenValueInteger32 (Length);
				}
			case "Digest" : {
				return new TokenValueBinary (Digest);
				}
			case "Recorded" : {
				return new TokenValueDateTime (Recorded);
				}
			case "Encrypted" : {
				return new TokenValueBoolean (Encrypted);
				}
			case "Signed" : {
				return new TokenValueBoolean (Signed);
				}
			case "KeyExchange" : {
				return new TokenValueBoolean (KeyExchange);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Key", new Property (typeof(TokenValueString), false)} ,
			{ "Length", new Property (typeof(TokenValueInteger32), false)} ,
			{ "Digest", new Property (typeof(TokenValueBinary), false)} ,
			{ "Recorded", new Property (typeof(TokenValueDateTime), false)} ,
			{ "Encrypted", new Property (typeof(TokenValueBoolean), false)} ,
			{ "Signed", new Property (typeof(TokenValueBoolean), false)} ,
			{ "KeyExchange", new Property (typeof(TokenValueBoolean), false)} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties = _StaticProperties;


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;



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


	}

	/// <summary>
	/// </summary>
public partial class ResultEntry : Result {
        /// <summary>
        /// </summary>

	public virtual CatalogedEntry						CatalogEntry  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "CatalogEntry" : {
				if (value is TokenValueStructObject vvalue) {
					CatalogEntry = vvalue.Value as CatalogedEntry;
					}
				break;
				}

			default: {
				base.Setter(tag, value);
				break;
				}
			}
		}

    ///<inheritdoc/>
    public override TokenValue Getter(
            string tag) {
        switch (tag) {
			case "CatalogEntry" : {
				return new TokenValueStruct<CatalogedEntry> (CatalogEntry);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "CatalogEntry", new Property ( typeof(TokenValueStruct), false,
					null, null, true)} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, Result._StaticAllProperties);


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;



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


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "CatalogEntry" : {
				if (value is TokenValueStructObject vvalue) {
					CatalogEntry = vvalue.Value as CatalogedEntry;
					}
				break;
				}
			case "Message" : {
				if (value is TokenValueStructObject vvalue) {
					Message = vvalue.Value as Message;
					}
				break;
				}

			default: {
				base.Setter(tag, value);
				break;
				}
			}
		}

    ///<inheritdoc/>
    public override TokenValue Getter(
            string tag) {
        switch (tag) {
			case "CatalogEntry" : {
				return new TokenValueStruct<CatalogedEntry> (CatalogEntry);
				}
			case "Message" : {
				return new TokenValueStruct<Message> (Message);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "CatalogEntry", new Property ( typeof(TokenValueStruct), false,
					null, null, true)} ,
			{ "Message", new Property ( typeof(TokenValueStruct), false,
					()=>new Message(), ()=>new Message(), false)} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, Result._StaticAllProperties);


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;



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


	}

	/// <summary>
	/// </summary>
public partial class ResultMail : ResultEntry {


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {

			default: {
				base.Setter(tag, value);
				break;
				}
			}
		}

    ///<inheritdoc/>
    public override TokenValue Getter(
            string tag) {
        switch (tag) {

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, ResultEntry._StaticAllProperties);


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;



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


	}

	/// <summary>
	/// </summary>
public partial class ResultSSH : ResultEntry {


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {

			default: {
				base.Setter(tag, value);
				break;
				}
			}
		}

    ///<inheritdoc/>
    public override TokenValue Getter(
            string tag) {
        switch (tag) {

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, ResultEntry._StaticAllProperties);


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;



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


	}

	/// <summary>
	/// </summary>
public partial class ResultGroupCreate : ResultEntry {


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {

			default: {
				base.Setter(tag, value);
				break;
				}
			}
		}

    ///<inheritdoc/>
    public override TokenValue Getter(
            string tag) {
        switch (tag) {

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, ResultEntry._StaticAllProperties);


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;



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


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "Message" : {
				if (value is TokenValueStructObject vvalue) {
					Message = vvalue.Value as Message;
					}
				break;
				}
			case "Status" : {
				if (value is TokenValueString vvalue) {
					Status = vvalue.Value;
					}
				break;
				}

			default: {
				base.Setter(tag, value);
				break;
				}
			}
		}

    ///<inheritdoc/>
    public override TokenValue Getter(
            string tag) {
        switch (tag) {
			case "Message" : {
				return new TokenValueStruct<Message> (Message);
				}
			case "Status" : {
				return new TokenValueString (Status);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Message", new Property ( typeof(TokenValueStruct), false,
					()=>new Message(), ()=>new Message(), false)} ,
			{ "Status", new Property (typeof(TokenValueString), false)} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, Result._StaticAllProperties);


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;



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


	}

	/// <summary>
	/// </summary>
public partial class ResultPending : Result {
        /// <summary>
        /// </summary>

	public virtual List<Message>				Messages  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "Messages" : {
				if (value is TokenValueListStructObject vvalue) {
					Messages = vvalue.Value as List<Message>;
					}
				break;
				}

			default: {
				base.Setter(tag, value);
				break;
				}
			}
		}

    ///<inheritdoc/>
    public override TokenValue Getter(
            string tag) {
        switch (tag) {
			case "Messages" : {
				return new TokenValueListStruct<Message> (Messages);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Messages", new Property ( typeof(TokenValueListStruct), true,
					()=>new List<Message>(), ()=>new Message(), false)} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, Result._StaticAllProperties);


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;



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


	}

	/// <summary>
	/// </summary>
public partial class ResultAuthorize : Result {
        /// <summary>
        /// </summary>

	public virtual List<ProcessResult>				Messages  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "Messages" : {
				if (value is TokenValueListStructObject vvalue) {
					Messages = vvalue.Value as List<ProcessResult>;
					}
				break;
				}

			default: {
				base.Setter(tag, value);
				break;
				}
			}
		}

    ///<inheritdoc/>
    public override TokenValue Getter(
            string tag) {
        switch (tag) {
			case "Messages" : {
				return new TokenValueListStruct<ProcessResult> (Messages);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Messages", new Property ( typeof(TokenValueListStruct), true,
					()=>new List<ProcessResult>(), null, true)} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, Result._StaticAllProperties);


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;



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


	}

	/// <summary>
	/// </summary>
public partial class ResultProcess : Result {
        /// <summary>
        /// </summary>

	public virtual Message						ProcessResult  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "ProcessResult" : {
				if (value is TokenValueStructObject vvalue) {
					ProcessResult = vvalue.Value as Message;
					}
				break;
				}

			default: {
				base.Setter(tag, value);
				break;
				}
			}
		}

    ///<inheritdoc/>
    public override TokenValue Getter(
            string tag) {
        switch (tag) {
			case "ProcessResult" : {
				return new TokenValueStruct<Message> (ProcessResult);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "ProcessResult", new Property ( typeof(TokenValueStruct), false,
					()=>new Message(), ()=>new Message(), false)} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, Result._StaticAllProperties);


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;



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

	public virtual ActivationAccount						ActivationAccount  {get; set;}
        /// <summary>
        /// </summary>

	public virtual ActivationCommon						ActivationCommon  {get; set;}
        /// <summary>
        /// </summary>

	public virtual RequestConnection						RequestConnection  {get; set;}
        /// <summary>
        /// </summary>

	public virtual AcknowledgeConnection						AcknowledgeConnection  {get; set;}
        /// <summary>
        /// </summary>

	public virtual RespondConnection						RespondConnection  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "Profile" : {
				if (value is TokenValueStructObject vvalue) {
					Profile = vvalue.Value as Profile;
					}
				break;
				}
			case "CatalogedMachine" : {
				if (value is TokenValueStructObject vvalue) {
					CatalogedMachine = vvalue.Value as CatalogedMachine;
					}
				break;
				}
			case "ActivationAccount" : {
				if (value is TokenValueStructObject vvalue) {
					ActivationAccount = vvalue.Value as ActivationAccount;
					}
				break;
				}
			case "ActivationCommon" : {
				if (value is TokenValueStructObject vvalue) {
					ActivationCommon = vvalue.Value as ActivationCommon;
					}
				break;
				}
			case "RequestConnection" : {
				if (value is TokenValueStructObject vvalue) {
					RequestConnection = vvalue.Value as RequestConnection;
					}
				break;
				}
			case "AcknowledgeConnection" : {
				if (value is TokenValueStructObject vvalue) {
					AcknowledgeConnection = vvalue.Value as AcknowledgeConnection;
					}
				break;
				}
			case "RespondConnection" : {
				if (value is TokenValueStructObject vvalue) {
					RespondConnection = vvalue.Value as RespondConnection;
					}
				break;
				}

			default: {
				base.Setter(tag, value);
				break;
				}
			}
		}

    ///<inheritdoc/>
    public override TokenValue Getter(
            string tag) {
        switch (tag) {
			case "Profile" : {
				return new TokenValueStruct<Profile> (Profile);
				}
			case "CatalogedMachine" : {
				return new TokenValueStruct<CatalogedMachine> (CatalogedMachine);
				}
			case "ActivationAccount" : {
				return new TokenValueStruct<ActivationAccount> (ActivationAccount);
				}
			case "ActivationCommon" : {
				return new TokenValueStruct<ActivationCommon> (ActivationCommon);
				}
			case "RequestConnection" : {
				return new TokenValueStruct<RequestConnection> (RequestConnection);
				}
			case "AcknowledgeConnection" : {
				return new TokenValueStruct<AcknowledgeConnection> (AcknowledgeConnection);
				}
			case "RespondConnection" : {
				return new TokenValueStruct<RespondConnection> (RespondConnection);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Profile", new Property ( typeof(TokenValueStruct), false,
					null, null, true)} ,
			{ "CatalogedMachine", new Property ( typeof(TokenValueStruct), false,
					()=>new CatalogedMachine(), ()=>new CatalogedMachine(), false)} ,
			{ "ActivationAccount", new Property ( typeof(TokenValueStruct), false,
					()=>new ActivationAccount(), ()=>new ActivationAccount(), false)} ,
			{ "ActivationCommon", new Property ( typeof(TokenValueStruct), false,
					()=>new ActivationCommon(), ()=>new ActivationCommon(), false)} ,
			{ "RequestConnection", new Property ( typeof(TokenValueStruct), false,
					()=>new RequestConnection(), ()=>new RequestConnection(), false)} ,
			{ "AcknowledgeConnection", new Property ( typeof(TokenValueStruct), false,
					()=>new AcknowledgeConnection(), ()=>new AcknowledgeConnection(), false)} ,
			{ "RespondConnection", new Property ( typeof(TokenValueStruct), false,
					()=>new RespondConnection(), ()=>new RespondConnection(), false)} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, Result._StaticAllProperties);


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;



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


	}

	/// <summary>
	/// </summary>
public partial class ResultTransactionRequest : Result {
        /// <summary>
        /// </summary>

	public virtual string						Identifier  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "Identifier" : {
				if (value is TokenValueString vvalue) {
					Identifier = vvalue.Value;
					}
				break;
				}

			default: {
				base.Setter(tag, value);
				break;
				}
			}
		}

    ///<inheritdoc/>
    public override TokenValue Getter(
            string tag) {
        switch (tag) {
			case "Identifier" : {
				return new TokenValueString (Identifier);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Identifier", new Property (typeof(TokenValueString), false)} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, Result._StaticAllProperties);


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;



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


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "Status" : {
				if (value is TokenValueString vvalue) {
					Status = vvalue.Value;
					}
				break;
				}
			case "Message" : {
				if (value is TokenValueStructObject vvalue) {
					Message = vvalue.Value as Message;
					}
				break;
				}

			default: {
				base.Setter(tag, value);
				break;
				}
			}
		}

    ///<inheritdoc/>
    public override TokenValue Getter(
            string tag) {
        switch (tag) {
			case "Status" : {
				return new TokenValueString (Status);
				}
			case "Message" : {
				return new TokenValueStruct<Message> (Message);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Status", new Property (typeof(TokenValueString), false)} ,
			{ "Message", new Property ( typeof(TokenValueStruct), false,
					()=>new Message(), ()=>new Message(), false)} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, Result._StaticAllProperties);


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;



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


	}

	/// <summary>
	/// </summary>
public partial class ResultApplication : Result {
        /// <summary>
        /// </summary>

	public virtual CatalogedApplication						Application  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "Application" : {
				if (value is TokenValueStructObject vvalue) {
					Application = vvalue.Value as CatalogedApplication;
					}
				break;
				}

			default: {
				base.Setter(tag, value);
				break;
				}
			}
		}

    ///<inheritdoc/>
    public override TokenValue Getter(
            string tag) {
        switch (tag) {
			case "Application" : {
				return new TokenValueStruct<CatalogedApplication> (Application);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Application", new Property ( typeof(TokenValueStruct), false,
					null, null, true)} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, Result._StaticAllProperties);


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;



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


	}

	/// <summary>
	/// </summary>
public partial class ResultApplicationList : Result {
        /// <summary>
        /// </summary>

	public virtual List<CatalogedApplication>				Applications  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "Applications" : {
				if (value is TokenValueListStructObject vvalue) {
					Applications = vvalue.Value as List<CatalogedApplication>;
					}
				break;
				}

			default: {
				base.Setter(tag, value);
				break;
				}
			}
		}

    ///<inheritdoc/>
    public override TokenValue Getter(
            string tag) {
        switch (tag) {
			case "Applications" : {
				return new TokenValueListStruct<CatalogedApplication> (Applications);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Applications", new Property ( typeof(TokenValueListStruct), true,
					()=>new List<CatalogedApplication>(), null, true)} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, Result._StaticAllProperties);


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;



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


	}



