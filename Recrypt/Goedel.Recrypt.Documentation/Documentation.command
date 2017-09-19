Class Goedel.Recrypt.Documentation Shell

	Type NewFile			"file"
	Type ExistingFile		"file"

	About "About"
	Brief		"Generate example materials for Mesh/Recrypt protocol"

	Command Register "start"
		DefaultCommand
		Brief "Generate example materials"
		Parameter Out "Out" NewFile
			Brief "Output file"
