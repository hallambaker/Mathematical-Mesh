
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
//  This file was automatically generated at 16-Mar-23 3:56:05 PM
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



namespace Goedel.Protocol.Test;


	/// <summary>
	///
	/// Classes to be used to test serialization an deserialization.
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

	    {"MultiInstance", MultiInstance._Factory},
	    {"MultiArray", MultiArray._Factory},
	    {"MultiStruct", MultiStruct._Factory}
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
	/// Contains one instance of each type of field.
	/// </summary>
public partial class MultiInstance : TestSchema {
        /// <summary>
        /// </summary>

	public virtual bool?						FieldBoolean  {get; set;}
        /// <summary>
        /// </summary>

	public virtual int?						FieldInteger  {get; set;}
        /// <summary>
        /// </summary>

	public virtual DateTime?						FieldDateTime  {get; set;}
        /// <summary>
        /// </summary>

	public virtual string						FieldString  {get; set;}
        /// <summary>
        /// </summary>

	public virtual byte[]						FieldBinary  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "FieldBoolean" : {
				if (value is TokenValueBoolean vvalue) {
					FieldBoolean = vvalue.Value;
					}
				break;
				}
			case "FieldInteger" : {
				if (value is TokenValueInteger32 vvalue) {
					FieldInteger = vvalue.Value;
					}
				break;
				}
			case "FieldDateTime" : {
				if (value is TokenValueDateTime vvalue) {
					FieldDateTime = vvalue.Value;
					}
				break;
				}
			case "FieldString" : {
				if (value is TokenValueString vvalue) {
					FieldString = vvalue.Value;
					}
				break;
				}
			case "FieldBinary" : {
				if (value is TokenValueBinary vvalue) {
					FieldBinary = vvalue.Value;
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
			case "FieldBoolean" : {
				return new TokenValueBoolean (FieldBoolean);
				}
			case "FieldInteger" : {
				return new TokenValueInteger32 (FieldInteger);
				}
			case "FieldDateTime" : {
				return new TokenValueDateTime (FieldDateTime);
				}
			case "FieldString" : {
				return new TokenValueString (FieldString);
				}
			case "FieldBinary" : {
				return new TokenValueBinary (FieldBinary);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "FieldBoolean", new Property (typeof(TokenValueBoolean), false)} ,
			{ "FieldInteger", new Property (typeof(TokenValueInteger32), false)} ,
			{ "FieldDateTime", new Property (typeof(TokenValueDateTime), false)} ,
			{ "FieldString", new Property (typeof(TokenValueString), false)} ,
			{ "FieldBinary", new Property (typeof(TokenValueBinary), false)} 
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
	public new const string __Tag = "MultiInstance";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new MultiInstance();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new MultiInstance FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as MultiInstance;
			}
		var Result = new MultiInstance ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
public partial class MultiArray : MultiInstance {
        /// <summary>
        /// </summary>

	public virtual List<bool?>				ArrayBoolean  {get; set;}
        /// <summary>
        /// </summary>

	public virtual List<int?>				ArrayInteger  {get; set;}
        /// <summary>
        /// </summary>

	public virtual List<DateTime?>				ArrayDateTime  {get; set;}
        /// <summary>
        /// </summary>

	public virtual List<string>				ArrayString  {get; set;}
        /// <summary>
        /// </summary>

	public virtual List<byte[]>				ArrayBinary  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "ArrayBoolean" : {
				if (value is TokenValueListBoolean vvalue) {
					ArrayBoolean = vvalue.Value;
					}
				break;
				}
			case "ArrayInteger" : {
				if (value is TokenValueListInteger32 vvalue) {
					ArrayInteger = vvalue.Value;
					}
				break;
				}
			case "ArrayDateTime" : {
				if (value is TokenValueListDateTime vvalue) {
					ArrayDateTime = vvalue.Value;
					}
				break;
				}
			case "ArrayString" : {
				if (value is TokenValueListString vvalue) {
					ArrayString = vvalue.Value;
					}
				break;
				}
			case "ArrayBinary" : {
				if (value is TokenValueListBinary vvalue) {
					ArrayBinary = vvalue.Value;
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
			case "ArrayBoolean" : {
				return new TokenValueListBoolean (ArrayBoolean);
				}
			case "ArrayInteger" : {
				return new TokenValueListInteger32 (ArrayInteger);
				}
			case "ArrayDateTime" : {
				return new TokenValueListDateTime (ArrayDateTime);
				}
			case "ArrayString" : {
				return new TokenValueListString (ArrayString);
				}
			case "ArrayBinary" : {
				return new TokenValueListBinary (ArrayBinary);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "ArrayBoolean", new Property (typeof(TokenValueListBoolean), true)} ,
			{ "ArrayInteger", new Property (typeof(TokenValueListInteger32), true)} ,
			{ "ArrayDateTime", new Property (typeof(TokenValueListDateTime), true)} ,
			{ "ArrayString", new Property (typeof(TokenValueListString), true)} ,
			{ "ArrayBinary", new Property (typeof(TokenValueListBinary), true)} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, MultiInstance._StaticAllProperties);


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
	public new const string __Tag = "MultiArray";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new MultiArray();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new MultiArray FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as MultiArray;
			}
		var Result = new MultiArray ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
public partial class MultiStruct : MultiArray {
        /// <summary>
        /// </summary>

	public virtual MultiInstance						FieldMultiInstance  {get; set;}
        /// <summary>
        /// </summary>

	public virtual List<MultiInstance>				ArrayMultiInstance  {get; set;}
        /// <summary>
        /// </summary>

	public virtual MultiInstance						TFieldMultiInstance  {get; set;}
        /// <summary>
        /// </summary>

	public virtual List<MultiInstance>				TArrayMultiInstance  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "FieldMultiInstance" : {
				if (value is TokenValueStructObject vvalue) {
					FieldMultiInstance = vvalue.Value as MultiInstance;
					}
				break;
				}
			case "ArrayMultiInstance" : {
				if (value is TokenValueListStructObject vvalue) {
					ArrayMultiInstance = vvalue.Value as List<MultiInstance>;
					}
				break;
				}
			case "TFieldMultiInstance" : {
				if (value is TokenValueStructObject vvalue) {
					TFieldMultiInstance = vvalue.Value as MultiInstance;
					}
				break;
				}
			case "TArrayMultiInstance" : {
				if (value is TokenValueListStructObject vvalue) {
					TArrayMultiInstance = vvalue.Value as List<MultiInstance>;
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
			case "FieldMultiInstance" : {
				return new TokenValueStruct<MultiInstance> (FieldMultiInstance);
				}
			case "ArrayMultiInstance" : {
				return new TokenValueListStruct<MultiInstance> (ArrayMultiInstance);
				}
			case "TFieldMultiInstance" : {
				return new TokenValueStruct<MultiInstance> (TFieldMultiInstance);
				}
			case "TArrayMultiInstance" : {
				return new TokenValueListStruct<MultiInstance> (TArrayMultiInstance);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "FieldMultiInstance", new Property ( typeof(TokenValueStruct), false,
					()=>new MultiInstance(), ()=>new MultiInstance(), false)} ,
			{ "ArrayMultiInstance", new Property ( typeof(TokenValueListStruct), true,
					()=>new List<MultiInstance>(), ()=>new MultiInstance(), false)} ,
			{ "TFieldMultiInstance", new Property ( typeof(TokenValueStruct), false,
					null, null, true)} ,
			{ "TArrayMultiInstance", new Property ( typeof(TokenValueListStruct), true,
					()=>new List<MultiInstance>(), null, true)} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, MultiArray._StaticAllProperties);


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
	public new const string __Tag = "MultiStruct";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new MultiStruct();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new MultiStruct FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as MultiStruct;
			}
		var Result = new MultiStruct ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}



