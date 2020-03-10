

##Shared Classes

The following classes are used as common elements in
Mesh profile specifications.

###Classes describing keys

###Structure: PublicKey

The PublicKey class is used to describe public key pairs and 
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
<dt>Contact: Contact (Optional)
<dd>The User's Mesh contact information
<dt>RecryptionKey: PublicKey (Optional)
<dd>The recryption key
<dt>EnvelopedRecryptionKeyDevice: DareEnvelope (Optional)
<dd>The decryption key encrypted under the user's device key.	
</dl>
###Structure: KeyOverlay

<dl>
<dt>UDF: String (Optional)
<dd>Fingerprint of the resulting composite key (to allow verification)
<dt>BaseUDF: String (Optional)
<dd>Fingerprint specifying the base key
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
<dt>KeyOfflineSignature: PublicKey (Optional)
<dd>The permanent signature key used to sign the profile itself. The UDF of
the key is used as the permanent object identifier of the profile. Thus,
by definition, the KeySignature value of a Profile does not change under
any circumstance. The only case in which a 
<dt>KeysOnlineSignature: PublicKey [0..Many]
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
###Structure: CatalogedEntry

Base class for cataloged Mesh data.

[No fields]

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
<dt>KeysMasterEscrow: PublicKey [0..Many]
<dd>A Personal Profile MAY contain one or more PMEK keys to enable escrow 
of private keys used for stored data. 
<dt>KeyEncryption: PublicKey (Optional)
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
<dt>KeyEncryption: PublicKey (Optional)
<dd>Key used to pass encrypted data to the device such as a
DeviceUseEntry
<dt>KeyAuthentication: PublicKey (Optional)
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
<dt>KeySignature: PublicKey (Optional)
<dd>The signature key for use of the device under the profile
<dt>KeyEncryption: PublicKey (Optional)
<dd>The encryption key for use of the device under the profile
<dt>KeyAuthentication: PublicKey (Optional)
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
###Mesh Account Classes



###Structure: ProfileAccount

<dl>
<dt>Inherits:  Profile
</dl>

Account assertion. This is signed by the service hosting the account.

<dl>
<dt>ServiceIDs: String [0..Many]
<dd>Service address(es).
<dt>MeshProfileUDF: String (Optional)
<dd>Master profile of the account being registered.
<dt>KeyEncryption: PublicKey (Optional)
<dd>Key used to encrypt data under this profile
<dt>KeyAuthentication: PublicKey (Optional)
<dd>Key used to authenticate requests made by the device.
</dl>
###Structure: ActivationAccount

<dl>
<dt>Inherits:  Activation
</dl>

<dl>
<dt>AccountUDF: String (Optional)
<dd>The UDF of the account
<dt>KeyGroup: KeyComposite (Optional)
<dd>The key contribution for the decryption key for the device. NB this is 
NOT an overlay on the device signature key, it is an overlay on the 
corresponding recryption key.
</dl>
###Structure: ConnectionAccount

<dl>
<dt>Inherits:  Connection
</dl>

<dl>
<dt>ServiceID: String [0..Many]
<dd>The list of service identifiers.
<dt>Permissions: Permission [0..Many]
<dd>List of the permissions that the device has been granted.
<dt>KeySignature: PublicKey (Optional)
<dd>The signature key for use of the device under the profile
<dt>KeyEncryption: PublicKey (Optional)
<dd>The encryption key for use of the device under the profile
<dt>KeyAuthentication: PublicKey (Optional)
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
<dt>ServiceIDs: String [0..Many]
<dd>Service address(es).
<dt>KeyEncryption: PublicKey (Optional)
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
<dt>KeyAuthentication: PublicKey (Optional)
<dd>Key used to authenticate service connections.
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
<dt>KeyAuthentication: PublicKey (Optional)
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

###Structure: ContactMesh

<dl>
<dt>UDF: String (Optional)
<dt>ServiceID: String [0..Many]
</dl>
###Structure: Contact

<dl>
<dt>Inherits:  Assertion
</dl>

<dl>
<dt>MeshAccounts: DareEnvelope [0..Many]
<dd>The Mesh Account Connection - the main event really
<dt>Email: String (Optional)
<dt>Identifier: String (Optional)
<dt>FullName: String (Optional)
<dt>Title: String (Optional)
<dt>First: String (Optional)
<dt>Middle: String (Optional)
<dt>Last: String (Optional)
<dt>Suffix: String (Optional)
<dt>Labels: String [0..Many]
<dt>AssertionAccounts: ProfileAccount [0..Many]
<dt>Addresses: Address [0..Many]
<dt>Locations: Location [0..Many]
<dt>Roles: Role [0..Many]
</dl>
###Structure: Role

<dl>
<dt>CompanyName: String (Optional)
<dt>Addresses: Address [0..Many]
<dt>Locations: Location [0..Many]
</dl>
###Structure: Address

<dl>
<dt>URI: String (Optional)
<dt>Labels: String [0..Many]
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
<dt>Self: Boolean (Optional)
<dd>If true, this catalog entry is for the user who created the catalog. To be
valid, such an entry MUST be signed by an administration key for the Mesh
profile containing the account to which the catalog belongs.
<dt>Key: String (Optional)
<dd>Unique key. 
<dt>Permissions: Permission [0..Many]
<dd>List of the permissions that the contact has been granted.
<dt>EnvelopedContact: DareEnvelope (Optional)
<dd>The (signed) contact data.
</dl>
###Structure: CatalogedContactRecryption

<dl>
<dt>Inherits:  CatalogedContact
</dl>

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
</dl>
###Structure: CatalogedMember

<dl>
<dt>UDF: String (Optional)
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

##Messages

###Structure: Message

<dl>
<dt>MessageID: String (Optional)
<dt>Sender: String (Optional)
<dt>Recipient: String (Optional)
<dt>References: Reference [0..Many]
</dl>
###Structure: MessageComplete

<dl>
<dt>Inherits:  Message
</dl>

[No fields]

###Structure: MessagePIN

<dl>
<dt>Account: String (Optional)
<dl>
<dt>Inherits:  Message
</dl>

<dt>Expires: DateTime (Optional)
<dt>PIN: String (Optional)
</dl>
###Structure: RequestConnection

Connection request message. This message contains the information

<dl>
<dt>Inherits:  Message
</dl>

<dl>
<dt>ServiceID: String (Optional)
<dd>
<dt>EnvelopedProfileDevice: DareEnvelope (Optional)
<dd>Device profile of the device making the request.
<dt>ClientNonce: Binary (Optional)
<dd>
<dt>PinUDF: String (Optional)
<dd>Fingerprint of the PIN value used to authenticate the request.
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
###Structure: OfferGroup

<dl>
<dt>Inherits:  Message
</dl>

[No fields]

###Structure: RequestContact

<dl>
<dt>Inherits:  Message
</dl>

<dl>
<dt>Reply: Boolean (Optional)
<dt>Subject: String (Optional)
<dt>Self: DareEnvelope (Optional)
<dd>The contact data.
</dl>
###Structure: ReplyContact

<dl>
<dt>Inherits:  RequestContact
</dl>

[No fields]

###Structure: GroupInvitation

<dl>
<dt>Inherits:  Message
</dl>

<dl>
<dt>Text: String (Optional)
<dt>EncryptedPartDecrypt: DareEnvelope (Optional)
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
<dt>Request: RequestConfirmation (Optional)
<dt>Accept: Boolean (Optional)
</dl>
###Structure: RequestTask

<dl>
<dt>Inherits:  Message
</dl>

[No fields]

