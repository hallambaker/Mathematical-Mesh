

##Shared Classes

The following classes are used as common elements in
Mesh profile specifications.

###Classes describing keys

###Structure: KeyData

The KeyData class is used to describe public key pairs and 
trust assertions associated with a public key.

<dl>
<dt>Udf: String (Optional)
<dd>UDF fingerprint of the public key parameters
<dt>X509Certificate: Binary (Optional)
<dd>List of X.509 Certificates
<dt>X509Chain: Binary [0..Many]
<dd>X.509 Certificate chain.
<dt>X509CSR: Binary (Optional)
<dd>X.509 Certificate Signing Request.
<dt>NotBefore: DateTime (Optional)
<dd>If present specifies a time instant that use of the private key
is not valid before.
<dt>NotOnOrAfter: DateTime (Optional)
<dd>If present specifies a time instant that use of the private key
is not valid on or after.
</dl>
###Structure: KeyShare

<dl>
<dt>Inherits:  Key
</dl>

<dl>
<dt>ServiceId: String (Optional)
<dd>The identifier used to claim the capability from the service.[Only present for
a partial key.]
<dt>ServiceAddress: String (Optional)
<dd>The service account that supports a serviced capability. [Only present for
a partial key.]	
</dl>
###Structure: CompositePrivate

<dl>
<dt>Inherits:  Key
</dl>

<dl>
<dt>DeviceKeyUdf: String (Optional)
<dd>UDF fingerprint of the bound device key (if used).
</dl>
##Assertion classes

Classes that are derived from an assertion.

###Structure: Assertion

Parent class from which all assertion classes are derived

<dl>
<dt>Names: String [0..Many]
<dd>Fingerprints of index terms for profile retrieval. The use of the fingerprint
of the name rather than the name itself is a precaution against enumeration
attacks and other forms of abuse.
<dt>Updated: DateTime (Optional)
<dd>The time instant the profile was last modified.
<dt>NotaryToken: String (Optional)
<dd>A Uniform Notary Token providing evidence that a signature
was performed after the notary token was created.
</dl>
###Structure: Condition

Parent class from which all condition classes are derived.

[No fields]

###Base Classes

Abstract classes from which the Profile, Activation and Connection classes
are derrived.

###Structure: Activation

<dl>
<dt>Inherits:  Assertion
</dl>

Contains the private activation information for a Mesh application running on
a specific device

<dl>
<dt>ActivationKey: String (Optional)
<dd>Secret seed used to derive keys that are not explicitly specified.
<dt>Entries: ActivationEntry [0..Many]
<dd>Activation of named account resource activations. These are separate from
Application activations which are 
</dl>
###Structure: ActivationEntry

<dl>
<dt>Resource: String (Optional)
<dd>Name of the activated resource
<dt>Key: KeyData (Optional)
<dd>The activation key or key share
<dt>ServiceId: String (Optional)
<dd>The identifier used to claim the capability from the service.[Only present for
a partial capability.]
<dt>ServiceAddress: String (Optional)
<dd>The service account that supports a serviced capability. [Only present for
a partial capability.]
</dl>
###Mesh Profile Classes

Classes describing Mesh Profiles. All Profiles are Assertions
derrived from Assertion.

###Structure: Profile

<dl>
<dt>Inherits:  Assertion
</dl>

Parent class from which all profile classes are derived

<dl>
<dt>Description: String (Optional)
<dd>Description of the profile
<dt>ProfileSignature: KeyData (Optional)
<dd>The permanent signature key used to sign the profile itself. The UDF of
the key is used as the permanent object identifier of the profile. Thus,
by definition, the KeySignature value of a Profile does not change under
any circumstance.
</dl>
###Structure: ProfileDevice

<dl>
<dt>Inherits:  Profile
</dl>

Describes a mesh device.

<dl>
<dt>Encryption: KeyData (Optional)
<dd>Base key contribution for encryption keys. 
Also used to decrypt activation data sent to the device
during connection to an account.
<dt>Signature: KeyData (Optional)
<dd>Base key contribution for signature keys. 
<dt>Authentication: KeyData (Optional)
<dd>Base key contribution for authentication keys. 
Also used to authenticate the device
during connection to an account.
</dl>
###Structure: ProfileAccount

Base class for the account profiles ProfileUser and ProfileGroup.
These subclasses may be merged at some future date.

<dl>
<dt>Inherits:  Profile
</dl>

