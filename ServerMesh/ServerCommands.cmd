Class MeshServerShell MeshServerShell
	Brief		"MatheMatical Mesh Server"

	Type NewFile			"file"
	Type ExistingFile		"file"

	Command Start "start"
		DefaultCommand
		Parameter Address "address" String
		Option MeshStore "mesh" String
			Default "MeshPersistenceStore.jlog"

		Option PortalStore "mesh" String
			Default "PortalPersistenceStore.jlog"

		Option  Verify			"verify"		Flag
			Brief "Verify configuration only"


	Command About "about"
		Brief "Report version and build date"