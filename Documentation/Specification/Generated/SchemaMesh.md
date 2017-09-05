

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


<dl><dt>UDF: 
<dd>String (Optional)


UDF fingerprint of the public key parameters/

<dl><dt>X509Certificate: 
<dd>Binary (Optional)


List of X.509 Certificates

<dl><dt>X509Chain: 
<dd>Binary [0..Many]


X.509 Certificate chain.

<dl><dt>X509CSR: 
<dd>Binary (Optional)


X.509 Certificate Signing Request.

###Structure: SignedData

Container for JOSE signed data and related attributes.


<dl><dt>Data: 
<dd>Binary (Optional)


The signed data

###Structure: EncryptedData

Container for JOSE encrypted data and related attributes.


<dl><dt>Data: 
<dd>Binary (Optional)


The encrypted data

##Common Application Classes

###Structure: Connection

Describes network connection parameters for an application


<dl><dt>ServiceName: 
<dd>String (Optional)


DNS address of the server

<dl><dt>Port: 
<dd>Integer (Optional)


TCP/UDP Port number

<dl><dt>Prefix: 
<dd>String (Optional)


DNS service prefix as described in [!RFC6335]

<dl><dt>Security: 
<dd>String [0..Many]


Describes the security mode to use. Valid choices are Direct/Upgrade/None

<dl><dt>UserName: 
<dd>String (Optional)


Username to present to the service for authentication

<dl><dt>Password: 
<dd>String (Optional)


Password to present to the service for authentication

<dl><dt>URI: 
<dd>String (Optional)


Service connection parameters in URI format

<dl><dt>Authentication: 
<dd>String (Optional)


List of the supported/acceptable authentication mechanisms,
preferred mechanism first.

<dl><dt>TimeOut: 
<dd>Integer (Optional)


Service timeout in seconds.

<dl><dt>Polling: 
<dd>Boolean (Optional)


If set, the client should poll the specified service intermittently
for updates.

#Mesh Profile Objects

##Base Profile Objects

###Structure: Entry

Base class for all Mesh Profile objects.


<dl><dt>Identifier: 
<dd>String (Optional)


Globally unique identifier that remains constant for the lifetime of the 
entry.

###Structure: SignedProfile

* Inherits: Entry

Contains a signed profile entry


<dl><dt>SignedData: 
<dd>JoseWebSignature (Optional)


The signed profile.


Note that each child of SignedProfile requires that the Payload field
of the SignedData object contain an object of a specific type. 
For example, a SignedDeviceProfile object MUST contain a Payload field that
contains a DeviceProfile object.

<dl><dt>Unauthenticated: 
<dd>Advice (Optional)


Additional data that is not authenticated.

###Structure: Advice

Additional data bound to a signed profile that is not authenticated.


<dl><dt>Default: 
<dd>DateTime (Optional)


If specified, the profile was the default profile at the specified 
date and time. The current default for that type of profile is the
profile with the most recent Default timestamp.

###Structure: PortalAdvice

* Inherits: Advice


<dl><dt>PortalAddress: 
<dd>String [0..Many]


A portal address at which this profile is registered.

###Structure: Profile

* Inherits: Entry

Parent class from which all profile types are derived


<dl><dt>Names: 
<dd>String [0..Many]


Fingerprints of index terms for profile retrieval. The use of the fingerprint
of the name rather than the name itself is a precaution against enumeration
attacks and other forms of abuse.

<dl><dt>Updated: 
<dd>DateTime (Optional)


The time instant the profile was last modified.

<dl><dt>NotaryToken: 
<dd>String (Optional)


A Uniform Notary Token providing evidence that a signature
was performed after the notary token was created.

##Device Profile Classes

###Structure: SignedDeviceProfile

* Inherits: SignedProfile

Contains a signed device profile

[None]

###Structure: DeviceProfile

* Inherits: Profile

Describes a mesh device.


<dl><dt>Description: 
<dd>String (Optional)


Description of the device

<dl><dt>DeviceSignatureKey: 
<dd>PublicKey (Optional)


Key used to sign certificates for the DAK and DEK. The fingerprint of
the DSK is the UniqueID of the Device Profile

<dl><dt>DeviceAuthenticationKey: 
<dd>PublicKey (Optional)


Key used to authenticate requests made by the device.

<dl><dt>DeviceEncryptiontionKey: 
<dd>PublicKey (Optional)


Key used to pass encrypted data to the device such as a
DeviceUseEntry

###Structure: DevicePrivateProfile

Private portion of device encryption profile. 


<dl><dt>DeviceSignatureKey: 
<dd>Key (Optional)


Private portion of the DeviceSignatureKey

