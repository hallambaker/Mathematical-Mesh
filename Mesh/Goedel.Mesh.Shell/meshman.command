Class Goedel.Mesh.Shell Shell
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

	OptionSet AccountOptions
		Option Mesh "mesh" String
			Brief "Account identifier (e.g. alice@example.com) or profile fingerprint"

	OptionSet DeviceProfileInfo
		Option DeviceNew "new" Flag
			Brief "Force creation of new device profile"
			Default "false"
		Option DeviceUDF "dudf" String
			Brief "Device profile fingerprint"
		Option DeviceID "did" String
			Brief "Device identifier"
		Option DeviceDescription "dd" String
			Brief "Device description"


	OptionSet MasterProfileInfo
		Option MasterUDF "mudf" String
			Brief "Master profile fingerprint"

	OptionSet DeviceAuthOptions
		Option Auth "auth" String
			Brief "Authorize the specified function"
		Option AuthAdmin "admin" Flag
			Brief "Authorize device as administration device"
			Default "false"
		Option AuthAll "all" Flag
			Brief "Authorize device for all application catalogs"
			Default "false"
		Option AuthBookmark "bookmark" Flag
			Brief "Authorize response to confirmation requests"
			Default "false"
		Option AuthCalendar "calendar" Flag
			Brief "Authorize access to calendar catalog"
			Default "false"
		Option AuthContacts "contact" Flag
			Brief "Authorize access to contacts catalog"
			Default "false"
		Option AuthConfirm "confirm" Flag
			Brief "Authorize response to confirmation requests"
			Default "false"
		Option AuthMail "mail" Flag
			Brief "Authorize access to configure SMTP mail services."
			Default "false"
		Option AuthNetwork "network" Flag
			Brief "Authorize access to the network catalog"
			Default "false"
		Option AuthPassword "password" Flag
			Brief "Authorize access to the password catalog"
			Default "false"
		Option AuthSSH "ssh" Flag
			Brief "Authorize use of SSH"
			Default "false"







	OptionSet MailOptions
		Option OpenPGP "openpgp" Flag
			Brief "Create encryption and signature keys for OpenPGP"
		Option SMIME"smime" Flag
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

	OptionSet LengthOptions
		Option Bits "bits" Integer
			Brief "Secret size in bits"

	OptionSet CryptoOptions
		Option Algorithms "alg" String
			Brief "List of algorithm specifiers"


	OptionSet EncodeOptions
		Option ContentType "cty" String
			Brief "Content Type"
		Option Encrypt "encrypt" String
			Brief "Encrypt data for specified recipient"
		Option Sign "sign" String
			Brief "Sign data with specified key"
		Option Hash "hash" Flag
			Brief "Compute hash of content"		
			Default "true"

	OptionSet DigestOptions
		Option DigestKey "key" String
			Brief "Encrypt data for specified recipient"

	OptionSet ContainerOptions
		Option Type "type" String
			Brief "The container type, plain/tree/digest/chain/tree"
		Enumerate EnumAuthentication "auth"
			Brief "Authentication and indexing"
			Case ePlain "plain"
				Brief "No authentication"
			Case eDigest "digest"
				Brief "Digest authentication"
			Case eChain "chain"
				Brief "Chained digest authentication"
			Case eTree "tree"
				Brief "Tree without authentication"
			Case eMerkel "merkel"
				Brief "Merkel tree authentication"
		Enumerate EnumUse "use"
			Case eLog "log"
				Brief "Log"
			Case eArchive "archive"
				Brief "Archive"
			Case eSpool "spool"
				Brief "Message spool"
			Case eCatalog "catalog"
				Brief "Object catalog"

	CommandSet Profile "profile"

		Brief "Manage personal and device profiles and accounts."

		Command ProfileHello "hello"		
			Brief "Connect to the service(s) a profile is connected to and report status."
			Include AccountOptions

		Command ProfileCreate "create"
			Brief "Create new personal profile"
			Parameter NewAccountID "new" String
				Brief "New account"
			Include Reporting
			Include DeviceProfileInfo
			Include CryptoOptions

		Command ProfileRegister "register"
			Brief "Register existing profile at a new portal"
			Parameter NewAccountID "account" String
				Brief "New account"
			Include Reporting
			Include AccountOptions
			Include MasterProfileInfo
			Include DeviceProfileInfo

		Command ProfileSync "sync"
			Brief "Synchronize local copies of Mesh profiles with the server"
			Include AccountOptions
			Include Reporting

		Command ProfileEscrow "escrow"
			Brief "Create a set of key escrow shares"
			Include CryptoOptions
			Include AccountOptions
			Include Reporting
			Parameter File "file" NewFile
			Option Quorum "quorum" Integer
				Default "2"
			Option Shares "shares" Integer
				Default "3"

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
			Option Verify "verify" Flag


		// Describe configuration
		Command ProfileList "list"
			Brief "List all profiles on the local machine"
			Include Reporting

		Command ProfileGet "get"
			Brief "Describe the specified profile"
			Include AccountOptions
			Include Reporting

		// Export and import of profiles
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
			
	CommandSet Connect "device"
		Brief "Device management commands."

		Command DeviceCreate "create"
			Brief "Create new device profile"
			Include CryptoOptions
			Parameter DeviceID "id" String
				Brief "Device identifier"
			Parameter DeviceDescription "dd" String
				Brief "Device description"
			Option Default "default" Flag
				Brief "Make the new device profile the default"

		Command DeviceAuthorize "auth"
			Brief "Authorize device to use application"
			Parameter DeviceID "id" String
				Brief "Device identifier"
			Include DeviceAuthOptions
			Include AccountOptions
			Include Reporting

		Command DeviceRequestConnect "request"
			Brief "Connect to an existing profile registered at a portal"
			Parameter Portal "account" String
				Brief "New portal account"
			Option PIN "pin" String
				Brief "One time use authenticator"
			Include Reporting
			Include DeviceProfileInfo
			Include DeviceAuthOptions

		Command DevicePreConnect "pre"
			Brief "Create a preconnection request"
			Parameter Portal "account" String
				Brief "New portal account"
			Option Key "key" String
				Brief "Encryption key for use in generating an EARL connector."
			Option Export "export" String
				Brief "Export the device configuration information to the specified file"
			Include Reporting
			Include EncodeOptions
			Include DeviceProfileInfo
			Include DeviceAuthOptions

		Command DevicePending "pending"
			Brief "Get list of pending connection requests"
			Include AccountOptions
			Include Reporting

		Command DeviceAccept "accept"
			Brief "Accept a pending connection"
			Parameter CompletionCode "code" String
				Brief "Fingerprint of connection to accept"
			Parameter DeviceID "id" String
				Brief "Device identifier"
			Include DeviceAuthOptions
			Include AccountOptions
			Include Reporting

		Command DeviceReject "reject"
			Brief "Reject a pending connection"
			Parameter CompletionCode "code" String
				Brief "Fingerprint of connection to reject"
			Include AccountOptions
			Include Reporting

		Command DeviceGetPIN "pin"
			Brief "Accept a pending connection"
			Option Length "length" Integer
				Brief "Length of PIN to generate (default is 8 characters)"
				Default "8"
			Option Expire "expire" String
				Default "1d"
			Include AccountOptions
			Include Reporting

		Command DeviceInit "init"
			Brief "Create an initialization "
			Parameter Earl "earl" String
				Brief "The EARL locator"
			Include AccountOptions

		Command DeviceEarl "earl"
			Brief "Connect a new device by means of an EARL"
			Parameter Earl "earl" String
				Brief "The EARL locator"
			Parameter DeviceID "id" String
				Brief "Device identifier"
			Include DeviceAuthOptions
			Include AccountOptions

		Command DeviceDelete "delete"
			Brief "Remove device from device catalog"
			Parameter DeviceID "id" String
				Brief "Device identifier"
			Include AccountOptions
			Include Reporting

		Command DeviceList"list"
			Brief "List devices in the device catalog"
			Include AccountOptions
			Include Reporting
			Parameter GroupID "group" String
				Brief "Recryption group name in user@example.com format"

	CommandSet Message "message"
		Brief "Contact and confirmation message options"
		
		Command MessageContact "contact"
			Brief "Post a conection request to a user"
			Parameter Recipient "recipient" String
				Brief "The recipient to send the conection request to"
			Include AccountOptions
			Include Reporting

		Command MessageConfirm "confirm"
			Brief "Post a confirmation request to a user"
			Parameter Recipient "recipient" String
				Brief "The recipient to send the confirmation request to"
			Parameter Text "text" String
				Brief "The recipient to send the confirmation request to"
			Include AccountOptions
			Include Reporting

		Command MessagePending "pending"
			Brief "List pending requests"
			Include AccountOptions
			Include Reporting

		Command MessageStatus "status"
			Brief "Request status of pending requests"
			Option RequestID "requestid" String
				Brief "Specifies the request to provide the status of"
			Include AccountOptions
			Include Reporting

		Command MessageAccept "accept"
			Brief "Accept a pending request"
			Option RequestID "requestid" String
				Brief "Specifies the request to accept"
			Include AccountOptions
			Include Reporting

		Command MessageReject "reject"
			Brief "Reject a pending request"
			Option RequestID "requestid" String
				Brief "Specifies the request to reject"
			Include AccountOptions
			Include Reporting

		Command MessageBlock "block"
			Brief "Reject a pending request and block requests from that source"
			Option RequestID "requestid" String
				Brief "Specifies the request to reject and block"
			Include AccountOptions
			Include Reporting

	CommandSet Group "group"
		Brief "Group management commands"

		Command GroupCreate "create"
			Brief "Create recryption group"
			Include AccountOptions
			Include Reporting
			Include CryptoOptions
			Parameter GroupID "group" String
				Brief "Recryption group name in user@example.com format"

		Command GroupAdd "add"
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

		Command GroupList "list"
			Brief "List members of a recryption group"
			Include AccountOptions
			Include Reporting
			Parameter GroupID "group" String
				Brief "Recryption group name in user@example.com format"

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
			Include CryptoOptions

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

		Command MailList "list"
			Brief "List mail account information"
			Include AccountOptions
			Include Reporting
			Parameter Address "address" String
				Brief "Mail account identifier"

	OptionSet SSHOptions
		Option Application "application" String
			Brief "The application format"

	// SSH
	CommandSet SSH "ssh"
		Brief "Manage SSH profiles connected to a personal profile"


		// Management of client key pairs
		Command SSHCreate "create"
			Brief "Generate a new SSH public keypair for the current machine and add to the personal profile"
			Include AccountOptions
			Include Reporting
			Include SSHOptions
			Include CryptoOptions
			Option ID "id" String
				Brief "Key identifier"

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
		
		CommandSet SSHMerge "merge"
			Command SSHMergeKnown "host"
				Brief "Add one or more hosts to the known_hosts file"
				Include AccountOptions
				Include Reporting
				Include SSHOptions
				Parameter File "file" ExistingFile
			
			Command SSHMergeClient "client"
				Brief "Add one or more hosts to the known_hosts file"

		// Add public keys to profile
		CommandSet SSHAdd "add"
			Command SSHAddHost "host"
				Brief "Add one or more hosts to the known_hosts file"
				Include AccountOptions
				Include Reporting
				Include SSHOptions


			
			Command SSHAddClient "client"
				Brief "Add one or more keys to the authorized_keys file"
				Include AccountOptions
				Include Reporting
				Include SSHOptions
				Parameter File "file" ExistingFile


		CommandSet SSHShow "show"
			Command SSHKnown "host"
				Brief "List the known SSH sites (aka known hosts)"
				Include AccountOptions
				Include Reporting
				Include SSHOptions

			Command SSHAuth "client"
				Brief "List the authorized device keys (aka authorized_keys)"
				Include AccountOptions
				Include Reporting	
				Include SSHOptions



	CommandSet Password "password"
		Brief "Manage password catalogs connected to an account"

		Command PasswordAdd "add"
			Brief "Add password entry"
			Parameter Site "site" String
			Parameter Username "user" String
			Parameter Password "password" String
			Include AccountOptions
			Include Reporting

		Command PasswordGet "get"
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

		Command PasswordDump "list"
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

		Command ContactGet "get"
			Brief "Lookup contact entry"
			Parameter Identifier "id" String
				Brief "Contact entry identifier"
			Include AccountOptions
			Include Reporting
			Option Encrypt "encrypt" String
				Brief "Encrypt the contact under the specified key"

		Command ContactDump "list"
			Brief "List contact entries"
			Include AccountOptions
			Include Reporting

	CommandSet Bookmark "bookmark"
		Brief "Manage bookmark catalogs connected to an account"

		Command BookmarkAdd "add"
			Brief "Add bookmark"
			Parameter Path "path" String
			Parameter Uri "uri" String
			Parameter Title "title" String
			Include AccountOptions
			Include Reporting

		Command BookmarkDelete "delete"
			Brief "Delete bookmark entry"
			Parameter Uri "uri" String
				Brief "Contact entry identifier"
			Option Path "path" String
			Include AccountOptions
			Include Reporting

		Command BookmarkGet "get"
			Brief "Lookup bookmark entry"
			Parameter Identifier "site" String
			Include AccountOptions
			Include Reporting

		Command BookmarkDump "list"
			Brief "List bookmark entries"
			Include AccountOptions
			Include Reporting


	CommandSet Calendar "calendar"
		Brief "Manage calendar catalogs connected to an account"

		Command CalendarAdd "add"
			Brief "Add calendar entry from file"
			Parameter File "in" ExistingFile
			Parameter Identifier "id" String
			Include AccountOptions
			Include Reporting

		Command CalendarGet "get"
			Brief "Lookup calendar entry"
			Parameter Identifier "id" String
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
			Parameter File "in" ExistingFile
			Parameter Identifier "id" String
			Include AccountOptions
			Include Reporting

		Command NetworkGet "get"
			Brief "Lookup calendar entry"
			Parameter Identifier "id" String
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




	CommandSet Key "key"
		Brief "Key operations."

		Command KeyNonce "nonce"
			Brief "Return a randomized nonce value formatted as a UDF Nonce Type"			
			Return ResultKey
			Include Reporting
			Include LengthOptions
			

		Command KeySecret "secret"
			Brief "Return a randomized secret value formatted as a UDF Encryption Key Type."			
			Return ResultKey
			Include Reporting
			Include LengthOptions

		Command KeyEarl "earl"
			Brief "Return a randomized secret value and locator as UDFs"			
			Return ResultKey
			Include Reporting
			Include DigestOptions
			Include LengthOptions

		Command KeyShare "share"
			Brief "Split a secret value according to the specified shares and quorum"			
			Return ResultKey
			Include Reporting
			Include DigestOptions
			Include LengthOptions
			Parameter Secret "secret" String
				Brief "The parameter to share"
			Option Quorum "quorum" Integer
				Default "2"
				Brief "The number of shares required to recover the secret"	
			Option Shares "shares" Integer
				Default "3"
				Brief "The number of shares to create"	

		Command KeyRecover "recover"
			Brief "Recover a secret value from the shares provided"			
			Return ResultKey
			Include Reporting
			Parameter Share1 "s1" String
				Brief "Share value #1"
			Parameter Share2 "s2" String
				Brief "Share value #2"
			Parameter Share3 "s3" String
				Brief "Share value #3"
			Parameter Share4 "s4" String
				Brief "Share value #4"
			Parameter Share5 "s5" String
				Brief "Share value #5"
			Parameter Share6 "s6" String
				Brief "Share value #6"
			Parameter Share7 "s7" String
				Brief "Share value #7"
			Parameter Share8 "s8" String
				Brief "Share value #8"

	CommandSet Hash "hash"
		Brief "Content Digest and Message Authentication Code operations on files"
		Command HashUDF "udf"
			Brief "Calculate the Uniform Data Fingerprint of the input data"
			Return ResultDigest
			Include Reporting
			Include CryptoOptions
			Include LengthOptions
			Option ContentType "cty" String
				Brief "Content Type"
			Option Expect "expect" String
				Brief "Expected value"			
			Parameter Input "in" ExistingFile
				Brief "File to take digest of"

		Command HashDigest "digest"
			Brief "Calculate the digest value of the input data"
			Return ResultDigest
			Include Reporting
			Include CryptoOptions
			Parameter Input "in" ExistingFile
				Brief "File to take digest of"

		Command HashMac "mac"
			Brief "Calculate a commitment value for the input data"
			Return ResultDigest
			Include Reporting
			Include CryptoOptions
			Include LengthOptions
			Option ContentType "cty" String
				Brief "Content Type"

			Option DigestKey "key" String
				Brief "Specifies the value of the key"	
			Option Expect "expect" String
				Brief "Expected value"		
			Parameter Input "in" ExistingFile
				Brief "File to create commitment of"


	CommandSet Dare "dare"
		Brief "DARE Message encryption and decryption commands"
		Command DareEncode "encode"
			Brief "Encode data as DARE Message."
			Return ResultFile
			Parameter Input "in" ExistingFile
				Brief "File or directory to encrypt"
			Include EncodeOptions
			Include CryptoOptions
			Include AccountOptions
			Include Reporting
			Option Output "out" NewFile
				Brief "Filename for encrypted output."
			Option Subdirectories "sub" Flag
				Brief "Process subdirectories recursively."
			Option SymmetrictKey "key" String
				Brief "Specifies the value of the master key"	
				
		Command DareDecode "decode"
			Brief "Decode a DARE Message."
			Return ResultFile
			Include AccountOptions
			Include Reporting
			Parameter Input "in" ExistingFile
				Brief "Encrypted File"
			Parameter Output "out" NewFile
				Brief "Decrypted File"
			Option SymmetrictKey "key" String
				Brief "Specifies the value of the master key"	

		Command DareVerify "verify"
			Brief "Verify a DARE Message."
			Return ResultFile
			Include AccountOptions
			Include Reporting
			Parameter Input "in" ExistingFile
				Brief "Encrypted File"
			Option SymmetrictKey "key" String
				Brief "Specifies the value of the master key"	

		Command DareEARL "earl"
			Brief "Create an Encrypted Authenticated Resource Locator (EARL)"
			Return ResultFile
			Parameter Input "in" ExistingFile
				Brief "File or directory to encrypt"
			Option Output "out" ExistingFile
				Brief "Directory to write encrypted output."
			Option Log "log" ExistingFile
				Brief "Write transaction report to DARE Container Log."
			Option New "new" ExistingFile
				Brief "Only convert file if not listed in DARE Container Log."
			Option Subdirectories "sub" Flag
				Brief "Process subdirectories recursively."
			Include CryptoOptions
			Include AccountOptions
			Include Reporting




	CommandSet Container "container"
		Brief "DARE container commands"

		Command ContainerCreate "create"
			Brief "Create a new DARE Container"
			Include EncodeOptions
			Include CryptoOptions
			Include ContainerOptions
			Include AccountOptions
			Include Reporting
			Parameter Container "out" NewFile
				Brief "New container"			

		Command ContainerArchive "archive"
			Brief "Create a new DARE Container and archive the specified files"
			Include EncodeOptions
			Include CryptoOptions
			Include AccountOptions
			Include Reporting
			Include ContainerOptions
			Parameter Input "in" ExistingFile
				Brief "Directory containing files to create archive from"
			Option Container "out" NewFile
				Brief "New container"	

		Command ContainerAppend "append"
			Brief "Append the specified file as an entry to the specified container"
			Include EncodeOptions
			Include CryptoOptions
			Include AccountOptions
			Include Reporting
			Parameter Container "in" ExistingFile
				Brief "Container to append to"
			Parameter File "file" NewFile
				Brief "File to append"
			Option Key "key" String

		Command ContainerDelete "delete"
			Parameter Container "in" ExistingFile
				Brief "Container to append to"
			Option Filename "file" String
				Brief "Name of file to delete"
			Option Key "key" String

		Command ContainerIndex "index"
			Brief "Compile an index for the specified container and append to the end."
			Include EncodeOptions
			Include CryptoOptions
			Include AccountOptions
			Include Reporting
			Parameter Container "in" ExistingFile
				Brief "Container to append to"

		Command ContainerExtract "extract"
			Brief "Extract the specified record from the container"
			Parameter Container "in" ExistingFile
				Brief "Container to read"

			Parameter Output "out" NewFile
				Brief "Extracted file"	
			Option Record "record" Integer
				Brief "Index number of file to extract"
				Default "-1"
			Option Filename "file" String
				Brief "Name of file to extract"
			Option Key "key" String
			Include AccountOptions
			Include Reporting

		Command ContainerCopy "copy"
			Brief "Copy container contents to create a new container"
			Parameter Input "in" ExistingFile
				Brief "Container to read"
			Parameter Output "out" NewFile
				Brief "Copy"
			Include EncodeOptions
			Include CryptoOptions
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
			Parameter Container "in" ExistingFile
				Brief "Container to read"