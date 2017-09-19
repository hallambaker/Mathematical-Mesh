Class MeshServerShell MeshServerShell
	Brief		"MatheMatical Mesh Server"

	Type NewFile			"file"
	Type ExistingFile		"file"

	Command Start "start"
		DefaultCommand
		Brief "Start Mesh server"

		Parameter PortalAddress "service" String
			Brief "Service DNS address"

		Parameter HostAddress "host" String
			Brief "Host address for Web Service Endpoint"

		Option MeshStore "mlog" String
			Default "MeshPersistenceStore.jlog"
			Brief "Log file for mesh transactions"

		Option PortalStore "plog" String
			Default "PortalPersistenceStore.jlog"
			Brief "Log file for portal transactions"

		Option Verify			"verify"		Flag
			Brief "Verify configuration only"

		Option Fallback			"fallback"	Flag
			Brief "Bind to fallback Web Service Endpoint (default)"
			Default "true"

		Option Multithread		"multi"	Flag
			Brief "run as multithreaded service (default)"
			Default "true"

	Command About "about"
		Brief "Report version and build date"