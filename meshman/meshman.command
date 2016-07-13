Class Goedel.Mesh.MeshMan Shell

	Type NewFile			"file"
	Type ExistingFile		"file"

	About "About"
	Brief		"brief"

	OptionSet Reporting
		Option Verbose "verbose" Flag
			Default "true"
			Brief "Verbose reports (default)"
		Option Report "report" Flag
			Default "true"
			Brief "Report results (default)"

	OptionSet PortalAccount
		Option Portal "portal" String
			Brief "Portal account"
		Option UDF "udf" String
			Brief "Profile fingerprint"

	OptionSet DeviceProfileInfo
		Option DeviceNew "new" Flag
			Brief "Force creation of new profile"
		Option DeviceUDF "dudf" String
			Brief "Device profile fingerprint"
		Option DeviceID "did" String
			Brief "Device identifier"
		Option DeviceDescription "dd" String
			Brief "Device description"

	// For debugging
	Command Reset "reset"
		Brief "Delete all test profiles"
		
	// Profile management

	Command Device "device"
		Brief "Create new device profile"
		Parameter DeviceID "id" String
			Brief "Device identifier"
		Parameter DeviceDescription "dd" String
			Brief "Device description"
		Option Default "default" Flag
			Brief "Make the new device profile the default"

	Command Personal "personal"
		Brief "Create new personal profile"
		Parameter Portal "portal" String
			Brief "New portal account"
		Parameter Description "pd" String
			Brief "Device description"
		Include Reporting
		Include DeviceProfileInfo


		Option Next "next" Flag
			Brief "If set ask the "


	Command Register "register"
		Brief "Register the specified profile at a new portal"
		Parameter UDF "udf" String
			Brief "Profile fingerprint"
		Parameter Portal "portal" String
			Brief "New portal account"
		Include Reporting

	Command Sync "sync"
		Brief "Synchronize local copies of Mesh profiles with the server"
		Include PortalAccount
		Include Reporting

	Command Escrow "escrow"
		Brief "Create a set of key escrow shares"
		Include PortalAccount
		Include Reporting
		Option Quorum "quorum" integer
		Option Shares "shares" integer


	Command Export "export"
		Brief "Export the specified profile data to the specified file"
		Parameter File "file" NewFile
		Include PortalAccount
		Include Reporting

	Command Import "import"
		Brief "Import the specified profile data to the specified file"
		Parameter File "file" NewFile
		Include PortalAccount
		Include Reporting

	// Describe configuration
	Command List "list"
		Brief "List all profiles on the local machine"
		Include Reporting

	Command Dump "dump"
		Brief "Describe the specified profile"
		Include PortalAccount
		Include Reporting


	// Connection related
	Command Pending "pending"
		Brief "Get list of pending connection requests"
		Include PortalAccount
		Include Reporting
			
	Command Connect "connect"
		Brief "Connect to an existing profile registered at a portal"
		Parameter Portal "portal" String
			Brief "New portal account"
		Option PIN "pin" String
			Brief "One time use authenticator"
		Include Reporting
		Include DeviceProfileInfo

	Command Accept "accept"
		Brief "Accept a pending connection"
		Parameter DeviceUDF "udf" String
			Brief "Fingerprint of connection to accept"
		Include Reporting
		Include PortalAccount

	Command Complete "complete"
		Brief "Complete a pending connection request"
		Include Reporting
		Include PortalAccount

	// Application profiles
	Command Password "password"
		Brief "Add a web application profile to a personal profile"
		Include PortalAccount
		Include Reporting

	Command AddPassword "pwadd"
		Brief "Add password entry"
		Parameter Site "site" String
		Parameter Username "user" String
		Parameter Password "password" String
		Include PortalAccount
		Include Reporting

	Command GetPassword "pwget"
		Brief "Lookup password entry"
		Parameter Site "site" String
		Include PortalAccount
		Include Reporting

	Command DeletePassword "pwdelete"
		Brief "Delete password entry"
		Parameter Site "site" String
			Brief "Domain name of Web site"
		Include PortalAccount
		Include Reporting

	Command DumpPassword "pwdump"
		Brief "Describe password entry"
		Parameter JSON "json" Flag
			Brief "Report results as JSON structure."
		Include PortalAccount
		Include Reporting


	// Mail
	Command Mail "mail"
		Brief "Add a mail application profile to a personal profile"
		Parameter address "address" String
			Brief "Mail account to create profile from"
		Include PortalAccount
		Include Reporting

	// SSH
	Command SSH "ssh"
		Brief "Add a ssh application profile to a personal profile"
		Include PortalAccount
		Include Reporting
