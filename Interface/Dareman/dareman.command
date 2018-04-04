Class Goedel.Mesh.DareMan Shell

	Type NewFile			"file"
	Type ExistingFile		"file"

	About "About"
	Brief		"brief"

	Command Register "register"
		Brief "Register new mesh/recryption account data"
		Parameter AccountID "account" String
			Brief "Mesh portal and account id"

	CommandSet Group "group"
		Brief "Group management commands"

		Command Create "create"
			Brief "Create recryption group"
			Parameter GroupID "group" String
				Brief "Recryption group name in user@example.com format"

		Command Add "add"
			Brief "Add user to recryption group"
			Parameter GroupID "group" String
				Brief "Recryption group name in user@example.com format"
			Parameter AccountID "account" String
				Brief "User to add"

		Command Delete "delete"
			Brief "Remove user from recryption group"
			Parameter GroupID "group" String
				Brief "Recryption group name in user@example.com format"			
			Parameter AccountID "account" String
				Brief "User to delete"


	Command Encrypt "encrypt"
		Brief "Encrypt file to recryption group."
		Parameter Input "in" ExistingFile
			Brief "File to encrypt"
		Parameter Group "group" String
			Brief "Recryption Group identifier"
		Parameter Output "out" NewFile
			Brief "Encrypted File"

	Command Decrypt "decrypt"
		Brief "Decrypt a DARE package."
		Parameter Input "in" ExistingFile
			Brief "Encrypted File"
		Parameter Output "out" NewFile
			Brief "Decrypted File"