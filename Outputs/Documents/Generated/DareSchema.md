

#DARE Schema

A DARE Envelope consists of a Header, an Enhanced Data Sequence (EDS) and 
an optional trailer. This section describes the JSON data fields used to 
construct headers, trailers and complete messages.

Wherever possible, fields from JWE, JWS and JWK have been used. In these cases,
the fields have the exact same semantics. Note however that the classes in 
which these fields are presented have different structure and nesting.

##Message Classes

A DARE Message contains a single DAREMessageSequence in either the JSON or 
Compact serialization as directed by the protocol in which it is applied.

###Structure: DareEnvelopeSequence

A DARE Message containing Header, EDS and Trailer in JSON object encoding.
Since a DAREMessage is almost invariably presented in JSON sequence or
compact encoding, use of the DAREMessage subclass is preferred.

Although a DARE Message is functionally an object, it is serialized as 
an ordered sequence. This ensures that the message header field will always
precede the body in a serialization, this allowing processing of the header
information to be performed before the entire body has been received.

<dl>
<dt>Header: DareHeader (Optional)
<dd>The message header. May specify the key exchange data, pre-signature 
or signature data, cloaked headers and/or encrypted data sequences.
<dt>Body: Binary (Optional)
<dd>The message body
<dt>Trailer: DareTrailer (Optional)
<dd>The message trailer. If present, this contains the signature.
</dl>
##Header and Trailer Classes

A DARE Message sequence MUST contain a (possibly empty) DAREHeader and MAY contain
a DARETrailer. 

###Structure: DareTrailer

A DARE Message Trailer

<dl>
<dt>Signatures: DareSignature [0..Many]
<dd>A list of signatures.
A message trailer MUST NOT contain a signatures field if the header contains 
a signatures field.
<dt>SignedData: Binary (Optional)
<dd>Contains a DAREHeader object 
<dt>PayloadDigest: Binary (Optional)
<dd>If present, contains the digest of the Payload.
<dt>ChainDigest: Binary (Optional)
<dd>If present, contains the digest of the PayloadDigest values of this
frame and the frame immediately preceding.
<dt>TreeDigest: Binary (Optional)
<dd>If present, contains the Binary Merkle Tree digest value.
</dl>
###Structure: DareHeader

<dl>
<dt>Inherits:  DareTrailer
</dl>

A DARE Message Header. Since any field that is present in a trailer MAY be 
placed in a header instead, the message header inherits from the trailer.

<dl>
<dt>EnvelopeID: String (Optional)
<dd>Unique identifier
<dt>EncryptionAlgorithm: String (Optional)
<dd>The encryption algorithm as specified in JWE
<dt>DigestAlgorithm: String (Optional)
<dd>Digest Algorithm. If specified, tells decoder that the digest algorithm is used to
construct a signature over the message payload.
<dt>KeyIdentifier: String (Optional)
<dd>Master key identifier.
<dt>Salt: Binary (Optional)
<dd>Salt value used to derrive cryptographic parameters for the content data.
<dt>Malt: Binary (Optional)
<dd>Hash of the Salt value used to derrive cryptographic parameters for the content data.
This field SHOULD NOT be present if the Salt field is present. It is used to
allow the salt value to be erased (thus rendering the payload content irrecoverable)
without affecting the ability to calculate the payload digest value.
<dt>Cloaked: Binary (Optional)
<dd>If present in a header or trailer, specifies an encrypted data block 
containing additional header fields whose values override those specified 
in the message and context headers.
<dd>When specified in a header, a cloaked field MAY be used to conceal metadata 
(content type, compression) and/or to specify an additional layer of key exchange. 
That applies to both the Message body and to headers specified within the cloaked 
header.
<dd>Processing of cloaked data is described in…
<dt>EDSS: Binary [0..Many]
<dd>If present, the Annotations field contains a sequence of Encrypted Data 
Segments encrypted under the message Master Key. The interpretation of these fields 
is application specific.
<dt>Signers: DareSignature [0..Many]
<dd>A list of 'presignature'
<dt>Recipients: DareRecipient [0..Many]
<dd>A list of recipient key exchange information blocks.
<dt>ContentMetaData: Binary (Optional)
<dd>If present contains a JSON encoded ContentInfo structure which specifies
plaintext content metadata and forms one of the inputs to the envelope digest value.
<dt>ContainerInfo: ContainerInfo (Optional)
<dd>Information that describes container information
<dt>ContainerIndex: ContainerIndex (Optional)
<dd>An index of records in the current container up to but not including
this one.
<dt>Received: DateTime (Optional)
<dd>Date on which the envelope was received.
</dl>
###Structure: ContentMeta

