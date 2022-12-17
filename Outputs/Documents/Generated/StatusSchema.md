

<dt>SRV Prefix: _wmsmp._tcp

<dt>HTTP Well Known Service Prefix: /.well-known/wsmp





##Request Messages



###Message: WsmpRequest

Base class for all request messages.

[No fields]

##Response Messages



###Message: WsmpResponse

Base class for all response messages. Contains only the
status code and status description fields.

[No fields]

##Transaction: ServiceConfig

<dl>
<dt>Request:  ServiceConfigRequest
<dt>Response:  ServiceConfigResponse
</dl>

###Message: ServiceConfigRequest

<dl>
<dt>Inherits:  WsmpRequest
</dl>

[No fields]

###Message: ServiceConfigResponse

<dl>
<dt>Inherits:  WsmpResponse
</dl>

[No fields]

##Transaction: ServiceStatus

<dl>
<dt>Request:  ServiceStatusRequest
<dt>Response:  ServiceStatusResponse
</dl>

###Message: ServiceStatusRequest

<dl>
<dt>Inherits:  WsmpRequest
</dl>

[No fields]

###Message: ServiceStatusResponse

<dl>
<dt>Inherits:  WsmpResponse
</dl>

<dl>
<dt>Start: DateTime (Optional)
<dt>End: DateTime (Optional)
<dt>Started: Integer (Optional)
<dt>Completed: Integer (Optional)
<dt>Pending: Integer (Optional)
</dl>
