

#Mesh/Recrypt Application Profile Objects

###Structure: RecryptProfile

Application profile for Confirm

* Inherits: ApplicationProfile


Account: String (Optional)

:The account to which the profile is bound

###Structure: RecryptDevicePublic

Contains public device description

* Inherits: ApplicationDevicePublic


EncryptKey: PublicKey (Optional)

:A private keypair or keypair contribution created for exclusive use 
of this device.

AuthKey: PublicKey (Optional)

:A private keypair or keypair contribution created for exclusive use 
of this device.

###Structure: RecryptProfilePrivate

Private portion of profile. Currently empty. Might have a list of 
registered accounts at some point or may not.

* Inherits: ApplicationProfilePrivate

[None]

###Structure: RecryptDevicePrivate

Private data specific to the device

* Inherits: ApplicationDevicePrivate


EncryptKey: PublicKey (Optional)

:A private keypair or keypair contribution created for exclusive use 
of this device.

AuthKey: PublicKey (Optional)

:A private keypair or keypair contribution created for exclusive use 
of this device.

