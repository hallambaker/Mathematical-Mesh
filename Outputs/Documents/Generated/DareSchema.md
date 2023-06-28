

#DARE Schema

A DARE Envelope consists of a Header, an Enhanced Data Sequence (EDS) and 
an optional trailer. This section describes the JSON data fields used to 
construct headers, trailers and complete envelopes.

Wherever possible, fields from JWE, JWS and JWK have been used. In these cases,
the fields have the exact same semantics. Note however that the classes in 
which these fields are presented have different structure and nesting.

##Envelope Classes

A DARE envelope contains a single DAREMessageSequence in either the JSON or 
Compact serialization as directed by the protocol in which it is applied.

###Structure: DareEnvelopeSequence

A DARE envelope containing Header, EDS and Trailer in JSON object encoding.
Since a DAREMessage is almost invariably presented in JSON sequence or
compact encoding, use of the DAREMessage subclass is preferred.

Although a DARE envelope is functionally an object, it is serialized as 
an ordered sequence. This ensures that the envelope header field will always
precede the body in a serialization, this allowing processing of the header
information to be performed before the entire body has been received.

<dl>
<dt>Header: DareHeader (Optional)
<dd>The envelope header. May specify the key exchange data, pre-signature 
or signature data, cloaked headers and/or encrypted data sequences.
<dt>Body: Binary (Optional)
<dd>The envelope body
<dt>Trailer: DareTrailer (Optional)
<dd>The envelope trailer. If present, this contains the signature.
</dl>
##Header and Trailer Classes

A DARE sequence MUST contain a (possibly empty) DAREHeader and MAY contain
a DARETrailer. 

###Structure: DareTrailer

A DARE envelope Trailer

<dl>
<dt>Signatures: DareSignature [0..Many]
<dd>A list of signatures.
A envelope trailer MUST NOT contain a signatures field if the header contains 
a signatures field.
<dt>ApexSignatures: DareSignature [0..Many]
<dd>A list of signatures over the apex digest.
A envelope trailer MUST NOT contain av apex field if the header contains 
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

A DARE Envelope Header. Since any field that is present in a trailer MAY be 
placed in a header instead, the envelope header inherits from the trailer.

<dl>
<dt>EnvelopeId: String (Optional)
<dd>Unique identifier
<dt>EncryptionAlgorithm: String (Optional)
<dd>The encryption algorithm as specified in JWE
<dt>DigestAlgorithm: String (Optional)
<dd>Digest Algorithm. If specified, tells decoder that the digest algorithm is used to
construct a signature over the envelope payload.
<dt>KeyIdentifier: String (Optional)
<dd>Base seed identifier.
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
in the envelope and context headers.
<dd>When specified in a header, a cloaked field MAY be used to conceal metadata 
(content type, compression) and/or to specify an additional layer of key exchange. 
That applies to both the envelope body and to headers specified within the cloaked 
header.
<dd>Processing of cloaked data is described in…
<dt>EDSS: Binary [0..Many]
<dd>If present, the Annotations field contains a sequence of Encrypted Data 
Segments encrypted under the envelope base seed. The interpretation of these fields 
is application specific.
<dt>Recipients: DareRecipient [0..Many]
<dd>A list of recipient key exchange information blocks.
<dt>Policy: DarePolicy (Optional)
<dd>A DARE security policy governing future additions to the container.
<dt>ContentMetaData: Binary (Optional)
<dd>If present contains a JSON encoded ContentInfo structure which specifies
plaintext content metadata and forms one of the inputs to the envelope digest value.
<dt>SequenceInfo: SequenceInfo (Optional)
<dd>Information that describes container information
<dt>SequenceIndex: SequenceIndex (Optional)
<dd>An index of records in the current container up to but not including
this one.
<dt>Received: DateTime (Optional)
<dd>Date on which the envelope was received.
<dt>Cover: Binary (Optional)
<dd>HTML document containing cover text to be presented if the document cannot be decrypted.
<dt>Bitmask: Binary (Optional)
<dd>Bitmask used to identify a container within a group for use in update notification
etc.
<dt>Debug: String (Optional)
<dd>Field reserved for use in debugging.
</dl>
###Structure: ContentMeta