<dl>
<dt>AccountAddress: String (Optional)
<dd>The account address. This is either a DNS service address 
(e.g. alice@example.com) or a Mesh Name (@alice).
<dt>ServiceUdf: String (Optional)
<dd>The fingerprint of the service profile to which the account is
currently bound.
<dt>EscrowEncryption: KeyData (Optional)
<dd>Escrow key associated with the account.
<dt>AdministratorSignature: KeyData (Optional)
<dd>Key used to sign connection assertions to the account.
<dt>CommonEncryption: KeyData (Optional)
<dd>Key currently used to encrypt data under this profile
<dt>CommonAuthentication: KeyData (Optional)
<dd>Key used to authenticate requests made under this user account.
This key SHOULD NOT be provisioned to any device except for the
purpose of enabling account recovery.
</dl>
###Structure: ProfileUser

<dl>
<dt>Inherits:  ProfileAccount
</dl>

Account assertion. This is signed by the service hosting the account.

<dl>
<dt>CommonSignature: KeyData (Optional)
<dd>Key used to sign data under the account.
</dl>
###Structure: ProfileGroup

<dl>
<dt>Inherits:  ProfileAccount
</dl>

Describes a group. Note that while a group is created by one person who
becomes its first administrator, control of the group may pass to other
administrators over time.

<dl>
<dt>Cover: Binary (Optional)
<dd>HTML document containing cover text to be presented if a document 
encrypted under the group key cannot be decrypted.
</dl>
###Structure: ProfileService

<dl>
<dt>Inherits:  Profile
</dl>

Profile of a Mesh Service

<dl>
<dt>ServiceAuthentication: KeyData (Optional)
<dd>Key used to authenticate service connections.
<dt>ServiceEncryption: KeyData (Optional)
<dd>Key used to encrypt data under this profile
<dt>ServiceSignature: KeyData (Optional)
<dd>Key used to sign data under the account.
</dl>
###Structure: ProfileMeshService

<dl>
<dt>Inherits:  ProfileService
</dl>

Profile of a Mesh Service

[No fields]

###Structure: ProfileHost

<dl>
<dt>Inherits:  ProfileDevice
</dl>

Profile of a Mesh Host providing one or more Mesh Services.

[No fields]

###Connection Assertions

Connection assertions are used to authenticate and authorize
interactions between devices and the service currently servicing
the account. They SHOULD NOT be visible to external parties.

###Structure: Connection

<dl>
<dt>Inherits:  Assertion
</dl>

<dl>
<dt>Subject: String (Optional)
<dd>UDF of the connection target.
<dt>Authority: String (Optional)
<dd>UDF of the connection source.
<dt>Authentication: KeyData (Optional)
<dd>The authentication key for use of the device under the profile
</dl>
###Structure: CallsignBinding

<dl>
<dt>Inherits:  Assertion
</dl>

<dl>
<dt>Canonical: String (Optional)
<dd>The canonical form of the callsign.
<dt>Display: String (Optional)
<dd>The display form of the callsign. This MAY include characters such as whitespace,
trademark signifiers, etc. that are omitted of trranslated in the canonical form.
<dt>CharacterPage: String (Optional)
<dd>Specifies the page to which the Description"CharacterPageLatin"
<dt>ProfileUdf: String (Optional)
<dd>The profile to which the name is bound.
<dt>TransferUdf: String (Optional)
<dd>The profile to which the name has been transfered.
<dt>Services: NamedService [0..Many]
<dd>List of named services. If multiple service providers are specified for a given 
service, these are listed in order of priority, most preferred first.
<dt>ServiceAddress: String (Optional)
<dd>The Mesh service address. 
<dt>CommonEncryption: KeyData (Optional)
<dd>Key currently used to encrypt data under this profile
</dl>
###Structure: Accreditation

Registration of a trusted third party accreditation of a callsign/profile binding.

<dl>
<dt>Callsign: String (Optional)
<dd>The callsign to which the accreditation applies
<dt>ProfileUdf: String (Optional)
<dd>The profile to which the accreditation applies.
<dt>SubjectNames: String [0..Many]
<dd>The validated names of the subject
<dt>SubjectLogos: String [0..Many]
<dd>Mesh strong URIs from which a validated logo belonging to the 
subject MAY be retreived and validated.
<dt>Issued: DateTime (Optional)
<dd>The time the assertion was issued.
<dt>Expires: DateTime (Optional)
<dd>The time the assertion is due to expire
<dt>Policy: String (Optional)
<dd>The issuing policy under which the validation was performed.
<dt>Practice: String (Optional)
<dd>The issuing practices under which the validation was performed.
</dl>
###Structure: ConnectionStripped

Asserts that a profile is connected to an account address.

<dl>
<dt>Inherits:  Connection
</dl>

Stripped down connection assertion

