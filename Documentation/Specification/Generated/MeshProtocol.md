

#Mesh Portal Service  Reference

<dl><dt>SRV Prefix: 
<dd>_mmm._tcp</dl>

<dl><dt>HTTP Well Known Service Prefix: 
<dd>/.well-known/mmm</dl>



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


<dl><dt>Portal: 
<dd>String (Optional)


Name of the Mesh Portal Service to which the request 
is directed.

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

[None]

##Imported Objects

The Mesh Service protocol makes use of JSON objects
defined in the JOSE Signatgure and Encryption specifications.

##Common Structures

The following common structures are used in the protocol
messages:

###Structure: KeyValue

Describes a Key/Value structure used to make queries
for records matching one or more selection criteria.


<dl><dt>Key: 
<dd>String (Optional)


The data retrieval key.

<dl><dt>Value: 
<dd>String (Optional)


The data value to match.

###Structure: SearchConstraints

Specifies constraints to be applied to a search result. These 
allow a client to limit the number of records returned, the quantity
of data returned, the earliest and latest data returned, etc.


<dl><dt>NotBefore: 
<dd>DateTime (Optional)


Only data published on or after the specified time instant 
is requested.

<dl><dt>Before: 
<dd>DateTime (Optional)


Only data published before the specified time instant is
requested. This excludes data published at the specified time instant.

<dl><dt>MaxEntries: 
<dd>Integer (Optional)


Maximum number of data entries to return.

<dl><dt>MaxBytes: 
<dd>Integer (Optional)


Maximum number of data bytes to return.

<dl><dt>PageKey: 
<dd>String (Optional)


Specifies a page key returned in a previous search operation
in which the number of responses exceeded the specified bounds.


When a page key is specified, all the other search parameters
except for MaxEntries and MaxBytes are ignored and the service
returns the next set of data responding to the earlier query.

##Transaction: Hello

Request: HelloRequest

Response: HelloResponse

Report service and version information. 

The Hello transaction provides a means of determining which protocol
versions, message encodings and transport protocols are supported by
the service.

##Transaction: ValidateAccount

Request: ValidateRequest

Response: ValidateResponse

Request validation of a proposed name for a new account.

For validation of a user's account name during profile creation.

###Message: ValidateRequest

* Inherits: MeshRequest

Describes the proposed account properties. Currently, these are limited
to the account name but could be extended in future versions of the protocol.


<dl><dt>Account: 
<dd>String (Optional)


Account name requested

<dl><dt>Reserve: 
<dd>Boolean (Optional)


If true, request a reservation for the specified account name.
Note that the service is not obliged to honor reservation 
requests.

<dl><dt>Language: 
<dd>String [0..Many]


List of ISO language codes in order of preference. For creating
explanatory text.

###Message: ValidateResponse

* Inherits: MeshResponse

States whether the proposed account properties are acceptable and
(optional) returns an indication of what properties are valid.

Note that receiving a 'Valid' responseto a Validate Request does
not guarantee creation of the account. In addition to the possibility 
that the account namecould be requested by another user between the 
Validate and Create transactions, a portal service MAY perform more 
stringent validation criteria when an account is actually being 
created. For example, checking with the authoritative list of
current accounts rather than a cached copy.


<dl><dt>Valid: 
<dd>Boolean (Optional)


If true, the specified account identifier is acceptable. If false,
the account identifier is rejected.

<dl><dt>Minimum: 
<dd>Integer (Optional)


Specifies the minimum length of an account name.

<dl><dt>Maximum: 
<dd>Integer (Optional)


Specifies the maximum length of an account name.

<dl><dt>InvalidCharacters: 
<dd>String (Optional)


A list of characters that the service 
does not accept in account names. The list of characters 
MAY not be exhaustive but SHOULD include any illegal characters
in the proposed account name.

<dl><dt>Reason: 
<dd>String (Optional)


Text explaining the reason an account name was rejected.

##Transaction: CreateAccount

Request: CreateRequest

