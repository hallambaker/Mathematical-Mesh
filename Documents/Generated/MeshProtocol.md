

#Mesh Portal Service  Reference

<dt>SRV Prefix: _mmm._tcp

<dt>HTTP Well Known Service Prefix: /.well-known/mmm



Every Mesh Portal Service transaction consists of exactly one
request followed by exactly one response.
Mesh Service transactions MAY cause modification
of the data stored in the Mesh Portal or the Mesh itself
but do not cause changes to the connection state. The protocol
itself is thus idempotent. There is no set sequence
in which operations are required to be performed. It is not
necessary to perform a Hello transaction prior to
a ValidateAccount, Publish or any other transaction.

##Request Messages

A Mesh Portal Service request consists of a payload object
that inherits from the MeshRequest class. When using the 
HTTP binding, the request MUST specify the portal DNS
address in the HTTP Host field. 

###Message: MeshRequest

Base class for all request messages.

<dl>
<dt>Portal: String (Optional)
<dd>Name of the Mesh Portal Service to which the request 
is directed.
</dl>
##Response Messages

A Mesh Portal Service response consists of a payload object that
inherits from the MeshResponse class. When using the
HTTP binding, the response SHOULD
report the Status response code in the HTTP response 
message. However the response code returned in the
payload object MUST always be considered authoritative.

###Message: MeshResponse

Base class for all response messages. Contains only the
status code and status description fields.

[No fields]

##Imported Objects

The Mesh Service protocol makes use of JSON objects
defined in the JOSE Signatgure and Encryption specifications.

##Common Structures

The following common structures are used in the protocol
messages:

###Structure: KeyValue

Describes a Key/Value structure used to make queries
for records matching one or more selection criteria.

<dl>
<dt>Key: String (Optional)
<dd>The data retrieval key.
<dt>Value: String (Optional)
<dd>The data value to match.
</dl>
###Structure: SearchConstraints

Specifies constraints to be applied to a search result. These 
allow a client to limit the number of records returned, the quantity
of data returned, the earliest and latest data returned, etc.

<dl>
<dt>NotBefore: DateTime (Optional)
<dd>Only data published on or after the specified time instant 
is requested.
<dt>Before: DateTime (Optional)
<dd>Only data published before the specified time instant is
requested. This excludes data published at the specified time instant.
<dt>MaxEntries: Integer (Optional)
<dd>Maximum number of data entries to return.
<dt>MaxBytes: Integer (Optional)
<dd>Maximum number of data bytes to return.
<dt>PageKey: String (Optional)
<dd>Specifies a page key returned in a previous search operation
in which the number of responses exceeded the specified bounds.
<dd>When a page key is specified, all the other search parameters
except for MaxEntries and MaxBytes are ignored and the service
returns the next set of data responding to the earlier query.
</dl>
##Transaction: Hello

<dl>
<dt>Request:  HelloRequest
<dt>Response:  HelloResponse
</dl>

Report service and version information. 

The Hello transaction provides a means of determining which protocol
versions, message encodings and transport protocols are supported by
the service.

##Transaction: ValidateAccount

<dl>
<dt>Request:  ValidateRequest
<dt>Response:  ValidateResponse
</dl>

Request validation of a proposed name for a new account.

For validation of a user's account name during profile creation.

###Message: ValidateRequest

<dl>
<dt>Inherits:  MeshRequest
</dl>

Describes the proposed account properties. Currently, these are limited
to the account name but could be extended in future versions of the protocol.

<dl>
<dt>Account: String (Optional)
<dd>Account name requested
<dt>Reserve: Boolean (Optional)
<dd>If true, request a reservation for the specified account name.
Note that the service is not obliged to honor reservation 
requests.
<dt>Language: String [0..Many]
<dd>List of ISO language codes in order of preference. For creating
explanatory text.
</dl>
###Message: ValidateResponse

<dl>
<dt>Inherits:  MeshResponse
</dl>

States whether the proposed account properties are acceptable and
(optional) returns an indication of what properties are valid.

Note that receiving a 'Valid' responseto a Validate Request does
not guarantee creation of the account. In addition to the possibility 
that the account namecould be requested by another user between the 
Validate and Create transactions, a portal service MAY perform more 
stringent validation criteria when an account is actually being 
created. For example, checking with the authoritative list of
current accounts rather than a cached copy.

<dl>
<dt>Valid: Boolean (Optional)
<dd>If true, the specified account identifier is acceptable. If false,
the account identifier is rejected.
<dt>Minimum: Integer (Optional)
<dd>Specifies the minimum length of an account name.
<dt>Maximum: Integer (Optional)
<dd>Specifies the maximum length of an account name.
<dt>InvalidCharacters: String (Optional)
<dd>A list of characters that the service 
does not accept in account names. The list of characters 
MAY not be exhaustive but SHOULD include any illegal characters
in the proposed account name.
<dt>Reason: String (Optional)
<dd>Text explaining the reason an account name was rejected.
</dl>
##Transaction: CreateAccount

