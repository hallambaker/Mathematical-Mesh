#MeshProtocol

##MeshProtocol Transactions

###Transaction: Hello

*Request: HelloRequest

*Response: HelloResponse

Report service and version information. 

The Hello transaction provides a means of determining which protocol
versions, message encodings and transport protocols are supported by
the service.

###Transaction: ValidateAccount

*Request: ValidateRequest

*Response: ValidateResponse

Request validation of a proposed name for a new account.

For validation of a user's account name during profile creation.

###Transaction: CreateAccount

*Request: CreateRequest

*Response: CreateResponse

Request creation of a new mesh account.

Unlike a profile, a mesh account is specific to a particular 
Mesh portal. A mesh account must be created and accepted before
a profile can be published.

###Transaction: Publish

*Request: PublishRequest

*Response: PublishResponse

Publish a profile or key escrow entry to the mesh.

###Transaction: Get

*Request: GetRequest

*Response: GetResponse

Search for data in the mesh that matches a set of keys.

###Transaction: GetRecords

*Request: GetRequest

*Response: GetRecordsResponse

###Transaction: Transfer

*Request: TransferRequest

*Response: TransferResponse

Request a bulk transfer of the log between the specified transaction
identifiers. Requires appropriate authorization

[Not currently implemented]

###Transaction: Status

*Request: StatusRequest

*Response: StatusResponse

Request the current status of the mesh as seen by the portal to which it
is directed.

The response to the status request contains the last signed checkpoint
and proof chains for each of the peer portals that have been checkpointed.

[Not currently implemented]

###Transaction: ConnectStart

*Request: ConnectStartRequest

*Response: ConnectStartResponse

Request connection of a new device to a mesh profile

###Transaction: ConnectStatus

*Request: ConnectStatusRequest

*Response: ConnectStatusResponse

Request status of pending connection request of a new device 
to a mesh profile

###Transaction: ConnectPending

*Request: ConnectPendingRequest

*Response: ConnectPendingResponse

Request status of pending connection request of a new device 
to a mesh profile

###Transaction: ConnectComplete

*Request: ConnectCompleteRequest

*Response: ConnectCompleteResponse

Request status of pending connection request of a new device 
to a mesh profile

##MeshProtocol Messages

###Message: MeshRequest

Minimal request. Contains no parameters.

[None]

###Message: MeshResponse

Minimal response. Contains only the status value and
description.


:Status :
::Integer [0..1]   

Status return code. The SMTP/HTTP scheme of 2xx = Success,
3xx = incomplete, 4xx = failure is followed.

:StatusDescription :
::String [0..1]   

Text description of the status return code for debugging 
and log file use.

###Message: HelloRequest

[None]

###Message: HelloResponse


:Status :
::Integer [0..1]   

Status return code. The SMTP/HTTP scheme of 2xx = Success,
3xx = incomplete, 4xx = failure is followed.

:StatusDescription :
::String [0..1]   

Text description of the status return code for debugging 
and log file use.

:Version :
::Version [0..1]   

Enumerates the protocol versions supported

:Alternates :
::Version [0..Many]   

Enumerates alternate protocol version(s) supported

###Message: ValidateRequest


:Account :
::String [0..1]   

Account name requested

:Reserve :
::Boolean [0..1]   

If true, request a reservation for the specified account name.
Note that the service is not obliged to honor reservation 
requests.

:Language :
::String [0..Many]   

List of ISO language codes in order of preference. For creating
explanatory text.

###Message: ValidateResponse


:Status :
::Integer [0..1]   

Status return code. The SMTP/HTTP scheme of 2xx = Success,
3xx = incomplete, 4xx = failure is followed.

:StatusDescription :
::String [0..1]   

Text description of the status return code for debugging 
and log file use.

:Valid :
::Boolean [0..1]   

[TBS]

:Minimum :
::Integer [0..1]   

[TBS]

:InvalidCharacters :
::String [0..1]   

A list of characters from the requested account that the service 
does not accept in account names.

:Reason :
::String [0..1]   

Text explaining the reason an account name was rejected.

###Message: CreateRequest


:Account :
::String [0..1]   

Account name requested

###Message: CreateResponse


:Status :
::Integer [0..1]   

Status return code. The SMTP/HTTP scheme of 2xx = Success,
3xx = incomplete, 4xx = failure is followed.

:StatusDescription :
::String [0..1]   

Text description of the status return code for debugging 
and log file use.

