
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
//  This file was automatically generated at 08-Feb-23 5:35:27 PM
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

using Goedel.Cryptography.Jose;


namespace Goedel.Cryptography.Dare;


	/// <summary>
	///
	/// Support classes for JSON Object Signing and Encryption
	/// </summary>
public abstract partial class Dare : global::Goedel.Protocol.JsonObject {

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag =>__Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "Dare";

	/// <summary>
    /// Dictionary mapping tags to factory methods
    /// </summary>
	public static Dictionary<string, JsonFactoryDelegate> _TagDictionary=> _tagDictionary;
	static Dictionary<string, JsonFactoryDelegate> _tagDictionary = 
			new () {

	    {"DareEnvelopeSequence", DareEnvelopeSequence._Factory},
	    {"DareTrailer", DareTrailer._Factory},
	    {"DareHeader", DareHeader._Factory},
	    {"ContentMeta", ContentMeta._Factory},
	    {"DareSignature", DareSignature._Factory},
	    {"IntervalSignature", IntervalSignature._Factory},
	    {"SignedEnvelope", SignedEnvelope._Factory},
	    {"X509Certificate", X509Certificate._Factory},
	    {"DareRecipient", DareRecipient._Factory},
	    {"DarePolicy", DarePolicy._Factory},
	    {"FileEntry", FileEntry._Factory},
	    {"Witness", Witness._Factory},
	    {"Proof", Proof._Factory}
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
	/// A DARE envelope containing Header, EDS and Trailer in JSON object encoding.
	/// Since a DAREMessage is almost invariably presented in JSON sequence or
	/// compact encoding, use of the DAREMessage subclass is preferred.
	/// Although a DARE envelope is functionally an object, it is serialized as 
	/// an ordered sequence. This ensures that the envelope header field will always
	/// precede the body in a serialization, this allowing processing of the header
	/// information to be performed before the entire body has been received.
	/// </summary>
public partial class DareEnvelopeSequence : Dare {
        /// <summary>
        ///The envelope header. May specify the key exchange data, pre-signature 
        ///or signature data, cloaked headers and/or encrypted data sequences.
        /// </summary>

	public virtual DareHeader						Header  {get; set;}
        /// <summary>
        ///The envelope body
        /// </summary>

	public virtual byte[]						Body  {get; set;}
        /// <summary>
        ///The envelope trailer. If present, this contains the signature.
        /// </summary>

	public virtual DareTrailer						Trailer  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "Header" : {
				if (value is TokenValueStructObject vvalue) {
					Header = vvalue.Value as DareHeader;
					}
				break;
				}
			case "Body" : {
				if (value is TokenValueBinary vvalue) {
					Body = vvalue.Value;
					}
				break;
				}
			case "Trailer" : {
				if (value is TokenValueStructObject vvalue) {
					Trailer = vvalue.Value as DareTrailer;
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
			case "Header" : {
				return new TokenValueStruct<DareHeader> (Header);
				}
			case "Body" : {
				return new TokenValueBinary (Body);
				}
			case "Trailer" : {
				return new TokenValueStruct<DareTrailer> (Trailer);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Header", new Property ( typeof(TokenValueStruct), false,
					()=>new DareHeader(), ()=>new DareHeader(), false)} ,
			{ "Body", new Property (typeof(TokenValueBinary), false)} ,
			{ "Trailer", new Property ( typeof(TokenValueStruct), false,
					()=>new DareTrailer(), ()=>new DareTrailer(), false)} 
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
	public new const string __Tag = "DareEnvelopeSequence";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new DareEnvelopeSequence();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new DareEnvelopeSequence FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as DareEnvelopeSequence;
			}
		var Result = new DareEnvelopeSequence ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	///
	/// A DARE envelope Trailer
	/// </summary>
public partial class DareTrailer : Dare {
        /// <summary>
        ///A list of signatures.
        ///A envelope trailer MUST NOT contain a signatures field if the header contains 
        ///a signatures field.
        /// </summary>

	public virtual List<DareSignature>				Signatures  {get; set;}
        /// <summary>
        ///A list of signatures over the apex digest.
        ///A envelope trailer MUST NOT contain av apex field if the header contains 
        ///a signatures field.
        /// </summary>

	public virtual List<DareSignature>				ApexSignatures  {get; set;}
        /// <summary>
        ///Contains a DAREHeader object 
        /// </summary>

	public virtual byte[]						SignedData  {get; set;}
        /// <summary>
        ///If present, contains the digest of the Payload.
        /// </summary>

	public virtual byte[]						PayloadDigest  {get; set;}
        /// <summary>
        ///If present, contains the digest of the PayloadDigest values of this
        ///frame and the frame immediately preceding.
        /// </summary>

	public virtual byte[]						ChainDigest  {get; set;}
        /// <summary>
        ///If present, contains the Binary Merkle Tree digest value.
        /// </summary>

	public virtual byte[]						TreeDigest  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "signatures" : {
				if (value is TokenValueListStructObject vvalue) {
					Signatures = vvalue.Value as List<DareSignature>;
					}
				break;
				}
			case "ApexSignatures" : {
				if (value is TokenValueListStructObject vvalue) {
					ApexSignatures = vvalue.Value as List<DareSignature>;
					}
				break;
				}
			case "SignedData" : {
				if (value is TokenValueBinary vvalue) {
					SignedData = vvalue.Value;
					}
				break;
				}
			case "PayloadDigest" : {
				if (value is TokenValueBinary vvalue) {
					PayloadDigest = vvalue.Value;
					}
				break;
				}
			case "ChainDigest" : {
				if (value is TokenValueBinary vvalue) {
					ChainDigest = vvalue.Value;
					}
				break;
				}
			case "TreeDigest" : {
				if (value is TokenValueBinary vvalue) {
					TreeDigest = vvalue.Value;
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
			case "signatures" : {
				return new TokenValueListStruct<DareSignature> (Signatures);
				}
			case "ApexSignatures" : {
				return new TokenValueListStruct<DareSignature> (ApexSignatures);
				}
			case "SignedData" : {
				return new TokenValueBinary (SignedData);
				}
			case "PayloadDigest" : {
				return new TokenValueBinary (PayloadDigest);
				}
			case "ChainDigest" : {
				return new TokenValueBinary (ChainDigest);
				}
			case "TreeDigest" : {
				return new TokenValueBinary (TreeDigest);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "signatures", new Property ( typeof(TokenValueListStruct), true,
					()=>new List<DareSignature>(), ()=>new DareSignature(), false)} ,
			{ "ApexSignatures", new Property ( typeof(TokenValueListStruct), true,
					()=>new List<DareSignature>(), ()=>new DareSignature(), false)} ,
			{ "SignedData", new Property (typeof(TokenValueBinary), false)} ,
			{ "PayloadDigest", new Property (typeof(TokenValueBinary), false)} ,
			{ "ChainDigest", new Property (typeof(TokenValueBinary), false)} ,
			{ "TreeDigest", new Property (typeof(TokenValueBinary), false)} 
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
	public new const string __Tag = "DareTrailer";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new DareTrailer();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new DareTrailer FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as DareTrailer;
			}
		var Result = new DareTrailer ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	///
	/// A DARE Envelope Header. Since any field that is present in a trailer MAY be 
	/// placed in a header instead, the envelope header inherits from the trailer.
	/// </summary>
public partial class DareHeader : DareTrailer {
        /// <summary>
        ///Unique identifier
        /// </summary>

	public virtual string						EnvelopeId  {get; set;}
        /// <summary>
        ///The encryption algorithm as specified in JWE
        /// </summary>

	public virtual string						EncryptionAlgorithm  {get; set;}
        /// <summary>
        ///Digest Algorithm. If specified, tells decoder that the digest algorithm is used to
        ///construct a signature over the envelope payload.
        /// </summary>

	public virtual string						DigestAlgorithm  {get; set;}
        /// <summary>
        ///Base seed identifier.
        /// </summary>

	public virtual string						KeyIdentifier  {get; set;}
        /// <summary>
        ///Salt value used to derrive cryptographic parameters for the content data.
        /// </summary>

	public virtual byte[]						Salt  {get; set;}
        /// <summary>
        ///Hash of the Salt value used to derrive cryptographic parameters for the content data.
        ///This field SHOULD NOT be present if the Salt field is present. It is used to
        ///allow the salt value to be erased (thus rendering the payload content irrecoverable)
        ///without affecting the ability to calculate the payload digest value.
        /// </summary>

	public virtual byte[]						Malt  {get; set;}
        /// <summary>
        ///If present in a header or trailer, specifies an encrypted data block 
        ///containing additional header fields whose values override those specified 
        ///in the envelope and context headers.
        ///When specified in a header, a cloaked field MAY be used to conceal metadata 
        ///(content type, compression) and/or to specify an additional layer of key exchange. 
        ///That applies to both the envelope body and to headers specified within the cloaked 
        ///header.
        ///Processing of cloaked data is described in…
        /// </summary>

	public virtual byte[]						Cloaked  {get; set;}
        /// <summary>
        ///If present, the Annotations field contains a sequence of Encrypted Data 
        ///Segments encrypted under the envelope base seed. The interpretation of these fields 
        ///is application specific.
        /// </summary>

	public virtual List<byte[]>				EDSS  {get; set;}
        /// <summary>
        ///A list of recipient key exchange information blocks.
        /// </summary>

	public virtual List<DareRecipient>				Recipients  {get; set;}
        /// <summary>
        ///A DARE security policy governing future additions to the container.
        /// </summary>

	public virtual DarePolicy						Policy  {get; set;}
        /// <summary>
        ///If present contains a JSON encoded ContentInfo structure which specifies
        ///plaintext content metadata and forms one of the inputs to the envelope digest value.
        /// </summary>

	public virtual byte[]						ContentMetaData  {get; set;}
        /// <summary>
        ///Information that describes container information
        /// </summary>

	public virtual SequenceInfo						SequenceInfo  {get; set;}
        /// <summary>
        ///An index of records in the current container up to but not including
        ///this one.
        /// </summary>

	public virtual SequenceIndex						SequenceIndex  {get; set;}
        /// <summary>
        ///Date on which the envelope was received.
        /// </summary>

	public virtual DateTime?						Received  {get; set;}
        /// <summary>
        ///HTML document containing cover text to be presented if the document cannot be decrypted.
        /// </summary>

	public virtual byte[]						Cover  {get; set;}
        /// <summary>
        ///Bitmask used to identify a container within a group for use in update notification
        ///etc.
        /// </summary>

	public virtual byte[]						Bitmask  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "EnvelopeId" : {
				if (value is TokenValueString vvalue) {
					EnvelopeId = vvalue.Value;
					}
				break;
				}
			case "enc" : {
				if (value is TokenValueString vvalue) {
					EncryptionAlgorithm = vvalue.Value;
					}
				break;
				}
			case "dig" : {
				if (value is TokenValueString vvalue) {
					DigestAlgorithm = vvalue.Value;
					}
				break;
				}
			case "kid" : {
				if (value is TokenValueString vvalue) {
					KeyIdentifier = vvalue.Value;
					}
				break;
				}
			case "Salt" : {
				if (value is TokenValueBinary vvalue) {
					Salt = vvalue.Value;
					}
				break;
				}
			case "Malt" : {
				if (value is TokenValueBinary vvalue) {
					Malt = vvalue.Value;
					}
				break;
				}
			case "cloaked" : {
				if (value is TokenValueBinary vvalue) {
					Cloaked = vvalue.Value;
					}
				break;
				}
			case "annotations" : {
				if (value is TokenValueListBinary vvalue) {
					EDSS = vvalue.Value;
					}
				break;
				}
			case "recipients" : {
				if (value is TokenValueListStructObject vvalue) {
					Recipients = vvalue.Value as List<DareRecipient>;
					}
				break;
				}
			case "policy" : {
				if (value is TokenValueStructObject vvalue) {
					Policy = vvalue.Value as DarePolicy;
					}
				break;
				}
			case "ContentMetaData" : {
				if (value is TokenValueBinary vvalue) {
					ContentMetaData = vvalue.Value;
					}
				break;
				}
			case "SequenceInfo" : {
				if (value is TokenValueStructObject vvalue) {
					SequenceInfo = vvalue.Value as SequenceInfo;
					}
				break;
				}
			case "SequenceIndex" : {
				if (value is TokenValueStructObject vvalue) {
					SequenceIndex = vvalue.Value as SequenceIndex;
					}
				break;
				}
			case "Received" : {
				if (value is TokenValueDateTime vvalue) {
					Received = vvalue.Value;
					}
				break;
				}
			case "Cover" : {
				if (value is TokenValueBinary vvalue) {
					Cover = vvalue.Value;
					}
				break;
				}
			case "Bitmask" : {
				if (value is TokenValueBinary vvalue) {
					Bitmask = vvalue.Value;
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
			case "EnvelopeId" : {
				return new TokenValueString (EnvelopeId);
				}
			case "enc" : {
				return new TokenValueString (EncryptionAlgorithm);
				}
			case "dig" : {
				return new TokenValueString (DigestAlgorithm);
				}
			case "kid" : {
				return new TokenValueString (KeyIdentifier);
				}
			case "Salt" : {
				return new TokenValueBinary (Salt);
				}
			case "Malt" : {
				return new TokenValueBinary (Malt);
				}
			case "cloaked" : {
				return new TokenValueBinary (Cloaked);
				}
			case "annotations" : {
				return new TokenValueListBinary (EDSS);
				}
			case "recipients" : {
				return new TokenValueListStruct<DareRecipient> (Recipients);
				}
			case "policy" : {
				return new TokenValueStruct<DarePolicy> (Policy);
				}
			case "ContentMetaData" : {
				return new TokenValueBinary (ContentMetaData);
				}
			case "SequenceInfo" : {
				return new TokenValueStruct<SequenceInfo> (SequenceInfo);
				}
			case "SequenceIndex" : {
				return new TokenValueStruct<SequenceIndex> (SequenceIndex);
				}
			case "Received" : {
				return new TokenValueDateTime (Received);
				}
			case "Cover" : {
				return new TokenValueBinary (Cover);
				}
			case "Bitmask" : {
				return new TokenValueBinary (Bitmask);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "EnvelopeId", new Property (typeof(TokenValueString), false)} ,
			{ "enc", new Property (typeof(TokenValueString), false)} ,
			{ "dig", new Property (typeof(TokenValueString), false)} ,
			{ "kid", new Property (typeof(TokenValueString), false)} ,
			{ "Salt", new Property (typeof(TokenValueBinary), false)} ,
			{ "Malt", new Property (typeof(TokenValueBinary), false)} ,
			{ "cloaked", new Property (typeof(TokenValueBinary), false)} ,
			{ "annotations", new Property (typeof(TokenValueListBinary), true)} ,
			{ "recipients", new Property ( typeof(TokenValueListStruct), true,
					()=>new List<DareRecipient>(), ()=>new DareRecipient(), false)} ,
			{ "policy", new Property ( typeof(TokenValueStruct), false,
					()=>new DarePolicy(), ()=>new DarePolicy(), false)} ,
			{ "ContentMetaData", new Property (typeof(TokenValueBinary), false)} ,
			{ "SequenceInfo", new Property ( typeof(TokenValueStruct), false,
					()=>new SequenceInfo(), ()=>new SequenceInfo(), false)} ,
			{ "SequenceIndex", new Property ( typeof(TokenValueStruct), false,
					()=>new SequenceIndex(), ()=>new SequenceIndex(), false)} ,
			{ "Received", new Property (typeof(TokenValueDateTime), false)} ,
			{ "Cover", new Property (typeof(TokenValueBinary), false)} ,
			{ "Bitmask", new Property (typeof(TokenValueBinary), false)} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, DareTrailer._StaticAllProperties);


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
	public new const string __Tag = "DareHeader";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new DareHeader();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new DareHeader FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as DareHeader;
			}
		var Result = new DareHeader ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
public partial class ContentMeta : Dare {
        /// <summary>
        ///Unique object identifier
        /// </summary>

	public virtual string						UniqueId  {get; set;}
        /// <summary>
        ///List of labels that are applied to the payload of the frame.
        /// </summary>

	public virtual List<string>				Labels  {get; set;}
        /// <summary>
        ///List of key/value pairs describing the payload of the frame.
        /// </summary>

	public virtual List<KeyValue>				KeyValues  {get; set;}
        /// <summary>
        ///The mesh message type
        /// </summary>

	public virtual string						MessageType  {get; set;}
        /// <summary>
        ///The content type field as specified in JWE
        /// </summary>

	public virtual string						ContentType  {get; set;}
        /// <summary>
        ///List of filename paths for the payload of the frame.
        /// </summary>

	public virtual List<string>				Paths  {get; set;}
        /// <summary>
        ///The original filename under which the data was stored.
        /// </summary>

	public virtual string						Filename  {get; set;}
        /// <summary>
        ///Operation on the header
        /// </summary>

	public virtual string						Event  {get; set;}
        /// <summary>
        ///Initial creation date.
        /// </summary>

	public virtual DateTime?						Created  {get; set;}
        /// <summary>
        ///Date of last modification.
        /// </summary>

	public virtual DateTime?						Modified  {get; set;}
        /// <summary>
        ///Date at which the associated transaction will expire
        /// </summary>

	public virtual DateTime?						Expire  {get; set;}
        /// <summary>
        ///Frame number of the first object instance value.
        /// </summary>

	public virtual int?						First  {get; set;}
        /// <summary>
        ///Frame number of the immediately prior object instance value	
        /// </summary>

	public virtual int?						Previous  {get; set;}
        /// <summary>
        ///Information describing the file entry on disk.
        /// </summary>

	public virtual FileEntry						FileEntry  {get; set;}


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
			case "Labels" : {
				if (value is TokenValueListString vvalue) {
					Labels = vvalue.Value;
					}
				break;
				}
			case "KeyValues" : {
				if (value is TokenValueListStructObject vvalue) {
					KeyValues = vvalue.Value as List<KeyValue>;
					}
				break;
				}
			case "MessageType" : {
				if (value is TokenValueString vvalue) {
					MessageType = vvalue.Value;
					}
				break;
				}
			case "cty" : {
				if (value is TokenValueString vvalue) {
					ContentType = vvalue.Value;
					}
				break;
				}
			case "Paths" : {
				if (value is TokenValueListString vvalue) {
					Paths = vvalue.Value;
					}
				break;
				}
			case "Filename" : {
				if (value is TokenValueString vvalue) {
					Filename = vvalue.Value;
					}
				break;
				}
			case "Event" : {
				if (value is TokenValueString vvalue) {
					Event = vvalue.Value;
					}
				break;
				}
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
			case "Expire" : {
				if (value is TokenValueDateTime vvalue) {
					Expire = vvalue.Value;
					}
				break;
				}
			case "First" : {
				if (value is TokenValueInteger32 vvalue) {
					First = vvalue.Value;
					}
				break;
				}
			case "Previous" : {
				if (value is TokenValueInteger32 vvalue) {
					Previous = vvalue.Value;
					}
				break;
				}
			case "FileEntry" : {
				if (value is TokenValueStructObject vvalue) {
					FileEntry = vvalue.Value as FileEntry;
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
			case "Labels" : {
				return new TokenValueListString (Labels);
				}
			case "KeyValues" : {
				return new TokenValueListStruct<KeyValue> (KeyValues);
				}
			case "MessageType" : {
				return new TokenValueString (MessageType);
				}
			case "cty" : {
				return new TokenValueString (ContentType);
				}
			case "Paths" : {
				return new TokenValueListString (Paths);
				}
			case "Filename" : {
				return new TokenValueString (Filename);
				}
			case "Event" : {
				return new TokenValueString (Event);
				}
			case "Created" : {
				return new TokenValueDateTime (Created);
				}
			case "Modified" : {
				return new TokenValueDateTime (Modified);
				}
			case "Expire" : {
				return new TokenValueDateTime (Expire);
				}
			case "First" : {
				return new TokenValueInteger32 (First);
				}
			case "Previous" : {
				return new TokenValueInteger32 (Previous);
				}
			case "FileEntry" : {
				return new TokenValueStruct<FileEntry> (FileEntry);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "UniqueId", new Property (typeof(TokenValueString), false)} ,
			{ "Labels", new Property (typeof(TokenValueListString), true)} ,
			{ "KeyValues", new Property ( typeof(TokenValueListStruct), true,
					()=>new List<KeyValue>(), ()=>new KeyValue(), false)} ,
			{ "MessageType", new Property (typeof(TokenValueString), false)} ,
			{ "cty", new Property (typeof(TokenValueString), false)} ,
			{ "Paths", new Property (typeof(TokenValueListString), true)} ,
			{ "Filename", new Property (typeof(TokenValueString), false)} ,
			{ "Event", new Property (typeof(TokenValueString), false)} ,
			{ "Created", new Property (typeof(TokenValueDateTime), false)} ,
			{ "Modified", new Property (typeof(TokenValueDateTime), false)} ,
			{ "Expire", new Property (typeof(TokenValueDateTime), false)} ,
			{ "First", new Property (typeof(TokenValueInteger32), false)} ,
			{ "Previous", new Property (typeof(TokenValueInteger32), false)} ,
			{ "FileEntry", new Property ( typeof(TokenValueStruct), false,
					()=>new FileEntry(), ()=>new FileEntry(), false)} 
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
	public new const string __Tag = "ContentMeta";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ContentMeta();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ContentMeta FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ContentMeta;
			}
		var Result = new ContentMeta ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	///
	/// The signature value
	/// </summary>
public partial class DareSignature : Dare {
        /// <summary>
        ///Digest algorithm hint. Specifying the digest algorithm to be applied
        ///to the envelope body allows the body to be processed in streaming mode.
        /// </summary>

	public virtual string						Dig  {get; set;}
        /// <summary>
        ///Key exchange algorithm
        /// </summary>

	public virtual string						Alg  {get; set;}
        /// <summary>
        ///Key identifier of the signature key.
        /// </summary>

	public virtual string						KeyIdentifier  {get; set;}
        /// <summary>
        ///PKIX certificate of signer.
        /// </summary>

	public virtual X509Certificate						Certificate  {get; set;}
        /// <summary>
        ///PKIX certificates that establish a trust path for the signer.
        /// </summary>

	public virtual X509Certificate						Path  {get; set;}
        /// <summary>
        ///The data description that was signed.
        /// </summary>

	public virtual byte[]						Manifest  {get; set;}
        /// <summary>
        ///The signature value as an Enhanced Data Sequence under the envelope base seed.
        /// </summary>

	public virtual byte[]						SignatureValue  {get; set;}
        /// <summary>
        ///The signature witness value used on an encrypted envelope to demonstrate that 
        ///the signature was authorized by a party with actual knowledge of the encryption 
        ///key used to encrypt the envelope.
        /// </summary>

	public virtual byte[]						WitnessValue  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "dig" : {
				if (value is TokenValueString vvalue) {
					Dig = vvalue.Value;
					}
				break;
				}
			case "alg" : {
				if (value is TokenValueString vvalue) {
					Alg = vvalue.Value;
					}
				break;
				}
			case "kid" : {
				if (value is TokenValueString vvalue) {
					KeyIdentifier = vvalue.Value;
					}
				break;
				}
			case "cert" : {
				if (value is TokenValueStructObject vvalue) {
					Certificate = vvalue.Value as X509Certificate;
					}
				break;
				}
			case "path" : {
				if (value is TokenValueStructObject vvalue) {
					Path = vvalue.Value as X509Certificate;
					}
				break;
				}
			case "Manifest" : {
				if (value is TokenValueBinary vvalue) {
					Manifest = vvalue.Value;
					}
				break;
				}
			case "signature" : {
				if (value is TokenValueBinary vvalue) {
					SignatureValue = vvalue.Value;
					}
				break;
				}
			case "witness" : {
				if (value is TokenValueBinary vvalue) {
					WitnessValue = vvalue.Value;
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
			case "dig" : {
				return new TokenValueString (Dig);
				}
			case "alg" : {
				return new TokenValueString (Alg);
				}
			case "kid" : {
				return new TokenValueString (KeyIdentifier);
				}
			case "cert" : {
				return new TokenValueStruct<X509Certificate> (Certificate);
				}
			case "path" : {
				return new TokenValueStruct<X509Certificate> (Path);
				}
			case "Manifest" : {
				return new TokenValueBinary (Manifest);
				}
			case "signature" : {
				return new TokenValueBinary (SignatureValue);
				}
			case "witness" : {
				return new TokenValueBinary (WitnessValue);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "dig", new Property (typeof(TokenValueString), false)} ,
			{ "alg", new Property (typeof(TokenValueString), false)} ,
			{ "kid", new Property (typeof(TokenValueString), false)} ,
			{ "cert", new Property ( typeof(TokenValueStruct), false,
					()=>new X509Certificate(), ()=>new X509Certificate(), false)} ,
			{ "path", new Property ( typeof(TokenValueStruct), false,
					()=>new X509Certificate(), ()=>new X509Certificate(), false)} ,
			{ "Manifest", new Property (typeof(TokenValueBinary), false)} ,
			{ "signature", new Property (typeof(TokenValueBinary), false)} ,
			{ "witness", new Property (typeof(TokenValueBinary), false)} 
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
	public new const string __Tag = "DareSignature";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new DareSignature();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new DareSignature FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as DareSignature;
			}
		var Result = new DareSignature ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	///
	/// A digital signature over one or more envelopes consisting of an apex signature value 
	/// </summary>
public partial class IntervalSignature : Dare {
        /// <summary>
        ///The index number of the frame containing the apex signature.
        /// </summary>

	public virtual int?						Index  {get; set;}
        /// <summary>
        ///The signed envelopes in order, lowest index first.
        /// </summary>

	public virtual SignedEnvelope						Envelopes  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "Index" : {
				if (value is TokenValueInteger32 vvalue) {
					Index = vvalue.Value;
					}
				break;
				}
			case "Envelopes" : {
				if (value is TokenValueStructObject vvalue) {
					Envelopes = vvalue.Value as SignedEnvelope;
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
			case "Index" : {
				return new TokenValueInteger32 (Index);
				}
			case "Envelopes" : {
				return new TokenValueStruct<SignedEnvelope> (Envelopes);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Index", new Property (typeof(TokenValueInteger32), false)} ,
			{ "Envelopes", new Property ( typeof(TokenValueStruct), false,
					()=>new SignedEnvelope(), ()=>new SignedEnvelope(), false)} 
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
	public new const string __Tag = "IntervalSignature";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new IntervalSignature();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new IntervalSignature FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as IntervalSignature;
			}
		var Result = new IntervalSignature ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	///
	/// An entry describing one signed envelope within an IntervalSignature
	/// </summary>
public partial class SignedEnvelope : Dare {
        /// <summary>
        ///The index number of the envelope.
        /// </summary>

	public virtual int?						Index  {get; set;}
        /// <summary>
        ///The digests required to complete the verification of the signature.		
        /// </summary>

	public virtual List<byte[]>				Digest  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "Index" : {
				if (value is TokenValueInteger32 vvalue) {
					Index = vvalue.Value;
					}
				break;
				}
			case "Digest" : {
				if (value is TokenValueListBinary vvalue) {
					Digest = vvalue.Value;
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
			case "Index" : {
				return new TokenValueInteger32 (Index);
				}
			case "Digest" : {
				return new TokenValueListBinary (Digest);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Index", new Property (typeof(TokenValueInteger32), false)} ,
			{ "Digest", new Property (typeof(TokenValueListBinary), true)} 
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
	public new const string __Tag = "SignedEnvelope";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new SignedEnvelope();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new SignedEnvelope FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as SignedEnvelope;
			}
		var Result = new SignedEnvelope ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
public partial class X509Certificate : Dare {
        /// <summary>
        ///URL identifying an X.509 public key certificate
        /// </summary>

	public virtual string						X5u  {get; set;}
        /// <summary>
        ///An X.509 public key certificate
        /// </summary>

	public virtual byte[]						X5  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "x5u" : {
				if (value is TokenValueString vvalue) {
					X5u = vvalue.Value;
					}
				break;
				}
			case "x5c" : {
				if (value is TokenValueBinary vvalue) {
					X5 = vvalue.Value;
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
			case "x5u" : {
				return new TokenValueString (X5u);
				}
			case "x5c" : {
				return new TokenValueBinary (X5);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "x5u", new Property (typeof(TokenValueString), false)} ,
			{ "x5c", new Property (typeof(TokenValueBinary), false)} 
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
	public new const string __Tag = "X509Certificate";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new X509Certificate();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new X509Certificate FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as X509Certificate;
			}
		var Result = new X509Certificate ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	///
	/// Recipient information
	/// </summary>
public partial class DareRecipient : Dare {
        /// <summary>
        ///Key identifier for the encryption key.
        ///The Key identifier MUST be either a UDF fingerprint of a key or a Group Key Identifier
        /// </summary>

	public virtual string						KeyIdentifier  {get; set;}
        /// <summary>
        ///The key wrapping and derivation algorithms.
        /// </summary>

	public virtual string						KeyWrapDerivation  {get; set;}
        /// <summary>
        ///The key parameters of the ephemeral key as specified in JWE
        /// </summary>

	public virtual Key						Epk  {get; set;}
        /// <summary>
        ///The wrapped base seed. The base seed is encrypted under the result of the key exchange.
        /// </summary>

	public virtual byte[]						WrappedBaseSeed  {get; set;}
        /// <summary>
        ///The per-recipient key exchange data.
        /// </summary>

	public virtual string						RecipientKeyData  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "kid" : {
				if (value is TokenValueString vvalue) {
					KeyIdentifier = vvalue.Value;
					}
				break;
				}
			case "kwd" : {
				if (value is TokenValueString vvalue) {
					KeyWrapDerivation = vvalue.Value;
					}
				break;
				}
			case "epk" : {
				if (value is TokenValueStructObject vvalue) {
					Epk = vvalue.Value as Key;
					}
				break;
				}
			case "wmk" : {
				if (value is TokenValueBinary vvalue) {
					WrappedBaseSeed = vvalue.Value;
					}
				break;
				}
			case "rkd" : {
				if (value is TokenValueString vvalue) {
					RecipientKeyData = vvalue.Value;
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
			case "kid" : {
				return new TokenValueString (KeyIdentifier);
				}
			case "kwd" : {
				return new TokenValueString (KeyWrapDerivation);
				}
			case "epk" : {
				return new TokenValueStruct<Key> (Epk);
				}
			case "wmk" : {
				return new TokenValueBinary (WrappedBaseSeed);
				}
			case "rkd" : {
				return new TokenValueString (RecipientKeyData);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "kid", new Property (typeof(TokenValueString), false)} ,
			{ "kwd", new Property (typeof(TokenValueString), false)} ,
			{ "epk", new Property ( typeof(TokenValueStruct), false,
					null, null, true)} ,
			{ "wmk", new Property (typeof(TokenValueBinary), false)} ,
			{ "rkd", new Property (typeof(TokenValueString), false)} 
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
	public new const string __Tag = "DareRecipient";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new DareRecipient();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new DareRecipient FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as DareRecipient;
			}
		var Result = new DareRecipient ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
public partial class DarePolicy : Dare {
        /// <summary>
        ///The encryption algorithm to be used to compute the payload.
        /// </summary>

	public virtual string						EncryptionAlgorithm  {get; set;}
        /// <summary>
        ///The digest algorithm to be used to compute the payload digest.
        /// </summary>

	public virtual string						DigestAlgorithm  {get; set;}
        /// <summary>
        ///The encryption policy specifier, determines how often a key exchange is required.
        ///'Single': All entries are encrypted under the key exchange specified in the 
        ///entry specifying this policy.
        ///'Isolated': All entries are encrypted under a separate key exchange.
        ///'All': All entries are encrypted.
        ///'None': No entries are encrypted.
        ///Default value is 'None' if EncryptKeys is null, and 'All' otherwise.
        /// </summary>

	public virtual string						Encryption  {get; set;}
        /// <summary>
        ///The signature policy
        ///'None': No entries are signed.
        ///'Last': The last entry in the container is signed.
        ///'Isolated': All entries are independently signed.
        ///'Any': Entries may be signed.
        ///Default value is 'None' if SignKeys is null, and 'Any' otherwise.
        /// </summary>

	public virtual string						Signature  {get; set;}
        /// <summary>
        ///The public parameters of keys used for encryption
        /// </summary>

	public virtual List<Key>				EncryptKeys  {get; set;}
        /// <summary>
        ///The public parameters of keys to which entries MUST be encrypted.
        /// </summary>

	public virtual List<Key>				SignKeys  {get; set;}
        /// <summary>
        ///If true the policy is immutable and cannot be changed by a subsequent policy override.
        /// </summary>

	public virtual bool?						Sealed  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "enc" : {
				if (value is TokenValueString vvalue) {
					EncryptionAlgorithm = vvalue.Value;
					}
				break;
				}
			case "dig" : {
				if (value is TokenValueString vvalue) {
					DigestAlgorithm = vvalue.Value;
					}
				break;
				}
			case "Encryption" : {
				if (value is TokenValueString vvalue) {
					Encryption = vvalue.Value;
					}
				break;
				}
			case "Signature" : {
				if (value is TokenValueString vvalue) {
					Signature = vvalue.Value;
					}
				break;
				}
			case "EncryptKeys" : {
				if (value is TokenValueListStructObject vvalue) {
					EncryptKeys = vvalue.Value as List<Key>;
					}
				break;
				}
			case "SignKeys" : {
				if (value is TokenValueListStructObject vvalue) {
					SignKeys = vvalue.Value as List<Key>;
					}
				break;
				}
			case "Sealed" : {
				if (value is TokenValueBoolean vvalue) {
					Sealed = vvalue.Value;
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
			case "enc" : {
				return new TokenValueString (EncryptionAlgorithm);
				}
			case "dig" : {
				return new TokenValueString (DigestAlgorithm);
				}
			case "Encryption" : {
				return new TokenValueString (Encryption);
				}
			case "Signature" : {
				return new TokenValueString (Signature);
				}
			case "EncryptKeys" : {
				return new TokenValueListStruct<Key> (EncryptKeys);
				}
			case "SignKeys" : {
				return new TokenValueListStruct<Key> (SignKeys);
				}
			case "Sealed" : {
				return new TokenValueBoolean (Sealed);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "enc", new Property (typeof(TokenValueString), false)} ,
			{ "dig", new Property (typeof(TokenValueString), false)} ,
			{ "Encryption", new Property (typeof(TokenValueString), false)} ,
			{ "Signature", new Property (typeof(TokenValueString), false)} ,
			{ "EncryptKeys", new Property ( typeof(TokenValueListStruct), true,
					()=>new List<Key>(), null, true)} ,
			{ "SignKeys", new Property ( typeof(TokenValueListStruct), true,
					()=>new List<Key>(), null, true)} ,
			{ "Sealed", new Property (typeof(TokenValueBoolean), false)} 
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
	public new const string __Tag = "DarePolicy";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new DarePolicy();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new DarePolicy FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as DarePolicy;
			}
		var Result = new DarePolicy ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
public partial class FileEntry : Dare {
        /// <summary>
        ///The file path in canonical form. 
        /// </summary>

	public virtual string						Path  {get; set;}
        /// <summary>
        ///The creation time of the file on disk in UTC
        /// </summary>

	public virtual DateTime?						CreationTime  {get; set;}
        /// <summary>
        ///The last access time of the file on disk in UTC
        /// </summary>

	public virtual DateTime?						LastAccessTime  {get; set;}
        /// <summary>
        ///The last write time of the file on disk in UTC
        /// </summary>

	public virtual DateTime?						LastWriteTime  {get; set;}
        /// <summary>
        ///The file attribues as a bitmapped integer.
        /// </summary>

	public virtual int?						Attributes  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "Path" : {
				if (value is TokenValueString vvalue) {
					Path = vvalue.Value;
					}
				break;
				}
			case "CreationTime" : {
				if (value is TokenValueDateTime vvalue) {
					CreationTime = vvalue.Value;
					}
				break;
				}
			case "LastAccessTime" : {
				if (value is TokenValueDateTime vvalue) {
					LastAccessTime = vvalue.Value;
					}
				break;
				}
			case "LastWriteTime" : {
				if (value is TokenValueDateTime vvalue) {
					LastWriteTime = vvalue.Value;
					}
				break;
				}
			case "Attributes" : {
				if (value is TokenValueInteger32 vvalue) {
					Attributes = vvalue.Value;
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
			case "Path" : {
				return new TokenValueString (Path);
				}
			case "CreationTime" : {
				return new TokenValueDateTime (CreationTime);
				}
			case "LastAccessTime" : {
				return new TokenValueDateTime (LastAccessTime);
				}
			case "LastWriteTime" : {
				return new TokenValueDateTime (LastWriteTime);
				}
			case "Attributes" : {
				return new TokenValueInteger32 (Attributes);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Path", new Property (typeof(TokenValueString), false)} ,
			{ "CreationTime", new Property (typeof(TokenValueDateTime), false)} ,
			{ "LastAccessTime", new Property (typeof(TokenValueDateTime), false)} ,
			{ "LastWriteTime", new Property (typeof(TokenValueDateTime), false)} ,
			{ "Attributes", new Property (typeof(TokenValueInteger32), false)} 
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
	public new const string __Tag = "FileEntry";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new FileEntry();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new FileEntry FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as FileEntry;
			}
		var Result = new FileEntry ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	///
	/// Entry containing the latest apex value of a specified append only log.
	/// </summary>
public partial class Witness : Dare {
        /// <summary>
        ///Globally unique log identifier
        /// </summary>

	public virtual string						Id  {get; set;}
        /// <summary>
        ///The issuer of the log
        /// </summary>

	public virtual string						Issuer  {get; set;}
        /// <summary>
        ///The Apex hash value
        /// </summary>

	public virtual byte[]						Apex  {get; set;}
        /// <summary>
        ///Specifies the index number assigned to the entry in the log.
        /// </summary>

	public virtual int?						Index  {get; set;}


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
			case "Issuer" : {
				if (value is TokenValueString vvalue) {
					Issuer = vvalue.Value;
					}
				break;
				}
			case "Apex" : {
				if (value is TokenValueBinary vvalue) {
					Apex = vvalue.Value;
					}
				break;
				}
			case "Index" : {
				if (value is TokenValueInteger32 vvalue) {
					Index = vvalue.Value;
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
			case "Issuer" : {
				return new TokenValueString (Issuer);
				}
			case "Apex" : {
				return new TokenValueBinary (Apex);
				}
			case "Index" : {
				return new TokenValueInteger32 (Index);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Id", new Property (typeof(TokenValueString), false)} ,
			{ "Issuer", new Property (typeof(TokenValueString), false)} ,
			{ "Apex", new Property (typeof(TokenValueBinary), false)} ,
			{ "Index", new Property (typeof(TokenValueInteger32), false)} 
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
	public new const string __Tag = "Witness";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new Witness();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new Witness FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as Witness;
			}
		var Result = new Witness ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	///
	/// Provides a proof that the payload with digest [hash] in the log described by 
	/// SignedWitness occurs at the index [Index]
	/// </summary>
public partial class Proof : Dare {
        /// <summary>
        ///The signed apex under which this proof chain is established
        /// </summary>

	public virtual DareEnvelope						SignedWitness  {get; set;}
        /// <summary>
        ///
        /// </summary>

	public virtual byte[]						Hash  {get; set;}
        /// <summary>
        ///Specifies the index number assigned to the entry in the log.
        /// </summary>

	public virtual int?						Index  {get; set;}
        /// <summary>
        ///The list of entries from which the proof path is computed.
        /// </summary>

	public virtual List<byte[]>				Path  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "SignedWitness" : {
				if (value is TokenValueStructObject vvalue) {
					SignedWitness = vvalue.Value as DareEnvelope;
					}
				break;
				}
			case "Hash" : {
				if (value is TokenValueBinary vvalue) {
					Hash = vvalue.Value;
					}
				break;
				}
			case "Index" : {
				if (value is TokenValueInteger32 vvalue) {
					Index = vvalue.Value;
					}
				break;
				}
			case "Path" : {
				if (value is TokenValueListBinary vvalue) {
					Path = vvalue.Value;
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
			case "SignedWitness" : {
				return new TokenValueStruct<DareEnvelope> (SignedWitness);
				}
			case "Hash" : {
				return new TokenValueBinary (Hash);
				}
			case "Index" : {
				return new TokenValueInteger32 (Index);
				}
			case "Path" : {
				return new TokenValueListBinary (Path);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "SignedWitness", new Property ( typeof(TokenValueStruct), false,
					()=>new DareEnvelope(), ()=>new DareEnvelope(), false)} ,
			{ "Hash", new Property (typeof(TokenValueBinary), false)} ,
			{ "Index", new Property (typeof(TokenValueInteger32), false)} ,
			{ "Path", new Property (typeof(TokenValueListBinary), true)} 
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
	public new const string __Tag = "Proof";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new Proof();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new Proof FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as Proof;
			}
		var Result = new Proof ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}



