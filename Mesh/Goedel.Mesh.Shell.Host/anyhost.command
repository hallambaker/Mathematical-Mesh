Class Goedel.Mesh.Shell.Host Shell
	Library
	Return		ShellResult

	Type NewFile			"file"
	Type ExistingFile		"file"

	Brief		"Mathematical Mesh command tool"
	Help "help"
		Brief		"Command guide."

	OptionSet Reporting
		Option Verbose "verbose" Flag
			Default "false"
			Brief "Verbose reports (default)"
		Option Report "report" Flag
			Default "true"
			Brief "Report output (default)"
		Option Json "json" Flag
			Default "false"
			Brief "Report output in JSON format"

	Command About "about"		
		Brief		"Report version and compilation date."
		Include Reporting
		Option Where "where" Flag
			Brief		"Report location of configuration files."
			Default "false"

	Command HostStart "start"
		Brief "Start the host service"

		Parameter HostConfig "hostconfig" String
			Brief "The host configuration file"
		Option MultiConfig "config" ExistingFile
			Brief "The configuration file, is created if necessary"
			Default "HostsAndServices"

		Option Console "console" Flag
			Default "false"

		Option MachineName "host" String
		Include Reporting

	Command HostVerify "verify"
		Brief "Verify that the host configuration file is correct."
		Parameter HostConfig "hostconfig" String
			Brief "The host configuration file"
		Option ServiceConfig "config" ExistingFile
			Brief "The service configuration file, is created if necessary"
			Default "ServiceConfig"
		Option Console "console" Flag
			Default "false"

		Option MachineName "host" String

