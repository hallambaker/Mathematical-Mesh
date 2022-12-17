

##Registrar service

###Shared Classes

<dt>SRV Prefix: _callsignreg._tcp

<dt>HTTP Well Known Service Prefix: /.well-known/callsignreg




###Message: ResolverRequest

Base class for all requests made to a registrar

[No fields]

###Message: ResolverResponse

Base class for all response messages. Contains only the
status code and status description fields.

[No fields]

###Transactions

##Transaction: Query

<dl>
<dt>Request:  QueryRequest
<dt>Response:  QueryResponse
</dl>

Request resolution of a profile bound to a callsign or registration identifier.
Returns an envelope containing the signed registration (if found).

###Message: QueryRequest

Request resolution of a profile bound to a callsign or registration identifier. 

<dl>
<dt>Inherits:  ResolverRequest
</dl>

<dl>
<dt>CallSign: String (Optional)
<dd>The callsign being requested in canonical form.
<dt>RegistrationId: String (Optional)
<dd>The registration identifier of a registration in the log.
<dt>LogId: String (Optional)
<dd>The unique identifier of an append only log whose signed Notarization
entry is requested.
</dl>
###Message: QueryResponse

Return the result of a QueryRequest

<dl>
<dt>Inherits:  ResolverResponse
</dl>

<dl>
<dt>Result: Enveloped<Registration> (Optional)
<dd>The registration specified in the result (if found).	
<dt>Notarization: Enveloped<Notarization> (Optional)
<dd>The latest notarization entry corresponding to the specified log.
</dl>
