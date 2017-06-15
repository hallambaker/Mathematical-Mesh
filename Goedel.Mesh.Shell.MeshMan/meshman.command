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


	// SSH
	CommandSet SSHSet "ssh"
		Command SSHCreate "create"
			Brief "Add a ssh application profile to a personal profile"
			Include PortalAccount
			Include Reporting
			Parameter Install "install" Flag
		
		Command SSHSync "sync"
			Brief "Synchronize this machine to SSH parameters from the mesh"
			Include PortalAccount
			Include Reporting


		Command SSHAuth "auth"
			Brief "List the SSH Authorized keys"
			Include ApplicationProfile
			Include Reporting
			Parameter Host "host" Flag
			Parameter Client "client" Flag

		Command SSHKnown "known"
			Brief "List the SSH Known Hosts"
			Include ApplicationProfile
			Include Reporting
			Parameter Host "host" Flag
			Parameter Client "client" Flag


		Command SSHPublic "public"
			Brief "Return the ssh public key for this device"
			Include ApplicationProfile
			Include Reporting
			Parameter Host "host" Flag
			Parameter Client "client" Flag

		Command SSHPrivate "private"
			Brief "Return the ss private key for this device"
			Include ApplicationProfile
			Include Reporting
			Parameter Host "host" Flag
			Parameter Client "client" Flag



	//Confirm
	CommandSet ConfirmSet "confirm"
		Command ConfirmCreate "create"
			Brief "Add a confirmation profile account"
			Include PortalAccount
			Include Reporting
			Parameter Address "address" String
				Brief "Confirmation account to create "
			Option PIN "pin" String
				Brief "One time use authenticator"

		Command ConfirmPost "post"
			Brief "Post a confirmation request to an account"
			Include ApplicationProfile
			Include Reporting

		Command ConfirmGet "get"
			Brief "List the pending confirmation requests for this account"
			Include ApplicationProfile
			Include Reporting

		Command ConfirmAccept "accept"
			Brief "Accept a confirmation request"
			Include ApplicationProfile
			Include Reporting

		Command ConfirmReject "reject"
			Brief "Reject a confirmation request"
			Include ApplicationProfile
			Include Reporting

	//Recrypt
	CommandSet RecryptSet "recrypt"
		Command RecryptCreate "create"
			Brief "Add a confirmation profile account"
			Include PortalAccount
			Include Reporting
			Parameter Address "address" String
				Brief "Confirmation account to create "
			Option PIN "pin" String
				Brief "One time use authenticator"

		Command RecryptGroup "group"
			Brief "Create a new recryption group"
			Include ApplicationProfile
			Include Reporting

		Command RecryptAdd "add"
			Brief "Add a member to a recryption group"
			Include ApplicationProfile
			Include Reporting

		Command RecryptDelete "delete"
			Brief "Remove a member from a recryption group"
			Include ApplicationProfile
			Include Reporting

		Command Encrypt "encrypt"
			Brief "Encrypt a file or directory"
			Include ApplicationProfile
			Include Reporting

		Command Decrypt "decrypt"
			Brief "Decrypt a file or directory"
			Include ApplicationProfile
			Include Reporting