###Message: PublishRequest

[None]

###Message: PublishResponse


:Status :
::Integer [0..1]   

Status return code. The SMTP/HTTP scheme of 2xx = Success,
3xx = incomplete, 4xx = failure is followed.

:StatusDescription :
::String [0..1]   

Text description of the status return code for debugging 
and log file use.

###Message: GetRequest


:Identifier :
::String [0..1]   

Lookup by profile ID

:Account :
::String [0..1]   

Lookup by Account ID

:KeyValues :
::KeyValue [0..Many]   

List of KeyValue pairs specifying the conditions to be met

:NotBefore :
::DateTime [0..1]   

[TBS]

:NotOnOrAfter :
::DateTime [0..1]   

[TBS]

:Multiple :
::Boolean [0..1]   

If true return multiple responses if available

###Message: GetResponse


:Status :
::Integer [0..1]   

Status return code. The SMTP/HTTP scheme of 2xx = Success,
3xx = incomplete, 4xx = failure is followed.

:StatusDescription :
::String [0..1]   

Text description of the status return code for debugging 
and log file use.

###Message: GetRecordsResponse


:Status :
::Integer [0..1]   

Status return code. The SMTP/HTTP scheme of 2xx = Success,
3xx = incomplete, 4xx = failure is followed.

:StatusDescription :
::String [0..1]   

Text description of the status return code for debugging 
and log file use.

:DataItems :
::DataItem [0..Many]   

List of mesh data records matching the request.

###Message: TransferRequest


:NotBefore :
::DateTime [0..1]   


:Until :
::DateTime [0..1]   


:After :
::String [0..1]   


:MaxEntries :
::Integer [0..1]   


:MaxBytes :
::Integer [0..1]   


###Message: TransferResponse


:Status :
::Integer [0..1]   

Status return code. The SMTP/HTTP scheme of 2xx = Success,
3xx = incomplete, 4xx = failure is followed.

:StatusDescription :
::String [0..1]   

Text description of the status return code for debugging 
and log file use.

###Message: StatusRequest

[None]

###Message: StatusResponse


:Status :
::Integer [0..1]   

Status return code. The SMTP/HTTP scheme of 2xx = Success,
3xx = incomplete, 4xx = failure is followed.

:StatusDescription :
::String [0..1]   

Text description of the status return code for debugging 
and log file use.

:LastWriteTime :
::DateTime [0..1]   

Time that the last write update was made to the Mesh

:LastCheckpointTime :
::DateTime [0..1]   

Time that the last Mesh checkpoint was calculated.

:NextCheckpointTime :
::DateTime [0..1]   

Time at which the next Mesh checkpoint should be calculated.

:CheckpointValue :
::String [0..1]   

Last checkpoint value.

###Message: ConnectStartRequest




:SignedRequest :
::SignedConnectionRequest [0..1]   



:AccountID :
::String [0..1]   



###Message: ConnectStartResponse




:SignedConnectionResult :
::String [0..1]   



###Message: ConnectStatusRequest




:AccountID :
::String [0..1]   



:DeviceID :
::String [0..1]   



###Message: ConnectStatusResponse




:Result :
::SignedConnectionResult [0..1]   



###Message: ConnectPendingRequest




:AccountID :
::String [0..1]   



###Message: ConnectPendingResponse




:Pending :
::SignedConnectionRequest [0..Many]   



###Message: ConnectCompleteRequest




:Result :
::SignedConnectionResult [0..1]   



:AccountID :
::String [0..1]   



###Message: ConnectCompleteResponse



[None]

##MeshProtocol Structures

###Structure: Version


:Major :
::Integer [0..1]   

Major version number of the service protocol. A higher

:Minor :
::Integer [0..1]   

Minor version number of the service protocol.

:Encodings :
::Encoding [0..Many]   

Enumerates alternative encodings (e.g. ASN.1, XML, JSON-B) if
supported by the server

:URI :
::String [0..Many]   

The preferred URI for this service. This MAY be used to effect
a redirect in the case that a service moves.

###Structure: Encoding


:ID :
::String [0..Many]   

The IANA encoding name

:Dictionary :
::String [0..Many]   

For encodings that employ a named dictionary for tag or data
compression, the name of the dictionary as defined by that 
encoding scheme. 			

###Structure: KeyValue


:Key :
::String [0..1]   

[TBS]

:Value :
::String [0..1]   

[TBS]

