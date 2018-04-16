Class Goedel.Confirm.Shell.Server ConfirmShell
	Brief		"Mesh/Confirm service"
	About "about"

	Command Start "start"
		Brief "Start the Mesh/Confirm service"

		Parameter ServiceAddress "portal" String
			Brief "Portal DNS address"

		Parameter HostAddress "host" String
			Brief "Host address for Web Service Endpoint"

		Option Port "Port" Integer
			Brief "Port"


		Option Store "log" String
			Default "RecryptPersistenceStore.jlog"
			Brief "Log file for transactions"

		Option Verify			"verify"		Flag
			Brief "Verify configuration only"

		Option Fallback			"fallback"	Flag
			Brief "Bind to fallback Web Service Endpoint (default)"
			Default "true"

		Option Multithread		"multi"	Flag
			Brief "run as multithreaded service (default)"
			Default "true"

