Class Goedel.Recrypt.Shell Shell

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

	Command Label "label"
		Brief "Create new security label"
		Include PortalAccount

	Command Add "add"
		Brief "Add user to a label"

	Command Remove "remove"
		Brief "Remove user from a label"

	Command Rekey "rekey"
		Brief "Create a new label key and recryption keys"

	Command Encrypt "encrypt"
		Brief "Encrypt a data file to a label"

	Command Decrypt "decrypt"
		Brief "Decrypt a data file"

		
