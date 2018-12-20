Class Goedel.Mesh.Shell Shell
	Library
	Return		"ShellResult"

	Type NewFile			"file"
	Type ExistingFile		"file"

	About		"about"
	Brief		"brief"

	OptionSet Reporting
		Option Verbose "verbose" Flag
			Default "true"
			Brief "Verbose reports (default)"
		Option Report "report" Flag
			Default "true"
			Brief "Report output (default)"
		Option Json "json" Flag
			Default "false"
			Brief "Report output in JSON format"

	OptionSet AccountOptions
		Option AccountID "portal" String
			Brief "Account identifier (e.g. alice@example.com)"
		Option UDF "udf" String
			Brief "Profile fingerprint"

	OptionSet DeviceProfileInfo
		Option DeviceNew "new" Flag
			Brief "Force creation of new device profile"
		Option DeviceUDF "dudf" String
			Brief "Device profile fingerprint"
		Option DeviceID "did" String
			Brief "Device identifier"
		Option DeviceDescription "dd" String
			Brief "Device description"

	OptionSet MailOptions
		Option OpenPGP "openpgp" Flag
			Default "true"
			Brief "Create encryption and signature keys for OpenPGP"
		Option SMIME"smime" Flag
			Default "true"
			Brief "Create encryption and signature keys for S/MIME"
		Option Configuration "configuration" ExistingFile
			Brief "Configuration file describing network settings"
		Option CA "ca" String
			Brief "Certificate Authority to request certificate from"
		Option Inbound "inbound" String
			Brief "inbound service configuration"
		Option Outbound "outbound" String
			Brief "outbound service configuration"

	OptionSet PublicKeyOptions
		Option Format "format" String"
			Brief "File format"
		Option File "file" NewFile
			Brief "Output file"

	OptionSet PrivateKeyOptions
		Option Format "format" String
			Brief "File format"
		Option Password "password" String
			Brief "Password to encrypt private key"
		Option File "file" NewFile
			Brief "Output file"


	OptionSet KeyCreateOptions
		Option AlgKey "alg" String
			Brief "The public key algorithm"
		Option LengthKey "size" String
			Brief "The public key size"

	OptionSet EncodeOptions

		Option Encrypt "encrypt" String
			Brief "Encrypt data for specified recipient"
		Option Sign "sign" String
			Brief "Sign data with specified key"
		
		Option AlgDigest "adigest" String
			Brief "The digest algorithm"
		Option AlgEncrypt "aencrypt" String
			Brief "The symmetric encryption algorithm"
		
		Option ModeEncrypt "mencrypt" String
			Brief "The public key encryption mode"
		Option ModeSign "msign" String
			Brief "The signature mode"

	OptionSet DigestOptions
		Option AlgDigest "adigest" String
			Brief "The digest algorithm"
		Option DigestKey "key" String
			Brief "Encrypt data for specified recipient"

	CommandSet Profile "profile"
		Brief "Manage personal and device profiles and accounts."

		// For debugging
		Command ProfileReset "reset"
			Brief "Delete all test profiles"
			Include Reporting

		Command DeviceCreate "device"
			Brief "Create new device profile"
			Parameter DeviceID "id" String
				Brief "Device identifier"
			Parameter DeviceDescription "dd" String
				Brief "Device description"
			Option Default "default" Flag
				Brief "Make the new device profile the default"

		Command PersonalCreate "personal"
			Brief "Create new personal profile"
			Parameter NewAccountID "new" String
				Brief "New account"
			Include Reporting
			Include DeviceProfileInfo

		Command ProfileRegister "register"
			Brief "Register existing profile at a new portal"
			Parameter NewAccountID "account" String
				Brief "New account"
			Include Reporting
			Include AccountOptions

		Command ProfileSync "sync"
			Brief "Synchronize local copies of Mesh profiles with the server"
			Include AccountOptions
			Include Reporting

		Command ProfileEscrow "escrow"
			Brief "Create a set of key escrow shares"
			Include AccountOptions
			Include Reporting
			Option Quorum "quorum" Integer
			Option Shares "shares" Integer

		Command ProfileRecover "recover"
			Brief "Recover escrowed profile"
			Include AccountOptions
			Include Reporting
			Parameter Share1 "s1" String
			Parameter Share2 "s2" String
			Parameter Share3 "s3" String
			Parameter Share4 "s4" String
			Parameter Share5 "s5" String
			Parameter Share6 "s6" String
			Parameter Share7 "s7" String
			Parameter Share8 "s8" String
			Option File "file" ExistingFile

		Command ProfileExport "export"
			Brief "Export the specified profile data to the specified file"
			Parameter File "file" NewFile
			Include AccountOptions
			Include Reporting

		Command ProfileImport "import"
			Brief "Import the specified profile data to the specified file"
			Parameter File "file" NewFile
			Include AccountOptions
			Include Reporting

		// Describe configuration
		Command ProfileList "list"
			Brief "List all profiles on the local machine"
			Include Reporting

		Command ProfileDump "dump"
			Brief "Describe the specified profile"
			Include AccountOptions
			Include Reporting

		// Connection related
		Command ProfilePending "pending"
			Brief "Get list of pending connection requests"
			Include AccountOptions
			Include Reporting
			
		Command ProfileConnect "connect"
			Brief "Connect to an existing profile registered at a portal"
			Parameter Portal "portal" String
				Brief "New portal account"
			Option PIN "pin" String
				Brief "One time use authenticator"
			Include Reporting
			Include DeviceProfileInfo

		Command ProfileAccept "accept"
			Brief "Accept a pending connection"
			Parameter CompletionCode "code" String
				Brief "Fingerprint of connection to accept"
			Include AccountOptions
			Include Reporting

		Command ProfileReject "reject"
			Brief "Reject a pending connection"
			Parameter CompletionCode "code" String
				Brief "Fingerprint of connection to reject"
			Include AccountOptions
			Include Reporting

		Command ProfileGetPIN "pin"
			Brief "Accept a pending connection"
			Option Length "length" Integer
				Brief "Length of PIN to generate (default is 8 characters)"
				Default "8"
			Include AccountOptions
			Include Reporting

		Command ProfileComplete "complete"
			Brief "Complete a pending connection request"
			Include AccountOptions
			Include Reporting


	// Mail
	CommandSet Mail "mail"
		Brief "Manage mail profiles connected to a personal profile"

		Command MailAdd "add"
			Brief "Add a mail application profile to a personal profile"
			Parameter Address "address" String
				Brief "Mail account to create profile from"
			Include AccountOptions
			Include Reporting
			Include MailOptions
			Include KeyCreateOptions

		Command MailUpdate "update"
			Brief "Update an existing mail application profile"
			Parameter Address "address" String
				Brief "Mail account to update"
			Include AccountOptions
			Include Reporting

		CommandSet SMIME "smime"
			Command SMIMEPrivate "private"
				Brief "Extract the private key for the specified account"
				Include AccountOptions
				Include Reporting
				Include PrivateKeyOptions
				Parameter Address "address" String
					Brief "Mail account to update"

			Command SMIMEPublic "public"
				Brief "Extract the public key/certificate for the specified account"
				Include AccountOptions
				Include Reporting
				Include PublicKeyOptions
				Parameter Address "address" String
					Brief "Mail account identifier"

		CommandSet PGP "openpgp"
			Command PGPPrivate "private"
				Brief "Extract the private key for the specified account"
				Include AccountOptions
				Include Reporting
				Include PrivateKeyOptions
				Parameter Address "address" String
					Brief "Mail account to update"

			Command PGPPublic "public"
				Brief "Extract the public key/certificate for the specified account"
				Include AccountOptions
				Include Reporting
				Include PublicKeyOptions
				Parameter Address "address" String
					Brief "Mail account identifier"

	OptionSet SSHOptions
		Option Application "application" String
			Brief "The application format"

	// SSH
	CommandSet SSH "ssh"
		Brief "Manage SSH profiles connected to a personal profile"

		CommandSet SSHAdd "add"
			Command SSHAddHost "host"
				Brief "Add one or more hosts to the known_hosts file"
				Include AccountOptions
				Include Reporting
				Include SSHOptions
				Parameter File "file" ExistingFile
			
			Command SSHAddClient "client"
				Brief "Add one or more keys to the authorized_keys file"
				Include AccountOptions
				Include Reporting
				Include SSHOptions
				Parameter File "file" ExistingFile

		Command SSHHost "host"
			Brief "Add the SSH server key(s) of the current machine to the personal profile"
			Include AccountOptions
			Include Reporting
			Include SSHOptions

		Command SSHCreate "create"
			Brief "Generate a new SSH public keypair for the current machine and add to the personal profile"
			Include AccountOptions
			Include Reporting
			Include SSHOptions
			Include KeyCreateOptions
			Option ID "id" String
				Brief "Key identifier"

		Command SSHKnown "known"
			Brief "List the known SSH sites (aka known hosts)"
			Include AccountOptions
			Include Reporting
			Include SSHOptions

		Command SSHAuth "auth"
			Brief "List the authorized device keys (aka authorized_keys)"
			Include AccountOptions
			Include Reporting	
			Include SSHOptions

		Command SSHPrivate "private"
			Brief "Extract the private key for this device"
			Include AccountOptions
			Include Reporting
			Include PrivateKeyOptions

		Command SSHPublic "public"
			Brief "Extract the public key for this device"
			Include AccountOptions
			Include Reporting
			Include PublicKeyOptions

	CommandSet Password "password"
		Brief "Manage password catalogs connected to an account"

		Command PasswordAdd "add"
			Brief "Add password entry"
			Parameter Site "site" String
			Parameter Username "user" String
			Parameter Password "password" String
			Include AccountOptions
			Include Reporting

		Command PasswordGet "user"
			Brief "Lookup password entry"
			Parameter Site "site" String
			Include AccountOptions
			Include Reporting

		Command PasswordDelete "delete"
			Brief "Delete password entry"
			Parameter Site "site" String
				Brief "Domain name of Web site"
			Include AccountOptions
			Include Reporting

		Command PasswordDump "dump"
			Brief "List password entries"
			Parameter Site "site" String
			Include AccountOptions
			Include Reporting

	CommandSet Contact "contact"
		Brief "Manage contact catalogs connected to an account"

		Command ContactAdd "add"
			Brief "Add contact entry from file"
			Parameter File "file" ExistingFile
			Include AccountOptions
			Include Reporting

		Command ContactDelete "delete"
			Brief "Delete contact entry"
			Parameter Identifier "id" String
				Brief "Contact entry identifier"
			Include AccountOptions
			Include Reporting

		Command ContactdGet "get"
			Brief "Lookup contact entry"
			Parameter Identifier "site" String
			Include AccountOptions
			Include Reporting

		Command ContactDump "dump"
			Brief "List contact entries"
			Include AccountOptions
			Include Reporting

	CommandSet Bookmark "bookmark"
		Brief "Manage bookmark catalogs connected to an account"

		Command BookmarkAdd "add"
			Brief "Add bookmark"
			Parameter Uri "uri" String
			Parameter Title "title" String
			Option Path "path" String
			Include AccountOptions
			Include Reporting

		Command BookmarkDelete "delete"
			Brief "Delete bookmark entry"
			Parameter Uri "uri" String
				Brief "Contact entry identifier"
			Option Path "path" String
			Include AccountOptions
			Include Reporting

		Command BookmarkDump "dump"
			Brief "List bookmark entries"
			Include AccountOptions
			Include Reporting


	CommandSet Calendar "calendar"
		Brief "Manage calendar catalogs connected to an account"

		Command CalendarAdd "add"
			Brief "Add calendar entry from file"
			Parameter File "file" ExistingFile
			Include AccountOptions
			Include Reporting

		Command CalendarDelete "delete"
			Brief "Delete calendar entry"
			Parameter Identifier "id" String
				Brief "Contact entry identifier"
			Include AccountOptions
			Include Reporting

		Command CalendarDump "dump"
			Brief "List calendar entries"
			Include AccountOptions
			Include Reporting

	CommandSet Network "network"
		Brief "Manage network profile settings"

		Command NetworkAdd "add"
			Brief "Add calendar entry from file"
			Parameter File "file" ExistingFile
			Include AccountOptions
			Include Reporting

		Command NetworkDelete "delete"
			Brief "Delete calendar entry"
			Parameter Identifier "id" String
				Brief "Network entry identifier"
			Include AccountOptions
			Include Reporting

		Command NetworkDump "dump"
			Brief "List network entries"
			Include AccountOptions
			Include Reporting


	CommandSet Message "message"
		Brief "Confirmation message options"

		Command MessageConnect "Connect"
			Brief "Post a conection request to a user"
			Parameter Recipient "recipient" String
				Brief "The recipient to send the conection request to"
			Include AccountOptions
			Include Reporting

		Command MessageConfirm "Confirm"
			Brief "Post a confirmation request to a user"
			Parameter Recipient "recipient" String
				Brief "The recipient to send the confirmation request to"
			Include AccountOptions
			Include Reporting

		Command MessageStatus "Status"
			Brief "Request status of pending requests"
			Option RequestID "requestid" String
				Brief "Specifies the request to provide the status of"
			Include AccountOptions
			Include Reporting

		Command MessagePending "Pending"
			Brief "List pending requests"
			Include AccountOptions
			Include Reporting

		Command MessageAccept "Accept"
			Brief "Accept a pending request"
			Option RequestID "requestid" String
				Brief "Specifies the request to accept"
			Include AccountOptions
			Include Reporting

		Command MessageReject "Reject"
			Brief "Reject a pending request"
			Option RequestID "requestid" String
				Brief "Specifies the request to reject"
			Include AccountOptions
			Include Reporting

		Command MessageBlock "Block"
			Brief "Reject a pending request and block requests from that source"
			Option RequestID "requestid" String
				Brief "Specifies the request to reject and block"
			Include AccountOptions
			Include Reporting

	CommandSet Group "group"
		Brief "Group management commands"

		Command GroupAdd "add"
			Brief "Add recryption group to keyring"
			Include AccountOptions
			Include Reporting
			Parameter GroupID "group" String
				Brief "Recryption group name in user@example.com format"

		Command GroupCreate "create"
			Brief "Create recryption group"
			Include AccountOptions
			Include Reporting
			Include KeyCreateOptions
			Parameter GroupID "group" String
				Brief "Recryption group name in user@example.com format"

		Command GroupUser "user"
			Brief "Add user to recryption group"
			Include AccountOptions
			Include Reporting
			Parameter GroupID "group" String
				Brief "Recryption group name in user@example.com format"
			Parameter MemberID "member" String
				Brief "User to add"

		Command GroupDelete "delete"
			Brief "Remove user from recryption group"
			Include AccountOptions
			Include Reporting
			Parameter GroupID "group" String
				Brief "Recryption group name in user@example.com format"			
			Parameter MemberID "member" String
				Brief "User to delete"



	CommandSet File "File"
		Brief "DARE Message encryption and decryption commands"

		Command FileEncrypt "encrypt"
			Brief "Encode file as DARE Message."
			Parameter Input "in" ExistingFile
				Brief "File or directory to encrypt"
			Include EncodeOptions
			Include AccountOptions
			Include Reporting
			Option Output "out" NewFile
				Brief "Filename for encrypted output."
			Option Subdirectories "sub" Flag
				Brief "Process subdirectories recursively."
		
		Command FileDecrypt "decrypt"
			Brief "Decrypt a DARE Message."
			Include AccountOptions
			Include Reporting
			Parameter Input "in" ExistingFile
				Brief "Encrypted File"
			Parameter Output "out" NewFile
				Brief "Decrypted File"


		Command FileRandom "random"
			Brief "Return a randomized string"			
			Include Reporting
			Include DigestOptions

		Command FileDigest "digest"
			Brief "Calculate the digest value of the input data"
			Include Reporting
			Option AlgDigest "adigest" String
				Brief "The digest algorithm"
			Parameter Input "in" ExistingFile
				Brief "File to take digest of"

		Command FileCommitment "commit"
			Brief "Calculate a commitment value for the input data"
			Include Reporting
			Option AlgDigest "adigest" String
				Brief "The digest algorithm"
			Option DigestKey "key" String
			Parameter Input "in" ExistingFile
				Brief "File to create commitment of"


	OptionSet ContainerOptions
		Option Type "type" String
			Brief "The container type, plain/tree/digest/chain/tree"

	CommandSet Container "container"
		Brief "DARE container commands"

		Command ContainerCreate "create"
			Brief "Create a new DARE Container"
			Include EncodeOptions
			Include ContainerOptions
			Include AccountOptions
			Include Reporting
			Parameter Output "out" NewFile
				Brief "New container"			

		Command ContainerArchive "archive"
			Brief "Create a new DARE Container and archive the specified files"
			Include EncodeOptions
			Include AccountOptions
			Include Reporting
			Include ContainerOptions
			Parameter Input "in" ExistingFile
				Brief "Directory containing files to create archive from"
			Parameter Output "out" NewFile
				Brief "New container"	

		Command ContainerAppend "append"
			Brief "Append the specified file as an entry to the specified container"
			Include EncodeOptions
			Include AccountOptions
			Include Reporting
			Parameter Input "in" ExistingFile
				Brief "Container to append to"
			Parameter Output "file" NewFile
				Brief "File to append"

		Command ContainerExtract "extract"
			Brief "Extract the specified record from the container"
			Parameter Input "in" ExistingFile
				Brief "Container to read"

			Parameter Output "out" NewFile
				Brief "Extracted file"	
			Option Record "record" Integer
				Brief "Index number of file to extract"
				Default "-1"
			Option Filename "file" String
				Brief "Name of file to extract"
			Include AccountOptions
			Include Reporting

		Command ContainerCopy "copy"
			Brief "Copy container contents to create a new container"
			Parameter Input "in" ExistingFile
				Brief "Container to read"
			Parameter Output "out" NewFile
				Brief "Copy"
			Include EncodeOptions
			Include ContainerOptions
			Include AccountOptions
			Include Reporting
			Option Decrypt "decrypt" Flag
				Default "false"
				Brief "Decrypt contents"
			Option Index "index" Flag
				Default "true"
				Brief "Append an index record to the end"
			Option Purge "purge" Flag
				Default "true"
				Brief "Purge unused data etc."

		Command ContainerVerify "verify"
			Brief "Verify signatures and digests on container."
			Include AccountOptions
			Include Reporting
			Parameter Input "in" ExistingFile
				Brief "Container to read"