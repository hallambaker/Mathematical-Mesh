#MeshItem

##MeshItem Transactions

##MeshItem Messages

##MeshItem Structures

###Structure: Entry


:Identifier :
::String [0..1]   

Globally unique identifier that remains constant for the lifetime of the 
entry.

###Structure: SignedProfile

Contains a signed profile entry


:Identifier :
::String [0..1]   

Globally unique identifier that remains constant for the lifetime of the 
entry.

:SignedData :
::JoseWebSignature [0..1]   

The signed profile

###Structure: SignedDeviceProfile

Contains a signed device profile


:Identifier :
::String [0..1]   

Globally unique identifier that remains constant for the lifetime of the 
entry.

:SignedData :
::JoseWebSignature [0..1]   

The signed profile

###Structure: SignedMasterProfile

Contains a signed Personal master profile


:Identifier :
::String [0..1]   

Globally unique identifier that remains constant for the lifetime of the 
entry.

:SignedData :
::JoseWebSignature [0..1]   

The signed profile

###Structure: SignedPersonalProfile

Contains a signed Personal current profile


:Identifier :
::String [0..1]   

Globally unique identifier that remains constant for the lifetime of the 
entry.

:SignedData :
::JoseWebSignature [0..1]   

The signed profile

###Structure: SignedApplicationProfile

Contains a signed device profile


:Identifier :
::String [0..1]   

Globally unique identifier that remains constant for the lifetime of the 
entry.

:SignedData :
::JoseWebSignature [0..1]   

The signed profile

###Structure: EncryptedProfile

Contains an encrypted profile entry


:Identifier :
::String [0..1]   

Globally unique identifier that remains constant for the lifetime of the 
entry.

:EncryptedData :
::JoseWebEncryption [0..1]   

The signed and encrypted profile

###Structure: Profile

Parent class from which all profile types are derrived


:Identifier :
::String [0..1]   

Globally unique identifier that remains constant for the lifetime of the 
entry.

:Names :
::String [0..Many]   

Fingerprints of index terms for profile retrieval. The use of the fingerprint
of the name rather than the name itself is a precaution against enumeration
attacks and other forms of abuse.

:Updated :
::DateTime [0..1]   

The time instant the profile was last modified.

:NotaryToken :
::String [0..1]   

A Uniform Notary Token providing evidence that a signature
was performed after the notary token was created.

###Structure: MasterProfile

Describes the long term parameters associated with a personal profile.


:Identifier :
::String [0..1]   

Globally unique identifier that remains constant for the lifetime of the 
entry.

:Names :
::String [0..Many]   

Fingerprints of index terms for profile retrieval. The use of the fingerprint
of the name rather than the name itself is a precaution against enumeration
attacks and other forms of abuse.

:Updated :
::DateTime [0..1]   

The time instant the profile was last modified.

:NotaryToken :
::String [0..1]   

A Uniform Notary Token providing evidence that a signature
was performed after the notary token was created.

:MasterSignatureKey :
::PublicKey [0..1]   

The root of trust for the Personal PKI, the public key of the PMSK 
is presented as a self-signed X.509v3 certificate with Certificate 
Signing use enabled. The PMSK is used to sign certificates for the 
PMEK, POSK and PKEK keys.

:MasterEscrowKeys :
::PublicKey [0..Many]   

A Personal Profile MAY contain one or more PMEK keys to enable escrow 
of private keys used for stored data. 

:OnlineSignatureKeys :
::PublicKey [0..Many]   

A Personal profile contains at least one POSK which is used to sign 
device administration application profiles.

###Structure: PersonalProfile

Describes the current applications and devices connected to a 
personal master profile.


:Identifier :
::String [0..1]   

Globally unique identifier that remains constant for the lifetime of the 
entry.

:Names :
::String [0..Many]   

Fingerprints of index terms for profile retrieval. The use of the fingerprint
of the name rather than the name itself is a precaution against enumeration
attacks and other forms of abuse.

:Updated :
::DateTime [0..1]   

The time instant the profile was last modified.

:NotaryToken :
::String [0..1]   

A Uniform Notary Token providing evidence that a signature
was performed after the notary token was created.

:SignedMasterProfile :
::SignedMasterProfile [0..1]   

The corresponding master profile. 
The profile MUST be signed by the PMSK.

:Devices :
::SignedDeviceProfile [0..Many]   

The set of device profiles connected to the profile.
The profile MUST be signed by the DSK in the profile.

:Applications :
::ApplicationProfileEntry [0..Many]   

Application profiles connected to this profile.

###Structure: ApplicationProfileEntry


:Identifier :
::String [0..1]   

The unique identifier of the application

:Type :
::String [0..1]   

The application type

:Friendly :
::String [0..1]   

Optional friendly name identifying the application.

:SignID :
::String [0..Many]   

List of devices authorized to sign application profiles

:DecryptID :
::String [0..Many]   

List of devices authorized to read private parts of application 
profiles					

###Structure: DeviceProfile

Describes a mesh device.