<dl>
<dt>Account: String (Optional)
<dd>To be removed
</dl>
###Structure: ConnectionService

<dl>
<dt>Inherits:  Connection
</dl>

Asserts that a device is connected to an account profile

<dl>
<dt>ProfileUdf: String (Optional)
<dd>The account address
</dl>
###Structure: ConnectionDevice

<dl>
<dt>Inherits:  ConnectionService
</dl>

Asserts that a device is connected to an account profile

<dl>
<dt>Roles: String [0..Many]
<dt>Signature: KeyData (Optional)
<dd>The signature key for use of the device under the profile
<dt>Encryption: KeyData (Optional)
<dd>The encryption key for use of the device under the profile
</dl>
###Structure: ConnectionApplication

<dl>
<dt>Inherits:  Connection
</dl>

Connection assertion stating that a particular device is 

[No fields]

###Structure: ConnectionGroup

Describes the connection of a member to a group.

<dl>
<dt>Inherits:  Connection
</dl>

[No fields]

###Structure: AccountHostAssignment

<dl>
<dt>Inherits:  Assertion
</dl>

<dl>
<dt>AccountAddess: String (Optional)
<dd>The account being bound
<dt>HostAddresses: String [0..Many]
<dd>Host address in Callsign, DNS or IP format in order of preference.
<dt>AccessEncrypt: KeyData (Optional)
<dd>Encryption key to be used to encrypt data for the service to use.
<dt>CallsignServiceProfile: ProfileAccount (Optional)
<dd>Profile of the callsign registry used by the service.
</dl>
###Structure: ConnectionHost

<dl>
<dt>Inherits:  Connection
</dl>

[No fields]

###Activation Assertions



###Structure: ActivationAccount

Contains activation data for device specific keys used in the context of a 
Mesh account.

<dl>
<dt>Inherits:  Activation
</dl>

<dl>
<dt>AccountUdf: String (Optional)
<dd>The UDF of the account
</dl>
###Structure: ActivationHost

Contains activation data for device specific keys used in the context of a 
Mesh host

<dl>
<dt>Inherits:  ActivationAccount
</dl>

[No fields]

###Structure: ActivationCommon

<dl>
<dt>Inherits:  Activation
</dl>

<dl>
<dt>ProfileSignature: KeyData (Optional)
<dd>Grant access to profile online signing key used to sign updates
to the profile.
<dt>AdministratorSignature: KeyData (Optional)
<dd>Grant access to Profile administration key used to make changes to
administrator catalogs.
<dt>Encryption: KeyData (Optional)
<dd>Grant access to ProfileUser account encryption key
<dt>Authentication: KeyData (Optional)
<dd>Grant access to ProfileUser account authentication key
<dt>Signature: KeyData (Optional)
<dd>Grant access to ProfileUser account signature key
</dl>
###Structure: ActivationApplication

<dl>
<dt>Inherits:  Activation
</dl>

[No fields]

###Structure: ActivationApplicationSsh

<dl>
<dt>Inherits:  ActivationApplication
</dl>

<dl>
<dt>ClientKey: KeyData (Optional)
<dd>The SSH client key.
</dl>
###Structure: ActivationApplicationMail

<dl>
<dt>Inherits:  ActivationApplication
</dl>

<dl>
<dt>SmimeSign: KeyData (Optional)
<dd>The S/Mime signature key
<dt>SmimeEncrypt: KeyData (Optional)
<dd>The S/Mime encryption key
<dt>OpenpgpSign: KeyData (Optional)
<dd>The OpenPGP signature key
<dt>OpenpgpEncrypt: KeyData (Optional)
<dd>The OpenPGP encryption key
</dl>
###Structure: ActivationApplicationGroup

<dl>
<dt>Inherits:  ActivationApplication
</dl>

<dl>
<dt>AccountEncryption: KeyData (Optional)
<dd>Key or capability allowing account encryption keys to be created 
for new members.
<dt>AdministratorSignature: KeyData (Optional)
<dd>Key or capability allowing account updates, connection assertions
etc to be signed.
<dt>AccountAuthentication: KeyData (Optional)
<dd>Key or capability allowing administration of the group.
<dt>EnvelopedConnectionService: Enveloped<ConnectionService> (Optional)
<dd>Signed connection service delegation allowing the device to
access the account.
</dl>
##Application Data

###Structure: ApplicationEntry

<dl>
<dt>Identifier: String (Optional)
</dl>
###Structure: ApplicationEntrySsh

<dl>
<dt>Inherits:  ApplicationEntry
</dl>

<dl>
<dt>EnvelopedActivation: Enveloped<ActivationApplicationSsh> (Optional)
</dl>
###Structure: ApplicationEntryGroup

