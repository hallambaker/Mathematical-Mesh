

<dt>SRV Prefix: _mmm._tcp

<dt>HTTP Well Known Service Prefix: /.well-known/mmm



Every Mesh Portal Service transaction consists of exactly one
request followed by exactly one response.
Mesh Service transactions MAY cause modification
of the data stored in the Mesh Service or the Mesh itself
but do not cause changes to the connection state. The protocol
itself is thus idempotent. There is no set sequence
in which operations are required to be performed. It is not
necessary to perform a Hello transaction prior to
any other transaction.

##Request Messages

A Mesh Portal Service request consists of a payload object
that inherits from the MeshRequest class. When using the 
HTTP binding, the request MUST specify the portal DNS
address in the HTTP Host field. 

###Message: MeshRequest

Base class for all request messages.

[No fields]

###Message: MeshRequestUser

Base class for all request messages made by a user.

<dl>
<dt>Inherits:  MeshRequest
</dl>

<dl>
<dt>Account: String (Optional)
<dd>The fully qualified account name (including DNS address) to which the
request is directed.
<dt>EnvelopedProfileDevice: Enveloped<ProfileDevice> (Optional)
<dd>Device profile of the device making the request.
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
defined in the JOSE Signatgure and Encryption specifications
and in the DARE Data At Rest Encryption extensions to JOSE.

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
###Structure: ConstraintsSelect

Specifies constraints to be applied to a search result. These 
allow a client to limit the number of records returned, the quantity
of data returned, the earliest and latest data returned, etc.

<dl>
<dt>Container: String (Optional)
<dd>The container to be searched.
<dt>IndexMin: Integer (Optional)
<dd>Only return objects with an index value that is equal to or
higher than the value specified.
<dt>IndexMax: Integer (Optional)
<dd>Only return objects with an index value that is equal to or
lower than the value specified.
<dt>NotBefore: DateTime (Optional)
<dd>Only data published on or after the specified time instant 
is requested.
<dt>Before: DateTime (Optional)
<dd>Only data published before the specified time instant is
requested. This excludes data published at the specified time instant.
<dt>PageKey: String (Optional)
<dd>Specifies a page key returned in a previous search operation
in which the number of responses exceeded the specified bounds.
<dd>When a page key is specified, all the other search parameters
except for MaxEntries and MaxBytes are ignored and the service
returns the next set of data responding to the earlier query.
</dl>
###Structure: ConstraintsData

Specifies constraints on the data to be sent.

<dl>
<dt>MaxEntries: Integer (Optional)
<dd>Maximum number of entries to send.
<dt>BytesOffset: Integer (Optional)
<dd>Specifies an offset to be applied to the payload data before it is sent. 
This allows large payloads to be transferred incrementally.
<dt>BytesMax: Integer (Optional)
<dd>Maximum number of payload bytes to send.
<dt>Header: Boolean (Optional)
<dd>Return the entry header
<dt>Payload: Boolean (Optional)
<dd>Return the entry payload
<dt>Trailer: Boolean (Optional)
<dd>Return the entry trailer
</dl>
###Structure: PolicyAccount

Describes the account creation policy including constraints on 
account names, whether there is an open account creation policy, etc.

<dl>
<dt>Minimum: Integer (Optional)
<dd>Specifies the minimum length of an account name.
<dt>Maximum: Integer (Optional)
<dd>Specifies the maximum length of an account name.
<dt>InvalidCharacters: String (Optional)
<dd>A list of characters that the service 
does not accept in account names. The list of characters 
MAY not be exhaustive but SHOULD include any illegal characters
in the proposed account name.
</dl>
###Structure: ContainerStatus

<dl>
<dt>Container: String (Optional)
<dt>Index: Integer (Optional)
<dt>Digest: Binary (Optional)
</dl>
###Structure: ContainerUpdate

<dl>
<dt>Inherits:  ContainerStatus
</dl>

<dl>
<dt>Envelopes: DareEnvelope [0..Many]
<dd>The entries to be uploaded. 
</dl>
##Transaction: Hello

<dl>
<dt>Request:  HelloRequest
<dt>Response:  MeshHelloResponse
</dl>

Report service and version information. 

