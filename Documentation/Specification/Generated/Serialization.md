

###Structure: Serialization


Default: DateTime (Optional)

###Structure: SerializationPersonal

* Inherits: Serialization


Profile: SignedPersonalProfile (Optional)

Portals: SerializationPortal [0..Many]

###Structure: SerializationPortal


Address: String (Optional)

###Structure: SerializationApplication

* Inherits: Serialization


Profile: SignedApplicationProfile (Optional)

###Structure: SerializationDevice

* Inherits: Serialization


Profile: SignedDeviceProfile (Optional)

