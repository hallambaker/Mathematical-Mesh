

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
<cmd>Alice> device accept NCOR-5R5M-T3UO-56RL-6RGR-DRD5-IM4G
<rsp></div>
~~~~

Specifying the /json option returns a result of type ResultConnectProcess:

~~~~
<div="terminal">
<cmd>Alice> device accept NCOR-5R5M-T3UO-56RL-6RGR-DRD5-IM4G /json
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
<cmd>Alice> device accept NCOR-5R5M-T3UO-56RL-6RGR-DRD5-IM4G
<rsp></div>
~~~~

Specifying the /json option returns a result of type ResultConnectProcess:

~~~~
<div="terminal">
<cmd>Alice> device accept NCOR-5R5M-T3UO-56RL-6RGR-DRD5-IM4G /json
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
<cmd>Alice> device delete NCOR-5R5M-T3UO-56RL-6RGR-DRD5-IM4G
<rsp>ERROR - The feature has not been implemented
</div>
~~~~

Specifying the /json option returns a result of type Result:

~~~~
<div="terminal">
<cmd>Alice> device delete NCOR-5R5M-T3UO-56RL-6RGR-DRD5-IM4G /json
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
<cmd>Alice> device earl udf://example.com/EABL-KTZW-DYTP-7GBS-P2MK-GJQ6-2XOB-74
<rsp>ERROR - Object reference not set to an instance of an object.
</div>
~~~~

Specifying the /json option returns a result of type Result:

