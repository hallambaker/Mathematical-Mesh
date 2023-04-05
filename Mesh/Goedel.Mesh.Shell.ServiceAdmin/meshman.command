Class Goedel.Mesh.Shell.ServiceAdmin Shell
	Library
	Return		ShellResult

	Type NewFile			"file"
	Type ExistingFile		"file"

	Brief		"Mathematical Mesh Service Administration tool"
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
		Option Resolver "resolver" String
			Brief "The resolver service"
		Option Registry "registry" String
			Brief "The registry account"
		Option Carnet "carnet" String
			Brief "The carnet service"			
		Option Persist "persist" String
			Brief "The persistence service"		
		Option Presence "presence" String
			Brief "The presence service"	


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
