

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
<cmd>Alice> device accept NDZP-2UYY-ZA5U-T2PR-7XBW-OBT6-2OQE
<rsp></div>
~~~~

Specifying the /json option returns a result of type ResultConnectProcess:

~~~~
<div="terminal">
<cmd>Alice> device accept NDZP-2UYY-ZA5U-T2PR-7XBW-OBT6-2OQE /json
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
<cmd>Alice> device accept NDZP-2UYY-ZA5U-T2PR-7XBW-OBT6-2OQE
<rsp></div>
~~~~

Specifying the /json option returns a result of type ResultConnectProcess:

~~~~
<div="terminal">
<cmd>Alice> device accept NDZP-2UYY-ZA5U-T2PR-7XBW-OBT6-2OQE /json
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
<cmd>Alice> device delete NDZP-2UYY-ZA5U-T2PR-7XBW-OBT6-2OQE
<rsp>ERROR - The feature has not been implemented
</div>
~~~~

Specifying the /json option returns a result of type Result:

~~~~
<div="terminal">
<cmd>Alice> device delete NDZP-2UYY-ZA5U-T2PR-7XBW-OBT6-2OQE /json
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
<cmd>Alice> device earl udf://example.com/EB2X-PUOT-6CR3-TVNH-EN2T-4Y4X-FK6Q-NC
<rsp>ERROR - Object reference not set to an instance of an object.
</div>
~~~~

Specifying the /json option returns a result of type Result:

