
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
//  This file was automatically generated at 06-Feb-23 6:17:29 PM
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

using Goedel.Cryptography.Dare;
using Goedel.Mesh;


namespace Goedel.Callsign;


	/// <summary>
	///
	/// Entries that may appear in the Callsign registry log. Three types of entry 
	/// are currently defined: Entries relating to registration and transfer of callsigns,
	/// Entries relating to descriptions of callsign character pages and entries relating
	/// to cross notarization of the log by third parties.
	/// </summary>
public abstract partial class CallsignEntry : global::Goedel.Protocol.JsonObject {

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag =>__Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "CallsignEntry";

	/// <summary>
    /// Dictionary mapping tags to factory methods
    /// </summary>
	public static Dictionary<string, JsonFactoryDelegate> _TagDictionary=> _tagDictionary;
	static Dictionary<string, JsonFactoryDelegate> _tagDictionary = 
			new () {

	    {"ProfileRegistry", ProfileRegistry._Factory},
	    {"ProfileResolver", ProfileResolver._Factory},
	    {"Registration", Registration._Factory},
	    {"CatalogedRegistration", CatalogedRegistration._Factory},
	    {"Page", Page._Factory},
	    {"CharacterSpan", CharacterSpan._Factory},
	    {"Canonical", Canonical._Factory},
	    {"MapChar", MapChar._Factory},
	    {"MapString", MapString._Factory},
	    {"Notarization", Notarization._Factory},
	    {"Challenge", Challenge._Factory},
	    {"CallsignRegistrationRequest", CallsignRegistrationRequest._Factory},
	    {"CallsignRegistrationResponse", CallsignRegistrationResponse._Factory},
	    {"ProcessResultCallsignRegistration", ProcessResultCallsignRegistration._Factory}
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
	/// Describes a callsign registry.
	/// </summary>
public partial class ProfileRegistry : ProfileAccount {


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
			Combine(_StaticProperties, ProfileAccount._StaticAllProperties);


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
	public new const string __Tag = "ProfileRegistry";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ProfileRegistry();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ProfileRegistry FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ProfileRegistry;
			}
		var Result = new ProfileRegistry ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	///
	/// Describes a callsign resolver.
	/// </summary>
public partial class ProfileResolver : ProfileService {
        /// <summary>
        ///The address of the registry
        /// </summary>

	public virtual string						RegistryAddress  {get; set;}
        /// <summary>
        ///The registry that this resolver resolves.
        /// </summary>

	public virtual Enveloped<ProfileAccount>						EnvelopedProfileRegistry  {get; set;}
        /// <summary>
        ///Key currently used to encrypt data under this profile
        /// </summary>

	public virtual KeyData						CommonEncryption  {get; set;}
        /// <summary>
        ///Key used to authenticate requests made under this user account.
        ///This key SHOULD NOT be provisioned to any device except for the
        ///purpose of enabling account recovery.
        /// </summary>

	public virtual KeyData						CommonAuthentication  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "RegistryAddress" : {
				if (value is TokenValueString vvalue) {
					RegistryAddress = vvalue.Value;
					}
				break;
				}
			case "EnvelopedProfileRegistry" : {
				if (value is TokenValueStructObject vvalue) {
					EnvelopedProfileRegistry = vvalue.Value as Enveloped<ProfileAccount>;
					}
				break;
				}
			case "CommonEncryption" : {
				if (value is TokenValueStructObject vvalue) {
					CommonEncryption = vvalue.Value as KeyData;
					}
				break;
				}
			case "CommonAuthentication" : {
				if (value is TokenValueStructObject vvalue) {
					CommonAuthentication = vvalue.Value as KeyData;
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
			case "RegistryAddress" : {
				return new TokenValueString (RegistryAddress);
				}
			case "EnvelopedProfileRegistry" : {
				return new TokenValueStruct<Enveloped<ProfileAccount>> (EnvelopedProfileRegistry);
				}
			case "CommonEncryption" : {
				return new TokenValueStruct<KeyData> (CommonEncryption);
				}
			case "CommonAuthentication" : {
				return new TokenValueStruct<KeyData> (CommonAuthentication);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "RegistryAddress", new Property (typeof(TokenValueString), false)} ,
			{ "EnvelopedProfileRegistry", new Property ( typeof(TokenValueStruct), false,
					()=>new Enveloped<ProfileAccount>(), ()=>new Enveloped<ProfileAccount>(), false)} ,
			{ "CommonEncryption", new Property ( typeof(TokenValueStruct), false,
					()=>new KeyData(), ()=>new KeyData(), false)} ,
			{ "CommonAuthentication", new Property ( typeof(TokenValueStruct), false,
					()=>new KeyData(), ()=>new KeyData(), false)} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, ProfileService._StaticAllProperties);


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
	public new const string __Tag = "ProfileResolver";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ProfileResolver();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ProfileResolver FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ProfileResolver;
			}
		var Result = new ProfileResolver ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	///
	/// A callsign or Notarization registration
	/// </summary>
public partial class Registration : CallsignEntry {
        /// <summary>
        ///Unique registration identifier
        /// </summary>

	public virtual string						Id  {get; set;}
        /// <summary>
        ///The signed callsign binding
        /// </summary>

	public virtual Enveloped<CallsignBinding>						Entry  {get; set;}
        /// <summary>
        ///The UTC time instant that the claim was submitted.
        /// </summary>

	public virtual DateTime?						Submitted  {get; set;}
        /// <summary>
        ///Callsign of the registrar that made the registration request
        /// </summary>

	public virtual string						Registrar  {get; set;}
        /// <summary>
        ///If present, specifies a previous registration with the same identifier.
        /// </summary>

	public virtual string						PriorId  {get; set;}
        /// <summary>
        ///Reason for creating a registration:
        ///Initial/ Update/ Voluntary/ Administrative/ Revoke
        /// </summary>

	public virtual string						Reason  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "Id" : {
				if (value is TokenValueString vvalue) {
					Id = vvalue.Value;
					}
				break;
				}
			case "Entry" : {
				if (value is TokenValueStructObject vvalue) {
					Entry = vvalue.Value as Enveloped<CallsignBinding>;
					}
				break;
				}
			case "Submitted" : {
				if (value is TokenValueDateTime vvalue) {
					Submitted = vvalue.Value;
					}
				break;
				}
			case "Registrar" : {
				if (value is TokenValueString vvalue) {
					Registrar = vvalue.Value;
					}
				break;
				}
			case "PriorId" : {
				if (value is TokenValueString vvalue) {
					PriorId = vvalue.Value;
					}
				break;
				}
			case "Reason" : {
				if (value is TokenValueString vvalue) {
					Reason = vvalue.Value;
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
			case "Id" : {
				return new TokenValueString (Id);
				}
			case "Entry" : {
				return new TokenValueStruct<Enveloped<CallsignBinding>> (Entry);
				}
			case "Submitted" : {
				return new TokenValueDateTime (Submitted);
				}
			case "Registrar" : {
				return new TokenValueString (Registrar);
				}
			case "PriorId" : {
				return new TokenValueString (PriorId);
				}
			case "Reason" : {
				return new TokenValueString (Reason);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Id", new Property (typeof(TokenValueString), false)} ,
			{ "Entry", new Property ( typeof(TokenValueStruct), false,
					()=>new Enveloped<CallsignBinding>(), ()=>new Enveloped<CallsignBinding>(), false)} ,
			{ "Submitted", new Property (typeof(TokenValueDateTime), false)} ,
			{ "Registrar", new Property (typeof(TokenValueString), false)} ,
			{ "PriorId", new Property (typeof(TokenValueString), false)} ,
			{ "Reason", new Property (typeof(TokenValueString), false)} 
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
	public new const string __Tag = "Registration";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new Registration();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new Registration FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as Registration;
			}
		var Result = new Registration ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
public partial class CatalogedRegistration : CatalogedEntry {
        /// <summary>
        ///The canonical form of the callsign.
        /// </summary>

	public virtual string						Canonical  {get; set;}
        /// <summary>
        ///Unique registration identifier
        /// </summary>

	public virtual string						Id  {get; set;}
        /// <summary>
        ///The registration entry for the item.
        /// </summary>

	public virtual Enveloped<Registration>						EnvelopedRegistration  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "Canonical" : {
				if (value is TokenValueString vvalue) {
					Canonical = vvalue.Value;
					}
				break;
				}
			case "Id" : {
				if (value is TokenValueString vvalue) {
					Id = vvalue.Value;
					}
				break;
				}
			case "EnvelopedRegistration" : {
				if (value is TokenValueStructObject vvalue) {
					EnvelopedRegistration = vvalue.Value as Enveloped<Registration>;
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
			case "Canonical" : {
				return new TokenValueString (Canonical);
				}
			case "Id" : {
				return new TokenValueString (Id);
				}
			case "EnvelopedRegistration" : {
				return new TokenValueStruct<Enveloped<Registration>> (EnvelopedRegistration);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Canonical", new Property (typeof(TokenValueString), false)} ,
			{ "Id", new Property (typeof(TokenValueString), false)} ,
			{ "EnvelopedRegistration", new Property ( typeof(TokenValueStruct), false,
					()=>new Enveloped<Registration>(), ()=>new Enveloped<Registration>(), false)} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, CatalogedEntry._StaticAllProperties);


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
	public new const string __Tag = "CatalogedRegistration";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new CatalogedRegistration();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new CatalogedRegistration FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as CatalogedRegistration;
			}
		var Result = new CatalogedRegistration ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
public partial class Page : CallsignEntry {
        /// <summary>
        ///Character page identifier
        /// </summary>

	public virtual string						Id  {get; set;}
        /// <summary>
        ///Additional allowed pages.
        /// </summary>

	public virtual List<string>				Allow  {get; set;}
        /// <summary>
        ///Characters permitted within this code page.
        /// </summary>

	public virtual List<CharacterSpan>				CharacterSpans  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "Id" : {
				if (value is TokenValueString vvalue) {
					Id = vvalue.Value;
					}
				break;
				}
			case "Allow" : {
				if (value is TokenValueListString vvalue) {
					Allow = vvalue.Value;
					}
				break;
				}
			case "CharacterSpans" : {
				if (value is TokenValueListStructObject vvalue) {
					CharacterSpans = vvalue.Value as List<CharacterSpan>;
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
			case "Id" : {
				return new TokenValueString (Id);
				}
			case "Allow" : {
				return new TokenValueListString (Allow);
				}
			case "CharacterSpans" : {
				return new TokenValueListStruct<CharacterSpan> (CharacterSpans);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Id", new Property (typeof(TokenValueString), false)} ,
			{ "Allow", new Property (typeof(TokenValueListString), true)} ,
			{ "CharacterSpans", new Property ( typeof(TokenValueListStruct), true,
					()=>new List<CharacterSpan>(), null, true)} 
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
	public new const string __Tag = "Page";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new Page();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new Page FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as Page;
			}
		var Result = new Page ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
public partial class CharacterSpan : CallsignEntry {
        /// <summary>
        ///The first character in the range (inclusive)
        /// </summary>

	public virtual int?						First  {get; set;}
        /// <summary>
        ///The last character in the range (inclusive), if ommitted or
        ///equal to zero, this is the same as Last.
        /// </summary>

	public virtual int?						Last  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "First" : {
				if (value is TokenValueInteger32 vvalue) {
					First = vvalue.Value;
					}
				break;
				}
			case "Last" : {
				if (value is TokenValueInteger32 vvalue) {
					Last = vvalue.Value;
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
			case "First" : {
				return new TokenValueInteger32 (First);
				}
			case "Last" : {
				return new TokenValueInteger32 (Last);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "First", new Property (typeof(TokenValueInteger32), false)} ,
			{ "Last", new Property (typeof(TokenValueInteger32), false)} 
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
	public new const string __Tag = "CharacterSpan";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new CharacterSpan();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new CharacterSpan FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as CharacterSpan;
			}
		var Result = new CharacterSpan ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	///
	/// Canonical character span.
	/// </summary>
public partial class Canonical : CharacterSpan {


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
			Combine(_StaticProperties, CharacterSpan._StaticAllProperties);


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
	public new const string __Tag = "Canonical";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new Canonical();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new Canonical FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as Canonical;
			}
		var Result = new Canonical ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	///
	/// Specifies a variant mapping the range of characters First..First+n to
	/// a range of characters Target..Target+n. Where n = Last - First+1
	/// </summary>
public partial class MapChar : CharacterSpan {
        /// <summary>
        ///The character that First is mapped to.
        /// </summary>

	public virtual int?						Target  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "Target" : {
				if (value is TokenValueInteger32 vvalue) {
					Target = vvalue.Value;
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
			case "Target" : {
				return new TokenValueInteger32 (Target);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Target", new Property (typeof(TokenValueInteger32), false)} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, CharacterSpan._StaticAllProperties);


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
	public new const string __Tag = "MapChar";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new MapChar();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new MapChar FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as MapChar;
			}
		var Result = new MapChar ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	///
	/// Specifies a mapping of non canonical characters in the range specified by 
	/// First..Last to the string Target.
	/// </summary>
public partial class MapString : CharacterSpan {
        /// <summary>
        ///Specifies a character string that the Source character(s) are mapped to.
        ///If count is greater than 1, all the characters map to the same string.
        /// </summary>

	public virtual string						Target  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "Target" : {
				if (value is TokenValueString vvalue) {
					Target = vvalue.Value;
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
			case "Target" : {
				return new TokenValueString (Target);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Target", new Property (typeof(TokenValueString), false)} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, CharacterSpan._StaticAllProperties);


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
	public new const string __Tag = "MapString";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new MapString();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new MapString FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as MapString;
			}
		var Result = new MapString ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
public partial class Notarization : CallsignEntry {
        /// <summary>
        ///Enveloped witness value of a specific append only log.
        /// </summary>

	public virtual List<Enveloped<Witness>>				Entries  {get; set;}
        /// <summary>
        ///Proof path validating the previous notary token that was entered in the
        ///log.
        /// </summary>

	public virtual Proof						Proof  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "Entries" : {
				if (value is TokenValueListStructObject vvalue) {
					Entries = vvalue.Value as List<Enveloped<Witness>>;
					}
				break;
				}
			case "Proof" : {
				if (value is TokenValueStructObject vvalue) {
					Proof = vvalue.Value as Proof;
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
				return new TokenValueListStruct<Enveloped<Witness>> (Entries);
				}
			case "Proof" : {
				return new TokenValueStruct<Proof> (Proof);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Entries", new Property ( typeof(TokenValueListStruct), true,
					()=>new List<Enveloped<Witness>>(), ()=>new Enveloped<Witness>(), false)} ,
			{ "Proof", new Property ( typeof(TokenValueStruct), false,
					()=>new Proof(), ()=>new Proof(), false)} 
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
	public new const string __Tag = "Notarization";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new Notarization();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new Notarization FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as Notarization;
			}
		var Result = new Notarization ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	///
	/// Registers a challenge to one or more callsigns that have been registered.
	/// </summary>
public partial class Challenge : Assertion {
        /// <summary>
        ///The callsigns subject to challenge
        /// </summary>

	public virtual List<string>				Subjects  {get; set;}
        /// <summary>
        ///The basis for the challenge
        /// </summary>

	public virtual List<string>				Basis  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "Subjects" : {
				if (value is TokenValueListString vvalue) {
					Subjects = vvalue.Value;
					}
				break;
				}
			case "Basis" : {
				if (value is TokenValueListString vvalue) {
					Basis = vvalue.Value;
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
			case "Subjects" : {
				return new TokenValueListString (Subjects);
				}
			case "Basis" : {
				return new TokenValueListString (Basis);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Subjects", new Property (typeof(TokenValueListString), true)} ,
			{ "Basis", new Property (typeof(TokenValueListString), true)} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, Assertion._StaticAllProperties);


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
	public new const string __Tag = "Challenge";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new Challenge();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new Challenge FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as Challenge;
			}
		var Result = new Challenge ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	///
	/// Connection request message. This message contains the information
	/// </summary>
public partial class CallsignRegistrationRequest : MessageValidated {
        /// <summary>
        ///The enveloped binnding of the callsign to the profile.	
        /// </summary>

	public virtual Enveloped<CallsignBinding>						EnvelopedCallsignBinding  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "EnvelopedCallsignBinding" : {
				if (value is TokenValueStructObject vvalue) {
					EnvelopedCallsignBinding = vvalue.Value as Enveloped<CallsignBinding>;
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
			case "EnvelopedCallsignBinding" : {
				return new TokenValueStruct<Enveloped<CallsignBinding>> (EnvelopedCallsignBinding);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "EnvelopedCallsignBinding", new Property ( typeof(TokenValueStruct), false,
					()=>new Enveloped<CallsignBinding>(), ()=>new Enveloped<CallsignBinding>(), false)} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, MessageValidated._StaticAllProperties);


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
	public new const string __Tag = "CallsignRegistrationRequest";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new CallsignRegistrationRequest();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new CallsignRegistrationRequest FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as CallsignRegistrationRequest;
			}
		var Result = new CallsignRegistrationRequest ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
public partial class CallsignRegistrationResponse : Message {
        /// <summary>
        ///True if and only if a new registration was created.
        /// </summary>

	public virtual bool?						Registered  {get; set;}
        /// <summary>
        ///The resulting catalog entry if accepted or the prior registration otherwise.
        /// </summary>

	public virtual CatalogedRegistration						CatalogedRegistration  {get; set;}
        /// <summary>
        ///Reason for refusing the registration.
        /// </summary>

	public virtual string						Reason  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "Registered" : {
				if (value is TokenValueBoolean vvalue) {
					Registered = vvalue.Value;
					}
				break;
				}
			case "CatalogedRegistration" : {
				if (value is TokenValueStructObject vvalue) {
					CatalogedRegistration = vvalue.Value as CatalogedRegistration;
					}
				break;
				}
			case "Reason" : {
				if (value is TokenValueString vvalue) {
					Reason = vvalue.Value;
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
			case "Registered" : {
				return new TokenValueBoolean (Registered);
				}
			case "CatalogedRegistration" : {
				return new TokenValueStruct<CatalogedRegistration> (CatalogedRegistration);
				}
			case "Reason" : {
				return new TokenValueString (Reason);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Registered", new Property (typeof(TokenValueBoolean), false)} ,
			{ "CatalogedRegistration", new Property ( typeof(TokenValueStruct), false,
					()=>new CatalogedRegistration(), ()=>new CatalogedRegistration(), false)} ,
			{ "Reason", new Property (typeof(TokenValueString), false)} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, Message._StaticAllProperties);


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
	public new const string __Tag = "CallsignRegistrationResponse";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new CallsignRegistrationResponse();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new CallsignRegistrationResponse FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as CallsignRegistrationResponse;
			}
		var Result = new CallsignRegistrationResponse ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
public partial class ProcessResultCallsignRegistration : ProcessResult {
        /// <summary>
        /// </summary>

	public virtual CallsignRegistrationResponse						CallsignRegistrationResponse  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "CallsignRegistrationResponse" : {
				if (value is TokenValueStructObject vvalue) {
					CallsignRegistrationResponse = vvalue.Value as CallsignRegistrationResponse;
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
			case "CallsignRegistrationResponse" : {
				return new TokenValueStruct<CallsignRegistrationResponse> (CallsignRegistrationResponse);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "CallsignRegistrationResponse", new Property ( typeof(TokenValueStruct), false,
					()=>new CallsignRegistrationResponse(), ()=>new CallsignRegistrationResponse(), false)} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, ProcessResult._StaticAllProperties);


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
	public new const string __Tag = "ProcessResultCallsignRegistration";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ProcessResultCallsignRegistration();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ProcessResultCallsignRegistration FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ProcessResultCallsignRegistration;
			}
		var Result = new ProcessResultCallsignRegistration ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}



