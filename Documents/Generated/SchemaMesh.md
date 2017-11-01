

#Shared Classes

The following classes are used as common elements in
Mesh profile specifications.a

##Cryptographic Data Classes

Most Mesh objects are signed and/or encrypted. For consistency
all Mesh classes make use of the cryptographic data classes
described in this section.

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
###Structure: SignedData

Container for JOSE signed data and related attributes.

<dl>
<dt>Data: Binary (Optional)
<dd>The signed data
</dl>
###Structure: EncryptedData

Container for JOSE encrypted data and related attributes.

<dl>
<dt>Data: Binary (Optional)
<dd>The encrypted data
</dl>
##Common Application Classes

###Structure: Connection

Describes network connection parameters for an application

<dl>
<dt>ServiceName: String (Optional)
<dd>DNS address of the server
<dt>Port: Integer (Optional)
<dd>TCP/UDP Port number
<dt>Prefix: String (Optional)
<dd>DNS service prefix as described in [!RFC6335]
<dt>Security: String [0..Many]
<dd>Describes the security mode to use. Valid choices are Direct/Upgrade/None
<dt>UserName: String (Optional)
<dd>Username to present to the service for authentication
<dt>Password: String (Optional)
<dd>Password to present to the service for authentication
<dt>URI: String (Optional)
<dd>Service connection parameters in URI format
<dt>Authentication: String (Optional)
<dd>List of the supported/acceptable authentication mechanisms,
preferred mechanism first.
<dt>TimeOut: Integer (Optional)
<dd>Service timeout in seconds.
<dt>Polling: Boolean (Optional)
<dd>If set, the client should poll the specified service intermittently
for updates.
</dl>
#Mesh Profile Objects

##Base Profile Objects

###Structure: Entry

Base class for all Mesh Profile objects.

<dl>
<dt>Identifier: String (Optional)
<dd>Globally unique identifier that remains constant for the lifetime of the 
entry.
</dl>
###Structure: SignedProfile

<dl>
<dt>Inherits:  Entry
</dl>

Contains a signed profile entry

<dl>
<dt>SignedData: JoseWebSignature (Optional)
<dd>The signed profile.
<dd>Note that each child of SignedProfile requires that the Payload field
of the SignedData object contain an object of a specific type. 
For example, a SignedDeviceProfile object MUST contain a Payload field that
contains a DeviceProfile object.
<dt>Unauthenticated: Advice (Optional)
<dd>Additional data that is not authenticated.
</dl>
###Structure: Advice

Additional data bound to a signed profile that is not authenticated.

<dl>
<dt>Default: DateTime (Optional)
<dd>If specified, the profile was the default profile at the specified 
date and time. The current default for that type of profile is the
profile with the most recent Default timestamp.
</dl>
###Structure: PortalAdvice

Describes the portal(s) at which the profile is registered.

<dl>
<dt>Inherits:  Advice
</dl>

<dl>
<dt>PortalAddress: String [0..Many]
<dd>A portal address at which this profile is registered.
</dl>
###Structure: Profile

<dl>
<dt>Inherits:  Entry
</dl>

Parent class from which all profile types are derived

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
##Device Profile Classes

###Structure: SignedDeviceProfile

<dl>
<dt>Inherits:  SignedProfile
</dl>

Contains a signed device profile

[No fields]

###Structure: DeviceProfile

<dl>
<dt>Inherits:  Profile
</dl>

Describes a mesh device.

<dl>
<dt>Description: String (Optional)
<dd>Description of the device
<dt>DeviceSignatureKey: PublicKey (Optional)
<dd>Key used to sign certificates for the DAK and DEK. The fingerprint of
the DSK is the UniqueID of the Device Profile
<dt>DeviceAuthenticationKey: PublicKey (Optional)
<dd>Key used to authenticate requests made by the device.
<dt>DeviceEncryptiontionKey: PublicKey (Optional)
<dd>Key used to pass encrypted data to the device such as a
DeviceUseEntry
</dl>
###Structure: DevicePrivateProfile

Private portion of device encryption profile. 

<dl>
<dt>DeviceSignatureKey: Key (Optional)
<dd>Private portion of the DeviceSignatureKey
<dt>DeviceAuthenticationKey: Key (Optional)
<dd>Private portion of the DeviceAuthenticationKey
<dt>DeviceEncryptiontionKey: Key (Optional)
<dd>Private portion of the DeviceEncryptiontionKey
</dl>
##Master Profile Objects

###Structure: SignedMasterProfile

<dl>
<dt>Inherits:  SignedProfile
</dl>

Contains a signed Personal master profile

[No fields]

###Structure: MasterProfile

<dl>
<dt>Inherits:  Profile
</dl>

