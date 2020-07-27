

##Shared Classes

The following classes are used as common elements in
Mesh profile specifications.

###Classes describing keys

###Structure: KeyData

The KeyData class is used to describe public key pairs and 
trust assertions associated with a public key.

<dl>
<dt>UDF: String (Optional)
<dd>UDF fingerprint of the public key parameters/
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
###Structure: KeyComposite

<dl>
<dt>Service: String (Optional)
<dd>Service holding the additional contribution
</dl>
###Structure: DeviceRecryptionKey

<dl>
<dt>UDF: String (Optional)
<dd>The fingerprint of the encryption key
<dt>RecryptionKey: KeyData (Optional)
<dd>The recryption key
<dt>EnvelopedRecryptionKeyDevice: DareEnvelope (Optional)
<dd>The decryption key encrypted under the user's device key.	
</dl>
###Structure: EscrowedKeySet

A set of escrowed keys. 

[No fields]

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

###Structure: Profile

<dl>
<dt>Inherits:  Assertion
</dl>

Parent class from which all profile classes are derived

<dl>
<dt>KeyOfflineSignature: KeyData (Optional)
<dd>The permanent signature key used to sign the profile itself. The UDF of
the key is used as the permanent object identifier of the profile. Thus,
by definition, the KeySignature value of a Profile does not change under
any circumstance. The only case in which a 
<dt>KeysOnlineSignature: KeyData [0..Many]
<dd>A Personal profile contains at least one OSK which is used to sign 
device administration application profiles.
</dl>
###Structure: Connection

<dl>
<dt>Inherits:  Assertion
</dl>

<dl>
<dt>SubjectUDF: String (Optional)
<dd>UDF of the connection target.
<dt>AuthorityUDF: String (Optional)
<dd>UDF of the connection source.
</dl>
###Structure: Activation

<dl>
<dt>Inherits:  Assertion
</dl>

Contains the private activation information for a Mesh application running on
a specific device

<dl>
<dt>EnvelopedConnection: DareEnvelope (Optional)
<dd>The signed AssertionDeviceConnection.
<dt>ActivationKey: String (Optional)
<dd>The master secret from which all the key contributions are derrived.
</dl>
###Structure: Permission

<dl>
<dt>Name: String (Optional)
<dt>Role: String (Optional)
<dt>Capabilities: DareEnvelope (Optional)
<dd>Keys or key contributions enabling the operation to be performed
</dl>
###Mesh Profile Classes

A Mesh profile does not have activation or connection classes associated with it.

It might be more consistent to represent administation devices as activations
on the ProfileMesh class though.

###Structure: ProfileMesh

<dl>
<dt>Inherits:  Profile
</dl>

Describes the long term parameters associated with a personal profile.

<dl>
<dt>KeysMasterEscrow: KeyData [0..Many]
<dd>A Personal Profile MAY contain one or more PMEK keys to enable escrow 
of private keys used for stored data. 
<dt>KeyEncryption: KeyData (Optional)
<dd>Key used to pass encrypted data to the device such as a
DeviceUseEntry
</dl>
###Mesh Device Classes



###Structure: ProfileDevice

<dl>
<dt>Inherits:  Profile
</dl>

Describes a mesh device.

<dl>
<dt>Description: String (Optional)
<dd>Description of the device
<dt>KeyEncryption: KeyData (Optional)
<dd>Key used to pass encrypted data to the device such as a
DeviceUseEntry
<dt>KeyAuthentication: KeyData (Optional)
<dd>Key used to authenticate requests made by the device.
</dl>
###Structure: ActivationDevice

<dl>
<dt>Inherits:  Activation
</dl>

[No fields]

###Structure: ConnectionDevice

<dl>
<dt>Inherits:  Connection
</dl>

