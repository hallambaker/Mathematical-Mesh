

# device

~~~~
<div="helptext">
<over>
device    Device management commands.
    accept   Accept a pending connection
    auth   Authorize device to use application
    complete   Complete a pending request
    delete   Remove device from device catalog
    earl   Connect a new device by means of an EARL
    init   Create an initialization 
    list   List devices in the device catalog
    pending   Get list of pending connection requests
    pre   Create a preconnection request
    reject   Reject a pending connection
    request   Connect to an existing profile registered at a portal
<over>
</div>
~~~~

# device accept

~~~~
<div="helptext">
<over>
accept   Accept a pending connection
       Fingerprint of connection to accept
       Device identifier
    /auth   Authorize the specified function
    /admin   Authorize device as administration device
    /all   Authorize device for all application catalogs
    /bookmark   Authorize response to confirmation requests
    /calendar   Authorize access to calendar catalog
    /contact   Authorize access to contacts catalog
    /confirm   Authorize response to confirmation requests
    /mail   Authorize access to configure SMTP mail services.
    /network   Authorize access to the network catalog
    /password   Authorize access to the password catalog
    /ssh   Authorize use of SSH
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
<over>
</div>
~~~~

Accept a pending connection request.


~~~~
<div="terminal">
<cmd>Alice> device accept NCPO-L452-CMZY-MLQO-TM52-KQYW-EFGP
<rsp></div>
~~~~

Specifying the /json option returns a result of type ResultConnectProcess:

~~~~
<div="terminal">
<cmd>Alice> device accept NCPO-L452-CMZY-MLQO-TM52-KQYW-EFGP /json
<rsp>{
  "ResultConnectProcess": {
    "Success": true}}
</div>
~~~~


# device auth

~~~~
<div="helptext">
<over>
auth   Authorize device to use application
       Device identifier
    /auth   Authorize the specified function
    /admin   Authorize device as administration device
    /all   Authorize device for all application catalogs
    /bookmark   Authorize response to confirmation requests
    /calendar   Authorize access to calendar catalog
    /contact   Authorize access to contacts catalog
    /confirm   Authorize response to confirmation requests
    /mail   Authorize access to configure SMTP mail services.
    /network   Authorize access to the network catalog
    /password   Authorize access to the password catalog
    /ssh   Authorize use of SSH
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
<over>
</div>
~~~~

The `device auth` command changes the set of authorizations given to the
specified device, adding or removing authorizations according to the 
flags specified on the command line.

The parameter specifies the device being configured by means of either
the UDF of the device profile or the device identifier.

The `/id` option may be used to specify a friendly name for the device.

Specifying the `/all` option causes the device to be granted all the 
available device authorizations except for those explicitly denied 
by means of a negative authorization grant (e.g. `/nobookmark`).

Specifying the `/noall` option causes the device to be granted no 
available device authorizations except for those explicitly granted 
by means of a positive authorization grant (e.g. `/bookmark`).

If neither the `/all` option or the `/noall` option is specified, the 
device authorizations remain unchanged except where explicitly 
granted or denied.

The following authorizations may be granted or denied:

* `bookmark`: Authorize response to confirmation requests
* `calendar`: Authorize access to calendar catalog
* `contact`: Authorize access to contacts catalog
* `confirm`: Authorize response to confirmation requests
* `mail`: Authorize access to configure SMTP mail services.
* `network`: Authorize access to the network catalog
* `password`: Authorize access to password catalog
* `ssh`: Authorize use of SSH


~~~~
<div="terminal">
<cmd>Alice> device auth Alice2 /contact
<rsp></div>
~~~~

Specifying the /json option returns a result of type ResultAuthorize:

~~~~
<div="terminal">
<cmd>Alice> device auth Alice2 /contact /json
<rsp>{
  "ResultAuthorize": {
    "Success": true}}
</div>
~~~~


# device accept

~~~~
<div="helptext">
<over>
accept   Accept a pending connection
       Fingerprint of connection to accept
       Device identifier
    /auth   Authorize the specified function
    /admin   Authorize device as administration device
    /all   Authorize device for all application catalogs
    /bookmark   Authorize response to confirmation requests
    /calendar   Authorize access to calendar catalog
    /contact   Authorize access to contacts catalog
    /confirm   Authorize response to confirmation requests
    /mail   Authorize access to configure SMTP mail services.
    /network   Authorize access to the network catalog
    /password   Authorize access to the password catalog
    /ssh   Authorize use of SSH
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
<over>
</div>
~~~~

The `device accept` command accepts the specified connection request.

The command must specify the connection identifier of the request 
being accepted. The connection identifier may be abbreviated provided that
this uniquely identifies the connection being accepted and that at least 
four characters are given.

The `/id` option may be used to specify a friendly name for the device.

The authorizations to be granted to the device may be specified using
the same syntax as for the `device auth` command with the default authorization
being that all authorizations are denied.


~~~~
<div="terminal">
<cmd>Alice> device accept NCPO-L452-CMZY-MLQO-TM52-KQYW-EFGP
<rsp></div>
~~~~

Specifying the /json option returns a result of type ResultConnectProcess:

~~~~
<div="terminal">
<cmd>Alice> device accept NCPO-L452-CMZY-MLQO-TM52-KQYW-EFGP /json
<rsp>{
  "ResultConnectProcess": {
    "Success": true}}
</div>
~~~~


# device delete

~~~~
<div="helptext">
<over>
delete   Remove device from device catalog
       Device identifier
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
<over>
</div>
~~~~

The `device delete` command removes the specified device from the catalog.

