
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
//  This file was automatically generated at 1/9/2026 3:47:09 PM
//   
//  Changes to this file may be overwritten without warning
//  
//  Generator:  protogen version 3.0.0.1141
//      Goedel Script Version : 0.1   Generated 
//      Goedel Schema Version : 0.1   Generated
//  
//      Copyright : © 2015-2021
//  
//  Build Platform: Win32NT 10.0.26200.0
//  
//  
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Goedel.Protocol;
using Goedel.Utilities;

#pragma warning disable IDE0028 // Don't warn collection initialization can be simplified.
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
    /// Dictionary mapping types to bindings
    /// </summary>
	public static Dictionary<System.Type, Binding> _BindingDictionary=> _bindingDictionary;
	static Dictionary<System.Type, Binding> _bindingDictionary = 
			new () {

	    {typeof(Enveloped), Enveloped._binding},
	    {typeof(DareSignatureHeader), DareSignatureHeader._binding},
	    {typeof(DareTrailer), DareTrailer._binding},
	    {typeof(DareHeader), DareHeader._binding},
	    {typeof(ContentMeta), ContentMeta._binding},
	    {typeof(ReceiptProof), ReceiptProof._binding},
	    {typeof(DareSignature), DareSignature._binding},
	    {typeof(IntervalSignature), IntervalSignature._binding},
	    {typeof(SignedEnvelope), SignedEnvelope._binding},
	    {typeof(X509Certificate), X509Certificate._binding},
	    {typeof(DareRecipient), DareRecipient._binding},
	    {typeof(DarePolicy), DarePolicy._binding},
	    {typeof(FileEntry), FileEntry._binding},
	    {typeof(Witness), Witness._binding},
	    {typeof(Proof), Proof._binding},
	    {typeof(Unprotected), Unprotected._binding},
	    {typeof(EarlSignature), EarlSignature._binding},
	    {typeof(DareSequence), DareSequence._binding},
	    {typeof(DareEnvelope), DareEnvelope._binding},
	    {typeof(TerminalIndex), TerminalIndex._binding},
	    {typeof(FileIndex), FileIndex._binding},
	    {typeof(EntryUpdateSet), EntryUpdateSet._binding},
	    {typeof(EntryUpdate), EntryUpdate._binding}
		};

	///<summary>Variable used to force static initialization</summary> 
	public static bool _Initialized => true;

	static Dare() {
		_Initialize();
		}

    internal static void _Initialize() {
		AddDictionary(ref _bindingDictionary);
		}

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
public partial class Enveloped : Dare {
    /// <summary>
    ///The envelope header. May specify the key exchange data, pre-signature 
    ///or signature data, cloaked headers and/or encrypted data sequences.
    /// </summary>

	[JsonPropertyName("Header")]
	public virtual DareHeader?					Header  {get; set;} //

    /// <summary>
    ///The envelope body
    /// </summary>

	[JsonPropertyName("Body")]
	public virtual byte[]?					Body  {get; set;} //

    /// <summary>
    ///The envelope trailer. If present, this contains the signature.
    /// </summary>

	[JsonPropertyName("Trailer")]
	public virtual DareTrailer?					Trailer  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyStruct ("Header", typeof (DareHeader),
					(data, value) => {(data as Enveloped).Header = value as DareHeader;}, 
					data => (data as Enveloped).Header,
					false, ()=>new  DareHeader(), ()=>new DareHeader()),
		new PropertyBinary ("Body", 
					(data, value) => {(data as Enveloped).Body = value;}, 
					data => (data as Enveloped).Body ),
		new PropertyStruct ("Trailer", typeof (DareTrailer),
					(data, value) => {(data as Enveloped).Trailer = value as DareTrailer;}, 
					data => (data as Enveloped).Trailer,
					false, ()=>new  DareTrailer(), ()=>new DareTrailer())
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<Enveloped> _binding = new (
			new() {
			{ "Header", _properties [0]},
			{ "Body", _properties [1]},
			{ "Trailer", _properties [2]}}, __Tag,
		() => new Enveloped(), () => [], () => [], null, Generic: true);


	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "Enveloped";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new Enveloped();

	}


	/// <summary>
	/// </summary>
public partial class DareSignatureHeader : Dare {
    /// <summary>
    ///The encrypted witness value	
    /// </summary>

	[JsonPropertyName("WitnessValue")]
	public virtual byte[]?					WitnessValue  {get; set;} //

    /// <summary>
    ///If present, contains the authentication tag value generated by the AEAD encryption
    ///algorithm used to encrypt the payload.
    /// </summary>

	[JsonPropertyName("PayloadTag")]
	public virtual byte[]?					PayloadTag  {get; set;} //

    /// <summary>
    ///If present, contains the digest of the Payload.
    /// </summary>

	[JsonPropertyName("PayloadDigest")]
	public virtual byte[]?					PayloadDigest  {get; set;} //

    /// <summary>
    ///If present, contains the digest of the PayloadDigest values of this
    ///frame and the frame immediately preceding.
    /// </summary>

	[JsonPropertyName("ChainDigest")]
	public virtual byte[]?					ChainDigest  {get; set;} //

    /// <summary>
    ///If present, contains the Binary Merkle Tree digest value.
    /// </summary>

	[JsonPropertyName("ApexDigest")]
	public virtual byte[]?					ApexDigest  {get; set;} //

    /// <summary>
    ///Digest Algorithm. If specified, tells decoder that the digest algorithm is used to
    ///construct a signature over the envelope payload.
    /// </summary>

	[JsonPropertyName("dig")]
	public virtual string?					DigestAlgorithm  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyBinary ("WitnessValue", 
					(data, value) => {(data as DareSignatureHeader).WitnessValue = value;}, 
					data => (data as DareSignatureHeader).WitnessValue ),
		new PropertyBinary ("PayloadTag", 
					(data, value) => {(data as DareSignatureHeader).PayloadTag = value;}, 
					data => (data as DareSignatureHeader).PayloadTag ),
		new PropertyBinary ("PayloadDigest", 
					(data, value) => {(data as DareSignatureHeader).PayloadDigest = value;}, 
					data => (data as DareSignatureHeader).PayloadDigest ),
		new PropertyBinary ("ChainDigest", 
					(data, value) => {(data as DareSignatureHeader).ChainDigest = value;}, 
					data => (data as DareSignatureHeader).ChainDigest ),
		new PropertyBinary ("ApexDigest", 
					(data, value) => {(data as DareSignatureHeader).ApexDigest = value;}, 
					data => (data as DareSignatureHeader).ApexDigest ),
		new PropertyString ("dig", 
					(data, value) => {(data as DareSignatureHeader).DigestAlgorithm = value;}, 
					data => (data as DareSignatureHeader).DigestAlgorithm )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<DareSignatureHeader> _binding = new (
			new() {
			{ "WitnessValue", _properties [0]},
			{ "PayloadTag", _properties [1]},
			{ "PayloadDigest", _properties [2]},
			{ "ChainDigest", _properties [3]},
			{ "ApexDigest", _properties [4]},
			{ "dig", _properties [5]}}, __Tag,
		() => new DareSignatureHeader(), () => [], () => [], null, Generic: false);


	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "DareSignatureHeader";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new DareSignatureHeader();

	}


	/// <summary>
	///
	/// A DARE envelope Trailer
	/// </summary>
