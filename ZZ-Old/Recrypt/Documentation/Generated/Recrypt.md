

#Recrypt Service Reference

SRV Prefix:

:_meshrecrypt._tcp

HTTP Well Known Service Prefix:

:/.well-known/meshrecrypt

TBS

##Request Messages

A Mesh/Recrypt request consists of a payload object
that inherits from the RecryptRequest class. When using the 
HTTP binding, the request MUST specify the portal DNS
address in the HTTP Host field. 

###Message: RecryptRequest

Base class for all request messages.


Portal: String (Optional)

:Name of the Mesh/Recrypt  Service to which the request 
is directed.

##Response Messages

A Mesh/Recrypt response consists of a payload object that
inherits from the RecryptResponse class. When using the
HTTP binding, the response SHOULD
report the Status response code in the HTTP response 
message. However the response code returned in the
payload object MUST always be considered authoritative.

###Message: RecryptResponse

Base class for all response messages. Contains only the
status code and status description fields.

A service MAY return either the response message specified
for that transaction or any parent of that message. 
Thus the RecryptResponse message MAY be returned in response 
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

[201] SuccessOK
:Operation completed successfully

[201] SuccessCreated
:Operation completed successfully, new data item created

[202] SuccessUpdated
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

[303] RedirectPermanent
:Service has been permanently moved

[307] RedirectTemporary
:Service has been temporarily moved

###Error Response Codes

A response code in the range 400-499 is
returned when the service was able to process the
transaction but the transaction resulted in an error.

[401] ClientUnauthorized
:Client is not authorized to perform specified request

[404] NotFound
:The requested object could not be found.

[409] AlreadyExists
:The requested object already exists.

###Failure Response Codes

A response code in the range 500-599 is
returned when the service was unable to process the
transaction but the transaction due to an internal
failure.

[500] ServerInternal
:An internal error occurred at the server

[503] ServerOverload
:The server cannot handle the request as it is overloaded

##Imported Objects

The Mesh/Remesh Service protocol makes use of JSON objects
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

###Structure: Resource


Identifier: String (Optional)

###Structure: Static

* Inherits: Resource

[None]

###Structure: Dynamic

* Inherits: Resource

[None]

###Structure: ResourceSet

* Inherits: Resource

[None]

###Structure: User

* Inherits: Resource


Account: String (Optional)

###Structure: Label

* Inherits: Resource

[None]

###Structure: KeySet

* Inherits: Resource


Account: String (Optional)

Administrators: User [0..Many]

Readers: User [0..Many]

##Transaction: Hello

Request: HelloRequest

Response:HelloResponse

Report service and version information. 

The Hello transaction provides a means of determining which protocol
versions, message encodings and transport protocols are supported by
the service.

###Message: HelloRequest

* Inherits: RecryptRequest



[None]

###Message: HelloResponse

* Inherits: RecryptResponse

Always reports success. Describes the configuration of the Mesh
portal service.


Version: Version (Optional)

:Enumerates the protocol versions supported

Alternates: Version [0..Many]

:Enumerates alternate protocol version(s) supported

##Transaction: Set

Request: SetRequest

Response:SetResponse

###Message: SetRequest

* Inherits: RecryptRequest



[None]

###Message: SetResponse

* Inherits: RecryptResponse


[None]

##Transaction: Get

Request: GetRequest

Response:GetResponse

###Message: GetRequest

* Inherits: RecryptRequest



[None]

###Message: GetResponse

* Inherits: RecryptResponse


[None]

##Transaction: Delete

Request: DeleteRequest

Response:DeleteResponse

###Message: DeleteRequest

* Inherits: RecryptRequest



[None]

###Message: DeleteResponse

* Inherits: RecryptResponse


[None]

##Transaction: Select

Request: SearchRequest

Response:SearchResponse

###Message: SearchRequest

* Inherits: RecryptRequest



[None]

###Message: SearchResponse

* Inherits: RecryptResponse


[None]

##Transaction: Join

Request: JoinRequest

Response:JoinResponse

###Message: JoinRequest

* Inherits: RecryptRequest



[None]

###Message: JoinResponse

* Inherits: RecryptResponse


[None]

##Transaction: Leave

Request: LeaveRequest

Response:LeaveResponse

###Message: LeaveRequest

* Inherits: RecryptRequest



[None]

###Message: LeaveResponse

* Inherits: RecryptResponse


[None]

