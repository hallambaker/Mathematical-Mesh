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
			Include Reporting
			Brief "Post a confirmation request"
			Parameter AccountID "id" String
				Brief "The responder account identifier in name@example.com format"
			Parameter Text "text" String
				Brief "The text of the confirmation request"

		Command ConfirmStatus "status"
			Include Reporting
			Brief "Obtain the satus of a previously posted request."
			Parameter ID "id" String
				Brief "The broker ID of the confirmation request"
			Option Cancel "cancel" Flag
				Brief "Cancel the request if no response has been received."

		Command ConfirmPending "pending"
			Include Reporting
			Brief "Get pending confirmation requests"
			Option AccountID "id" String
				Brief "The responder account identifier in name@example.com format"

		Command ConfirmAccept "accept"
			Include Reporting
			Brief "Accept a pending confirmation request"
			Parameter ID "id" String
				Brief "The broker ID of the confirmation request"
			Option AccountID "id" String
				Brief "The responder account identifier in name@example.com format"

		Command ConfirmReject "reject"
			Include Reporting
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
			Include Reporting
			Parameter GroupID "group" String
				Brief "The group identifier in name@example.com format"
			Parameter AccountID "profile" String
				Brief "The initial account administrator"

		Command RecryptAdd "add"
			Brief "Add a member to a recryption group."
			Include MeshProfile
			Include Reporting
			Parameter GroupID "id" String
				Brief "The recryption group identifier in name@example.com format"
			Parameter AccountID "id" String
				Brief "The user account identifier in name@example.com format"

		Command RecryptDelete "delete"
			Brief "Delete a member from a recryption group."
			Include MeshProfile
			Include Reporting
			Parameter GroupID "id" String
				Brief "The recryption group identifier in name@example.com format"
			Parameter AccountID "id" String
				Brief "The user account identifier in name@example.com format"

		Command Encrypt "encrypt"
			Include Reporting
			Brief "Encrypt a file or files"
			Parameter GroupID "id" String
				Brief "The recryption group identifier in name@example.com format"
			Include InputSpecifier
			Option Upload "Upload" Flag
				Brief "Upload the encrypted file to the service"
			Option Path "path" String
				Brief "Path to store the encrypted file to"

		Command Decrypt "decrypt"
			Include Reporting
			Brief "Decrypt a file or files"
			Include InputSpecifier
			Include MeshProfile
			Option Path "path" String
				Brief "Path to store the decrypted file to"

	OptionSet CatalogAccount
		Option Catalog "catalog" String
			Brief "Catalog account"

	CommandSet Password "password"
		Brief "Manage password catalogs connected to an account"

		Command AddPassword "add"
			Brief "Add password entry"
			Parameter Site "site" String
			Parameter Username "user" String
			Parameter Password "password" String
			Include CatalogAccount
			Include PortalAccount
			Include Reporting

		Command GetUsername "user"
			Brief "Lookup password entry"
			Parameter Site "site" String
			Include CatalogAccount
			Include PortalAccount
			Include Reporting

		Command GetPassword "pass"
			Brief "Lookup password entry"
			Parameter Site "site" String
			Include CatalogAccount
			Include PortalAccount
			Include Reporting

		Command DeletePassword "delete"
			Brief "Delete password entry"
			Parameter Site "site" String
				Brief "Domain name of Web site"
			Include CatalogAccount
			Include PortalAccount
			Include Reporting

		Command DumpPassword "dump"
			Brief "List password entries"
			Parameter Site "site" String
			Option JSON "json" Flag
				Brief "Report results as JSON structure."
			Include CatalogAccount
			Include PortalAccount
			Include Reporting



	CommandSet Contact "contact"
		Brief "Manage contact catalogs connected to an account"

		Command AddContact "add"
			Brief "Add contact entry from file"
			Parameter File "file" ExistingFile
			Include CatalogAccount
			Include PortalAccount
			Include Reporting

		Command DeleteContact "delete"
			Brief "Delete contact entry"
			Parameter Identifier "id" String
				Brief "Contact entry identifier"
			Include CatalogAccount
			Include PortalAccount
			Include Reporting

		Command DumpContact "dump"
			Brief "List contact entries"
			Option JSON "json" Flag
				Brief "Report results as JSON structure."
			Include CatalogAccount
			Include PortalAccount
			Include Reporting

	CommandSet Bookmark "bookmark"
		Brief "Manage bookmark catalogs connected to an account"

		Command AddBookmark"add"
			Brief "Add bookmark entry from file"
			Parameter File "file" ExistingFile
			Include CatalogAccount
			Include PortalAccount
			Include Reporting

		Command DeleteBookmark "delete"
			Brief "Delete bookmark entry"
			Parameter Identifier "id" String
				Brief "Contact entry identifier"
			Include CatalogAccount
			Include PortalAccount
			Include Reporting

		Command DumpBookmark "dump"
			Brief "List bookmark entries"
			Option JSON "json" Flag
				Brief "Report results as JSON structure."
			Include CatalogAccount
			Include PortalAccount
			Include Reporting


	CommandSet Calendar "calendar"
		Brief "Manage calendar catalogs connected to an account"

		Command AddCalendar"add"
			Brief "Add calendar entry from file"
			Parameter File "file" ExistingFile
			Include CatalogAccount
			Include PortalAccount
			Include Reporting

		Command DeleteCalendar "delete"
			Brief "Delete calendar entry"
			Parameter Identifier "id" String
				Brief "Contact entry identifier"
			Include CatalogAccount
			Include PortalAccount
			Include Reporting

		Command DumpCalendar "dump"
			Brief "List calendar entries"
			Option JSON "json" Flag
				Brief "Report results as JSON structure."
			Include CatalogAccount
			Include PortalAccount
			Include Reporting

