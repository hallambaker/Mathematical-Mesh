Class Goedel.Command Shell
	Library
	Brief "This is a test piece"
	About "about"

	Type NewFile			"file"
	Type ExistingFile		"file"

	Command One "one"
		Parameter P1 "p1" String
		Parameter P2 "p2" Integer
		Option O1 "o1" Flag


	Command Two "two"
		Parameter P1 "p1" String
			Default "DefaultValue"
		Parameter P2 "p2" Integer
			Default "42"
		Option O1 "o1" Flag
			Default "true"

	Command Three "three"

	CommandSet Sub "sub"
		// DefaultCommand
		Command Four "four"
			Parser Goedel.Command TestParser ".test"
			Script Goedel.Command TestScript Test ".testout"
		Command Five "five"

		CommandSet Sub2 "sub2"
			// DefaultCommand
			Command Six "six"
			Command Seven "seven"