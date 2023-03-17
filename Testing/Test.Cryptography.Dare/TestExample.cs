
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
//  This file was automatically generated at 17-Mar-23 6:50:54 PM
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


namespace Goedel.XUnit;


	/// <summary>
	///
	/// Classes that represent data written to the portal log.
	/// </summary>
public abstract partial class TestSchema : global::Goedel.Protocol.JsonObject {

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag =>__Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "TestSchema";

	/// <summary>
    /// Dictionary mapping tags to factory methods
    /// </summary>
	public static Dictionary<string, JsonFactoryDelegate> _TagDictionary=> _tagDictionary;
	static Dictionary<string, JsonFactoryDelegate> _tagDictionary = 
			new () {

	    {"TestEntry", TestEntry._Factory},
	    {"TestItem", TestItem._Factory},
	    {"MessageTest", MessageTest._Factory},
	    {"CatalogEntryTest", CatalogEntryTest._Factory}
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
	/// An entry in the test log
	/// </summary>
abstract public partial class TestEntry : TestSchema {
        /// <summary>
        ///Time the pending item was created.
        /// </summary>

	public virtual DateTime?						Created  {get; set;}
        /// <summary>
        ///Time the pending item was last modified.
        /// </summary>

	public virtual DateTime?						Modified  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "Created" : {
				if (value is TokenValueDateTime vvalue) {
					Created = vvalue.Value;
					}
				break;
				}
			case "Modified" : {
				if (value is TokenValueDateTime vvalue) {
					Modified = vvalue.Value;
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
			case "Created" : {
				return new TokenValueDateTime (Created);
				}
			case "Modified" : {
				return new TokenValueDateTime (Modified);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Created", new Property (typeof(TokenValueDateTime), false)} ,
			{ "Modified", new Property (typeof(TokenValueDateTime), false)} 
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
	public new const string __Tag = "TestEntry";

	/// <summary>
    /// Factory method. Throws exception as this is an abstract class.
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => throw new CannotCreateAbstract();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new TestEntry FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as TestEntry;
			}
		throw new CannotCreateAbstract();
		}


	}

	/// <summary>
	///
	/// Test account...
	/// </summary>
public partial class TestItem : TestEntry {
        /// <summary>
        ///Assigned account identifier, e.g. 'alice@example.com'. Account names are 
        ///not case sensitive.
        /// </summary>

	public virtual string						AccountID  {get; set;}
        /// <summary>
        ///Fingerprint of associated user profile
        /// </summary>

	public virtual string						UserProfileUDF  {get; set;}
        /// <summary>
        ///Status of the account, valid values are 'Open', 'Closed',
        ///'Suspended'
        /// </summary>

	public virtual string						Status  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "AccountID" : {
				if (value is TokenValueString vvalue) {
					AccountID = vvalue.Value;
					}
				break;
				}
			case "UserProfileUDF" : {
				if (value is TokenValueString vvalue) {
					UserProfileUDF = vvalue.Value;
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
			case "AccountID" : {
				return new TokenValueString (AccountID);
				}
			case "UserProfileUDF" : {
				return new TokenValueString (UserProfileUDF);
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

			{ "AccountID", new Property (typeof(TokenValueString), false)} ,
			{ "UserProfileUDF", new Property (typeof(TokenValueString), false)} ,
			{ "Status", new Property (typeof(TokenValueString), false)} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, TestEntry._StaticAllProperties);


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
	public new const string __Tag = "TestItem";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new TestItem();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new TestItem FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as TestItem;
			}
		var Result = new TestItem ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	///
	/// Test message consiting of a chunk of data with a unique identifier deterministically
	/// Generated from the parameters Seed, Serial, Version and Length
	/// </summary>
public partial class MessageTest : Goedel.Mesh.Message {
        /// <summary>
        /// </summary>

	public virtual string						UniqueId  {get; set;}
        /// <summary>
        /// </summary>

	public virtual string						VersionId  {get; set;}
        /// <summary>
        /// </summary>

	public virtual string						Seed  {get; set;}
        /// <summary>
        /// </summary>

	public virtual int?						Serial  {get; set;}
        /// <summary>
        /// </summary>

	public virtual int?						Version  {get; set;}
        /// <summary>
        ///If specified, the entry was generated with random length setting.
        /// </summary>

	public virtual int?						Length  {get; set;}
        /// <summary>
        /// </summary>

	public virtual byte[]						Data  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "UniqueId" : {
				if (value is TokenValueString vvalue) {
					UniqueId = vvalue.Value;
					}
				break;
				}
			case "VersionId" : {
				if (value is TokenValueString vvalue) {
					VersionId = vvalue.Value;
					}
				break;
				}
			case "Seed" : {
				if (value is TokenValueString vvalue) {
					Seed = vvalue.Value;
					}
				break;
				}
			case "Serial" : {
				if (value is TokenValueInteger32 vvalue) {
					Serial = vvalue.Value;
					}
				break;
				}
			case "Version" : {
				if (value is TokenValueInteger32 vvalue) {
					Version = vvalue.Value;
					}
				break;
				}
			case "Length" : {
				if (value is TokenValueInteger32 vvalue) {
					Length = vvalue.Value;
					}
				break;
				}
			case "Data" : {
				if (value is TokenValueBinary vvalue) {
					Data = vvalue.Value;
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
			case "UniqueId" : {
				return new TokenValueString (UniqueId);
				}
			case "VersionId" : {
				return new TokenValueString (VersionId);
				}
			case "Seed" : {
				return new TokenValueString (Seed);
				}
			case "Serial" : {
				return new TokenValueInteger32 (Serial);
				}
			case "Version" : {
				return new TokenValueInteger32 (Version);
				}
			case "Length" : {
				return new TokenValueInteger32 (Length);
				}
			case "Data" : {
				return new TokenValueBinary (Data);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "UniqueId", new Property (typeof(TokenValueString), false)} ,
			{ "VersionId", new Property (typeof(TokenValueString), false)} ,
			{ "Seed", new Property (typeof(TokenValueString), false)} ,
			{ "Serial", new Property (typeof(TokenValueInteger32), false)} ,
			{ "Version", new Property (typeof(TokenValueInteger32), false)} ,
			{ "Length", new Property (typeof(TokenValueInteger32), false)} ,
			{ "Data", new Property (typeof(TokenValueBinary), false)} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, Goedel.Mesh.Message._StaticAllProperties);


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
	public new const string __Tag = "MessageTest";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new MessageTest();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new MessageTest FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as MessageTest;
			}
		var Result = new MessageTest ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	///
	/// Test message consiting of a chunk of data with a unique identifier deterministically
	/// Generated from the parameters Seed, Serial, Version and Length
	/// </summary>
public partial class CatalogEntryTest : Goedel.Mesh.CatalogedEntry {
        /// <summary>
        /// </summary>

	public virtual string						UniqueId  {get; set;}
        /// <summary>
        /// </summary>

	public virtual string						VersionId  {get; set;}
        /// <summary>
        /// </summary>

	public virtual string						Seed  {get; set;}
        /// <summary>
        /// </summary>

	public virtual int?						Serial  {get; set;}
        /// <summary>
        /// </summary>

	public virtual int?						Version  {get; set;}
        /// <summary>
        ///If specified, the 
        /// </summary>

	public virtual int?						Length  {get; set;}
        /// <summary>
        /// </summary>

	public virtual byte[]						Data  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "UniqueId" : {
				if (value is TokenValueString vvalue) {
					UniqueId = vvalue.Value;
					}
				break;
				}
			case "VersionId" : {
				if (value is TokenValueString vvalue) {
					VersionId = vvalue.Value;
					}
				break;
				}
			case "Seed" : {
				if (value is TokenValueString vvalue) {
					Seed = vvalue.Value;
					}
				break;
				}
			case "Serial" : {
				if (value is TokenValueInteger32 vvalue) {
					Serial = vvalue.Value;
					}
				break;
				}
			case "Version" : {
				if (value is TokenValueInteger32 vvalue) {
					Version = vvalue.Value;
					}
				break;
				}
			case "Length" : {
				if (value is TokenValueInteger32 vvalue) {
					Length = vvalue.Value;
					}
				break;
				}
			case "Data" : {
				if (value is TokenValueBinary vvalue) {
					Data = vvalue.Value;
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
			case "UniqueId" : {
				return new TokenValueString (UniqueId);
				}
			case "VersionId" : {
				return new TokenValueString (VersionId);
				}
			case "Seed" : {
				return new TokenValueString (Seed);
				}
			case "Serial" : {
				return new TokenValueInteger32 (Serial);
				}
			case "Version" : {
				return new TokenValueInteger32 (Version);
				}
			case "Length" : {
				return new TokenValueInteger32 (Length);
				}
			case "Data" : {
				return new TokenValueBinary (Data);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "UniqueId", new Property (typeof(TokenValueString), false)} ,
			{ "VersionId", new Property (typeof(TokenValueString), false)} ,
			{ "Seed", new Property (typeof(TokenValueString), false)} ,
			{ "Serial", new Property (typeof(TokenValueInteger32), false)} ,
			{ "Version", new Property (typeof(TokenValueInteger32), false)} ,
			{ "Length", new Property (typeof(TokenValueInteger32), false)} ,
			{ "Data", new Property (typeof(TokenValueBinary), false)} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, Goedel.Mesh.CatalogedEntry._StaticAllProperties);


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
	public new const string __Tag = "CatalogEntryTest";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new CatalogEntryTest();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new CatalogEntryTest FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as CatalogEntryTest;
			}
		var Result = new CatalogEntryTest ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}



