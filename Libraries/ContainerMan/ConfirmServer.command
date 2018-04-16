Class Goedel.Container.Shell ContainerShell
	Brief		"Container management tool"
	About "about"

	Command ListContent "list"
		Brief		"List the container contents"

		Option	Hex "hex" Flag
		Option	Json "json" Flag

		Option	Head "head" Flag
		Option	Tail "tail" Flag


	Command Convert "convert"
		Parameter In "in" ExistingFile
			Brief "The input file"
		Parameter Out "out" NewFile
			Brief "The output file"

		Option Simple	"simple"	Flag
		Option Digest	"digest"	Flag
		Option Chain	"chain"		Flag
		Option Tree		"tree"		Flag
		Option Merkle	"merkle"	Flag

	Command Encrypt "encrypt"
		Parameter In "in" ExistingFile
			Brief "The input file or path"
		Parameter Out "out" NewFile
			Brief "The output file"
		Parameter Key "key" String
			Brief "The encryption key identifier"
		Option Archive	"archive"	Flag
			Brief "Create archive in a single file"

	Command Decrypt "decrypt"

		Parameter In "in" ExistingFile
			Brief "The input container"
		Parameter Out "out" NewFile
			Brief "The output path"