<dl>
<dt>Inherits:  ApplicationEntry
</dl>

<dl>
<dt>EnvelopedActivation: Enveloped<ActivationApplicationGroup> (Optional)
</dl>
###Structure: ApplicationEntryMail

<dl>
<dt>Inherits:  ApplicationEntry
</dl>

<dl>
<dt>EnvelopedActivation: Enveloped<ActivationApplicationMail> (Optional)
</dl>
##Data Structures

Classes describing data used in cataloged data.	

###Structure: Contact

<dl>
<dt>Inherits:  Assertion
</dl>

Base class for contact entries.

<dl>
<dt>Id: String (Optional)
<dd>The globally unique contact identifier.
<dt>Local: String (Optional)
<dd>The local name.
<dt>Anchors: Anchor [0..Many]
<dd>Mesh fingerprints associated with the contact.
<dt>NetworkAddresses: NetworkAddress [0..Many]
<dd>Network address entries
<dt>Locations: Location [0..Many]
<dd>The physical locations the contact is associated with.
<dt>Roles: Role [0..Many]
<dd>The roles of the contact
<dt>Bookmark: Bookmark [0..Many]
<dd>The Web sites and other online presences of the contact
<dt>Sources: TaggedSource [0..Many]
<dd>Source(s) from which this contact was constructed.
</dl>
###Structure: Anchor

Trust anchor

<dl>
<dt>Udf: String (Optional)
<dd>The trust anchor.
<dt>Validation: String (Optional)
<dd>The means of validation.
</dl>
###Structure: TaggedSource

Source from which contact information was obtained.

<dl>
<dt>LocalName: String (Optional)
<dd>Short name for the contact information.
<dt>Validation: String (Optional)
<dd>The means of validation.		
<dt>BinarySource: Binary (Optional)
<dd>The contact data in binary form.
<dt>EnvelopedSource: Enveloped<Contact> (Optional)
<dd>The contact data in enveloped form. If present, the BinarySource property
is ignored.
</dl>
###Structure: ContactGroup

<dl>
<dt>Inherits:  Contact
</dl>

Contact for a group, including encryption groups.

[No fields]

###Structure: ContactPerson

<dl>
<dt>Inherits:  Contact
</dl>



<dl>
<dt>CommonNames: PersonName [0..Many]
<dd>List of person names in order of preference
</dl>
###Structure: ContactOrganization

<dl>
<dt>Inherits:  Contact
</dl>

		

<dl>
<dt>CommonNames: OrganizationName [0..Many]
<dd>List of person names in order of preference
</dl>
###Structure: OrganizationName

The name of an organization

<dl>
<dt>Inactive: Boolean (Optional)
<dd>If true, the name is not in current use.
<dt>RegisteredName: String (Optional)
<dd>The registered name.
<dt>DBA: String (Optional)
<dd>Names that the organization uses including trading names
and doing business as names.
</dl>
###Structure: PersonName

The name of a natural person

<dl>
<dt>Inactive: Boolean (Optional)
<dd>If true, the name is not in current use.
<dt>FullName: String (Optional)
<dd>The preferred presentation of the full name.
<dt>Prefix: String (Optional)
<dd>Honorific or title, E.g. Sir, Lord, Dr., Mr.
<dt>First: String (Optional)
<dd>First name.
<dt>Middle: String [0..Many]
<dd>Middle names or initials.
<dt>Last: String (Optional)
<dd>Last name.
<dt>Suffix: String (Optional)
<dd>Nominal suffix, e.g. Jr., III, etc.
<dt>PostNominal: String (Optional)
<dd>Post nominal letters (if used).
</dl>
###Structure: NetworkAddress

Provides all means of contacting the individual according to a
particular network address

<dl>
<dt>Inactive: Boolean (Optional)
<dd>If true, the name is not in current use.
<dt>Address: String (Optional)
<dd>The network address, e.g. alice@example.com
<dt>NetworkCapability: String [0..Many]
<dd>The capabilities bound to this address.
<dt>EnvelopedProfileAccount: Enveloped<ProfileAccount> (Optional)
<dd>The account profile
<dt>Protocols: NetworkProtocol [0..Many]
<dd>Public keys associated with the network address
</dl>
###Structure: NetworkProtocol

<dl>
<dt>Protocol: String (Optional)
<dd>The IANA protocol|identifier of the network protocols by which 
the contact may be reached using the specified Address. 
</dl>
###Structure: Role

