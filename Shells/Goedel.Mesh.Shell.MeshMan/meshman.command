Class Goedel.Mesh.MeshMan Shell
	Library

	Type NewFile			"file"
	Type ExistingFile		"file"

	About "About"
	Brief		"brief"

	OptionSet Reporting
		Option Verbose "verbose" Flag
			Default "false"
			Brief "Verbose reports (default)"
		Option Report "report" Flag
			Default "true"
			Brief "Report results (default)"

	OptionSet PortalAccount
		Option Portal "portal" String
			Brief "Portal account"
		Option UDF "udf" String
			Brief "Profile fingerprint"

	OptionSet ApplicationProfile
		Option Portal "portal" String
			Brief "Portal account"
		Option UDF "udf" String
			Brief "Profile fingerprint"
		Option ID "id" String
			Brief "Application profile friendly name"

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
		Option Barcode "barcode" String
			Brief "Create a barcode URL with the specified prefix"



	Command Verify "verify"
		Brief "Verify requested portal address"
		Parameter Portal "portal" String
			Brief "Test portal account"
		Include Reporting

	// Describe configuration
	Command List "list"
		Brief "List all profiles on the local machine"
		Include Reporting

	Command Dump "dump"
		Brief "Describe the specified profile"
		Include PortalAccount
		Include Reporting

	CommandSet Personal "personal"
		Command PersonalCreate "create"
			Brief "Create new personal profile"
			Parameter Portal "portal" String
				Brief "New portal account"
			Parameter Description "pd" String
				Brief "Device description"
			Include Reporting
			Include DeviceProfileInfo


		Command Register "register"
			Brief "Register the specified profile at a new portal"
			Parameter Portal "portal" String
				Brief "New portal account"
			Parameter UDF "udf" String
				Brief "Profile fingerprint"
			Include Reporting

		Command Deregister "deregister"
			Brief "Deregister the specified profile at a portal"
			Parameter Portal "portal" String
				Brief "New portal account"
			Include Reporting


		Command Fingerprint "fingerprint"
			Brief "Return the fingerprint of a Mesh profile"
			Option DeviceID "did" String
				Brief "Device identifier"
			Include PortalAccount
			Include Reporting

		Command Sync "sync"
			Brief "Synchronize local copies of Mesh profiles with the server"
			Include PortalAccount
			Include Reporting

		Command Escrow "escrow"
			Brief "Create a set of key escrow shares"
			Include PortalAccount
			Include Reporting
			Option Quorum "quorum" Integer
			Option Shares "shares" Integer
			Option File "file" NewFile

		Command Recover "recover"
			Parameter Portal "portal" String
				Brief "New portal account"
			Parameter Description "pd" String
				Brief "Device description"
			Brief "Recover a previously escrowed key"
			Parameter S0 "s0" String
			Parameter S1 "s1" String
			Parameter S2 "s2" String
			Parameter S3 "s3" String
			Parameter S4 "s4" String
			Parameter S5 "s5" String
			Parameter S6 "s6" String
			Parameter S7 "s7" String
			Parameter S8 "s8" String
			Parameter S9 "s9" String
			Parameter S10 "s10" String

		Command Purge "purge"
			Parameter Portal "portal" String
				Brief "New portal account"
			Parameter Description "pd" String
				Brief "Device description"
			Brief "Recover a previously escrowed key"
			Parameter S0 "s0" String
			Parameter S1 "s1" String
			Parameter S2 "s2" String
			Parameter S3 "s3" String
			Parameter S4 "s4" String
			Parameter S5 "s5" String
			Parameter S6 "s6" String
			Parameter S7 "s7" String
			Parameter S8 "s8" String
			Parameter S9 "s9" String
			Parameter S10 "s10" String
			Option Force "force" Flag

		Command Export "export"
			Brief "Export the specified profile data to the specified file"
			Parameter File "file" NewFile
			Option Password "password" String
			Include PortalAccount
			Include Reporting

		Command Import "import"
			Brief "Import the specified profile data to the specified file"
			Parameter File "file" NewFile
			Option Password "password" String
			Include PortalAccount
			Include Reporting


	CommandSet ConnectSet "connect"

		// Connection related
		Command Pending "pending"
			Brief "Get list of pending connection requests"
			Include PortalAccount
			Include Reporting
			
		Command Connect "start"
			Brief "Connect to an existing profile registered at a portal"
			Parameter Portal "portal" String
				Brief "New portal account"
			Option PIN "pin" String
				Brief "One time use authenticator"
			Option Reboot "reboot" Flag
				Brief "Reconnect using a bootstrap profile"
			Include Reporting
			Include DeviceProfileInfo

		Command Bootstrap "bootstrap"
			Brief "Create a bootstrap profile"
			Include Reporting
			Include PortalAccount



		Command Accept "accept"
			Brief "Accept a pending connection"
			Parameter DeviceUDF "udf" String
				Brief "Fingerprint of connection to accept"
			Include Reporting
			Include PortalAccount
			Option PreAuthorized "pre" Flag
				Brief "Accept all pre-authorized requests"

		Command Complete "complete"
			Brief "Complete a pending connection request"
			Include Reporting
			Include PortalAccount

		Command PIN "generate"
			Brief "Generate a PIN pre-authorizing a connection request"
			Include Reporting
			Include PortalAccount


	// Application profiles
	CommandSet PasswordSet "password"

		Command PasswordCreate "create"
			Brief "Add a web application profile to a personal profile"
			Include PortalAccount
			Include Reporting

		Command AddPassword "add"
			Brief "Add password entry"
			Parameter Site "site" String
			Parameter Username "user" String
			Parameter Password "password" String
			Include ApplicationProfile
			Include Reporting

		Command GetPassword "get"
			Brief "Lookup password entry"
			Parameter Site "site" String
			Include ApplicationProfile
			Include Reporting

		Command DeletePassword "delete"
			Brief "Delete password entry"
			Parameter Site "site" String
				Brief "Domain name of Web site"
			Include ApplicationProfile
			Include Reporting

		Command DumpPassword "dump"
			Brief "Describe password entry"
			Parameter JSON "json" Flag
				Brief "Report results as JSON structure."
			Include ApplicationProfile
			Include Reporting


	// Mail
	CommandSet MailSet "mail"
		Command MailCreate "create"
			Brief "Add a mail application profile to a personal profile"
			Parameter Address "address" String
				Brief "Mail account to create profile from"
			Option CA "ca" String
				Brief "Domain name of CA"
			Include PortalAccount
			Include Reporting

		Command MailSetData "set"
			Include PortalAccount
			Include Reporting
			Parameter File "file" ExistingFile
				Brief "Input file"
			Option Password "pass" String
				Brief "Password used to encrypt private data"

		Command MailGetData "get"
			Include PortalAccount
			Include Reporting
			Parameter File "file" NewFile
				Brief "Output file"
			Option Password "pass" String
				Brief "Password used to encrypt private data"
			Parameter P12 "p12" Flag
				Brief "If set, include keydata in PKCS12 format."
			Parameter OpenPGP "openpgp" Flag
				Brief "If set, include keydata in OpenPGP format."

	// SSH
	CommandSet SSHSet "ssh"
		Command SSHCreate "create"
			Brief "Add a ssh application profile to a personal profile"
			Include PortalAccount
			Include Reporting
			Option Install "install" String
				Brief "Format"
				
		Command SSHSync "sync"
			Brief "Synchronize this machine to SSH parameters from the mesh"
			Include PortalAccount
			Include Reporting
			Parameter Path "path" String

		Command SSHAuth "auth"
			Brief "List the SSH Authorized keys"
			Include ApplicationProfile
			Include Reporting
			Parameter Host "host" String
			Option Format "format" String
				Brief "Format"

		Command SSHKnown "known"
			Brief "List the SSH Known Hosts"
			Include ApplicationProfile
			Include Reporting
			Parameter Host "host" Flag
				Brief "If specified, only list keys for this host"
			Option Format "format" String
				Brief "Format"

		Command SSHAdd "add"
			Brief "Add an SSH host"
			Include ApplicationProfile
			Include Reporting
			Parameter Host "host" String
			Parameter Algorithm "algorithm" String
			Parameter Key "key" String

		Command SSHPublic "public"
			Brief "Return the ssh public key for this device"
			Include ApplicationProfile
			Include Reporting
			Parameter File "file" NewFile
				Brief "Output file"
			Option Password "pass" String
				Brief "Password"
			Option Format "format" String
				Brief "Format"

		Command SSHPrivate "private"
			Brief "Return the ssh private key for this device"
			Include ApplicationProfile
			Include Reporting
			Parameter File "file" NewFile
				Brief "Output file"
			Option Password "pass" String
				Brief "Password"
			Option Format "format" String
				Brief "Format"



	// Key generation
	Command KeyGen "keygen"
		Include Reporting
		Brief "Generate a secret key"
		Parameter Algorithm "alg" String
			Brief "The algorithm to use (default is password)"