<dl>
<dt>Permissions: Permission [0..Many]
<dd>List of the permissions that the device has been granted.
<dt>KeySignature: KeyData (Optional)
<dd>The signature key for use of the device under the profile
<dt>KeyEncryption: KeyData (Optional)
<dd>The encryption key for use of the device under the profile
<dt>KeyAuthentication: KeyData (Optional)
<dd>The authentication key for use of the device under the profile
</dl>
###Structure: CatalogedDevice

<dl>
<dt>Inherits:  CatalogedEntry
</dl>

Public device entry, indexed under the device ID

<dl>
<dt>UDF: String (Optional)
<dd>UDF of the signature key of the device in the Mesh
<dt>EnvelopedProfileMesh: DareEnvelope (Optional)
<dd>The Mesh profile
<dt>DeviceUDF: String (Optional)
<dd>UDF of the signature key of the device
<dt>EnvelopedProfileDevice: DareEnvelope (Optional)
<dd>The device profile
<dt>EnvelopedConnectionDevice: DareEnvelope (Optional)
<dd>The public assertion demonstrating connection of the Device to the Mesh
<dt>EnvelopedActivationDevice: DareEnvelope (Optional)
<dd>The activations of the device within the Mesh
<dt>Accounts: AccountEntry [0..Many]
<dd>The accounts that this device is connected to
</dl>
###Structure: CatalogedPublication

<dl>
<dt>Inherits:  CatalogedEntry
</dl>

A publication.

<dl>
<dt>ID: String (Optional)
<dd>Unique identifier code
<dt>Authenticator: String (Optional)
<dd>The witness key value to use to request access to the record.	
<dt>EnvelopedData: DareEnvelope (Optional)
<dd>Dare Envelope containing the entry data
<dt>NotOnOrAfter: DateTime (Optional)
<dd>Epiration time (inclusive)
</dl>
###Mesh Account Classes



###Structure: ProfileAccount

<dl>
<dt>Inherits:  Profile
</dl>

Account assertion. This is signed by the service hosting the account.

<dl>
<dt>AccountAddresses: String [0..Many]
<dd>Service address(es).
<dt>MeshProfileUDF: String (Optional)
<dd>Master profile of the account being registered.
<dt>KeyEncryption: KeyData (Optional)
<dd>Key used to encrypt data under this profile
<dt>KeyAuthentication: KeyData (Optional)
<dd>Key used to authenticate requests made by the device.
<dt>EnvelopedProfileService: DareEnvelope (Optional)
<dd>The service profile
</dl>
###Structure: ActivationAccount

<dl>
<dt>Inherits:  Activation
</dl>

<dl>
<dt>AccountUDF: String (Optional)
<dd>The UDF of the account
<dt>KeyAccountEncryption: KeyData (Optional)
<dd>Key used to encrypt data under this profile
<dt>KeyAccountSignature: KeyData (Optional)
<dd>Key used to encrypt data under this profile
</dl>
###Structure: ConnectionAccount

<dl>
<dt>Inherits:  Connection
</dl>

<dl>
<dt>AccountAddresses: String [0..Many]
<dd>The list of service identifiers.
<dt>Permissions: Permission [0..Many]
<dd>List of the permissions that the device has been granted.
<dt>KeySignature: KeyData (Optional)
<dd>The signature key for use of the device under the profile
<dt>KeyEncryption: KeyData (Optional)
<dd>The encryption key for use of the device under the profile
<dt>KeyAuthentication: KeyData (Optional)
<dd>The authentication key for use of the device under the profile
</dl>
###Structure: AccountEntry

Contains the Account information for an account with a CatalogedDevice.

<dl>
<dt>AccountUDF: String (Optional)
<dd>UDF of the account profile
<dt>EnvelopedProfileAccount: DareEnvelope (Optional)
<dd>The account profile
<dt>EnvelopedConnectionAccount: DareEnvelope (Optional)
<dd>The connection of this device to the account
<dt>EnvelopedActivationAccount: DareEnvelope (Optional)
<dd>The activation data for this device to the account	
</dl>
###Structure: ConnectionApplication