The parameter specifies the device being configured by means of either
the UDF of the device profile or the device identifier.


~~~~
<div="terminal">
<cmd>Alice> device delete NCPO-L452-CMZY-MLQO-TM52-KQYW-EFGP
<rsp>ERROR - The feature has not been implemented
</div>
~~~~

Specifying the /json option returns a result of type Result:

~~~~
<div="terminal">
<cmd>Alice> device delete NCPO-L452-CMZY-MLQO-TM52-KQYW-EFGP /json
<rsp>{
  "Result": {
    "Success": false,
    "Reason": "The feature has not been implemented"}}
</div>
~~~~


# device earl

~~~~
<div="helptext">
<over>
earl   Connect a new device by means of an EARL
       The EARL locator
       Device identifier
    /auth   Authorize the specified function
    /admin   Authorize device as administration device
    /all   Authorize device for all application catalogs
    /bookmark   Authorize response to confirmation requests
    /calendar   Authorize access to calendar catalog
    /contact   Authorize access to contacts catalog
    /confirm   Authorize response to confirmation requests
    /mail   Authorize access to configure SMTP mail services.
    /network   Authorize access to the network catalog
    /password   Authorize access to the password catalog
    /ssh   Authorize use of SSH
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
<over>
</div>
~~~~

The `device earl` command attempts to connect a device to a personal profile
by means of an EARL UDF.

The EARL is typically presented to the administration device in the form of
a QR code which is decoded and passed to the meshman application.

The `/id` option may be used to specify a friendly name for the device if the
connection attempt succeeds.

The authorizations to be granted to the device may be specified using
the same syntax as for the `device auth` command with the default authorization
being that all authorizations are denied.


~~~~
<div="terminal">
<cmd>Alice> device earl udf://example.com/EC4X-PWKB-JNOA-FRW7-DBBT-ZAYU-3EVA-FR
<rsp>ERROR - Object reference not set to an instance of an object.
</div>
~~~~

Specifying the /json option returns a result of type Result:

~~~~
<div="terminal">
<cmd>Alice> device earl udf://example.com/EC4X-PWKB-JNOA-FRW7-DBBT-ZAYU-3EVA-FR /json
<rsp>{
  "Result": {
    "Success": false,
    "Reason": "Object reference not set to an instance of an object."}}
</div>
~~~~


# device list

~~~~
<div="helptext">
<over>
list   List devices in the device catalog
       Recryption group name in user@example.com format
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
<over>
</div>
~~~~

The `device list` command lists the device profiles in the device catalog.


~~~~
<div="terminal">
<cmd>Alice> device list
<rsp></div>
~~~~

Specifying the /json option returns a result of type Result:

~~~~
<div="terminal">
<cmd>Alice> device list /json
<rsp>{
  "Result": {
    "Success": true}}
</div>
~~~~


# device pending

~~~~
<div="helptext">
<over>
pending   Get list of pending connection requests
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
<over>
</div>
~~~~

The `device pending` command lists the pending device connection requests in
the inbound message spool.


~~~~
<div="terminal">
<cmd>Alice> device pending
<rsp></div>
~~~~

Specifying the /json option returns a result of type ResultPending:

