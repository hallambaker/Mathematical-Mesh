

#Mesh/Recrypt/Admin Service

The Mesh/Recrypt administration service supports transactions to 
Add and Delete members from a group and to list all the members in a group.

<dt>SRV Prefix: _recrypt._tcp

<dt>HTTP Well Known Service Prefix: /.well-known/recrypt



Every Recrypt Service transaction consists of exactly one
request followed by exactly one response.

Mesh Service transactions MAY cause modification
of the data stored in the Mesh Portal or the Mesh itself
but do not cause changes to the connection state. The protocol
itself is thus idempotent. There is no set sequence
in which operations are required to be performed. It is not
necessary to perform a Hello transaction prior to
a CreateGroup, AddMember or any other transaction.

##Request Messages

A Mesh/Recrypt administration Service request consists of a payload object
that inherits from the MeshRequest class. When using the 
HTTP binding, the request MUST specify the portal DNS
address in the HTTP Host field. 

###Message: RecryptRequest

Base class for all request messages.

[No fields]

##Response Messages

A Mesh/Recrypt administration Service response consists of a payload object that
inherits from the MeshResponse class. When using the
HTTP binding, the response SHOULD
report the Status response code in the HTTP response 
message. However the response code returned in the
payload object MUST always be considered authoritative.

###Message: RecryptResponse

Base class for all response messages. Contains only the
status code and status description fields.

[No fields]

##Imported Objects

The Recrypt Administration Sercice makes use of JSON objects
defined in the JOSE Signatgure and Encryption specifications.

##Common classes

The following classes are referenced at multiple points in the protocol.

##Administrator Transactions

##Transaction: Hello

<dl>
<dt>Request:  HelloRequest
<dt>Response:  HelloResponse
</dl>

Report service and version information. 

The Hello transaction provides a means of determining which protocol
versions, message encodings and transport protocols are supported by
the service.

##Transaction: CreateGroup

<dl>
<dt>Request:  CreateGroupRequest
<dt>Response:  CreateGroupResponse
</dl>

Create a new recryption group.

###Message: CreateGroupRequest

<dl>
<dt>Inherits:  RecryptRequest
</dl>

Request creation of a recryption group. The only
request parameter describes the group to be created.

<dl>
<dt>RecryptionGroup: RecryptionGroup (Optional)
<dd>The Recryption Group to create	
</dl>
###Message: CreateGroupResponse

<dl>
<dt>Inherits:  RecryptResponse
</dl>

Reports the success or failure of a CreateGroup request. The
operation either succeeds or fails, there are no returned
parameters

[No fields]

##Transaction: UpdateGroup

<dl>
<dt>Request:  UpdateGroupRequest
<dt>Response:  UpdateGroupResponse
</dl>

Update the information describing a recryption group.

###Message: UpdateGroupRequest

<dl>
<dt>Inherits:  RecryptRequest
</dl>

Request an update to a recryption group. 

Note that the update 
process is currently limited to 'strike and replace'. This is 
likely to become cumbersome if groups with very large numbers 
of entries are being maintained. It is likely that a future 
version of the protocol will support update requests that
implement commonly occurring tasks such as updates to 
add a new encryption key, etc.

<dl>
<dt>RecryptionGroup: RecryptionGroup (Optional)
<dd>The Recryption Group to create	
</dl>
###Message: UpdateGroupResponse

<dl>
<dt>Inherits:  RecryptResponse
</dl>

Reports the success or failure of a UpdateGroup request. The
operation either succeeds or fails, there are no returned
parameters

[No fields]

##Transaction: GetGroup

<dl>
<dt>Request:  GetGroupRequest
<dt>Response:  GetGroupResponse
</dl>

Request a recryption group record.

###Message: GetGroupRequest

<dl>
<dt>Inherits:  RecryptRequest
</dl>

Obtain recryption group data

<dl>
<dt>GroupID: String (Optional)
<dd>The UDF fingerprint of the recryption group to add the member to.
</dl>
###Message: GetGroupResponse

<dl>
<dt>Inherits:  RecryptResponse
</dl>

Obtain recryption group response.

<dl>
<dt>RecryptionGroup: RecryptionGroup (Optional)
<dd>The Recryption Group to create	
</dl>
##Transaction: AddMember