~~~~
<div="terminal">
<cmd>Alice> device earl udf://example.com/EB2X-PUOT-6CR3-TVNH-EN2T-4Y4X-FK6Q-NC /json
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
        "MessageID": "NDZP-2UYY-ZA5U-T2PR-7XBW-OBT6-2OQE",
        "EnvelopedRequestConnection": [{},
          "ewogICJSZXF1ZXN0Q29ubmVjdGlvbiI6
  IHsKICAgICJTZXJ2aWNlSUQiOiAiYWxpY2VAZXhhbXBsZS5jb20iLAogICAgIk
  VudmVsb3BlZFByb2ZpbGVEZXZpY2UiOiBbewogICAgICAgICJkaWciOiAiUzUx
  MiJ9LAogICAgICAiZXdvZ0lDSlFjbTltYVd4bFJHVjJhV05sSWpvZ2V3b2dJQ0
  FnSWt0bGVVOW1abXhwYm1WVGFXZAogIHVZWFIxY21VaU9pQjdDaUFnSUNBZ0lD
  SlZSRVlpT2lBaVRVTk5OaTFhV0ZWV0xVeEhXVWd0U1VFM05pMWFOCiAgVkpKTF
  V0S1N6WXRTMWhhVGlJc0NpQWdJQ0FnSUNKUWRXSnNhV05RWVhKaGJXVjBaWEp6
  SWpvZ2V3b2dJQ0EKICBnSUNBZ0lDSlFkV0pzYVdOTFpYbEZRMFJJSWpvZ2V3b2
  dJQ0FnSUNBZ0lDQWdJbU55ZGlJNklDSkZaRFEwTwogIENJc0NpQWdJQ0FnSUNB
  Z0lDQWlVSFZpYkdsaklqb2dJblpKVkU5aFp6aFlTVzlKWWtGcE5WVXhRazB0VD
  JSCiAgWVNFNXZWRzFUTlVkcU1FMVNkVmQ2VERkVk5HNU5NbXBDTmtNemNtVUtJ
  Q0JmZEMxNWFuaEtUbkJMYjNnMk0KICBFWnNhazltZGtOeVFVRWlmWDE5TEFvZ0
  lDQWdJa3RsZVVWdVkzSjVjSFJwYjI0aU9pQjdDaUFnSUNBZ0lDSgogIFZSRVlp
  T2lBaVRVUlRSUzFHVWpOWkxWcFVRMHd0UWtZMlRTMHlVVE5ITFZkRE5VNHRUMG
  xVU3lJc0NpQWdJCiAgQ0FnSUNKUWRXSnNhV05RWVhKaGJXVjBaWEp6SWpvZ2V3
  b2dJQ0FnSUNBZ0lDSlFkV0pzYVdOTFpYbEZRMFIKICBJSWpvZ2V3b2dJQ0FnSU
  NBZ0lDQWdJbU55ZGlJNklDSkZaRFEwT0NJc0NpQWdJQ0FnSUNBZ0lDQWlVSFZp
  YgogIEdsaklqb2dJbkYzTkdnM1JTMDVWR1YwVUhaU1ZuQmFiaTFEYTFVeWFHRm
  xWMVl0U2pZelowcDNSamcxTVhBCiAgeGMySTJkMkp6Vm1kbE16UUtJQ0JwU2xG
  V1ptZDFSM1JOV2poVFFVSnlhMU54WmsxTWEwRWlmWDE5TEFvZ0kKICBDQWdJa3
  RsZVVGMWRHaGxiblJwWTJGMGFXOXVJam9nZXdvZ0lDQWdJQ0FpVlVSR0lqb2dJ
  azFFVkVRdFR6VgogIEZUQzFLVjBvM0xVZFFTVVV0UVZwUVdpMUhVVE5YTFRkWF
  ZsSWlMQW9nSUNBZ0lDQWlVSFZpYkdsalVHRnlZCiAgVzFsZEdWeWN5STZJSHNL
  SUNBZ0lDQWdJQ0FpVUhWaWJHbGpTMlY1UlVORVNDSTZJSHNLSUNBZ0lDQWdJQ0
  EKICBnSUNKamNuWWlPaUFpUldRME5EZ2lMQW9nSUNBZ0lDQWdJQ0FnSWxCMVlt
  eHBZeUk2SUNKb1RYVndlVUpLWQogIHpoNVUxZDNSVU5aVmpGS1Z6bHlOR05pU1
  hkQmMxTjBlakYxZW5wSGNEaGZOVXhxY3psNmNUbDJlRU5hQ2lBCiAgZ1pUQnpN
  V2xVU2w5MGNuQlBaMHBHYkZjM2RtWkdaUzFCSW4xOWZYMTkiLAogICAgICB7Ci
  AgICAgICAgInNpZ25hdHVyZXMiOiBbewogICAgICAgICAgICAiYWxnIjogIlM1
  MTIiLAogICAgICAgICAgICAia2lkIjogIk1DTTYtWlhVVi1MR1lILUlBNzYtWj
  VSSS1LSks2LUtYWk4iLAogICAgICAgICAgICAic2lnbmF0dXJlIjogIi0yMXQ1
  eU5RM3dtQkJ2V2lxWGhnV2NvWTV4N1JfWVBaMjFUd3RWZW4xQ0VFalRrTXUKIC
  BKUlRqUnl0TVAtTENvNmdNS0VQTU84bEV6Z0FibnZ3Mkh4WElmQ3pPSkF5enB4
  TU1xOHlXeHJkTnU3UWdkVgogIHJDbmNrSVdOaGJhSHdOMlVWcFMtbEpCZEVib2
  9tQWo0b0VjX1hzaHdBIn1dLAogICAgICAgICJQYXlsb2FkRGlnZXN0IjogIk52
  TUtJZnJFc3A0ZzdsVUVTb19pbkZSV2d1YUJhZ05pZmEyWVBEbHFFOWM1eQogIE
  xnWTdLeXdTUnFTbGVmREtyOWphZXFRWW00a3E0QkdhaWs4UGw3TDd3In1dLAog
  ICAgIkNsaWVudE5vbmNlIjogIk81MnNfdjNiSUNELUVvdmRCRE1UTVEifX0"],
        "ServerNonce": "IphTEA9tmtgFjIlzSQwjmw",
        "Witness": "AJA4-2O5P-LABF-2BRK-AJKP-S2LI-DV3D"},
      {
        "MessageID": "NB3R-I5BK-QDB2-QWXG-WPVK-NGH6-OIII",
        "EnvelopedRequestConnection": [{},
          "ewogICJSZXF1ZXN0Q29ubmVjdGlvbiI6
  IHsKICAgICJTZXJ2aWNlSUQiOiAiYWxpY2VAZXhhbXBsZS5jb20iLAogICAgIk
  VudmVsb3BlZFByb2ZpbGVEZXZpY2UiOiBbewogICAgICAgICJkaWciOiAiUzUx
  MiJ9LAogICAgICAiZXdvZ0lDSlFjbTltYVd4bFJHVjJhV05sSWpvZ2V3b2dJQ0
  FnSWt0bGVVOW1abXhwYm1WVGFXZAogIHVZWFIxY21VaU9pQjdDaUFnSUNBZ0lD
  SlZSRVlpT2lBaVRVTkpOUzFNU1VKTExWZERUa1V0VTB3M1FpMVFXCiAgbE0wTF
  RaYVZrZ3RTa05EVmlJc0NpQWdJQ0FnSUNKUWRXSnNhV05RWVhKaGJXVjBaWEp6
  SWpvZ2V3b2dJQ0EKICBnSUNBZ0lDSlFkV0pzYVdOTFpYbEZRMFJJSWpvZ2V3b2
  dJQ0FnSUNBZ0lDQWdJbU55ZGlJNklDSkZaRFEwTwogIENJc0NpQWdJQ0FnSUNB
  Z0lDQWlVSFZpYkdsaklqb2dJbDlRVUV4ek1uTldaR0pCY20xS056RTRkeTB0WT
  E5CiAgNU1FaEhOalk1ZFdOZmQxSldTbUYwTm5SdldITk9aMWt0ZWpkTmNFc0tJ
  Q0JOZFhCQ1oyaFFkazF4Vm1wUmEKICB6Vk9XbnBuU1VoQlkwRWlmWDE5TEFvZ0
  lDQWdJa3RsZVVWdVkzSjVjSFJwYjI0aU9pQjdDaUFnSUNBZ0lDSgogIFZSRVlp
  T2lBaVRVUk1VeTFPVmtVMExVeEpWRUl0VERkR1JTMU1TMFJXTFV3elNqY3RSel
  JKVXlJc0NpQWdJCiAgQ0FnSUNKUWRXSnNhV05RWVhKaGJXVjBaWEp6SWpvZ2V3
  b2dJQ0FnSUNBZ0lDSlFkV0pzYVdOTFpYbEZRMFIKICBJSWpvZ2V3b2dJQ0FnSU
  NBZ0lDQWdJbU55ZGlJNklDSkZaRFEwT0NJc0NpQWdJQ0FnSUNBZ0lDQWlVSFZp
  YgogIEdsaklqb2dJbmxyZWs0NVdEbHRZMlJHVm1aeFUybFNXbmRwWm10WFp6Ql
  hVMmhIU1hrMlVGQXRUa0ZsVVZsCiAgSWNrOXRjbU5VY0hkdFZqZ0tJQ0JmZGxa
  bE9VUndla3RZWWpGbVoxRklhRWRwUlVoSE9FRWlmWDE5TEFvZ0kKICBDQWdJa3
  RsZVVGMWRHaGxiblJwWTJGMGFXOXVJam9nZXdvZ0lDQWdJQ0FpVlVSR0lqb2dJ
  azFEVmpJdFZsWgogIE9OaTAwUmtzekxVVTNVRUl0VkVOQlJpMVNWVFJKTFVsV1
  RrSWlMQW9nSUNBZ0lDQWlVSFZpYkdsalVHRnlZCiAgVzFsZEdWeWN5STZJSHNL
  SUNBZ0lDQWdJQ0FpVUhWaWJHbGpTMlY1UlVORVNDSTZJSHNLSUNBZ0lDQWdJQ0
  EKICBnSUNKamNuWWlPaUFpUldRME5EZ2lMQW9nSUNBZ0lDQWdJQ0FnSWxCMVlt
  eHBZeUk2SUNJd1JuWkZaMlpTUwogIG1sVFJXOUxVR3R3TWtsMmRXbDFOVk5TZU
  dKcVJXNWhTbTlMUWt0ZlkydGlVa3N4WWtWV05TMWhjMjFOQ2lBCiAgZ1JVWkZO
  RGhrYlhWNk56ZERjM2wxWlVOWVJWRk5jM2xCSW4xOWZYMTkiLAogICAgICB7Ci
  AgICAgICAgInNpZ25hdHVyZXMiOiBbewogICAgICAgICAgICAiYWxnIjogIlM1
  MTIiLAogICAgICAgICAgICAia2lkIjogIk1DSTUtTElCSy1XQ05FLVNMN0ItUF
  pTNC02WlZILUpDQ1YiLAogICAgICAgICAgICAic2lnbmF0dXJlIjogImV3V294
  SUdBS0t0emtDTWc5WVBncTI2Z2xoRG5iYlB5NU42VVFtVTF3YjJRYTUyRkcKIC
  AzSjhDc3RWREw2ODJKQV9lVXZOYzNGUmRWRUFfVnJlLVNEN1F6bEJJNFpiUWZw
  NkxfV3labHYwTTZ2LU92bwogIG1YcV9JQzd0TGpXeDFWQ25TejlHT3A2Vk1VOE
  o3N2pkdXFHNWQyRFVBIn1dLAogICAgICAgICJQYXlsb2FkRGlnZXN0IjogIktn
  WndZUkZfcm56cEhhOFQtV2NxRk1rZmZFRUFSVmJGNU9RUDU4ZkxQWlFwOAogIH
  JUSzZyNk1falVUX0FNbjVWVmVldlhOem1HekpTQ1ptTjNfWVBYdUl3In1dLAog
  ICAgIkNsaWVudE5vbmNlIjogIm94cVVRenhQT1VtNjVhUDdUX000d0EifX0"],
        "ServerNonce": "EyRSuA6di-CaMo7ZEKIx7g",
        "Witness": "ASOE-FANU-WN2N-UQ24-JBHE-GSHV-EKQL"}]}}
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
<cmd>Alice> device reject NB3R-I5BK-QDB2-QWXG-WPVK-NGH6-OIII
<rsp></div>
~~~~