:Identifier :
::String [0..1]   

Globally unique identifier that remains constant for the lifetime of the 
entry.

:Names :
::String [0..Many]   

Fingerprints of index terms for profile retrieval. The use of the fingerprint
of the name rather than the name itself is a precaution against enumeration
attacks and other forms of abuse.

:Updated :
::DateTime [0..1]   

The time instant the profile was last modified.

:NotaryToken :
::String [0..1]   

A Uniform Notary Token providing evidence that a signature
was performed after the notary token was created.

:Description :
::String [0..1]   

Description of the device

:DeviceSignatureKey :
::PublicKey [0..1]   

Key used to sign certificates for the DAK and DEK. The fingerprint of
the DSK is the UniqueID of the Device Profile

:DeviceAuthenticationKey :
::PublicKey [0..1]   

Key used to authenticate requests made by the device.

:DeviceEncryptiontionKey :
::PublicKey [0..1]   

Key used to pass encrypted data to the device such as a
DeviceUseEntry

###Structure: DevicePrivateProfile

Private portion of device encryption profile. 


:DeviceSignatureKey :
::Key [0..1]   

Private portion of the DeviceSignatureKey

:DeviceAuthenticationKey :
::Key [0..1]   

Private portion of the DeviceAuthenticationKey

:DeviceEncryptiontionKey :
::Key [0..1]   

Private portion of the DeviceEncryptiontionKey

###Structure: ApplicationProfile

Parent class from which all application profiles inherit.


:Identifier :
::String [0..1]   

Globally unique identifier that remains constant for the lifetime of the 
entry.

:Names :
::String [0..Many]   

Fingerprints of index terms for profile retrieval. The use of the fingerprint
of the name rather than the name itself is a precaution against enumeration
attacks and other forms of abuse.

:Updated :
::DateTime [0..1]   

The time instant the profile was last modified.

:NotaryToken :
::String [0..1]   

A Uniform Notary Token providing evidence that a signature
was performed after the notary token was created.

:EncryptedData :
::JoseWebEncryption [0..1]   

Encrypted application data	

###Structure: PasswordProfile

Stores usernames and passwords


:Identifier :
::String [0..1]   

Globally unique identifier that remains constant for the lifetime of the 
entry.

:Names :
::String [0..Many]   

Fingerprints of index terms for profile retrieval. The use of the fingerprint
of the name rather than the name itself is a precaution against enumeration
attacks and other forms of abuse.

:Updated :
::DateTime [0..1]   

The time instant the profile was last modified.

:NotaryToken :
::String [0..1]   

A Uniform Notary Token providing evidence that a signature
was performed after the notary token was created.

:EncryptedData :
::JoseWebEncryption [0..1]   

Encrypted application data	

###Structure: PasswordProfilePrivate


:Entries :
::PasswordEntry [0..Many]   

[TBS]

###Structure: PasswordEntry

Username password entry for a single site


:Sites :
::String [0..Many]   

DNS name of site *.example.com matches www.example.com
etc.

:Username :
::String [0..1]   

Case sensitive username

:Password :
::String [0..1]   

Case sensitive password.

###Structure: MailProfile

Public profile describes mail receipt policy. Private describes
Sending policy


:Identifier :
::String [0..1]   

Globally unique identifier that remains constant for the lifetime of the 
entry.

:Names :
::String [0..Many]   

Fingerprints of index terms for profile retrieval. The use of the fingerprint
of the name rather than the name itself is a precaution against enumeration
attacks and other forms of abuse.

:Updated :
::DateTime [0..1]   

The time instant the profile was last modified.

:NotaryToken :
::String [0..1]   

A Uniform Notary Token providing evidence that a signature
was performed after the notary token was created.

:EncryptedData :
::JoseWebEncryption [0..1]   

Encrypted application data	

:EncryptionPGP :
::PublicKey [0..1]   

The current OpenPGP encryption key

:EncryptionSMIME :
::PublicKey [0..1]   

The current S/MIME encryption key

###Structure: MailProfilePrivate

Describes a mail account configuration

Private profile contains connection settings for the inbound and
outbound mail server(s) and cryptographic private keys. Public
profile may contain security policy information for the sender.


:EmailAddress :
::String [0..1]   

The RFC822 Email address. [e.g. "alice@example.com"]

:ReplyToAddress :
::String [0..1]   

The RFC822 Reply toEmail address. [e.g. "alice@example.com"]

When set, allows a sender to tell the receiver that replies to
this account should be directed to this address.

:DisplayName :
::String [0..1]   

The Display Name. [e.g. "Alice Example"]

:AccountName :
::String [0..1]   

The Account Name for display to the app user [e.g. "Work Account"]

:Inbound :
::Connection [0..Many]   

The Inbound Mail Connection(s). This is typically IMAP4 or POP3

If multiple connections are specified, the order in the sequence
indicates the preference order.

:Outbound :
::Connection [0..Many]   

The Outbound Mail Connection(s). This is typically SMTP/SUBMIT

