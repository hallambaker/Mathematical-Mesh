

#Mesh Portal Service  Reference

SRV Prefix:

:_mmm._tcp

HTTP Well Known Service Prefix:

:/.well-known/mmm

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

Base class for all request objects.


Portal: String (Optional)

:Name of the Mesh Portal Service to which the request 
is directed.

##Response Messages

A Mesh Portal Service response consists of a payload object that
inherits from the MeshResponse class. When using the
HTTP binding, the response SHOULD
report the Status response code in the HTTP response 
message. However the response code returned in the
payload object MUST always be considered authoritative.

###Message: MeshResponse

Base class for all responses. Contains only the
status code and status description fields.

A service MAY return either the response message specified
for that transaction or any parent of that message. 
Thus the MeshResponse message MAY be returned in response 
to any request.


Status: Integer (Optional)

:Status return code. The SMTP/HTTP scheme of 2xx = Success,
3xx = incomplete, 4xx = failure is followed.

StatusDescription: String (Optional)

:Text description of the status return code for debugging 
and log file use.

###Successful Response Codes

The following response codes are returned when a
transaction has completed successfully.

201 SuccessOK
:Operation completed successfully

201 SuccessCreated
:Operation completed successfully, new data item created

202 SuccessUpdated
:Operation completed successfully, data item was updated

###Warning Response Codes

The following response codes are returned when a
transaction did not complete because the target
service has been redirected.

In the case that a redirect code is returned, the 
StatusDescription field contains the URI of the 
new service. Note however that the redirect location 
indicated in a status response might be incorrect
or even malicious and cannot be considered 
trustworthy without appropriate authentication.

303 RedirectPermanent
:Service has been permanently moved

307 RedirectTemporary
:Service has been temporarily moved

###Error Response Codes

A response code in the range 400-499 is
returned when the service was able to process the
transaction but the transaction resulted in an error.

401 ClientUnauthorized
:Client is not authorized to perform specified request

404 NotFound
:The requested object could not be found.

409 AlreadyExists
:The requested object already exists.

###Failure Response Codes

A response code in the range 500-599 is
returned when the service was unable to process the
transaction but the transaction due to an internal
failure.

500 ServerInternal
:An internal error occurred at the server

503 ServerOverload
:The server cannot handle the request as it is overloaded

##Imported Objects

The Mesh Service protocol makes use of JSON objects
defined in the JOSE Signatgure and Encryption specifications.

##Common Structures

The following common structures are used in the protocol
messages:

###Structure: Version

Describes a protocol version.


Major: Integer (Optional)

:Major version number of the service protocol. A higher

Minor: Integer (Optional)

:Minor version number of the service protocol.

Encodings: Encoding [0..Many]

:Enumerates alternative encodings (e.g. ASN.1, XML, JSON-B)
supported by the service. If no encodings are specified, the
JSON encoding is assumed.

URI: String [0..Many]

:The preferred URI for this service. This MAY be used to effect
a redirect in the case that a service moves.

###Structure: Encoding

Describes a message content encoding.


ID: String [0..Many]

:The IANA encoding name

Dictionary: String [0..Many]

:For encodings that employ a named dictionary for tag or data
compression, the name of the dictionary as defined by that 
encoding scheme. 	

###Structure: KeyValue

Describes a Key/Value structure used to make queries
for records matching one or more selection criteria.


Key: String (Optional)

:The data retrieval key.

Value: String (Optional)

:The data value to match.

###Structure: SearchConstraints

Specifies constraints to be applied to a search result. These 
allow a client to limit the number of records returned, the quantity
of data returned, the earliest and latest data returned, etc.


NotBefore: DateTime (Optional)

:Only data published on or after the specified time instant 
is requested.

Before: DateTime (Optional)

:Only data published before the specified time instant is
requested. This excludes data published at the specified time instant.

MaxEntries: Integer (Optional)

:Maximum number of data entries to return.

MaxBytes: Integer (Optional)