~~~~
<div="terminal">
<cmd>Alice> device earl udf://example.com/EABL-KTZW-DYTP-7GBS-P2MK-GJQ6-2XOB-74 /json
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
        "MessageID": "NCOR-5R5M-T3UO-56RL-6RGR-DRD5-IM4G",
        "EnvelopedRequestConnection": [{},
          "ewogICJSZXF1ZXN0Q29ubmVjdGlvbiI6
  IHsKICAgICJTZXJ2aWNlSUQiOiAiYWxpY2VAZXhhbXBsZS5jb20iLAogICAgIk
  VudmVsb3BlZFByb2ZpbGVEZXZpY2UiOiBbewogICAgICAgICJkaWciOiAiUzUx
  MiJ9LAogICAgICAiZXdvZ0lDSlFjbTltYVd4bFJHVjJhV05sSWpvZ2V3b2dJQ0
  FnSWt0bGVVOW1abXhwYm1WVGFXZAogIHVZWFIxY21VaU9pQjdDaUFnSUNBZ0lD
  SlZSRVlpT2lBaVRVRllWQzFGUWpkVExUUkpUVXN0VTAxUlZ5MVJNCiAgMVpLTF
  VOTVMxRXROMUpOU3lJc0NpQWdJQ0FnSUNKUWRXSnNhV05RWVhKaGJXVjBaWEp6
  SWpvZ2V3b2dJQ0EKICBnSUNBZ0lDSlFkV0pzYVdOTFpYbEZRMFJJSWpvZ2V3b2
  dJQ0FnSUNBZ0lDQWdJbU55ZGlJNklDSkZaRFEwTwogIENJc0NpQWdJQ0FnSUNB
  Z0lDQWlVSFZpYkdsaklqb2dJbXMwVjAxVGNWbG5XVmRwTkUxQlRWZG5lRkZ5VU
  RWCiAgTWNuaG9WVzk2TUV4Q1gwSkhNMlZmZVRKeVEyd3lZV1Z0WTJOUmVIQUtJ
  Q0JoU2pObk9UWlVkMDlwWDBsSlEKICAxcFBSRzlIZW1odFpVRWlmWDE5TEFvZ0
  lDQWdJa3RsZVVWdVkzSjVjSFJwYjI0aU9pQjdDaUFnSUNBZ0lDSgogIFZSRVlp
  T2lBaVRVSkRUaTFhV2xkRUxUWTNRazB0U2pKVFRDMVVRek0zTFVkWFIwb3RSVX
  BZUlNJc0NpQWdJCiAgQ0FnSUNKUWRXSnNhV05RWVhKaGJXVjBaWEp6SWpvZ2V3
  b2dJQ0FnSUNBZ0lDSlFkV0pzYVdOTFpYbEZRMFIKICBJSWpvZ2V3b2dJQ0FnSU
  NBZ0lDQWdJbU55ZGlJNklDSkZaRFEwT0NJc0NpQWdJQ0FnSUNBZ0lDQWlVSFZp
  YgogIEdsaklqb2dJbUpWUWxsSU5YQklWV1ZZWXkxc1owSndRbGxqYzJKQmEzRk
  pSVU5IVkY5alIzRXljVk5tVlRSCiAgTU5EUnJVRTVoT0ZWTk1XMEtJQ0J3ZDFG
  Mk1XcFZiME5WUlZWdVdscFVSM05vZDA0dGEwRWlmWDE5TEFvZ0kKICBDQWdJa3
  RsZVVGMWRHaGxiblJwWTJGMGFXOXVJam9nZXdvZ0lDQWdJQ0FpVlVSR0lqb2dJ
  azFCVTFndE5WWgogIFRXUzB6VDB0TExVZEJOVE10UjBsWlJpMHlSalpDTFZOUE
  5rUWlMQW9nSUNBZ0lDQWlVSFZpYkdsalVHRnlZCiAgVzFsZEdWeWN5STZJSHNL
  SUNBZ0lDQWdJQ0FpVUhWaWJHbGpTMlY1UlVORVNDSTZJSHNLSUNBZ0lDQWdJQ0
  EKICBnSUNKamNuWWlPaUFpUldRME5EZ2lMQW9nSUNBZ0lDQWdJQ0FnSWxCMVlt
  eHBZeUk2SUNKNFpXRlFia2RKTgogIEc5SGQzb3lMVFF5VEdWa1ZUTTNZbTF2VE
  dscFlrMUhaRWhTUjJObVVsTjZjV2xJV0hkVk9URXhVRjlJQ2lBCiAgZ1NYSmhV
  bVJhVWxkNlgwOUNURVIxYkZkb00zUjNjbEZCSW4xOWZYMTkiLAogICAgICB7Ci
  AgICAgICAgInNpZ25hdHVyZXMiOiBbewogICAgICAgICAgICAiYWxnIjogIlM1
  MTIiLAogICAgICAgICAgICAia2lkIjogIk1BWFQtRUI3Uy00SU1LLVNNUVctUT
  NWSi1DTEtRLTdSTUsiLAogICAgICAgICAgICAic2lnbmF0dXJlIjogInNJbk5P
  RUVRSjN3aFVibUJIR0dWNXJCVmhtRWRfUE40eWRRUW9DYXBXVEJJSlQxc2QKIC
  BidkFCVllxR1NCcmx4Q2lTSDRmTVFlVWlTNkFpaHhqTHRZR2N5RC01VUVQOUpK
  YzlSWU5SZFlYdGRnMzZSUAogIEhWX3loaUpXcktHdU1tdlBveW1QTkk1ZUYzZE
  xPV1dYdHNNS1Y4eXNBIn1dLAogICAgICAgICJQYXlsb2FkRGlnZXN0IjogIlE5
  UUU3U0E5RTRwckk2NGV6eFJvSHRlb1JORUNYc1V6dDZEYzZwZzZpM3BnLQogIF
  VjY1BCRy0xSUMxVzQ1UU1RMy10WXRsUnE2dDJrQzR1UV9vZ2NTTFhRIn1dLAog
  ICAgIkNsaWVudE5vbmNlIjogImpDVG5rbjJOd21nSklsMUYzMGtuVHcifX0"],
        "ServerNonce": "tbXfF-H7t9Bewo6QH9P7Yg",
        "Witness": "SYWD-GC4A-FZPO-ZY27-FEKV-LEMM-LVLO"},
      {
        "MessageID": "NACG-VWPR-YKGR-WUSJ-RTWE-WVXS-RVZS",
        "EnvelopedRequestConnection": [{},
          "ewogICJSZXF1ZXN0Q29ubmVjdGlvbiI6
  IHsKICAgICJTZXJ2aWNlSUQiOiAiYWxpY2VAZXhhbXBsZS5jb20iLAogICAgIk
  VudmVsb3BlZFByb2ZpbGVEZXZpY2UiOiBbewogICAgICAgICJkaWciOiAiUzUx
  MiJ9LAogICAgICAiZXdvZ0lDSlFjbTltYVd4bFJHVjJhV05sSWpvZ2V3b2dJQ0
  FnSWt0bGVVOW1abXhwYm1WVGFXZAogIHVZWFIxY21VaU9pQjdDaUFnSUNBZ0lD
  SlZSRVlpT2lBaVRVSkVUQzFQUWt0RUxVdFdVRkF0VjFSTFFpMVVVCiAgMFpFTF
  ZGV05VRXRSMHhXUnlJc0NpQWdJQ0FnSUNKUWRXSnNhV05RWVhKaGJXVjBaWEp6
  SWpvZ2V3b2dJQ0EKICBnSUNBZ0lDSlFkV0pzYVdOTFpYbEZRMFJJSWpvZ2V3b2
  dJQ0FnSUNBZ0lDQWdJbU55ZGlJNklDSkZaRFEwTwogIENJc0NpQWdJQ0FnSUNB
  Z0lDQWlVSFZpYkdsaklqb2dJbEpDUzFsdFkyWlBjWGhyWjBSck9HRnBUbVYxYV
  VFCiAgMU1rbzJha0pKT0dsSmVreFhkMlZYZVZKcGJXTllhekZVWW5oeU5ISUtJ
  Q0IzT1hWR1N6UTJUbU00Ukd0dmIKICAzZFdWRlJtVjA0eWQwRWlmWDE5TEFvZ0
  lDQWdJa3RsZVVWdVkzSjVjSFJwYjI0aU9pQjdDaUFnSUNBZ0lDSgogIFZSRVlp
  T2lBaVRVSlFVaTFJUTB0R0xVMUJWMVl0TWpSTlNTMUlNazlVTFUxTVdVVXRRa1
  JPU3lJc0NpQWdJCiAgQ0FnSUNKUWRXSnNhV05RWVhKaGJXVjBaWEp6SWpvZ2V3
  b2dJQ0FnSUNBZ0lDSlFkV0pzYVdOTFpYbEZRMFIKICBJSWpvZ2V3b2dJQ0FnSU
  NBZ0lDQWdJbU55ZGlJNklDSkZaRFEwT0NJc0NpQWdJQ0FnSUNBZ0lDQWlVSFZp
  YgogIEdsaklqb2dJa2hDWTFWdlUydHdjakU0VFdac2RrUnVNMU41VmxOM1RIVk
  dObWxZWTI1WGVqZFFZMDVKWTJ0CiAgM2JrNUlUblp0VVVKS09XZ0tJQ0IxZG1a
  S0xUTktMVU42UW1OTFpFZExWbVJaZFVwdU5rRWlmWDE5TEFvZ0kKICBDQWdJa3
  RsZVVGMWRHaGxiblJwWTJGMGFXOXVJam9nZXdvZ0lDQWdJQ0FpVlVSR0lqb2dJ
  azFEUkRRdFZsUgogIFZReTAwUlRjMkxWRlJSRmd0V0VGSVVpMUZTRFUxTFRWT1
  NVd2lMQW9nSUNBZ0lDQWlVSFZpYkdsalVHRnlZCiAgVzFsZEdWeWN5STZJSHNL
  SUNBZ0lDQWdJQ0FpVUhWaWJHbGpTMlY1UlVORVNDSTZJSHNLSUNBZ0lDQWdJQ0
  EKICBnSUNKamNuWWlPaUFpUldRME5EZ2lMQW9nSUNBZ0lDQWdJQ0FnSWxCMVlt
  eHBZeUk2SUNKRFlVUk5ZbWhJVwogIG00dFNFb3diMU5PWW1GT2VEZFdkRmhPYz
  NwTWRXWTBlRVJFUkRObmRqQXdYekJwTkhJMlgwTk5SRzlNQ2lBCiAgZ2VHNTRX
  VkJYUzNsU2FscG9TM0JSVEZVMVNrWklMVEpCSW4xOWZYMTkiLAogICAgICB7Ci
  AgICAgICAgInNpZ25hdHVyZXMiOiBbewogICAgICAgICAgICAiYWxnIjogIlM1
  MTIiLAogICAgICAgICAgICAia2lkIjogIk1CREwtT0JLRC1LVlBQLVdUS0ItVF
  NGRC1RVjVBLUdMVkciLAogICAgICAgICAgICAic2lnbmF0dXJlIjogIjRQYjNY
  S243VFZtWjJxcVJuQy12cVYyc0szQ2JETTRTTmozYkZ0dFhzWmFSbXplUFIKIC
  AxdFRyOHF5NzY3RVQyaFE0b3dCeEtQS2lQV0FXa1h1TU9OdXdKdjl6QmFxcm1T
  d3pEVl9Bdk1WX0FBc251VwogIFVUaGt5OW45a0JoMHhLOGRQNmZiSi0tZS1RZl
  VNR3lKWFZrUjh6ajRBIn1dLAogICAgICAgICJQYXlsb2FkRGlnZXN0IjogIlcw
  QmtBdWxvc2dhRk56TWJzUzY5VVdiUmtBZi13dUY2a2piYXdHNVlkSVlMUwogIF
  FLN3BTS19xVzFIWkdtUGFSXzNJT3hTamtkMkxWN1lxamZjV05LZFNRIn1dLAog
  ICAgIkNsaWVudE5vbmNlIjogIlA3WUhSQl9LN2pLSGtzY0lvSENld0EifX0"],
        "ServerNonce": "YoEB3s5RQhAd6jvIEOqLsw",
        "Witness": "VHHK-22IB-74MU-JOLK-GJF7-SE6W-6TR7"}]}}
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
<cmd>Alice> device reject NACG-VWPR-YKGR-WUSJ-RTWE-WVXS-RVZS
<rsp></div>
~~~~

