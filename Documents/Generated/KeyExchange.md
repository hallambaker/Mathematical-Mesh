

#Key Exchange Service

Supports key exchange to establish a shared secret and bound ticket
between a client and a service

<dt>SRV Prefix: _jwcexchange._tcp

<dt>HTTP Well Known Service Prefix: /.well-known/jwcexchange



Every Recrypt Service transaction consists of exactly one
request followed by exactly one response.

##Shared classes

###Structure: Algorithms

<dl>
<dt>Encryption: String [0..Many]
<dd>Algorithm identifiers of encryption and authenticated encryption algorithms offered
<dt>Authentication: String [0..Many]
<dd>Authentication algorithm offer
</dl>
##Utility Transactions

##Transaction: Exchange

<dl>
<dt>Request:  ExchangeRequest
<dt>Response:  ExchangeResponse
</dl>

Perform Key Exchange to establish shared key bound to a ticket. 

###Message: ExchangeRequest

Initiate the key exchange request.

<dl>
<dt>Offer: Algorithms [0..Many]
<dd>Set of message authentication and encryption algorithms offered by the client
</dl>
###Message: ExchangeResponse

Returns the server parameters.

<dl>
<dt>Ticket: Binary (Optional)
<dd>Opaque session identifier.
<dt>Witness: Binary (Optional)
<dd>Opaque witness value used to prove binding to the ticket.
<dt>Encryption: String [0..Many]
<dd>Algorithm identifiers of encryption or authenticated encryption algorithm chosen
<dt>Authentication: String [0..Many]
<dd>Algorithm identifiers of authentication algorithm chosen
</dl>
