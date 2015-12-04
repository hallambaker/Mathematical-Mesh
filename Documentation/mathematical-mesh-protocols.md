// This file was converted using RFCTool
<ietf>draft-hallambaker-mathematical-mesh-protocols
<title>Mathematical Mesh: Client-Service Protocol
<abbrev>Mathematical Mesh CSP
<version>00

<ipr>trust200902
<area>Security
<publisher>Internet Engineering Task Force (IETF)
<status>Standards Track

<category>Standards Track
<author>Phillip Hallam-Baker    
    <fullname>Phillip Hallam-Baker    
    <initials>P. M.    
    <organization>Comodo Group Inc.    
    <surname>Phillip    
    <email>philliph@comodo.com


#Abstract

The Mathematical Mesh ‘The Mesh’ is an end-to-end secure infrastructure
that facilitates the exchange of configuration and credential data
between multiple user devices. The core protocols of the Mesh are described
with examples of common use cases and reference data.

#Introduction

#Definitions

##Requirements Language



The key words "MUST", "MUST NOT", "REQUIRED", "SHALL", "SHALL NOT",
"SHOULD", "SHOULD NOT", "RECOMMENDED", "MAY", and "OPTIONAL" in this document
are to be interpreted as described in RFC 2119 [RFC2119].

#Use Scenarios

##Service Discovery

##Create Account

##Connect Device

##Add Application

##Update Application

##Delete Device

##Master Profile Recovery

##Application Profile Recovery

#Mesh Client-Service Protocol Messages

#MeshProtocol 

##MeshProtocol Transactions 

###Transaction: Hello 

Report service and version information.  

The Hello transaction provides a means of determining which protocol
versions, message encodings and transport protocols are supported by  the
service. 

###Transaction: ValidateAccount 

Request validation of a proposed name for a new account. 

For validation of a user's account name during profile creation. 

###Transaction: CreateAccount 

Request creation of a new mesh account. 

Unlike a profile, a mesh account is specific to a particular  Mesh
portal. A mesh account must be created and accepted before a profile can be
published. 

###Transaction: Publish 

Publish a profile or key escrow entry to the mesh. 

###Transaction: Get 

Search for data in the mesh that matches a set of keys. 

###Transaction: GetRecords 

###Transaction: Transfer 

Request a bulk transfer of the log between the specified transaction
identifiers. Requires appropriate authorization 

[Not currently implemented] 

###Transaction: Status 

Request the current status of the mesh as seen by the portal to which it
is directed. 

The response to the status request contains the last signed checkpoint
and proof chains for each of the peer portals that have been checkpointed.


[Not currently implemented] 

###Transaction: ConnectStart 

Request connection of a new device to a mesh profile 

###Transaction: ConnectStatus 

Request status of pending connection request of a new device  to a mesh
profile 

###Transaction: ConnectPending 

Request status of pending connection request of a new device  to a mesh
profile 

###Transaction: ConnectComplete 

Request status of pending connection request of a new device  to a mesh
profile 

##MeshProtocol Messages 

###Message: MeshRequest 

[None] 

###Message: MeshResponse 

[None] 

###Message: HelloRequest 

[None] 

###Message: HelloResponse 

Enumerates the protocol versions supported 

Enumerates alternate protocol version(s) supported 

###Message: ValidateRequest 

Account name requested 

If true, request a reservation for the specified account name. Note that
the service is not obliged to honor reservation  requests. 

List of ISO language codes in order of preference. For creating
explanatory text. 

###Message: ValidateResponse 

[TBS] 

[TBS] 

A list of characters from the requested account that the service  does
not accept in account names. 

Text explaining the reason an account name was rejected. 

###Message: CreateRequest 

Account name requested 

###Message: CreateResponse 

[None] 

###Message: PublishRequest 

[None] 

###Message: PublishResponse 

[None] 

###Message: GetRequest 

Lookup by profile ID 

Lookup by Account ID 

List of KeyValue pairs specifying the conditions to be met 

[TBS] 

[TBS] 

If true return multiple responses if available 

###Message: GetResponse 

[None] 

###Message: GetRecordsResponse 

List of mesh data records matching the request. 

###Message: TransferRequest 

###Message: TransferResponse 

[None] 

###Message: StatusRequest 

[None] 

###Message: StatusResponse 

Time that the last write update was made to the Mesh 

Time that the last Mesh checkpoint was calculated. 

Time at which the next Mesh checkpoint should be calculated. 

Last checkpoint value. 

###Message: ConnectStartRequest 

###Message: ConnectStartResponse 

###Message: ConnectStatusRequest 

###Message: ConnectStatusResponse 

###Message: ConnectPendingRequest 

###Message: ConnectPendingResponse 

###Message: ConnectCompleteRequest 

###Message: ConnectCompleteResponse 

[None] 

##MeshProtocol Structures 

###Structure: Version 

Major version number of the service protocol. A higher 

Minor version number of the service protocol. 

Enumerates alternative encodings (e.g. ASN.1, XML, JSON-B) if supported
by the server 

The preferred URI for this service. This MAY be used to effect a
redirect in the case that a service moves. 

###Structure: Encoding 

The IANA encoding name 

For encodings that employ a named dictionary for tag or data
compression, the name of the dictionary as defined by that  encoding scheme.  

###Structure: KeyValue 

[TBS] 

[TBS] 

#Mesh Client-Service Protocol State Transitions

#Security Considerations

##Service Confidentiality

#IANA Considerations

IANA has registered the following protocol identifier for use with this
protocol: MMM

#Appendix A: Portal Schema.