<dl>
<dt>Request:  CreateRequest
<dt>Response:  CreateResponse
</dl>

Request creation of a new portal account.

Unlike a profile, a mesh account is specific to a particular 
Mesh portal. A mesh account must be created and accepted before
a profile can be published.

###Message: CreateRequest

Request creation of a new portal account. The request specifies
the requested account identifier and the Mesh profile to be associated 
with the account.

<dl>
<dt>Inherits:  MeshRequest
</dl>

<dl>
<dt>Account: String (Optional)
<dd>Account identifier requested.
</dl>
###Message: CreateResponse

<dl>
<dt>Inherits:  MeshResponse
</dl>

Reports the success or failure of a Create transaction.

[No fields]

##Transaction: DeleteAccount

<dl>
<dt>Request:  DeleteRequest
<dt>Response:  DeleteResponse
</dl>

Request deletion of a portal account.

Deletes a portal account but not the underlying profile. Once registered,
profiles are permanent.

###Message: DeleteRequest

Request deletion of a new portal account. The request specifies
the requested account identifier.

<dl>
<dt>Inherits:  MeshRequest
</dl>

<dl>
<dt>Account: String (Optional)
<dd>Account identifier to be deleted.
</dl>
###Message: DeleteResponse

<dl>
<dt>Inherits:  MeshResponse
</dl>

Reports the success or failure of a Delete transaction.

[No fields]

##Transaction: Get

<dl>
<dt>Request:  GetRequest
<dt>Response:  GetResponse
</dl>

Search for data in the mesh that matches a set of properties
described by a sequence of key/value pairs.

###Message: GetRequest

Describes the Portal or Mesh data to be retreived.

<dl>
<dt>Inherits:  MeshRequest
</dl>

<dl>
<dt>Identifier: String (Optional)
<dd>Lookup by profile ID
<dt>Account: String (Optional)
<dd>Lookup by Account ID
<dt>KeyValues: KeyValue [0..Many]
<dd>List of KeyValue pairs specifying the conditions to be met
<dt>SearchConstraints: SearchConstraints (Optional)
<dd>Constrain the search to a specific time interval and/or 
limit the number and/or total size of data records returned.
<dt>Multiple: Boolean (Optional)
<dd>If true return multiple responses if available
<dt>Full: Boolean (Optional)
<dd>If true, the client requests that the full Mesh data record 
be returned containing both the Mesh entry itself and the 
Mesh metadata that allows the date and time of the 
publication of the Mesh entry to be verified.
</dl>
###Message: GetResponse

Reports the success or failure of a Get transaction. If a Mesh entry
matching the specified profile is found, containsthe list of entries
matching the request.

<dl>
<dt>Inherits:  MeshResponse
</dl>

<dl>
<dt>DataItems: DataItem [0..Many]
<dd>List of mesh data records matching the request.
<dt>PageKey: String (Optional)
<dd>If non-null, indicates that the number and/or size of the data records
returned exceeds either the SearchConstraints specified in the
request or internal server limits.
</dl>
##Transaction: Publish

<dl>
<dt>Request:  PublishRequest
<dt>Response:  PublishResponse
</dl>

Publish a profile or key escrow entry to the mesh.

###Message: PublishRequest

Requests publication of the specified Mesh entry.

<dl>
<dt>Inherits:  MeshRequest
</dl>

[No fields]

###Message: PublishResponse

Reports the success or failure of a Publish transaction.

<dl>
<dt>Inherits:  MeshResponse
</dl>

[No fields]

##Transaction: Status

<dl>
<dt>Request:  StatusRequest
<dt>Response:  StatusResponse
</dl>

Request the current status of the mesh as seen by the portal to which it
is directed.

The response to the status request contains the last signed checkpoint
and proof chains for each of the peer portals that have been checkpointed.

[Not currently implemented]

###Message: StatusRequest

<dl>
<dt>Inherits:  MeshRequest
</dl>

Initiates a status transaction.

[No fields]

###Message: StatusResponse

Reports the success or failure of a Status transaction.

<dl>
<dt>Inherits:  MeshResponse
</dl>

<dl>
<dt>LastWriteTime: DateTime (Optional)
<dd>Time that the last write update was made to the Mesh
<dt>LastCheckpointTime: DateTime (Optional)
<dd>Time that the last Mesh checkpoint was calculated.
<dt>NextCheckpointTime: DateTime (Optional)
<dd>Time at which the next Mesh checkpoint should be calculated.
<dt>CheckpointValue: String (Optional)
<dd>Last checkpoint value.
</dl>
##Transaction: ConnectStart

