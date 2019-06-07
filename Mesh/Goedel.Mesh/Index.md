# Goedel.Mesh


[Per Mesh]
ProfileMaster  Signed Mesh.KeySignature
		PublicKey KeySignature
		PublicKey KeyEncryption
		List<PublicKey> MasterEscrowKeys
		List<PublicKey> OnlineSignatureKeys

[Per Account]
AssertionAccount Signed Mesh.OnlineSignatureKeys[n]
		PublicKey AccountEncryptionKey

[Per Device]
ProfileDevice Signed self.KeySignature
		PublicKey KeySignature
		PublicKey KeyEncryption
		PublicKey KeyAuthentication


[Per Mesh/Device]
AssertionDeviceConnection Signed Mesh.OnlineSignatureKeys[n]
		PublicKey KeySignature = ProfileDevice.KeySignature + DevicePrivate.KeySignature
		PublicKey KeyEncryption = ProfileDevice.KeyEncryption + DevicePrivate.KeyEncryption
		PublicKey KeyAuthentication = ProfileDevice.KeyAuthentication + DevicePrivate.KeyAuthentication

AssertionDevicePrivate Encrypted (ProfileDevice.KeyEncryption, Mesh.KeyEncryption)
		KeyOverlay KeySignature
		KeyOverlay KeyEncryption
		KeyOverlay KeyAuthentication
		List<Activation> Activations

[Per Mesh/Device/Account]

ActivationAccount (Encrypted via AssertionDevicePrivate)
		KeyOverlay KeySignature
		KeyOverlay KeyEncryption

ConnectionAccount Signed Mesh.OnlineSignatureKeys[n]
		PublicKey KeySignature
		PublicKey KeyAuthentication



## To Do

* Re-open mesh profile from persisted file

* Re-open mesh account from persisted file

* Ensure that the activations posted to an account are persisted.

* Read contacts catalog update from account

* Create PIN for connect

* Create connection request

* Approve connection request

* Synchronize after connection

* Authenticate request

* Make documentation of above

* Verify signatures on assertions

* Validate chains.

* Tests that bad chains are rejected.

