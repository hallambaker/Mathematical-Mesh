

#Mesh/Account Service

The Mesh/Account Service is used to manage accounts. All operations
are regarded as privileged and will require appropriate access controls.

<dt>SRV Prefix: _mmmaccount._tcp

<dt>HTTP Well Known Service Prefix: /.well-known/mmmaccount



Every Mesh/Account Service transaction consists of exactly one
request followed by exactly one response.

##Request Messages



###Message: AccountRequest

Base class for all request messages.

[No fields]

##Response Messages



###Message: AccountResponse

Base class for all response messages. Contains only the
status code and status description fields.

A service MAY return either the response message specified
for that transaction or any parent of that message. 
Thus the RecryptResponse message MAY be returned in response 
to any request.

[No fields]

##Imported Objects


##Common classes

The following classes are referenced at multiple points in the protocol.

###Structure: AccountData

The data associated with an account

<dl>
<dt>AccountId: String (Optional)
<dd>The account identifier
<dt>Created: DateTime (Optional)
<dd>Date and time that the account identifier was created.
<dt>Status: String (Optional)
<dd>Account status
<dt>MeshUDF: String (Optional)
<dd>Fingerprint of the user's mesh profile
<dt>Portal: String [0..Many]
<dd>Mesh Portal identifier
<dt>Entries: AccountDataEntry [0..Many]
<dd>Service specific data
</dl>
###Structure: AccountDataEntry

Superclass for all account data entry objects

[No fields]

##Utility Transactions

##Transaction: Hello

<dl>
<dt>Request:  HelloRequest
<dt>Response:  HelloResponse
</dl>

Report service and version information. 

The Hello transaction provides a means of determining which protocol
versions, message encodings and transport protocols are supported by
the service.

##Administration Transactions

##Transaction: Create

<dl>
<dt>Request:  CreateRequest
<dt>Response:  CreateResponse
</dl>

Create new account

###Message: CreateRequest

<dl>
<dt>Inherits:  AccountRequest
</dl>

Create a new account

<dl>
<dt>Data: AccountData (Optional)
<dd>Describes the account to be created
</dl>
###Message: CreateResponse

<dl>
<dt>Inherits:  AccountResponse
</dl>

Response to create request

<dl>
<dt>UDF: String (Optional)
<dd>Unique identifier of the account
</dl>
##Transaction: Delete

<dl>
<dt>Request:  DeleteRequest
<dt>Response:  DeleteResponse
</dl>

Delete an account

###Message: DeleteRequest

<dl>
<dt>Inherits:  AccountRequest
</dl>

Delete an account

<dl>
<dt>AccountId: String (Optional)
<dd>The account to delete
</dl>
###Message: DeleteResponse

<dl>
<dt>Inherits:  AccountResponse
</dl>

Result

[No fields]

##Transaction: Update

<dl>
<dt>Request:  UpdateRequest
<dt>Response:  UpdateResponse
</dl>


###Message: UpdateRequest

<dl>
<dt>Inherits:  AccountRequest
</dl>

Update an account profile

<dl>
<dt>Data: AccountData (Optional)
<dd>The account to update
</dl>
###Message: UpdateResponse

<dl>
<dt>Inherits:  AccountResponse
</dl>

Result

[No fields]

##Transaction: Get

<dl>
<dt>Request:  GetRequest
<dt>Response:  GetResponse
</dl>


###Message: GetRequest

<dl>
<dt>Inherits:  AccountRequest
</dl>

Fetches an account profile.

<dl>
<dt>AccountId: String (Optional)
<dd>The account to fetch
</dl>
###Message: GetResponse

<dl>
<dt>Inherits:  AccountResponse
</dl>

Result

<dl>
<dt>Data: AccountData (Optional)
<dd>Describes the account (if found)
</dl>