The Hello transaction provides a means of determining which protocol
versions, message encodings and transport protocols are supported by
the service.

The PostConstraints field MAY be used to advise senders of a maximum
size of payload that MAY be sent in an initial Post request.

###Message: MeshHelloResponse

<dl>
<dt>ConstraintsUpdate: ConstraintsData (Optional)
<dd>Specifies the default data constraints for updates.
<dt>ConstraintsPost: ConstraintsData (Optional)
<dd>Specifies the default data constraints for message senders.
<dt>PolicyAccount: PolicyAccount (Optional)
<dd>Specifies the account creation policy
<dt>EnvelopedProfileService: Enveloped<ProfileService> (Optional)
<dd>The enveloped master profile of the service.
<dt>EnvelopedProfileHost: Enveloped<ProfileHost> (Optional)
<dd>The enveloped profile of the host.
</dl>
##Transaction: CreateAccount

<dl>
<dt>Request:  CreateRequest
<dt>Response:  CreateResponse
</dl>

Request creation of a new service account or group.

Attempt 

###Message: CreateRequest

Request binding of an account to a service address.

<dl>
<dt>Inherits:  MeshRequest
</dl>

<dl>
<dt>AccountAddress: String (Optional)
<dd>The service account to bind to.
<dt>EnvelopedProfileUser: Enveloped<ProfileUser> (Optional)
<dd>The signed assertion describing the account.
</dl>
###Message: CreateResponse

<dl>
<dt>Inherits:  MeshResponse
</dl>

Reports the success or failure of a Create transaction.

<dl>
<dt>Reason: String (Optional)
<dd>Text explaining the status of the creation request.
<dt>URL: String (Optional)
<dd>A URL to which the user is directed to complete the account creation 
request.
</dl>
##Transaction: DeleteAccount

<dl>
<dt>Request:  DeleteRequest
<dt>Response:  DeleteResponse
</dl>

Request deletion of a service account.

###Message: DeleteRequest

Request creation of a new portal account. The request specifies
the requested account identifier and the Mesh profile to be associated 
with the account.

<dl>
<dt>Inherits:  MeshRequestUser
</dl>

[No fields]

###Message: DeleteResponse

<dl>
<dt>Inherits:  MeshResponse
</dl>

Reports the success or failure of a Delete transaction.

[No fields]

##Transaction: Complete

<dl>
<dt>Request:  CompleteRequest
<dt>Response:  CompleteResponse
</dl>

###Message: CompleteRequest

<dl>
<dt>Inherits:  StatusRequest
</dl>

<dl>
<dt>AccountAddress: String (Optional)
<dt>ResponseID: String (Optional)
</dl>
###Message: CompleteResponse

<dl>
<dt>Inherits:  MeshResponse
</dl>

<dl>
<dt>EnvelopedRespondConnection: Enveloped<RespondConnection> (Optional)
<dd>The signed assertion describing the result of the connect request
</dl>
##Transaction: Status

<dl>
<dt>Request:  StatusRequest
<dt>Response:  StatusResponse
</dl>

###Message: StatusRequest

<dl>
<dt>Inherits:  MeshRequestUser
</dl>

<dl>
<dt>DeviceUDF: String (Optional)
<dt>ProfileMasterDigest: Binary (Optional)
<dt>Catalogs: String [0..Many]
<dt>Spools: String [0..Many]
</dl>
###Message: StatusResponse

<dl>
<dt>Inherits:  MeshResponse
</dl>

<dl>
<dt>EnvelopedProfileAccount: Enveloped<ProfileAccount> (Optional)
<dd>The account profile providing the root of trust for this account.
<dt>EnvelopedCatalogedDevice: Enveloped<CatalogedDevice> (Optional)
<dd>The catalog device entry
<dt>ContainerStatus: ContainerStatus [0..Many]
</dl>
##Transaction: Download

<dl>
<dt>Request:  DownloadRequest
<dt>Response:  DownloadResponse
</dl>

Request objects from the specified container with the specified search
criteria.

###Message: DownloadRequest

<dl>
<dt>Inherits:  MeshRequestUser
</dl>

Request objects from the specified container(s).

A client MAY request only objects matching specified search criteria
be returned and MAY request that only specific fields or parts of the 
payload be returned.