:Maximum number of data bytes to return.

PageKey: String (Optional)

:Specifies a page key returned in a previous search operation
in which the number of responses exceeded the specified bounds.

:When a page key is specified, all the other search parameters
except for MaxEntries and MaxBytes are ignored and the service
returns the next set of data responding to the earlier query.

##Transaction: Hello

Request: HelloRequest

Response:HelloResponse

Report service and version information. 

The Hello transaction provides a means of determining which protocol
versions, message encodings and transport protocols are supported by
the service.

###Message: HelloRequest

* Inherits: MeshRequest

[None]

###Message: HelloResponse

Always reports success. Describes the configuration of the Mesh
portal service.

* Inherits: MeshResponse


Version: Version (Optional)

:Enumerates the protocol versions supported

Alternates: Version [0..Many]

:Enumerates alternate protocol version(s) supported

##Transaction: ValidateAccount

Request: ValidateRequest

Response:ValidateResponse

Request validation of a proposed name for a new account.

For validation of a user's account name during profile creation.

###Message: ValidateRequest

* Inherits: MeshRequest

Describes the proposed account properties. Currently, these are limited
to the account name but could be extended in future versions of the protocol.


Account: String (Optional)

:Account name requested

Reserve: Boolean (Optional)

:If true, request a reservation for the specified account name.
Note that the service is not obliged to honor reservation 
requests.

Language: String [0..Many]

:List of ISO language codes in order of preference. For creating
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


Valid: Boolean (Optional)

:If true, the specified account identifier is acceptable. If false,
the account identifier is rejected.

Minimum: Integer (Optional)

:Specifies the minimum length of an account name.

Maximum: Integer (Optional)

:Specifies the maximum length of an account name.

InvalidCharacters: String (Optional)

:A list of characters that the service 
does not accept in account names. The list of characters 
MAY not be exhaustive but SHOULD include any illegal characters
in the proposed account name.

Reason: String (Optional)

:Text explaining the reason an account name was rejected.

##Transaction: CreateAccount

Request: CreateRequest

Response:CreateResponse

Request creation of a new portal account.

Unlike a profile, a mesh account is specific to a particular 
Mesh portal. A mesh account must be created and accepted before
a profile can be published.

###Message: CreateRequest

Request creation of a new portal account. The request specifies
the requested account identifier and the Mesh profile to be associated 
with the account.

* Inherits: MeshRequest


Account: String (Optional)

:Account identifier requested.

###Message: CreateResponse

* Inherits: MeshResponse

Reports the success or failure of a Create transaction.

[None]

##Transaction: Get

Request: GetRequest

Response:GetResponse

Search for data in the mesh that matches a set of properties
described by a sequence of key/value pairs.

###Message: GetRequest

Describes the Portal or Mesh data to be retreived.

* Inherits: MeshRequest


Identifier: String (Optional)

:Lookup by profile ID

Account: String (Optional)

:Lookup by Account ID

KeyValues: KeyValue [0..Many]

:List of KeyValue pairs specifying the conditions to be met

SearchConstraints: SearchConstraints (Optional)

:Constrain the search to a specific time interval and/or 
limit the number and/or total size of data records returned.

Multiple: Boolean (Optional)

:If true return multiple responses if available

Full: Boolean (Optional)

:If true, the client requests that the full Mesh data record be 
returned containing both the Mesh entry itself and the Mesh
metadata that allows the date and time of the publication of
the Mesh entry to be verified.

###Message: GetResponse

Reports the success or failure of a Get transaction. If a Mesh entry
matching the specified profile is found, containsthe list of entries
matching the request.

* Inherits: MeshResponse


DataItems: DataItem [0..Many]

:List of mesh data records matching the request.

PageKey: String (Optional)

:If non-null, indicates that the number and/or size of the data records
returned exceeds either the SearchConstraints specified in the
request or internal server limits.

##Transaction: Publish

Request: PublishRequest