Specifying the /json option returns a result of type ResultConnectProcess:

~~~~
<div="terminal">
<cmd>Alice> device reject NACG-VWPR-YKGR-WUSJ-RTWE-WVXS-RVZS /json
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
<cmd>Alice4> device pre devices@example.com /key=udf://example.com/EABL-KTZW-DYTP-7GBS-P2MK-GJQ6-2XOB-74
<rsp>ERROR - Object reference not set to an instance of an object.
</div>
~~~~

Specifying the /json option returns a result of type Result:

~~~~
<div="terminal">
<cmd>Alice4> device pre devices@example.com /key=udf://example.com/EABL-KTZW-DYTP-7GBS-P2MK-GJQ6-2XOB-74 /json
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
<rsp>   Witness value = VHHK-22IB-74MU-JOLK-GJF7-SE6W-6TR7
   Personal Mesh = MA5E-Q7B3-SQ5O-6OS2-WBTJ-BFVE-I3S3
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
      "ID": "MBDL-OBKD-KVPP-WTKB-TSFD-QV5A-GLVG",
      "EnvelopedProfileMaster": [{
          "dig": "S512"},
        "ewogICJQcm9maWxlTWVzaCI6IHsKICAgICJLZXlPZmZsaW5lU2lnbmF
  0dXJlIjogewogICAgICAiVURGIjogIk1BNUUtUTdCMy1TUTVPLTZPUzItV0JUS
  i1CRlZFLUkzUzMiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICA
  gICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiL
  AogICAgICAgICAgIlB1YmxpYyI6ICJoaFNYR3VkdmFLaW9JU1otc3NhVWtZV04
  1ZmV3WDhMQ0FnMWk3M0twR21wVHNZWTMwRjFJCiAgMm9QeVlrcWZnNllia0dfT
  FE5RlR6N3FBIn19fSwKICAgICJLZXlzT25saW5lU2lnbmF0dXJlIjogW3sKICA
  gICAgICAiVURGIjogIk1BQ0YtQTZPNi1LSk9QLVNJVVctVEpMRS1IVDVRLUJaQ
  VYiLAogICAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICAgIlB
  1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogI
  CAgICAgICAgICAiUHVibGljIjogIm52TVFxc19qNlFNZ0xGdnU1dzFuOW5CcUp
  xVG8zMVJkMXVRTURRQ0NJb0NralZSSVU5aEwKICBIbjh0QWlYSXcyVlZfY2lJd
  09wOVFUNkEifX19XSwKICAgICJLZXlFbmNyeXB0aW9uIjogewogICAgICAiVUR
  GIjogIk1BUk4tTk43Vi1BRlJULVdKWTUtSE01WS1BNktSLTJaQVUiLAogICAgI
  CAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNESCI
  6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAgIlB1YmxpY
  yI6ICJrT2JqWDdfTFIxUkVzRHJsT0RwajV1UFlWeTg1Q1JlZWgzX2xoSGpYZGx
  QbFpac1dRbVQ2CiAgQXNHYlV2RGVIZE9tdzVOWmJybmZBRUlBIn19fX19",
        {
          "signatures": [{
              "alg": "S512",
              "kid": "MA5E-Q7B3-SQ5O-6OS2-WBTJ-BFVE-I3S3",
              "signature": "ezZVhIiAMJgH9R-QKz00c9NhM-JfkzJJ2js3VL0jT3OUVJzYG
  oG5b3j-QAfnEQr-U02k6bzqTwoAyiWkBki6OuIrWZnLsDbRQyE_MjUYategYS_
  ZbGGimqWkbjwLPTUegAshvcSfVOvT_dUuySlT0AwA"}],
          "PayloadDigest": "OAM7VjIwAxhfJjBdHsViluV2isPerTDMZKy75rQsEbN4l
  5C1TuLI9txSXfKx7wx9ryST8sgsGVtGI6k89PxA7Q"}],
      "DeviceUDF": "MBDL-OBKD-KVPP-WTKB-TSFD-QV5A-GLVG",
      "EnvelopedProfileDevice": [{
          "dig": "S512"},
        "ewogICJQcm9maWxlRGV2aWNlIjogewogICAgIktleU9mZmxpbmVTaWd
  uYXR1cmUiOiB7CiAgICAgICJVREYiOiAiTUJETC1PQktELUtWUFAtV1RLQi1UU
  0ZELVFWNUEtR0xWRyIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICA
  gICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJFZDQ0O
  CIsCiAgICAgICAgICAiUHVibGljIjogIlJCS1ltY2ZPcXhrZ0RrOGFpTmV1aUE
  1Mko2akJJOGlJekxXd2VXeVJpbWNYazFUYnhyNHIKICB3OXVGSzQ2TmM4RGtvb
  3dWVFRmV04yd0EifX19LAogICAgIktleUVuY3J5cHRpb24iOiB7CiAgICAgICJ
  VREYiOiAiTUJQUi1IQ0tGLU1BV1YtMjRNSS1IMk9ULU1MWUUtQkROSyIsCiAgI
  CAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJsaWNLZXlFQ0R
  IIjogewogICAgICAgICAgImNydiI6ICJFZDQ0OCIsCiAgICAgICAgICAiUHVib
  GljIjogIkhCY1VvU2twcjE4TWZsdkRuM1N5VlN3THVGNmlYY25XejdQY05JY2t
  3bk5ITnZtUUJKOWgKICB1dmZKLTNKLUN6QmNLZEdLVmRZdUpuNkEifX19LAogI
  CAgIktleUF1dGhlbnRpY2F0aW9uIjogewogICAgICAiVURGIjogIk1DRDQtVlR
  VQy00RTc2LVFRRFgtWEFIUi1FSDU1LTVOSUwiLAogICAgICAiUHVibGljUGFyY
  W1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICA
  gICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJDYURNYmhIW
  m4tSEowb1NOYmFOeDdWdFhOc3pMdWY0eERERDNndjAwXzBpNHI2X0NNRG9MCiA
  geG54WVBXS3lSalpoS3BRTFU1SkZILTJBIn19fX19",
        {
          "signatures": [{
              "alg": "S512",
              "kid": "MBDL-OBKD-KVPP-WTKB-TSFD-QV5A-GLVG",
              "signature": "4Pb3XKn7TVmZ2qqRnC-vqV2sK3CbDM4SNj3bFttXsZaRmzePR
  1tTr8qy767ET2hQ4owBxKPKiPWAWkXuMONuwJv9zBaqrmSwzDV_AvMV_AAsnuW
  UThky9n9kBh0xK8dP6fbJ--e-QfUMGyJXVkR8zj4A"}],
          "PayloadDigest": "W0BkAulosgaFNzMbsS69UWbRkAf-wuF6kjbawG5YdIYLS
  QK7pSK_qW1HZGmPaR_3IOxSjkd2LV7YqjfcWNKdSQ"}],
      "EnvelopedMessageConnectionResponse": [{
          "ContentMetaData": "ewogICJVbmlxdWVJRCI6ICJORDYzLUlRNUwtU0tCVi1
  RQTNCLTVWVkktUVZPVS1ZTjdTIiwKICAiTWVzc2FnZVR5cGUiOiAiQWNrbm93b
  GVkZ2VDb25uZWN0aW9uIn0"},
        "ewogICJBY2tub3dsZWRnZUNvbm5lY3Rpb24iOiB7CiA
  gICAiTWVzc2FnZUlEIjogIk5BQ0ctVldQUi1ZS0dSLVdVU0otUlRXRS1XVlhTL
  VJWWlMiLAogICAgIkVudmVsb3BlZFJlcXVlc3RDb25uZWN0aW9uIjogW3t9LAo
  gICAgICAiZXdvZ0lDSlNaWEYxWlhOMFEyOXVibVZqZEdsdmJpSTYKICBJSHNLS
  UNBZ0lDSlRaWEoyYVdObFNVUWlPaUFpWVd4cFkyVkFaWGhoYlhCc1pTNWpiMjB
  pTEFvZ0lDQWdJawogIFZ1ZG1Wc2IzQmxaRkJ5YjJacGJHVkVaWFpwWTJVaU9pQ
  mJld29nSUNBZ0lDQWdJQ0prYVdjaU9pQWlVelV4CiAgTWlKOUxBb2dJQ0FnSUN
  BaVpYZHZaMGxEU2xGamJUbHRZVmQ0YkZKSFZqSmhWMDVzU1dwdloyVjNiMmRKU
  TAKICBGblNXdDBiR1ZWT1cxYWJYaHdZbTFXVkdGWFpBb2dJSFZaV0ZJeFkyMVZ
  hVTlwUWpkRGFVRm5TVU5CWjBsRAogIFNsWlNSVmxwVDJsQmFWUlZTa1ZVUXpGU
  VVXdDBSVXhWZEZkVlJrRjBWakZTVEZGcE1WVlZDaUFnTUZwRlRGCiAgWkdWMDV
  WUlhSU01IaFhVbmxKYzBOcFFXZEpRMEZuU1VOS1VXUlhTbk5oVjA1UldWaEthR
  0pYVmpCYVdFcDYKICBTV3B2WjJWM2IyZEpRMEVLSUNCblNVTkJaMGxEU2xGa1Y
  wcHpZVmRPVEZwWWJFWlJNRkpKU1dwdloyVjNiMgogIGRKUTBGblNVTkJaMGxEU
  VdkSmJVNTVaR2xKTmtsRFNrWmFSRkV3VHdvZ0lFTkpjME5wUVdkSlEwRm5TVU5
  CCiAgWjBsRFFXbFZTRlpwWWtkc2FrbHFiMmRKYkVwRFV6RnNkRmt5V2xCaldHa
  HlXakJTY2s5SFJuQlViVll4WVYKICBWRkNpQWdNVTFyYnpKaGEwcEtUMGRzU21
  WcmVGaGtNbFpZWlZaS2NHSlhUbGxoZWtaVldXNW9lVTVJU1V0SgogIFEwSXpUM
  WhXUjFONlVUSlViVTAwVWtkMGRtSUtJQ0F6WkZkV1JsSnRWakEwZVdRd1JXbG1
  XREU1VEVGdlowCiAgbERRV2RKYTNSc1pWVldkVmt6U2pWalNGSndZakkwYVU5c
  FFqZERhVUZuU1VOQlowbERTZ29nSUZaU1JWbHAKICBUMmxCYVZSVlNsRlZhVEZ
  KVVRCMFIweFZNVUpXTVZsMFRXcFNUbE5UTVVsTmF6bFZURlV4VFZkVlZYUlJhM
  QogIEpQVTNsSmMwTnBRV2RKQ2lBZ1EwRm5TVU5LVVdSWFNuTmhWMDVSV1ZoS2F
  HSlhWakJhV0VwNlNXcHZaMlYzCiAgYjJkSlEwRm5TVU5CWjBsRFNsRmtWMHB6W
  VZkT1RGcFliRVpSTUZJS0lDQkpTV3B2WjJWM2IyZEpRMEZuU1UKICBOQlowbER
  RV2RKYlU1NVpHbEpOa2xEU2taYVJGRXdUME5KYzBOcFFXZEpRMEZuU1VOQlowb
  ERRV2xWU0ZacAogIFlnb2dJRWRzYWtscWIyZEphMmhEV1RGV2RsVXlkSGRqYWt
  VMFZGZGFjMlJyVW5WTk1VNDFWbXhPTTFSSVZrCiAgZE9iV3haV1RJMVdHVnFaR
  kZaTURWS1dUSjBDaUFnTTJKck5VbFVibHAwVlZWS1MwOVhaMHRKUTBJeFpHMWE
  KICBTMHhVVGt0TVZVNDJVVzFPVEZwRlpFeFdiVkphWkZWd2RVNXJSV2xtV0RFN
  VRFRnZaMGtLSUNCRFFXZEphMwogIFJzWlZWR01XUkhhR3hpYmxKd1dUSkdNR0Z
  YT1hWSmFtOW5aWGR2WjBsRFFXZEpRMEZwVmxWU1IwbHFiMmRKCiAgYXpGRVVrU
  lJkRlpzVWdvZ0lGWlJlVEF3VWxSak1reFdSbEpTUm1kMFYwVkdTVlZwTVVaVFJ
  GVXhURlJXVDEKICBOVmQybE1RVzluU1VOQlowbERRV2xWU0ZacFlrZHNhbFZIU
  m5sWkNpQWdWekZzWkVkV2VXTjVTVFpKU0hOTAogIFNVTkJaMGxEUVdkSlEwRnB
  WVWhXYVdKSGJHcFRNbFkxVWxWT1JWTkRTVFpKU0hOTFNVTkJaMGxEUVdkSlEwC
  iAgRUtJQ0JuU1VOS2FtTnVXV2xQYVVGcFVsZFJNRTVFWjJsTVFXOW5TVU5CWjB
  sRFFXZEpRMEZuU1d4Q01WbHQKICBlSEJaZVVrMlNVTktSRmxWVWs1WmJXaEpWd
  29nSUcwMGRGTkZiM2RpTVU1UFdXMUdUMlZFWkZka1JtaFBZegogIE53VFdSWFd
  UQmxSVkpGVWtST2JtUnFRWGRZZWtKd1RraEpNbGd3VGs1U1J6bE5RMmxCQ2lBZ
  1oyVkhOVFJYCiAgVmtKWVV6TnNVMkZzY0c5VE0wSlNWRVpWTVZOcldrbE1WRXB
  DU1c0eE9XWllNVGtpTEFvZ0lDQWdJQ0I3Q2kKICBBZ0lDQWdJQ0FnSW5OcFoyN
  WhkSFZ5WlhNaU9pQmJld29nSUNBZ0lDQWdJQ0FnSUNBaVlXeG5Jam9nSWxNMQo
  gIE1USWlMQW9nSUNBZ0lDQWdJQ0FnSUNBaWEybGtJam9nSWsxQ1JFd3RUMEpMU
  kMxTFZsQlFMVmRVUzBJdFZGCiAgTkdSQzFSVmpWQkxVZE1Wa2NpTEFvZ0lDQWd
  JQ0FnSUNBZ0lDQWljMmxuYm1GMGRYSmxJam9nSWpSUVlqTlkKICBTMjQzVkZad
  FdqSnhjVkp1UXkxMmNWWXljMHN6UTJKRVRUUlRUbW96WWtaMGRGaHpXbUZTYlh
  wbFVGSUtJQwogIEF4ZEZSeU9IRjVOelkzUlZReWFGRTBiM2RDZUV0UVMybFFWM
  EZYYTFoMVRVOU9kWGRLZGpsNlFtRnhjbTFUCiAgZDNwRVZsOUJkazFXWDBGQmM
  yNTFWd29nSUZWVWFHdDVPVzQ1YTBKb01IaExPR1JRTm1aaVNpMHRaUzFSWmwKI
  CBWTlIzbEtXRlpyVWpoNmFqUkJJbjFkTEFvZ0lDQWdJQ0FnSUNKUVlYbHNiMkZ
  rUkdsblpYTjBJam9nSWxjdwogIFFtdEJkV3h2YzJkaFJrNTZUV0p6VXpZNVZWZ
  GlVbXRCWmkxM2RVWTJhMnBpWVhkSE5WbGtTVmxNVXdvZ0lGCiAgRkxOM0JUUzE
  5eFZ6RklXa2R0VUdGU1h6TkpUM2hUYW10a01reFdOMWx4YW1aalYwNUxaRk5SS
  W4xZExBb2cKICBJQ0FnSWtOc2FXVnVkRTV2Ym1ObElqb2dJbEEzV1VoU1FsOUx
  OMnBMU0d0elkwbHZTRU5sZDBFaWZYMCJdLAogICAgIlNlcnZlck5vbmNlIjogI
  llvRUIzczVSUWhBZDZqdklFT3FMc3ciLAogICAgIldpdG5lc3MiOiAiVkhISy0
  yMklCLTc0TVUtSk9MSy1HSkY3LVNFNlctNlRSNyJ9fQ"],
      "EnvelopedAccountAssertion": [{
          "dig": "S512"},
        "ewogICJQcm9maWxlQWNjb3VudCI6IHsKICAgICJLZXlPZmZsaW5lU2l
  nbmF0dXJlIjogewogICAgICAiVURGIjogIk1BQ08tVlBDUy1TWFFPLUdRQk4tR
  UFPWC1BVkJaLVc1MkoiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICA
  gICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0N
  DgiLAogICAgICAgICAgIlB1YmxpYyI6ICJURDg2X3VVbWhJTG1MdmRJcExONXZ
  PcVBHbGFldUNHeElyRC13Z3FZY0tuNHRyNThDNEs0CiAgdDdkZ1gxV2IzRUZhW
  DY4TEZOVUZjVUNBIn19fSwKICAgICJLZXlzT25saW5lU2lnbmF0dXJlIjogW3s
  KICAgICAgICAiVURGIjogIk1DTVQtTFJONS1QSTdNLVRWM0YtMkFJSS1SV05EL
  VgyRk8iLAogICAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICA
  gIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAgICJjcnYiOiAiRWQ0NDgiL
  AogICAgICAgICAgICAiUHVibGljIjogIjJiazNyaVZDa1FXSzVxMl84R2MxeG5
  ORTRhTExyVVZrWnQ2RlNrS3piRXJ2UXl4ejh1N1AKICBselM4ajNmMnp2RFRWU
  HBCcW9LdndLdUEifX19XSwKICAgICJTZXJ2aWNlSURzIjogWyJhbGljZUBleGF
  tcGxlLmNvbSJdLAogICAgIk1lc2hQcm9maWxlVURGIjogIk1BNUUtUTdCMy1TU
  TVPLTZPUzItV0JUSi1CRlZFLUkzUzMiLAogICAgIktleUVuY3J5cHRpb24iOiB
  7CiAgICAgICJVREYiOiAiTUFLSC1EUlBMLVVJVzYtQjUzMy0yQlI2LVpNRUItT
  FdWRyIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJ
  saWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJFZDQ0OCIsCiAgICAgI
  CAgICAiUHVibGljIjogIkYtM0hCMzNhYUlidjBGd0p3SXktN1VyeVNteDVpWk9
  BRzlNb2tRZ0pYRDV3eldSZ2tiOGIKICBiSkt0Vm42TXFYTFhVVC1LSXFOTU5MU
  UEifX19fX0",
        {
          "signatures": [{
              "alg": "S512",
              "kid": "MACF-A6O6-KJOP-SIUW-TJLE-HT5Q-BZAV",
              "signature": "XsomDQxhyGoam0JGAAH4RC6PeDTS6DKjYBBaFOBPTcJZE33-T
  vfeuZPHulPgFlMlZOCyfZUcq_qAZETXNPUK3uIIMlZBhKEYQlNGW-XEU1hnXYI
  7ncBpjz9rQdtIpw9dfnfP3LoyvkIBVZrraE5wOCsA"}],
          "PayloadDigest": "kCal45O8SGjEZZ0JsIQsQ_-3nCZWFqEVG_vg6zAEfhT7J
  r0PVJ6gMuQHwfrxKGol3WSyRvEkvk7P7_EiA716pQ"}]}}}
</div>
~~~~