public partial class DareTrailer : DareSignatureHeader {
    /// <summary>
    ///A list of signatures over the PayloadDigest.
    ///A envelope trailer MUST NOT contain a signatures field if the header contains 
    ///a signatures field.
    /// </summary>

	[JsonPropertyName("signatures")]
	public virtual List<DareSignature>?					Signatures  {get; set;}
    /// <summary>
    ///A list of signatures over the ChainDigest and/or ApexDigest if present.
    /// </summary>

	[JsonPropertyName("seqsignatures")]
	public virtual List<DareSignature>?					SequenceSignatures  {get; set;}
    /// <summary>
    ///Additional data added to the signature to bind to an application 
    ///defined context.
    /// </summary>

	[JsonPropertyName("ApplicationContextValue")]
	public virtual byte[]?					ApplicationContextValue  {get; set;} //

    /// <summary>
    ///Contains a DareSignatureHeader object containing the manifest over which the 
    ///envelope signature is calculated.
    /// </summary>

	[JsonPropertyName("SignedData")]
	public virtual byte[]?					SignedData  {get; set;} //

    /// <summary>
    ///Contains a DareSignatureHeader object containing an additional manifest.
    ///The sequence signature is calculated over SignedData + SequenceSignedData
    /// </summary>

	[JsonPropertyName("SequenceSignedData")]
	public virtual byte[]?					SequenceSignedData  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyListStruct ("signatures", typeof (DareSignature),
					(data, value) => {(data as DareTrailer).Signatures = value as List<DareSignature>;}, 
					data => (data as DareTrailer).Signatures,
					false, ()=>new  List<DareSignature>(), ()=>new DareSignature()),
		new PropertyListStruct ("seqsignatures", typeof (DareSignature),
					(data, value) => {(data as DareTrailer).SequenceSignatures = value as List<DareSignature>;}, 
					data => (data as DareTrailer).SequenceSignatures,
					false, ()=>new  List<DareSignature>(), ()=>new DareSignature()),
		new PropertyBinary ("ApplicationContextValue", 
					(data, value) => {(data as DareTrailer).ApplicationContextValue = value;}, 
					data => (data as DareTrailer).ApplicationContextValue ),
		new PropertyBinary ("SignedData", 
					(data, value) => {(data as DareTrailer).SignedData = value;}, 
					data => (data as DareTrailer).SignedData ),
		new PropertyBinary ("SequenceSignedData", 
					(data, value) => {(data as DareTrailer).SequenceSignedData = value;}, 
					data => (data as DareTrailer).SequenceSignedData )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<DareTrailer> _binding = new (
			new() {
			{ "signatures", _properties [0]},
			{ "seqsignatures", _properties [1]},
			{ "ApplicationContextValue", _properties [2]},
			{ "SignedData", _properties [3]},
			{ "SequenceSignedData", _properties [4]}}, __Tag,
		() => new DareTrailer(), () => [], () => [], DareSignatureHeader._binding, Generic: false);


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

	[JsonPropertyName("EnvelopeId")]
	public virtual string?					EnvelopeId  {get; set;} //

    /// <summary>
    ///The encryption algorithm as specified in JWE
    /// </summary>

	[JsonPropertyName("enc")]
	public virtual string?					EncryptionAlgorithm  {get; set;} //

    /// <summary>
    ///Base seed identifier.
    /// </summary>

	[JsonPropertyName("kid")]
	public virtual string?					KeyIdentifier  {get; set;} //

    /// <summary>
    ///Salt value used to derrive cryptographic parameters for the content data.
    /// </summary>

	[JsonPropertyName("Salt")]
	public virtual byte[]?					Salt  {get; set;} //

    /// <summary>
    ///Hash of the Salt value used to derrive cryptographic parameters for the content data.
    ///This field SHOULD NOT be present if the Salt field is present. It is used to
    ///allow the salt value to be erased (thus rendering the payload content irrecoverable)
    ///without affecting the ability to calculate the payload digest value.
    /// </summary>

	[JsonPropertyName("Malt")]
	public virtual byte[]?					Malt  {get; set;} //

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

	[JsonPropertyName("cloaked")]
	public virtual byte[]?					Cloaked  {get; set;} //

    /// <summary>
    ///If present, the Annotations field contains a sequence of Encrypted Data 
    ///Segments encrypted under the envelope base seed. The interpretation of these fields 
    ///is application specific.
    /// </summary>

	[JsonPropertyName("annotations")]
	public virtual List<byte[]>?					EDSS  {get; set;}
    /// <summary>
    ///A list of recipient key exchange information blocks.
    /// </summary>

	[JsonPropertyName("recipients")]
	public virtual List<DareRecipient>?					Recipients  {get; set;}
    /// <summary>
    ///A DARE security policy governing future additions to the container.
    /// </summary>

	[JsonPropertyName("policy")]
	public virtual DarePolicy?					Policy  {get; set;} //

    /// <summary>
    ///If present contains a JSON encoded ContentInfo structure which specifies
    ///plaintext content metadata and forms one of the inputs to the envelope digest value.
    /// </summary>

	[JsonPropertyName("ContentMetaData")]
	public virtual byte[]?					ContentMetaData  {get; set;} //

    /// <summary>
    ///Information that describes container information
    /// </summary>

	[JsonPropertyName("SequenceInfo")]
	public virtual SequenceInfo?					SequenceInfo  {get; set;} //

    /// <summary>
    ///An index of records in the current container up to but not including
    ///this one.
    /// </summary>

	[JsonPropertyName("SequenceIndex")]
	public virtual SequenceIndex?					SequenceIndex  {get; set;} //

    /// <summary>
    ///Date on which the envelope was received.
    /// </summary>

	[JsonPropertyName("Received")]
	public virtual DateTime?					Received  {get; set;} //

    /// <summary>
    ///HTML document containing cover text to be presented if the document cannot be decrypted.
    /// </summary>

	[JsonPropertyName("Cover")]
	public virtual byte[]?					Cover  {get; set;} //

    /// <summary>
    ///Bitmask used to identify a container within a group for use in update notification
    ///etc.
    /// </summary>

	[JsonPropertyName("Bitmask")]
	public virtual byte[]?					Bitmask  {get; set;} //

