

###Structure: Serialization

<dl>
<dt>Default: DateTime (Optional)
<dd>If present, the profile was made default at the specified date and time. 
The default profile being the profile with the latest value for
Default.
Base class for profile serialization

</dl>
###Structure: SerializationPersonal

Serialize personal profile.

<dl>
<dt>Inherits:  Serialization
</dl>

<dl>
<dt>Profile: SignedPersonalProfile (Optional)
<dd>The profile being serialized.
<dt>Portals: SerializationPortal [0..Many]
<dd>List of portals the profile is registered to.
</dl>
###Structure: SerializationPortal

Describe a portal connection.

<dl>
<dt>Address: String (Optional)
<dd>Portal address.
</dl>
###Structure: SerializationApplication

Serialize application profile.

<dl>
<dt>Inherits:  Serialization
</dl>

<dl>
<dt>Profile: SignedApplicationProfile (Optional)
<dd>The profile being serialized.
</dl>
###Structure: SerializationDevice

Serialize device profile.

<dl>
<dt>Inherits:  Serialization
</dl>

<dl>
<dt>Profile: SignedDeviceProfile (Optional)
<dd>The profile being serialized.
</dl>