<dl>
<dt>Request:  ConnectStartRequest
<dt>Response:  ConnectStartResponse
</dl>

Request connection of a new device to a mesh profile

###Message: ConnectStartRequest

<dl>
<dt>Inherits:  MeshRequest
</dl>

Initial device connection request.

<dl>
<dt>SignedRequest: SignedConnectionRequest (Optional)
<dd>Device connection request signed by thesignature key of the 
device requesting connection.
<dt>AccountID: String (Optional)
<dd>Account identifier of account to which the device is requesting
connection.
</dl>
###Message: ConnectStartResponse

Reports the success or failure of a ConnectStart transaction.

<dl>
<dt>Inherits:  MeshRequest
</dl>

[No fields]

##Transaction: ConnectStatus

<dl>
<dt>Request:  ConnectStatusRequest
<dt>Response:  ConnectStatusResponse
</dl>

Request status of pending connection request of a new device 
to a mesh profile

###Message: ConnectStatusRequest

<dl>
<dt>Inherits:  MeshRequest
</dl>

Request status information for a pending request posted
previously.

<dl>
<dt>AccountID: String (Optional)
<dd>Account identifier for which pending connection information
is requested.
<dt>DeviceID: String (Optional)
<dd>Device identifier of device requesting status information.
</dl>
###Message: ConnectStatusResponse

Reports the success or failure of a ConnectStatus transaction.

<dl>
<dt>Inherits:  MeshRequest
</dl>

<dl>
<dt>Result: SignedConnectionResult (Optional)
<dd>The signed ConnectionResult object.
</dl>
##Transaction: ConnectPending

<dl>
<dt>Request:  ConnectPendingRequest
<dt>Response:  ConnectPendingResponse
</dl>

Request a list of pending requests for an administration profile.

###Message: ConnectPendingRequest

<dl>
<dt>Inherits:  MeshRequest
</dl>

Specify the criteria for pending requests.

<dl>
<dt>AccountID: String (Optional)
<dd>The account identifier of the account for which
pending connection requests are requested.
<dt>SearchConstraints: SearchConstraints (Optional)
<dd>Constrain the search to a specific time interval and/or 
limit the number and/or total size of data records returned.
</dl>
###Message: ConnectPendingResponse

Reports the success or failure of a ConnectPending transaction.

<dl>
<dt>Inherits:  MeshRequest
</dl>

<dl>
<dt>Pending: SignedConnectionRequest [0..Many]
<dd>A list of pending requests satisfying the criteria set out
in the request.
<dt>PageKey: String (Optional)
<dd>If non-null, indicates that the number and/or size of the data records
returned exceeds either the SearchConstraints specified in the
request or internal server limits.
</dl>
##Transaction: ConnectComplete

<dl>
<dt>Request:  ConnectCompleteRequest
<dt>Response:  ConnectCompleteResponse
</dl>

Post response to a pending connection request.

###Message: ConnectCompleteRequest

Reports the success or failure of a ConnectComplete transaction.

<dl>
<dt>Inherits:  MeshRequest
</dl>

<dl>
<dt>Result: SignedConnectionResult (Optional)
<dd>The connection result to be posted to the portal. The result MUST
be signed by a valid administration key for the Mesh profile.
<dt>AccountID: String (Optional)
<dd>The account identifier to which the connection result is
posted.
</dl>
###Message: ConnectCompleteResponse

<dl>
<dt>Inherits:  MeshRequest
</dl>

Reports the success or failure of a ConnectComplete transaction.

[No fields]

##Transaction: Transfer

<dl>
<dt>Request:  TransferRequest
<dt>Response:  TransferResponse
</dl>

Perform a bulk transfer of the log between the specified transaction
identifiers. Requires appropriate authorization

[Not currently implemented]

###Message: TransferRequest

Request a bulk transfer of the log between the specified transaction
identifiers. Requires appropriate authorization

<dl>
<dt>Inherits:  MeshRequest
</dl>

<dl>
<dt>SearchConstraints: SearchConstraints (Optional)
<dd>Constrain the search to a specific time interval and/or 
limit the number and/or total size of data records returned.
</dl>
###Message: TransferResponse

<dl>
<dt>Inherits:  MeshResponse
</dl>

Reports the success or failure of a Transfer transaction.
If successful, contains the list of Mesh records to be transferred.

<dl>
<dt>DataItems: DataItem [0..Many]
<dd>List of mesh data records matching the request.
<dt>PageKey: String (Optional)
<dd>If non-null, indicates that the number and/or size of the data records
returned exceeds either the SearchConstraints specified in the
request or internal server limits.
</dl>
