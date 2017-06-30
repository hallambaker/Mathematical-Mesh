

#Mesh/Confirm Application Profile Objects

###Structure: ConfirmProfile

Application profile for Confirm

* Inherits: ApplicationProfile


Account: String (Optional)

:The account to which the profile is bound

Authentication: PublicKey [0..Many]

:Authorized Authentication keys for this account. Authentication
keys provide authentication without providing non-repudiability.
This permits their use in cases where it is desirable to avoid
the possibility of contractual binding.

Signature: PublicKey [0..Many]

:Authorized Signature keys for this account.Signature keys
provide non-repudiable authentication of a response. This permits
their use in cases where it is desirable to provide the possibility
of contractual binding.

###Structure: ConfirmPrivate

Private portion of profile. Currently empty.

* Inherits: ApplicationProfilePrivate

[None]

###Structure: ConfirmDevicePublic

Public data specific to the device

* Inherits: ApplicationDevicePublic


SignPublicKey: PublicKey (Optional)

:A private keypair or keypair contribution created for exclusive use 
of this device.

AuthPublicKey: PublicKey (Optional)

:A private keypair or keypair contribution created for exclusive use 
of this device.

###Structure: ConfirmDevicePrivate

Private data specific to the device

* Inherits: ApplicationDevicePrivate


SignPrivateKey: PublicKey (Optional)

:A private keypair or keypair contribution created for exclusive use 
of this device.

AuthPrivateKey: PublicKey (Optional)

:A private keypair or keypair contribution created for exclusive use 
of this device.