<dl>
<dt>Select: ConstraintsSelect [0..Many]
<dd>Specifies constraints to be applied to a search result. These 
allow a client to limit the number of records returned, the quantity
of data returned, the earliest and latest data returned, etc.
<dt>ConstraintsPost: ConstraintsData (Optional)
<dd>Specifies the data constraints to be applied to the responses.
</dl>
###Message: DownloadResponse

<dl>
<dt>Inherits:  MeshResponse
</dl>

Return the set of objects requested.

Services SHOULD NOT return a response that is disproportionately large
relative to the speed of the network connection without a clear indication
from the client that it is relevant. A service MAY limit the number of 
objects returned. A service MAY limit the scope of each response. 

<dl>
<dt>Updates: ContainerUpdate [0..Many]
<dd>The updated data
</dl>
##Transaction: Transact

<dl>
<dt>Request:  TransactRequest
<dt>Response:  TransactResponse
</dl>

Attempt an atomic transaction on the containers and spools associated with an account.

###Message: TransactRequest

<dl>
<dt>Inherits:  MeshRequestUser
</dl>

Upload entries to a container. This request is only valid if it is issued
by the owner of the account

<dl>
<dt>Updates: ContainerUpdate [0..Many]
<dd>The data to be updated
<dt>Accounts: String [0..Many]
<dd>The account(s) to which the request is directed.
<dt>Outbound: Enveloped<Message> [0..Many]
<dd>The messages to be sent to other accounts  
<dt>Inbound: Enveloped<Message> [0..Many]
<dd>Messages to be appended to the user's inbound spool. this is
typically used to post notifications to the user to mark messages as having been
read or responded to.
<dt>Local: Enveloped<Message> [0..Many]
<dd>Messages to be appended to the user's local spool. This is used to allow connecting
devices to collect activation messages before they have connected to the mesh.
</dl>
###Message: TransactResponse

<dl>
<dt>Inherits:  MeshResponse
</dl>

Response to an upload request. 

<dl>
<dt>Entries: EntryResponse [0..Many]
<dd>The responses to the entries.
<dt>ConstraintsData: ConstraintsData (Optional)
<dd>If the upload request contains redacted entries, specifies constraints 
that apply to the redacted entries as a group. Thus the total payloads
of all the messages must not exceed the specified value.
</dl>
###Structure: EntryResponse

<dl>
<dt>IndexRequest: Integer (Optional)
<dd>The index value of the entry in the request.
<dt>IndexContainer: Integer (Optional)
<dd>The index value assigned to the entry in the container.
<dt>Result: String (Optional)
<dd>Specifies the result of attempting to add the entry to a catalog
or spool. Valid values for a message are 'Accept', 'Reject'. Valid 
values for an entry are 'Accept', 'Reject' and 'Conflict'.
<dt>ConstraintsData: ConstraintsData (Optional)
<dd>If the entry was redacted, specifies constraints 
that apply to the redacted entries as a group. Thus the total payloads
of all the messages must not exceed the specified value.	
</dl>
##Transaction: Post

<dl>
<dt>Request:  PostRequest
<dt>Response:  PostResponse
</dl>

Request to post to a spool from an external party. The request and response
messages are extensions of the corresponding messages for the Upload transaction.
It is expected that additional fields will be added as the need arises.

###Message: PostRequest

<dl>
<dt>Inherits:  MeshRequest
</dl>



<dl>
<dt>Accounts: String [0..Many]
<dd>The account(s) to which the request is directed.
<dt>Messages: Enveloped<Message> [0..Many]
<dd>The messages to be sent to the addresses specified in Accounts. 
</dl>
###Message: PostResponse

<dl>
<dt>Inherits:  TransactResponse
</dl>



[No fields]

##Transaction: Connect

<dl>
<dt>Request:  ConnectRequest
<dt>Response:  ConnectResponse
</dl>

Request information necessary to begin making a connection request.

###Message: ConnectRequest

<dl>
<dt>Inherits:  MeshRequest
</dl>

<dl>
<dt>EnvelopedRequestConnection: Enveloped<RequestConnection> (Optional)
<dd>The connection request generated by the client 
<dt>Rights: String [0..Many]
<dd>List of named access rights.
</dl>
###Message: ConnectResponse