If multiple connections are specified, the order in the sequence
indicates the preference order.

:Sign :
::PublicKey [0..Many]   

The public keypair(s) for signing and decrypting email.

If multiple public keys are specified, the order indicates preference.

:Encrypt :
::PublicKey [0..Many]   

The public keypairs for encrypting and decrypting email.

If multiple public keys are specified, the order indicates preference.							

###Structure: NetworkProfile

Describes the network profile to follow


:Identifier :
::String [0..1]   

Globally unique identifier that remains constant for the lifetime of the 
entry.

:Names :
::String [0..Many]   

Fingerprints of index terms for profile retrieval. The use of the fingerprint
of the name rather than the name itself is a precaution against enumeration
attacks and other forms of abuse.

:Updated :
::DateTime [0..1]   

The time instant the profile was last modified.

:NotaryToken :
::String [0..1]   

A Uniform Notary Token providing evidence that a signature
was performed after the notary token was created.

:EncryptedData :
::JoseWebEncryption [0..1]   

Encrypted application data	

###Structure: NetworkProfilePrivate

Describes the network profile to follow


:Sites :
::String [0..Many]   

DNS name of sites to which profile applies *.example.com matches www.example.com
etc.		

:DNS :
::Connection [0..Many]   

DNS Resolution Services

:Prefix :
::String [0..Many]   

DNS prefixes to search

:CTL :
::Binary [0..1]   

Certificate Trust List giving WebPKI roots to trust

:WebPKI :
::String [0..Many]   

List of UDF fingerprints of keys making up the trust roots
to be accepted for Web PKI purposes.

###Structure: EscrowEntry

Contains escrowed data


:Identifier :
::String [0..1]   

Globally unique identifier that remains constant for the lifetime of the 
entry.

:EncryptedData :
::JoseWebEncryption [0..1]   

[TBS]

###Structure: OfflineEscrowEntry

Contains data escrowed using the offline escrow mechanism.


:Identifier :
::String [0..1]   

Globally unique identifier that remains constant for the lifetime of the 
entry.

:EncryptedData :
::JoseWebEncryption [0..1]   

[TBS]

###Structure: OnlineEscrowEntry

Contains data escrowed using the online escrow mechanism.


:Identifier :
::String [0..1]   

Globally unique identifier that remains constant for the lifetime of the 
entry.

:EncryptedData :
::JoseWebEncryption [0..1]   

[TBS]

###Structure: EscrowedKeySet

A set of escrowed keys.


:PrivateKeys :
::Key [0..Many]   

The escrowed keys.

###Structure: Connection

Describes network connection parameters for an application


:ServiceName :
::String [0..1]   

DNS address of the server

:Port :
::Integer [0..1]   

TCP/UDP Port number

:Prefix :
::String [0..1]   

DNS service prefix as described in [!RFC6335]

:Security :
::String [0..Many]   

Describes the security mode to use. Valid choices are Direct/Upgrade/None

:UserName :
::String [0..1]   

Username to present to the service for authentication

:Password :
::String [0..1]   

Password to present to the service for authentication

:URI :
::String [0..1]   

Service connection parameters in URI format

:Authentication :
::String [0..1]   

List of the supported/acceptable authentication mechanisms,
preferred mechanism first.

:TimeOut :
::Integer [0..1]   

Service timeout in seconds.

:Polling :
::Boolean [0..1]   

If set, the client should poll the specified service intermittently
for updates.

###Structure: EncryptedData

Container for JOSE encrypted data and related attributes.


:Data :
::Binary [0..1]   

[TBS]

###Structure: SignedData

Container for JOSE signed data and related attributes.


:Data :
::Binary [0..1]   

[TBS]

###Structure: PublicKey

Container for public key pair data


:UDF :
::String [0..1]   

UDF fingerprint of the key

:X509Certificate :
::Binary [0..1]   

List of X.509 Certificates

:X509Chain :
::Binary [0..Many]   

X.509 Certificate chain.

:X509CSR :
::Binary [0..1]   

X.509 Certificate Signing Request.

###Structure: ConnectionRequest


:ParentUDF :
::String [0..1]   

[TBS]

:Device :
::SignedDeviceProfile [0..1]   

[TBS]

:BlockToken :
::String [0..1]   

[TBS]

###Structure: ConnectionResult


:ParentUDF :
::String [0..1]   

[TBS]

:Device :
::SignedDeviceProfile [0..1]   

[TBS]

:BlockToken :
::String [0..1]   

[TBS]

:Result :
::String [0..1]   

[TBS]

###Structure: SignedConnectionRequest

Contains a signed connection request


:Identifier :
::String [0..1]   

Globally unique identifier that remains constant for the lifetime of the 
entry.

:SignedData :
::JoseWebSignature [0..1]   

The signed profile

###Structure: SignedConnectionResult

Contains a signed connection request


:Identifier :
::String [0..1]   

Globally unique identifier that remains constant for the lifetime of the 
entry.

:SignedData :
::JoseWebSignature [0..1]   

The signed profile

