

#Cryptographic Data Objects

##Public Key Objects

###Structure: PublicKey

Container for public key pair data


UDF: String (Optional)

:UDF fingerprint of the key

X509Certificate: Binary (Optional)

:List of X.509 Certificates

X509Chain: Binary [0..Many]

:X.509 Certificate chain.

X509CSR: Binary (Optional)

:X.509 Certificate Signing Request.

##JOSE Signature Objects

###Structure: SignedData

Container for JOSE signed data and related attributes.


Data: Binary (Optional)

##JOSE Encryption Objects

###Structure: EncryptedData

Container for JOSE encrypted data and related attributes.


Data: Binary (Optional)

#Mesh Profile Objects

##Base Profile Objects

###Structure: Entry

Base class for all Mesh Profile objects.


Identifier: String (Optional)

:Globally unique identifier that remains constant for the lifetime of the 
entry.

###Structure: SignedProfile

* Inherits: Entry

Contains a signed profile entry


SignedData: JoseWebSignature (Optional)

:The signed profile.

:Note that each child of SignedProfile requires that the Payload field
of the SignedData object contain an object of a specific type. 
For example, a SignedDeviceProfile object MUST contain a Payload field that
contains a DeviceProfile object.

###Structure: Profile

* Inherits: Entry

Parent class from which all profile types are derrived


Names: String [0..Many]

:Fingerprints of index terms for profile retrieval. The use of the fingerprint
of the name rather than the name itself is a precaution against enumeration
attacks and other forms of abuse.

Updated: DateTime (Optional)

:The time instant the profile was last modified.

NotaryToken: String (Optional)

:A Uniform Notary Token providing evidence that a signature
was performed after the notary token was created.

##Device Profile Objects

###Structure: SignedDeviceProfile

* Inherits: SignedProfile

Contains a signed device profile

[None]

###Structure: DeviceProfile

* Inherits: Profile

Describes a mesh device.


Description: String (Optional)

:Description of the device

DeviceSignatureKey: PublicKey (Optional)

:Key used to sign certificates for the DAK and DEK. The fingerprint of
the DSK is the UniqueID of the Device Profile

DeviceAuthenticationKey: PublicKey (Optional)

:Key used to authenticate requests made by the device.

DeviceEncryptiontionKey: PublicKey (Optional)

:Key used to pass encrypted data to the device such as a
DeviceUseEntry

###Structure: DevicePrivateProfile

Private portion of device encryption profile. 


DeviceSignatureKey: Key (Optional)

:Private portion of the DeviceSignatureKey

DeviceAuthenticationKey: Key (Optional)

:Private portion of the DeviceAuthenticationKey

DeviceEncryptiontionKey: Key (Optional)

:Private portion of the DeviceEncryptiontionKey

##Master Profile Objects

###Structure: SignedMasterProfile

* Inherits: SignedProfile

Contains a signed Personal master profile

[None]

###Structure: MasterProfile

* Inherits: Profile

Describes the long term parameters associated with a personal profile.


MasterSignatureKey: PublicKey (Optional)

:The root of trust for the Personal PKI, the public key of the PMSK 
is presented as a self-signed X.509v3 certificate with Certificate 
Signing use enabled. The PMSK is used to sign certificates for the 
PMEK, POSK and PKEK keys.

MasterEscrowKeys: PublicKey [0..Many]

:A Personal Profile MAY contain one or more PMEK keys to enable escrow 
of private keys used for stored data. 

OnlineSignatureKeys: PublicKey [0..Many]

:A Personal profile contains at least one POSK which is used to sign 
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


SignedMasterProfile: SignedMasterProfile (Optional)

:The corresponding master profile. 
The profile MUST be signed by the PMSK.

Devices: SignedDeviceProfile [0..Many]

:The set of device profiles connected to the profile.
The profile MUST be signed by the DSK in the profile.

Applications: ApplicationProfileEntry [0..Many]

:Application profiles connected to this profile.

##Application Profile Objects

###Structure: SignedApplicationProfile

* Inherits: SignedProfile

Contains a signed device profile

[None]

###Structure: EncryptedProfile

* Inherits: Entry

Contains an encrypted profile entry


EncryptedData: JoseWebEncryption (Optional)

:The signed and encrypted profile

###Structure: ApplicationProfile

* Inherits: Profile

Parent class from which all application profiles inherit.


EncryptedData: JoseWebEncryption (Optional)

:Encrypted application data	

###Structure: ApplicationProfileEntry


Identifier: String (Optional)

:The unique identifier of the application

Type: String (Optional)

:The application type

Friendly: String (Optional)

:Optional friendly name identifying the application.

SignID: String [0..Many]

:List of devices authorized to sign application profiles

