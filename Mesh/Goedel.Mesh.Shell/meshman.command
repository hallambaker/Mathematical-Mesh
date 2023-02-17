Class Goedel.Mesh.Shell Shell
	Library
	Return		ShellResult

	Type NewFile			"file"
	Type ExistingFile		"file"

	Brief		"Mathematical Mesh command tool"
	Help "help"
		Brief		"Command guide."
	//About "about"
	//	Brief		"Report version and compilation date."

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


	OptionSet LogOptions
		Option Log "log" ExistingFile
			Brief "Write transaction report to DARE Sequence Log."
		Option Admin "admin" String
			Brief "Identifier of administrator authorized to read the log."

	OptionSet AccountOptions
		Option AccountAddress "account" String
			Brief "Account identifier (e.g. alice@example.com) or profile fingerprint"
		Option LocalName "local" String
			Brief "Local name for account (e.g. personal)"
		Option AutoSync "sync" Flag
			Default "true"
			Brief "If true, attempt to synchronize the account to the service before operation"
		Option AutoApprove "auto" Flag
			Brief "If true, automatically approve pending requests with prior authorization."
			Default "true"

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



	OptionSet DeviceAuthOptions
		Option Auth "auth" String
			Brief "(De)Authorize the specified function on the device"
		Option AuthSuper "root" Flag
			Brief "Device as super administration device"
			Default "false"
		Option AuthAdmin "admin" Flag
			Brief "Device as administration device"
			Default "false"

		Option AuthMessage "message" Flag
			Brief "Authorize rights for Mesh messaging"
			Default "false"
		Option AuthWeb "web" Flag
			Brief "Authorize rights for Mesh messaging and Web."
			Default "false"
		Option AuthDevice "device" Flag
			Brief "Device restrictive access"
			Default "false"		
		Option AuthThreshold "threshold" Flag
			Brief "Authorize threshold rights for Mesh messaging and Web."
			Default "false"		
		Option AuthSSH "ssh" String
			Brief "Authorize rights for specified SSH account"
			Default "false"
		Option AuthEmail "email" String
			Brief "Authorize rights for specified smtp email account"
			Default "false"
		Option AuthGroupMember "member" String
			Brief "Authorize member rights for specified Mesh group"
			Default "false"
		Option AuthGroupAdmin "group" String
			Brief "Authorize group administrator rights for specified Mesh group"
			Default "false"

		Option AuthNone "null" Flag
			Brief "Do not authorize any device rights at all (cannot be used with any rights grant))"
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

	OptionSet KeyFileOptions
		Option Format "format" String"
			Brief "File format"
		Option File "file" NewFile
			Brief "Output file"
		Option Password "password" String
			Brief "Password to encrypt private key"
		Option Private "private" Flag
			Default "false"


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
		Option Cover "cover" ExistingFile
			Brief "File containing a cover to be added to encrypted files"

	OptionSet DigestOptions
		Option DigestKey "key" String
			Brief "Encrypt data for specified recipient"

	OptionSet SequenceOptions
		Option Type "type" String
			Brief "The sequence type, plain/tree/digest/chain/tree"
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
	Command About "about"		
		Brief		"Report version and compilation date."
		Include Reporting
		Option Where "where" Flag
			Brief		"Report location of configuration files."
			Default "false"

	CommandSet Account "account"
		Brief "Account creation and management commands."

		Command AccountHello "hello"		
			Brief "Connect to the service(s) a profile is connected to and report status."
			Include AccountOptions
			Parameter Account "account" String
				Brief "Account"	

		Command AccountCreate "create"
			Brief "Create new account profile"
			Parameter NewAccountID "account" String
				Brief "New account"				
			Option Localname "localname" String
				Brief "Account friendly name"
			Option Payment "payment" String
				Brief "Optional payment token"
			Include DeviceProfileInfo
			Include Reporting
			Include CryptoOptions

		Command AccountDelete "delete"
			Brief "Delete an account profile"
			Parameter ProfileUdf "udf" String
				Brief "Fingerprint of the account to be removed from this device"
			Include Reporting

		Command AccountStatus "status"
			Brief "Return the status of the account catalogs and spools"
			Include AccountOptions
			Include Reporting

		Command AccountSync "sync"
			Brief "Synchronize local copies of Mesh profiles with the server"
			Include AccountOptions
			Include Reporting


		Command AccountInfo "Info"
			Brief "Report the public keys of the specified account"
			Include AccountOptions
			Include Reporting
		
		Command AccountGetPIN "pin"
			Brief "Get a pin value to pre-authorize a connection"
			Option Length "length" Integer
				Brief "Length of PIN to generate in characters"
				Default "24"
			Option Expire "expire" String
				Brief "Expiry time in days (1d), hours (1, 1h) or minutes (10m)."
				Default "1"
			Option URI "uri" Flag
				Brief "Return a dynamic connection URI"
			Include AccountOptions
			Include Reporting
			Include DeviceAuthOptions

		Command AccountConnect "connect"
			Brief "Connect by means of a connection uri"
			Parameter Uri "uri" String
				Brief "The device location URI"			
			Include AccountOptions
			Include Reporting
			Include DeviceAuthOptions

		Command AccountEscrow "escrow"
			Return ResultEscrow
			Brief "Create a set of key escrow shares"
			Include CryptoOptions
			Include AccountOptions
			Include Reporting
			Option Quorum "quorum" Integer
				Default "2"
			Option Shares "shares" Integer
				Default "3"

		Command AccountPurge "purge"
			Return ResultMachine
			Brief "Purge the Mesh recovery key from this device"
			Include AccountOptions
			Include Reporting

		Command AccountRecover "recover"
			Return ResultMasterCreate
			Brief "Recover escrowed profile"
			Include AccountOptions
			Include Reporting
			Parameter Share1 "s1" String
				Brief "Recovery share"
			Parameter Share2 "s2" String
				Brief "Recovery share"
			Parameter Share3 "s3" String
				Brief "Recovery share"
			Parameter Share4 "s4" String
				Brief "Recovery share"
			Parameter Share5 "s5" String
				Brief "Recovery share"
			Parameter Share6 "s6" String
				Brief "Recovery share"
			Parameter Share7 "s7" String
				Brief "Recovery share"
			Parameter Share8 "s8" String
				Brief "Recovery share"
			Option File "file" ExistingFile
				Brief "File containing the recovery key blob"
			Option Verify "verify" Flag
				Brief "Check that the shares are valid for recovery without performing recovery."

		// Describe configuration
		Command AccountList "list"
			Return ResultMachine
			Brief "List all profiles on the local machine"
			Include Reporting
			Include AccountOptions

		Command AccountGet "get"
			Return ResultMachine
			Brief "Describe the specified profile"
			Include AccountOptions
			Include Reporting

		// Export and import of profiles
		Command AccountExport "export"
			Parameter File "file" NewFile
				Brief "Name of the file to which the archive is to be written."	
			Return ResultMachine
			Brief "Export the specified profile data to the specified file"
			Include AccountOptions
			Include Reporting

		Command AccountImport "import"
			Return ResultMachine
			Brief "Import the specified profile data to the specified file"
			Parameter File "file" NewFile
				Brief "Name of the file file which the archive is to be read."	
			Include AccountOptions
			Include Reporting



	CommandSet Connect "device"
		Brief "Device management commands."

		Command DeviceRequestConnect "request"
			Brief "Connect to an existing profile registered at a portal"
			Parameter AccountAddress "account" String
				Brief "The Mesh Service Account"
			Option PIN "pin" String
				Brief "One time use authenticator"
			Include Reporting
			Include DeviceProfileInfo
			Include DeviceAuthOptions

		Command DevicePending "pending"
			Brief "Get list of pending connection requests"
			Include AccountOptions
			Include Reporting

		Command DeviceComplete "complete"
			Brief "Complete a pending request"
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

		Command DeviceDelete "delete"
			Brief "Remove device from device catalog"
			Parameter DeviceID "id" String
				Brief "Device identifier"
			Include AccountOptions
			Include Reporting

		Command DeviceList "list"
			Brief "List devices in the device catalog"
			Include AccountOptions
			Include Reporting
			Parameter GroupID "group" String
				Brief "Recryption group name in user@example.com format"
		
		Command DeviceAuthorize "auth"
			Brief "Authorize device to use application"
			Parameter DeviceID "id" String
				Brief "Device identifier"
			Include DeviceAuthOptions
			Include AccountOptions
			Include Reporting

		Command DeviceJoin "join"
			Brief "Connect by means of a connection URI from an administration device."
			Parameter Uri "uri" String
				Brief "The device location URI"			
			
			Include AccountOptions
			Include Reporting

		Command DeviceInstall "install"
			Brief "Connect by means of a connection URI from an administration device."
			Parameter Profile "in" String
				Brief "The device profile"			
			
			Include AccountOptions
			Include Reporting

		Command DevicePreconfigure "preconfig"
			Brief "Generate new device profile and publish as an EARL"
			Include AccountOptions
			Include Reporting
			Option Length "length" Integer
				Brief "Length of PIN to generate in characters"
				Default "24"

	CommandSet Message "message"
		Brief "Contact and confirmation message options"
		


		Command MessageConfirm "confirm"
			Brief "Post a confirmation request to a user"
			Parameter Recipient "recipient" String
				Brief "The recipient to send the confirmation request to"
			Parameter Text "text" String
				Brief "Text of the request message"
			Include AccountOptions
			Include Reporting

		Command MessagePending "pending"
			Brief "List pending requests"
			Include AccountOptions
			Include Reporting
			Option Unread "unread" Flag
				Default "true"
				Brief "Return unread messages"
			Option Read "read" Flag
				Default "false"
				Brief "Return read messages"
			Option Raw "raw" Flag
				Default "false"
				Brief "Return messages in raw form"

		Command MessageStatus "status"
			Brief "Request status of pending request"
			Parameter RequestID "requestid" String
				Brief "Specifies the request to provide the status of"
			Include AccountOptions
			Include Reporting

		Command MessageAccept "accept"
			Brief "Accept a pending request"
			Parameter RequestID "requestid" String
				Brief "Specifies the request to accept"
			Include AccountOptions
			Include Reporting

		Command MessageReject "reject"
			Brief "Reject a pending request"
			Parameter RequestID "requestid" String
				Brief "Specifies the request to reject"
			Include AccountOptions
			Include Reporting

		Command MessageBlock "block"
			Brief "Reject a pending request and block requests from that source"
			Parameter RequestID "requestid" String
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
			Include DeviceAuthOptions
			Parameter GroupID "group" String
				Brief "Recryption group name in user@example.com format"
			Option Cover "cover" ExistingFile
				Brief "File containing a default cover to be added to encrypted files"

		Command GroupAdd "add"
			Brief "Add user to recryption group"
			Include AccountOptions
			Include Reporting
			Parameter GroupID "group" String
				Brief "Recryption group name in user@example.com format"
			Parameter MemberID "member" String
				Brief "User to add"

		Command GroupGet	 "get"
			Brief "Find member in recryption group"
			Include AccountOptions
			Include Reporting
			Parameter GroupID "group" String
				Brief "Recryption group name in user@example.com format"			
			Parameter MemberID "member" String
				Brief "User to find"

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





	CommandSet Password "password"
		Brief "Manage password catalogs connected to an account"

		Command PasswordAdd "add"
			Brief "Add password entry"
			Parameter Site "site" String
				Brief "The site(s) at which the password is to be used."
			Parameter Username "user" String
				Brief "The username"
			Parameter Password "password" String
				Brief "The password"
			Include AccountOptions
			Include Reporting

		Command PasswordGet "get"
			Brief "Lookup password entry"
			Parameter Site "site" String
				Brief "The site name"
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
				Brief "The site or sites to return."
			Include AccountOptions
			Include Reporting

	CommandSet Contact "contact"
		Brief "Manage contact catalogs connected to an account"

		Command ContactAdd "add"
			Brief "Add contact entry from specified parameters"
			Parameter Address "address" String
				Brief "The user address"
			Parameter Name "name" String
				Brief "The user name"
			Option Unique "uid" String
				Brief "Unique identifier"
			Option Identifier "id" String
				Brief "Local identifier"
			Option Self "self" Flag
				Brief "Contact is for self"



		Command ContactStatic "static"
			Brief "Create static contact retrieval URI"
			Include AccountOptions
			Include Reporting

		Command ContactDynamic "dynamic"
			Brief "Create dynamic contact retrieval URI"
			Include AccountOptions
			Include Reporting

		Command ContactFetch "fetch"
			Brief "Request contact from URI without presenting own contact"
			Parameter Uri "uri" String			
			Include AccountOptions
			Include Reporting

		Command ContactExchange "exchange"
			Brief "Request contact from URI presenting own contact"
			Parameter Uri "uri" String
				Brief "Contact exchange URI"
			Include AccountOptions
			Include Reporting

		Command MessageContact "request"
			Brief "Post a conection request to a user"
			Parameter Recipient "recipient" String
				Brief "The recipient to send the conection request to"
			Include AccountOptions
			Include Reporting

		Command ContactImport "import"
			Brief "Import contact entry from file"
			Parameter File "file" ExistingFile
				Brief "File containing the contact entry to add"
			Option Self "self" Flag
				Brief "Contact is for self"
			Include AccountOptions
			Include Reporting

		Command ContactExport "export"
			Brief "Export contact entry from file"
			Parameter Identifier "id" String
				Brief "Contact entry identifier"
			Parameter File "file" ExistingFile
				Brief "File containing the contact entry to add"
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


		Command BookmarkImport "import"
			Brief "Add bookmark entry from file"
			Parameter File "in" ExistingFile
				Brief "File containing the bookmark entry to add"
			Option Identifier "id" String
				Brief "Unique entry identifier"
			Option Format "format" String
				Brief "Specifies the file format."
			Include AccountOptions
			Include Reporting

		Command BookmarkAdd "add"
			Brief "Add bookmark entry from specified parameters"
			Parameter Uri "uri" String
				Brief "The recorded link"
			Parameter Title "title" String
				Brief "Title of the recorded item"
			Option Unique "uid" String
				Brief "Unique identifier"
			Option Identifier "id" String
				Brief "Local identifier"
			Option Abstract "abstract" String
				Brief "Abstract of the recorded item"
			Option Comment "comment" String
				Brief "Comment on reason for adding"
			Option React "react" String
				Brief "Reactions to the recorded item"

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
				Brief "The unique entry identifier"
			Include AccountOptions
			Include Reporting

		Command BookmarkDump "list"
			Brief "List bookmark entries"
			Include AccountOptions
			Include Reporting


	CommandSet Calendar "calendar"
		Brief "Manage calendar catalogs connected to an account"

		Command CalendarImport "import"
			Brief "Add calendar entry from file"
			Parameter File "in" ExistingFile
				Brief "File containing the calendar entry to add"
			Option Identifier "id" String
				Brief "Unique entry identifier"
			Option Format "format" String
				Brief "Specifies the file format."
			Include AccountOptions
			Include Reporting

		Command CalendarAdd "add"
			Brief "Add calendar entry"
			Parameter Title "title" String
				Brief "The entry title."
			Option Identifier "id" String
				Brief "Local identifier"
			Include AccountOptions
			Include Reporting

		Command CalendarGet "get"
			Brief "Lookup calendar entry"
			Parameter Identifier "id" String
				Brief "Unique entry identifier"
			Include AccountOptions
			Include Reporting

		Command CalendarDelete "delete"
			Brief "Delete calendar entry"
			Parameter Identifier "id" String
				Brief "Unique entry identifier"
			Include AccountOptions
			Include Reporting

		Command CalendarDump "list"
			Brief "List calendar entries"
			Include AccountOptions
			Include Reporting

	CommandSet Network "network"
		Brief "Manage network profile settings"

		Command NetworkImport "import"
			Brief "Add network entry from file"
			Parameter File "in" ExistingFile
				Brief "File containing the network entry to add"
			Option Identifier "id" String
				Brief "Unique entry identifier"
			Include AccountOptions
			Include Reporting

		Command NetworkAdd "add"
			Brief "Add network entry "
			Parameter SSID "ssid" String
				Brief "WiFi SSID parameter"
			Parameter Password "password" ExistingFile
				Brief "Password value"
			Option Identifier "id" String
				Brief "Local identifier"
			Include AccountOptions
			Include Reporting

		Command NetworkGet "get"
			Brief "Lookup calendar entry"
			Parameter Identifier "id" String
				Brief "Local identifier"
			Include AccountOptions
			Include Reporting

		Command NetworkDelete "delete"
			Brief "Delete calendar entry"
			Parameter Identifier "id" String
				Brief "Network entry identifier"
			Include AccountOptions
			Include Reporting

		Command NetworkList "list"
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
			Parameter Output "out" NewFile
				Brief "Filename for encrypted output."
			Include EncodeOptions
			Include CryptoOptions
			Include AccountOptions
			Include Reporting
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
			Option SymmetricKey "key" String
				Brief "Specifies the value of the master key"	

		Command DareEARL "earl"
			Brief "Create an Encrypted Authenticated Resource Locator (EARL)"
			Return ResultFile
			Parameter Input "in" ExistingFile
				Brief "File to encode"
			Parameter Domain "domain" String
				Brief "Domain of the EARL service."	
			Option Directory "dir" ExistingFile
				Brief "Directory to write encrypted output."
				Default ".earl"

			
			Option New "new" Flag
				Brief "Only convert file if not listed in DARE Sequence Log."
			Include CryptoOptions
			Include LogOptions
			Include AccountOptions
			Include Reporting


		Command DareCreate "create"
			Brief "Create a new DARE Sequence"
			Include EncodeOptions
			Include CryptoOptions
			Include SequenceOptions
			Include AccountOptions
			Include Reporting
			Parameter Sequence "out" NewFile
				Brief "New sequence"			

		Command DareArchive "archive"
			Brief "Create a new DARE archive and add the specified files"
			Include EncodeOptions
			Include CryptoOptions
			Include AccountOptions
			Include Reporting
			Include SequenceOptions
			Parameter Input "in" ExistingFile
				Brief "Directory containing files to create archive from"
			Option Sequence "out" NewFile
				Brief "New sequence"	
			Option Index "index" Flag
				Default "true"
				Brief "Append index to the archive"	

		Command DareLog "log"
			Brief "Append the specified string to the sequence."
			Include EncodeOptions
			Include CryptoOptions
			Include AccountOptions
			Include Reporting
			Parameter Sequence "in" ExistingFile
				Brief "Sequence to append to"
			Parameter Entry "entry" NewFile
				Brief "Text to append"

		Command DareAppend "append"
			Brief "Append the specified file as an entry to the specified sequence."
			Include EncodeOptions
			Include CryptoOptions
			Include AccountOptions
			Include Reporting
			Parameter Sequence "in" ExistingFile
				Brief "Sequence to append to"
			Parameter File "file" NewFile
				Brief "File to append"
			Option Id "id" String
				Brief "Identifier of the file in the sequence"
			Option Index "index" Flag
				Default "false"
				Brief "Append index to the archive"	

		Command DareDelete "delete"
			Brief "Delete file from archive index."
			Parameter Sequence "in" ExistingFile
				Brief "Sequence to append to"
			Option Filename "file" String
				Brief "Name of file to delete"
			Option Key "key" String


		Command DareDir "dir"
			Brief "Compile a catalog for the specified sequence."
			Include Reporting
			Include AccountOptions
			Parameter Sequence "in" ExistingFile
				Brief "Sequence to be cataloged"

		Command DareList "list"
			Brief "Compile a catalog for the specified sequence."
			Include Reporting
			Include AccountOptions
			Parameter Sequence "in" ExistingFile
				Brief "Sequence to be cataloged"
			Parameter Output "out" NewFile
				Brief "List output"	

		Command DareIndex "index"
			Brief "Compile an index for the specified sequence and append to the end."
			Include EncodeOptions
			Include CryptoOptions
			Include AccountOptions
			Include Reporting
			Parameter Sequence "in" ExistingFile
				Brief "Sequence to be indexed"

		Command DareExtract "extract"
			Brief "Extract the specified record from the sequence"
			Parameter Sequence "in" ExistingFile
				Brief "Sequence to read"

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

		Command DareCopy "copy"
			Brief "Copy sequence contents to create a new sequence removing deleted elements"
			Parameter Input "in" ExistingFile
				Brief "Sequence to read"
			Parameter Output "out" NewFile
				Brief "Copy"
			Include EncodeOptions
			Include CryptoOptions
			Include SequenceOptions
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

	// Mail
	CommandSet Mail "mail"
		Brief "Manage mail profiles connected to a personal profile"

		Command MailAdd "add"
			Brief "Add a mail application profile to a personal profile"
			Parameter Address "address" String
				Brief "Mail account to create profile from"
			Include DeviceAuthOptions
			Include AccountOptions
			Include Reporting
			Include MailOptions
			Include CryptoOptions


		Command MailGet "get"
			Brief "Lookup mail entry"
			Parameter Address "address" String
				Brief "The mail account address"
			Include AccountOptions
			Include Reporting

		Command MailList "list"
			Brief "List mail account information"
			Include AccountOptions
			Include Reporting

		Command MailImport "import"
			Brief "Import account information"
			Parameter File "file" ExistingFile
				Brief "File containing the contact entry to add"
			Option Identifier "id" String
				Brief "Unique entry identifier"
			Include AccountOptions
			Include Reporting


		Command MailDelete "delete"
			Brief "Delete mail account information"
			Include AccountOptions
			Include Reporting
			Parameter Address "address" String
				Brief "Mail account identifier"


		CommandSet SMIME "smime"
			Brief "Commands for managing S/MIME entries"
			Command SmimeSign "sign"
				Brief "Extract the signature key for the specified account"
				Include AccountOptions
				Include Reporting
				Include KeyFileOptions
				Parameter Address "address" String
					Brief "Mail account to update"

			Command SmimeEncrypt "encrypt"
				Brief "Extract the public key/certificate for the specified account"
				Include AccountOptions
				Include Reporting
				Include KeyFileOptions
				Parameter Address "address" String
					Brief "Mail account identifier"

		CommandSet PGP "openpgp"
			Brief "Commands for managing PGP entries"
			Command OpenpgpSign "sign"
				Brief "Extract the signature key for the specified account"
				Include AccountOptions
				Include Reporting
				Include KeyFileOptions
				Parameter Address "address" String
					Brief "Mail account to update"

			Command OpenpgpEncrypt "encrypt"
				Brief "Extract the public key/certificate for the specified account"
				Include AccountOptions
				Include Reporting
				Include KeyFileOptions
				Parameter Address "address" String
					Brief "Mail account identifier"




	// SSH
	CommandSet SSH "ssh"
		Brief "Manage SSH profiles connected to a personal profile"


		// Management of client key pairs
		Command SSHCreate "create"
			Brief "Generate a new SSH public keypair for the current machine and add to the personal profile"
			Include AccountOptions
			Include Reporting
			Include CryptoOptions
			Include DeviceAuthOptions
			Option ID "id" String
				Brief "Key identifier"

		Command SSHGet "get"
			Brief "Get SSH account data"
			Parameter Identifier "id" String
				Brief "The mail account address"
			Include AccountOptions
			Include Reporting
			Include KeyFileOptions

		Command SSHList "list"
			Brief "List SSH account information"
			Include KeyFileOptions
			Include AccountOptions
			Include Reporting

		Command SSHClient "client"
			Brief "Import SSH client information"
			Parameter FileIn "file" ExistingFile
				Brief "File containing the contact entry to add"
			Option Identifier "id" String
				Brief "Unique entry identifier"
			Option Merge "merge" Flag
				Brief "Merge input file with Mesh profile"
			Include AccountOptions
			Include Reporting
			Include KeyFileOptions

		Command SSHHost "host"
			Brief "Import account information"
			Parameter FileIn "file" ExistingFile
				Brief "File containing the contact entry to add"
			Option Identifier "id" String
				Brief "Unique entry identifier"
			Option Merge "merge" Flag
				Brief "Merge input file with Mesh profile"
			Include AccountOptions
			Include Reporting
			Include KeyFileOptions

		Command SSHKnown "known"
			Brief "Get SSH data for known host"
			Parameter Identifier "id" String
				Brief "The mail account address"
			Include AccountOptions
			Include Reporting
			Include KeyFileOptions

		Command SSHDelete "delete"
			Brief "Delete SSH profile information"
			Parameter Identifier "id" String
				Brief "Unique entry identifier"
			Include AccountOptions
			Include Reporting

	CommandSet Callsign "callsign"
		Command CallsignRegister "register"
			Brief "Register a callsign"
			Parameter Identifier "id" String
				Brief "The callsign to register in requested presentation form"
			Include AccountOptions
			Include Reporting

		Command CallsignBind "bind"
			Brief "Bind a registered callsign to an account"
			Parameter Identifier "id" String
				Brief "The callsign to bind"
			Include AccountOptions
			Include Reporting

		Command CallsignResolve "resolve"
			Brief "Request callsign resolution."
			Parameter Identifier "id" String
				Brief "The callsign to resolve"
			Include AccountOptions
			Include Reporting
		
		Command CallsignTransfer "transfer"
			Brief "Transfer a callsign to another user."
			Parameter Recipient "recipient" String
				Brief "The recipient to send the callsign to"
			Parameter Identifier "id" String
				Brief "The callsign to bind"
			Include AccountOptions
			Include Reporting
		
		Command CallsignStatus "status"
			Brief "Report callsign registration status."
			Include AccountOptions
			Include Reporting

		Command CallsignGet "get"
			Brief "Report callsign registration status."
			Include AccountOptions
			Include Reporting		
		
		Command CallsignList "list"
			Brief "List callsign registrations."
			Include AccountOptions
			Include Reporting


	CommandSet Wallet "wallet"
		Command WalletInvoice "invoice"
			Brief "Send a request for payment."
			Parameter Recipient "recipient" String
				Brief "The recipient to send the confirmation request to"
			Parameter Invoice "message" ExistingFile
				Brief "The invoice text"
			Parameter Currency "currency" String
				Brief "The payment currency"
			Parameter Amount "amount" String
				Brief "The payment amount"
			Parameter Reason "reason" String
				Brief "The reason for the payment request"
			Include AccountOptions
			Include Reporting

		Command WalletTransfer "transfer"
			Brief "Transfer a token to another user."
			Parameter Recipient "recipient" String
				Brief "The recipient to send the confirmation request to"
			Parameter Currency "currency" String
				Brief "The payment currency"
			Parameter Amount "amount" String
				Brief "The payment amount"
			Parameter Reason "reason" String
				Brief "The reason for the transfer"
			Include AccountOptions
			Include Reporting

		Command WalletAccept "accept"
			Brief "Accept an invoice and make payment"
			Parameter MessageId "message" String
				Brief "The invoice message id"
			Include AccountOptions
			Include Reporting

		Command WalletReject "reject"
			Brief "Accept an invoice and make payment"
			Parameter MessageId "message" String
				Brief "The invoice message id"
			Include AccountOptions
			Include Reporting

		Command WalletRedeem "redeem"
			Brief "Redeem an invoice payment"
			Parameter MessageId "message" String
				Brief "The payment message id to redeem"
			Include AccountOptions
			Include Reporting

		Command WalletList "list"
			Brief "List wallet entries"
			Include AccountOptions
			Include Reporting

		Command WalletDelete "delete"
			Brief "Delete wallet entry"
			Parameter Identifier "id" String
				Brief "Wallet entry identifier"
			Include AccountOptions
			Include Reporting

		Command WalletkGet "get"
			Brief "Lookup wallet entry"
			Parameter Identifier "id" String
				Brief "Local identifier"
			Include AccountOptions
			Include Reporting

	CommandSet Carnet "carnet"
		Command CarnetMint "Mint"
			Brief "Mint a carnet and send it to a user"
			Parameter Amount "amount" String
				Brief "The payment amount"
			Option Recipient "to" String
				Brief "The recipient to send the confirmation request to"

			Option Currency "currency" String
				Brief "The payment currency"
			Option Tickets "tickets" Integer
				Brief "The number of tickets to issue"			
			Option Quantum "quantum" Integer
				Brief "The value of each ticket"	
			Include AccountOptions
			Include Reporting

		Command CarnetStatus "status"
			Brief "Return status of a carnet entry"
			Parameter Identifier "id" String
				Brief "The carnet identifier"
			Include AccountOptions
			Include Reporting

	CommandSet Chat "chat"
		Command ChatMessage "message"

		Command ChatListen "listen"
			Option Quantum "quantum" Integer
				Brief "The value of each ticket"	

		Command ChatPoll "poll"