<dl>
<dt>OrganizationName: String (Optional)
<dd>The organization at which the role is held
<dt>Titles: String [0..Many]
<dd>The titles held with respect to that organization.
<dt>Locations: Location [0..Many]
<dd>Postal or physical addresses associated with the role.
</dl>
###Structure: Location

<dl>
<dt>Appartment: String (Optional)
<dt>Street: String (Optional)
<dt>District: String (Optional)
<dt>Locality: String (Optional)
<dt>County: String (Optional)
<dt>Postcode: String (Optional)
<dt>Country: String (Optional)
</dl>
###Structure: Bookmark

<dl>
<dt>Uri: String (Optional)
<dt>Title: String (Optional)
<dt>Role: String [0..Many]
</dl>
###Structure: Reference

<dl>
<dt>MessageId: String (Optional)
<dd>The received message to which this is a response
<dt>ResponseId: String (Optional)
<dd>Message that was generated in response to the original (optional).
<dt>Relationship: String (Optional)
<dd>The relationship type. This can be Read, Unread, Accept, Reject.
</dl>
###Structure: Engagement

<dl>
<dt>Key: String (Optional)
<dd>Unique key.
<dt>Start: DateTime (Optional)
<dt>Finish: DateTime (Optional)
<dt>StartTravel: String (Optional)
<dt>FinishTravel: String (Optional)
<dt>TimeZone: String (Optional)
<dt>Title: String (Optional)
<dt>Description: String (Optional)
<dt>Location: String (Optional)
<dt>Trigger: String [0..Many]
<dt>Conference: String [0..Many]
<dt>Repeat: String (Optional)
<dt>Busy: Boolean (Optional)
</dl>
##Catalog Entries

###Structure: CatalogedEntry

Base class for cataloged Mesh data.

<dl>
<dt>Labels: String [0..Many]
<dd>The set of labels describing the entry
<dt>LocalName: String (Optional)
<dd>User specified identifier.
<dt>Uid: String (Optional)
<dd>Globaly unique identifier
</dl>
###Structure: CatalogedDevice

<dl>
<dt>Inherits:  CatalogedEntry
</dl>

Public device entry, indexed under the device ID Hello

<dl>
<dt>Updated: DateTime (Optional)
<dd>Timestamp, allows 
<dt>Udf: String (Optional)
<dd>UDF of the signature key of the device in the Mesh
<dt>DeviceUdf: String (Optional)
<dd>UDF of the offline signature key of the device
<dt>SignatureUdf: String (Optional)
<dd>UDF of the account online signature key
<dt>EnvelopedProfileUser: Enveloped<ProfileAccount> (Optional)
<dd>The Mesh profile. Why is this still here? This is not 
specific to the device.
<dt>EnvelopedProfileDevice: Enveloped<ProfileDevice> (Optional)
<dd>The device profile
<dt>EnvelopedConnectionService: Enveloped<ConnectionService> (Optional)
<dd>Slim version of ConnectionDevice used by the presentation layer
<dt>EnvelopedConnectionDevice: Enveloped<ConnectionDevice> (Optional)
<dd>The public assertion demonstrating connection of the Device to the Mesh
<dt>EnvelopedActivationAccount: Enveloped<ActivationAccount> (Optional)
<dd>The activation of the device within the Mesh account
<dt>EnvelopedActivationCommon: Enveloped<ActivationCommon> (Optional)
<dd>The activation of the device within the Mesh account
</dl>
###Structure: CatalogedSignature

<dl>
<dt>Inherits:  CatalogedEntry
</dl>

Cataloged Signature

[No fields]

###Structure: CatalogedPublication

<dl>
<dt>Inherits:  CatalogedEntry
</dl>

A publication.

<dl>
<dt>Id: String (Optional)
<dd>Unique identifier code
<dt>Authenticator: String (Optional)
<dd>The witness key value to use to request access to the record.	
<dt>EnvelopedData: DareEnvelope (Optional)
<dd>Dare Envelope containing the entry data. The data type is specified
by the envelope metadata.
<dt>NotOnOrAfter: DateTime (Optional)
<dd>Epiration time (inclusive)
</dl>
###Structure: CatalogedCredential

<dl>
<dt>Inherits:  CatalogedEntry
</dl>

<dl>
<dt>Protocol: String (Optional)
<dt>Service: String (Optional)
<dt>Username: String (Optional)
<dt>Password: String (Optional)
<dt>ClientAuthentication: KeyData [0..Many]
<dd>Specifies the client identification key
<dt>HostAuthentication: KeyData [0..Many]
<dd>Means of authenticating the host key
</dl>
###Structure: CatalogedApplicationSsh

<dl>
<dt>Inherits:  CatalogedApplication
</dl>

