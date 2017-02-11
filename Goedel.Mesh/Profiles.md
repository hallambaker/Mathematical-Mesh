=Mesh Profile Classes

Writing code to handle signed data leads to the nesting problem. When the data is serialized 
in wire form, the signature object naturally wraps the data being signed. In writing code
to interact with the data it is usually best to consider the signature to be a property of
the class mapping the data that is signed

The Mesh libraries are (or will be) based on the second approach. Methods should always use
the class mapping the data that is signed.

For example, DeviceProfile has the following property:

: SignedDeviceProfile

:: The signature wrapper for the data

: Sign(string UDF=null,  KeyPair KeyPair = null)

:: Create a new signature wrapper

The corresponding wrapper has the following properties:

: DeviceProfile

:: The unpacked profile as a DeviceProfile

: Profile

:: The unpacked profile as a Profile

: SignedData

:: The signature

: SignedData.Data

:: The UTF8 encoded DeviceProfile

: Validate ()

:: Validate the signature on the profile according to the implicit trust chain

: Unpack ()

:: Validate and unpack the profile


==Creating and Updating Profiles

Profiles are managed through the MeshCatalog of profile registrations. The pattern for 
creating, manipulating and updating profiles is:

* Create the profile.

* Register the profile in the MeshCatalog. This causes the profile to be persisted
on the local machine and the portal(s).

* Fetch the profile from the catalog.

* Modify the profile.

* Update the registered profile.

This approach allows us to use the Profile* classes to interact with the profile data
and then checkpoint that data against the local and remote mesh.

~~~~
~~~~
