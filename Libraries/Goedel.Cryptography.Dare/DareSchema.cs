
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
//  This file was automatically generated at 5/29/2024 2:17:49 PM
//   
//  Changes to this file may be overwritten without warning
//  
//  Generator:  protogen version 3.0.0.1131
//      Goedel Script Version : 0.1   Generated 
//      Goedel Schema Version : 0.1   Generated
//  
//      Copyright : © 2015-2021
//  
//  Build Platform: Win32NT 10.0.22631.0
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

	public virtual DareHeader?						Header  {get; set;}

        /// <summary>
        ///The envelope body
        /// </summary>

	public virtual byte[]?						Body  {get; set;}

        /// <summary>
        ///The envelope trailer. If present, this contains the signature.
        /// </summary>

	public virtual DareTrailer?						Trailer  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new DareEnvelopeSequence(), null);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Header", new PropertyStruct ("Header", 
					(IBinding data, object? value) => {(data as DareEnvelopeSequence).Header = value as DareHeader;}, (IBinding data) => (data as DareEnvelopeSequence).Header,
					false, ()=>new  DareHeader(), ()=>new DareHeader())} ,
			{ "Body", new PropertyBinary ("Body", 
					(IBinding data, byte[]? value) => {(data as DareEnvelopeSequence).Body = value;}, (IBinding data) => (data as DareEnvelopeSequence).Body )},
			{ "Trailer", new PropertyStruct ("Trailer", 
					(IBinding data, object? value) => {(data as DareEnvelopeSequence).Trailer = value as DareTrailer;}, (IBinding data) => (data as DareEnvelopeSequence).Trailer,
					false, ()=>new  DareTrailer(), ()=>new DareTrailer())} 
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

	public virtual List<DareSignature>?					Signatures  {get; set;}
        /// <summary>
        ///A list of signatures over the apex digest.
        ///A envelope trailer MUST NOT contain av apex field if the header contains 
        ///a signatures field.
        /// </summary>

	public virtual List<DareSignature>?					ApexSignatures  {get; set;}
        /// <summary>
        ///Contains a DAREHeader object 
        /// </summary>

	public virtual byte[]?						SignedData  {get; set;}

        /// <summary>
        ///If present, contains the digest of the Payload.
        /// </summary>

	public virtual byte[]?						PayloadDigest  {get; set;}

        /// <summary>
        ///If present, contains the digest of the PayloadDigest values of this
        ///frame and the frame immediately preceding.
        /// </summary>

	public virtual byte[]?						ChainDigest  {get; set;}

        /// <summary>
        ///If present, contains the Binary Merkle Tree digest value.
        /// </summary>

	public virtual byte[]?						TreeDigest  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new DareTrailer(), null);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "signatures", new PropertyListStruct ("signatures", 
					(IBinding data, object? value) => {(data as DareTrailer).Signatures = value as List<DareSignature>;}, (IBinding data) => (data as DareTrailer).Signatures,
					false, ()=>new  List<DareSignature>(), ()=>new DareSignature())} ,
			{ "ApexSignatures", new PropertyListStruct ("ApexSignatures", 
					(IBinding data, object? value) => {(data as DareTrailer).ApexSignatures = value as List<DareSignature>;}, (IBinding data) => (data as DareTrailer).ApexSignatures,
					false, ()=>new  List<DareSignature>(), ()=>new DareSignature())} ,
			{ "SignedData", new PropertyBinary ("SignedData", 
					(IBinding data, byte[]? value) => {(data as DareTrailer).SignedData = value;}, (IBinding data) => (data as DareTrailer).SignedData )},
			{ "PayloadDigest", new PropertyBinary ("PayloadDigest", 
					(IBinding data, byte[]? value) => {(data as DareTrailer).PayloadDigest = value;}, (IBinding data) => (data as DareTrailer).PayloadDigest )},
			{ "ChainDigest", new PropertyBinary ("ChainDigest", 
					(IBinding data, byte[]? value) => {(data as DareTrailer).ChainDigest = value;}, (IBinding data) => (data as DareTrailer).ChainDigest )},
			{ "TreeDigest", new PropertyBinary ("TreeDigest", 
					(IBinding data, byte[]? value) => {(data as DareTrailer).TreeDigest = value;}, (IBinding data) => (data as DareTrailer).TreeDigest )}
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

	public virtual string?						EnvelopeId  {get; set;}

        /// <summary>
        ///The encryption algorithm as specified in JWE
        /// </summary>

	public virtual string?						EncryptionAlgorithm  {get; set;}

        /// <summary>
        ///Digest Algorithm. If specified, tells decoder that the digest algorithm is used to
        ///construct a signature over the envelope payload.
        /// </summary>

	public virtual string?						DigestAlgorithm  {get; set;}

        /// <summary>
        ///Base seed identifier.
        /// </summary>

	public virtual string?						KeyIdentifier  {get; set;}

        /// <summary>
        ///Salt value used to derrive cryptographic parameters for the content data.
        /// </summary>

	public virtual byte[]?						Salt  {get; set;}

        /// <summary>
        ///Hash of the Salt value used to derrive cryptographic parameters for the content data.
        ///This field SHOULD NOT be present if the Salt field is present. It is used to
        ///allow the salt value to be erased (thus rendering the payload content irrecoverable)
        ///without affecting the ability to calculate the payload digest value.
        /// </summary>

	public virtual byte[]?						Malt  {get; set;}

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

	public virtual byte[]?						Cloaked  {get; set;}

        /// <summary>
        ///If present, the Annotations field contains a sequence of Encrypted Data 
        ///Segments encrypted under the envelope base seed. The interpretation of these fields 
        ///is application specific.
        /// </summary>

	public virtual List<byte[]>?					EDSS  {get; set;}
        /// <summary>
        ///A list of recipient key exchange information blocks.
        /// </summary>

	public virtual List<DareRecipient>?					Recipients  {get; set;}
        /// <summary>
        ///A DARE security policy governing future additions to the container.
        /// </summary>

	public virtual DarePolicy?						Policy  {get; set;}

        /// <summary>
        ///If present contains a JSON encoded ContentInfo structure which specifies
        ///plaintext content metadata and forms one of the inputs to the envelope digest value.
        /// </summary>

	public virtual byte[]?						ContentMetaData  {get; set;}

        /// <summary>
        ///Information that describes container information
        /// </summary>

	public virtual SequenceInfo?						SequenceInfo  {get; set;}

        /// <summary>
        ///An index of records in the current container up to but not including
        ///this one.
        /// </summary>

	public virtual SequenceIndex?						SequenceIndex  {get; set;}

        /// <summary>
        ///Date on which the envelope was received.
        /// </summary>

	public virtual DateTime?						Received  {get; set;}

        /// <summary>
        ///HTML document containing cover text to be presented if the document cannot be decrypted.
        /// </summary>

	public virtual byte[]?						Cover  {get; set;}

        /// <summary>
        ///Bitmask used to identify a container within a group for use in update notification
        ///etc.
        /// </summary>

	public virtual byte[]?						Bitmask  {get; set;}

        /// <summary>
        ///Field reserved for use in debugging.
        /// </summary>

	public virtual string?						Debug  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new DareHeader(), DareTrailer._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "EnvelopeId", new PropertyString ("EnvelopeId", 
					(IBinding data, string? value) => {(data as DareHeader).EnvelopeId = value;}, (IBinding data) => (data as DareHeader).EnvelopeId )},
			{ "enc", new PropertyString ("enc", 
					(IBinding data, string? value) => {(data as DareHeader).EncryptionAlgorithm = value;}, (IBinding data) => (data as DareHeader).EncryptionAlgorithm )},
			{ "dig", new PropertyString ("dig", 
					(IBinding data, string? value) => {(data as DareHeader).DigestAlgorithm = value;}, (IBinding data) => (data as DareHeader).DigestAlgorithm )},
			{ "kid", new PropertyString ("kid", 
					(IBinding data, string? value) => {(data as DareHeader).KeyIdentifier = value;}, (IBinding data) => (data as DareHeader).KeyIdentifier )},
			{ "Salt", new PropertyBinary ("Salt", 
					(IBinding data, byte[]? value) => {(data as DareHeader).Salt = value;}, (IBinding data) => (data as DareHeader).Salt )},
			{ "Malt", new PropertyBinary ("Malt", 
					(IBinding data, byte[]? value) => {(data as DareHeader).Malt = value;}, (IBinding data) => (data as DareHeader).Malt )},
			{ "cloaked", new PropertyBinary ("cloaked", 
					(IBinding data, byte[]? value) => {(data as DareHeader).Cloaked = value;}, (IBinding data) => (data as DareHeader).Cloaked )},
			{ "annotations", new PropertyListBinary ("annotations", 
					(IBinding data, List<byte[]>? value) => {(data as DareHeader).EDSS = value;}, (IBinding data) => (data as DareHeader).EDSS )},
			{ "recipients", new PropertyListStruct ("recipients", 
					(IBinding data, object? value) => {(data as DareHeader).Recipients = value as List<DareRecipient>;}, (IBinding data) => (data as DareHeader).Recipients,
					false, ()=>new  List<DareRecipient>(), ()=>new DareRecipient())} ,
			{ "policy", new PropertyStruct ("policy", 
					(IBinding data, object? value) => {(data as DareHeader).Policy = value as DarePolicy;}, (IBinding data) => (data as DareHeader).Policy,
					false, ()=>new  DarePolicy(), ()=>new DarePolicy())} ,
			{ "ContentMetaData", new PropertyBinary ("ContentMetaData", 
					(IBinding data, byte[]? value) => {(data as DareHeader).ContentMetaData = value;}, (IBinding data) => (data as DareHeader).ContentMetaData )},
			{ "SequenceInfo", new PropertyStruct ("SequenceInfo", 
					(IBinding data, object? value) => {(data as DareHeader).SequenceInfo = value as SequenceInfo;}, (IBinding data) => (data as DareHeader).SequenceInfo,
					false, ()=>new  SequenceInfo(), ()=>new SequenceInfo())} ,
			{ "SequenceIndex", new PropertyStruct ("SequenceIndex", 
					(IBinding data, object? value) => {(data as DareHeader).SequenceIndex = value as SequenceIndex;}, (IBinding data) => (data as DareHeader).SequenceIndex,
					false, ()=>new  SequenceIndex(), ()=>new SequenceIndex())} ,
			{ "Received", new PropertyDateTime ("Received", 
					(IBinding data, DateTime? value) => {(data as DareHeader).Received = value;}, (IBinding data) => (data as DareHeader).Received )},
			{ "Cover", new PropertyBinary ("Cover", 
					(IBinding data, byte[]? value) => {(data as DareHeader).Cover = value;}, (IBinding data) => (data as DareHeader).Cover )},
			{ "Bitmask", new PropertyBinary ("Bitmask", 
					(IBinding data, byte[]? value) => {(data as DareHeader).Bitmask = value;}, (IBinding data) => (data as DareHeader).Bitmask )},
			{ "Debug", new PropertyString ("Debug", 
					(IBinding data, string? value) => {(data as DareHeader).Debug = value;}, (IBinding data) => (data as DareHeader).Debug )}
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

	public virtual string?						UniqueId  {get; set;}

        /// <summary>
        ///List of labels that are applied to the payload of the frame.
        /// </summary>

	public virtual List<string>?					Labels  {get; set;}
        /// <summary>
        ///List of key/value pairs describing the payload of the frame.
        /// </summary>

	public virtual List<KeyValue>?					KeyValues  {get; set;}
        /// <summary>
        ///The mesh message type
        /// </summary>

	public virtual string?						MessageType  {get; set;}

        /// <summary>
        ///The content type field as specified in JWE
        /// </summary>

	public virtual string?						ContentType  {get; set;}

        /// <summary>
        ///List of filename paths for the payload of the frame.
        /// </summary>

	public virtual List<string>?					Paths  {get; set;}
        /// <summary>
        ///The original filename under which the data was stored.
        /// </summary>

	public virtual string?						Filename  {get; set;}

        /// <summary>
        ///Operation on the header
        /// </summary>

	public virtual string?						Event  {get; set;}

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

	public virtual long?						First  {get; set;}

        /// <summary>
        ///Frame number of the immediately prior object instance value	
        /// </summary>

	public virtual long?						Previous  {get; set;}

        /// <summary>
        ///Information describing the file entry on disk.
        /// </summary>

	public virtual FileEntry?						FileEntry  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new ContentMeta(), null);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "UniqueId", new PropertyString ("UniqueId", 
					(IBinding data, string? value) => {(data as ContentMeta).UniqueId = value;}, (IBinding data) => (data as ContentMeta).UniqueId )},
			{ "Labels", new PropertyListString ("Labels", 
					(IBinding data, List<string>? value) => {(data as ContentMeta).Labels = value;}, (IBinding data) => (data as ContentMeta).Labels )},
			{ "KeyValues", new PropertyListStruct ("KeyValues", 
					(IBinding data, object? value) => {(data as ContentMeta).KeyValues = value as List<KeyValue>;}, (IBinding data) => (data as ContentMeta).KeyValues,
					false, ()=>new  List<KeyValue>(), ()=>new KeyValue())} ,
			{ "MessageType", new PropertyString ("MessageType", 
					(IBinding data, string? value) => {(data as ContentMeta).MessageType = value;}, (IBinding data) => (data as ContentMeta).MessageType )},
			{ "cty", new PropertyString ("cty", 
					(IBinding data, string? value) => {(data as ContentMeta).ContentType = value;}, (IBinding data) => (data as ContentMeta).ContentType )},
			{ "Paths", new PropertyListString ("Paths", 
					(IBinding data, List<string>? value) => {(data as ContentMeta).Paths = value;}, (IBinding data) => (data as ContentMeta).Paths )},
			{ "Filename", new PropertyString ("Filename", 
					(IBinding data, string? value) => {(data as ContentMeta).Filename = value;}, (IBinding data) => (data as ContentMeta).Filename )},
			{ "Event", new PropertyString ("Event", 
					(IBinding data, string? value) => {(data as ContentMeta).Event = value;}, (IBinding data) => (data as ContentMeta).Event )},
			{ "Created", new PropertyDateTime ("Created", 
					(IBinding data, DateTime? value) => {(data as ContentMeta).Created = value;}, (IBinding data) => (data as ContentMeta).Created )},
			{ "Modified", new PropertyDateTime ("Modified", 
					(IBinding data, DateTime? value) => {(data as ContentMeta).Modified = value;}, (IBinding data) => (data as ContentMeta).Modified )},
			{ "Expire", new PropertyDateTime ("Expire", 
					(IBinding data, DateTime? value) => {(data as ContentMeta).Expire = value;}, (IBinding data) => (data as ContentMeta).Expire )},
			{ "First", new PropertyInteger64 ("First", 
					(IBinding data, long? value) => {(data as ContentMeta).First = value;}, (IBinding data) => (data as ContentMeta).First )},
			{ "Previous", new PropertyInteger64 ("Previous", 
					(IBinding data, long? value) => {(data as ContentMeta).Previous = value;}, (IBinding data) => (data as ContentMeta).Previous )},
			{ "FileEntry", new PropertyStruct ("FileEntry", 
					(IBinding data, object? value) => {(data as ContentMeta).FileEntry = value as FileEntry;}, (IBinding data) => (data as ContentMeta).FileEntry,
					false, ()=>new  FileEntry(), ()=>new FileEntry())} 
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

	public virtual string?						Dig  {get; set;}

        /// <summary>
        ///Key exchange algorithm
        /// </summary>

	public virtual string?						Alg  {get; set;}

        /// <summary>
        ///Key identifier of the signature key.
        /// </summary>

	public virtual string?						KeyIdentifier  {get; set;}

        /// <summary>
        ///PKIX certificate of signer.
        /// </summary>

	public virtual X509Certificate?						Certificate  {get; set;}

        /// <summary>
        ///PKIX certificates that establish a trust path for the signer.
        /// </summary>

	public virtual X509Certificate?						Path  {get; set;}

        /// <summary>
        ///The data description that was signed.
        /// </summary>

	public virtual byte[]?						Manifest  {get; set;}

        /// <summary>
        ///The signature value as an Enhanced Data Sequence under the envelope base seed.
        /// </summary>

	public virtual byte[]?						SignatureValue  {get; set;}

        /// <summary>
        ///The signature witness value used on an encrypted envelope to demonstrate that 
        ///the signature was authorized by a party with actual knowledge of the encryption 
        ///key used to encrypt the envelope.
        /// </summary>

	public virtual byte[]?						WitnessValue  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new DareSignature(), null);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "dig", new PropertyString ("dig", 
					(IBinding data, string? value) => {(data as DareSignature).Dig = value;}, (IBinding data) => (data as DareSignature).Dig )},
			{ "alg", new PropertyString ("alg", 
					(IBinding data, string? value) => {(data as DareSignature).Alg = value;}, (IBinding data) => (data as DareSignature).Alg )},
			{ "kid", new PropertyString ("kid", 
					(IBinding data, string? value) => {(data as DareSignature).KeyIdentifier = value;}, (IBinding data) => (data as DareSignature).KeyIdentifier )},
			{ "cert", new PropertyStruct ("cert", 
					(IBinding data, object? value) => {(data as DareSignature).Certificate = value as X509Certificate;}, (IBinding data) => (data as DareSignature).Certificate,
					false, ()=>new  X509Certificate(), ()=>new X509Certificate())} ,
			{ "path", new PropertyStruct ("path", 
					(IBinding data, object? value) => {(data as DareSignature).Path = value as X509Certificate;}, (IBinding data) => (data as DareSignature).Path,
					false, ()=>new  X509Certificate(), ()=>new X509Certificate())} ,
			{ "Manifest", new PropertyBinary ("Manifest", 
					(IBinding data, byte[]? value) => {(data as DareSignature).Manifest = value;}, (IBinding data) => (data as DareSignature).Manifest )},
			{ "signature", new PropertyBinary ("signature", 
					(IBinding data, byte[]? value) => {(data as DareSignature).SignatureValue = value;}, (IBinding data) => (data as DareSignature).SignatureValue )},
			{ "witness", new PropertyBinary ("witness", 
					(IBinding data, byte[]? value) => {(data as DareSignature).WitnessValue = value;}, (IBinding data) => (data as DareSignature).WitnessValue )}
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

	public virtual long?						Index  {get; set;}

        /// <summary>
        ///The signed envelopes in order, lowest index first.
        /// </summary>

	public virtual SignedEnvelope?						Envelopes  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new IntervalSignature(), null);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Index", new PropertyInteger64 ("Index", 
					(IBinding data, long? value) => {(data as IntervalSignature).Index = value;}, (IBinding data) => (data as IntervalSignature).Index )},
			{ "Envelopes", new PropertyStruct ("Envelopes", 
					(IBinding data, object? value) => {(data as IntervalSignature).Envelopes = value as SignedEnvelope;}, (IBinding data) => (data as IntervalSignature).Envelopes,
					false, ()=>new  SignedEnvelope(), ()=>new SignedEnvelope())} 
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

	public virtual long?						Index  {get; set;}

        /// <summary>
        ///The digests required to complete the verification of the signature.		
        /// </summary>

	public virtual List<byte[]>?					Digest  {get; set;}


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new SignedEnvelope(), null);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Index", new PropertyInteger64 ("Index", 
					(IBinding data, long? value) => {(data as SignedEnvelope).Index = value;}, (IBinding data) => (data as SignedEnvelope).Index )},
			{ "Digest", new PropertyListBinary ("Digest", 
					(IBinding data, List<byte[]>? value) => {(data as SignedEnvelope).Digest = value;}, (IBinding data) => (data as SignedEnvelope).Digest )}
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

	public virtual string?						X5u  {get; set;}

        /// <summary>
        ///An X.509 public key certificate
        /// </summary>

	public virtual byte[]?						X5  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new X509Certificate(), null);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "x5u", new PropertyString ("x5u", 
					(IBinding data, string? value) => {(data as X509Certificate).X5u = value;}, (IBinding data) => (data as X509Certificate).X5u )},
			{ "x5c", new PropertyBinary ("x5c", 
					(IBinding data, byte[]? value) => {(data as X509Certificate).X5 = value;}, (IBinding data) => (data as X509Certificate).X5 )}
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

	public virtual string?						KeyIdentifier  {get; set;}

        /// <summary>
        ///The key wrapping and derivation algorithms.
        /// </summary>

	public virtual string?						KeyWrapDerivation  {get; set;}

        /// <summary>
        ///The key parameters of the ephemeral key as specified in JWE
        /// </summary>

	public virtual Key?						Epk  {get; set;}

        /// <summary>
        ///The wrapped base seed. The base seed is encrypted under the result of the key exchange.
        /// </summary>

	public virtual byte[]?						WrappedBaseSeed  {get; set;}

        /// <summary>
        ///The per-recipient key exchange data.
        /// </summary>

	public virtual string?						RecipientKeyData  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new DareRecipient(), null);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "kid", new PropertyString ("kid", 
					(IBinding data, string? value) => {(data as DareRecipient).KeyIdentifier = value;}, (IBinding data) => (data as DareRecipient).KeyIdentifier )},
			{ "kwd", new PropertyString ("kwd", 
					(IBinding data, string? value) => {(data as DareRecipient).KeyWrapDerivation = value;}, (IBinding data) => (data as DareRecipient).KeyWrapDerivation )},
			{ "epk", new PropertyStruct ("epk", 
					(IBinding data, object? value) => {(data as DareRecipient).Epk = value as Key;}, (IBinding data) => (data as DareRecipient).Epk,
					true)} ,
			{ "wmk", new PropertyBinary ("wmk", 
					(IBinding data, byte[]? value) => {(data as DareRecipient).WrappedBaseSeed = value;}, (IBinding data) => (data as DareRecipient).WrappedBaseSeed )},
			{ "rkd", new PropertyString ("rkd", 
					(IBinding data, string? value) => {(data as DareRecipient).RecipientKeyData = value;}, (IBinding data) => (data as DareRecipient).RecipientKeyData )}
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
        ///When applied to a store, indicates it is world readable.
        /// </summary>

	public virtual bool?						Public  {get; set;}

        /// <summary>
        ///The encryption algorithm to be used to compute the payload.
        /// </summary>

	public virtual string?						EncryptionAlgorithm  {get; set;}

        /// <summary>
        ///The digest algorithm to be used to compute the payload digest.
        /// </summary>

	public virtual string?						DigestAlgorithm  {get; set;}

        /// <summary>
        ///The encryption policy specifier, determines how often a key exchange is required.
        ///'Single': All entries are encrypted under the key exchange specified in the 
        ///entry specifying this policy.
        ///'Isolated': All entries are encrypted under a separate key exchange.
        ///'All': All entries are encrypted.
        ///'None': No entries are encrypted.
        ///Default value is 'None' if EncryptKeys is null, and 'All' otherwise.
        /// </summary>

	public virtual string?						Encryption  {get; set;}

        /// <summary>
        ///The signature policy
        ///'None': No entries are signed.
        ///'Last': The last entry in the container is signed.
        ///'Isolated': All entries are independently signed.
        ///'Any': Entries may be signed.
        ///Default value is 'None' if SignKeys is null, and 'Any' otherwise.
        /// </summary>

	public virtual string?						Signature  {get; set;}

        /// <summary>
        ///The public parameters of keys used for encryption
        /// </summary>

	public virtual List<Key>?					EncryptKeys  {get; set;}
        /// <summary>
        ///The public parameters of keys to which entries MUST be encrypted.
        /// </summary>

	public virtual List<Key>?					SignKeys  {get; set;}
        /// <summary>
        ///If true the policy is immutable and cannot be changed by a subsequent policy override.
        /// </summary>

	public virtual bool?						Sealed  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new DarePolicy(), null);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Public", new PropertyBoolean ("Public", 
					(IBinding data, bool? value) => {(data as DarePolicy).Public = value;}, (IBinding data) => (data as DarePolicy).Public )},
			{ "enc", new PropertyString ("enc", 
					(IBinding data, string? value) => {(data as DarePolicy).EncryptionAlgorithm = value;}, (IBinding data) => (data as DarePolicy).EncryptionAlgorithm )},
			{ "dig", new PropertyString ("dig", 
					(IBinding data, string? value) => {(data as DarePolicy).DigestAlgorithm = value;}, (IBinding data) => (data as DarePolicy).DigestAlgorithm )},
			{ "Encryption", new PropertyString ("Encryption", 
					(IBinding data, string? value) => {(data as DarePolicy).Encryption = value;}, (IBinding data) => (data as DarePolicy).Encryption )},
			{ "Signature", new PropertyString ("Signature", 
					(IBinding data, string? value) => {(data as DarePolicy).Signature = value;}, (IBinding data) => (data as DarePolicy).Signature )},
			{ "EncryptKeys", new PropertyListStruct ("EncryptKeys", 
					(IBinding data, object? value) => {(data as DarePolicy).EncryptKeys = value as List<Key>;}, (IBinding data) => (data as DarePolicy).EncryptKeys,
					true, ()=>new List<Key>()
)} ,
			{ "SignKeys", new PropertyListStruct ("SignKeys", 
					(IBinding data, object? value) => {(data as DarePolicy).SignKeys = value as List<Key>;}, (IBinding data) => (data as DarePolicy).SignKeys,
					true, ()=>new List<Key>()
)} ,
			{ "Sealed", new PropertyBoolean ("Sealed", 
					(IBinding data, bool? value) => {(data as DarePolicy).Sealed = value;}, (IBinding data) => (data as DarePolicy).Sealed )}
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

	public virtual string?						Path  {get; set;}

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



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new FileEntry(), null);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Path", new PropertyString ("Path", 
					(IBinding data, string? value) => {(data as FileEntry).Path = value;}, (IBinding data) => (data as FileEntry).Path )},
			{ "CreationTime", new PropertyDateTime ("CreationTime", 
					(IBinding data, DateTime? value) => {(data as FileEntry).CreationTime = value;}, (IBinding data) => (data as FileEntry).CreationTime )},
			{ "LastAccessTime", new PropertyDateTime ("LastAccessTime", 
					(IBinding data, DateTime? value) => {(data as FileEntry).LastAccessTime = value;}, (IBinding data) => (data as FileEntry).LastAccessTime )},
			{ "LastWriteTime", new PropertyDateTime ("LastWriteTime", 
					(IBinding data, DateTime? value) => {(data as FileEntry).LastWriteTime = value;}, (IBinding data) => (data as FileEntry).LastWriteTime )},
			{ "Attributes", new PropertyInteger32 ("Attributes", 
					(IBinding data, int? value) => {(data as FileEntry).Attributes = value;}, (IBinding data) => (data as FileEntry).Attributes )}
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

	public virtual string?						Id  {get; set;}

        /// <summary>
        ///The issuer of the log
        /// </summary>

	public virtual string?						Issuer  {get; set;}

        /// <summary>
        ///The Apex hash value
        /// </summary>

	public virtual byte[]?						Apex  {get; set;}

        /// <summary>
        ///Specifies the index number assigned to the entry in the log.
        /// </summary>

	public virtual long?						Index  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new Witness(), null);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Id", new PropertyString ("Id", 
					(IBinding data, string? value) => {(data as Witness).Id = value;}, (IBinding data) => (data as Witness).Id )},
			{ "Issuer", new PropertyString ("Issuer", 
					(IBinding data, string? value) => {(data as Witness).Issuer = value;}, (IBinding data) => (data as Witness).Issuer )},
			{ "Apex", new PropertyBinary ("Apex", 
					(IBinding data, byte[]? value) => {(data as Witness).Apex = value;}, (IBinding data) => (data as Witness).Apex )},
			{ "Index", new PropertyInteger64 ("Index", 
					(IBinding data, long? value) => {(data as Witness).Index = value;}, (IBinding data) => (data as Witness).Index )}
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

	public virtual DareEnvelope?						SignedWitness  {get; set;}

        /// <summary>
        ///
        /// </summary>

	public virtual byte[]?						Hash  {get; set;}

        /// <summary>
        ///Specifies the index number assigned to the entry in the log.
        /// </summary>

	public virtual long?						Index  {get; set;}

        /// <summary>
        ///The list of entries from which the proof path is computed.
        /// </summary>

	public virtual List<byte[]>?					Path  {get; set;}


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new Proof(), null);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "SignedWitness", new PropertyStruct ("SignedWitness", 
					(IBinding data, object? value) => {(data as Proof).SignedWitness = value as DareEnvelope;}, (IBinding data) => (data as Proof).SignedWitness,
					false, ()=>new  DareEnvelope(), ()=>new DareEnvelope())} ,
			{ "Hash", new PropertyBinary ("Hash", 
					(IBinding data, byte[]? value) => {(data as Proof).Hash = value;}, (IBinding data) => (data as Proof).Hash )},
			{ "Index", new PropertyInteger64 ("Index", 
					(IBinding data, long? value) => {(data as Proof).Index = value;}, (IBinding data) => (data as Proof).Index )},
			{ "Path", new PropertyListBinary ("Path", 
					(IBinding data, List<byte[]>? value) => {(data as Proof).Path = value;}, (IBinding data) => (data as Proof).Path )}
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