Specifying the /json option returns a result of type ResultConnectProcess:

~~~~
<div="terminal">
<cmd>Alice> device reject NB3R-I5BK-QDB2-QWXG-WPVK-NGH6-OIII /json
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
<cmd>Alice4> device pre devices@example.com /key=udf://example.com/EB2X-PUOT-6CR3-TVNH-EN2T-4Y4X-FK6Q-NC
<rsp>ERROR - Object reference not set to an instance of an object.
</div>
~~~~

Specifying the /json option returns a result of type Result:

~~~~
<div="terminal">
<cmd>Alice4> device pre devices@example.com /key=udf://example.com/EB2X-PUOT-6CR3-TVNH-EN2T-4Y4X-FK6Q-NC /json
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
<rsp>   Witness value = ASOE-FANU-WN2N-UQ24-JBHE-GSHV-EKQL
   Personal Mesh = MCON-CT4L-LAU5-UQTO-TPIS-MHJA-T7RG
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
      "ID": "MCI5-LIBK-WCNE-SL7B-PZS4-6ZVH-JCCV",
      "EnvelopedProfileMaster": [{
          "dig": "S512"},
        "ewogICJQcm9maWxlTWVzaCI6IHsKICAgICJLZXlPZmZsaW5lU2lnbmF
  0dXJlIjogewogICAgICAiVURGIjogIk1DT04tQ1Q0TC1MQVU1LVVRVE8tVFBJU
  y1NSEpBLVQ3UkciLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICA
  gICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiL
  AogICAgICAgICAgIlB1YmxpYyI6ICJYUlNFRG9RU01tb1dTbjZSbV95S3ZoNTh
  SRWtncjNRZlc5Tk9icDRZS1U4cnhoWlVzLWlnCiAgNjJHWk1xeHdRbE9uUmJCZ
  2p1NWNNcnVBIn19fSwKICAgICJLZXlzT25saW5lU2lnbmF0dXJlIjogW3sKICA
  gICAgICAiVURGIjogIk1EVk4tSEJMRi1RM0JGLU9TQ1QtT0xYNC1URFNZLVRZM
  1ciLAogICAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICAgIlB
  1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogI
  CAgICAgICAgICAiUHVibGljIjogIlFiZTVIb1VVRU9RQ3Vxbm5EcHNRMUlKbHE
  xVGZLSC0tVWFmUXhZTVpqWk9nMkNqVzVqZTAKICBPU3JWNm5sR3VENGVCRzdsS
  0cwVEZ0R0EifX19XSwKICAgICJLZXlFbmNyeXB0aW9uIjogewogICAgICAiVUR
  GIjogIk1BR08tRUw3Vy1aNTJQLVdPQ0EtSVdTQi1VRklJLVkzUzIiLAogICAgI
  CAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNESCI
  6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAgIlB1YmxpY
  yI6ICIzLUc3RjRBcS1UNVhNRnlLMFB5eS1YeW1LS3RZeHc4czM2MFVEaVRQWk9
  NS1VnZEdWWldGCiAgcWJaWFRmZWRNN09hbnhaM1Y1S2hCU1FBIn19fX19",
        {
          "signatures": [{
              "alg": "S512",
              "kid": "MCON-CT4L-LAU5-UQTO-TPIS-MHJA-T7RG",
              "signature": "JA-l8CSrpdssVo6RheZKg22k2szLc3GrLpJSZjaRtsy5qmFCQ
  YvdwrNhOhZZIwPCFw7aJoy9G9cAudjhd3xtt7POzNpBv5DZAZD2IjknlHPREXM
  LVtW-D8ra6S1CSv4HPLQh63rsqH1DwQpbX5WhCjEA"}],
          "PayloadDigest": "c1V7yAlkEdwACebqyVNyQIGHhNZvORUuKKtbktuHh_dr9
  96S9-SJAUqpKO9tAxzlCFRwh0IFA6s16s-ATGqC9g"}],
      "DeviceUDF": "MCI5-LIBK-WCNE-SL7B-PZS4-6ZVH-JCCV",
      "EnvelopedProfileDevice": [{
          "dig": "S512"},
        "ewogICJQcm9maWxlRGV2aWNlIjogewogICAgIktleU9mZmxpbmVTaWd
  uYXR1cmUiOiB7CiAgICAgICJVREYiOiAiTUNJNS1MSUJLLVdDTkUtU0w3Qi1QW
  lM0LTZaVkgtSkNDViIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICA
  gICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJFZDQ0O
  CIsCiAgICAgICAgICAiUHVibGljIjogIl9QUExzMnNWZGJBcm1KNzE4dy0tY19
  5MEhHNjY5dWNfd1JWSmF0NnRvWHNOZ1ktejdNcEsKICBNdXBCZ2hQdk1xVmpRa
  zVOWnpnSUhBY0EifX19LAogICAgIktleUVuY3J5cHRpb24iOiB7CiAgICAgICJ
  VREYiOiAiTURMUy1OVkU0LUxJVEItTDdGRS1MS0RWLUwzSjctRzRJUyIsCiAgI
  CAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJsaWNLZXlFQ0R
  IIjogewogICAgICAgICAgImNydiI6ICJFZDQ0OCIsCiAgICAgICAgICAiUHVib
  GljIjogInlrek45WDltY2RGVmZxU2lSWndpZmtXZzBXU2hHSXk2UFAtTkFlUVl
  Ick9tcmNUcHdtVjgKICBfdlZlOURwektYYjFmZ1FIaEdpRUhHOEEifX19LAogI
  CAgIktleUF1dGhlbnRpY2F0aW9uIjogewogICAgICAiVURGIjogIk1DVjItVlZ
  ONi00RkszLUU3UEItVENBRi1SVTRJLUlWTkIiLAogICAgICAiUHVibGljUGFyY
  W1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICA
  gICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICIwRnZFZ2ZSS
  mlTRW9LUGtwMkl2dWl1NVNSeGJqRW5hSm9LQktfY2tiUksxYkVWNS1hc21NCiA
  gRUZFNDhkbXV6NzdDc3l1ZUNYRVFNc3lBIn19fX19",
        {
          "signatures": [{
              "alg": "S512",
              "kid": "MCI5-LIBK-WCNE-SL7B-PZS4-6ZVH-JCCV",
              "signature": "ewWoxIGAKKtzkCMg9YPgq26glhDnbbPy5N6UQmU1wb2Qa52FG
  3J8CstVDL682JA_eUvNc3FRdVEA_Vre-SD7QzlBI4ZbQfp6L_WyZlv0M6v-Ovo
  mXq_IC7tLjWx1VCnSz9GOp6VMU8J77jduqG5d2DUA"}],
          "PayloadDigest": "KgZwYRF_rnzpHa8T-WcqFMkffEEARVbF5OQP58fLPZQp8
  rTK6r6M_jUT_AMn5VVeevXNzmGzJSCZmN3_YPXuIw"}],
      "EnvelopedMessageConnectionResponse": [{
          "ContentMetaData": "ewogICJVbmlxdWVJRCI6ICJOQkZLLUpZNzMtV1lXVy1
  SU0JFLUhSREctRlBCMy1MTUQyIiwKICAiTWVzc2FnZVR5cGUiOiAiQWNrbm93b
  GVkZ2VDb25uZWN0aW9uIn0"},
        "ewogICJBY2tub3dsZWRnZUNvbm5lY3Rpb24iOiB7CiA
  gICAiTWVzc2FnZUlEIjogIk5CM1ItSTVCSy1RREIyLVFXWEctV1BWSy1OR0g2L
  U9JSUkiLAogICAgIkVudmVsb3BlZFJlcXVlc3RDb25uZWN0aW9uIjogW3t9LAo
  gICAgICAiZXdvZ0lDSlNaWEYxWlhOMFEyOXVibVZqZEdsdmJpSTYKICBJSHNLS
  UNBZ0lDSlRaWEoyYVdObFNVUWlPaUFpWVd4cFkyVkFaWGhoYlhCc1pTNWpiMjB
  pTEFvZ0lDQWdJawogIFZ1ZG1Wc2IzQmxaRkJ5YjJacGJHVkVaWFpwWTJVaU9pQ
  mJld29nSUNBZ0lDQWdJQ0prYVdjaU9pQWlVelV4CiAgTWlKOUxBb2dJQ0FnSUN
  BaVpYZHZaMGxEU2xGamJUbHRZVmQ0YkZKSFZqSmhWMDVzU1dwdloyVjNiMmRKU
  TAKICBGblNXdDBiR1ZWT1cxYWJYaHdZbTFXVkdGWFpBb2dJSFZaV0ZJeFkyMVZ
  hVTlwUWpkRGFVRm5TVU5CWjBsRAogIFNsWlNSVmxwVDJsQmFWUlZUa3BPVXpGT
  lUxVktURXhXWkVSVWExVjBWVEIzTTFGcE1WRlhDaUFnYkUwd1RGCiAgUmFZVlp
  yWjNSVGEwNUVWbWxKYzBOcFFXZEpRMEZuU1VOS1VXUlhTbk5oVjA1UldWaEthR
  0pYVmpCYVdFcDYKICBTV3B2WjJWM2IyZEpRMEVLSUNCblNVTkJaMGxEU2xGa1Y
  wcHpZVmRPVEZwWWJFWlJNRkpKU1dwdloyVjNiMgogIGRKUTBGblNVTkJaMGxEU
  VdkSmJVNTVaR2xKTmtsRFNrWmFSRkV3VHdvZ0lFTkpjME5wUVdkSlEwRm5TVU5
  CCiAgWjBsRFFXbFZTRlpwWWtkc2FrbHFiMmRKYkRsUlZVVjRlazF1VGxkYVIwc
  ENZMjB4UzA1NlJUUmtlVEIwV1QKICBFNUNpQWdOVTFGYUVoT2FsazFaRmRPWm1
  ReFNsZFRiVVl3VG01U2RsZElUazlhTVd0MFpXcGtUbU5GYzB0SgogIFEwSk9aR
  mhDUTFveWFGRmthekY0Vm0xd1VtRUtJQ0I2Vms5WGJuQnVVMVZvUWxrd1JXbG1
  XREU1VEVGdlowCiAgbERRV2RKYTNSc1pWVldkVmt6U2pWalNGSndZakkwYVU5c
  FFqZERhVUZuU1VOQlowbERTZ29nSUZaU1JWbHAKICBUMmxCYVZSVlVrMVZlVEZ
  QVm10Vk1FeFZlRXBXUlVsMFZFUmtSMUpUTVUxVE1GSlhURlYzZWxOcVkzUlNlb
  AogIEpLVlhsSmMwTnBRV2RKQ2lBZ1EwRm5TVU5LVVdSWFNuTmhWMDVSV1ZoS2F
  HSlhWakJhV0VwNlNXcHZaMlYzCiAgYjJkSlEwRm5TVU5CWjBsRFNsRmtWMHB6W
  VZkT1RGcFliRVpSTUZJS0lDQkpTV3B2WjJWM2IyZEpRMEZuU1UKICBOQlowbER
  RV2RKYlU1NVpHbEpOa2xEU2taYVJGRXdUME5KYzBOcFFXZEpRMEZuU1VOQlowb
  ERRV2xWU0ZacAogIFlnb2dJRWRzYWtscWIyZEpibXh5WldzME5WZEViSFJaTWx
  KSFZtMWFlRlV5YkZOWGJtUndXbTEwV0ZwNlFsCiAgaFZNbWhJVTFock1sVkdRW
  FJVYTBac1ZWWnNDaUFnU1dOck9YUmpiVTVWWTBoa2RGWnFaMHRKUTBKbVpHeGE
  KICBiRTlWVW5kbGEzUlpXV3BHYlZveFJrbGhSV1J3VWxWb1NFOUZSV2xtV0RFN
  VRFRnZaMGtLSUNCRFFXZEphMwogIFJzWlZWR01XUkhhR3hpYmxKd1dUSkdNR0Z
  YT1hWSmFtOW5aWGR2WjBsRFFXZEpRMEZwVmxWU1IwbHFiMmRKCiAgYXpGRVZtc
  EpkRlpzV2dvZ0lFOU9hVEF3VW10emVreFZWVE5WUlVsMFZrVk9RbEpwTVZOV1Z
  GSktURlZzVjEKICBSclNXbE1RVzluU1VOQlowbERRV2xWU0ZacFlrZHNhbFZIU
  m5sWkNpQWdWekZzWkVkV2VXTjVTVFpKU0hOTAogIFNVTkJaMGxEUVdkSlEwRnB
  WVWhXYVdKSGJHcFRNbFkxVWxWT1JWTkRTVFpKU0hOTFNVTkJaMGxEUVdkSlEwC
  iAgRUtJQ0JuU1VOS2FtTnVXV2xQYVVGcFVsZFJNRTVFWjJsTVFXOW5TVU5CWjB
  sRFFXZEpRMEZuU1d4Q01WbHQKICBlSEJaZVVrMlNVTkpkMUp1V2taYU1scFRVd
  29nSUcxc1ZGSlhPVXhWUjNSM1RXdHNNbVJYYkRGT1ZrNVRaVQogIGRLY1ZKWE5
  XaFRiVGxNVVd0MFpsa3lkR2xWYTNONFdXdFdWMDVUTVdoak1qRk9RMmxCQ2lBZ
  1oxSlZXa1pPCiAgUkdocllsaFdOazU2WkVSak0yd3hXbFZPV1ZKV1JrNWpNMnh
  DU1c0eE9XWllNVGtpTEFvZ0lDQWdJQ0I3Q2kKICBBZ0lDQWdJQ0FnSW5OcFoyN
  WhkSFZ5WlhNaU9pQmJld29nSUNBZ0lDQWdJQ0FnSUNBaVlXeG5Jam9nSWxNMQo
  gIE1USWlMQW9nSUNBZ0lDQWdJQ0FnSUNBaWEybGtJam9nSWsxRFNUVXRURWxDU
  3kxWFEwNUZMVk5NTjBJdFVGCiAgcFROQzAyV2xaSUxVcERRMVlpTEFvZ0lDQWd
  JQ0FnSUNBZ0lDQWljMmxuYm1GMGRYSmxJam9nSW1WM1YyOTQKICBTVWRCUzB0M
  GVtdERUV2M1V1ZCbmNUSTJaMnhvUkc1aVlsQjVOVTQyVlZGdFZURjNZakpSWVR
  VeVJrY0tJQwogIEF6U2poRGMzUldSRXcyT0RKS1FWOWxWWFpPWXpOR1VtUldSV
  UZmVm5KbExWTkVOMUY2YkVKSk5GcGlVV1p3CiAgTmt4ZlYzbGFiSFl3VFRaMkx
  VOTJid29nSUcxWWNWOUpRemQwVEdwWGVERldRMjVUZWpsSFQzQTJWazFWT0UKI
  CBvM04ycGtkWEZITldReVJGVkJJbjFkTEFvZ0lDQWdJQ0FnSUNKUVlYbHNiMkZ
  rUkdsblpYTjBJam9nSWt0bgogIFduZFpVa1pmY201NmNFaGhPRlF0VjJOeFJrM
  XJabVpGUlVGU1ZtSkdOVTlSVURVNFpreFFXbEZ3T0FvZ0lICiAgSlVTelp5Tms
  xZmFsVlVYMEZOYmpWV1ZtVmxkbGhPZW0xSGVrcFRRMXB0VGpOZldWQllkVWwzS
  W4xZExBb2cKICBJQ0FnSWtOc2FXVnVkRTV2Ym1ObElqb2dJbTk0Y1ZWUmVuaFF
  UMVZ0TmpWaFVEZFVYMDAwZDBFaWZYMCJdLAogICAgIlNlcnZlck5vbmNlIjogI
  kV5UlN1QTZkaS1DYU1vN1pFS0l4N2ciLAogICAgIldpdG5lc3MiOiAiQVNPRS1
  GQU5VLVdOMk4tVVEyNC1KQkhFLUdTSFYtRUtRTCJ9fQ"],
      "EnvelopedAccountAssertion": [{
          "dig": "S512"},
        "ewogICJQcm9maWxlQWNjb3VudCI6IHsKICAgICJLZXlPZmZsaW5lU2l
  nbmF0dXJlIjogewogICAgICAiVURGIjogIk1CVFctSUc2SC00M0NJLTJYT04tM
  k43WS1OVFc1LVVCVUoiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICA
  gICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0N
  DgiLAogICAgICAgICAgIlB1YmxpYyI6ICI0cGJNdmEyaUFGeWI3b3pIVGZRVmF
  WRklwUmFlbGlGZFhqaVJ2aFRPN1F3V2h3bXpnSi1HCiAgOHJOS0pMLXVoaThEa
  zhlOHpuUXdiREtBIn19fSwKICAgICJLZXlzT25saW5lU2lnbmF0dXJlIjogW3s
  KICAgICAgICAiVURGIjogIk1BQ0MtTTYySi1HTEdOLVVDWTYtVEtKVi1YTlpWL
  Uo2T0giLAogICAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICA
  gIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAgICJjcnYiOiAiRWQ0NDgiL
  AogICAgICAgICAgICAiUHVibGljIjogImJiLWNhWElWS0NKYjFCYzlSVXJVb0V
  UaXgyX05QR3FoZlZsSWxnWHNEWDhrYTJMcjRreVYKICBQcUg5eG5DUlBJMk1We
  DdORkoyVU9YR0EifX19XSwKICAgICJTZXJ2aWNlSURzIjogWyJhbGljZUBleGF
  tcGxlLmNvbSJdLAogICAgIk1lc2hQcm9maWxlVURGIjogIk1DT04tQ1Q0TC1MQ
  VU1LVVRVE8tVFBJUy1NSEpBLVQ3UkciLAogICAgIktleUVuY3J5cHRpb24iOiB
  7CiAgICAgICJVREYiOiAiTUM1WC1CNUFRLU8yQVItU05LVC1KVDIzLUNQTDQtU
  ldPViIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJ
  saWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJFZDQ0OCIsCiAgICAgI
  CAgICAiUHVibGljIjogImhIeExZaDBvYmRDYmJNcWw3RzhQR3o2b0xYdVlxTS1
  Ed0VOY2NPYlFTb1pNWkhCWFRQcVoKICBWWkNoQU1idkhGM2pqSW1aNGpYT3IxW
  UEifX19fX0",
        {
          "signatures": [{
              "alg": "S512",
              "kid": "MDVN-HBLF-Q3BF-OSCT-OLX4-TDSY-TY3W",
              "signature": "XDt6-O6FDpfP8z2gr2STjXlAbe2ekivkai7W4j9CWwHj4VhVo
  dwb84JgaMazE0kOa2t4tvuualOADW_3JLFVMQ_ehy3J8Hg9pftezTcCQxR8SqR
  mUTRkoL3VZpwWqiIPCt7c3gwbVLnjoeyEzoUQGBsA"}],
          "PayloadDigest": "mO4nivX1v00Z42_ZJ2HF5FRryysWiOrEHtBDjhWDCXc9B
  QutYyK_BjmIM8krtP-HDyqAX2PDK5DSxaOAfdVJGA"}]}}}
</div>
~~~~



