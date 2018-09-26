

	





				



	//
	Transaction User Download DownloadRequest DownloadResponse
		Description
			|Request objects from the specified container with the specified search
			|criteria.

	Message DownloadRequest
		Inherits MeshRequest
		Description
			|Request objects from the specified container.
		Description
			|A client MAY request only objects matching specified search criteria
			|be returned and MAY request that only specific fields or parts of the 
			|payload be returned.
		String Account
		String Container
			Multiple
		Struct ConstraintsSelect Select
			Description
				|Specifies constraints to be applied to a search result. These 
				|allow a client to limit the number of records returned, the quantity
				|of data returned, the earliest and latest data returned, etc.
		Struct DataConstraints PostConstraints
			Description
				|Specifies the data constraints to be applied to the responses.

	Message DownloadResponse
		Inherits MeshResponse
		Description
			|Return the set of objects requested.
		Description
			|Services SHOULD NOT return a response that is disproportionately large
			|relative to the speed of the network connection without a clear indication
			|from the client that it is relevant. A service MAY limit the number of 
			|objects returned. A service MAY limit the scope of each response. 



	Transaction User Upload UploadRequest UploadResponse
		Description
			|Request objects from the specified container with the specified search
			|criteria.


	Message UploadRequest
		Inherits MeshRequest
		Description
			|Upload entries to a container. This request is only valid if it is issued
			|by the owner of the account
		String Account
			Multiple
			Description
				|The account(s) to which the entries are to be uploaded.
		String Container
			Description
				|The container to which the entries are to be uploaded.
		Struct DAREMessage Message
			Multiple
			Description
				|The entries to be uploaded. These MAY be either complete messages or redacted messages.
				|In either case, the messages MUST conform to the ConstraintsUpdate specified by the 
				|service 

	Message UploadResponse
		Inherits MeshResponse
		Description
			|Response to an upload request. 
		Struct EntryResponse Entries
			Description
				|The responses to the entries.
		Struct ConstraintsData ConstraintsData
			Description
				|If the upload request contains redacted entries, specifies constraints 
				|that apply to the redacted entries as a group. Thus the total payloads
				|of all the messages must not exceed the specified value.


	Structure EntryResponse
		Integer IndexRequest
			Description
				|The index value of the entry in the request.
		Integer IndexContainer
			Description
				|The index value assigned to the entry in the container.
		String Result
			Description
				|Specifies the result of attempting to add the entry to a catalog
				|or spool. Valid values for a message are 'Accept', 'Reject'. Valid 
				|values for an entry are 'Accept', 'Reject' and 'Conflict'.
		Struct ConstraintsData ConstraintsData
			Description
				|If the entry was redacted, specifies constraints 
				|that apply to the redacted entries as a group. Thus the total payloads
				|of all the messages must not exceed the specified value.	




	Transaction Public Post PostRequest PostResponse
		Description
			|Request to post to a spool from an external party. The request and response
			|messages are extensions of the corresponding messages for the Upload transaction.
			|It is expected that additional fields will be added as the need arises.


	Message PostRequest
		Inherits UploadRequest
		Description
			|

	Message PostResponse
		Inherits UploadResponse
		Description
			|



	//Create account
	Transaction Admin CreateAccount CreateRequest CreateResponse
		Description
			|Request creation of a new service account.
		Description
			|Attempt 

	Message CreateRequest
		Description
			|Request creation of a new portal account. The request specifies
			|the requested account identifier and the Mesh profile to be associated 
			|with the account.
		Inherits MeshRequest
		String Account
			Description
				|Account identifier requested.
		String Language
			Multiple
			Description
				|List of ISO language codes in order of preference. For creating
				|explanatory text.
		TStruct SignedProfile Profile
			Description
				|User profile of account to be created. The profile MUST specify the 
				|account being created as an account.

	Message CreateResponse
		Inherits MeshResponse
		Description
			|Reports the success or failure of a Create transaction.
		String Reason
			Description
				|Text explaining the status of the creation request.
		String Status
			Description
				|The status of the account creation request.
		String URL
			Description
				|A URL to which the user is directed to complete the account creation 
				|request.