Response: CreateResponse

Request creation of a new portal account.

Unlike a profile, a mesh account is specific to a particular 
Mesh portal. A mesh account must be created and accepted before
a profile can be published.

###Message: CreateRequest

Request creation of a new portal account. The request specifies
the requested account identifier and the Mesh profile to be associated 
with the account.

* Inherits: MeshRequest


<dl><dt>Account: 
<dd>String (Optional)


Account identifier requested.

###Message: CreateResponse

* Inherits: MeshResponse

Reports the success or failure of a Create transaction.

[None]

##Transaction: DeleteAccount

Request: DeleteRequest

Response: DeleteResponse

Request deletion of a portal account.

Deletes a portal account but not the underlying profile. Once registered,
profiles are permanent.

###Message: DeleteRequest

Request deletion of a new portal account. The request specifies
the requested account identifier.

* Inherits: MeshRequest


<dl><dt>Account: 
<dd>String (Optional)


Account identifier to be deleted.

###Message: DeleteResponse

* Inherits: MeshResponse

Reports the success or failure of a Delete transaction.

[None]

##Transaction: Get

Request: GetRequest

Response: GetResponse

Search for data in the mesh that matches a set of properties
described by a sequence of key/value pairs.

###Message: GetRequest

Describes the Portal or Mesh data to be retreived.

* Inherits: MeshRequest


<dl><dt>Identifier: 
<dd>String (Optional)


Lookup by profile ID

<dl><dt>Account: 
<dd>String (Optional)


Lookup by Account ID

<dl><dt>KeyValues: 
<dd>KeyValue [0..Many]


List of KeyValue pairs specifying the conditions to be met

<dl><dt>SearchConstraints: 
<dd>SearchConstraints (Optional)


Constrain the search to a specific time interval and/or 
limit the number and/or total size of data records returned.

<dl><dt>Multiple: 
<dd>Boolean (Optional)


If true return multiple responses if available

<dl><dt>Full: 
<dd>Boolean (Optional)


If true, the client requests that the full Mesh data record 
be returned containing both the Mesh entry itself and the 
Mesh metadata that allows the date and time of the 
publication of the Mesh entry to be verified.

###Message: GetResponse

Reports the success or failure of a Get transaction. If a Mesh entry
matching the specified profile is found, containsthe list of entries
matching the request.

* Inherits: MeshResponse


<dl><dt>DataItems: 
<dd>DataItem [0..Many]


List of mesh data records matching the request.

<dl><dt>PageKey: 
<dd>String (Optional)


If non-null, indicates that the number and/or size of the data records
returned exceeds either the SearchConstraints specified in the
request or internal server limits.

##Transaction: Publish

Request: PublishRequest

Response: PublishResponse

Publish a profile or key escrow entry to the mesh.

###Message: PublishRequest

Requests publication of the specified Mesh entry.

* Inherits: MeshRequest

[None]

###Message: PublishResponse

Reports the success or failure of a Publish transaction.

* Inherits: MeshResponse

[None]

##Transaction: Status

Request: StatusRequest

Response: StatusResponse

Request the current status of the mesh as seen by the portal to which it
is directed.

The response to the status request contains the last signed checkpoint
and proof chains for each of the peer portals that have been checkpointed.

[Not currently implemented]

###Message: StatusRequest

* Inherits: MeshRequest

Initiates a status transaction.

[None]

###Message: StatusResponse

Reports the success or failure of a Status transaction.

* Inherits: MeshResponse


<dl><dt>LastWriteTime: 
<dd>DateTime (Optional)


Time that the last write update was made to the Mesh

<dl><dt>LastCheckpointTime: 
<dd>DateTime (Optional)


Time that the last Mesh checkpoint was calculated.

<dl><dt>NextCheckpointTime: 
<dd>DateTime (Optional)


Time at which the next Mesh checkpoint should be calculated.

<dl><dt>CheckpointValue: 
<dd>String (Optional)


Last checkpoint value.

##Transaction: ConnectStart

