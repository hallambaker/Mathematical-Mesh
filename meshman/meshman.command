Class Goedel.Mesh.MeshMan MeshManShell
	Brief		"MatheMatical Mesh Key Manager"

	Type NewFile			"file"
	Type ExistingFile		"file"


	Command About "about"
		Brief "Report version and build date"


	// For debugging
	Command Reset "reset"
		Brief "Delete all test profiles"
		
	// Profile management
	Command Create "create"
		Brief "Create new personal profile"
		Parameter Profile "profile" String

	Command Register "register"
		Brief "Register the specified profile at a new portal"
		Parameter UDF "udf" String
			Brief "Profile fingerprint"
		Parameter Portal "portal" String
			Brief "New portal account"

	Command Sync "sync"
		Brief "Synchronize local copies of Mesh profiles with the server"
		Parameter Portal "portal" String
			Brief "Portal account"
		Parameter UDF "udf" String
			Brief "Profile fingerprint"

	Command Escrow "escrow"
		Brief "Create a set of key escrow shares"
		Parameter Portal "portal" String
			Brief "Portal account"
		Parameter UDF "udf" String
			Brief "Profile fingerprint"
		Option Quorum "quorum" integer
		Option Shares "shares" integer


	Command Export "export"
		Brief "Export the specified profile data to the specified file"
		Parameter File "file" NewFile
		Parameter Portal "portal" String
			Brief "Portal account"
		Parameter UDF "udf" String
			Brief "Profile fingerprint"

	Command Import "import"
		Brief "Import the specified profile data to the specified file"
		Parameter File "file" NewFile
		Parameter Portal "portal" String
			Brief "Portal account"
		Parameter UDF "udf" String
			Brief "Profile fingerprint"


	// Describe configuration
	Command List "list"
		Brief "List all profiles"
		Parameter Portal "portal" String
			Brief "Portal account"
		Parameter UDF "udf" String
			Brief "Profile fingerprint"
		Parameter All "all" Flag
			Brief "List all profiles"
	
	// Connection related
	Command Pending "pending"
		Brief "Get list of pending connection requests"
		Option Portal "portal" String
			Brief "Portal account"
	
	Command Connect "connect"
		Brief "Connect to an existing profile registered at a portal"
		Parameter UDF "udf" String
			Brief "Profile fingerprint"
		Option Portal "portal" String
			Brief "Portal account"
		Option PIN "pin" String
			Brief "One time use authenticator"

	Command Accept "accept"
		Brief "Accept a pending connection"
		Parameter UDF "udf" String
			Brief "Fingerprint of connection to accept"

	Command Complete "complete"
		Brief "Complete a pending connection request"
		Option Portal "portal" String
			Brief "Portal account"
		Parameter UDF "udf" String
			Brief "Profile fingerprint"


	// Application profiles
	Command Web "web"
		Brief "Add a web application profile to a personal profile"
		Option Portal "portal" String
			Brief "Portal account"
		Parameter UDF "udf" string
			Brief "Profile String"

	Command AddPassword "pwa"
		Parameter Site "site" String
		Parameter Username "user" String
		Parameter Password "password" String
		Option Portal "portal" String
			Brief "Portal account"
		Parameter UDF "udf" String
			Brief "Profile fingerprint"

	Command GetPassword "pwg"
		Parameter Site "site" String
		Option Portal "portal" String
			Brief "Portal account"
		Parameter UDF "udf" string
			Brief "Profile fingerprint"

	Command DeletePassword "pwd"
		Parameter Site "site" String
			Brief "Domain name of Web site"
		Option Portal "portal" String
			Brief "Portal account"
		Parameter UDF "udf" String
			Brief "Profile fingerprint"

	// Mail
	Command Mail "mail"
		Brief "Add a mail application profile to a personal profile"
		Parameter address "address" String
			Brief "Mail account to create profile from"
		Option Portal "portal" String
			Brief "Portal account"
		Parameter UDF "udf" String
			Brief "Profile fingerprint"

	// SSH
	Command SSH "ssh"
		Brief "Add a ssh application profile to a personal profile"
		Option Portal "portal" String
			Brief "Portal account"
		Parameter UDF "udf" String
			Brief "Profile fingerprint"