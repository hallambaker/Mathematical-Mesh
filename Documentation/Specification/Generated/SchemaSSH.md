

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


<dl><dt>PublicKey: 
<dd>PublicKey (Optional)


Public authentication key for a device.

###Structure: SSHProfilePrivate

Private portion or profile.

* Inherits: ApplicationProfilePrivate


<dl><dt>Account: 
<dd>String (Optional)


The account to which the profile is bound

<dl><dt>HostEntries: 
<dd>HostEntry [0..Many]


Hosts bound to the profile

###Structure: HostEntry

Describe a host connected to the SSH profile. This is a machine 
that the user will access using the credential.

* Inherits: Entry


<dl><dt>Address: 
<dd>String (Optional)


The DNS address or IP address of the host

<dl><dt>AlgorithmID: 
<dd>String (Optional)


The SSH Algorithm identifier

<dl><dt>PublicKey: 
<dd>String (Optional)


The Base64 encoded public key

###Structure: SSHDevicePrivate

Private data specific to the device

* Inherits: ApplicationDevicePrivate


<dl><dt>DevicePrivateKey: 
<dd>PublicKey (Optional)


A private keypair or keypair contribution created for exclusive use 
of this device.

<dl><dt>KeyUDF: 
<dd>String (Optional)


Fingerprint of device that this key corresponds to.

