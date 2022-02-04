Class Goedel.Mesh.Shell.ServiceAdmin Shell
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

	Command Create "create"
		Include Reporting
		Brief "Initialize a new Mesh service and administration account"

		Parameter ServiceDns "dns" String
			Brief "The DNS address of the service"	
		Option HostConfig "hostconfig" String
			Brief "The host configuration name (defaults to mmmsettings.json)"
		Option HostIp "ip" String
			Brief "The external IP address of the host."
		Option HostDns "host" String
			Brief "The DNS address of the host for service configuration"
		Option Admin "admin" String
			Brief "The administrator account address, also default for the host domain."
		Option MultiConfig "config" ExistingFile
			Brief "The configuration file, is created if necessary"
			Default "HostsAndServices"
		Option Account "account" String
			Brief "The account under which the service is to run (defaults to account executing command)."

	Command DNS "dns"
		Include Reporting
		Brief "Compute the DNS configuration from the service config."
		Parameter DnsConfig "dnsconfig" NewFile
			Brief "The file to write the DNS configuration to"

		Parameter HostConfig "hostconfig" String
			Brief "The host configuration name"

		Option MultiConfig "config" ExistingFile
			Brief "The configuration file, is created if necessary"
			Default "HostsAndServices"

	Command Netsh "netsh"
		Include Reporting
		Brief "Compute the netsh configuration from the service config."
		Parameter DnsConfig "dnsconfig" NewFile
			Brief "The file to write the netsh configuration to"

		Parameter HostConfig "hostconfig" String
			Brief "The host configuration name"

		Option MultiConfig "config" ExistingFile
			Brief "The configuration file, is created if necessary"
			Default "HostsAndServices"