~~~~
<div="terminal">
<cmd>Alice> device pending /json
<rsp>{
  "ResultPending": {
    "Success": true,
    "Messages": [{
        "MessageID": "NCPO-L452-CMZY-MLQO-TM52-KQYW-EFGP",
        "EnvelopedRequestConnection": [{},
          "ewogICJSZXF1ZXN0Q29ubmVjdGlvbiI6
  IHsKICAgICJTZXJ2aWNlSUQiOiAiYWxpY2VAZXhhbXBsZS5jb20iLAogICAgIk
  VudmVsb3BlZFByb2ZpbGVEZXZpY2UiOiBbewogICAgICAgICJkaWciOiAiU0hB
  MiJ9LAogICAgICAiZXdvZ0lDSlFjbTltYVd4bFJHVjJhV05sSWpvZ2V3b2dJQ0
  FnSWt0bGVVOW1abXhwYm1WVGFXZAogIHVZWFIxY21VaU9pQjdDaUFnSUNBZ0lD
  SlZSRVlpT2lBaVRVUkpWaTFLU2tOQkxVaFFSbG90U1RKV1RpMUxXCiAgRFZPTF
  ROVFZVRXRVMUpSV1NJc0NpQWdJQ0FnSUNKUWRXSnNhV05RWVhKaGJXVjBaWEp6
  SWpvZ2V3b2dJQ0EKICBnSUNBZ0lDSlFkV0pzYVdOTFpYbEZRMFJJSWpvZ2V3b2
  dJQ0FnSUNBZ0lDQWdJbU55ZGlJNklDSkZaRFEwTwogIENJc0NpQWdJQ0FnSUNB
  Z0lDQWlVSFZpYkdsaklqb2dJbTFWVm1Gb1ltZzJjSEYzWjBONFMwVXpiRFk1Y1
  hwCiAgTVprVktWVTFVZWw5cU1sZDNRMlUwTlhFelJ5MVdhVFJOWXkxcmQwVUtJ
  Q0JJZVUxWFEyVnpaM05UV2prNVYKICBtRjFla1ZrYlRaeFpVRWlmWDE5TEFvZ0
  lDQWdJa3RsZVVWdVkzSjVjSFJwYjI0aU9pQjdDaUFnSUNBZ0lDSgogIFZSRVlp
  T2lBaVRVRklRUzB6UWtFMUxWQTFOak10VWpkSlR5MUhRelZCTFZkS1RVSXROVU
  pQUXlJc0NpQWdJCiAgQ0FnSUNKUWRXSnNhV05RWVhKaGJXVjBaWEp6SWpvZ2V3
  b2dJQ0FnSUNBZ0lDSlFkV0pzYVdOTFpYbEZRMFIKICBJSWpvZ2V3b2dJQ0FnSU
  NBZ0lDQWdJbU55ZGlJNklDSkZaRFEwT0NJc0NpQWdJQ0FnSUNBZ0lDQWlVSFZp
  YgogIEdsaklqb2dJa2RaVmxwYU9XbFdTbEozV0ZoVlRtMXpVRXh3Tm01WFNYTm
  lZMkZZZWtkYVlsTk1kR2w0WVdZCiAgNWVIRTJjblJRTjFsSFpGZ0tJQ0E0TjFo
  eGFXRlNPVnBuWkZWdmQzQTJka3M1YUdRMldVRWlmWDE5TEFvZ0kKICBDQWdJa3
  RsZVVGMWRHaGxiblJwWTJGMGFXOXVJam9nZXdvZ0lDQWdJQ0FpVlVSR0lqb2dJ
  azFEUzBndE5qVgogIERSUzFTUTFwYUxVRlZUa3d0TTBVMFVpMUxVVFJFTFZwWl
  QxRWlMQW9nSUNBZ0lDQWlVSFZpYkdsalVHRnlZCiAgVzFsZEdWeWN5STZJSHNL
  SUNBZ0lDQWdJQ0FpVUhWaWJHbGpTMlY1UlVORVNDSTZJSHNLSUNBZ0lDQWdJQ0
  EKICBnSUNKamNuWWlPaUFpUldRME5EZ2lMQW9nSUNBZ0lDQWdJQ0FnSWxCMVlt
  eHBZeUk2SUNKd2FDMXBjMkpDVAogIERJMU9HSjVORFpxZWxCUFdWb3dWMnMyVV
  RKMmVtWnVYMVU0WDJSWFNXODVUa1ZCWkdoRFZGcEJka3RRQ2lBCiAgZ1VtSkxV
  bTVLWjBzd2FsUXRkME5PYUcwNGRuQkpiRk5CSW4xOWZYMTkiLAogICAgICB7Ci
  AgICAgICAgInNpZ25hdHVyZXMiOiBbewogICAgICAgICAgICAiYWxnIjogIlNI
  QTIiLAogICAgICAgICAgICAia2lkIjogIk1ESVYtSkpDQS1IUEZaLUkyVk4tS1
  g1Ti0zU1VBLVNSUVkiLAogICAgICAgICAgICAic2lnbmF0dXJlIjogIkdVVWtR
  WW1LQUc2YlJ5ekgxNGFEbzV4VWgxUjFFTGhWUUxjWDYyZzhOU1hRUWxwZ3QKIC
  BjWUc3SHQxZ1VDQmJscVpWa2hqbnltc0hlOEFGd2E3SlBmQWs4MTJvTmN5OVBL
  ZWNRX1F4SXJDRHRadnhYcwogIDZCbWo5S1FYUHFHZTB4eFB0bWxfZ0ZobzdQRG
  JiU0VKeGRvVEZIQzhBIn1dLAogICAgICAgICJQYXlsb2FkRGlnZXN0IjogIjRJ
  T1NqZFVfQVVWbDNrZENXQ2toRjBaZmFLWEZ4MTN0SXZMNnMwdFg0UDJuWQogIF
  9GQUFDOWk2UXJ5SzF2WHBabmw3YVFyQVlGWjd5Mk5KSXBZajh4SW9BIn1dLAog
  ICAgIkNsaWVudE5vbmNlIjogIjhXV0xoN3BOOXc1UVduYTF4S1BaYUEifX0"],
        "ServerNonce": "jWEMY7ODhvO9UwAdKSiAcA",
        "Witness": "AEJC-J3HS-3PSM-VQPX-ZWDR-UBSK-NXPN"},
      {
        "MessageID": "NCWO-SIYM-U3KV-YMR6-HRHQ-SQEK-I26H",
        "EnvelopedRequestConnection": [{},
          "ewogICJSZXF1ZXN0Q29ubmVjdGlvbiI6
  IHsKICAgICJTZXJ2aWNlSUQiOiAiYWxpY2VAZXhhbXBsZS5jb20iLAogICAgIk
  VudmVsb3BlZFByb2ZpbGVEZXZpY2UiOiBbewogICAgICAgICJkaWciOiAiU0hB
  MiJ9LAogICAgICAiZXdvZ0lDSlFjbTltYVd4bFJHVjJhV05sSWpvZ2V3b2dJQ0
  FnSWt0bGVVOW1abXhwYm1WVGFXZAogIHVZWFIxY21VaU9pQjdDaUFnSUNBZ0lD
  SlZSRVlpT2lBaVRVSkxSaTAxTkZKSkxWcEROVFV0UTFsTVRTMWFXCiAgbFJYTF
  ZKS1FrOHRURkpPVGlJc0NpQWdJQ0FnSUNKUWRXSnNhV05RWVhKaGJXVjBaWEp6
  SWpvZ2V3b2dJQ0EKICBnSUNBZ0lDSlFkV0pzYVdOTFpYbEZRMFJJSWpvZ2V3b2
  dJQ0FnSUNBZ0lDQWdJbU55ZGlJNklDSkZaRFEwTwogIENJc0NpQWdJQ0FnSUNB
  Z0lDQWlVSFZpYkdsaklqb2dJblpvWDNVMGFuSlNUVXRaZEhaUFpWazVkMnA1Y0
  c1CiAgdWVWaEthRjk2ZUV4a09HNTNSMGQ0UnpGTmMybGZiVEZ0YTI5aVEzb0tJ
  Q0JXY0RsMloxSkxVbGQwTlRWd1QKICB6QjJkbU5EYWtWclZVRWlmWDE5TEFvZ0
  lDQWdJa3RsZVVWdVkzSjVjSFJwYjI0aU9pQjdDaUFnSUNBZ0lDSgogIFZSRVlp
  T2lBaVRVUmFVQzFQTmtKRkxVRk9Xa1F0TjBaYVFpMUtRMVZGTFZCWVdVY3RVRE
  0xTmlJc0NpQWdJCiAgQ0FnSUNKUWRXSnNhV05RWVhKaGJXVjBaWEp6SWpvZ2V3
  b2dJQ0FnSUNBZ0lDSlFkV0pzYVdOTFpYbEZRMFIKICBJSWpvZ2V3b2dJQ0FnSU
  NBZ0lDQWdJbU55ZGlJNklDSkZaRFEwT0NJc0NpQWdJQ0FnSUNBZ0lDQWlVSFZp
  YgogIEdsaklqb2dJbUZSVkZneE1GSXhTbXQwVFU5ZlRVUkpkbE5UTW5sUmFGWl
  VhMU5QYld0NFdFeDBRVkU1V1hJCiAgelRXZE5aMFYwVFdkbFgyd0tJQ0I2ZVVW
  cFZGVkhiemRzUWpSemJtdFNRbTQzZVhwT1QwRWlmWDE5TEFvZ0kKICBDQWdJa3
  RsZVVGMWRHaGxiblJwWTJGMGFXOXVJam9nZXdvZ0lDQWdJQ0FpVlVSR0lqb2dJ
  azFEUlZrdFdETgogIFBTaTFGV1VsR0xVNDFUMFF0UWxCQlJpMVhTRUZVTFRKU1
  NqSWlMQW9nSUNBZ0lDQWlVSFZpYkdsalVHRnlZCiAgVzFsZEdWeWN5STZJSHNL
  SUNBZ0lDQWdJQ0FpVUhWaWJHbGpTMlY1UlVORVNDSTZJSHNLSUNBZ0lDQWdJQ0
  EKICBnSUNKamNuWWlPaUFpUldRME5EZ2lMQW9nSUNBZ0lDQWdJQ0FnSWxCMVlt
  eHBZeUk2SUNKV2F6Rktaakl5VAogIDJaS1RqUndhRlU0WVhaMVJFcHZTRVI2Ul
  ZGNlgxSXRlbkoyYlVSaGJVdHVhbFpuY2pkUGIxOTJTaTFIQ2lBCiAgZ1VVMUxi
  MU42UldnMVl6YzFiMEoyUlRCS2IzcHlOVWxCSW4xOWZYMTkiLAogICAgICB7Ci
  AgICAgICAgInNpZ25hdHVyZXMiOiBbewogICAgICAgICAgICAiYWxnIjogIlNI
  QTIiLAogICAgICAgICAgICAia2lkIjogIk1CS0YtNTRSSS1aQzU1LUNZTE0tWl
  pUVy1SSkJPLUxSTk4iLAogICAgICAgICAgICAic2lnbmF0dXJlIjogIkZkb3pZ
  Zi1VRk42enhHWDRPaGEtT05uMjZFUk5kdzJZQ2RTU2dSTzJvVUJhX2FzclMKIC
  BIal9kd0t0LVNqMHo4TUdvZEVpWWh4bzNKR0FaZ3hVSzhTa3doaVhXdTJqOHRZ
  TXBsak40U3NfQndMUmFWMwogIDlRQkcxU2JPY1NKMnI4ZGhuWU1ZV1hGTnRLQ0
  lBcVZSWl84UVRSakVBIn1dLAogICAgICAgICJQYXlsb2FkRGlnZXN0IjogIll1
  UFdlMjctSS12OUlxWUcyVFhieXpzbm56cEpMaFJfcW9EZ3JrazU0dTVTcAogIF
  ZPRFFZaWFLM2tPQmFSTDdua0xXUVBhUXBMRGtKQUdzQU1sMVMtTWVBIn1dLAog
  ICAgIkNsaWVudE5vbmNlIjogImFpbmNfTF9WTWIzOWtLdUY4bHFSWXcifX0"],
        "ServerNonce": "WnJ_Y79eg7anvOLHM9pjZg",
        "Witness": "NGPY-QAYV-OCQD-W6JD-U3HP-3OAQ-57OW"}]}}
</div>
~~~~


# device reject

~~~~
<div="helptext">
<over>
reject   Reject a pending connection
       Fingerprint of connection to reject
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
<over>
</div>
~~~~

The `device reject` command rejects the specified connection request.

The command must specify the connection identifier of the request 
being accepted. The connection identifier may be abbreviated provided that
this uniquely identifies the connection being accepted and that at least 
four characters are given.


~~~~
<div="terminal">
<cmd>Alice> device reject NCWO-SIYM-U3KV-YMR6-HRHQ-SQEK-I26H
<rsp></div>
~~~~

Specifying the /json option returns a result of type ResultConnectProcess:

~~~~
<div="terminal">
<cmd>Alice> device reject NCWO-SIYM-U3KV-YMR6-HRHQ-SQEK-I26H /json
<rsp>{
  "ResultConnectProcess": {
    "Success": true}}
</div>
~~~~




# device pre

~~~~
<div="helptext">
<over>
pre   Create a preconnection request
       New portal account
    /key   Encryption key for use in generating an EARL connector.
    /export   Export the device configuration information to the specified file
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /cty   Content Type
    /encrypt   Encrypt data for specified recipient
    /sign   Sign data with specified key
    /hash   Compute hash of content
    /new   Force creation of new device profile
    /dudf   Device profile fingerprint
    /did   Device identifier
    /dd   Device description
    /auth   Authorize the specified function
    /admin   Authorize device as administration device
    /all   Authorize device for all application catalogs
    /bookmark   Authorize response to confirmation requests
    /calendar   Authorize access to calendar catalog
    /contact   Authorize access to contacts catalog
    /confirm   Authorize response to confirmation requests
    /mail   Authorize access to configure SMTP mail services.
    /network   Authorize access to the network catalog
    /password   Authorize access to the password catalog
    /ssh   Authorize use of SSH
<over>
</div>
~~~~

The `device pre \<account\>` command requests connection of a device to a mesh hailing
account supporting the EARL connection profile.

The \<account\> parameter specifies the hailing account for which the connection request is
made.

The `/key` option may be used to generate the encryption key to be used.

If the `/export` option is specified, the device profile and private keys are written to
a DARE container archive under the specified encryption options rather than the device 
on which the command is issued. This allows a host machine to be used to perform 
offline initialization of device profiles in batch mode during manufacture.


~~~~
<div="terminal">
<cmd>Alice4> device pre devices@example.com /key=udf://example.com/EC4X-PWKB-JNOA-FRW7-DBBT-ZAYU-3EVA-FR
<rsp>ERROR - Object reference not set to an instance of an object.
</div>
~~~~

Specifying the /json option returns a result of type Result:

~~~~
<div="terminal">
<cmd>Alice4> device pre devices@example.com /key=udf://example.com/EC4X-PWKB-JNOA-FRW7-DBBT-ZAYU-3EVA-FR /json
<rsp>{
  "Result": {
    "Success": false,
    "Reason": "Object reference not set to an instance of an object."}}
</div>
~~~~


# device request

~~~~
<div="helptext">
<over>
request   Connect to an existing profile registered at a portal
       The Mesh Service Account
    /pin   One time use authenticator
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /new   Force creation of new device profile
    /dudf   Device profile fingerprint
    /did   Device identifier
    /dd   Device description
    /auth   Authorize the specified function
    /admin   Authorize device as administration device
    /all   Authorize device for all application catalogs
    /bookmark   Authorize response to confirmation requests
    /calendar   Authorize access to calendar catalog
    /contact   Authorize access to contacts catalog
    /confirm   Authorize response to confirmation requests
    /mail   Authorize access to configure SMTP mail services.
    /network   Authorize access to the network catalog
    /password   Authorize access to the password catalog
    /ssh   Authorize use of SSH
<over>
</div>
~~~~

The `device request \<account\>` command requests connection of a device to a mesh profile.

The \<account\> parameter specifies the account for which the connection request is
made.

If the account holder has generated an authentication code, this is specified by means of 
the `/pin` option.




~~~~
<div="terminal">
<cmd>Alice2> device request alice@example.com
<rsp>   Witness value = NGPY-QAYV-OCQD-W6JD-U3HP-3OAQ-57OW
   Personal Mesh = MCSC-2POG-PH7T-ODJX-HOCA-B4XY-AFSK
</div>
~~~~

Specifying the /json option returns a result of type ResultConnect:

~~~~
<div="terminal">
<cmd>Alice2> device request alice@example.com /json
<rsp>{
  "ResultConnect": {
    "Success": true,
    "CatalogedMachine": {
      "ID": "MBKF-54RI-ZC55-CYLM-ZZTW-RJBO-LRNN",
      "EnvelopedProfileMaster": [{
          "dig": "SHA2"},
        "ewogICJQcm9maWxlTWVzaCI6IHsKICAgICJLZXlPZmZsaW5lU2lnbmF
  0dXJlIjogewogICAgICAiVURGIjogIk1DU0MtMlBPRy1QSDdULU9ESlgtSE9DQ
  S1CNFhZLUFGU0siLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICA
  gICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiL
  AogICAgICAgICAgIlB1YmxpYyI6ICJBcU9tLWVMc1VQeVNQa2VtTXZWSUpjdFh
  VU1RhNkVDNWNfdzBrTEhaQ2g0eExsRm93NFNKCiAgenNEajJ4U1g1b2ZVbDFYY
  3VDQmo5cWFBIn19fSwKICAgICJLZXlzT25saW5lU2lnbmF0dXJlIjogW3sKICA
  gICAgICAiVURGIjogIk1ESTctTE1NVC1MVEpFLTZDNVotQUZaTi02T1hXLVlMV
  zMiLAogICAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICAgIlB
  1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogI
  CAgICAgICAgICAiUHVibGljIjogInRRaE0ybFVpQm5LZ2s5UEFTaWdlYmRaSDE
  4bkRDNHFGU1pJSmdtd1RQWXJwZEFLc1NudVoKICBQSDdVUHUzQXRZakZGOGFHT
  Xl5RjhVdUEifX19XSwKICAgICJLZXlFbmNyeXB0aW9uIjogewogICAgICAiVUR
  GIjogIk1BVFMtMzdKNS0yNkRHLU1ZVVItN0JNVS1QUEpKLVVVTzQiLAogICAgI
  CAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNESCI
  6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAgIlB1YmxpY
  yI6ICJTVUpOenBETEhUOWR4T3lZZHpmdWhQTDBta1IxdHctSlRqdUlWZ1U3WC1
  iRnFpMno2NmVmCiAgUXYxY3dTZVZMLW9abjJDT3BJSE4tbEtBIn19fX19",
        {
          "signatures": [{
              "alg": "SHA2",
              "kid": "MCSC-2POG-PH7T-ODJX-HOCA-B4XY-AFSK",
              "signature": "riRoZjc1gdnCuBooN1Nf3b-U1BxNNMNdyGoepizbYZBkie_TZ
  g26c-wb-Nabj1QoxckrARTeyrSA9LyI-pw2CfVYJIxxqoYjN2tzhQ_yixJ7nFk
  ieasbfVD_IKR6xU1j8agpeiU572xz42NlF5jufgkA"}],
          "PayloadDigest": "kzRXdgdpelIk0nCoPlfMJ8SN3j211cOF6ygBIQuirxTS8
  Q6aBJyUbbhFBRVWtyyVSQo_CA_5a5we_9dsLrkPpQ"}],
      "DeviceUDF": "MBKF-54RI-ZC55-CYLM-ZZTW-RJBO-LRNN",
      "EnvelopedProfileDevice": [{
          "dig": "SHA2"},
        "ewogICJQcm9maWxlRGV2aWNlIjogewogICAgIktleU9mZmxpbmVTaWd
  uYXR1cmUiOiB7CiAgICAgICJVREYiOiAiTUJLRi01NFJJLVpDNTUtQ1lMTS1aW
  lRXLVJKQk8tTFJOTiIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICA
  gICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJFZDQ0O
  CIsCiAgICAgICAgICAiUHVibGljIjogInZoX3U0anJSTUtZdHZPZVk5d2p5cG5
  ueVhKaF96eExkOG53R0d4RzFNc2lfbTFta29iQ3oKICBWcDl2Z1JLUld0NTVwT
  zB2dmNDakVrVUEifX19LAogICAgIktleUVuY3J5cHRpb24iOiB7CiAgICAgICJ
  VREYiOiAiTURaUC1PNkJFLUFOWkQtN0ZaQi1KQ1VFLVBYWUctUDM1NiIsCiAgI
  CAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJsaWNLZXlFQ0R
  IIjogewogICAgICAgICAgImNydiI6ICJFZDQ0OCIsCiAgICAgICAgICAiUHVib
  GljIjogImFRVFgxMFIxSmt0TU9fTURJdlNTMnlRaFZUa1NPbWt4WEx0QVE5WXI
  zTWdNZ0V0TWdlX2wKICB6eUVpVFVHbzdsQjRzbmtSQm43eXpOT0EifX19LAogI
  CAgIktleUF1dGhlbnRpY2F0aW9uIjogewogICAgICAiVURGIjogIk1DRVktWDN
  PSi1FWUlGLU41T0QtQlBBRi1XSEFULTJSSjIiLAogICAgICAiUHVibGljUGFyY
  W1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICA
  gICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJWazFKZjIyT
  2ZKTjRwaFU4YXZ1REpvSER6RVF6X1ItenJ2bURhbUtualZncjdPb192Si1HCiA
  gUU1Lb1N6RWg1Yzc1b0J2RTBKb3pyNUlBIn19fX19",
        {
          "signatures": [{
              "alg": "SHA2",
              "kid": "MBKF-54RI-ZC55-CYLM-ZZTW-RJBO-LRNN",
              "signature": "FdozYf-UFN6zxGX4Oha-ONn26ERNdw2YCdSSgRO2oUBa_asrS
  Hj_dwKt-Sj0z8MGodEiYhxo3JGAZgxUK8SkwhiXWu2j8tYMpljN4Ss_BwLRaV3
  9QBG1SbOcSJ2r8dhnYMYWXFNtKCIAqVRZ_8QTRjEA"}],
          "PayloadDigest": "YuPWe27-I-v9IqYG2TXbyzsnnzpJLhR_qoDgrkk54u5Sp
  VODQYiaK3kOBaRL7nkLWQPaQpLDkJAGsAMl1S-MeA"}],
      "EnvelopedMessageConnectionResponse": [{
          "ContentMetaData": "ewogICJVbmlxdWVJRCI6ICJOQjMyLTRCUFItM0dOTi1
  ZNk9FLTRBVFAtRE1OWi1QS0pIIiwKICAiTWVzc2FnZVR5cGUiOiAiQWNrbm93b
  GVkZ2VDb25uZWN0aW9uIn0"},
        "ewogICJBY2tub3dsZWRnZUNvbm5lY3Rpb24iOiB7CiA
  gICAiTWVzc2FnZUlEIjogIk5DV08tU0lZTS1VM0tWLVlNUjYtSFJIUS1TUUVLL
  UkyNkgiLAogICAgIkVudmVsb3BlZFJlcXVlc3RDb25uZWN0aW9uIjogW3t9LAo
  gICAgICAiZXdvZ0lDSlNaWEYxWlhOMFEyOXVibVZqZEdsdmJpSTYKICBJSHNLS
  UNBZ0lDSlRaWEoyYVdObFNVUWlPaUFpWVd4cFkyVkFaWGhoYlhCc1pTNWpiMjB
  pTEFvZ0lDQWdJawogIFZ1ZG1Wc2IzQmxaRkJ5YjJacGJHVkVaWFpwWTJVaU9pQ
  mJld29nSUNBZ0lDQWdJQ0prYVdjaU9pQWlVMGhCCiAgTWlKOUxBb2dJQ0FnSUN
  BaVpYZHZaMGxEU2xGamJUbHRZVmQ0YkZKSFZqSmhWMDVzU1dwdloyVjNiMmRKU
  TAKICBGblNXdDBiR1ZWT1cxYWJYaHdZbTFXVkdGWFpBb2dJSFZaV0ZJeFkyMVZ
  hVTlwUWpkRGFVRm5TVU5CWjBsRAogIFNsWlNSVmxwVDJsQmFWUlZTa3hTYVRBe
  FRrWktTa3hXY0VST1ZGVjBVVEZzVFZSVE1XRlhDaUFnYkZKWVRGCiAgWktTMUZ
  yT0hSVVJrcFBWR2xKYzBOcFFXZEpRMEZuU1VOS1VXUlhTbk5oVjA1UldWaEthR
  0pYVmpCYVdFcDYKICBTV3B2WjJWM2IyZEpRMEVLSUNCblNVTkJaMGxEU2xGa1Y
  wcHpZVmRPVEZwWWJFWlJNRkpKU1dwdloyVjNiMgogIGRKUTBGblNVTkJaMGxEU
  VdkSmJVNTVaR2xKTmtsRFNrWmFSRkV3VHdvZ0lFTkpjME5wUVdkSlEwRm5TVU5
  CCiAgWjBsRFFXbFZTRlpwWWtkc2FrbHFiMmRKYmxwdldETlZNR0Z1U2xOVVZYU
  mFaRWhhVUZwV2F6VmtNbkExWTAKICBjMUNpQWdkV1ZXYUV0aFJqazJaVVY0YTA
  5SE5UTlNNR1EwVW5wR1RtTXliR1ppVkVaMFlUSTVhVkV6YjB0SgogIFEwSlhZM
  FJzTWxveFNreFZiR1F3VGxSV2QxUUtJQ0I2UWpKa2JVNUVZV3RXY2xaVlJXbG1
  XREU1VEVGdlowCiAgbERRV2RKYTNSc1pWVldkVmt6U2pWalNGSndZakkwYVU5c
  FFqZERhVUZuU1VOQlowbERTZ29nSUZaU1JWbHAKICBUMmxCYVZSVlVtRlZRekZ
  RVG10S1JreFZSazlYYTFGMFRqQmFZVkZwTVV0Uk1WWkdURlpDV1ZkVlkzUlZSR
  QogIDB4VG1sSmMwTnBRV2RKQ2lBZ1EwRm5TVU5LVVdSWFNuTmhWMDVSV1ZoS2F
  HSlhWakJhV0VwNlNXcHZaMlYzCiAgYjJkSlEwRm5TVU5CWjBsRFNsRmtWMHB6W
  VZkT1RGcFliRVpSTUZJS0lDQkpTV3B2WjJWM2IyZEpRMEZuU1UKICBOQlowbER
  RV2RKYlU1NVpHbEpOa2xEU2taYVJGRXdUME5KYzBOcFFXZEpRMEZuU1VOQlowb
  ERRV2xWU0ZacAogIFlnb2dJRWRzYWtscWIyZEpiVVpTVmtabmVFMUdTWGhUYlh
  Rd1ZGVTVabFJWVWtwa2JFNVVUVzVzVW1GR1dsCiAgVmhNVTVRWWxkME5GZEZlR
  EJSVmtVMVYxaEpDaUFnZWxSWFpFNWFNRll3VkZka2JGZ3lkMHRKUTBJMlpWVlc
  KICBjRlpHVmtoaWVtUnpVV3BTZW1KdGRGTlJiVFF6WlZod1QxUXdSV2xtV0RFN
  VRFRnZaMGtLSUNCRFFXZEphMwogIFJzWlZWR01XUkhhR3hpYmxKd1dUSkdNR0Z
  YT1hWSmFtOW5aWGR2WjBsRFFXZEpRMEZwVmxWU1IwbHFiMmRKCiAgYXpGRVVsW
  nJkRmRFVGdvZ0lGQlRhVEZHVjFWc1IweFZOREZVTUZGMFVXeENRbEpwTVZoVFJ
  VWlZURlJLVTEKICBOcVNXbE1RVzluU1VOQlowbERRV2xWU0ZacFlrZHNhbFZIU
  m5sWkNpQWdWekZzWkVkV2VXTjVTVFpKU0hOTAogIFNVTkJaMGxEUVdkSlEwRnB
  WVWhXYVdKSGJHcFRNbFkxVWxWT1JWTkRTVFpKU0hOTFNVTkJaMGxEUVdkSlEwC
  iAgRUtJQ0JuU1VOS2FtTnVXV2xQYVVGcFVsZFJNRTVFWjJsTVFXOW5TVU5CWjB
  sRFFXZEpRMEZuU1d4Q01WbHQKICBlSEJaZVVrMlNVTktWMkY2Umt0YWFrbDVWQ
  W9nSURKYVMxUnFVbmRoUmxVMFdWaGFNVkpGY0haVFJWSTJVbAogIFpHTmxneFN
  YUmxia295WWxWU2FHSlZkSFZoYkZwdVkycGtVR0l4T1RKVGFURklRMmxCQ2lBZ
  1oxVlZNVXhpCiAgTVU0MlVsZG5NVmw2WXpGaU1Fb3lVbFJDUzJJemNIbE9WV3h
  DU1c0eE9XWllNVGtpTEFvZ0lDQWdJQ0I3Q2kKICBBZ0lDQWdJQ0FnSW5OcFoyN
  WhkSFZ5WlhNaU9pQmJld29nSUNBZ0lDQWdJQ0FnSUNBaVlXeG5Jam9nSWxOSQo
  gIFFUSWlMQW9nSUNBZ0lDQWdJQ0FnSUNBaWEybGtJam9nSWsxQ1MwWXROVFJTU
  1MxYVF6VTFMVU5aVEUwdFdsCiAgcFVWeTFTU2tKUExVeFNUazRpTEFvZ0lDQWd
  JQ0FnSUNBZ0lDQWljMmxuYm1GMGRYSmxJam9nSWtaa2IzcFoKICBaaTFWUms0M
  mVuaEhXRFJQYUdFdFQwNXVNalpGVWs1a2R6SlpRMlJUVTJkU1R6SnZWVUpoWDJ
  GemNsTUtJQwogIEJJYWw5a2QwdDBMVk5xTUhvNFRVZHZaRVZwV1doNGJ6TktSM
  EZhWjNoVlN6aFRhM2RvYVZoWGRUSnFPSFJaCiAgVFhCc2FrNDBVM05mUW5kTVV
  tRldNd29nSURsUlFrY3hVMkpQWTFOS01uSTRaR2h1V1UxWlYxaEdUblJMUTAKI
  CBsQmNWWlNXbDg0VVZSU2FrVkJJbjFkTEFvZ0lDQWdJQ0FnSUNKUVlYbHNiMkZ
  rUkdsblpYTjBJam9nSWxsMQogIFVGZGxNamN0U1MxMk9VbHhXVWN5VkZoaWVYc
  HpibTU2Y0VwTWFGSmZjVzlFWjNKcmF6VTBkVFZUY0FvZ0lGCiAgWlBSRkZaYVd
  GTE0ydFBRbUZTVERkdWEweFhVVkJoVVhCTVJHdEtRVWR6UVUxc01WTXRUV1ZCS
  W4xZExBb2cKICBJQ0FnSWtOc2FXVnVkRTV2Ym1ObElqb2dJbUZwYm1OZlRGOVd
  UV0l6T1d0TGRVWTRiSEZTV1hjaWZYMCJdLAogICAgIlNlcnZlck5vbmNlIjogI
  lduSl9ZNzllZzdhbnZPTEhNOXBqWmciLAogICAgIldpdG5lc3MiOiAiTkdQWS1
  RQVlWLU9DUUQtVzZKRC1VM0hQLTNPQVEtNTdPVyJ9fQ"],
      "EnvelopedAccountAssertion": [{
          "dig": "SHA2"},
        "ewogICJQcm9maWxlQWNjb3VudCI6IHsKICAgICJLZXlPZmZsaW5lU2l
  nbmF0dXJlIjogewogICAgICAiVURGIjogIk1DMjMtWDNDVC1FVU5CLURSM00tU
  UlCSS1XMklKLUFURVAiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICA
  gICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0N
  DgiLAogICAgICAgICAgIlB1YmxpYyI6ICI5dXBQMWlhazMwX0pyRzFwZVl3aGt
  UMDBEcHc4SjBqd0dRQTBuZWhuQlZQdU9hRzloNlNzCiAgRmUwRGV6MmIzYVFwb
  GRBR1VLb1VCZENBIn19fSwKICAgICJLZXlzT25saW5lU2lnbmF0dXJlIjogW3s
  KICAgICAgICAiVURGIjogIk1DUlItSkZMWi1UMkpILUlOR0QtU0JZRi1OTzZYL
  TU1Uk4iLAogICAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICA
  gIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAgICJjcnYiOiAiRWQ0NDgiL
  AogICAgICAgICAgICAiUHVibGljIjogIkZfTUpmMHc4ZFVIaVBZeTk3WEtRbXB
  mRlZMbk5uZHNqUUg1cDFjM3ozSGxucVRhMmE3YkUKICBVQ09veGE0SEFpc2Y5Q
  nFueEpFZE9tZ0EifX19XSwKICAgICJTZXJ2aWNlSURzIjogWyJhbGljZUBleGF
  tcGxlLmNvbSJdLAogICAgIk1lc2hQcm9maWxlVURGIjogIk1DU0MtMlBPRy1QS
  DdULU9ESlgtSE9DQS1CNFhZLUFGU0siLAogICAgIktleUVuY3J5cHRpb24iOiB
  7CiAgICAgICJVREYiOiAiTUJXWS1JSUtZLVZPQjUtQlhJUC1ESVhYLVI0VEgtW
  klGMiIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJ
  saWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJFZDQ0OCIsCiAgICAgI
  CAgICAiUHVibGljIjogInN3cGU2SDV5aVU0dkpvdGJvWGJGd3dJRXBfbFhPLWt
  ibTl6ajlQT0ZMTHdmcWU2QlVNc3UKICA5RkJDTDZHSHA5M3djbUxNMjd0R1JuN
  EEifX19fX0",
        {
          "signatures": [{
              "alg": "SHA2",
              "kid": "MDI7-LMMT-LTJE-6C5Z-AFZN-6OXW-YLW3",
              "signature": "BKyn2yRykmhAchtt7nfrEFbtAjq597QoPxRTb8hphW01701Oh
  gTWMBilRSDRQaz-MdtVqePyDYCA7Voe6MO31wEh3xKUcD50zZeD01bKnIpbylb
  l13WNGw25loyC6ns_Xj2fbsP6bq-j98gEm4uYAwEA"}],
          "PayloadDigest": "h-nEPwrNmuSb9Eed4NgVBHIbfthIoyoHXvmyrCJ61Nmqc
  1GVow8VgMV-tywKMfH7rhra3iRwx4Z_ikDtgKdbOQ"}]}}}
</div>
~~~~



