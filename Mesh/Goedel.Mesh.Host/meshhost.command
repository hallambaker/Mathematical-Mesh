Class Goedel.Mesh.Host Shell
	Library
	Return		HostResult

	Type NewFile			"file"
	Type ExistingFile		"file"

	Brief		"Mathematical Mesh command tool"
	Help "help"
		Brief		"Command guide."
	About "about"
		Brief		"Report version and compilation date."

	OptionSet Reporting

		Enumerate EnumReporting "report"
			Brief "Reporting level"
			Case eJson "json"
				Brief "Report output in JSON format"
			Case eVerbose "verbose"
				Brief "Verbose reports"
			Case eReport "report"
				Brief "Report output (default)"
			Case eSilent "silent"
				Brief "Suppress output"

		Option Verbose "verbose" Flag
			Default "true"
			Brief "Verbose reports (default)"
		Option Report "report" Flag
			Default "true"
			Brief "Report output (default)"
		Option Json "json" Flag
			Default "false"
			Brief "Report output in JSON format"



	Command Start "start"
		Include Reporting
		DefaultCommand
		Brief "Start the service or specified host"
		Option Host "host" String
		Option Config "config" ExistingFile

	Command Stop "stop"
		Include Reporting
		Brief "Start the service or specified host"
		Option Host "host" String

	Command Initialize "init"		
		Brief "Initialize the service configuration"
		Include Reporting
		Parameter BaseConfig "config" ExistingFile
		Parameter Config "config" NewFile
		Option Administrator "admin" String
			Brief "Create an initial profile and assign administrator privilege"

	Command Verify "verify"		
		Brief "Verify the service configuration"
		Parameter Config "config" ExistingFile
		Include Reporting

	Command Update "update"		
		Brief "Update the service configuration at every host"
		Parameter Config "config" ExistingFile
		Include Reporting


	CommandSet Account "account"
		Command AccountPin "Pin"
			Brief "Issue PIN to grant account issue"
			Parameter Account "account" String
			Include Reporting

		Command AccountDelete "delete"
			Brief "Delete account"
			Parameter Account "account" String
			Include Reporting

		Command AccountGet "get"
			Brief "Lookup account info"
			Parameter Account "account" String
			Include Reporting

		Command AccountQuota "quota"
			Brief "Set account quota"
			Parameter Account	"account" String
			Option KiloBytes	"kb" Integer
			Option MegaBytes	"mb" Integer
			Option GigaBytes	"gb" Integer
			Option Transactions "trans" Integer
			Option Inbound		"in" Integer
			Option Outbound		"out" Integer
			Option Suspend		"suspend" Flag
			Include Reporting

		Command AccountDump "list"
			Brief "List accounts matching optional pattern"
			Parameter Account "account" String
			Include Reporting