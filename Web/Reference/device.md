

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
<cmd>Alice> device accept JAIU-EMU6-PRO7-DPWT-JWFX-NJE4-S6Y2
<rsp>ERROR - Cannot access a closed file.
</div>
~~~~

Specifying the /json option returns a result of type Result:

~~~~
<div="terminal">
<cmd>Alice> device accept JAIU-EMU6-PRO7-DPWT-JWFX-NJE4-S6Y2 /json
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

**Missing Example***

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
<cmd>Alice> device accept JAIU-EMU6-PRO7-DPWT-JWFX-NJE4-S6Y2
<rsp>ERROR - Cannot access a closed file.
</div>
~~~~

Specifying the /json option returns a result of type Result:

~~~~
<div="terminal">
<cmd>Alice> device accept JAIU-EMU6-PRO7-DPWT-JWFX-NJE4-S6Y2 /json
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
<cmd>Alice> device delete JAIU-EMU6-PRO7-DPWT-JWFX-NJE4-S6Y2
<rsp>ERROR - The feature has not been implemented
</div>
~~~~

Specifying the /json option returns a result of type Result:

~~~~
<div="terminal">
<cmd>Alice> device delete JAIU-EMU6-PRO7-DPWT-JWFX-NJE4-S6Y2 /json
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
<rsp>MessageID: PF33-UK76-TZDH-UBFZ-4JSM-YRZB-YKPS
        Connection Request::
        MessageID: PF33-UK76-TZDH-UBFZ-4JSM-YRZB-YKPS
        To:  From: 
        Device:  MCIA-7IZ5-KGO3-U3CW-Y6Q2-5NMS-ZPXG
        Witness: PF33-UK76-TZDH-UBFZ-4JSM-YRZB-YKPS
