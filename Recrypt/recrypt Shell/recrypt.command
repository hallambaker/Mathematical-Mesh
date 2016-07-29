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


	// For debugging
	Command Reset "reset"
		Brief "Delete all test profiles"
		
