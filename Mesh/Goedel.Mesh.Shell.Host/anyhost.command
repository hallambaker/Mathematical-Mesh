Class Goedel.Mesh.Shell.Host Shell
	Library
	Return		ShellResult

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

	Command HostStart "start"
		Brief "Start the host service"
		Parameter HostConfig "hostconfig" ExistingFile
			Brief "The host configuration file"
		Option Console "console" Flag
			Default "false"

		Option MachineName "host" String
		Include Reporting

	Command HostVerify "verify"
		Brief "Verify that the host configuration file is correct."
		Parameter HostConfig "hostconfig" ExistingFile
			Brief "The host configuration file"
		Option Console "console" Flag
			Default "false"

		Option MachineName "host" String