<dl>
<dt>Inherits:  Connection
</dl>

[No fields]

###Mesh Group Classes



###Structure: ProfileGroup

<dl>
<dt>Inherits:  Profile
</dl>

Describes a group. Note that while a group is created by one person who
becomes its first administrator, control of the group may pass to other
administrators over time.

<dl>
<dt>AccountAddresses: String [0..Many]
<dd>Service address(es).
<dt>KeyEncryption: KeyData (Optional)
<dd>Key currently used to encrypt data under this profile
</dl>
###Structure: ActivationGroup

<dl>
<dt>Inherits:  Activation
</dl>

<dl>
<dt>GroupUDF: String (Optional)
<dd>The UDF of the group
</dl>
###Structure: ConnectionGroup

Describes the connection of a member to a group.

<dl>
<dt>Inherits:  Connection
</dl>

<dl>
<dt>KeyEncryption: KeyComposite (Optional)
<dd>The decryption key for the user within the group
</dl>
###Mesh Service Classes



###Structure: ProfileService

<dl>
<dt>Inherits:  Profile
</dl>

Profile of a Mesh Service

<dl>
<dt>KeyAuthentication: KeyData (Optional)
<dd>Key used to authenticate service connections.
<dt>KeyEncryption: KeyData (Optional)
<dd>Key used to encrypt data under this profile
</dl>
###Structure: ConnectionService

<dl>
<dt>Inherits:  Connection
</dl>

[No fields]

###Mesh Host Classes



###Structure: ProfileHost

<dl>
<dt>Inherits:  Profile
</dl>

<dl>
<dt>KeyAuthentication: KeyData (Optional)
<dd>Key used to authenticate service connections.
</dl>
###Structure: ConnectionHost

<dl>
<dt>Inherits:  Connection
</dl>

[No fields]

##Cataloged items

###Data Structures

Classes describing data used in cataloged data.

###Structure: Contact

<dl>
<dt>Inherits:  Assertion
</dl>

Base class for contact entries.

<dl>
<dt>Id: String (Optional)
<dd>The globally unique contact identifier.
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
<dt>UDF: String (Optional)
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
<dt>EnvelopedSource: DareEnvelope (Optional)
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
<dt>EnvelopedProfileAccount: DareEnvelope (Optional)
<dd>Optional enveloped profile for the Address
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
<dt>MessageID: String (Optional)
<dd>The received message to which this is a response
<dt>ResponseID: String (Optional)
<dd>Message that was generated in response to the original (optional).
<dt>Relationship: String (Optional)
<dd>The relationship type. This can be Read, Unread, Accept, Reject.
</dl>
###Structure: Task

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
<dt>Permissions: Permission [0..Many]
<dd>List of the permissions that the contact has been granted.
</dl>
###Structure: CatalogedContactRecryption

<dl>
<dt>Inherits:  CatalogedContact
</dl>

[No fields]

###Structure: CatalogedCapability

<dl>
<dt>Inherits:  CatalogedEntry
</dl>



[No fields]

###Structure: CryptographicCapability

<dl>
<dt>Id: String (Optional)
<dd>The identifier of the capability. If this is a user capability, MUST match the
KeyData identifier. If this is a serviced capability, MUST match the value of
ServiceId on the corresponding service capability.
<dt>KeyData: KeyData (Optional)
<dd>The key that enables the capability
<dt>EnvelopedKeyShares: DareEnvelope [0..Many]
<dd>One or more enveloped key shares.
<dt>SubjectId: String (Optional)
<dd>The identifier of the resource that is controlled using the key.
<dt>SubjectAddress: String (Optional)
<dd>The address of the resource that is controlled using the key.
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

<dl>
<dt>ServiceId: String (Optional)
<dd>The identifier used to claim the capability from the service.[Only present for
a partial capability.]
<dt>ServiceAddress: String (Optional)
<dd>The service account that supports a serviced capability. [Only present for
a partial capability.]
</dl>
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

