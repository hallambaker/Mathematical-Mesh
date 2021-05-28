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
		DefaultCommand
		Brief "Start the host service"
		Include Reporting


	Command Initialize "init"		
		Brief "Initialize the service configuration"
		Parameter ServiceDomain "domain" String
			Brief "The service DNS domain"	
		Include Reporting


	Command Verify "verify"		
		Brief "Verify the service configuration"
		Include Reporting


	CommandSet Host "host"

	OptionSet LogData
		Option File "file" String
			Brief "Set file log destination"
		Option Remote "remote" String
			Brief "Set remote log destination"		
		Option Error "error" Flag
			Default "true"
			Brief "Error reports"	
		Option Event "event" Flag
			Default "true"
			Brief "Transaction events"
		Option EventData "data" Flag
			Default "false"
			Brief "Transaction data"
		Option Status "status" Flag
			Default "true"
			Brief "Status events"

	CommandSet Log "log"
		Command LogLocal "local"
			Brief "Set the path on which to store logs and the roll policies none/hour/day/week/month)"
			Parameter File "path" String
			Option Operations "ops" String
				Brief "Operations log roll period"
			Option Config "config" String
				Brief "Configuration log roll period"
			Option Error "error" String
				Brief "Error log roll period"
		
		Command LogAdd "add"
			Brief "Add log destination"
			Parameter Id "identifier" String
			Include LogData
			Include Reporting

		Command LogSet "set"
			Brief "Configure log destination"
			Parameter Id "identifier" String
			Include LogData
			Include Reporting

		Command LogDelete "delete"
			Brief "Delete  remote log destination"
			Parameter Id "identifier" String
			Parameter Address "address" String
			Include Reporting

		Command LogGet "get"
			Brief "Lookup remote log destination"
			Parameter Id "identifier" String
			Include Reporting

		Command LogDump "list"
			Brief "List  remote log destination"
			Include Reporting

	CommandSet DNS "dns"
		Command DnsAdd "add"
			Brief "Add dns service address"
			Parameter Domain "domain" String
			Include Reporting

		Command DnsDelete "delete"
			Brief "Delete dns service address"
			Parameter Domain "domain" String
			Include Reporting

		Command DnsGet "get"
			Brief "Lookup dns service address"
			Parameter Domain "domain" String
			Include Reporting

		Command DnsDump "list"
			Brief "List dns service addresses"
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