Response:PublishResponse

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

Response:StatusResponse

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


LastWriteTime: DateTime (Optional)

:Time that the last write update was made to the Mesh

LastCheckpointTime: DateTime (Optional)

:Time that the last Mesh checkpoint was calculated.

NextCheckpointTime: DateTime (Optional)

:Time at which the next Mesh checkpoint should be calculated.

CheckpointValue: String (Optional)

:Last checkpoint value.

##Transaction: ConnectStart

Request: ConnectStartRequest

Response:ConnectStartResponse

Request connection of a new device to a mesh profile

###Message: ConnectStartRequest

* Inherits: MeshRequest

Initial device connection request.


SignedRequest: SignedConnectionRequest (Optional)

:Device connection request signed by thesignature key of the 
device requesting connection.

AccountID: String (Optional)

:Account identifier of account to which the device is requesting
connection.

###Message: ConnectStartResponse

Reports the success or failure of a ConnectStart transaction.

* Inherits: MeshRequest

[None]

##Transaction: ConnectStatus

Request: ConnectStatusRequest

Response:ConnectStatusResponse

Request status of pending connection request of a new device 
to a mesh profile

###Message: ConnectStatusRequest

* Inherits: MeshRequest

Request status information for a pending request posted
previously.


AccountID: String (Optional)

:Account identifier for which pending connection information
is requested.

DeviceID: String (Optional)

:Device identifier of device requesting status information.

###Message: ConnectStatusResponse

Reports the success or failure of a ConnectStatus transaction.

* Inherits: MeshRequest


Result: SignedConnectionResult (Optional)

:The signed ConnectionResult object.

##Transaction: ConnectPending

Request: ConnectPendingRequest

Response:ConnectPendingResponse

Request a list of pending requests for an administration profile.

###Message: ConnectPendingRequest

* Inherits: MeshRequest

Specify the criteria for pending requests.


AccountID: String (Optional)

:The account identifier of the account for which
pending connection requests are requested.

SearchConstraints: SearchConstraints (Optional)

:Constrain the search to a specific time interval and/or 
limit the number and/or total size of data records returned.

###Message: ConnectPendingResponse

Reports the success or failure of a ConnectPending transaction.

* Inherits: MeshRequest


Pending: SignedConnectionRequest [0..Many]

:A list of pending requests satisfying the criteria set out
in the request.

PageKey: String (Optional)

:If non-null, indicates that the number and/or size of the data records
returned exceeds either the SearchConstraints specified in the
request or internal server limits.

##Transaction: ConnectComplete

Request: ConnectCompleteRequest

Response:ConnectCompleteResponse

Post response to a pending connection request.

###Message: ConnectCompleteRequest

Reports the success or failure of a ConnectComplete transaction.

* Inherits: MeshRequest


Result: SignedConnectionResult (Optional)

:The connection result to be posted to the portal. The result MUST
be signed by a valid administration key for the Mesh profile.

AccountID: String (Optional)

:The account identifier to which the connection result is
posted.

###Message: ConnectCompleteResponse

* Inherits: MeshRequest

Reports the success or failure of a ConnectComplete transaction.

[None]

##Transaction: Transfer

Request: TransferRequest

Response:TransferResponse

Request a bulk transfer of the log between the specified transaction
identifiers. Requires appropriate authorization

[Not currently implemented]

###Message: TransferRequest



* Inherits: MeshRequest


SearchConstraints: SearchConstraints (Optional)

:Constrain the search to a specific time interval and/or 
limit the number and/or total size of data records returned.

###Message: TransferResponse

* Inherits: MeshResponse

Reports the success or failure of a Transfer transaction.
If successful, contains the list of Mesh records to be transferred.


DataItems: DataItem [0..Many]

:List of mesh data records matching the request.

PageKey: String (Optional)

:If non-null, indicates that the number and/or size of the data records
returned exceeds either the SearchConstraints specified in the
request or internal server limits.

