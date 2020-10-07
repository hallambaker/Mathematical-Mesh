

# device

~~~~
<div="helptext">
<over>
device    Device management commands.
    accept   Accept a pending connection
    auth   Authorize device to use application
    complete   Complete a pending request
    delete   Remove device from device catalog
    install   Connect by means of a connection URI from an administration device.
    join   Connect by means of a connection URI from an administration device.
    list   List devices in the device catalog
    pending   Get list of pending connection requests
    preconfig   Generate new device profile and publish as an EARL
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
    /auth   (De)Authorize the specified function on the device
    /root   Device as super administration device
    /admin   Device as administration device
    /message   Authorize rights for Mesh messaging
    /web   Authorize rights for Mesh messaging and Web.
    /device   Device restrictive access
    /ssh   Authorize rights for specified SSH account
    /email   Authorize rights for specified smtp email account
    /member   Authorize member rights for specified Mesh group
    /group   Authorize group administrator rights for specified Mesh group
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /local   Local name for account (e.g. personal)
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
<over>
</div>
~~~~

Accept a pending connection request.


~~~~
<div="terminal">
<cmd>Alice> device accept AMLN-OTR2-SYCF-KZGL-IOIZ-SPQL-TJX6
<rsp>ERROR - Cannot access a closed file.
</div>
~~~~

Specifying the /json option returns a result of type Result:

~~~~
<div="terminal">
<cmd>Alice> device accept AMLN-OTR2-SYCF-KZGL-IOIZ-SPQL-TJX6 /json
<rsp>{
  "Result": {
    "Success": false,
    "Reason": "Cannot access a closed file."}}
</div>
~~~~


# device auth

~~~~
<div="helptext">
<over>
auth   Authorize device to use application
       Device identifier
    /auth   (De)Authorize the specified function on the device
    /root   Device as super administration device
    /admin   Device as administration device
    /message   Authorize rights for Mesh messaging
    /web   Authorize rights for Mesh messaging and Web.
    /device   Device restrictive access
    /ssh   Authorize rights for specified SSH account
    /email   Authorize rights for specified smtp email account
    /member   Authorize member rights for specified Mesh group
    /group   Authorize group administrator rights for specified Mesh group
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /local   Local name for account (e.g. personal)
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
<rsp>ERROR - The option System.Object[] is not known.
</div>
~~~~

Specifying the /json option returns a result of type Result:

~~~~
<div="terminal">
<cmd>Alice> device auth Alice2 /contact /json
<rsp>{
  "Result": {
    "Success": false,
    "Reason": "The option System.Object[] is not known."}}
</div>
~~~~


# device accept

~~~~
<div="helptext">
<over>
accept   Accept a pending connection
       Fingerprint of connection to accept
       Device identifier
    /auth   (De)Authorize the specified function on the device
    /root   Device as super administration device
    /admin   Device as administration device
    /message   Authorize rights for Mesh messaging
    /web   Authorize rights for Mesh messaging and Web.
    /device   Device restrictive access
    /ssh   Authorize rights for specified SSH account
    /email   Authorize rights for specified smtp email account
    /member   Authorize member rights for specified Mesh group
    /group   Authorize group administrator rights for specified Mesh group
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /local   Local name for account (e.g. personal)
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
<cmd>Alice> device accept AMLN-OTR2-SYCF-KZGL-IOIZ-SPQL-TJX6
<rsp>ERROR - Cannot access a closed file.
</div>
~~~~

Specifying the /json option returns a result of type Result:

~~~~
<div="terminal">
<cmd>Alice> device accept AMLN-OTR2-SYCF-KZGL-IOIZ-SPQL-TJX6 /json
<rsp>{
  "Result": {
    "Success": false,
    "Reason": "Cannot access a closed file."}}
</div>
~~~~


# device delete

~~~~
<div="helptext">
<over>
delete   Remove device from device catalog
       Device identifier
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /local   Local name for account (e.g. personal)
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
<cmd>Alice> device delete AMLN-OTR2-SYCF-KZGL-IOIZ-SPQL-TJX6
<rsp>ERROR - The feature has not been implemented
</div>
~~~~

Specifying the /json option returns a result of type Result:

~~~~
<div="terminal">
<cmd>Alice> device delete AMLN-OTR2-SYCF-KZGL-IOIZ-SPQL-TJX6 /json
<rsp>{
  "Result": {
    "Success": false,
    "Reason": "The feature has not been implemented"}}
</div>
~~~~


# device join

~~~~
<div="helptext">
<over>
join   Connect by means of a connection URI from an administration device.
       The device location URI
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /local   Local name for account (e.g. personal)
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
<over>
</div>
~~~~

The `device join` command attempts to connect a device to a personal profile
by means of a URI supplied by an administration device.

# device list

~~~~
<div="helptext">
<over>
list   List devices in the device catalog
       Recryption group name in user@example.com format
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /local   Local name for account (e.g. personal)
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
    /local   Local name for account (e.g. personal)
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
<rsp>MessageID: DVHM-4XCL-BA55-ZW2F-GYO2-JWYN-OGH5
        Connection Request::
        MessageID: DVHM-4XCL-BA55-ZW2F-GYO2-JWYN-OGH5
        To:  From: 
        Device:  MAWT-SA4U-LLRU-GJ26-BYRC-ZUBL-YYI3
        Witness: DVHM-4XCL-BA55-ZW2F-GYO2-JWYN-OGH5
MessageID: AMLN-OTR2-SYCF-KZGL-IOIZ-SPQL-TJX6
        Connection Request::
        MessageID: AMLN-OTR2-SYCF-KZGL-IOIZ-SPQL-TJX6
        To:  From: 
        Device:  MDYN-U7RH-NCK4-NLPY-VMMT-OIRY-BHH4
        Witness: AMLN-OTR2-SYCF-KZGL-IOIZ-SPQL-TJX6
</div>
~~~~

Specifying the /json option returns a result of type ResultPending:

~~~~
<div="terminal">
<cmd>Alice> device pending /json
<rsp>{
  "ResultPending": {
    "Success": true,
    "Messages": [{
        "MessageId": "DVHM-4XCL-BA55-ZW2F-GYO2-JWYN-OGH5",
        "EnvelopedRequestConnection": [{
            "EnvelopeID": "MCQ4-37Z5-CRP2-LMJD-JQP5-NCEZ-FO5N-4DDV-GX2Y-ROA3-PSGK-G35A-3G5W-VXPC",
            "ContentMetaData": "ewogICJVbmlxdWVJRCI6ICJOQkhXLVc2NkgtU1dMQS0
  2U0ZOLU9JTEUtU1hUTC0yU1Q1IiwKICAiTWVzc2FnZVR5cGUiOiAiUmVxdWVzd
  ENvbm5lY3Rpb24iLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCI
  sCiAgIkNyZWF0ZWQiOiAiMjAyMC0wOS0yMlQxMzoxMjo1OVoifQ"},
          "ewogICJSZXF1ZXN0Q29ubmVjdGlvbiI6IHsKICAgICJ
  NZXNzYWdlSWQiOiAiTkJIVy1XNjZILVNXTEEtNlNGTi1PSUxFLVNYVEwtMlNUN
  SIsCiAgICAiQXV0aGVudGljYXRlZERhdGEiOiBbewogICAgICAgICJFbnZlbG9
  wZUlEIjogIk1BV1QtU0E0VS1MTFJVLUdKMjYtQllSQy1aVUJMLVlZSTMiLAogI
  CAgICAgICJkaWciOiAiUzUxMiIsCiAgICAgICAgIkNvbnRlbnRNZXRhRGF0YSI
  6ICJld29nSUNKVmJtbHhkV1ZKUkNJNklDSk5RVmRVTFZOQk5GVXRURXhTVlMxC
  iAgSFNqSTJMVUpaVWtNdFdsVkNUQzFaV1Vreklpd0tJQ0FpVFdWemMyRm5aVlI
  1Y0dVaU9pQWlVSEp2Wm1sc1oKICBVUmxkbWxqWlNJc0NpQWdJbU4wZVNJNklDS
  mhjSEJzYVdOaGRHbHZiaTl0YlcwdmIySnFaV04wSWl3S0lDQQogIGlRM0psWVh
  SbFpDSTZJQ0l5TURJd0xUQTVMVEl5VkRFek9qRXlPalU1V2lKOSJ9LAogICAgI
  CAiZXdvZ0lDSlFjbTltYVd4bFJHVjJhV05sSWpvZ2V3b2dJQ0FnSWs5bVpteAo
  gIHBibVZUYVdkdVlYUjFjbVVpT2lCN0NpQWdJQ0FnSUNKVlJFWWlPaUFpVFVGW
  FZDMVRRVFJWTFV4TVVsVXRSCiAgMG95TmkxQ1dWSkRMVnBWUWt3dFdWbEpNeUl
  zQ2lBZ0lDQWdJQ0pRZFdKc2FXTlFZWEpoYldWMFpYSnpJam8KICBnZXdvZ0lDQ
  WdJQ0FnSUNKUWRXSnNhV05MWlhsRlEwUklJam9nZXdvZ0lDQWdJQ0FnSUNBZ0l
  tTnlkaUk2SQogIENKRlpEUTBPQ0lzQ2lBZ0lDQWdJQ0FnSUNBaVVIVmliR2xqS
  WpvZ0lqQXpXVlpNYkdoRlluaEpVRWhWYW5JCiAgd05YcENabUpwZGtoVmMyZFl
  ja2syWjFkVFZXVmlkMDR0UWtaWmVGRlZPRFIzYkdJS0lDQXlNRE5WWW1Rd0wKI
  CBUSmtha1EyZW5rd1ZXZEVOVk52YlVFaWZYMTlMQW9nSUNBZ0lrdGxlVVZ1WTN
  KNWNIUnBiMjRpT2lCN0NpQQogIGdJQ0FnSUNKVlJFWWlPaUFpVFVKR1RpMDBUV
  kZCTFVsQ1VsSXRVMWxQTmkxWVUxZE5MVVpRTTFFdE5rRllSCiAgeUlzQ2lBZ0l
  DQWdJQ0pRZFdKc2FXTlFZWEpoYldWMFpYSnpJam9nZXdvZ0lDQWdJQ0FnSUNKU
  WRXSnNhV04KICBMWlhsRlEwUklJam9nZXdvZ0lDQWdJQ0FnSUNBZ0ltTnlkaUk
  2SUNKWU5EUTRJaXdLSUNBZ0lDQWdJQ0FnSQogIENKUWRXSnNhV01pT2lBaVUyN
  XZNMlJ1YlRkclNUVkVhamRQY2sxeFVHOXVXRXQ1TUdVNWFWaGpPRGRYZFVoCiA
  gcloyWXRWV1kyY3pSaVdtNHhiWGxzU0FvZ0lGQnZaaTFOUWtKTVoyNHhWMkpUT
  m1oWlVXWkVhSFJsUVNKOWYKICBYMHNDaUFnSUNBaVMyVjVRWFYwYUdWdWRHbGp
  ZWFJwYjI0aU9pQjdDaUFnSUNBZ0lDSlZSRVlpT2lBaVRVUgogIFRTeTFaVTB4V
  kxWZFdTMGt0TmxJeVdpMVBWMDB6TFVkVFJEWXRTVFkzTXlJc0NpQWdJQ0FnSUN
  KUWRXSnNhCiAgV05RWVhKaGJXVjBaWEp6SWpvZ2V3b2dJQ0FnSUNBZ0lDSlFkV
  0pzYVdOTFpYbEZRMFJJSWpvZ2V3b2dJQ0EKICBnSUNBZ0lDQWdJbU55ZGlJNkl
  DSllORFE0SWl3S0lDQWdJQ0FnSUNBZ0lDSlFkV0pzYVdNaU9pQWljMlZ3UgogI
  DNrNWVUTmtZVFUxZDJSZk9IQnpiM1o1VWs5b2NrZGpWR3hJWkRkNlpUaFlSemd
  6UW5FM1JreG9ZWEpOZEdaCiAgNU1Rb2dJR28yYjJsMmNqbGtTVmhVTVZSS2JqZ
  HNURFZaUmtZeVFTSjlmWDE5ZlEiLAogICAgICB7CiAgICAgICAgInNpZ25hdHV
  yZXMiOiBbewogICAgICAgICAgICAiYWxnIjogIlM1MTIiLAogICAgICAgICAgI
  CAia2lkIjogIk1BV1QtU0E0VS1MTFJVLUdKMjYtQllSQy1aVUJMLVlZSTMiLAo
  gICAgICAgICAgICAic2lnbmF0dXJlIjogImM1cE1lQXFRUVJjRzdBWTRNNFJwa
  0o3T0l2XzE3SmdEZ1dHOF9DakNaQ2oxS0ZpMDIKICAwX0FaXzdnWWJ2UEo1Mnh
  Mank2Y1pRSVcxd0Foa0E2MEF6WEVEdFNQdktIUmFCTFNIaHJ1QlZ2S0lVeVhrU
  AogIEVvaFFQLV9wbWVoYmpPU3YzX1B6b052T0xVR2xMNERWc2FROTdYQlFBIn1
  dLAogICAgICAgICJQYXlsb2FkRGlnZXN0IjogIkZmU1lxclpfZGVnaDVrOVlJR
  EFVRWF4OVN4OHFLMXp0UmQwM1A1SnRIclA2SQogIDVSV29jM3pnejRSVVNfaEt
  WdzU0cFhQQ3NUSTdxMmczNXNzQTZLMGxnIn1dLAogICAgIkNsaWVudE5vbmNlI
  jogIjU4TWdQVGllbXRRMGZIWmxzSjNjTEEiLAogICAgIkFjY291bnRBZGRyZXN
  zIjogImFsaWNlQGV4YW1wbGUuY29tIn19"],
        "ServerNonce": "EBpND37csD1ak5QjCKzBrw",
        "Witness": "DVHM-4XCL-BA55-ZW2F-GYO2-JWYN-OGH5"},
      {
        "MessageId": "AMLN-OTR2-SYCF-KZGL-IOIZ-SPQL-TJX6",
        "EnvelopedRequestConnection": [{
            "EnvelopeID": "MAKR-4N3A-7TCE-4M4B-PF2P-DRJU-MRIG-45QP-SDZF-NZTS-A3BV-DHCX-N6WV-ZCRM",
            "ContentMetaData": "ewogICJVbmlxdWVJRCI6ICJOREpJLTNLSE0tVUJTSS1
  FRlhKLU9LV1ctWTJEMi1QRU1QIiwKICAiTWVzc2FnZVR5cGUiOiAiUmVxdWVzd
  ENvbm5lY3Rpb24iLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCI
  sCiAgIkNyZWF0ZWQiOiAiMjAyMC0wOS0yMlQxMzoxMjo1OVoifQ"},
          "ewogICJSZXF1ZXN0Q29ubmVjdGlvbiI6IHsKICAgICJ
  NZXNzYWdlSWQiOiAiTkRKSS0zS0hNLVVCU0ktRUZYSi1PS1dXLVkyRDItUEVNU
  CIsCiAgICAiQXV0aGVudGljYXRlZERhdGEiOiBbewogICAgICAgICJFbnZlbG9
  wZUlEIjogIk1EWU4tVTdSSC1OQ0s0LU5MUFktVk1NVC1PSVJZLUJISDQiLAogI
  CAgICAgICJkaWciOiAiUzUxMiIsCiAgICAgICAgIkNvbnRlbnRNZXRhRGF0YSI
  6ICJld29nSUNKVmJtbHhkV1ZKUkNJNklDSk5SRmxPTFZVM1VrZ3RUa05MTkMxC
  iAgT1RGQlpMVlpOVFZRdFQwbFNXUzFDU0VnMElpd0tJQ0FpVFdWemMyRm5aVlI
  1Y0dVaU9pQWlVSEp2Wm1sc1oKICBVUmxkbWxqWlNJc0NpQWdJbU4wZVNJNklDS
  mhjSEJzYVdOaGRHbHZiaTl0YlcwdmIySnFaV04wSWl3S0lDQQogIGlRM0psWVh
  SbFpDSTZJQ0l5TURJd0xUQTVMVEl5VkRFek9qRXlPalU1V2lKOSJ9LAogICAgI
  CAiZXdvZ0lDSlFjbTltYVd4bFJHVjJhV05sSWpvZ2V3b2dJQ0FnSWs5bVpteAo
  gIHBibVZUYVdkdVlYUjFjbVVpT2lCN0NpQWdJQ0FnSUNKVlJFWWlPaUFpVFVSW
  lRpMVZOMUpJTFU1RFN6UXRUCiAga3hRV1MxV1RVMVVMVTlKVWxrdFFraElOQ0l
  zQ2lBZ0lDQWdJQ0pRZFdKc2FXTlFZWEpoYldWMFpYSnpJam8KICBnZXdvZ0lDQ
  WdJQ0FnSUNKUWRXSnNhV05MWlhsRlEwUklJam9nZXdvZ0lDQWdJQ0FnSUNBZ0l
  tTnlkaUk2SQogIENKRlpEUTBPQ0lzQ2lBZ0lDQWdJQ0FnSUNBaVVIVmliR2xqS
  WpvZ0lua3RaR3BKWkdzMllTMW1ka1ZQYlZwCiAgMU9YRnZRVFpUUkUxeFVIZFZ
  WbEZIYUZKdFVXTkZXbGswWmxaVGQwZHVlVXhqV0VZS0lDQlphRWxXYjI5MmMKI
  CAwaGpVVWhUYjFOaFEyTk1kRzlrVFVFaWZYMTlMQW9nSUNBZ0lrdGxlVVZ1WTN
  KNWNIUnBiMjRpT2lCN0NpQQogIGdJQ0FnSUNKVlJFWWlPaUFpVFVKTlV5MUxUR
  kZaTFZoWFdWa3RTelZEVVMxWFEwWlhMVkZUVUVNdFFsZzBNCiAgaUlzQ2lBZ0l
  DQWdJQ0pRZFdKc2FXTlFZWEpoYldWMFpYSnpJam9nZXdvZ0lDQWdJQ0FnSUNKU
  WRXSnNhV04KICBMWlhsRlEwUklJam9nZXdvZ0lDQWdJQ0FnSUNBZ0ltTnlkaUk
  2SUNKWU5EUTRJaXdLSUNBZ0lDQWdJQ0FnSQogIENKUWRXSnNhV01pT2lBaWFGT
  k5NMngzUVdGMFFVMXNURWhZY1Vrd2JtVTJaa2hGU21GblVUVkRkbkpyVlhsCiA
  gcmR6VTNOVVJFWlhaTlNGWmhkbmx1ZFFvZ0lGWTViVXQ2TkdKNVdTMHpjWEZ2W
  nprMFIxSnlVREY1UVNKOWYKICBYMHNDaUFnSUNBaVMyVjVRWFYwYUdWdWRHbGp
  ZWFJwYjI0aU9pQjdDaUFnSUNBZ0lDSlZSRVlpT2lBaVRVUgogIFVRaTFXUVZaT
  UxVWTJRMVl0TTBsWU1pMVFURTAxTFZSWlVqWXRXbGRZVnlJc0NpQWdJQ0FnSUN
  KUWRXSnNhCiAgV05RWVhKaGJXVjBaWEp6SWpvZ2V3b2dJQ0FnSUNBZ0lDSlFkV
  0pzYVdOTFpYbEZRMFJJSWpvZ2V3b2dJQ0EKICBnSUNBZ0lDQWdJbU55ZGlJNkl
  DSllORFE0SWl3S0lDQWdJQ0FnSUNBZ0lDSlFkV0pzYVdNaU9pQWlVRTFaVwogI
  GtSWWVWRlpaVEZpTjBkMVoybEJWVGxsWkRabGN6WlBTMUpRTVVoM2JWRjJUbE5
  IY25RNVh6Uk5WMVZzWTI1CiAgRE1nb2dJRFIxVW1WWGN6Um9SSFkxTUZwWGFWR
  lVZMDFuWDJWRlFTSjlmWDE5ZlEiLAogICAgICB7CiAgICAgICAgInNpZ25hdHV
  yZXMiOiBbewogICAgICAgICAgICAiYWxnIjogIlM1MTIiLAogICAgICAgICAgI
  CAia2lkIjogIk1EWU4tVTdSSC1OQ0s0LU5MUFktVk1NVC1PSVJZLUJISDQiLAo
  gICAgICAgICAgICAic2lnbmF0dXJlIjogImowRVNiODVOOUdTU2dvdlZEQnM2O
  Dk4WnhNc25CSzJoWWt5VEVlWnpaUmFTSW9NTl8KICBtWTduelBNV2pTNUg2S3J
  aV1FfUGcxZFBrMEFLUXpsWGdTRGhzMVdhLWppSlRpMVdyOGotLVRTbGNpQS1yd
  AogIEE5VjgyZ2FQS3NGbnd4Ykd4MlMxZHVEVDJlNWNZSWUyTzFwRFZFVGdBIn1
  dLAogICAgICAgICJQYXlsb2FkRGlnZXN0IjogIjBjWkg2Mm4zUTdWWDhqamdtb
  kNfMm51NUI5Q0FWWFJ5bC1NdFI1TVkzcnNLNwogIFktWklLcXFYNzFkaVpzQTQ
  4ZElOb01qclhnNUVsM25jM3M1WDd5YlNRIn1dLAogICAgIkNsaWVudE5vbmNlI
  jogIjVPclRQQXR3OGFRekFXamZGRHQ5b2ciLAogICAgIkFjY291bnRBZGRyZXN
  zIjogImFsaWNlQGV4YW1wbGUuY29tIn19"],
        "ServerNonce": "CS5fCSynX8-Yj3vWHPqhwA",
        "Witness": "AMLN-OTR2-SYCF-KZGL-IOIZ-SPQL-TJX6"}]}}
</div>
~~~~


# device reject

~~~~
<div="helptext">
<over>
reject   Reject a pending connection
       Fingerprint of connection to reject
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /local   Local name for account (e.g. personal)
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
<cmd>Alice> device reject DVHM-4XCL-BA55-ZW2F-GYO2-JWYN-OGH5
<rsp></div>
~~~~

Specifying the /json option returns a result of type ResultProcess:

~~~~
<div="terminal">
<cmd>Alice> device reject DVHM-4XCL-BA55-ZW2F-GYO2-JWYN-OGH5 /json
<rsp>{
  "ResultProcess": {
    "Success": true,
    "ProcessResult": {
      "Success": true}}}
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
    /auth   (De)Authorize the specified function on the device
    /root   Device as super administration device
    /admin   Device as administration device
    /message   Authorize rights for Mesh messaging
    /web   Authorize rights for Mesh messaging and Web.
    /device   Device restrictive access
    /ssh   Authorize rights for specified SSH account
    /email   Authorize rights for specified smtp email account
    /member   Authorize member rights for specified Mesh group
    /group   Authorize group administrator rights for specified Mesh group
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
<rsp>   Device UDF = MDYN-U7RH-NCK4-NLPY-VMMT-OIRY-BHH4
   Witness value = AMLN-OTR2-SYCF-KZGL-IOIZ-SPQL-TJX6
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
      "Id": "MDYN-U7RH-NCK4-NLPY-VMMT-OIRY-BHH4",
      "EnvelopedProfileUser": [{
          "EnvelopeID": "MAQJ-32QZ-HFDM-M2MZ-PR57-3FSO-4CH4",
          "dig": "S512",
          "ContentMetaData": "ewogICJVbmlxdWVJRCI6ICJNQVFKLTMyUVotSEZETS1
  NMk1aLVBSNTctM0ZTTy00Q0g0IiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZmlsZ
  VVzZXIiLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIsCiAgIkN
  yZWF0ZWQiOiAiMjAyMC0wOS0yMlQxMzoxMjo1N1oifQ"},
        "ewogICJQcm9maWxlVXNlciI6IHsKICAgICJPZmZsaW5
  lU2lnbmF0dXJlIjogewogICAgICAiVURGIjogIk1BUUotMzJRWi1IRkRNLU0yT
  VotUFI1Ny0zRlNPLTRDSDQiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHs
  KICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiR
  WQ0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICItaUM4aHJxbXloREdpbS0wb29
  wZnQ0NUtrY2JlbjZMVjlhZDVXOUMwaW43c0gyQjVtOFo2CiAgQUsxV0wwYVJtS
  nZrX1Q3Um9KZkNocy1BIn19fSwKICAgICJBY2NvdW50QWRkcmVzc2VzIjogWyJ
  hbGljZUBleGFtcGxlLmNvbSJdLAogICAgIkFjY291bnRFbmNyeXB0aW9uIjoge
  wogICAgICAiVURGIjogIk1BVFEtU1dDSS02NkFXLTNXSDctVDVJTS1IUUhSLTJ
  KR0MiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVib
  GljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiWDQ0OCIsCiAgICAgICA
  gICAiUHVibGljIjogIjJubXQ5OWZXUWdQWXdENGpSQ2JxX2xzaUxPY1h0RnVtZ
  zBCTjI2OTRCa3c5M1lRUElnT0gKICBoNjdfVGdCWG1oU2s1WVVCNndtdS1qZUE
  ifX19LAogICAgIkVudmVsb3BlZFByb2ZpbGVTZXJ2aWNlIjogW3sKICAgICAgI
  CAiRW52ZWxvcGVJRCI6ICJNREdaLUVTR00tTUNTRS0zQlhZLUI0TUUtQk9PWC1
  GRllBIiwKICAgICAgICAiZGlnIjogIlM1MTIiLAogICAgICAgICJDb250ZW50T
  WV0YURhdGEiOiAiZXdvZ0lDSlZibWx4ZFdWSlJDSTZJQ0pOUkVkYUxVVlRSMDB
  0VFVOVFJTMAogIHpRbGhaTFVJMFRVVXRRazlQV0MxR1JsbEJJaXdLSUNBaVRXV
  npjMkZuWlZSNWNHVWlPaUFpVUhKdlptbHNaCiAgVk5sY25acFkyVWlMQW9nSUN
  KamRIa2lPaUFpWVhCd2JHbGpZWFJwYjI0dmJXMXRMMjlpYW1WamRDSXNDaUEKI
  CBnSWtOeVpXRjBaV1FpT2lBaU1qQXlNQzB3T1MweU1sUXhNem94TWpvMU4xb2l
  mUSJ9LAogICAgICAiZXdvZ0lDSlFjbTltYVd4bFUyVnlkbWxqWlNJNklIc0tJQ
  0FnSUNKUFptWgogIHNhVzVsVTJsbmJtRjBkWEpsSWpvZ2V3b2dJQ0FnSUNBaVZ
  VUkdJam9nSWsxRVIxb3RSVk5IVFMxTlExTkZMCiAgVE5DV0ZrdFFqUk5SUzFDV
  DA5WUxVWkdXVUVpTEFvZ0lDQWdJQ0FpVUhWaWJHbGpVR0Z5WVcxbGRHVnljeUk
  KICA2SUhzS0lDQWdJQ0FnSUNBaVVIVmliR2xqUzJWNVJVTkVTQ0k2SUhzS0lDQ
  WdJQ0FnSUNBZ0lDSmpjbllpTwogIGlBaVJXUTBORGdpTEFvZ0lDQWdJQ0FnSUN
  BZ0lsQjFZbXhwWXlJNklDSk5RMGt4V0hObVowTk1aaTB0ZUVwCiAgdWJEbFFab
  nBOVm1sUE56bFJZbUZTTVcxS1luUktObDh4UTBjMGFGVkdSRjlPUVVJMENpQWd
  jV052VFZsRlUKICBWRXlZMHBDTjNjNVRrSjBZbTF0TTBkQkluMTlmU3dLSUNBZ
  0lDSkxaWGxGYm1OeWVYQjBhVzl1SWpvZ2V3bwogIGdJQ0FnSUNBaVZVUkdJam9
  nSWsxQ1NGSXRNMHMxUlMxVk0wRllMVWxVVUV3dFZFTk5VQzFXVlZCQ0xWUkRXC
  iAgRmtpTEFvZ0lDQWdJQ0FpVUhWaWJHbGpVR0Z5WVcxbGRHVnljeUk2SUhzS0l
  DQWdJQ0FnSUNBaVVIVmliR2wKICBqUzJWNVJVTkVTQ0k2SUhzS0lDQWdJQ0FnS
  UNBZ0lDSmpjbllpT2lBaVdEUTBPQ0lzQ2lBZ0lDQWdJQ0FnSQogIENBaVVIVml
  iR2xqSWpvZ0lqVlZXa2R6Y21aMVRIbFRRVVZTWDFWRWIwSlVUM04xYVVRNFZtS
  lVUVXRNYms5CiAgTVptazBVWFZNY2prMFdsaDFkR3hXZVhVS0lDQllYM1F4ZGp
  NMVZqazFUREppVjJOSlpqTnRPVzVPWVVFaWYKICBYMTlmWDAiLAogICAgICB7C
  iAgICAgICAgInNpZ25hdHVyZXMiOiBbewogICAgICAgICAgICAiYWxnIjogIlM
  1MTIiLAogICAgICAgICAgICAia2lkIjogIk1ER1otRVNHTS1NQ1NFLTNCWFktQ
  jRNRS1CT09YLUZGWUEiLAogICAgICAgICAgICAic2lnbmF0dXJlIjogIjBzQk5
  zU3B2VDM5ZVYzX1dFbGNzX3dUUlZReWo4TVRCRTJCNVNscUNIa0JNcTc0TTcKI
  CBIajg5T1RCX09PMVhfYUZzbEJ6ZUN5R3JBNEFiNkRpcFp1SjFIOWdnME1kTHB
  3alBLYUhrUTlfRW1wakJuNwogIF9UaXVpTGJVcExZRHZlVGlVR1Fkc0VrR3dWW
  WxyNXZiNF9SOEdBU01BIn1dLAogICAgICAgICJQYXlsb2FkRGlnZXN0IjogIl9
  INHF5NWx0MWo4NTFTRWZrV01lb3VIRi1PamlNMDhFOXlIbE5idDdyOHhtVgogI
  DVhVXpQVG1ZRXV3S2xmdEQ5TFlGNF9SbGY5UkdqbGVYNGppazFhNjh3In1dLAo
  gICAgIktleUF1dGhlbnRpY2F0aW9uIjogewogICAgICAiVURGIjogIk1BVEEtQ
  kNTVi1QTllILTZXT0YtRVJPQi1PNzVCLU8zTkoiLAogICAgICAiUHVibGljUGF
  yYW1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgI
  CAgICJjcnYiOiAiWDQ0OCIsCiAgICAgICAgICAiUHVibGljIjogIllOUHdjOTF
  wekxRZnBzMTdLYmh0cnMwLXVDZVhLb2FNZ3o4cGc1Tl82UVNXZlRRMFJESUIKI
  CAtTEF2d0dzM19FbXlqR1g1SWFtS1Z3MEEifX19fX0",
        {
          "signatures": [{
              "alg": "S512",
              "kid": "MAQJ-32QZ-HFDM-M2MZ-PR57-3FSO-4CH4",
              "signature": "mMeH05n2TY8r-XiFEUl9ThuglEeY6jGMUHzKmB3_y7PUoa5wy
  b4-_v2tTFbMFumVEtBBI36RJAaASy2EeqmjBxyKLHWTsMWpmpXOw0GuqgBfpJs
  ZTBcGrF1vJoOOLwaa8KfPnqK6Y2dkIFF0yv5PHxEA"}],
          "PayloadDigest": "QXNvSqjI1u2vCWL4DOefnI0N4H2IuTVkKy2Hud-OETq4g
  SgQF3bIRpoeakjQT1oDZkNdxqQ8VhDm-huhuwoSaQ"}],
      "DeviceUDF": "MDYN-U7RH-NCK4-NLPY-VMMT-OIRY-BHH4",
      "EnvelopedProfileDevice": [{
          "EnvelopeID": "MDYN-U7RH-NCK4-NLPY-VMMT-OIRY-BHH4",
          "dig": "S512",
          "ContentMetaData": "ewogICJVbmlxdWVJRCI6ICJNRFlOLVU3UkgtTkNLNC1
  OTFBZLVZNTVQtT0lSWS1CSEg0IiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZmlsZ
  URldmljZSIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0IiwKICA
  iQ3JlYXRlZCI6ICIyMDIwLTA5LTIyVDEzOjEyOjU5WiJ9"},
        "ewogICJQcm9maWxlRGV2aWNlIjogewogICAgIk9mZmx
  pbmVTaWduYXR1cmUiOiB7CiAgICAgICJVREYiOiAiTURZTi1VN1JILU5DSzQtT
  kxQWS1WTU1ULU9JUlktQkhINCIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjo
  gewogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6I
  CJFZDQ0OCIsCiAgICAgICAgICAiUHVibGljIjogInktZGpJZGs2YS1mdkVPbVp
  1OXFvQTZTRE1xUHdVVlFHaFJtUWNFWlk0ZlZTd0dueUxjWEYKICBZaElWb292c
  0hjUUhTb1NhQ2NMdG9kTUEifX19LAogICAgIktleUVuY3J5cHRpb24iOiB7CiA
  gICAgICJVREYiOiAiTUJNUy1LTFFZLVhXWVktSzVDUS1XQ0ZXLVFTUEMtQlg0M
  iIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJsaWN
  LZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJYNDQ4IiwKICAgICAgICAgI
  CJQdWJsaWMiOiAiaFNNM2x3QWF0QU1sTEhYcUkwbmU2ZkhFSmFnUTVDdnJrVXl
  rdzU3NUREZXZNSFZhdnludQogIFY5bUt6NGJ5WS0zcXFvZzk0R1JyUDF5QSJ9f
  X0sCiAgICAiS2V5QXV0aGVudGljYXRpb24iOiB7CiAgICAgICJVREYiOiAiTUR
  UQi1WQVZMLUY2Q1YtM0lYMi1QTE01LVRZUjYtWldYVyIsCiAgICAgICJQdWJsa
  WNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICA
  gICAgICAgImNydiI6ICJYNDQ4IiwKICAgICAgICAgICJQdWJsaWMiOiAiUE1ZW
  kRYeVFZZTFiN0d1Z2lBVTllZDZlczZPS1JQMUh3bVF2TlNHcnQ5XzRNV1VsY25
  DMgogIDR1UmVXczRoRHY1MFpXaVFUY01nX2VFQSJ9fX19fQ",
        {
          "signatures": [{
              "alg": "S512",
              "kid": "MDYN-U7RH-NCK4-NLPY-VMMT-OIRY-BHH4",
              "signature": "j0ESb85N9GSSgovVDBs6898ZxMsnBK2hYkyTEeZzZRaSIoMN_
  mY7nzPMWjS5H6KrZWQ_Pg1dPk0AKQzlXgSDhs1Wa-jiJTi1Wr8j--TSlciA-rt
  A9V82gaPKsFnwxbGx2S1duDT2e5cYIe2O1pDVETgA"}],
          "PayloadDigest": "0cZH62n3Q7VX8jjgmnC_2nu5B9CAVXRyl-MtR5MY3rsK7
  Y-ZIKqqX71diZsA48dINoMjrXg5El3nc3s5X7ybSQ"}],
      "EnvelopedAcknowledgeConnection": [{
          "EnvelopeID": "MDY3-VLYY-APS7-RNM4-AJH6-RSW2-JVKB-6RIL-2CQR-ERMG-EREI-GA5P-RVSA-TSYU",
          "ContentMetaData": "ewogICJVbmlxdWVJRCI6ICJBTUxOLU9UUjItU1lDRi1
  LWkdMLUlPSVotU1BRTC1USlg2IiwKICAiTWVzc2FnZVR5cGUiOiAiQWNrbm93b
  GVkZ2VDb25uZWN0aW9uIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmp
  lY3QiLAogICJDcmVhdGVkIjogIjIwMjAtMDktMjJUMTM6MTI6NTlaIn0",
          "ContainerInfo": {
            "Index": 1,
            "TreePosition": 0},
          "Received": "2020-09-22T13:12:59Z"},
        "ewogICJBY2tub3dsZWRnZUNvbm5lY3Rpb24iOiB7CiAgICAiTW
  Vzc2FnZUlkIjogIkFNTE4tT1RSMi1TWUNGLUtaR0wtSU9JWi1TUFFMLVRKWDYi
  LAogICAgIkVudmVsb3BlZFJlcXVlc3RDb25uZWN0aW9uIjogW3sKICAgICAgIC
  AiRW52ZWxvcGVJRCI6ICJNQUtSLTROM0EtN1RDRS00TTRCLVBGMlAtRFJKVS1N
  UklHLTQ1UVAtU0RaRi1OWlRTLUEzQlYtREhDWC1ONldWLVpDUk0iLAogICAgIC
  AgICJDb250ZW50TWV0YURhdGEiOiAiZXdvZ0lDSlZibWx4ZFdWSlJDSTZJQ0pP
  UkVwSkxUTkxTRTB0VlVKVFNTMQogIEZSbGhLTFU5TFYxY3RXVEpFTWkxUVJVMV
  FJaXdLSUNBaVRXVnpjMkZuWlZSNWNHVWlPaUFpVW1WeGRXVnpkCiAgRU52Ym01
  bFkzUnBiMjRpTEFvZ0lDSmpkSGtpT2lBaVlYQndiR2xqWVhScGIyNHZiVzF0TD
  I5aWFtVmpkQ0kKICBzQ2lBZ0lrTnlaV0YwWldRaU9pQWlNakF5TUMwd09TMHlN
  bFF4TXpveE1qbzFPVm9pZlEifSwKICAgICAgImV3b2dJQ0pTWlhGMVpYTjBRMj
  l1Ym1WamRHbHZiaUk2SUhzS0lDQWdJQ0oKICBOWlhOellXZGxTV1FpT2lBaVRr
  UktTUzB6UzBoTkxWVkNVMGt0UlVaWVNpMVBTMWRYTFZreVJESXRVRVZOVQogIE
  NJc0NpQWdJQ0FpUVhWMGFHVnVkR2xqWVhSbFpFUmhkR0VpT2lCYmV3b2dJQ0Fn
  SUNBZ0lDSkZiblpsYkc5CiAgd1pVbEVJam9nSWsxRVdVNHRWVGRTU0MxT1Ewcz
  BMVTVNVUZrdFZrMU5WQzFQU1ZKWkxVSklTRFFpTEFvZ0kKICBDQWdJQ0FnSUNK
  a2FXY2lPaUFpVXpVeE1pSXNDaUFnSUNBZ0lDQWdJa052Ym5SbGJuUk5aWFJoUk
  dGMFlTSQogIDZJQ0psZDI5blNVTktWbUp0Ykhoa1YxWktVa05KTmtsRFNrNVNS
  bXhQVEZaVk0xVnJaM1JVYTA1TVRrTXhDCiAgaUFnVDFSR1FscE1WbHBPVkZaUm
  RGUXdiRk5YVXpGRFUwVm5NRWxwZDB0SlEwRnBWRmRXZW1NeVJtNWFWbEkKICAx
  WTBkVmFVOXBRV2xWU0VwMldtMXNjMW9LSUNCVlVteGtiV3hxV2xOSmMwTnBRV2
  RKYlU0d1pWTkpOa2xEUwogIG1oalNFSnpZVmRPYUdSSGJIWmlhVGwwWWxjd2Rt
  SXlTbkZhVjA0d1NXbDNTMGxEUVFvZ0lHbFJNMHBzV1ZoCiAgU2JGcERTVFpKUT
  BsNVRVUkpkMHhVUVRWTVZFbDVWa1JGZWs5cVJYbFBhbFUxVjJsS09TSjlMQW9n
  SUNBZ0kKICBDQWlaWGR2WjBsRFNsRmpiVGx0WVZkNGJGSkhWakpoVjA1c1NXcH
  ZaMlYzYjJkSlEwRm5TV3M1YlZwdGVBbwogIGdJSEJpYlZaVVlWZGtkVmxZVWpG
  amJWVnBUMmxDTjBOcFFXZEpRMEZuU1VOS1ZsSkZXV2xQYVVGcFZGVlNXCiAgbF
  JwTVZaT01VcEpURlUxUkZONlVYUlVDaUFnYTNoUlYxTXhWMVJWTVZWTVZUbEtW
  V3hyZEZGcmFFbE9RMGwKICB6UTJsQlowbERRV2RKUTBwUlpGZEtjMkZYVGxGWl
  dFcG9ZbGRXTUZwWVNucEphbThLSUNCblpYZHZaMGxEUQogIFdkSlEwRm5TVU5L
  VVdSWFNuTmhWMDVNV2xoc1JsRXdVa2xKYW05blpYZHZaMGxEUVdkSlEwRm5TVU
  5CWjBsCiAgdFRubGthVWsyU1FvZ0lFTktSbHBFVVRCUFEwbHpRMmxCWjBsRFFX
  ZEpRMEZuU1VOQmFWVklWbWxpUjJ4cVMKICBXcHZaMGx1YTNSYVIzQktXa2R6TW
  xsVE1XMWthMVpRWWxad0NpQWdNVTlZUm5aUlZGcFVVa1V4ZUZWSVpGWgogIFdi
  RVpJWVVaS2RGVlhUa1pYYkdzd1dteGFWR1F3WkhWbFZYaHFWMFZaUzBsRFFscG
  hSV3hYWWpJNU1tTUtJCiAgQ0F3YUdwVlZXaFVZakZPYUZFeVRrMWtSemxyVkZW
  RmFXWllNVGxNUVc5blNVTkJaMGxyZEd4bFZWWjFXVE4KICBLTldOSVVuQmlNal
  JwVDJsQ04wTnBRUW9nSUdkSlEwRm5TVU5LVmxKRldXbFBhVUZwVkZWS1RsVjVN
  VXhVUgogIGtaYVRGWm9XRmRXYTNSVGVsWkVWVk14V0ZFd1dsaE1Wa1pVVlVWTm
  RGRnNaekJOQ2lBZ2FVbHpRMmxCWjBsCiAgRFFXZEpRMHBSWkZkS2MyRlhUbEZa
  V0Vwb1lsZFdNRnBZU25wSmFtOW5aWGR2WjBsRFFXZEpRMEZuU1VOS1UKICBXUl
  hTbk5oVjA0S0lDQk1XbGhzUmxFd1VrbEphbTluWlhkdlowbERRV2RKUTBGblNV
  TkJaMGx0VG5sa2FVawogIDJTVU5LV1U1RVVUUkphWGRMU1VOQlowbERRV2RKUT
  BGblNRb2dJRU5LVVdSWFNuTmhWMDFwVDJsQmFXRkdUCiAgazVOTW5nelVWZEdN
  RkZWTVhOVVJXaFpZMVZyZDJKdFZUSmFhMmhHVTIxR2JsVlVWa1JrYmtweVZsaH
  NDaUEKICBnY21SNlZUTk9WVkpGV2xoYVRsTkdXbWhrYm14MVpGRnZaMGxHV1RW
  aVZYUTJUa2RLTlZkVE1IcGpXRVoyVwogIG5wck1GSXhTbmxWUkVZMVVWTktPV1
  lLSUNCWU1ITkRhVUZuU1VOQmFWTXlWalZSV0ZZd1lVZFdkV1JIYkdwCiAgWldG
  SndZakkwYVU5cFFqZERhVUZuU1VOQlowbERTbFpTUlZscFQybEJhVlJWVWdvZ0
  lGVlJhVEZYVVZaYVQKICBVeFZXVEpSTVZsMFRUQnNXVTFwTVZGVVJUQXhURlpT
  V2xWcVdYUlhiR1JaVm5sSmMwTnBRV2RKUTBGblNVTgogIEtVV1JYU25OaENpQW
  dWMDVSV1ZoS2FHSlhWakJhV0VwNlNXcHZaMlYzYjJkSlEwRm5TVU5CWjBsRFNs
  RmtWCiAgMHB6WVZkT1RGcFliRVpSTUZKSlNXcHZaMlYzYjJkSlEwRUtJQ0JuU1
  VOQlowbERRV2RKYlU1NVpHbEpOa2wKICBEU2xsT1JGRTBTV2wzUzBsRFFXZEpR
  MEZuU1VOQlowbERTbEZrVjBwellWZE5hVTlwUVdsVlJURmFWd29nSQogIEd0U1
  dXVldSbHBhVkVacFRqQmtNVm95YkVKV1ZHeHNXa1JhYkdONldsQlRNVXBSVFZW
  b00ySldSakpVYkU1CiAgSVkyNVJOVmg2VWs1V01WWnpXVEkxQ2lBZ1JFMW5iMm
  RKUkZJeFZXMVdXR042VW05U1NGa3hUVVp3V0dGV1IKICBsVlpNREZ1V0RKV1Js
  RlRTamxtV0RFNVpsRWlMQW9nSUNBZ0lDQjdDaUFnSUNBZ0lDQWdJbk5wWjI1aG
  RIVgogIHlaWE1pT2lCYmV3b2dJQ0FnSUNBZ0lDQWdJQ0FpWVd4bklqb2dJbE0x
  TVRJaUxBb2dJQ0FnSUNBZ0lDQWdJCiAgQ0FpYTJsa0lqb2dJazFFV1U0dFZUZF
  NTQzFPUTBzMExVNU1VRmt0VmsxTlZDMVBTVkpaTFVKSVNEUWlMQW8KICBnSUNB
  Z0lDQWdJQ0FnSUNBaWMybG5ibUYwZFhKbElqb2dJbW93UlZOaU9EVk9PVWRUVT
  JkdmRsWkVRbk0yTwogIERrNFduaE5jMjVDU3pKb1dXdDVWRVZsV25wYVVtRlRT
  VzlOVGw4S0lDQnRXVGR1ZWxCTlYycFROVWcyUzNKCiAgYVYxRmZVR2N4WkZCck
  1FRkxVWHBzV0dkVFJHaHpNVmRoTFdwcFNsUnBNVmR5T0dvdExWUlRiR05wUVMx
  eWQKICBBb2dJRUU1VmpneVoyRlFTM05HYm5kNFlrZDRNbE14WkhWRVZESmxOV0
  5aU1dVeVR6RndSRlpGVkdkQkluMQogIGRMQW9nSUNBZ0lDQWdJQ0pRWVhsc2Iy
  RmtSR2xuWlhOMElqb2dJakJqV2tnMk1tNHpVVGRXV0RocWFtZHRiCiAga05mTW
  01MU5VSTVRMEZXV0ZKNWJDMU5kRkkxVFZremNuTkxOd29nSUZrdFdrbExjWEZZ
  TnpGa2FWcHpRVFEKICA0WkVsT2IwMXFjbGhuTlVWc00yNWpNM00xV0RkNVlsTl
  JJbjFkTEFvZ0lDQWdJa05zYVdWdWRFNXZibU5sSQogIGpvZ0lqVlBjbFJRUVhS
  M09HRlJla0ZYYW1aR1JIUTViMmNpTEFvZ0lDQWdJa0ZqWTI5MWJuUkJaR1J5Wl
  hOCiAgeklqb2dJbUZzYVdObFFHVjRZVzF3YkdVdVkyOXRJbjE5Il0sCiAgICAi
  U2VydmVyTm9uY2UiOiAiQ1M1ZkNTeW5YOC1ZajN2V0hQcWh3QSIsCiAgICAiV2
  l0bmVzcyI6ICJBTUxOLU9UUjItU1lDRi1LWkdMLUlPSVotU1BRTC1USlg2In19",
        {}],
      "AccountAddress": "alice@example.com"}}}
</div>
~~~~