MessageID: JAIU-EMU6-PRO7-DPWT-JWFX-NJE4-S6Y2
        Connection Request::
        MessageID: JAIU-EMU6-PRO7-DPWT-JWFX-NJE4-S6Y2
        To:  From: 
        Device:  MBSW-5TDC-4JNH-DP7U-YRYH-336S-XS7X
        Witness: JAIU-EMU6-PRO7-DPWT-JWFX-NJE4-S6Y2
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
        "MessageId": "PF33-UK76-TZDH-UBFZ-4JSM-YRZB-YKPS",
        "EnvelopedRequestConnection": [{
            "EnvelopeID": "MBZX-P2NX-V5EX-6S4U-YRQ2-RH55-WFGF",
            "ContentMetaData": "ewogICJVbmlxdWVJRCI6ICJOQVJPLURSUUQtRzVINS1
  ETVo3LTNYNkotQTdWSy02RlhDIiwKICAiTWVzc2FnZVR5cGUiOiAiUmVxdWVzd
  ENvbm5lY3Rpb24iLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCI
  sCiAgIkNyZWF0ZWQiOiAiMjAyMC0xMC0yMVQxNDoyODozM1oifQ"},
          "ewogICJSZXF1ZXN0Q29ubmVjdGlvbiI6IHsKICAgICJ
  NZXNzYWdlSWQiOiAiTkFSTy1EUlFELUc1SDUtRE1aNy0zWDZKLUE3VkstNkZYQ
  yIsCiAgICAiQXV0aGVudGljYXRlZERhdGEiOiBbewogICAgICAgICJFbnZlbG9
  wZUlEIjogIk1DSUEtN0laNS1LR08zLVUzQ1ctWTZRMi01Tk1TLVpQWEciLAogI
  CAgICAgICJkaWciOiAiUzUxMiIsCiAgICAgICAgIkNvbnRlbnRNZXRhRGF0YSI
  6ICJld29nSUNKVmJtbHhkV1ZKUkNJNklDSk5RMGxCTFRkSldqVXRTMGRQTXkxC
  iAgVk0wTlhMVmsyVVRJdE5VNU5VeTFhVUZoSElpd0tJQ0FpVFdWemMyRm5aVlI
  1Y0dVaU9pQWlVSEp2Wm1sc1oKICBVUmxkbWxqWlNJc0NpQWdJbU4wZVNJNklDS
  mhjSEJzYVdOaGRHbHZiaTl0YlcwdmIySnFaV04wSWl3S0lDQQogIGlRM0psWVh
  SbFpDSTZJQ0l5TURJd0xURXdMVEl4VkRFME9qSTRPak16V2lKOSJ9LAogICAgI
  CAiZXdvZ0lDSlFjbTltYVd4bFJHVjJhV05sSWpvZ2V3b2dJQ0FnSWxCeWIyWgo
  gIHBiR1ZUYVdkdVlYUjFjbVVpT2lCN0NpQWdJQ0FnSUNKVlpHWWlPaUFpVFVOS
  lFTMDNTVm8xTFV0SFR6TXRWCiAgVE5EVnkxWk5sRXlMVFZPVFZNdFdsQllSeUl
  zQ2lBZ0lDQWdJQ0pRZFdKc2FXTlFZWEpoYldWMFpYSnpJam8KICBnZXdvZ0lDQ
  WdJQ0FnSUNKUWRXSnNhV05MWlhsRlEwUklJam9nZXdvZ0lDQWdJQ0FnSUNBZ0l
  tTnlkaUk2SQogIENKRlpEUTBPQ0lzQ2lBZ0lDQWdJQ0FnSUNBaVVIVmliR2xqS
  WpvZ0lsRlBUVXR2VHprd1ZuQXlOVk5wZEhkCiAgQmFtbEdhSGxSVjE4eE5UQk1
  Oa2c1V2xoTGRsazBVV0Z6TWt4dFZFdEZka1ZtTFZZS0lDQkRSVXRoV25sdmMKI
  CBWWlBkakU1VGw5aWFtczBNbFZzVjBFaWZYMTlMQW9nSUNBZ0lrSmhjMlZGYm1
  OeWVYQjBhVzl1SWpvZ2V3bwogIGdJQ0FnSUNBaVZXUm1Jam9nSWsxRVQxTXRSM
  DgwUVMxUk4xQlRMVEpVU0ZVdFUwUTFNeTFaTlVORkxWcEtSCiAgRklpTEFvZ0l
  DQWdJQ0FpVUhWaWJHbGpVR0Z5WVcxbGRHVnljeUk2SUhzS0lDQWdJQ0FnSUNBa
  VVIVmliR2wKICBqUzJWNVJVTkVTQ0k2SUhzS0lDQWdJQ0FnSUNBZ0lDSmpjbll
  pT2lBaVdEUTBPQ0lzQ2lBZ0lDQWdJQ0FnSQogIENBaVVIVmliR2xqSWpvZ0lrT
  m9WVTFTZGpVemVIbDFOWEIxVWtGV1QwUlVhMnA1TUZseFZtWjFiUzF6VTI1CiA
  gRWNVZDNNa1pDUVZFdGRYWkxZVFptVUdFS0lDQXlabEJsZEVaeGJsUnNNRWQxY
  TNsbFFuTm5iV2t4YVVFaWYKICBYMTlMQW9nSUNBZ0lrSmhjMlZCZFhSb1pXNTB
  hV05oZEdsdmJpSTZJSHNLSUNBZ0lDQWdJbFZrWmlJNklDSgogIE5RbGRYTFZGS
  VZsUXRXRXBEVlMxUFYwZENMVTgyUzB3dFZGUklOQzAxUnpRMklpd0tJQ0FnSUN
  BZ0lsQjFZCiAgbXhwWTFCaGNtRnRaWFJsY25NaU9pQjdDaUFnSUNBZ0lDQWdJb
  EIxWW14cFkwdGxlVVZEUkVnaU9pQjdDaUEKICBnSUNBZ0lDQWdJQ0FpWTNKMkl
  qb2dJbGcwTkRnaUxBb2dJQ0FnSUNBZ0lDQWdJbEIxWW14cFl5STZJQ0pFYwogI
  DBsVFJqaGFWME15YUZsTmNVUjVWREoxTVRFNWVFSXpiekJZTkRkSWRtNVpRVmh
  MTmtkcFZWaGZhbnB5YnpOCiAgRFQxTXpDaUFnTm5Ga1IxZDJVRE4wTm1KT1RWR
  jJOakkyYUVOWVdVRkJJbjE5ZlN3S0lDQWdJQ0pDWVhObFUKICAybG5ibUYwZFh
  KbElqb2dld29nSUNBZ0lDQWlWV1JtSWpvZ0lrMUNSVUl0VEZneVdpMUVWa0ZOT
  FZGVVREUQogIHRORVkxU1MxV1RsWTNMVXBZVnpJaUxBb2dJQ0FnSUNBaVVIVml
  iR2xqVUdGeVlXMWxkR1Z5Y3lJNklIc0tJCiAgQ0FnSUNBZ0lDQWlVSFZpYkdsa
  lMyVjVSVU5FU0NJNklIc0tJQ0FnSUNBZ0lDQWdJQ0pqY25ZaU9pQWlSV1EKICA
  wTkRnaUxBb2dJQ0FnSUNBZ0lDQWdJbEIxWW14cFl5STZJQ0pwVUd0MFZHbFpWR
  EZvWWxadGFIUTBURGwzTQogIEZwVU5IbHBWR2RSWVdsMU9UWXRTV010ZFV4emM
  wRk9XSEZ2VVVReGExTnRDaUFnVVUxRk1Ga3RWWGcwZUc0CiAgd1QwaE9PV3hwY
  3pKaU1uTkJJbjE5ZlgxOSIsCiAgICAgIHsKICAgICAgICAic2lnbmF0dXJlcyI
  6IFt7CiAgICAgICAgICAgICJhbGciOiAiUzUxMiIsCiAgICAgICAgICAgICJra
  WQiOiAiTUNJQS03SVo1LUtHTzMtVTNDVy1ZNlEyLTVOTVMtWlBYRyIsCiAgICA
  gICAgICAgICJzaWduYXR1cmUiOiAiNmFnelRyT0hYektmaTRCUGRXbUpKSU5vW
  Wo0WXlrRFFqVktZaENlOFJHMHluZ0tSYQogIERGQXo3OHpab1dJNEo2Z3RFSm5
  xSmcwRld5QXZWRjU3QmtMNm9PRk1kck1fZHBtX0RQSGc2cC1NY292TGRoCiAgS
  mJnZ0x4ZTJkUkFYNFozSzNPM1hRZTNwZ205dThWY1VoMnI0RG1RWUEifV0sCiA
  gICAgICAgIlBheWxvYWREaWdlc3QiOiAiRGwtWEE0bkc1MWM0eV9qbEctYTF6R
  EJtQmVZcmR3QmxITDAzWkNtd1daTE10CiAgLVdYMFJnMnhBeHQyWEZ4ZDREaHh
  1NUxtQ0xFYTdab0l4ZGk3eXJsd2cifV0sCiAgICAiQ2xpZW50Tm9uY2UiOiAiT
  UU1c3JuYnNPVXBuNW1YZHpaUEpUQSIsCiAgICAiQWNjb3VudEFkZHJlc3MiOiA
  iYWxpY2VAZXhhbXBsZS5jb20ifX0"],
        "ServerNonce": "xgRJanQNWAt-k4kwPCUJJQ",
        "Witness": "PF33-UK76-TZDH-UBFZ-4JSM-YRZB-YKPS"},
      {
        "MessageId": "JAIU-EMU6-PRO7-DPWT-JWFX-NJE4-S6Y2",
        "EnvelopedRequestConnection": [{
            "EnvelopeID": "MDHS-YGA2-CYLJ-EQSD-BPDW-HCLC-BVFI",
            "ContentMetaData": "ewogICJVbmlxdWVJRCI6ICJORFVMLVVSVzUtUjdMWi1
  ZVklQLVRNWDctQUU1Sy1CQ0JWIiwKICAiTWVzc2FnZVR5cGUiOiAiUmVxdWVzd
  ENvbm5lY3Rpb24iLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCI
  sCiAgIkNyZWF0ZWQiOiAiMjAyMC0xMC0yMVQxNDoyODozM1oifQ"},
          "ewogICJSZXF1ZXN0Q29ubmVjdGlvbiI6IHsKICAgICJ
  NZXNzYWdlSWQiOiAiTkRVTC1VUlc1LVI3TFotWVZJUC1UTVg3LUFFNUstQkNCV
  iIsCiAgICAiQXV0aGVudGljYXRlZERhdGEiOiBbewogICAgICAgICJFbnZlbG9
  wZUlEIjogIk1CU1ctNVREQy00Sk5ILURQN1UtWVJZSC0zMzZTLVhTN1giLAogI
  CAgICAgICJkaWciOiAiUzUxMiIsCiAgICAgICAgIkNvbnRlbnRNZXRhRGF0YSI
  6ICJld29nSUNKVmJtbHhkV1ZKUkNJNklDSk5RbE5YTFRWVVJFTXRORXBPU0MxC
  iAgRVVEZFZMVmxTV1VndE16TTJVeTFZVXpkWUlpd0tJQ0FpVFdWemMyRm5aVlI
  1Y0dVaU9pQWlVSEp2Wm1sc1oKICBVUmxkbWxqWlNJc0NpQWdJbU4wZVNJNklDS
  mhjSEJzYVdOaGRHbHZiaTl0YlcwdmIySnFaV04wSWl3S0lDQQogIGlRM0psWVh
  SbFpDSTZJQ0l5TURJd0xURXdMVEl4VkRFME9qSTRPak16V2lKOSJ9LAogICAgI
  CAiZXdvZ0lDSlFjbTltYVd4bFJHVjJhV05sSWpvZ2V3b2dJQ0FnSWxCeWIyWgo
  gIHBiR1ZUYVdkdVlYUjFjbVVpT2lCN0NpQWdJQ0FnSUNKVlpHWWlPaUFpVFVKV
  FZ5MDFWRVJETFRSS1RrZ3RSCiAgRkEzVlMxWlVsbElMVE16TmxNdFdGTTNXQ0l
  zQ2lBZ0lDQWdJQ0pRZFdKc2FXTlFZWEpoYldWMFpYSnpJam8KICBnZXdvZ0lDQ
  WdJQ0FnSUNKUWRXSnNhV05MWlhsRlEwUklJam9nZXdvZ0lDQWdJQ0FnSUNBZ0l
  tTnlkaUk2SQogIENKRlpEUTBPQ0lzQ2lBZ0lDQWdJQ0FnSUNBaVVIVmliR2xqS
  WpvZ0ltdENWVEpmV1VKV1pESjBjazlDT1hsCiAgblVrRTRTVTVuTmtSa1JFMWp
  iMGwxZVU1UlNYQnNabVZ0WTNrNGRsOUtOR1ppUlVJS0lDQjJXVlZRYlZWVGQKI
  CBGbE9MWEZyWmxGMVpGQTJXSGgyYjBFaWZYMTlMQW9nSUNBZ0lrSmhjMlZGYm1
  OeWVYQjBhVzl1SWpvZ2V3bwogIGdJQ0FnSUNBaVZXUm1Jam9nSWsxRFVVb3ROe
  lJOTlMxV05GUkdMVkl6UmtZdFZ6UkpWaTFFTXpNM0xWZEpSCiAgRWdpTEFvZ0l
  DQWdJQ0FpVUhWaWJHbGpVR0Z5WVcxbGRHVnljeUk2SUhzS0lDQWdJQ0FnSUNBa
  VVIVmliR2wKICBqUzJWNVJVTkVTQ0k2SUhzS0lDQWdJQ0FnSUNBZ0lDSmpjbll
  pT2lBaVdEUTBPQ0lzQ2lBZ0lDQWdJQ0FnSQogIENBaVVIVmliR2xqSWpvZ0lrZ
  DRkVmhuVFhoQ2VEWktZbEJVZDBGMk1YSXpZMGhzWVUxTFkyVm1VMjV0VDFkCiA
  gZmMwTXlZbE5SVTFWcU1EUXRUMGhqV1RVS0lDQTJla0ZMWmtGdGNrRlZZVms0T
  UVaS01uSldUbkJ4UzBFaWYKICBYMTlMQW9nSUNBZ0lrSmhjMlZCZFhSb1pXNTB
  hV05oZEdsdmJpSTZJSHNLSUNBZ0lDQWdJbFZrWmlJNklDSgogIE5RMEZRTFRSW
  VEwVXRUa3BHU1MxR1JVVklMVTgyUkVNdE4xSXlOQzFQVmxoWklpd0tJQ0FnSUN
  BZ0lsQjFZCiAgbXhwWTFCaGNtRnRaWFJsY25NaU9pQjdDaUFnSUNBZ0lDQWdJb
  EIxWW14cFkwdGxlVVZEUkVnaU9pQjdDaUEKICBnSUNBZ0lDQWdJQ0FpWTNKMkl
  qb2dJbGcwTkRnaUxBb2dJQ0FnSUNBZ0lDQWdJbEIxWW14cFl5STZJQ0pXTwogI
  FhwMVZuUTVTRGxTUjBZNGVETjBTSGhsTUVGbExUQlljbTlIVW1SQ1NXNVRibVZ
  HY0U1MFdqTmhkV1kxZGtWCiAgR2NuSlFDaUFnZEVOeU5WWkRhbW8xVTFVeVIzU
  jFWRVpqU0U5UlRTMUJJbjE5ZlN3S0lDQWdJQ0pDWVhObFUKICAybG5ibUYwZFh
  KbElqb2dld29nSUNBZ0lDQWlWV1JtSWpvZ0lrMUVTbEV0VFVSRlFTMUxWME5ST
  FZaSVNrTQogIHRUbG8xTkMxR1JVSTBMVTgzTWpRaUxBb2dJQ0FnSUNBaVVIVml
  iR2xqVUdGeVlXMWxkR1Z5Y3lJNklIc0tJCiAgQ0FnSUNBZ0lDQWlVSFZpYkdsa
  lMyVjVSVU5FU0NJNklIc0tJQ0FnSUNBZ0lDQWdJQ0pqY25ZaU9pQWlSV1EKICA
  wTkRnaUxBb2dJQ0FnSUNBZ0lDQWdJbEIxWW14cFl5STZJQ0poVVVSd1kzTkVZM
  EpWZW1WRVlYRkpSVFZGWQogIDBKaFFtRkdSak15TFRGTGVrZzVRbWRWWTFsNVV
  UY3libkZ1UzFCQ1JEQnBDaUFnWkVWd1NITTVSRkZFWkZKCiAgWlFtcEdSMnRhV
  EhaSmVHOUJJbjE5ZlgxOSIsCiAgICAgIHsKICAgICAgICAic2lnbmF0dXJlcyI
  6IFt7CiAgICAgICAgICAgICJhbGciOiAiUzUxMiIsCiAgICAgICAgICAgICJra
  WQiOiAiTUJTVy01VERDLTRKTkgtRFA3VS1ZUllILTMzNlMtWFM3WCIsCiAgICA
  gICAgICAgICJzaWduYXR1cmUiOiAiSElWT19RdU16MlF2RnFaYjYtNUpjRHRHY
  nFFOVRUSW1JT1dhU2h6UE5USHhqV01ETQogIE1ueWhDcDc3R3Vaa3l0Z19haDl
  iVTk4MnBvQTNBUzB3Q0xiMWFfT0o1N09wRFM4UDNDV0t0OG9fOFJTX3ZLCiAgT
  TNQcnRRUW1tZ2Yta3U4VVJaMGo2ZHQ5X3IyTm5mdDlLaThNc2lqOEEifV0sCiA
  gICAgICAgIlBheWxvYWREaWdlc3QiOiAiV2lueFpSVXNuWDZTTXBJaWxKVWk5R
  3Z4ZmN5R0pNY3VpSk95Wm9fSUdsaFdfCiAgTm53aWZIOXYtSm5vNnF4NkVKWXE
  3NWsta2R4dXNXbDhiV3laeG1tQXcifV0sCiAgICAiQ2xpZW50Tm9uY2UiOiAiW
  jN1dl9weXBtamtscDFKN0R2X2ZoZyIsCiAgICAiQWNjb3VudEFkZHJlc3MiOiA
  iYWxpY2VAZXhhbXBsZS5jb20ifX0"],
        "ServerNonce": "qg6GYJIgzY2PBzrqP01TNg",
        "Witness": "JAIU-EMU6-PRO7-DPWT-JWFX-NJE4-S6Y2"}]}}
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
<cmd>Alice> device reject PF33-UK76-TZDH-UBFZ-4JSM-YRZB-YKPS
<rsp></div>
~~~~