<dl>
<dt>ClientKey: KeyData (Optional)
<dd>The S/Mime encryption key
</dl>
###Structure: CatalogedNetwork

<dl>
<dt>Inherits:  CatalogedEntry
</dl>

<dl>
<dt>Protocol: String (Optional)
<dt>Service: String (Optional)
<dt>Username: String (Optional)
<dt>Password: String (Optional)
</dl>
###Structure: CatalogedContact

<dl>
<dt>Inherits:  CatalogedEntry
</dl>

<dl>
<dt>Key: String (Optional)
<dd>Unique key. 
<dt>Self: Boolean (Optional)
<dd>If true, this catalog entry is for the user who created the catalog.
</dl>
###Structure: CatalogedAccess

<dl>
<dt>Inherits:  CatalogedEntry
</dl>



[No fields]

###Structure: Capability

<dl>
<dt>Id: String (Optional)
<dd>The identifier of the capability. If this is a cryptographic capability,
this is the KeyIdentifier of the primary key that was shared. If
this is an access capability, this is the KeyIdentifier of the authentication
key being authorized for access.
<dt>Active: Boolean (Optional)
<dt>Issued: Integer (Optional)
<dt>Mode: String (Optional)
<dd>The authentication mode: Device, Account, PIN
<dt>Udf: String (Optional)
<dd>Identifies the authentication credential. For a device, this is the authentication key identifier, 
for an account, the profile identifier, for a PIN, the locator value of the PIN.
<dt>Witness: String (Optional)
<dd>The verification value used to perform proof of knowledge of the secret.
</dl>
###Structure: NullCapability

<dl>
<dt>Inherits:  Capability
</dl>

[No fields]

###Structure: AccessCapability

<dl>
<dt>Inherits:  Capability
</dl>

<dl>
<dt>Rights: String [0..Many]
<dd>Access rights associated with the key
<dt>EnvelopedCatalogedDevice: Enveloped<CatalogedDevice> (Optional)
<dd>
<dt>CatalogedDeviceDigest: String (Optional)
<dd>Digest value used to signal updates to envelope		
</dl>
###Structure: PublicationCapability

<dl>
<dt>Inherits:  Capability
</dl>



<dl>
<dt>Identifier: String (Optional)
<dd>Selector allowing a specific document to be requested.
<dt>Digest: String (Optional)
<dd>Document digest, this allows a status/claim request to 
request an update to be returned only if the document
has changed.
<dt>Data: Binary (Optional)
<dd>The published document.
</dl>
###Structure: CryptographicCapability

<dl>
<dt>Inherits:  Capability
</dl>

<dl>
<dt>KeyData: KeyData (Optional)
<dd>The key that enables the capability
<dt>GranteeAccount: String (Optional)
<dd><dt>GranteeUdf: String (Optional)
<dd><dt>EnvelopedKeyShare: Enveloped<KeyData> (Optional)
<dd>One or more enveloped key shares.
</dl>
###Structure: CapabilityDecrypt

<dl>
<dt>Inherits:  CryptographicCapability
</dl>

The corresponding key is a decryption key

[No fields]

###Structure: CapabilityDecryptPartial

<dl>
<dt>Inherits:  CapabilityDecrypt
</dl>

The corresponding key is an encryption key

[No fields]

###Structure: CapabilityDecryptServiced

<dl>
<dt>Inherits:  CapabilityDecrypt
</dl>

The corresponding key is an encryption key

<dl>
<dt>AuthenticationId: String (Optional)
<dd>UDF of trust root under which request to use a serviced capability must be 
authorized. [Only present for a serviced capability]
</dl>
###Structure: CapabilitySign

<dl>
<dt>Inherits:  CryptographicCapability
</dl>

The corresponding key is an administration key

[No fields]

###Structure: CapabilityKeyGenerate

<dl>
<dt>Inherits:  CryptographicCapability
</dl>

The corresponding key is a key that may be used to generate key shares.

[No fields]

###Structure: CapabilityFairExchange

<dl>
<dt>Inherits:  CryptographicCapability
</dl>

The corresponding key is a decryption key to be used in accordance 
with the Micali Fair Electronic Exchange with Invisible Trusted Parties
protocol.

[No fields]

###Structure: NamedService

<dl>
<dt>Prefix: String (Optional)
<dd>The IANA service name (e.g. dns)
<dt>Mapping: String (Optional)
<dd>Optional name mapping, (e.g. alice@example.com -> alice.mesh)
<dt>Endpoints: String [0..Many]
<dd>The service endpoints. This MAY be specified as a callsign (@alice),
a DNS address (example.com), an IP address (10.0.0.1) or a fully
qualified URI.
</dl>
###Structure: ServiceAccessToken