<dl>
<dt>UniqueID: String (Optional)
<dd>Unique object identifier
<dt>Labels: String [0..Many]
<dd>List of labels that are applied to the payload of the frame.
<dt>KeyValues: KeyValue [0..Many]
<dd>List of key/value pairs describing the payload of the frame.
<dt>MessageType: String (Optional)
<dd>The mesh message type
<dt>ContentType: String (Optional)
<dd>The content type field as specified in JWE
<dt>Paths: String [0..Many]
<dd>List of filename paths for the payload of the frame.
<dt>Filename: String (Optional)
<dd>The original filename under which the data was stored.
<dt>Event: String (Optional)
<dd>Operation on the header
<dt>Created: DateTime (Optional)
<dd>Initial creation date.
<dt>Modified: DateTime (Optional)
<dd>Date of last modification.
<dt>Expire: DateTime (Optional)
<dd>Date at which the associated transaction will expire
<dt>First: Integer (Optional)
<dd>Frame number of the first object instance value.
<dt>Previous: Integer (Optional)
<dd>Frame number of the immediately prior object instance value	
</dl>
##Cryptographic Data

DARE Message uses the same fields as JWE and JWS but with different
structure. In particular, DARE messages MAY have multiple recipients
and multiple signers.

###Structure: DareSignature

The signature value

<dl>
<dt>Dig: String (Optional)
<dd>Digest algorithm hint. Specifying the digest algorithm to be applied
to the message body allows the body to be processed in streaming mode.
<dt>Alg: String (Optional)
<dd>Key exchange algorithm
<dt>KeyIdentifier: String (Optional)
<dd>Key identifier of the signature key.
<dt>Certificate: X509Certificate (Optional)
<dd>PKIX certificate of signer.
<dt>Path: X509Certificate (Optional)
<dd>PKIX certificates that establish a trust path for the signer.
<dt>Manifest: Binary (Optional)
<dd>The data description that was signed.
<dt>SignatureValue: Binary (Optional)
<dd>The signature value as an Enhanced Data Sequence under the message Master Key.
<dt>WitnessValue: Binary (Optional)
<dd>The signature witness value used on an encrypted message to demonstrate that 
the signature was authorized by a party with actual knowledge of the encryption 
key used to encrypt the message.
</dl>
###Structure: X509Certificate

<dl>
<dt>X5u: String (Optional)
<dd>URL identifying an X.509 public key certificate
<dt>X5: Binary (Optional)
<dd>An X.509 public key certificate
</dl>
###Structure: DareRecipient

Recipient information

<dl>
<dt>KeyIdentifier: String (Optional)
<dd>Key identifier for the encryption key.
<dd>The Key identifier MUST be either a UDF fingerprint of a key or a Group Key Identifier
<dt>KeyWrapDerivation: String (Optional)
<dd>The key wrapping and derivation algorithms.
<dt>WrappedMasterKey: Binary (Optional)
<dd>The wrapped master key. The master key is encrypted under the result of the key exchange.
<dt>RecipientKeyData: String (Optional)
<dd>The per-recipient key exchange data.
</dl>
