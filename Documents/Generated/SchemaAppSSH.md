

##SSH Application Profile Objects

Profiles that describe SSH user agent configuration

###Structure: SSHProfile

Application profile for SSH. This is an initial cut of the 
profile and will need revision. In particular, a sysadmin with 
a very large number of hosts they are accessing will need some means
of avoiding combinatorial explosion.

<dl>
<dt>Inherits:  ApplicationProfile
</dl>

[No fields]

###Structure: SSHDevicePublic

Contains public device description

<dl>
<dt>Inherits:  ApplicationDevicePublic
</dl>

<dl>
<dt>PublicKey: PublicKey (Optional)
<dd>Public authentication key for a device.
</dl>
###Structure: SSHProfilePrivate

Private portion or profile.

<dl>
<dt>Inherits:  ApplicationProfilePrivate
</dl>

<dl>
<dt>Account: String (Optional)
<dd>The account to which the profile is bound
<dt>HostEntries: HostEntry [0..Many]
<dd>Hosts bound to the profile
</dl>
###Structure: HostEntry

Describe a host connected to the SSH profile. This is a machine 
that the user will access using the credential.

<dl>
<dt>Inherits:  Entry
</dl>

<dl>
<dt>Address: String (Optional)
<dd>The DNS address or IP address of the host
<dt>AlgorithmID: String (Optional)
<dd>The SSH Algorithm identifier
<dt>PublicKey: String (Optional)
<dd>The Base64 encoded public key
</dl>
###Structure: SSHDevicePrivate

Private data specific to the device

<dl>
<dt>Inherits:  ApplicationDevicePrivate
</dl>

<dl>
<dt>DevicePrivateKey: PublicKey (Optional)
<dd>A private keypair or keypair contribution created for exclusive use 
of this device.
<dt>KeyUDF: String (Optional)
<dd>Fingerprint of device that this key corresponds to.
</dl>