<dl>
<dt>UniqueId: String (Optional)
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
<dt>FileEntry: FileEntry (Optional)
<dd>Information describing the file entry on disk.
</dl>
##Cryptographic Data

DARE envelope uses the same fields as JWE and JWS but with different
structure. In particular, DARE envelopes MAY have multiple recipients
and multiple signers.

###Structure: DareSignature

The signature value

<dl>
<dt>Dig: String (Optional)
<dd>Digest algorithm hint. Specifying the digest algorithm to be applied
to the envelope body allows the body to be processed in streaming mode.
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
<dd>The signature value as an Enhanced Data Sequence under the envelope base seed.
<dt>WitnessValue: Binary (Optional)
<dd>The signature witness value used on an encrypted envelope to demonstrate that 
the signature was authorized by a party with actual knowledge of the encryption 
key used to encrypt the envelope.
</dl>
###Structure: IntervalSignature

A digital signature over one or more envelopes consisting of an apex signature value 

<dl>
<dt>Index: Integer (Optional)
<dd>The index number of the frame containing the apex signature.
<dt>Envelopes: SignedEnvelope (Optional)
<dd>The signed envelopes in order, lowest index first.
</dl>
###Structure: SignedEnvelope

An entry describing one signed envelope within an IntervalSignature

<dl>
<dt>Index: Integer (Optional)
<dd>The index number of the envelope.
<dt>Digest: Binary [0..Many]
<dd>The digests required to complete the verification of the signature.		
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
<dt>WrappedBaseSeed: Binary (Optional)
<dd>The wrapped base seed. The base seed is encrypted under the result of the key exchange.
<dt>RecipientKeyData: String (Optional)
<dd>The per-recipient key exchange data.
</dl>
###Structure: DarePolicy

<dl>
<dt>Public: Boolean (Optional)
<dd>When applied to a store, indicates it is world readable.
<dt>EncryptionAlgorithm: String (Optional)
<dd>The encryption algorithm to be used to compute the payload.
<dt>DigestAlgorithm: String (Optional)
<dd>The digest algorithm to be used to compute the payload digest.
<dt>Encryption: String (Optional)
<dd>The encryption policy specifier, determines how often a key exchange is required.
'Single': All entries are encrypted under the key exchange specified in the 
entry specifying this policy.
'Isolated': All entries are encrypted under a separate key exchange.
'All': All entries are encrypted.
'None': No entries are encrypted.
<dd>Default value is 'None' if EncryptKeys is null, and 'All' otherwise.
<dt>Signature: String (Optional)
<dd>The signature policy
'None': No entries are signed.
'Last': The last entry in the container is signed.
'Isolated': All entries are independently signed.
'Any': Entries may be signed.
<dd>Default value is 'None' if SignKeys is null, and 'Any' otherwise.
<dt>Sealed: Boolean (Optional)
<dd>If true the policy is immutable and cannot be changed by a subsequent policy override.
</dl>
###Structure: FileEntry

<dl>
<dt>Path: String (Optional)
<dd>The file path in canonical form. 
<dt>CreationTime: DateTime (Optional)
<dd>The creation time of the file on disk in UTC
<dt>LastAccessTime: DateTime (Optional)
<dd>The last access time of the file on disk in UTC
<dt>LastWriteTime: DateTime (Optional)
<dd>The last write time of the file on disk in UTC
<dt>Attributes: Integer (Optional)
<dd>The file attribues as a bitmapped integer.
</dl>
###Structure: Witness

Entry containing the latest apex value of a specified append only log.

<dl>
<dt>Id: String (Optional)
<dd>Globally unique log identifier
<dt>Issuer: String (Optional)
<dd>The issuer of the log
<dt>Apex: Binary (Optional)
<dd>The Apex hash value
<dt>Index: Integer (Optional)
<dd>Specifies the index number assigned to the entry in the log.
</dl>
###Structure: Proof

Provides a proof that the payload with digest [hash] in the log described by 
SignedWitness occurs at the index [Index]

<dl>
<dt>SignedWitness: DareEnvelope (Optional)
<dd>The signed apex under which this proof chain is established
<dt>Hash: Binary (Optional)
<dd>
<dt>Index: Integer (Optional)
<dd>Specifies the index number assigned to the entry in the log.
<dt>Path: Binary [0..Many]
<dd>The list of entries from which the proof path is computed.
</dl>