Specifying the /json option returns a result of type ResultProcess:

~~~~
<div="terminal">
<cmd>Alice> device reject PF33-UK76-TZDH-UBFZ-4JSM-YRZB-YKPS /json
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
<rsp>   Device UDF = MBSW-5TDC-4JNH-DP7U-YRYH-336S-XS7X
   Witness value = JAIU-EMU6-PRO7-DPWT-JWFX-NJE4-S6Y2
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
      "Id": "MBSW-5TDC-4JNH-DP7U-YRYH-336S-XS7X",
      "EnvelopedProfileAccount": [{
          "EnvelopeID": "MDUR-4AKJ-GEI7-7NXU-HZMM-C2N3-34S5",
          "dig": "S512",
          "ContentMetaData": "ewogICJVbmlxdWVJRCI6ICJNRFVSLTRBS0otR0VJNy0
  3TlhVLUhaTU0tQzJOMy0zNFM1IiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZmlsZ
  VVzZXIiLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIsCiAgIkN
  yZWF0ZWQiOiAiMjAyMC0xMC0yMVQxNDoyODozMFoifQ"},
        "ewogICJQcm9maWxlVXNlciI6IHsKICAgICJQcm9maWx
  lU2lnbmF0dXJlIjogewogICAgICAiVWRmIjogIk1EVVItNEFLSi1HRUk3LTdOW
  FUtSFpNTS1DMk4zLTM0UzUiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHs
  KICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiR
  WQ0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJVUTdDSk1hRzVIR1JwWmlPNlR
  uYWV6dFRPSVNNVkxvN0EzTVFOdVhWVUM2WFBsT28xbkl3CiAgM2pEV01KZ3pzN
  DF5LWhsWEN5MTFiTDJBIn19fSwKICAgICJBY2NvdW50QWRkcmVzcyI6ICJhbGl
  jZUBleGFtcGxlLmNvbSIsCiAgICAiU2VydmljZVVkZiI6ICJNQ1FOLVhTUUItQ
  kZTSC1EVUlPLTc1UVItT082SC1WUURVIiwKICAgICJBY2NvdW50RW5jcnlwdGl
  vbiI6IHsKICAgICAgIlVkZiI6ICJNQURRLTNOVzYtU0hYRi1MNlg2LU5JMk8tQ
  0Y3QS1YNVk3IiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICA
  gIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogI
  CAgICAgICAgIlB1YmxpYyI6ICIwNzRGTV9KRWZGbEhQdE1TZFl0cld1dko2LTJ
  FNS1MbUNhdWNMMXJpdml0MzE3M25jOTZuCiAgU01OdjF4SU9vZzBTWnAxNWJhO
  GFwT0lBIn19fSwKICAgICJBZG1pbmlzdHJhdG9yU2lnbmF0dXJlIjogewogICA
  gICAiVWRmIjogIk1EVVItNEFLSi1HRUk3LTdOWFUtSFpNTS1DMk4zLTM0UzUiL
  AogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V
  5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAgI
  lB1YmxpYyI6ICJVUTdDSk1hRzVIR1JwWmlPNlRuYWV6dFRPSVNNVkxvN0EzTVF
  OdVhWVUM2WFBsT28xbkl3CiAgM2pEV01KZ3pzNDF5LWhsWEN5MTFiTDJBIn19f
  SwKICAgICJBY2NvdW50QXV0aGVudGljYXRpb24iOiB7CiAgICAgICJVZGYiOiA
  iTUM1Ty1MVVJFLTVKNVUtU0FOWS1MQkhJLVJQUU4tNjY3NSIsCiAgICAgICJQd
  WJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewo
  gICAgICAgICAgImNydiI6ICJYNDQ4IiwKICAgICAgICAgICJQdWJsaWMiOiAiQ
  XYxYVFBSXJ2Yk83M1Zob25pSC1JbVBaZk5BNnhpT09Id1oxWER4RDJDQVBkSnN
  nRFZ1dgogIDdOd0lOVERCX2c2WGxNYU5xMGVTOVJzQSJ9fX0sCiAgICAiQWNjb
  3VudFNpZ25hdHVyZSI6IHsKICAgICAgIlVkZiI6ICJNQkdOLVhRSjYtVUpORS0
  1SFZYLTZSQ0EtQ1BOTC1VRTRFIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiO
  iB7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2Ijo
  gIkVkNDQ4IiwKICAgICAgICAgICJQdWJsaWMiOiAidVIxLS14NEw1aExKTXlLV
  mtDc1MwMWdxMVNkdGJMcmFNYlNzaUNRR1FTTFNhUkx5ZzBIegogIE5nZ1FIU2p
  WQUFIaHlpMDlDVDQ5Sm9zQSJ9fX19fQ",
        {
          "signatures": [{
              "alg": "S512",
              "kid": "MDUR-4AKJ-GEI7-7NXU-HZMM-C2N3-34S5",
              "signature": "czHjTKj7kFcBnOrqKG0hpWTPTjSP6vY1mWzpLG9nxWpxog9IA
  LUSoQ04Ip-MUByf7oAcTMNGrkgA9Qm5q33TFuttqD57aSjhGVE2I2HWssHhrAj
  xgchwwEmP5ArSyeit1mAXtnk7f3DcuwuNXZcEJAwA"}],
          "PayloadDigest": "ZJmoM-pLooex2hV6btC-4Y5VgWYyRsNeiF9b1Ze11y-53
  Y__8g4scXY1xyye11S7_hu2viByH0m4PiTzMK9y5g"}],
      "DeviceUDF": "MBSW-5TDC-4JNH-DP7U-YRYH-336S-XS7X",
      "EnvelopedProfileDevice": [{
          "EnvelopeID": "MBSW-5TDC-4JNH-DP7U-YRYH-336S-XS7X",
          "dig": "S512",
          "ContentMetaData": "ewogICJVbmlxdWVJRCI6ICJNQlNXLTVUREMtNEpOSC1
  EUDdVLVlSWUgtMzM2Uy1YUzdYIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZmlsZ
  URldmljZSIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0IiwKICA
  iQ3JlYXRlZCI6ICIyMDIwLTEwLTIxVDE0OjI4OjMzWiJ9"},
        "ewogICJQcm9maWxlRGV2aWNlIjogewogICAgIlByb2Z
  pbGVTaWduYXR1cmUiOiB7CiAgICAgICJVZGYiOiAiTUJTVy01VERDLTRKTkgtR
  FA3VS1ZUllILTMzNlMtWFM3WCIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjo
  gewogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6I
  CJFZDQ0OCIsCiAgICAgICAgICAiUHVibGljIjogImtCVTJfWUJWZDJ0ck9COXl
  nUkE4SU5nNkRkRE1jb0l1eU5RSXBsZmVtY3k4dl9KNGZiRUIKICB2WVVQbVVTd
  FlOLXFrZlF1ZFA2WHh2b0EifX19LAogICAgIkJhc2VFbmNyeXB0aW9uIjogewo
  gICAgICAiVWRmIjogIk1DUUotNzRNNS1WNFRGLVIzRkYtVzRJVi1EMzM3LVdJR
  EgiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGl
  jS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiWDQ0OCIsCiAgICAgICAgI
  CAiUHVibGljIjogIkd4dVhnTXhCeDZKYlBUd0F2MXIzY0hsYU1LY2VmU25tT1d
  fc0MyYlNRU1VqMDQtT0hjWTUKICA2ekFLZkFtckFVYVk4MEZKMnJWTnBxS0Eif
  X19LAogICAgIkJhc2VBdXRoZW50aWNhdGlvbiI6IHsKICAgICAgIlVkZiI6ICJ
  NQ0FQLTRYQ0UtTkpGSS1GRUVILU82REMtN1IyNC1PVlhZIiwKICAgICAgIlB1Y
  mxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiA
  gICAgICAgICAiY3J2IjogIlg0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJWO
  Xp1VnQ5SDlSR0Y4eDN0SHhlMEFlLTBYcm9HUmRCSW5TbmVGcE50WjNhdWY1dkV
  GcnJQCiAgdENyNVZDamo1U1UyR3R1VEZjSE9RTS1BIn19fSwKICAgICJCYXNlU
  2lnbmF0dXJlIjogewogICAgICAiVWRmIjogIk1ESlEtTURFQS1LV0NRLVZISkM
  tTlo1NC1GRUI0LU83MjQiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKI
  CAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ
  0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJhUURwY3NEY0JVemVEYXFJRTVFY
  0JhQmFGRjMyLTFLekg5QmdVY1l5UTcybnFuS1BCRDBpCiAgZEVwSHM5RFFEZFJ
  ZQmpGR2taTHZJeG9BIn19fX19",
        {
          "signatures": [{
              "alg": "S512",
              "kid": "MBSW-5TDC-4JNH-DP7U-YRYH-336S-XS7X",
              "signature": "HIVO_QuMz2QvFqZb6-5JcDtGbqE9TTImIOWaShzPNTHxjWMDM
  MnyhCp77GuZkytg_ah9bU982poA3AS0wCLb1a_OJ57OpDS8P3CWKt8o_8RS_vK
  M3PrtQQmmgf-ku8URZ0j6dt9_r2Nnft9Ki8Msij8A"}],
          "PayloadDigest": "WinxZRUsnX6SMpIilJUi9GvxfcyGJMcuiJOyZo_IGlhW_
  NnwifH9v-Jno6qx6EJYq75k-kdxusWl8bWyZxmmAw"}],
      "EnvelopedAcknowledgeConnection": [{
          "EnvelopeID": "MCE4-5HGF-CITH-5Z2S-IIVB-BYA3-GIPP",
          "ContentMetaData": "ewogICJVbmlxdWVJRCI6ICJKQUlVLUVNVTYtUFJPNy1
  EUFdULUpXRlgtTkpFNC1TNlkyIiwKICAiTWVzc2FnZVR5cGUiOiAiQWNrbm93b
  GVkZ2VDb25uZWN0aW9uIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmp
  lY3QiLAogICJDcmVhdGVkIjogIjIwMjAtMTAtMjFUMTQ6Mjg6MzNaIn0",
          "ContainerInfo": {
            "Index": 1,
            "TreePosition": 0},
          "Received": "2020-10-21T14:28:33Z"},
        "ewogICJBY2tub3dsZWRnZUNvbm5lY3Rpb24iOiB7CiAgICAiTW
  Vzc2FnZUlkIjogIkpBSVUtRU1VNi1QUk83LURQV1QtSldGWC1OSkU0LVM2WTIi
  LAogICAgIkVudmVsb3BlZFJlcXVlc3RDb25uZWN0aW9uIjogW3sKICAgICAgIC
  AiRW52ZWxvcGVJRCI6ICJNREhTLVlHQTItQ1lMSi1FUVNELUJQRFctSENMQy1C
  VkZJIiwKICAgICAgICAiQ29udGVudE1ldGFEYXRhIjogImV3b2dJQ0pWYm1seG
  RXVkpSQ0k2SUNKT1JGVk1MVlZTVnpVdFVqZE1XaTEKICBaVmtsUUxWUk5XRGN0
  UVVVMVN5MUNRMEpXSWl3S0lDQWlUV1Z6YzJGblpWUjVjR1VpT2lBaVVtVnhkV1
  Z6ZAogIEVOdmJtNWxZM1JwYjI0aUxBb2dJQ0pqZEhraU9pQWlZWEJ3YkdsallY
  UnBiMjR2YlcxdEwyOWlhbVZqZENJCiAgc0NpQWdJa055WldGMFpXUWlPaUFpTW
  pBeU1DMHhNQzB5TVZReE5Eb3lPRG96TTFvaWZRIn0sCiAgICAgICJld29nSUNK
  U1pYRjFaWE4wUTI5dWJtVmpkR2x2YmlJNklIc0tJQ0FnSUNKCiAgTlpYTnpZV2
  RsU1dRaU9pQWlUa1JWVEMxVlVsYzFMVkkzVEZvdFdWWkpVQzFVVFZnM0xVRkZO
  VXN0UWtOQ1YKICBpSXNDaUFnSUNBaVFYVjBhR1Z1ZEdsallYUmxaRVJoZEdFaU
  9pQmJld29nSUNBZ0lDQWdJQ0pGYm5abGJHOQogIHdaVWxFSWpvZ0lrMUNVMWN0
  TlZSRVF5MDBTazVJTFVSUU4xVXRXVkpaU0Mwek16WlRMVmhUTjFnaUxBb2dJCi
  AgQ0FnSUNBZ0lDSmthV2NpT2lBaVV6VXhNaUlzQ2lBZ0lDQWdJQ0FnSWtOdmJu
  UmxiblJOWlhSaFJHRjBZU0kKICA2SUNKbGQyOW5TVU5LVm1KdGJIaGtWMVpLVW
  tOSk5rbERTazVSYkU1WVRGUldWVkpGVFhST1JYQlBVME14QwogIGlBZ1JWVkVa
  RlpNVm14VFYxVm5kRTE2VFRKVmVURlpWWHBrV1VscGQwdEpRMEZwVkZkV2VtTX
  lSbTVhVmxJCiAgMVkwZFZhVTlwUVdsVlNFcDJXbTFzYzFvS0lDQlZVbXhrYld4
  cVdsTkpjME5wUVdkSmJVNHdaVk5KTmtsRFMKICBtaGpTRUp6WVZkT2FHUkhiSF
  ppYVRsMFlsY3dkbUl5U25GYVYwNHdTV2wzUzBsRFFRb2dJR2xSTTBwc1dWaAog
  IFNiRnBEU1RaSlEwbDVUVVJKZDB4VVJYZE1WRWw0VmtSRk1FOXFTVFJQYWsxNl
  YybEtPU0o5TEFvZ0lDQWdJCiAgQ0FpWlhkdlowbERTbEZqYlRsdFlWZDRiRkpI
  VmpKaFYwNXNTV3B2WjJWM2IyZEpRMEZuU1d4Q2VXSXlXZ28KICBnSUhCaVIxWl
  VZVmRrZFZsWVVqRmpiVlZwVDJsQ04wTnBRV2RKUTBGblNVTktWbHBIV1dsUGFV
  RnBWRlZLVgogIEZaNU1ERldSVkpFVEZSU1MxUnJaM1JTQ2lBZ1JrRXpWbE14V2
  xWc2JFbE1WRTE2VG14TmRGZEdUVE5YUTBsCiAgelEybEJaMGxEUVdkSlEwcFJa
  RmRLYzJGWFRsRlpXRXBvWWxkV01GcFlTbnBKYW04S0lDQm5aWGR2WjBsRFEKIC
  BXZEpRMEZuU1VOS1VXUlhTbk5oVjA1TVdsaHNSbEV3VWtsSmFtOW5aWGR2WjBs
  RFFXZEpRMEZuU1VOQlowbAogIHRUbmxrYVVrMlNRb2dJRU5LUmxwRVVUQlBRMG
  x6UTJsQlowbERRV2RKUTBGblNVTkJhVlZJVm1saVIyeHFTCiAgV3B2WjBsdGRF
  TldWRXBtVjFWS1YxcEVTakJqYXpsRFQxaHNDaUFnYmxWclJUUlRWVFZ1VG10U2
  ExSkZNV3AKICBpTUd3eFpWVTFVbE5ZUW5OYWJWWjBXVE5yTkdSc09VdE9SMXBw
  VWxWSlMwbERRakpYVmxaUllsWldWR1FLSQogIENCR2JFOU1XRVp5V214R01WcE
  dRVEpYU0dneVlqQkZhV1pZTVRsTVFXOW5TVU5CWjBsclNtaGpNbFpHWW0xCiAg
  T2VXVllRakJoVnpsMVNXcHZaMlYzYndvZ0lHZEpRMEZuU1VOQmFWWlhVbTFKYW
  05blNXc3hSRlZWYjNST2UKICBsSk9UbE14VjA1R1VrZE1Wa2w2VW10WmRGWjZV
  a3BXYVRGRlRYcE5NMHhXWkVwU0NpQWdSV2RwVEVGdlowbAogIERRV2RKUTBGcF
  ZVaFdhV0pIYkdwVlIwWjVXVmN4YkdSSFZubGplVWsyU1VoelMwbERRV2RKUTBG
  blNVTkJhCiAgVlZJVm1saVIyd0tJQ0JxVXpKV05WSlZUa1ZUUTBrMlNVaHpTMG
  xEUVdkSlEwRm5TVU5CWjBsRFNtcGpibGwKICBwVDJsQmFWZEVVVEJQUTBselEy
  bEJaMGxEUVdkSlEwRm5TUW9nSUVOQmFWVklWbWxpUjJ4cVNXcHZaMGxyWgogIE
  RSa1ZtaHVWRmhvUTJWRVdrdFpiRUpWWkRCR01rMVlTWHBaTUdoeldWVXhURmt5
  Vm0xVk1qVjBWREZrQ2lBCiAgZ1ptTXdUWGxaYkU1U1ZURldjVTFFVVhSVU1HaH
  FWMVJWUzBsRFFUSmxhMFpNV210R2RHTnJSbFpaVm1zMFQKICBVVmFTMDF1U2xk
  VWJrSjRVekJGYVdZS0lDQllNVGxNUVc5blNVTkJaMGxyU21oak1sWkNaRmhTYj
  FwWE5UQgogIGhWMDVvWkVkc2RtSnBTVFpKU0hOTFNVTkJaMGxEUVdkSmJGWnJX
  bWxKTmtsRFNnb2dJRTVSTUVaUlRGUlNXCiAgVkV3VlhSVWEzQkhVMU14UjFKVl
  ZrbE1WVGd5VWtWTmRFNHhTWGxPUXpGUVZteG9Xa2xwZDB0SlEwRm5TVU4KICBC
  WjBsc1FqRlpDaUFnYlhod1dURkNhR050Um5SYVdGSnNZMjVOYVU5cFFqZERhVU
  ZuU1VOQlowbERRV2RKYgogIEVJeFdXMTRjRmt3ZEd4bFZWWkVVa1ZuYVU5cFFq
  ZERhVUVLSUNCblNVTkJaMGxEUVdkSlEwRnBXVE5LTWtsCiAgcWIyZEpiR2N3VG
  tSbmFVeEJiMmRKUTBGblNVTkJaMGxEUVdkSmJFSXhXVzE0Y0ZsNVNUWkpRMHBY
  VHdvZ0kKICBGaHdNVlp1VVRWVFJHeFRVakJaTkdWRVRqQlRTR2hzVFVWR2JFeF
  VRbGxqYlRsSVZXMVNRMU5YTlZSaWJWWgogIEhZMFUxTUZkcVRtaGtWMWt4Wkd0
  V0NpQWdSMk51U2xGRGFVRm5aRVZPZVU1V1drUmhiVzh4VlRGVmVWSXpVCiAgak
  ZXUlZwcVUwVTVVbFJUTVVKSmJqRTVabE4zUzBsRFFXZEpRMHBEV1ZoT2JGVUtJ
  Q0F5Ykc1aWJVWXdaRmgKICBLYkVscWIyZGxkMjluU1VOQlowbERRV2xXVjFKdF
  NXcHZaMGxyTVVWVGJFVjBWRlZTUmxGVE1VeFdNRTVTVAogIEZaYVNWTnJUUW9n
  SUhSVWJHOHhUa014UjFKVlNUQk1WVGd6VFdwUmFVeEJiMmRKUTBGblNVTkJhVl
  ZJVm1sCiAgaVIyeHFWVWRHZVZsWE1XeGtSMVo1WTNsSk5rbEljMHRKQ2lBZ1Ew
  Rm5TVU5CWjBsRFFXbFZTRlpwWWtkc2EKICBsTXlWalZTVlU1RlUwTkpOa2xJYz
  B0SlEwRm5TVU5CWjBsRFFXZEpRMHBxWTI1WmFVOXBRV2xTVjFFS0lDQQogIHdU
  a1JuYVV4QmIyZEpRMEZuU1VOQlowbERRV2RKYkVJeFdXMTRjRmw1U1RaSlEwcG
  9WVlZTZDFrelRrVlpNCiAgRXBXWlcxV1JWbFlSa3BTVkZaR1dRb2dJREJLYUZG
  dFJrZFNhazE1VEZSR1RHVnJaelZSYldSV1dURnNOVlYKICBVWTNsaWJrWjFVek
  ZDUTFKRVFuQkRhVUZuV2tWV2QxTklUVFZTUmtaRldrWktDaUFnV2xGdGNFZFNN
  blJoVgogIEVoYVNtVkhPVUpKYmpFNVpsZ3hPU0lzQ2lBZ0lDQWdJSHNLSUNBZ0
  lDQWdJQ0FpYzJsbmJtRjBkWEpsY3lJCiAgNklGdDdDaUFnSUNBZ0lDQWdJQ0Fn
  SUNKaGJHY2lPaUFpVXpVeE1pSXNDaUFnSUNBZ0lDQWdJQ0FnSUNKcmEKICBXUW
  lPaUFpVFVKVFZ5MDFWRVJETFRSS1RrZ3RSRkEzVlMxWlVsbElMVE16TmxNdFdG
  TTNXQ0lzQ2lBZ0lDQQogIGdJQ0FnSUNBZ0lDSnphV2R1WVhSMWNtVWlPaUFpU0
  VsV1QxOVJkVTE2TWxGMlJuRmFZall0TlVwalJIUkhZCiAgbkZGT1ZSVVNXMUpU
  MWRoVTJoNlVFNVVTSGhxVjAxRVRRb2dJRTF1ZVdoRGNEYzNSM1ZhYTNsMFoxOW
  hhRGwKICBpVlRrNE1uQnZRVE5CVXpCM1EweGlNV0ZmVDBvMU4wOXdSRk00VURO
  RFYwdDBPRzlmT0ZKVFgzWkxDaUFnVAogIFROUWNuUlJVVzF0WjJZdGEzVTRWVk
  phTUdvMlpIUTVYM0l5VG01bWREbExhVGhOYzJscU9FRWlmVjBzQ2lBCiAgZ0lD
  QWdJQ0FnSWxCaGVXeHZZV1JFYVdkbGMzUWlPaUFpVjJsdWVGcFNWWE51V0RaVF
  RYQkphV3hLVldrNVIKICAzWjRabU41UjBwTlkzVnBTazk1V205ZlNVZHNhRmRm
  Q2lBZ1RtNTNhV1pJT1hZdFNtNXZObkY0TmtWS1dYRQogIDNOV3N0YTJSNGRYTl
  hiRGhpVjNsYWVHMXRRWGNpZlYwc0NpQWdJQ0FpUTJ4cFpXNTBUbTl1WTJVaU9p
  QWlXCiAgak4xZGw5d2VYQnRhbXRzY0RGS04wUjJYMlpvWnlJc0NpQWdJQ0FpUV
  dOamIzVnVkRUZrWkhKbGMzTWlPaUEKICBpWVd4cFkyVkFaWGhoYlhCc1pTNWpi
  MjBpZlgwIl0sCiAgICAiU2VydmVyTm9uY2UiOiAicWc2R1lKSWd6WTJQQnpycV
  AwMVROZyIsCiAgICAiV2l0bmVzcyI6ICJKQUlVLUVNVTYtUFJPNy1EUFdULUpX
  RlgtTkpFNC1TNlkyIn19",
        {}],
      "AccountAddress": "alice@example.com"}}}
</div>
~~~~