<dl>
<dt>Inherits:  NamedService
</dl>

<dl>
<dt>Token: Binary (Optional)
<dd>Session initiation token
<dt>SharedSecret: Binary (Optional)
<dd>Session shared secret
</dl>
###Structure: CatalogedBookmark

<dl>
<dt>Inherits:  CatalogedEntry
</dl>

<dl>
<dt>Uri: String (Optional)
<dt>Title: String (Optional)
<dt>Comments: String [0..Many]
<dd>User comments on bookmark entry
</dl>
###Structure: CatalogedTask

<dl>
<dt>Inherits:  CatalogedEntry
</dl>

<dl>
<dt>EnvelopedTask: Enveloped<Engagement> (Optional)
<dt>Title: String (Optional)
<dt>Key: String (Optional)
<dd>Unique key.
</dl>
###Structure: CatalogedApplication

<dl>
<dt>Inherits:  CatalogedEntry
</dl>

<dl>
<dt>Default: Integer (Optional)
<dt>Key: String (Optional)
<dt>Grant: String [0..Many]
<dt>Deny: String [0..Many]
<dt>EnvelopedCapabilities: DareEnvelope [0..Many]
<dd>Enveloped keys for use with Application
<dt>EnvelopedEscrow: Enveloped<KeyData> [0..Many]
<dd>Escrow entries for the application.
</dl>
###Structure: CatalogedMember

<dl>
<dt>ContactAddress: String (Optional)
<dt>MemberCapabilityId: String (Optional)
<dt>ServiceCapabilityId: String (Optional)
<dl>
<dt>Inherits:  CatalogedEntry
</dl>

</dl>
###Structure: CatalogedGroup

<dl>
<dt>Inherits:  CatalogedApplication
</dl>

<dl>
<dt>EnvelopedConnectionAddress: Enveloped<ConnectionStripped> (Optional)
<dd>The connection allowing control of the group.
<dt>EnvelopedProfileGroup: Enveloped<ProfileAccount> (Optional)
<dd>The Mesh profile
<dt>EnvelopedActivationCommon: Enveloped<ActivationCommon> (Optional)
<dd>The activation of the device within the Mesh account
</dl>
###Structure: CatalogedApplicationMail

<dl>
<dt>Inherits:  CatalogedApplication
</dl>

<dl>
<dt>AccountAddress: String (Optional)
<dt>InboundConnect: String (Optional)
<dt>OutboundConnect: String (Optional)
<dt>SmimeSign: KeyData (Optional)
<dd>The S/Mime signature key
<dt>SmimeEncrypt: KeyData (Optional)
<dd>The S/Mime encryption key
<dt>OpenpgpSign: KeyData (Optional)
<dd>The OpenPGP signature key
<dt>OpenpgpEncrypt: KeyData (Optional)
<dd>The OpenPGP encryption key
</dl>
###Structure: CatalogedApplicationNetwork

<dl>
<dt>Inherits:  CatalogedApplication
</dl>

[No fields]

###Structure: MessageInvoice

<dl>
<dt>Inherits:  Message
</dl>

[No fields]

###Structure: CatalogedReceipt

<dl>
<dt>Inherits:  CatalogedEntry
</dl>

[No fields]

###Structure: CatalogedTicket

<dl>
<dt>Inherits:  CatalogedEntry
</dl>

[No fields]

##Publications

###Structure: DevicePreconfigurationPublic

<dl>
<dt>EnvelopedProfileDevice: Enveloped<ProfileDevice> (Optional)
<dd>The device profile
<dt>Hailing: String [0..Many]
<dd>A list of URIs specifying hailing transports that may be used to
initiate a connection to the device. This allows a device to 
specify that it can be reached by WiFi transport to a particular 
private SSID, or by Bluetooth, IR etc. etc.
</dl>
###Structure: DevicePreconfigurationPrivate

<dl>
<dt>Inherits:  DevicePreconfigurationPublic
</dl>

A data structure that is passed 

<dl>
<dt>EnvelopedConnectionDevice: Enveloped<ConnectionDevice> (Optional)
<dd>The device connection
<dt>EnvelopedConnectionService: Enveloped<ConnectionService> (Optional)
<dd>The device connection
<dt>ConnectUri: String (Optional)
<dd>The connection URI. This would normally be printed on the device as a 
QR code.
</dl>
##Messages

###Structure: Message

<dl>
<dt>MessageId: String (Optional)
<dd>Unique per-message ID. When encapsulating a Mesh Message in a DARE envelope,
the envelope EnvelopeID field MUST be a UDF fingerprint of the MessageId
value. 
<dt>Sender: String (Optional)
<dt>Recipient: String (Optional)
</dl>
###Structure: MessageError

