

#Connection descriptions

The following classes are used to store Mesh connection descriptions.

###Structure: CatalogedMachine

Describes a current or pending connection to a Mesh

<dl>
<dt>Id: String (Optional)
<dd>Unique object instance identifier.
<dt>Local: String (Optional)
<dd>Local short name for the profile
<dt>Default: Boolean (Optional)
<dd>If true, this is the default for the profile type (master, account)
<dt>EnvelopedProfileAccount: Enveloped<ProfileAccount> (Optional)
<dd>The master profile that provides the root of trust for this Mesh
<dt>CatalogedDevice: CatalogedDevice (Optional)
<dd>The cataloged device profile
<dt>CatalogedDeviceDigest: String (Optional)
<dd>The digest of the cataloged device.
<dt>EnvelopedAccountHostAssignment: Enveloped<AccountHostAssignment> (Optional)
<dd>The enveloped assignment describing how the client should
discover the host and encrypt data to it.
</dl>
###Structure: CatalogedService

<dl>
<dt>Inherits:  CatalogedMachine
</dl>

Describes an ordinary device connected to a Mesh

<dl>
<dt>EnvelopedProfileService: Enveloped<ProfileService> (Optional)
<dd>The service profile
<dt>EnvelopedProfileHost: Enveloped<ProfileHost> (Optional)
<dd>The host profile
<dt>EnvelopedActivationCommon: Enveloped<ActivationCommon> (Optional)
<dd>The activation record for the service client (if used)
<dt>EnvelopedActivationHost: Enveloped<ActivationHost> (Optional)
<dd>The activation record for this host
<dt>EnvelopedConnectionService: Enveloped<ConnectionService> (Optional)
<dd>The connection of the host to the service
<dt>ServiceIdentifier: String (Optional)
<dd>Specifies the type of service 
</dl>
###Structure: CatalogedStandard

<dl>
<dt>Inherits:  CatalogedMachine
</dl>

Describes an ordinary device connected to a Mesh

[No fields]

###Structure: CatalogedPending

<dl>
<dt>Inherits:  CatalogedMachine
</dl>

Describes a pending connection to a Mesh account believed to have been 
created and posted to a service.

<dl>
<dt>DeviceUDF: String (Optional)
<dd>UDF of the connected device
<dt>EnvelopedProfileDevice: Enveloped<ProfileDevice> (Optional)
<dd>The device profile presented to the service.
<dt>EnvelopedAcknowledgeConnection: Enveloped<AcknowledgeConnection> (Optional)
<dd>The response returned by the service when the registration was requested.
<dt>AccountAddress: String (Optional)
<dd>The account at which the request is pending.
</dl>
###Structure: CatalogedPreconfigured

<dl>
<dt>Inherits:  CatalogedMachine
</dl>

Describes a preconfigured Device Profile bound to a remote 
manufacturer profile.

<dl>
<dt>EnvelopedProfileDevice: Enveloped<ProfileDevice> (Optional)
<dd>The device profile presented to the service.
<dt>EnvelopedConnectionService: Enveloped<ConnectionService> (Optional)
<dd>The device connection used to authenticate to the service.
<dt>EnvelopedConnectionDevice: Enveloped<ConnectionDevice> (Optional)
<dd>The device connection used to authenticate to the service.
<dt>AccountAddress: String (Optional)
<dd>The account to which claims will be posted
<dt>PublicationId: String (Optional)
<dd>The publication identifier
<dt>ServiceAuthenticator: String (Optional)
<dd>Authenticator key used to authenticate claim to the service.
<dt>DeviceAuthenticator: String (Optional)
<dd>Authenticator key used to authenticate claim to the device.	
</dl>