<dl><dt>DeviceAuthenticationKey: 
<dd>Key (Optional)


Private portion of the DeviceAuthenticationKey

<dl><dt>DeviceEncryptiontionKey: 
<dd>Key (Optional)


Private portion of the DeviceEncryptiontionKey

##Master Profile Objects

###Structure: SignedMasterProfile

* Inherits: SignedProfile

Contains a signed Personal master profile

[None]

###Structure: MasterProfile

* Inherits: Profile

Describes the long term parameters associated with a personal profile.


<dl><dt>MasterSignatureKey: 
<dd>PublicKey (Optional)


The root of trust for the Personal PKI, the public key of the PMSK 
is presented as a self-signed X.509v3 certificate with Certificate 
Signing use enabled. The PMSK is used to sign certificates for the 
PMEK, POSK and PKEK keys.

<dl><dt>MasterEscrowKeys: 
<dd>PublicKey [0..Many]


A Personal Profile MAY contain one or more PMEK keys to enable escrow 
of private keys used for stored data. 

<dl><dt>OnlineSignatureKeys: 
<dd>PublicKey [0..Many]


A Personal profile contains at least one POSK which is used to sign 
device administration application profiles.

##Personal Profile Objects

###Structure: SignedPersonalProfile

* Inherits: SignedProfile

Contains a signed Personal current profile

[None]

###Structure: PersonalProfile

* Inherits: Profile

Describes the current applications and devices connected to a 
personal master profile.


<dl><dt>SignedMasterProfile: 
<dd>SignedMasterProfile (Optional)


The corresponding master profile. 
The profile MUST be signed by the PMSK.

<dl><dt>Devices: 
<dd>SignedDeviceProfile [0..Many]


The set of device profiles connected to the profile.
The profile MUST be signed by the DSK in the profile.

<dl><dt>Applications: 
<dd>ApplicationProfileEntry [0..Many]


Application profiles connected to this profile.

###Structure: ApplicationProfileEntry

Personal profile entry describing the privileges of specific devices.


<dl><dt>Identifier: 
<dd>String (Optional)


The unique identifier of the application

<dl><dt>Type: 
<dd>String (Optional)


The application type

<dl><dt>Friendly: 
<dd>String (Optional)


Optional friendly name identifying the application.

<dl><dt>SignID: 
<dd>String [0..Many]


List of devices authorized to sign application profiles

<dl><dt>DecryptID: 
<dd>String [0..Many]


List of devices authorized to read private parts of application 
profiles		

##Application Profile Objects

###Structure: SignedApplicationProfile

* Inherits: SignedProfile

Contains a signed device profile

[None]

###Structure: ApplicationProfile

* Inherits: Profile

Parent class from which all application profiles inherit.

[None]

###Structure: ApplicationProfilePrivate

* Inherits: Entry

The base class for all private profiles.

[None]

###Structure: ApplicationDevicePublic

* Inherits: Entry

Describes the public per device data


<dl><dt>DeviceDescription: 
<dd>String (Optional)


Description of the device for convenience of the user.

<dl><dt>DeviceUDF: 
<dd>String (Optional)


Fingerprint of device that this key corresponds to.

###Structure: ApplicationDevicePrivate

* Inherits: Entry

Describes the private per device data

[None]

##Key Escrow Objects

###Structure: EscrowEntry

* Inherits: Entry

Contains escrowed data


<dl><dt>EncryptedData: 
<dd>JoseWebEncryption (Optional)


The encrypted escrow data 

###Structure: OfflineEscrowEntry

* Inherits: EscrowEntry

Contains data escrowed using the offline escrow mechanism.

[None]

###Structure: OnlineEscrowEntry

* Inherits: EscrowEntry

Contains data escrowed using the online escrow mechanism.

[None]

###Structure: EscrowedKeySet

A set of escrowed keys. 

[None]

#Portal Connection

##Connection Request and Response Structures

###Structure: ConnectionRequest

Describes a connection request.


<dl><dt>ParentUDF: 
<dd>String (Optional)


UDF of Mesh Profile to which connection is requested.

<dl><dt>Device: 
<dd>SignedDeviceProfile (Optional)


The Device profile to be connected

###Structure: SignedConnectionRequest

* Inherits: SignedProfile

Contains a ConnectionRequest signed by the 
corresponding device signature key.

[None]

###Structure: ConnectionResult

Describes the result of a connection request.

* Inherits: ConnectionRequest


<dl><dt>Result: 
<dd>String (Optional)


The result of the connection request. Valid responses are:
Accepted, Refused, Query.

###Structure: SignedConnectionResult

* Inherits: SignedProfile

Contains a signed connection result

[None]

