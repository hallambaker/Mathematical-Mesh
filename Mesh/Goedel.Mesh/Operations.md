Catalog Escrow
	Decrypt MeshEscrowEncryptKey
	Contains
		CatalogEncryptKey

Catalog Capability
	Decrypt CapabilityGroupKey




Device Service
	Has CapabilityGroupKey

Device Recovery
	Is Genesis
	Has MeshSecret
		Grants MeshEscrowEncryptKey
		Grants MeshOfflineSignKey
		Grants CapabilityGroupKey

Device Genesis
	|Device with full, unrestricted privileges.
	Is MetaAdmin
	Grants MeshSecret
		Grants MeshEscrowEncryptKey
		Grants MeshOfflineSignKey
		Grants CapabilityGroupKey
	Operation CreateRecoveryShares (n,t)
		Requires MeshSecret
	Operation EraseMeshSecret
		Requires MeshSecret
		Becomes MetaAdmin
	Operation RecoverCatalog
		Requires MeshSecret
	Operation ChangeServiceProvider
		Requires MeshSecret


Device MetaAdmin
	// Can make another MetaAdmin despite not having the recovery key.
	// We don't need to support this yet!

	Has AdminSignKey
	Has MeshSignatureShare(MetaAdmin)
	Has CapabilityGroupShare(MetaAdmin)

	Operation AddMetaAdmin
		Requires MeshSignatureShare(MetaAdmin)
			Sign MeshProfile
			Create MeshSignatureShare(MetaAdmin)
		Requires CapabilityGroupShare(MetaAdmin)

	Operation ChangeServiceProvider
		Requires CapabilityGroupShare(MetaAdmin)
	
	Operation AddAdmin
		Requires MeshSignatureShare(MetaAdmin)
			Sign MeshProfile


Device Admin
	Is External
	Has AdminSignShare(Service)
	Has CatalogDeviceDecryptKey

	Operation AddDevice
		Requires AdminSignShare(Service)
			Sign MeshProfile

Device Messaging
	Is Connected
	Has ExternalMessageDecryptShare
	Has CatalogContactDecryptShare
	Has CatalogBookmarkDecryptSharey
	Has CatalogTaskDecryptShare
	Has CatalogCredentialDecryptShare
	Has CatalogApplicationDecryptShare

Device Connected
	// Only receives specific keys on 'need to know' basis.


Keys
	MeshSecret
		MeshEscrowEncrypt
		MeshOfflineSign
		CapabilityGroup
		CatalogDevice
		CatalogBookmark
		CatalogCalendar
		CatalogContact
		CatalogCredential
		CatalogApplication
		CatalogNetwork

	AdminSign			// Unique to signer device