<dl>
<dt>Request:  AddMemberRequest
<dt>Response:  AddMemberResponse
</dl>

Add a member or members to an existing recryption group.

###Message: AddMemberRequest

<dl>
<dt>Inherits:  RecryptRequest
</dl>

Add a member to a recryption group (not currently used)

<dl>
<dt>RecryptionGroup: String (Optional)
<dd>The UDF fingerprint of the recryption group to add the member to.
<dt>MemberEntry: MemberEntry [0..Many]
<dd>Describes the member(s) to add
</dl>
###Message: AddMemberResponse

<dl>
<dt>Inherits:  RecryptResponse
</dl>

Reports the success or failure of a AddMember request. The
operation either succeeds or fails, there are no returned
parameters

[No fields]

##Transaction: UpdateMember

<dl>
<dt>Request:  UpdateMemberRequest
<dt>Response:  UpdateMemberResponse
</dl>

Update a one or more member entries

This transaction may be used to make member entries inactive by 
posting REVOKED or SUSPENDED status to their member entry.

###Message: UpdateMemberRequest

<dl>
<dt>Inherits:  RecryptRequest
</dl>

Update a recryption group member entry (not currently used)

<dl>
<dt>RecryptionGroup: String (Optional)
<dd>The UDF fingerprint of the recryption group in which the member entries is to be updated
<dt>MemberEntry: MemberEntry [0..Many]
<dd>Describes the member(s) to add
</dl>
###Message: UpdateMemberResponse

<dl>
<dt>Inherits:  RecryptResponse
</dl>

Reports the success or failure of a UpdateMember request. The
operation either succeeds or fails, there are no returned
parameters

[No fields]

##Future work

At present the protocol does not provide a mechanism for 
modifying administrator privileges or requesting statistics
on use of recryption services. These are obviously important.
Whether these should be part of the base protocol or a separate
protocol is another matter.

#User Service

The only transaction supported by the user facing service at this point are the ability
to request a recryption operation and the ability to request a group encryption
key.

##Transaction: GetKey

<dl>
<dt>Request:  GetKeyRequest
<dt>Response:  GetKeyResponse
</dl>

Request that the service provide a recryption result for the specified
encrypted data and return it encrypted under the user's public key.

###Message: GetKeyRequest

<dl>
<dt>Inherits:  RecryptRequest
</dl>

Request the current recryption key for the specified recryption group.
NB: At present the group key is NOT authenticated and thus a MITM can
perform a key substituition attack. This will be fixed in the next 
release.

<dl>
<dt>GroupID: String (Optional)
<dd>The recryption group for which the key data is requested.
</dl>
###Message: GetKeyResponse

<dl>
<dt>Inherits:  RecryptResponse
</dl>

Response to get key request.

<dl>
<dt>SignedKey: JoseWebSignature (Optional)
<dd>The signed key entry
</dl>
##Transaction: RecryptData

<dl>
<dt>Request:  RecryptDataRequest
<dt>Response:  RecryptDataResponse
</dl>

Request that the service provide a recryption result for the specified
encrypted data and return it encrypted under the user's public key.

###Message: RecryptDataRequest

<dl>
<dt>Inherits:  RecryptRequest
</dl>

Request that the service provide a recryption result for the specified
encrypted data and return it encrypted under the user's public key.

<dl>
<dt>MemberUDF: String (Optional)
<dd>The member Mesh profile UDF
<dt>MemberKeyUDF: String (Optional)
<dd>The member key fingerprint
<dt>GroupKeyID: String (Optional)
<dd>The key identifier of the group key to which the data is encrypted
</dl>
###Message: RecryptDataResponse

<dl>
<dt>Inherits:  RecryptResponse
</dl>

Result of recryption request.

<dl>
<dt>Partial: Binary (Optional)
<dd>The partial decryption information to use to complete the key agreement
<dt>EncryptedPartial: JoseWebEncryption (Optional)
<dd>The partial decryption information to use to complete the key agreement encrypted
under the user's key.
<dt>DecryptionKey: JoseWebEncryption (Optional)
<dd>The decryption key to use to complete the decryption encrypted
under the user's key.
</dl>
