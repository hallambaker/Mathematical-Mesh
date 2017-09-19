

#Mesh/Confirm Service

The Mesh/Confirm confirmation service is a two party protocol. An 
Enquirer requests a response from the 

SRV Prefix:

:_Confirm._tcp

HTTP Well Known Service Prefix:

:/.well-known/confirm

Every Confirm Service transaction consists of exactly one
request followed by exactly one response.

There is no set sequence
in which operations are required to be performed. It is not
necessary to perform a Hello transaction prior to
a CreateGroup, AddMember or any other transaction.

##Request Messages



###Message: ConfirmRequest

Base class for all request messages.


Portal: String (Optional)

:Name of the Mesh/Recrypt administration Service to which the request 
is directed.

##Response Messages



###Message: ConfirmResponse

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

The Recrypt Administration Sercice makes use of JSON objects
defined in the JOSE Signatgure and Encryption specifications.

##Common classes

The following classes are referenced at multiple points in the protocol.

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

##Utility Transactions

##Transaction: Hello

Request: HelloRequest

Response:HelloResponse

Report service and version information. 

The Hello transaction provides a means of determining which protocol
versions, message encodings and transport protocols are supported by
the service.

###Message: HelloRequest

* Inherits: ConfirmRequest

Request service description.

[None]

###Message: HelloResponse

* Inherits: ConfirmResponse

Always reports success. Describes the configuration of the service.


Version: Version (Optional)

:Enumerates the protocol versions supported

Alternates: Version [0..Many]

:Enumerates alternate protocol version(s) supported

##Enquirer Transactions

##Transaction: Enquire

Request: EnquireRequest

Response:EnquireResponse

Post a confirmation request to the broker.

###Message: EnquireRequest

* Inherits: ConfirmRequest




Request: JoseWebEncryption (Optional)

:Signed and optionally encrypted request message.

Responder: String (Optional)

:The Responder account the request is directed to.

Expire: DateTime (Optional)

:Date and time after which the Enquirer has no interest in
the request value. Note that a Broker MAY cancel requests
according to its own policy at any time.

EnquirerID: String (Optional)

:A unique identifier for the transaction generated by
the enquirer. This identifier MAY be used to reject duplicate
transactions by a broker or Requestor.

###Message: EnquireResponse

* Inherits: ConfirmResponse

Reports the success or failure of an Enquire transaction.


BrokerID: String (Optional)

:A unique identifier for the transaction generated by
the broker.

##Transaction: Status

Request: StatusRequest

Response:StatusResponse

Request status on a previously posted request

###Message: StatusRequest

* Inherits: ConfirmRequest

Reports the status or of an Enquire transaction.


Cancel: Boolean (Optional)

:If true, the broker is abandoning the request and it should
no longer be returned to the user as an active pending request.
This flag would typically be set true on the last polling attempt made 
before the Enquirer abandonds the request. It is therefore entirely
valid for a broker to return a Response value if the Cancel flag
is true.

BrokerID: String (Optional)

:The unique identifier for the transaction generated by
the broker and returned in the corresponding Enquire
transaction.

###Message: StatusResponse

* Inherits: ConfirmResponse

The result of a status request.


RequestStatus: String (Optional)

:The status value. Valid values are PENDING, BCANCEL, ECANCEL, REPLY,
REFUSED

Response: JoseWebEncryption (Optional)

:Signed and optionally encrypted response message.

##Responder Transactions

##Transaction: Pending

Request: PendingRequest

Response:PendingResponse

Request a list of pending transactions meeting the specified
selection criteria.

###Message: PendingRequest

* Inherits: ConfirmRequest

Request a list of pending requests for a specified account.


Responder: String (Optional)

:The Responder account the the list of pending requests is 
requested for.

MaxResponse: Integer (Optional)

:The maximum number of request entries to return.

BeforeId: String (Optional)

:Only send request entries posted prior to the specified
entry. 

AfterId: String (Optional)

:Only send request entries posted after the specified
entry. 

###Message: PendingResponse

* Inherits: ConfirmResponse

Contains a list of pending requests.


Entries: RequestEntry (Optional)

:List of pending requests.

###Structure: RequestEntry

Describes a pending request and associated information.


Request: JoseWebEncryption (Optional)

:Signed and optionally encrypted request message.

Responder: String (Optional)

:The Responder account the request is directed to.

Expire: DateTime (Optional)

:Date and time after which the Enquirer has no interest in
the request value. Note that a Broker MAY cancel requests
according to its own policy at any time.

EnquirerID: String (Optional)

:A unique identifier for the transaction generated by
the enquirer. This identifier MAY be used to reject duplicate
transactions by a broker or Requestor.		

BrokerID: String (Optional)

:The unique identifier for the transaction generated by
the broker and returned in the corresponding Enquire
transaction.

##Transaction: Respond

Request: RespondRequest

Response:RespondResponse

Respond to a confirmation request.

###Message: RespondRequest

* Inherits: ConfirmRequest

Respond to a confirmation request.


Response: JoseWebEncryption (Optional)

:Signed and optionally encrypted response message.

###Message: RespondResponse

* Inherits: ConfirmResponse

Reports the success or failure of a Respond transaction.

[None]