###Structure: CatalogedBookmark

<dl>
<dt>Inherits:  CatalogedEntry
</dl>

<dl>
<dt>Uri: String (Optional)
<dt>Title: String (Optional)
<dt>Path: String (Optional)
</dl>
###Structure: CatalogedTask

<dl>
<dt>Inherits:  CatalogedEntry
</dl>

<dl>
<dt>EnvelopedTask: DareEnvelope (Optional)
<dt>Title: String (Optional)
<dt>Key: String (Optional)
<dd>Unique key.
</dl>
###Structure: CatalogedApplication

<dl>
<dt>Inherits:  CatalogedEntry
</dl>

<dl>
<dt>Key: String (Optional)
<dt>EnvelopedCapabilities: DareEnvelope [0..Many]
<dd>Enveloped keys for use with Application
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
<dt>Profile: ProfileGroup (Optional)
</dl>
###Structure: CatalogedApplicationSSH

<dl>
<dt>Inherits:  CatalogedApplication
</dl>

[No fields]

###Structure: CatalogedApplicationMail

<dl>
<dt>Inherits:  CatalogedApplication
</dl>

[No fields]

###Structure: CatalogedApplicationNetwork

<dl>
<dt>Inherits:  CatalogedApplication
</dl>

[No fields]

##Static Assertions

###Structure: DevicePreconfiguration

A data structure that is passed 

<dl>
<dt>EnvelopedProfileDevice: DareEnvelope (Optional)
<dd>The device profile
<dt>ConnectUri: String (Optional)
<dd>The connection URI. This would normally be printed on the device as a 
QR code.
</dl>
##Messages

###Structure: Message

<dl>
<dt>MessageID: String (Optional)
<dd>Unique per-message ID. When encapsulating a Mesh Message in a DARE envelope,
the envelope EnvelopeID field MUST be a UDF fingerprint of the MessageID
value. 
<dt>Sender: String (Optional)
<dt>Recipient: String (Optional)
<dt>References: Reference [0..Many]
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

[No fields]

###Structure: MessagePinValidated

<dl>
<dt>Inherits:  Message
</dl>

<dl>
<dt>AuthenticatedData: DareEnvelope (Optional)
<dd>Enveloped data that is authenticated by means of the PIN
<dt>ClientNonce: Binary (Optional)
<dd>
<dt>PinUDF: String (Optional)
<dd>Fingerprint of the PIN value used to authenticate the request.
<dt>PinWitness: Binary (Optional)
<dd>Witness value calculated as KDF (Device.UDF + AccountAddress, ClientNonce)
</dl>
###Structure: MessagePIN

<dl>
<dt>Account: String (Optional)
<dl>
<dt>Inherits:  Message
</dl>

<dt>Expires: DateTime (Optional)
<dt>Automatic: Boolean (Optional)
<dd>If true, authentication against the PIN code is sufficient to complete
the associated action without further authorization.
<dt>SaltedPIN: String (Optional)
<dd>PIN code bound to the specified action.
<dt>Action: String (Optional)
<dd>The action to which this PIN code is bound.
</dl>
###Structure: RequestConnection

Connection request message. This message contains the information

<dl>
<dt>Inherits:  MessagePinValidated
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
<dt>EnvelopedRequestConnection: DareEnvelope (Optional)
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
###Structure: RequestContact

<dl>
<dt>Inherits:  Message
</dl>

<dl>
<dt>Reply: Boolean (Optional)
<dt>Subject: String (Optional)
<dt>PIN: String (Optional)
<dd>One time authentication code.
<dt>Self: DareEnvelope (Optional)
<dd>The contact data.
</dl>
###Structure: ReplyContact

<dl>
<dt>Inherits:  MessagePinValidated
</dl>

<dl>
<dt>Subject: String (Optional)
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
<dt>Request: DareEnvelope (Optional)
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