DecryptID: String [0..Many]

:List of devices authorized to read private parts of application 
profiles					

##Common Application Objects

###Structure: Connection

Describes network connection parameters for an application


ServiceName: String (Optional)

:DNS address of the server

Port: Integer (Optional)

:TCP/UDP Port number

Prefix: String (Optional)

:DNS service prefix as described in [!RFC6335]

Security: String [0..Many]

:Describes the security mode to use. Valid choices are Direct/Upgrade/None

UserName: String (Optional)

:Username to present to the service for authentication

Password: String (Optional)

:Password to present to the service for authentication

URI: String (Optional)

:Service connection parameters in URI format

Authentication: String (Optional)

:List of the supported/acceptable authentication mechanisms,
preferred mechanism first.

TimeOut: Integer (Optional)

:Service timeout in seconds.

Polling: Boolean (Optional)

:If set, the client should poll the specified service intermittently
for updates.

##Password Application Profile Objects

###Structure: PasswordProfile

* Inherits: ApplicationProfile

Stores usernames and passwords

[None]

###Structure: PasswordProfilePrivate


Entries: PasswordEntry [0..Many]

###Structure: PasswordEntry

Username password entry for a single site


Sites: String [0..Many]

:DNS name of site *.example.com matches www.example.com
etc.

Username: String (Optional)

:Case sensitive username

Password: String (Optional)

:Case sensitive password.

##Mail Application Profile Objects

###Structure: MailProfile

* Inherits: ApplicationProfile

Public profile describes mail receipt policy. Private describes
Sending policy


EncryptionPGP: PublicKey (Optional)

:The current OpenPGP encryption key

EncryptionSMIME: PublicKey (Optional)

:The current S/MIME encryption key

###Structure: MailProfilePrivate

Describes a mail account configuration

Private profile contains connection settings for the inbound and
outbound mail server(s) and cryptographic private keys. Public
profile may contain security policy information for the sender.


EmailAddress: String (Optional)

:The RFC822 Email address. [e.g. "alice@example.com"]

ReplyToAddress: String (Optional)

:The RFC822 Reply toEmail address. [e.g. "alice@example.com"]

:When set, allows a sender to tell the receiver that replies to
this account should be directed to this address.

DisplayName: String (Optional)

:The Display Name. [e.g. "Alice Example"]

AccountName: String (Optional)

:The Account Name for display to the app user [e.g. "Work Account"]

Inbound: Connection [0..Many]

:The Inbound Mail Connection(s). This is typically IMAP4 or POP3

:If multiple connections are specified, the order in the sequence
indicates the preference order.

Outbound: Connection [0..Many]

:The Outbound Mail Connection(s). This is typically SMTP/SUBMIT

:If multiple connections are specified, the order in the sequence
indicates the preference order.

Sign: PublicKey [0..Many]

:The public keypair(s) for signing and decrypting email.

:If multiple public keys are specified, the order indicates preference.

Encrypt: PublicKey [0..Many]

:The public keypairs for encrypting and decrypting email.

:If multiple public keys are specified, the order indicates preference.							

##Network Application Profile Objects

###Structure: NetworkProfile

* Inherits: ApplicationProfile

Describes the network profile to follow

[None]

###Structure: NetworkProfilePrivate

Describes the network profile to follow


Sites: String [0..Many]

:DNS name of sites to which profile applies *.example.com matches www.example.com
etc.		

DNS: Connection [0..Many]

:DNS Resolution Services

Prefix: String [0..Many]

:DNS prefixes to search

CTL: Binary (Optional)

:Certificate Trust List giving WebPKI roots to trust

WebPKI: String [0..Many]

:List of UDF fingerprints of keys making up the trust roots
to be accepted for Web PKI purposes.

##Key Escrow Objects

###Structure: EscrowEntry

* Inherits: Entry

Contains escrowed data


EncryptedData: JoseWebEncryption (Optional)

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


PrivateKeys: Key [0..Many]

:The escrowed keys.

#Portal Connection

##Connection Request and Response Structures

###Structure: ConnectionRequest

Describes a connection request.


ParentUDF: String (Optional)

:UDF of Mesh Profile to which connection is requested.

Device: SignedDeviceProfile (Optional)

:The Device profile to be connected

###Structure: SignedConnectionRequest

* Inherits: SignedProfile

Contains a ConnectionRequest signed by the 
corresponding device signature key.

[None]

###Structure: ConnectionResult

Describes the result of a connection request.

* Inherits: ConnectionRequest


Result: String (Optional)

:The result of the connection request. Valid responses are:
Accepted, Refused, Query.

###Structure: SignedConnectionResult

* Inherits: SignedProfile

Contains a signed connection result

[None]

