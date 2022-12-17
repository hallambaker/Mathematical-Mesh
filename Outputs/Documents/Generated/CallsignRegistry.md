

##Registry service

###Registry Account

###Structure: CatalogedRegistry

<dl>
<dt>EnvelopedConnectionAddress: Enveloped<ConnectionStripped> (Optional)
<dd>The connection allowing control of the registry.
<dt>EnvelopedProfileRegistry: Enveloped<ProfileAccount> (Optional)
<dd>The Mesh profile
<dt>EnvelopedActivationCommon: Enveloped<ActivationCommon> (Optional)
<dd>The activation data for the registry.
</dl>
###Structure: ActivationApplicationRegistry

<dl>
<dt>AccountEncryption: KeyData (Optional)
<dd>Key used to decrypt registry messages.
<dt>AdministratorSignature: KeyData (Optional)
<dd>Key or capability used to sign the registry log
<dt>EnvelopedConnectionService: Enveloped<ConnectionService> (Optional)
<dd>Signed connection service delegation allowing the device to
access the account.
</dl>
###Structure: ApplicationEntryRegistry

<dl>
<dt>EnvelopedActivation: Enveloped<ActivationApplicationRegistry> (Optional)
</dl>
###Shared Classes

<dt>SRV Prefix: _callsignreg._tcp

<dt>HTTP Well Known Service Prefix: /.well-known/callsignreg




###Message: CallsignRequest

Base class for all requests made to a registrar

[No fields]

###Message: CallsignResponse

Base class for all response messages. Contains only the
status code and status description fields.

[No fields]

###Transactions

##Transaction: Register

<dl>
<dt>Request:  RegisterRequest
<dt>Response:  RegisterResponse
</dl>

Request registration of a callsign.

###Message: RegisterRequest

Request registration of a callsign.

<dl>
<dt>Inherits:  CallsignRequest
</dl>

<dl>
<dt>PriorId: String (Optional)
<dd>If present, specifies a previous registration with the same identifier.
<dt>Reason: String (Optional)
<dd>Reason for creating a registration:
Initial/ Update/ Voluntary/ Administrative/ Revoke
<dt>EnvelopedCallsign: Enveloped<CallsignBinding> (Optional)
<dd>The callsign request signed by the party to which the callsign is to
be granted.
</dl>
###Message: RegisterResponse

<dl>
<dt>Inherits:  CallsignResponse
</dl>

Reports the success or failure of a registration.

<dl>
<dt>Result: Enveloped<Registration> (Optional)
<dd>The registration (if created).
</dl>
##Transaction: Notarize

<dl>
<dt>Request:  NotarizeRequest
<dt>Response:  NotarizeResponse
</dl>

Request inclusion of a signed witness value in the chain.

###Message: NotarizeRequest

Request registration of a callsign.

<dl>
<dt>Inherits:  CallsignRequest
</dl>

<dl>
<dt>Witness: Enveloped<Witness> (Optional)
<dd>The notary token to be included.
</dl>
###Message: NotarizeResponse

<dl>
<dt>Inherits:  CallsignResponse
</dl>

Reports the success or failure of a registration.

<dl>
<dt>Witness: Enveloped<Witness> (Optional)
<dd>The most recent witness value created by the service.
<dt>Notarization: Enveloped<Notarization> (Optional)
<dd>A notarization entry that includes the witness value specified in the request.
</dl>
