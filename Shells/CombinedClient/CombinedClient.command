Class Goedel.Combined.Shell.Client CombinedShell
	Library

	Brief		"Client for Mesh/Confirm service"
	Command Null "null"
		Brief "Do nothing yet"

	OptionSet Reporting
		Option Verbose "verbose" Flag
			Default "false"
			Brief "Verbose reports (default)"
		Option Report "report" Flag
			Default "true"
			Brief "Report results (default)"

	OptionSet DeviceProfileInfo
		Option DeviceNew "new" Flag
			Brief "Force creation of new profile"
		Option DeviceUDF "dudf" String
			Brief "Device profile fingerprint"
		Option DeviceID "did" String
			Brief "Device identifier"
		Option DeviceDescription "dd" String
			Brief "Device description"

	OptionSet MeshProfile
		Option MeshID "mesh" String
			Brief "Mesh account identified by fingerprint or portal ID"

	OptionSet InputSpecifier
		Option In "in" ExistingFile
			Brief "The input file"
		Option Out "out" NewFile
			Brief "The output file"
		Option Recurse "Recurse" Flag
			Brief "Perform operation recursively on subdirectories"


	CommandSet Mesh "mesh" 
		Brief "Create and manage mesh profiles (subset only)"
		Command PersonalCreate "create"
			Brief "Create new personal profile"
			Parameter Portal "portal" String
				Brief "New portal account"
			Parameter Description "pd" String
				Brief "Device description"
			Include Reporting
			Include DeviceProfileInfo

	CommandSet Account "account"
		Brief "Manage a messaging account"

		Command AccountCreate "create"
			Brief "Create a new messaging account"
			Include Reporting
			Include MeshProfile
			Parameter AccountID "id" String
				Brief "The account identifier in name@example.com format"
			Option PIN "pin" String
				Brief "One time use authenticator"

		Command AccountDelete "delete"
			Brief "Delete a messaging account"
			Include Reporting
			Include MeshProfile
			Parameter AccountID "id" String
				Brief "The account identifier in name@example.com format"

		Command AccountUpdate "update"
			Brief "Update a messaging account to add or remove features"
			Include Reporting
			Include MeshProfile
			Parameter AccountID "id" String
				Brief "The account identifier in name@example.com format"

		Command AccountGet "get"
			Brief "Get account status"
			Include Reporting
			Include MeshProfile
			Parameter AccountID "id" String
				Brief "The account identifier in name@example.com format"

	CommandSet Confirm "confirm"
		Brief "Perform a confirmation service operation"

		Command ConfirmPost "post"
			Brief "Post a confirmation request"
			Parameter AccountID "id" String
				Brief "The responder account identifier in name@example.com format"
			Parameter Text "text" String
				Brief "The text of the confirmation request"

		Command ConfirmStatus "status"
			Brief "Obtain the satus of a previously posted request."
			Parameter ID "id" String
				Brief "The broker ID of the confirmation request"
			Option Cancel "cancel" Flag
				Brief "Cancel the request if no response has been received."

		Command ConfirmPending "pending"
			Brief "Get pending confirmation requests"
			Option AccountID "id" String
				Brief "The responder account identifier in name@example.com format"

		Command ConfirmAccept "accept"
			Brief "Accept a pending confirmation request"
			Parameter ID "id" String
				Brief "The broker ID of the confirmation request"
			Option AccountID "id" String
				Brief "The responder account identifier in name@example.com format"

		Command ConfirmReject "reject"
			Brief "Reject a pending confirmation request"
			Parameter ID "id" String
				Brief "The broker ID of the confirmation request"
			Option AccountID "id" String
				Brief "The responder account identifier in name@example.com format"

	CommandSet Recrypt "recrypt"
		Brief "Perform recryption operations."
		Command CreateGroup "create"
			Brief "Create a recryption group"
			Include MeshProfile

			Parameter GroupID "group" String
				Brief "The group identifier in name@example.com format"
			Parameter AccountID "profile" String
				Brief "The initial account administrator"

		Command RecryptAdd "add"
			Brief "Add a member to a recryption group."
			Include MeshProfile
			Parameter GroupID "id" String
				Brief "The recryption group identifier in name@example.com format"
			Parameter AccountID "id" String
				Brief "The user account identifier in name@example.com format"

		Command RecryptDelete "delete"
			Brief "Delete a member from a recryption group."
			Include MeshProfile
			Parameter GroupID "id" String
				Brief "The recryption group identifier in name@example.com format"
			Parameter AccountID "id" String
				Brief "The user account identifier in name@example.com format"

		Command Encrypt "encrypt"
			Brief "Encrypt a file or files"
			Parameter GroupID "id" String
				Brief "The recryption group identifier in name@example.com format"
			Include InputSpecifier
			Option Upload "Upload" Flag
				Brief "Upload the encrypted file to the service"
			Option Path "path" String
				Brief "Path to store the encrypted file to"

		Command Decrypt "decrypt"
			Brief "Decrypt a file or files"
			Include InputSpecifier
			Include MeshProfile
			Option Path "path" String
				Brief "Path to store the decrypted file to"

