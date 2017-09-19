Class Goedel.Recrypt.Shell Shell
	Brief		"Mesh/Recrypt Server"

	Type NewFile			"file"
	Type ExistingFile		"file"

	Command Start "start"
		DefaultCommand
		Parameter Address "address" String

		Option PortalStore "log" String
			Default "PortalPersistenceStore.jlog"

		Option  Verify			"verify"		Flag
			Brief "Verify configuration only"


	Command About "about"
		Brief "Report version and build date"