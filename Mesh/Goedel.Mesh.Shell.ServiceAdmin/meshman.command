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
	
		Parameter ServiceConfig "config" ExistingFile
			Brief "The service configuration file, is created if necessary"
		Parameter ServiceDns "dns" String
			Brief "The DNS address of the service"	
		Option HostIp "ip" String
			Brief "The external IP address of the host."
		Option HostDns "host" String
			Brief "The DNS address of the host for service configuration"
		Option Admin "admin" String
			Brief "The administrator account address, also default for the host domain."
		Option NewFile "out" NewFile
			Brief "File to write the configuration to"


	Command Start "start"
		Include Reporting
		Brief "Start the host service"
		Parameter HostDns "dns" String
			Brief "The DNS address of the service"	
		Option All "all" Flag
			Brief "Start all hosts in the service"

	Command Stop "stop"
		Include Reporting
		Brief "Stop the host service."
		Parameter HostDns "dns" String
			Brief "The DNS address of the service"	
		Option All "all" Flag
			Brief "Stop all hosts in the service"

	Command Pause "pause"
		Include Reporting
		Brief "Start the host service in paused mode or pause the service if already started."
		Parameter HostDns "dns" String
			Brief "The DNS address of the service"	
		Option All "all" Flag
			Brief "Pause all hosts in the service"


	Command Fetch "fetch"
		Include Reporting
		Brief "Fetch the host configuration file from the specified service."
		Parameter HostConfig "hostconfig" NewFile
			Brief "The host configuration file"
		Parameter HostDns "dns" String
			Brief "The DNS address of the service"			

	Command Update "update"
		Include Reporting
		Brief "Initialize this machine as a host"
		Parameter HostConfig "hostconfig" ExistingFile
			Brief "The host configuration file"
		Parameter HostDns "dns" String
			Brief "The DNS address of the service"			

	Command Verify "verify"
		Include Reporting
		Brief "Verify that the host configuration file is correct."
		Parameter HostConfig "hostconfig" ExistingFile
			Brief "The host configuration file"

	Command DNS "dns"
		Include Reporting
		Brief "Compute the DNS configuration from the service config."
		Parameter HostConfig "hostconfig" ExistingFile
			Brief "The host configuration file"
		Parameter DnsConfig "dnsconfig" ExistingFile
			Brief "The DNS configuration file"

	Command Credential "credential"
		Include Reporting
		Brief "Issue a credential to the specified host"
		Parameter HostConfig "hostconfig" ExistingFile
			Brief "The host configuration file, is created if necessary"
		Parameter HostName "Host id" ExistingFile
			Brief "The host to add."