Request: ConnectStartRequest

Response: ConnectStartResponse

Request connection of a new device to a mesh profile

###Message: ConnectStartRequest

* Inherits: MeshRequest

Initial device connection request.


<dl><dt>SignedRequest: 
<dd>SignedConnectionRequest (Optional)


Device connection request signed by thesignature key of the 
device requesting connection.

<dl><dt>AccountID: 
<dd>String (Optional)


Account identifier of account to which the device is requesting
connection.

###Message: ConnectStartResponse

Reports the success or failure of a ConnectStart transaction.

* Inherits: MeshRequest

[None]

##Transaction: ConnectStatus

Request: ConnectStatusRequest

Response: ConnectStatusResponse

Request status of pending connection request of a new device 
to a mesh profile

###Message: ConnectStatusRequest

* Inherits: MeshRequest

Request status information for a pending request posted
previously.


<dl><dt>AccountID: 
<dd>String (Optional)


Account identifier for which pending connection information
is requested.

<dl><dt>DeviceID: 
<dd>String (Optional)


Device identifier of device requesting status information.

###Message: ConnectStatusResponse

Reports the success or failure of a ConnectStatus transaction.

* Inherits: MeshRequest


<dl><dt>Result: 
<dd>SignedConnectionResult (Optional)


The signed ConnectionResult object.

##Transaction: ConnectPending

Request: ConnectPendingRequest

Response: ConnectPendingResponse

Request a list of pending requests for an administration profile.

###Message: ConnectPendingRequest

* Inherits: MeshRequest

Specify the criteria for pending requests.


<dl><dt>AccountID: 
<dd>String (Optional)


The account identifier of the account for which
pending connection requests are requested.

<dl><dt>SearchConstraints: 
<dd>SearchConstraints (Optional)


Constrain the search to a specific time interval and/or 
limit the number and/or total size of data records returned.

###Message: ConnectPendingResponse

Reports the success or failure of a ConnectPending transaction.

* Inherits: MeshRequest


<dl><dt>Pending: 
<dd>SignedConnectionRequest [0..Many]


A list of pending requests satisfying the criteria set out
in the request.

<dl><dt>PageKey: 
<dd>String (Optional)


If non-null, indicates that the number and/or size of the data records
returned exceeds either the SearchConstraints specified in the
request or internal server limits.

##Transaction: ConnectComplete

Request: ConnectCompleteRequest

Response: ConnectCompleteResponse

Post response to a pending connection request.

###Message: ConnectCompleteRequest

Reports the success or failure of a ConnectComplete transaction.

* Inherits: MeshRequest


<dl><dt>Result: 
<dd>SignedConnectionResult (Optional)


The connection result to be posted to the portal. The result MUST
be signed by a valid administration key for the Mesh profile.

<dl><dt>AccountID: 
<dd>String (Optional)


The account identifier to which the connection result is
posted.

###Message: ConnectCompleteResponse

* Inherits: MeshRequest

Reports the success or failure of a ConnectComplete transaction.

[None]

##Transaction: Transfer

Request: TransferRequest

Response: TransferResponse

Perform a bulk transfer of the log between the specified transaction
identifiers. Requires appropriate authorization

[Not currently implemented]

###Message: TransferRequest

Request a bulk transfer of the log between the specified transaction
identifiers. Requires appropriate authorization

* Inherits: MeshRequest


<dl><dt>SearchConstraints: 
<dd>SearchConstraints (Optional)


Constrain the search to a specific time interval and/or 
limit the number and/or total size of data records returned.

###Message: TransferResponse

* Inherits: MeshResponse

Reports the success or failure of a Transfer transaction.
If successful, contains the list of Mesh records to be transferred.


<dl><dt>DataItems: 
<dd>DataItem [0..Many]


List of mesh data records matching the request.

<dl><dt>PageKey: 
<dd>String (Optional)


If non-null, indicates that the number and/or size of the data records
returned exceeds either the SearchConstraints specified in the
request or internal server limits.

