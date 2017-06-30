

#SSH Application Profile Objects

###Structure: SSHProfile

Application profile for SSH. This is an initial cut of the 
profile and will need revision. In particular, a sysadmin with 
a very large number of hosts they are accessing will need some means
of avoiding combinatorial explosion.

* Inherits: ApplicationProfile

[None]

###Structure: SSHDevicePublic

Contains public device description

* Inherits: ApplicationDevicePublic


PublicKey: PublicKey (Optional)

:Public authentication key for a device.

###Structure: SSHProfilePrivate

Private portion or profile.

* Inherits: ApplicationProfilePrivate


Account: String (Optional)

:The account to which the profile is bound

HostEntries: HostEntry [0..Many]

:Hosts bound to the profile

###Structure: HostEntry

Describe a host connected to the SSH profile. This is a machine 
that the user will access using the credential.

* Inherits: Entry


Address: String (Optional)

:The DNS address or IP address of the host

AlgorithmID: String (Optional)

:The SSH Algorithm identifier

PublicKey: String (Optional)

:The Base64 encoded public key

###Structure: SSHDevicePrivate

Private data specific to the device

* Inherits: ApplicationDevicePrivate


DevicePrivateKey: PublicKey (Optional)

:A private keypair or keypair contribution created for exclusive use 
of this device.

KeyUDF: String (Optional)

:Fingerprint of device that this key corresponds to.