Describes the long term parameters associated with a personal profile.

<dl>
<dt>MasterSignatureKey: PublicKey (Optional)
<dd>The root of trust for the Personal PKI, the public key of the PMSK 
is presented as a self-signed X.509v3 certificate with Certificate 
Signing use enabled. The PMSK is used to sign certificates for the 
PMEK, POSK and PKEK keys.
<dt>MasterEscrowKeys: PublicKey [0..Many]
<dd>A Personal Profile MAY contain one or more PMEK keys to enable escrow 
of private keys used for stored data. 
<dt>OnlineSignatureKeys: PublicKey [0..Many]
<dd>A Personal profile contains at least one POSK which is used to sign 
device administration application profiles.
</dl>
##Personal Profile Objects

###Structure: SignedPersonalProfile

<dl>
<dt>Inherits:  SignedProfile
</dl>

Contains a signed Personal current profile

[No fields]

###Structure: PersonalProfile

<dl>
<dt>Inherits:  Profile
</dl>

Describes the current applications and devices connected to a 
personal master profile.

<dl>
<dt>SignedMasterProfile: SignedMasterProfile (Optional)
<dd>The corresponding master profile. 
The profile MUST be signed by the PMSK.
<dt>Devices: SignedDeviceProfile [0..Many]
<dd>The set of device profiles connected to the profile.
The profile MUST be signed by the DSK in the profile.
<dt>Applications: ApplicationProfileEntry [0..Many]
<dd>Application profiles connected to this profile.
</dl>
###Structure: ApplicationProfileEntry

Personal profile entry describing the privileges of specific devices.

<dl>
<dt>Identifier: String (Optional)
<dd>The unique identifier of the application
<dt>Type: String (Optional)
<dd>The application type
<dt>Friendly: String (Optional)
<dd>Optional friendly name identifying the application.
<dt>AdminDeviceUDF: String [0..Many]
<dd>List of devices authorized to sign application profiles
<dt>DecryptDeviceUDF: String [0..Many]
<dd>List of devices authorized to read private parts of application 
profiles.
</dl>
##Application Profile Objects

###Structure: SignedApplicationProfile

<dl>
<dt>Inherits:  SignedProfile
</dl>

Contains a signed device profile

[No fields]

###Structure: ApplicationProfile

<dl>
<dt>Inherits:  Profile
</dl>

Parent class from which all application profiles inherit.

[No fields]

###Structure: ApplicationProfilePrivate

<dl>
<dt>Inherits:  Entry
</dl>

The base class for all private profiles.

[No fields]

###Structure: ApplicationDevicePublic

<dl>
<dt>Inherits:  Entry
</dl>

Describes the public per device data

<dl>
<dt>DeviceDescription: String (Optional)
<dd>Description of the device for convenience of the user.
<dt>DeviceUDF: String (Optional)
<dd>Fingerprint of device that this key corresponds to.
</dl>
###Structure: ApplicationDevicePrivate

<dl>
<dt>Inherits:  Entry
</dl>

Describes the private per device data

[No fields]

##Key Escrow Objects

###Structure: EscrowEntry

<dl>
<dt>Inherits:  Entry
</dl>

Contains escrowed data

<dl>
<dt>EncryptedData: JoseWebEncryption (Optional)
<dd>The encrypted escrow data 
</dl>
###Structure: OfflineEscrowEntry

<dl>
<dt>Inherits:  EscrowEntry
</dl>

Contains data escrowed using the offline escrow mechanism.

[No fields]

###Structure: OnlineEscrowEntry

<dl>
<dt>Inherits:  EscrowEntry
</dl>

Contains data escrowed using the online escrow mechanism.

[No fields]

###Structure: EscrowedKeySet

A set of escrowed keys. 

[No fields]

#Portal Connection

##Connection Request and Response Structures

###Structure: ConnectionRequest

Describes a connection request.

<dl>
<dt>ParentUDF: String (Optional)
<dd>UDF of Mesh Profile to which connection is requested.
<dt>Device: SignedDeviceProfile (Optional)
<dd>The Device profile to be connected
</dl>
###Structure: SignedConnectionRequest

<dl>
<dt>Inherits:  SignedProfile
</dl>

Contains a ConnectionRequest signed by the 
corresponding device signature key.

[No fields]

###Structure: ConnectionResult

Describes the result of a connection request.

<dl>
<dt>Inherits:  ConnectionRequest
</dl>

<dl>
<dt>Result: String (Optional)
<dd>The result of the connection request. Valid responses are:
Accepted, Refused, Query.
</dl>
###Structure: SignedConnectionResult

<dl>
<dt>Inherits:  SignedProfile
</dl>

Contains a signed connection result

[No fields]