<dl>
<dt>Inherits:  MeshResponse
</dl>

<dl>
<dt>EnvelopedAcknowledgeConnection: Enveloped<AcknowledgeConnection> (Optional)
<dd>The connection request generated by the client
<dt>EnvelopedProfileUser: Enveloped<ProfileUser> (Optional)
<dd>The user profile that provides the root of trust for this Mesh
</dl>
##Transaction: Claim

<dl>
<dt>Request:  ClaimRequest
<dt>Response:  ClaimResponse
</dl>

Claim a publication

###Message: ClaimRequest

<dl>
<dt>Inherits:  MeshRequest
</dl>

<dl>
<dt>EnvelopedMessageClaim: Enveloped<MessageClaim> (Optional)
<dd>The claim message
</dl>
###Message: ClaimResponse

<dl>
<dt>Inherits:  MeshResponse
</dl>

<dl>
<dt>CatalogedPublication: CatalogedPublication (Optional)
<dd>The encrypted device profile
</dl>
##Transaction: PollClaim

<dl>
<dt>Request:  PollClaimRequest
<dt>Response:  PollClaimResponse
</dl>

Check party making claim

###Message: PollClaimRequest

<dl>
<dt>Inherits:  MeshRequest
</dl>

<dl>
<dt>PublicationId: String (Optional)
<dd>The envelope identifier formed from the PublicationId.
<dt>TargetAccountAddress: String (Optional)
<dd>Account to which the claim is directed
</dl>
###Message: PollClaimResponse

<dl>
<dt>Inherits:  MeshResponse
</dl>

<dl>
<dt>EnvelopedMessage: Enveloped<Message> (Optional)
<dd>The claim message
</dl>
##Transaction: CreateGroup

<dl>
<dt>Request:  CreateGroupRequest
<dt>Response:  CreateGroupResponse
</dl>

Check party making claim

###Message: CreateGroupRequest

<dl>
<dt>Inherits:  MeshRequest
</dl>

<dl>
<dt>AccountAddress: String (Optional)
<dd>The service account to bind to.
<dt>EnvelopedProfileGroup: Enveloped<ProfileGroup> (Optional)
<dd>The persistent profile that will be used to validate changes to the
account assertion.
</dl>
###Message: CreateGroupResponse

<dl>
<dt>Inherits:  CreateResponse
</dl>

[No fields]

###Structure: CryptographicOperation

<dl>
<dt>KeyId: String (Optional)
<dd>The key identifier			
<dt>KeyCoefficient: Binary (Optional)
<dd>Lagrange coefficient multiplier to be applied to the private key
</dl>
###Structure: CryptographicOperationSign

<dl>
<dt>Inherits:  CryptographicOperation
</dl>

<dl>
<dt>Data: Binary (Optional)
<dd>The data to sign
<dt>PartialR: Binary (Optional)
<dd>Contribution to the R offset.
</dl>
###Structure: CryptographicOperationKeyAgreement

<dl>
<dt>Inherits:  CryptographicOperation
</dl>

[No fields]

###Structure: CryptographicOperationGenerate

<dl>
<dt>Inherits:  CryptographicOperation
</dl>

[No fields]

###Structure: CryptographicOperationShare

<dl>
<dt>Inherits:  CryptographicOperation
</dl>

<dl>
<dt>Threshold: Integer (Optional)
<dt>Shares: Integer (Optional)
</dl>
###Structure: CryptographicResult

<dl>
<dt>Error: String (Optional)
</dl>
###Structure: CryptographicResultKeyAgreement

<dl>
<dt>Inherits:  CryptographicResult
</dl>

[No fields]

##Transaction: Operate

<dl>
<dt>Request:  OperateRequest
<dt>Response:  OperateResponse
</dl>

Perform a set of cryptographic operations

###Message: OperateRequest

<dl>
<dt>Inherits:  MeshRequest
</dl>

<dl>
<dt>AccountAddress: String (Optional)
<dd>The service account the capability is bound to
</dl>
###Message: OperateResponse

<dl>
<dt>Inherits:  MeshResponse
</dl>

[No fields]