<dl>
<dt>Inherits:  Message
</dl>

<dl>
<dt>ErrorCode: String (Optional)
</dl>
###Structure: MessageComplete

<dl>
<dt>Inherits:  Message
</dl>

<dl>
<dt>References: Reference [0..Many]
</dl>
###Structure: MessageValidated

<dl>
<dt>Inherits:  Message
</dl>

<dl>
<dt>AuthenticatedData: DareEnvelope (Optional)
<dd>Enveloped data that is authenticated by means of the PIN
<dt>ClientNonce: Binary (Optional)
<dd>Nonce provided by the client to validate the PIN
<dt>PinId: String (Optional)
<dd>Pin identifier value calculated from the PIN code, action and account address.
<dt>PinWitness: Binary (Optional)
<dd>Witness value calculated as KDF (Device.Udf + AccountAddress, ClientNonce)
</dl>
###Structure: MessagePin

<dl>
<dt>Account: String (Optional)
<dl>
<dt>Inherits:  Message
</dl>

<dt>Expires: DateTime (Optional)
<dt>Automatic: Boolean (Optional)
<dd>If true, authentication against the PIN code is sufficient to complete
the associated action without further authorization.
<dt>SaltedPin: String (Optional)
<dd>PIN code bound to the specified action.
<dt>Action: String (Optional)
<dd>The action to which this PIN code is bound.
<dt>Roles: String [0..Many]
<dd>The set of rights bound to the PIN grant.
</dl>
###Structure: RequestConnection

Connection request message. This message contains the information

<dl>
<dt>Inherits:  MessageValidated
</dl>

<dl>
<dt>AccountAddress: String (Optional)
<dd>
</dl>
###Structure: AcknowledgeConnection

Connection request message generated by a service on receipt of a valid
MessageConnectionRequestClient

<dl>
<dt>Inherits:  Message
</dl>

<dl>
<dt>EnvelopedRequestConnection: Enveloped<RequestConnection> (Optional)
<dd>The client connection request.
<dt>ServerNonce: Binary (Optional)
<dd>
<dt>Witness: String (Optional)
<dd>
</dl>
###Structure: RespondConnection

Respond to RequestConnection message to grant or refuse the connection
request.

<dl>
<dt>Inherits:  Message
</dl>

<dl>
<dt>Result: String (Optional)
<dd>The response to the request. One of "Accept", "Reject" or "Pending".
<dt>CatalogedDevice: CatalogedDevice (Optional)
<dd>The device information. MUST be present if the value of Result is
"Accept". MUST be absent or null otherwise.
</dl>
###Structure: MessageContact

<dl>
<dt>Inherits:  MessageValidated
</dl>

<dl>
<dt>Reply: Boolean (Optional)
<dd>If true, requests that the recipient return their own contact information
in reply.
<dt>Subject: String (Optional)
<dd>Optional explanation of the reason for the request.
<dt>PIN: String (Optional)
<dd>One time authentication code supplied to a recipient to allow authentication
of the response.
</dl>
###Structure: GroupInvitation

<dl>
<dt>Inherits:  Message
</dl>

<dl>
<dt>Text: String (Optional)
</dl>
###Structure: RequestConfirmation

<dl>
<dt>Inherits:  Message
</dl>

<dl>
<dt>Text: String (Optional)
</dl>
###Structure: ResponseConfirmation

<dl>
<dt>Inherits:  Message
</dl>

<dl>
<dt>Request: Enveloped<RequestConfirmation> (Optional)
<dt>Accept: Boolean (Optional)
</dl>
###Structure: RequestTask

<dl>
<dt>Inherits:  Message
</dl>

[No fields]

###Structure: MessageClaim

<dl>
<dt>Inherits:  Message
</dl>

<dl>
<dt>PublicationId: String (Optional)
<dt>ServiceAuthenticate: String (Optional)
<dt>DeviceAuthenticate: String (Optional)
<dt>Expires: DateTime (Optional)
</dl>
###Structure: ProcessResult

Report result of message processing.	

<dl>
<dt>Inherits:  Message
</dl>

<dl>
<dt>Success: Boolean (Optional)
<dt>ErrorReport: String (Optional)
<dd>The error report code.
</dl>
###Structure: ProcessResultNotSupported

The message type is not supported.

<dl>
<dt>Inherits:  ProcessResult
</dl>

[No fields]

###Structure: ProcessResultNotFound

<dl>
<dt>Inherits:  ProcessResult
</dl>

[No fields]