    /// <summary>
    ///Field reserved for use in debugging.
    /// </summary>

	[JsonPropertyName("Debug")]
	public virtual string?					Debug  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("EnvelopeId", 
					(data, value) => {(data as DareHeader).EnvelopeId = value;}, 
					data => (data as DareHeader).EnvelopeId ),
		new PropertyString ("enc", 
					(data, value) => {(data as DareHeader).EncryptionAlgorithm = value;}, 
					data => (data as DareHeader).EncryptionAlgorithm ),
		new PropertyString ("kid", 
					(data, value) => {(data as DareHeader).KeyIdentifier = value;}, 
					data => (data as DareHeader).KeyIdentifier ),
		new PropertyBinary ("Salt", 
					(data, value) => {(data as DareHeader).Salt = value;}, 
					data => (data as DareHeader).Salt ),
		new PropertyBinary ("Malt", 
					(data, value) => {(data as DareHeader).Malt = value;}, 
					data => (data as DareHeader).Malt ),
		new PropertyBinary ("cloaked", 
					(data, value) => {(data as DareHeader).Cloaked = value;}, 
					data => (data as DareHeader).Cloaked ),
		new PropertyListBinary ("annotations", 
					(data, value) => {(data as DareHeader).EDSS = value;}, 
					data => (data as DareHeader).EDSS ),
		new PropertyListStruct ("recipients", typeof (DareRecipient),
					(data, value) => {(data as DareHeader).Recipients = value as List<DareRecipient>;}, 
					data => (data as DareHeader).Recipients,
					false, ()=>new  List<DareRecipient>(), ()=>new DareRecipient()),
		new PropertyStruct ("policy", typeof (DarePolicy),
					(data, value) => {(data as DareHeader).Policy = value as DarePolicy;}, 
					data => (data as DareHeader).Policy,
					false, ()=>new  DarePolicy(), ()=>new DarePolicy()),
		new PropertyBinary ("ContentMetaData", 
					(data, value) => {(data as DareHeader).ContentMetaData = value;}, 
					data => (data as DareHeader).ContentMetaData ),
		new PropertyStruct ("SequenceInfo", typeof (SequenceInfo),
					(data, value) => {(data as DareHeader).SequenceInfo = value as SequenceInfo;}, 
					data => (data as DareHeader).SequenceInfo,
					false, ()=>new  SequenceInfo(), ()=>new SequenceInfo()),
		new PropertyStruct ("SequenceIndex", typeof (SequenceIndex),
					(data, value) => {(data as DareHeader).SequenceIndex = value as SequenceIndex;}, 
					data => (data as DareHeader).SequenceIndex,
					false, ()=>new  SequenceIndex(), ()=>new SequenceIndex()),
		new PropertyDateTime ("Received", 
					(data, value) => {(data as DareHeader).Received = value;}, 
					data => (data as DareHeader).Received ),
		new PropertyBinary ("Cover", 
					(data, value) => {(data as DareHeader).Cover = value;}, 
					data => (data as DareHeader).Cover ),
		new PropertyBinary ("Bitmask", 
					(data, value) => {(data as DareHeader).Bitmask = value;}, 
					data => (data as DareHeader).Bitmask ),
		new PropertyString ("Debug", 
					(data, value) => {(data as DareHeader).Debug = value;}, 
					data => (data as DareHeader).Debug )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<DareHeader> _binding = new (
			new() {
			{ "EnvelopeId", _properties [0]},
			{ "enc", _properties [1]},
			{ "kid", _properties [2]},
			{ "Salt", _properties [3]},
			{ "Malt", _properties [4]},
			{ "cloaked", _properties [5]},
			{ "annotations", _properties [6]},
			{ "recipients", _properties [7]},
			{ "policy", _properties [8]},
			{ "ContentMetaData", _properties [9]},
			{ "SequenceInfo", _properties [10]},
			{ "SequenceIndex", _properties [11]},
			{ "Received", _properties [12]},
			{ "Cover", _properties [13]},
			{ "Bitmask", _properties [14]},
			{ "Debug", _properties [15]}}, __Tag,
		() => new DareHeader(), () => [], () => [], DareTrailer._binding, Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class ContentMeta : Dare {
    /// <summary>
    ///Unique object identifier
    /// </summary>

	[JsonPropertyName("UniqueId")]
	public virtual string?					UniqueId  {get; set;} //

    /// <summary>
    ///Nonce value, optionally used to ensure uniqueness of a digest over the content 
    ///and associated metadata.
    /// </summary>

	[JsonPropertyName("Nonce")]
	public virtual string?					Nonce  {get; set;} //

    /// <summary>
    ///List of labels that are applied to the payload of the frame.
    /// </summary>

	[JsonPropertyName("Labels")]
	public virtual List<string>?					Labels  {get; set;}
    /// <summary>
    ///List of key/value pairs describing the payload of the frame.
    /// </summary>

	[JsonPropertyName("KeyValues")]
	public virtual List<KeyValue>?					KeyValues  {get; set;}
    /// <summary>
    ///The mesh message type
    /// </summary>

	[JsonPropertyName("MessageType")]
	public virtual string?					MessageType  {get; set;} //

    /// <summary>
    ///The content type field as specified in JWE
    /// </summary>

	[JsonPropertyName("cty")]
	public virtual string?					ContentType  {get; set;} //

    /// <summary>
    ///List of filename paths for the payload of the frame.
    /// </summary>

	[JsonPropertyName("Paths")]
	public virtual List<string>?					Paths  {get; set;}
    /// <summary>
    ///The original filename under which the data was stored.
    /// </summary>

	[JsonPropertyName("Filename")]
	public virtual string?					Filename  {get; set;} //

    /// <summary>
    ///Operation on the header
    /// </summary>

	[JsonPropertyName("Event")]
	public virtual string?					Event  {get; set;} //

    /// <summary>
    ///Initial creation date.
    /// </summary>

	[JsonPropertyName("Created")]
	public virtual DateTime?					Created  {get; set;} //

    /// <summary>
    ///Date of last modification.
    /// </summary>

	[JsonPropertyName("Modified")]
	public virtual DateTime?					Modified  {get; set;} //

    /// <summary>
    ///Date at which the associated transaction will expire
    /// </summary>

	[JsonPropertyName("Expire")]
	public virtual DateTime?					Expire  {get; set;} //

    /// <summary>
    ///Frame number of the first object instance value.
    /// </summary>

	[JsonPropertyName("First")]
	public virtual long?					First  {get; set;} //

    /// <summary>
    ///Frame number of the immediately prior object instance value	
    /// </summary>

	[JsonPropertyName("Previous")]
	public virtual long?					Previous  {get; set;} //

    /// <summary>
    ///Information describing the file entry on disk.
    /// </summary>

	[JsonPropertyName("FileEntry")]
	public virtual FileEntry?					FileEntry  {get; set;} //

    /// <summary>
    ///Provides a means by which another party can demonstrate they could read the message.
    /// </summary>

	[JsonPropertyName("ReceiptProof")]
	public virtual ReceiptProof?					ReceiptProof  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("UniqueId", 
					(data, value) => {(data as ContentMeta).UniqueId = value;}, 
					data => (data as ContentMeta).UniqueId ),
		new PropertyString ("Nonce", 
					(data, value) => {(data as ContentMeta).Nonce = value;}, 
					data => (data as ContentMeta).Nonce ),
		new PropertyListString ("Labels", 
					(data, value) => {(data as ContentMeta).Labels = value;}, 
					data => (data as ContentMeta).Labels ),
		new PropertyListStruct ("KeyValues", typeof (KeyValue),
					(data, value) => {(data as ContentMeta).KeyValues = value as List<KeyValue>;}, 
					data => (data as ContentMeta).KeyValues,
					false, ()=>new  List<KeyValue>(), ()=>new KeyValue()),
		new PropertyString ("MessageType", 
					(data, value) => {(data as ContentMeta).MessageType = value;}, 
					data => (data as ContentMeta).MessageType ),
		new PropertyString ("cty", 
					(data, value) => {(data as ContentMeta).ContentType = value;}, 
					data => (data as ContentMeta).ContentType ),
		new PropertyListString ("Paths", 
					(data, value) => {(data as ContentMeta).Paths = value;}, 
					data => (data as ContentMeta).Paths ),
		new PropertyString ("Filename", 
					(data, value) => {(data as ContentMeta).Filename = value;}, 
					data => (data as ContentMeta).Filename ),
		new PropertyString ("Event", 
					(data, value) => {(data as ContentMeta).Event = value;}, 
					data => (data as ContentMeta).Event ),
		new PropertyDateTime ("Created", 
					(data, value) => {(data as ContentMeta).Created = value;}, 
					data => (data as ContentMeta).Created ),
		new PropertyDateTime ("Modified", 
					(data, value) => {(data as ContentMeta).Modified = value;}, 
					data => (data as ContentMeta).Modified ),
		new PropertyDateTime ("Expire", 
					(data, value) => {(data as ContentMeta).Expire = value;}, 
					data => (data as ContentMeta).Expire ),
		new PropertyInteger64 ("First", 
					(data, value) => {(data as ContentMeta).First = value;}, 
					data => (data as ContentMeta).First ),
		new PropertyInteger64 ("Previous", 
					(data, value) => {(data as ContentMeta).Previous = value;}, 
					data => (data as ContentMeta).Previous ),
		new PropertyStruct ("FileEntry", typeof (FileEntry),
					(data, value) => {(data as ContentMeta).FileEntry = value as FileEntry;}, 
					data => (data as ContentMeta).FileEntry,
					false, ()=>new  FileEntry(), ()=>new FileEntry()),
		new PropertyStruct ("ReceiptProof", typeof (ReceiptProof),
					(data, value) => {(data as ContentMeta).ReceiptProof = value as ReceiptProof;}, 
					data => (data as ContentMeta).ReceiptProof,
					false, ()=>new  ReceiptProof(), ()=>new ReceiptProof())
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ContentMeta> _binding = new (
			new() {
			{ "UniqueId", _properties [0]},
			{ "Nonce", _properties [1]},
			{ "Labels", _properties [2]},
			{ "KeyValues", _properties [3]},
			{ "MessageType", _properties [4]},
			{ "cty", _properties [5]},
			{ "Paths", _properties [6]},
			{ "Filename", _properties [7]},
			{ "Event", _properties [8]},
			{ "Created", _properties [9]},
			{ "Modified", _properties [10]},
			{ "Expire", _properties [11]},
			{ "First", _properties [12]},
			{ "Previous", _properties [13]},
			{ "FileEntry", _properties [14]},
			{ "ReceiptProof", _properties [15]}}, __Tag,
		() => new ContentMeta(), () => [], () => [], null, Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class ReceiptProof : Dare {
    /// <summary>
    ///
    /// </summary>

	[JsonPropertyName("PIN")]
	public virtual string?					PIN  {get; set;} //

    /// <summary>
    ///
    /// </summary>

	[JsonPropertyName("Expiry")]
	public virtual DateTime?					Expiry  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("PIN", 
					(data, value) => {(data as ReceiptProof).PIN = value;}, 
					data => (data as ReceiptProof).PIN ),
		new PropertyDateTime ("Expiry", 
					(data, value) => {(data as ReceiptProof).Expiry = value;}, 
					data => (data as ReceiptProof).Expiry )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ReceiptProof> _binding = new (
			new() {
			{ "PIN", _properties [0]},
			{ "Expiry", _properties [1]}}, __Tag,
		() => new ReceiptProof(), () => [], () => [], null, Generic: false);


	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "ReceiptProof";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ReceiptProof();

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

	[JsonPropertyName("dig")]
	public virtual string?					Dig  {get; set;} //

    /// <summary>
    ///Key exchange algorithm
    /// </summary>

	[JsonPropertyName("alg")]
	public virtual string?					Alg  {get; set;} //

    /// <summary>
    ///Key identifier of the signature key.
    /// </summary>

	[JsonPropertyName("kid")]
	public virtual string?					KeyIdentifier  {get; set;} //

    /// <summary>
    ///PKIX certificate of signer.
    /// </summary>

	[JsonPropertyName("cert")]
	public virtual X509Certificate?					Certificate  {get; set;} //

    /// <summary>
    ///PKIX certificates that establish a trust path for the signer.
    /// </summary>

	[JsonPropertyName("path")]
	public virtual X509Certificate?					Path  {get; set;} //

    /// <summary>
    ///The data description that was signed.
    /// </summary>

	[JsonPropertyName("Manifest")]
	public virtual byte[]?					Manifest  {get; set;} //

    /// <summary>
    ///The key used to create the signature.
    /// </summary>

	[JsonPropertyName("SignatureKey")]
	public virtual Key?					SignatureKey  {get; set;} //

    /// <summary>
    ///The signature value as an Enhanced Data Sequence under the envelope base seed.
    /// </summary>

	[JsonPropertyName("signature")]
	public virtual byte[]?					SignatureValue  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("dig", 
					(data, value) => {(data as DareSignature).Dig = value;}, 
					data => (data as DareSignature).Dig ),
		new PropertyString ("alg", 
					(data, value) => {(data as DareSignature).Alg = value;}, 
					data => (data as DareSignature).Alg ),
		new PropertyString ("kid", 
					(data, value) => {(data as DareSignature).KeyIdentifier = value;}, 
					data => (data as DareSignature).KeyIdentifier ),
		new PropertyStruct ("cert", typeof (X509Certificate),
					(data, value) => {(data as DareSignature).Certificate = value as X509Certificate;}, 
					data => (data as DareSignature).Certificate,
					false, ()=>new  X509Certificate(), ()=>new X509Certificate()),
		new PropertyStruct ("path", typeof (X509Certificate),
					(data, value) => {(data as DareSignature).Path = value as X509Certificate;}, 
					data => (data as DareSignature).Path,
					false, ()=>new  X509Certificate(), ()=>new X509Certificate()),
		new PropertyBinary ("Manifest", 
					(data, value) => {(data as DareSignature).Manifest = value;}, 
					data => (data as DareSignature).Manifest ),
		new PropertyStruct ("SignatureKey", typeof (Key), 
					(data, value) => {(data as DareSignature).SignatureKey = value as Key;}, 
					data => (data as DareSignature).SignatureKey,
					true) ,
		new PropertyBinary ("signature", 
					(data, value) => {(data as DareSignature).SignatureValue = value;}, 
					data => (data as DareSignature).SignatureValue )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<DareSignature> _binding = new (
			new() {
			{ "dig", _properties [0]},
			{ "alg", _properties [1]},
			{ "kid", _properties [2]},
			{ "cert", _properties [3]},
			{ "path", _properties [4]},
			{ "Manifest", _properties [5]},
			{ "SignatureKey", _properties [6]},
			{ "signature", _properties [7]}}, __Tag,
		() => new DareSignature(), () => [], () => [], null, Generic: false);


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

	}


	/// <summary>
	///
	/// A digital signature over one or more envelopes consisting of an apex signature value 
	/// </summary>
public partial class IntervalSignature : Dare {
    /// <summary>
    ///The index number of the frame containing the apex signature.
    /// </summary>

	[JsonPropertyName("Index")]
	public virtual long?					Index  {get; set;} //

    /// <summary>
    ///The signed envelopes in order, lowest index first.
    /// </summary>

	[JsonPropertyName("Envelopes")]
	public virtual SignedEnvelope?					Envelopes  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyInteger64 ("Index", 
					(data, value) => {(data as IntervalSignature).Index = value;}, 
					data => (data as IntervalSignature).Index ),
		new PropertyStruct ("Envelopes", typeof (SignedEnvelope),
					(data, value) => {(data as IntervalSignature).Envelopes = value as SignedEnvelope;}, 
					data => (data as IntervalSignature).Envelopes,
					false, ()=>new  SignedEnvelope(), ()=>new SignedEnvelope())
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<IntervalSignature> _binding = new (
			new() {
			{ "Index", _properties [0]},
			{ "Envelopes", _properties [1]}}, __Tag,
		() => new IntervalSignature(), () => [], () => [], null, Generic: false);


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

	}


	/// <summary>
	///
	/// An entry describing one signed envelope within an IntervalSignature
	/// </summary>
public partial class SignedEnvelope : Dare {
    /// <summary>
    ///The index number of the envelope.
    /// </summary>

	[JsonPropertyName("Index")]
	public virtual long?					Index  {get; set;} //

    /// <summary>
    ///The digests required to complete the verification of the signature.		
    /// </summary>

	[JsonPropertyName("Digest")]
	public virtual List<byte[]>?					Digest  {get; set;}

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyInteger64 ("Index", 
					(data, value) => {(data as SignedEnvelope).Index = value;}, 
					data => (data as SignedEnvelope).Index ),
		new PropertyListBinary ("Digest", 
					(data, value) => {(data as SignedEnvelope).Digest = value;}, 
					data => (data as SignedEnvelope).Digest )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<SignedEnvelope> _binding = new (
			new() {
			{ "Index", _properties [0]},
			{ "Digest", _properties [1]}}, __Tag,
		() => new SignedEnvelope(), () => [], () => [], null, Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class X509Certificate : Dare {
    /// <summary>
    ///URL identifying an X.509 public key certificate
    /// </summary>

	[JsonPropertyName("x5u")]
	public virtual string?					X5u  {get; set;} //

    /// <summary>
    ///An X.509 public key certificate
    /// </summary>

	[JsonPropertyName("x5c")]
	public virtual byte[]?					X5  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("x5u", 
					(data, value) => {(data as X509Certificate).X5u = value;}, 
					data => (data as X509Certificate).X5u ),
		new PropertyBinary ("x5c", 
					(data, value) => {(data as X509Certificate).X5 = value;}, 
					data => (data as X509Certificate).X5 )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<X509Certificate> _binding = new (
			new() {
			{ "x5u", _properties [0]},
			{ "x5c", _properties [1]}}, __Tag,
		() => new X509Certificate(), () => [], () => [], null, Generic: false);


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

	[JsonPropertyName("kid")]
	public virtual string?					KeyIdentifier  {get; set;} //

    /// <summary>
    ///The key wrapping and derivation algorithms.
    /// </summary>

	[JsonPropertyName("kwd")]
	public virtual string?					KeyWrapDerivation  {get; set;} //

    /// <summary>
    ///The key parameters of the ephemeral key as specified in JWE
    /// </summary>

	[JsonPropertyName("epk")]
	public virtual Key?					Epk  {get; set;} //

    /// <summary>
    ///Binary cryptographic exchange parameters
    /// </summary>

	[JsonPropertyName("ek")]
	public virtual byte[]?					Ek  {get; set;} //

    /// <summary>
    ///The wrapped base seed. The base seed is encrypted under the result of the key exchange.
    /// </summary>

	[JsonPropertyName("wmk")]
	public virtual byte[]?					WrappedBaseSeed  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("kid", 
					(data, value) => {(data as DareRecipient).KeyIdentifier = value;}, 
					data => (data as DareRecipient).KeyIdentifier ),
		new PropertyString ("kwd", 
					(data, value) => {(data as DareRecipient).KeyWrapDerivation = value;}, 
					data => (data as DareRecipient).KeyWrapDerivation ),
		new PropertyStruct ("epk", typeof (Key), 
					(data, value) => {(data as DareRecipient).Epk = value as Key;}, 
					data => (data as DareRecipient).Epk,
					true) ,
		new PropertyBinary ("ek", 
					(data, value) => {(data as DareRecipient).Ek = value;}, 
					data => (data as DareRecipient).Ek ),
		new PropertyBinary ("wmk", 
					(data, value) => {(data as DareRecipient).WrappedBaseSeed = value;}, 
					data => (data as DareRecipient).WrappedBaseSeed )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<DareRecipient> _binding = new (
			new() {
			{ "kid", _properties [0]},
			{ "kwd", _properties [1]},
			{ "epk", _properties [2]},
			{ "ek", _properties [3]},
			{ "wmk", _properties [4]}}, __Tag,
		() => new DareRecipient(), () => [], () => [], null, Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class DarePolicy : Dare {
    /// <summary>
    ///When applied to a store, indicates it is world readable.
    /// </summary>

	[JsonPropertyName("Public")]
	public virtual bool?					Public  {get; set;} //

    /// <summary>
    ///The encryption algorithm to be used to compute the payload.
    /// </summary>

	[JsonPropertyName("enc")]
	public virtual string?					EncryptionAlgorithm  {get; set;} //

    /// <summary>
    ///The digest algorithm to be used to compute the payload digest.
    /// </summary>

	[JsonPropertyName("dig")]
	public virtual string?					DigestAlgorithm  {get; set;} //

    /// <summary>
    ///The encryption policy specifier, determines how often a key exchange is required.
    ///'Single': All entries are encrypted under the key exchange specified in the 
    ///entry specifying this policy.
    ///'Isolated': All entries are encrypted under a separate key exchange.
    ///'All': All entries are encrypted.
    ///'None': No entries are encrypted.
    ///Default value is 'None' if EncryptKeys is null, and 'All' otherwise.
    /// </summary>

	[JsonPropertyName("Encryption")]
	public virtual string?					Encryption  {get; set;} //

    /// <summary>
    ///The signature policy
    ///'None': No entries are signed.
    ///'Last': The last entry in the container is signed.
    ///'Isolated': All entries are independently signed.
    ///'Any': Entries may be signed.
    ///Default value is 'None' if SignKeys is null, and 'Any' otherwise.
    /// </summary>

	[JsonPropertyName("Signature")]
	public virtual string?					Signature  {get; set;} //

    /// <summary>
    ///The public parameters of keys used for encryption
    /// </summary>

	[JsonPropertyName("EncryptKeys")]
	public virtual List<Key>?					EncryptKeys  {get; set;}
    /// <summary>
    ///The public parameters of the signing keys under which records are signed in accordance
    ///with the Signature policy
    /// </summary>

	[JsonPropertyName("SignKeys")]
	public virtual List<Key>?					SignKeys  {get; set;}
    /// <summary>
    ///If true the policy is immutable and cannot be changed by a subsequent policy override.
    /// </summary>

	[JsonPropertyName("Sealed")]
	public virtual bool?					Sealed  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyBoolean ("Public", 
					(data, value) => {(data as DarePolicy).Public = value;}, 
					data => (data as DarePolicy).Public ),
		new PropertyString ("enc", 
					(data, value) => {(data as DarePolicy).EncryptionAlgorithm = value;}, 
					data => (data as DarePolicy).EncryptionAlgorithm ),
		new PropertyString ("dig", 
					(data, value) => {(data as DarePolicy).DigestAlgorithm = value;}, 
					data => (data as DarePolicy).DigestAlgorithm ),
		new PropertyString ("Encryption", 
					(data, value) => {(data as DarePolicy).Encryption = value;}, 
					data => (data as DarePolicy).Encryption ),
		new PropertyString ("Signature", 
					(data, value) => {(data as DarePolicy).Signature = value;}, 
					data => (data as DarePolicy).Signature ),
		new PropertyListStruct ("EncryptKeys", typeof (Key), 
					(data, value) => {(data as DarePolicy).EncryptKeys = value as List<Key>;}, 
					data => (data as DarePolicy).EncryptKeys,
					true, ()=>new List<Key>()
) ,
		new PropertyListStruct ("SignKeys", typeof (Key), 
					(data, value) => {(data as DarePolicy).SignKeys = value as List<Key>;}, 
					data => (data as DarePolicy).SignKeys,
					true, ()=>new List<Key>()
) ,
		new PropertyBoolean ("Sealed", 
					(data, value) => {(data as DarePolicy).Sealed = value;}, 
					data => (data as DarePolicy).Sealed )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<DarePolicy> _binding = new (
			new() {
			{ "Public", _properties [0]},
			{ "enc", _properties [1]},
			{ "dig", _properties [2]},
			{ "Encryption", _properties [3]},
			{ "Signature", _properties [4]},
			{ "EncryptKeys", _properties [5]},
			{ "SignKeys", _properties [6]},
			{ "Sealed", _properties [7]}}, __Tag,
		() => new DarePolicy(), () => [], () => [], null, Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class FileEntry : Dare {
    /// <summary>
    ///The file path in canonical form. 
    /// </summary>

	[JsonPropertyName("Path")]
	public virtual string?					Path  {get; set;} //

    /// <summary>
    ///The creation time of the file on disk in UTC
    /// </summary>

	[JsonPropertyName("CreationTime")]
	public virtual DateTime?					CreationTime  {get; set;} //

    /// <summary>
    ///The last access time of the file on disk in UTC
    /// </summary>

	[JsonPropertyName("LastAccessTime")]
	public virtual DateTime?					LastAccessTime  {get; set;} //

    /// <summary>
    ///The last write time of the file on disk in UTC
    /// </summary>

	[JsonPropertyName("LastWriteTime")]
	public virtual DateTime?					LastWriteTime  {get; set;} //

    /// <summary>
    ///The file attribues as a bitmapped integer.
    /// </summary>

	[JsonPropertyName("Attributes")]
	public virtual int?					Attributes  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("Path", 
					(data, value) => {(data as FileEntry).Path = value;}, 
					data => (data as FileEntry).Path ),
		new PropertyDateTime ("CreationTime", 
					(data, value) => {(data as FileEntry).CreationTime = value;}, 
					data => (data as FileEntry).CreationTime ),
		new PropertyDateTime ("LastAccessTime", 
					(data, value) => {(data as FileEntry).LastAccessTime = value;}, 
					data => (data as FileEntry).LastAccessTime ),
		new PropertyDateTime ("LastWriteTime", 
					(data, value) => {(data as FileEntry).LastWriteTime = value;}, 
					data => (data as FileEntry).LastWriteTime ),
		new PropertyInteger32 ("Attributes", 
					(data, value) => {(data as FileEntry).Attributes = value;}, 
					data => (data as FileEntry).Attributes )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<FileEntry> _binding = new (
			new() {
			{ "Path", _properties [0]},
			{ "CreationTime", _properties [1]},
			{ "LastAccessTime", _properties [2]},
			{ "LastWriteTime", _properties [3]},
			{ "Attributes", _properties [4]}}, __Tag,
		() => new FileEntry(), () => [], () => [], null, Generic: false);


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

	}


	/// <summary>
	///
	/// Entry containing the latest apex value of a specified append only log.
	/// </summary>
public partial class Witness : Dare {
    /// <summary>
    ///Globally unique log identifier
    /// </summary>

	[JsonPropertyName("Id")]
	public virtual string?					Id  {get; set;} //

    /// <summary>
    ///The issuer of the log
    /// </summary>

	[JsonPropertyName("Issuer")]
	public virtual string?					Issuer  {get; set;} //

    /// <summary>
    ///The Apex hash value
    /// </summary>

	[JsonPropertyName("Apex")]
	public virtual byte[]?					Apex  {get; set;} //

    /// <summary>
    ///Specifies the index number assigned to the entry in the log.
    /// </summary>

	[JsonPropertyName("Index")]
	public virtual long?					Index  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("Id", 
					(data, value) => {(data as Witness).Id = value;}, 
					data => (data as Witness).Id ),
		new PropertyString ("Issuer", 
					(data, value) => {(data as Witness).Issuer = value;}, 
					data => (data as Witness).Issuer ),
		new PropertyBinary ("Apex", 
					(data, value) => {(data as Witness).Apex = value;}, 
					data => (data as Witness).Apex ),
		new PropertyInteger64 ("Index", 
					(data, value) => {(data as Witness).Index = value;}, 
					data => (data as Witness).Index )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<Witness> _binding = new (
			new() {
			{ "Id", _properties [0]},
			{ "Issuer", _properties [1]},
			{ "Apex", _properties [2]},
			{ "Index", _properties [3]}}, __Tag,
		() => new Witness(), () => [], () => [], null, Generic: false);


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

	}


	/// <summary>
	///
	/// Provides a proof that the payload with digest [hash] in the log described by 
	/// SignedWitness occurs at the index [Index]
	/// </summary>
public partial class Proof : Dare {
	/// <summary>
	/// Wrapped property
    /// </summary>
	[JsonPropertyName("EnvelopedWitness")]
	public virtual Enveloped<Witness>?					EnvelopedWitness  {get; set;} 

	/// <summary>
	/// Wrapped property
    /// </summary>
	public virtual Witness?				Witness  => EnvelopedWitness.Decode();
    /// <summary>
    ///
    /// </summary>

	[JsonPropertyName("Hash")]
	public virtual byte[]?					Hash  {get; set;} //

    /// <summary>
    ///Specifies the index number assigned to the entry in the log.
    /// </summary>

	[JsonPropertyName("Index")]
	public virtual long?					Index  {get; set;} //

    /// <summary>
    ///The list of entries from which the proof path is computed.
    /// </summary>

	[JsonPropertyName("Path")]
	public virtual List<byte[]>?					Path  {get; set;}

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyGStruct ("EnvelopedWitness", typeof (Enveloped),
					(data, value) => {(data as Proof).EnvelopedWitness = value as Enveloped<Witness>;},
					data => (data as Proof).EnvelopedWitness,
					()=>new  Enveloped<Witness>(), ()=>new Enveloped<Witness>()),
		new PropertyBinary ("Hash", 
					(data, value) => {(data as Proof).Hash = value;}, 
					data => (data as Proof).Hash ),
		new PropertyInteger64 ("Index", 
					(data, value) => {(data as Proof).Index = value;}, 
					data => (data as Proof).Index ),
		new PropertyListBinary ("Path", 
					(data, value) => {(data as Proof).Path = value;}, 
					data => (data as Proof).Path )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<Proof> _binding = new (
			new() {
			{ "EnvelopedWitness", _properties [0]},
			{ "Hash", _properties [1]},
			{ "Index", _properties [2]},
			{ "Path", _properties [3]}}, __Tag,
		() => new Proof(), () => [], () => [], null, Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class Unprotected : Dare {
    /// <summary>
    ///The digest algorithm to be used to compute the payload digest.
    /// </summary>

	[JsonPropertyName("dig")]
	public virtual string?					DigestAlgorithm  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("signs")]
	public virtual List<EarlSignature>?					Signers  {get; set;}
    /// <summary>
    /// </summary>

	[JsonPropertyName("sigs")]
	public virtual List<EarlSignature>?					Signatures  {get; set;}
    /// <summary>
    ///The number of the entry in the sequence.
    /// </summary>

	[JsonPropertyName("Frame")]
	public virtual long?					Frame  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("dig", 
					(data, value) => {(data as Unprotected).DigestAlgorithm = value;}, 
					data => (data as Unprotected).DigestAlgorithm ),
		new PropertyListStruct ("signs", typeof (EarlSignature),
					(data, value) => {(data as Unprotected).Signers = value as List<EarlSignature>;}, 
					data => (data as Unprotected).Signers,
					false, ()=>new  List<EarlSignature>(), ()=>new EarlSignature()),
		new PropertyListStruct ("sigs", typeof (EarlSignature),
					(data, value) => {(data as Unprotected).Signatures = value as List<EarlSignature>;}, 
					data => (data as Unprotected).Signatures,
					false, ()=>new  List<EarlSignature>(), ()=>new EarlSignature()),
		new PropertyInteger64 ("Frame", 
					(data, value) => {(data as Unprotected).Frame = value;}, 
					data => (data as Unprotected).Frame )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<Unprotected> _binding = new (
			new() {
			{ "dig", _properties [0]},
			{ "signs", _properties [1]},
			{ "sigs", _properties [2]},
			{ "Frame", _properties [3]}}, __Tag,
		() => new Unprotected(), () => [], () => [], null, Generic: false);


	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "Unprotected";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new Unprotected();

	}


	/// <summary>
	/// </summary>
public partial class EarlSignature : Dare {
    /// <summary>
    ///Key exchange algorithm
    /// </summary>

	[JsonPropertyName("alg")]
	public virtual string?					Alg  {get; set;} //

    /// <summary>
    ///Key identifier of the signature key.		
    /// </summary>

	[JsonPropertyName("kid")]
	public virtual string?					KeyIdentifier  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("val")]
	public virtual byte[]?					Value  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("alg", 
					(data, value) => {(data as EarlSignature).Alg = value;}, 
					data => (data as EarlSignature).Alg ),
		new PropertyString ("kid", 
					(data, value) => {(data as EarlSignature).KeyIdentifier = value;}, 
					data => (data as EarlSignature).KeyIdentifier ),
		new PropertyBinary ("val", 
					(data, value) => {(data as EarlSignature).Value = value;}, 
					data => (data as EarlSignature).Value )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<EarlSignature> _binding = new (
			new() {
			{ "alg", _properties [0]},
			{ "kid", _properties [1]},
			{ "val", _properties [2]}}, __Tag,
		() => new EarlSignature(), () => [], () => [], null, Generic: false);


	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "EarlSignature";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new EarlSignature();

	}


	/// <summary>
	/// </summary>
public partial class DareSequence : Dare {
    /// <summary>
    /// </summary>

	[JsonPropertyName("Envelopes")]
	public virtual List<DareEnvelope>?					Envelopes  {get; set;}

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyListStruct ("Envelopes", typeof (DareEnvelope),
					(data, value) => {(data as DareSequence).Envelopes = value as List<DareEnvelope>;}, 
					data => (data as DareSequence).Envelopes,
					false, ()=>new  List<DareEnvelope>(), ()=>new DareEnvelope())
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<DareSequence> _binding = new (
			new() {
			{ "Envelopes", _properties [0]}}, __Tag,
		() => new DareSequence(), () => [], () => [], null, Generic: false);


	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "DareSequence";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new DareSequence();

	}


	/// <summary>
	/// </summary>
public partial class DareEnvelope : Dare {
    /// <summary>
    /// </summary>

	[JsonPropertyName("unsigned")]
	public virtual DareHeader?					Unsigned  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("signed")]
	public virtual byte[]?					Signed  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("payload")]
	public virtual byte[]?					Payload  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("trailer")]
	public virtual DareTrailer?					Trailer  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyStruct ("unsigned", typeof (DareHeader),
					(data, value) => {(data as DareEnvelope).Unsigned = value as DareHeader;}, 
					data => (data as DareEnvelope).Unsigned,
					false, ()=>new  DareHeader(), ()=>new DareHeader()),
		new PropertyBinary ("signed", 
					(data, value) => {(data as DareEnvelope).Signed = value;}, 
					data => (data as DareEnvelope).Signed ),
		new PropertyBinary ("payload", 
					(data, value) => {(data as DareEnvelope).Payload = value;}, 
					data => (data as DareEnvelope).Payload ),
		new PropertyStruct ("trailer", typeof (DareTrailer),
					(data, value) => {(data as DareEnvelope).Trailer = value as DareTrailer;}, 
					data => (data as DareEnvelope).Trailer,
					false, ()=>new  DareTrailer(), ()=>new DareTrailer())
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<DareEnvelope> _binding = new (
			new() {
			{ "unsigned", _properties [0]},
			{ "signed", _properties [1]},
			{ "payload", _properties [2]},
			{ "trailer", _properties [3]}}, __Tag,
		() => new DareEnvelope(), () => [], () => [], null, Generic: true);


	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "DareEnvelope";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new DareEnvelope();

	}


	/// <summary>
	/// </summary>
public partial class TerminalIndex : Dare {
    /// <summary>
    /// </summary>

	[JsonPropertyName("Entries")]
	public virtual List<FileIndex>?					Entries  {get; set;}

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyListStruct ("Entries", typeof (FileIndex),
					(data, value) => {(data as TerminalIndex).Entries = value as List<FileIndex>;}, 
					data => (data as TerminalIndex).Entries,
					false, ()=>new  List<FileIndex>(), ()=>new FileIndex())
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<TerminalIndex> _binding = new (
			new() {
			{ "Entries", _properties [0]}}, __Tag,
		() => new TerminalIndex(), () => [], () => [], null, Generic: false);


	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "TerminalIndex";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new TerminalIndex();

	}


	/// <summary>
	/// </summary>
public partial class FileIndex : Dare {
    /// <summary>
    ///The number of the entry in the sequence.
    /// </summary>

	[JsonPropertyName("Frame")]
	public virtual long?					Frame  {get; set;} //

    /// <summary>
    ///Position of the start of the frame
    /// </summary>

	[JsonPropertyName("FrameStart")]
	public virtual long?					FrameStart  {get; set;} //

    /// <summary>
    ///The frame length (including length markers)
    /// </summary>

	[JsonPropertyName("FrameLength")]
	public virtual long?					FrameLength  {get; set;} //

    /// <summary>
    ///Position of the start of the Payload
    /// </summary>

	[JsonPropertyName("PayloadStart")]
	public virtual long?					PayloadStart  {get; set;} //

    /// <summary>
    ///The payload length
    /// </summary>

	[JsonPropertyName("PayloadLength")]
	public virtual long?					PayloadLength  {get; set;} //

    /// <summary>
    ///The name of the file on disk
    /// </summary>

	[JsonPropertyName("Filename")]
	public virtual string?					Filename  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyInteger64 ("Frame", 
					(data, value) => {(data as FileIndex).Frame = value;}, 
					data => (data as FileIndex).Frame ),
		new PropertyInteger64 ("FrameStart", 
					(data, value) => {(data as FileIndex).FrameStart = value;}, 
					data => (data as FileIndex).FrameStart ),
		new PropertyInteger64 ("FrameLength", 
					(data, value) => {(data as FileIndex).FrameLength = value;}, 
					data => (data as FileIndex).FrameLength ),
		new PropertyInteger64 ("PayloadStart", 
					(data, value) => {(data as FileIndex).PayloadStart = value;}, 
					data => (data as FileIndex).PayloadStart ),
		new PropertyInteger64 ("PayloadLength", 
					(data, value) => {(data as FileIndex).PayloadLength = value;}, 
					data => (data as FileIndex).PayloadLength ),
		new PropertyString ("Filename", 
					(data, value) => {(data as FileIndex).Filename = value;}, 
					data => (data as FileIndex).Filename )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<FileIndex> _binding = new (
			new() {
			{ "Frame", _properties [0]},
			{ "FrameStart", _properties [1]},
			{ "FrameLength", _properties [2]},
			{ "PayloadStart", _properties [3]},
			{ "PayloadLength", _properties [4]},
			{ "Filename", _properties [5]}}, __Tag,
		() => new FileIndex(), () => [], () => [], null, Generic: false);


	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "FileIndex";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new FileIndex();

	}


	/// <summary>
	/// </summary>
public partial class EntryUpdateSet : Dare {
    /// <summary>
    /// </summary>

	[JsonPropertyName("Entries")]
	public virtual List<EntryUpdate>?					Entries  {get; set;}

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyListStruct ("Entries", typeof (EntryUpdate),
					(data, value) => {(data as EntryUpdateSet).Entries = value as List<EntryUpdate>;}, 
					data => (data as EntryUpdateSet).Entries,
					false, ()=>new  List<EntryUpdate>(), ()=>new EntryUpdate())
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<EntryUpdateSet> _binding = new (
			new() {
			{ "Entries", _properties [0]}}, __Tag,
		() => new EntryUpdateSet(), () => [], () => [], null, Generic: false);


	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "EntryUpdateSet";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new EntryUpdateSet();

	}


	/// <summary>
	/// </summary>
public partial class EntryUpdate : Dare {
    /// <summary>
    /// </summary>

	[JsonPropertyName("Id")]
	public virtual string?					Id  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("Event")]
	public virtual string?					Event  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("Id", 
					(data, value) => {(data as EntryUpdate).Id = value;}, 
					data => (data as EntryUpdate).Id ),
		new PropertyString ("Event", 
					(data, value) => {(data as EntryUpdate).Event = value;}, 
					data => (data as EntryUpdate).Event )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<EntryUpdate> _binding = new (
			new() {
			{ "Id", _properties [0]},
			{ "Event", _properties [1]}}, __Tag,
		() => new EntryUpdate(), () => [], () => [], null, Generic: false);


	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "EntryUpdate";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new EntryUpdate();

	}



