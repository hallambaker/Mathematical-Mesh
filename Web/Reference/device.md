

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
<cmd>Alice> device accept AZQV-NA3W-DTL6-6F6Z-Z2KX-UU4I-OPC4
<rsp>ERROR - Cannot access a closed file.
</div>
~~~~

Specifying the /json option returns a result of type Result:

~~~~
<div="terminal">
<cmd>Alice> device accept AZQV-NA3W-DTL6-6F6Z-Z2KX-UU4I-OPC4 /json
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
<cmd>Alice> device accept AZQV-NA3W-DTL6-6F6Z-Z2KX-UU4I-OPC4
<rsp>ERROR - Cannot access a closed file.
</div>
~~~~

Specifying the /json option returns a result of type Result:

~~~~
<div="terminal">
<cmd>Alice> device accept AZQV-NA3W-DTL6-6F6Z-Z2KX-UU4I-OPC4 /json
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
<cmd>Alice> device delete AZQV-NA3W-DTL6-6F6Z-Z2KX-UU4I-OPC4
<rsp>ERROR - The feature has not been implemented
</div>
~~~~

Specifying the /json option returns a result of type Result:

~~~~
<div="terminal">
<cmd>Alice> device delete AZQV-NA3W-DTL6-6F6Z-Z2KX-UU4I-OPC4 /json
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
<rsp>MessageID: HCG4-XSEY-PC7D-KLDI-OP6X-MEBD-TLWT
        Connection Request::
        MessageID: HCG4-XSEY-PC7D-KLDI-OP6X-MEBD-TLWT
        To:  From: 
        Device:  MARV-3CT2-H7RW-CPGM-ILRK-4C6V-QIYK
        Witness: HCG4-XSEY-PC7D-KLDI-OP6X-MEBD-TLWT
MessageID: AZQV-NA3W-DTL6-6F6Z-Z2KX-UU4I-OPC4
        Connection Request::
        MessageID: AZQV-NA3W-DTL6-6F6Z-Z2KX-UU4I-OPC4
        To:  From: 
        Device:  MCRS-WMA4-QV32-HPLQ-4L3R-MSYA-UJXZ
        Witness: AZQV-NA3W-DTL6-6F6Z-Z2KX-UU4I-OPC4
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
        "MessageId": "HCG4-XSEY-PC7D-KLDI-OP6X-MEBD-TLWT",
        "EnvelopedRequestConnection": [{
            "EnvelopeID": "MBPN-YHZT-Z54R-KJIY-UF5H-IA5O-5JQR",
            "ContentMetaData": "ewogICJVbmlxdWVJRCI6ICJOQkVLLUNCSkwtVFZCTi1
  LTEdJLUtNQU0tS01CRC1YTUwzIiwKICAiTWVzc2FnZVR5cGUiOiAiUmVxdWVzd
  ENvbm5lY3Rpb24iLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCI
  sCiAgIkNyZWF0ZWQiOiAiMjAyMC0xMC0yM1QxNToxODo1NFoifQ"},
          "ewogICJSZXF1ZXN0Q29ubmVjdGlvbiI6IHsKICAgICJ
  NZXNzYWdlSWQiOiAiTkJFSy1DQkpMLVRWQk4tS0xHSS1LTUFNLUtNQkQtWE1MM
  yIsCiAgICAiQXV0aGVudGljYXRlZERhdGEiOiBbewogICAgICAgICJFbnZlbG9
  wZUlEIjogIk1BUlYtM0NUMi1IN1JXLUNQR00tSUxSSy00QzZWLVFJWUsiLAogI
  CAgICAgICJkaWciOiAiUzUxMiIsCiAgICAgICAgIkNvbnRlbnRNZXRhRGF0YSI
  6ICJld29nSUNKVmJtbHhkV1ZKUkNJNklDSk5RVkpXTFRORFZESXRTRGRTVnkxC
  iAgRFVFZE5MVWxNVWtzdE5FTTJWaTFSU1ZsTElpd0tJQ0FpVFdWemMyRm5aVlI
  1Y0dVaU9pQWlVSEp2Wm1sc1oKICBVUmxkbWxqWlNJc0NpQWdJbU4wZVNJNklDS
  mhjSEJzYVdOaGRHbHZiaTl0YlcwdmIySnFaV04wSWl3S0lDQQogIGlRM0psWVh
  SbFpDSTZJQ0l5TURJd0xURXdMVEl6VkRFMU9qRTRPalUwV2lKOSJ9LAogICAgI
  CAiZXdvZ0lDSlFjbTltYVd4bFJHVjJhV05sSWpvZ2V3b2dJQ0FnSWxCeWIyWgo
  gIHBiR1ZUYVdkdVlYUjFjbVVpT2lCN0NpQWdJQ0FnSUNKVlpHWWlPaUFpVFVGU
  1ZpMHpRMVF5TFVnM1VsY3RRCiAgMUJIVFMxSlRGSkxMVFJETmxZdFVVbFpTeUl
  zQ2lBZ0lDQWdJQ0pRZFdKc2FXTlFZWEpoYldWMFpYSnpJam8KICBnZXdvZ0lDQ
  WdJQ0FnSUNKUWRXSnNhV05MWlhsRlEwUklJam9nZXdvZ0lDQWdJQ0FnSUNBZ0l
  tTnlkaUk2SQogIENKRlpEUTBPQ0lzQ2lBZ0lDQWdJQ0FnSUNBaVVIVmliR2xqS
  WpvZ0lrcEJNWGMxZERGdFgzSTJjVmRXYlZGCiAga2VYRk1PVEZOUkRVeWRWazR
  SR2xKVkRnM2NtNVFSbVJqWVZGbVN6WnBiMmRQWW5JS0lDQXlWMjlqTVZveGMKI
  CBuSXdWMmxxT0VOSWJXMHpka3hhT0VFaWZYMTlMQW9nSUNBZ0lrSmhjMlZGYm1
  OeWVYQjBhVzl1SWpvZ2V3bwogIGdJQ0FnSUNBaVZXUm1Jam9nSWsxRVV6TXRTM
  DlCVmkxUk4wZEtMVUUxTTBjdFNWbE1SUzFVVkZWUkxVeFpUCiAgVVVpTEFvZ0l
  DQWdJQ0FpVUhWaWJHbGpVR0Z5WVcxbGRHVnljeUk2SUhzS0lDQWdJQ0FnSUNBa
  VVIVmliR2wKICBqUzJWNVJVTkVTQ0k2SUhzS0lDQWdJQ0FnSUNBZ0lDSmpjbll
  pT2lBaVdEUTBPQ0lzQ2lBZ0lDQWdJQ0FnSQogIENBaVVIVmliR2xqSWpvZ0lsZ
  EZRMlpKT1doWE1qTlBSM1pmVWxoNlVqazVWM2wyUm5RdFNVcE1OR3d4VG1NCiA
  geFVtOTJSbUkyY0dVd1IyRklNMEV3V0dvS0lDQk5XbVpvUm5VMVRsRjNjekZ4Z
  Hpoc1ExSTFXRzlFV1VFaWYKICBYMTlMQW9nSUNBZ0lrSmhjMlZCZFhSb1pXNTB
  hV05oZEdsdmJpSTZJSHNLSUNBZ0lDQWdJbFZrWmlJNklDSgogIE5RMWN6TFZre
  VQxRXRUbGRGVGkxT1draEtMVnBXVERZdE1qSkVSeTAzUmt0Sklpd0tJQ0FnSUN
  BZ0lsQjFZCiAgbXhwWTFCaGNtRnRaWFJsY25NaU9pQjdDaUFnSUNBZ0lDQWdJb
  EIxWW14cFkwdGxlVVZEUkVnaU9pQjdDaUEKICBnSUNBZ0lDQWdJQ0FpWTNKMkl
  qb2dJbGcwTkRnaUxBb2dJQ0FnSUNBZ0lDQWdJbEIxWW14cFl5STZJQ0ozWgogI
  ERoQldrczVSMUI1TkVVMWNrVjJWRXhFV2xSZk9ITk9OeTFOYlRSNldIWkhkV1V
  6U0ZKdVowVmlMVVV3VVY5CiAgcU0zWk1DaUFnVldwb2FsUlliWFpCYURRNWRtO
  TFXbVpsZEhWMGNIVkJJbjE5ZlN3S0lDQWdJQ0pDWVhObFUKICAybG5ibUYwZFh
  KbElqb2dld29nSUNBZ0lDQWlWV1JtSWpvZ0lrMUNOa0V0VmxKSk55MWFUa2xZT
  FRKV1dFYwogIHRVa3REVWkxS1ZrNVdMVTAxVUU0aUxBb2dJQ0FnSUNBaVVIVml
  iR2xqVUdGeVlXMWxkR1Z5Y3lJNklIc0tJCiAgQ0FnSUNBZ0lDQWlVSFZpYkdsa
  lMyVjVSVU5FU0NJNklIc0tJQ0FnSUNBZ0lDQWdJQ0pqY25ZaU9pQWlSV1EKICA
  wTkRnaUxBb2dJQ0FnSUNBZ0lDQWdJbEIxWW14cFl5STZJQ0pGZHpkdlZIaHpRW
  EZhZGxGV2MwWnpXa2cxUwogIEhaWlZtRjJhekZsTnpsQk16SkNMVEZwTjFWTlZ
  6bFphazU0Y2taNlRHUXlDaUFnVFU1RFZHaFdSVU15YzBrCiAgdFYwRkJXVlZXW
  khaV2JWVkJJbjE5ZlgxOSIsCiAgICAgIHsKICAgICAgICAic2lnbmF0dXJlcyI
  6IFt7CiAgICAgICAgICAgICJhbGciOiAiUzUxMiIsCiAgICAgICAgICAgICJra
  WQiOiAiTUFSVi0zQ1QyLUg3UlctQ1BHTS1JTFJLLTRDNlYtUUlZSyIsCiAgICA
  gICAgICAgICJzaWduYXR1cmUiOiAiYjdUXzRfNTdsZmpWLVlZaXRqM29nQ3I0T
  nNEeHIyNTNEMlVUZDNXYlZOd19SU3lsaQogIGU0WXA5TjdSbmx4MVZDdXZaNy1
  BQzJCTWkyQW5oQ0t3TVJzbTBDbE1sUXVjbzlKZ1ZCR1VRc3BYalQ5YXh6CiAgS
  GtSeWRfWk1ydzlBMGd6aGpqQmNwMTc4VTVxcUFnVEZYbDIteXV4d0EifV0sCiA
  gICAgICAgIlBheWxvYWREaWdlc3QiOiAiQ01yQ0RHb3oxSGtyWjA1VlFCXzR2Z
  zJFMmtBN082cVhSMlJYODVLZnhyVFRpCiAgM1cxSkxtMFJsbUtieHVvV3E3TUR
  jVU0tRWtXNU9fM0NCM0M5allESVEifV0sCiAgICAiQ2xpZW50Tm9uY2UiOiAid
  ERaZDRLNzlVMmloOV83eW5LQ1dndyIsCiAgICAiQWNjb3VudEFkZHJlc3MiOiA
  iYWxpY2VAZXhhbXBsZS5jb20ifX0"],
        "ServerNonce": "yByzAmpgfKIz4O1b0_CsgQ",
        "Witness": "HCG4-XSEY-PC7D-KLDI-OP6X-MEBD-TLWT"},
      {
        "MessageId": "AZQV-NA3W-DTL6-6F6Z-Z2KX-UU4I-OPC4",
        "EnvelopedRequestConnection": [{
            "EnvelopeID": "MCLW-SWBM-CVP4-HYAG-3AOD-LY6R-VPVJ",
            "ContentMetaData": "ewogICJVbmlxdWVJRCI6ICJOQ1RELUtTUkItQTRPUS0
  zUzc1LTVRRUMtTlc1NC1aRTNaIiwKICAiTWVzc2FnZVR5cGUiOiAiUmVxdWVzd
  ENvbm5lY3Rpb24iLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCI
  sCiAgIkNyZWF0ZWQiOiAiMjAyMC0xMC0yM1QxNToxODo1M1oifQ"},
          "ewogICJSZXF1ZXN0Q29ubmVjdGlvbiI6IHsKICAgICJ
  NZXNzYWdlSWQiOiAiTkNURC1LU1JCLUE0T1EtM1M3NS01UUVDLU5XNTQtWkUzW
  iIsCiAgICAiQXV0aGVudGljYXRlZERhdGEiOiBbewogICAgICAgICJFbnZlbG9
  wZUlEIjogIk1DUlMtV01BNC1RVjMyLUhQTFEtNEwzUi1NU1lBLVVKWFoiLAogI
  CAgICAgICJkaWciOiAiUzUxMiIsCiAgICAgICAgIkNvbnRlbnRNZXRhRGF0YSI
  6ICJld29nSUNKVmJtbHhkV1ZKUkNJNklDSk5RMUpUTFZkTlFUUXRVVll6TWkxC
  iAgSVVFeFJMVFJNTTFJdFRWTlpRUzFWU2xoYUlpd0tJQ0FpVFdWemMyRm5aVlI
  1Y0dVaU9pQWlVSEp2Wm1sc1oKICBVUmxkbWxqWlNJc0NpQWdJbU4wZVNJNklDS
  mhjSEJzYVdOaGRHbHZiaTl0YlcwdmIySnFaV04wSWl3S0lDQQogIGlRM0psWVh
  SbFpDSTZJQ0l5TURJd0xURXdMVEl6VkRFMU9qRTRPalV6V2lKOSJ9LAogICAgI
  CAiZXdvZ0lDSlFjbTltYVd4bFJHVjJhV05sSWpvZ2V3b2dJQ0FnSWxCeWIyWgo
  gIHBiR1ZUYVdkdVlYUjFjbVVpT2lCN0NpQWdJQ0FnSUNKVlpHWWlPaUFpVFVOU
  1V5MVhUVUUwTFZGV016SXRTCiAgRkJNVVMwMFRETlNMVTFUV1VFdFZVcFlXaUl
  zQ2lBZ0lDQWdJQ0pRZFdKc2FXTlFZWEpoYldWMFpYSnpJam8KICBnZXdvZ0lDQ
  WdJQ0FnSUNKUWRXSnNhV05MWlhsRlEwUklJam9nZXdvZ0lDQWdJQ0FnSUNBZ0l
  tTnlkaUk2SQogIENKRlpEUTBPQ0lzQ2lBZ0lDQWdJQ0FnSUNBaVVIVmliR2xqS
  WpvZ0lreDZkRE54YlRkWWVIRk9lSEl3V2xkCiAgQ1RYWTJVelJ4ZFRaVlVXVkJ
  lVUZYU0VodE1WRlVVV2gwUWt4RGVscHBha2hzUjJnS0lDQnRYMjVLTW10d1QKI
  CBYQlJUVkZrVTJ4ZlJuRTJVR3BuUjBFaWZYMTlMQW9nSUNBZ0lrSmhjMlZGYm1
  OeWVYQjBhVzl1SWpvZ2V3bwogIGdJQ0FnSUNBaVZXUm1Jam9nSWsxRFZGY3RUa
  1ZDVEMxVU5scExMVkJIVEVrdE4wUktSQzAyVjBGQ0xVdFlOCiAgMWNpTEFvZ0l
  DQWdJQ0FpVUhWaWJHbGpVR0Z5WVcxbGRHVnljeUk2SUhzS0lDQWdJQ0FnSUNBa
  VVIVmliR2wKICBqUzJWNVJVTkVTQ0k2SUhzS0lDQWdJQ0FnSUNBZ0lDSmpjbll
  pT2lBaVdEUTBPQ0lzQ2lBZ0lDQWdJQ0FnSQogIENBaVVIVmliR2xqSWpvZ0lsT
  kVWVlpQYUhOU2NuUnlUMmRIYW1WSU5GUkthMUYyTkZwclEwUkdVWGxIVTNOCiA
  gb1MycDRSblZJVmxrMWVVNVFlamQ0YTJrS0lDQjVia0o0VkMxUFdDMWtWbGN5T
  mpoWlZVdFpVR3BsWjBFaWYKICBYMTlMQW9nSUNBZ0lrSmhjMlZCZFhSb1pXNTB
  hV05oZEdsdmJpSTZJSHNLSUNBZ0lDQWdJbFZrWmlJNklDSgogIE5Ra2RFTFV0T
  FZGY3RSRWxhV2kwM1JrRlpMVVpTTTAwdFdsTkxSUzAyTlRZeklpd0tJQ0FnSUN
  BZ0lsQjFZCiAgbXhwWTFCaGNtRnRaWFJsY25NaU9pQjdDaUFnSUNBZ0lDQWdJb
  EIxWW14cFkwdGxlVVZEUkVnaU9pQjdDaUEKICBnSUNBZ0lDQWdJQ0FpWTNKMkl
  qb2dJbGcwTkRnaUxBb2dJQ0FnSUNBZ0lDQWdJbEIxWW14cFl5STZJQ0k0UgogI
  G1neGFVMDNabEV4ZUMxalIxWnlkR1U1VGt4Q2JFdEhhVXQwZDFCb09VeFdPVEp
  OYzI5dlVqQnBVbEZHV1RsCiAgVWMyOTFDaUFnYjFobFkxQmtTbWxSVkdwS1owb
  3lNbkpNV1RNMmRtRkJJbjE5ZlN3S0lDQWdJQ0pDWVhObFUKICAybG5ibUYwZFh
  KbElqb2dld29nSUNBZ0lDQWlWV1JtSWpvZ0lrMUNSVFl0UVZGQlVDMUxSREpNT
  FVkVVJrSQogIHRWa3RGUmkxVVNETkxMVEpRTjBNaUxBb2dJQ0FnSUNBaVVIVml
  iR2xqVUdGeVlXMWxkR1Z5Y3lJNklIc0tJCiAgQ0FnSUNBZ0lDQWlVSFZpYkdsa
  lMyVjVSVU5FU0NJNklIc0tJQ0FnSUNBZ0lDQWdJQ0pqY25ZaU9pQWlSV1EKICA
  wTkRnaUxBb2dJQ0FnSUNBZ0lDQWdJbEIxWW14cFl5STZJQ0p2T0U0emNuZG5WV
  EZqVEdZd1V6ZHFUR2c0UwogIFV0c1lYaEJiR3hHWTBoR1MwMXBSV0ZwYlhsQ1p
  VWk5VbWs1VW10QmNtdEtDaUFnWnpKa1ExaFBSbkpWTnpCCiAgQk1IbERURmhrY
  VVaTmEwZEJJbjE5ZlgxOSIsCiAgICAgIHsKICAgICAgICAic2lnbmF0dXJlcyI
  6IFt7CiAgICAgICAgICAgICJhbGciOiAiUzUxMiIsCiAgICAgICAgICAgICJra
  WQiOiAiTUNSUy1XTUE0LVFWMzItSFBMUS00TDNSLU1TWUEtVUpYWiIsCiAgICA
  gICAgICAgICJzaWduYXR1cmUiOiAiMEtKNzNEbkN1bW1Pam9OQjF1TDVyejI3W
  UwtOGdvUjhhMkVsYWhIb3A0dmtYSHFBTAogIG9pVHdPUkRMX2ZfVEV1QXNPQ05
  2Wjh5OEYtQXVTaElQc2YxblRDWEJYZUZoWDVNZTI3ZC1KR0FwR3NuR1M3CiAgN
  U5iYWp0MS1rbVEtV3BKUVhBWlNLTmloSmFQSU1TdW1WdjVLXzVCQUEifV0sCiA
  gICAgICAgIlBheWxvYWREaWdlc3QiOiAiaHhGR01tSHB6UElIWmlRZmdaa1cwd
  VAwY3djNTlYZ3lKcWdUNUdHRmpFRlU4CiAgNWUzSjBxS25EUTdVdkRYSm1qbjJ
  Kci1lYk1TQnZHSjN2M3dZYnNkMGcifV0sCiAgICAiQ2xpZW50Tm9uY2UiOiAiR
  Fl5U1RSR2hSOU1odndTeTA3VEZNdyIsCiAgICAiQWNjb3VudEFkZHJlc3MiOiA
  iYWxpY2VAZXhhbXBsZS5jb20ifX0"],
        "ServerNonce": "Y6iiziOv0a8B-5MHd2sntA",
        "Witness": "AZQV-NA3W-DTL6-6F6Z-Z2KX-UU4I-OPC4"}]}}
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
<cmd>Alice> device reject HCG4-XSEY-PC7D-KLDI-OP6X-MEBD-TLWT
<rsp></div>
~~~~

Specifying the /json option returns a result of type ResultProcess:

~~~~
<div="terminal">
<cmd>Alice> device reject HCG4-XSEY-PC7D-KLDI-OP6X-MEBD-TLWT /json
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
<rsp>   Device UDF = MCRS-WMA4-QV32-HPLQ-4L3R-MSYA-UJXZ
   Witness value = AZQV-NA3W-DTL6-6F6Z-Z2KX-UU4I-OPC4
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
      "Id": "MCRS-WMA4-QV32-HPLQ-4L3R-MSYA-UJXZ",
      "EnvelopedProfileAccount": [{
          "EnvelopeID": "MCAP-Q4KN-WUUZ-PAAK-AB6K-5JVV-AKRD",
          "dig": "S512",
          "ContentMetaData": "ewogICJVbmlxdWVJRCI6ICJNQ0FQLVE0S04tV1VVWi1
  QQUFLLUFCNkstNUpWVi1BS1JEIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZmlsZ
  VVzZXIiLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIsCiAgIkN
  yZWF0ZWQiOiAiMjAyMC0xMC0yM1QxNToxODo1MVoifQ"},
        "ewogICJQcm9maWxlVXNlciI6IHsKICAgICJQcm9maWx
  lU2lnbmF0dXJlIjogewogICAgICAiVWRmIjogIk1DQVAtUTRLTi1XVVVaLVBBQ
  UstQUI2Sy01SlZWLUFLUkQiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHs
  KICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiR
  WQ0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJCS1d6eGRKWkd0YVVjdi1INnR
  EZ3B0OS1sWjVzODRTanNUS25NcHFJWkNZOXQyYTAwSFBOCiAgMV9yX3JydWE4Y
  UlzaHFCb0tOM2hVd2NBIn19fSwKICAgICJBY2NvdW50QWRkcmVzcyI6ICJhbGl
  jZUBleGFtcGxlLmNvbSIsCiAgICAiU2VydmljZVVkZiI6ICJNQUMyLVhZNk0tT
  UVWMi1RRklNLTQzWFEtNU0zQi1OWlNFIiwKICAgICJBY2NvdW50RW5jcnlwdGl
  vbiI6IHsKICAgICAgIlVkZiI6ICJNQlJYLU5MWFotS0VUQy1VNFA1LTZWM0YtS
  zU0Wi1UV0VBIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICA
  gIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogI
  CAgICAgICAgIlB1YmxpYyI6ICJqcmxmZExmdXJTMGRaTnNqdnE0QmpQcW5TenF
  STTh1U0ZGeXFOSS1Td2h2d0ZNeDYtMGw4CiAgNmc5SXJwc1pVZU9CTGNJUldlV
  WZsQjZBIn19fSwKICAgICJBZG1pbmlzdHJhdG9yU2lnbmF0dXJlIjogewogICA
  gICAiVWRmIjogIk1DQVAtUTRLTi1XVVVaLVBBQUstQUI2Sy01SlZWLUFLUkQiL
  AogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V
  5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAgI
  lB1YmxpYyI6ICJCS1d6eGRKWkd0YVVjdi1INnREZ3B0OS1sWjVzODRTanNUS25
  NcHFJWkNZOXQyYTAwSFBOCiAgMV9yX3JydWE4YUlzaHFCb0tOM2hVd2NBIn19f
  SwKICAgICJBY2NvdW50QXV0aGVudGljYXRpb24iOiB7CiAgICAgICJVZGYiOiA
  iTUFKNS1CM1A3LVAzQlotVVJYUy1ZNDRXLVgySkEtU09NTSIsCiAgICAgICJQd
  WJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewo
  gICAgICAgICAgImNydiI6ICJYNDQ4IiwKICAgICAgICAgICJQdWJsaWMiOiAiX
  0htQzNlYzBReFV2OC1ZWFpOM05JanJOQks1RlVRNURzREtQbE8wVWdmZFFnc2Z
  PMjBSVAogIE1vNDl4MUtleThPaTY1d3NFMldLSnd1QSJ9fX0sCiAgICAiQWNjb
  3VudFNpZ25hdHVyZSI6IHsKICAgICAgIlVkZiI6ICJNQktWLUNFRlItVVRPMi1
  XMzZLLU01QUstVVhQSy1DV05DIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiO
  iB7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2Ijo
  gIkVkNDQ4IiwKICAgICAgICAgICJQdWJsaWMiOiAiQmsxSWNPUllDMTVfZGt3R
  zVzV1lEV3dNVlYwTV84Y0NWbjhKU0hXa2FoVTRWeXEzOEYycAogIDg0UGNCZFZ
  jZ0xMUEhZWEtubXFfSlktQSJ9fX19fQ",
        {
          "signatures": [{
              "alg": "S512",
              "kid": "MCAP-Q4KN-WUUZ-PAAK-AB6K-5JVV-AKRD",
              "signature": "GFM5omve9D6dV2PRU-LLpwsBWZZOd7eZkLNOPo7rkNLy8fBse
  MRcf2ZqYqLYMgjwhfpJWMG_VfyAyr1qJbtodNJPCP2vV_aTmSJE5j-LARW8oG6
  ReRE-eRJRZraoDydkc70Ayvy-3yDTV2lP0bcr7BQA"}],
          "PayloadDigest": "631YRohVmktPFEwOxyyYvRRiXAsStFqVFEOihgEQ7hMHy
  74jRDy71MwlIueVN2xtvYLJVj-hXzvYfIfXPGb3-A"}],
      "DeviceUDF": "MCRS-WMA4-QV32-HPLQ-4L3R-MSYA-UJXZ",
      "EnvelopedProfileDevice": [{
          "EnvelopeID": "MCRS-WMA4-QV32-HPLQ-4L3R-MSYA-UJXZ",
          "dig": "S512",
          "ContentMetaData": "ewogICJVbmlxdWVJRCI6ICJNQ1JTLVdNQTQtUVYzMi1
  IUExRLTRMM1ItTVNZQS1VSlhaIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZmlsZ
  URldmljZSIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0IiwKICA
  iQ3JlYXRlZCI6ICIyMDIwLTEwLTIzVDE1OjE4OjUzWiJ9"},
        "ewogICJQcm9maWxlRGV2aWNlIjogewogICAgIlByb2Z
  pbGVTaWduYXR1cmUiOiB7CiAgICAgICJVZGYiOiAiTUNSUy1XTUE0LVFWMzItS
  FBMUS00TDNSLU1TWUEtVUpYWiIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjo
  gewogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6I
  CJFZDQ0OCIsCiAgICAgICAgICAiUHVibGljIjogIkx6dDNxbTdYeHFOeHIwWld
  CTXY2UzRxdTZVUWVBeUFXSEhtMVFUUWh0QkxDelppakhsR2gKICBtX25KMmtwT
  XBRTVFkU2xfRnE2UGpnR0EifX19LAogICAgIkJhc2VFbmNyeXB0aW9uIjogewo
  gICAgICAiVWRmIjogIk1DVFctTkVCTC1UNlpLLVBHTEktN0RKRC02V0FCLUtYN
  1ciLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGl
  jS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiWDQ0OCIsCiAgICAgICAgI
  CAiUHVibGljIjogIlNEVVZPaHNScnRyT2dHamVINFRKa1F2NFprQ0RGUXlHU3N
  oS2p4RnVIVlk1eU5Qejd4a2kKICB5bkJ4VC1PWC1kVlcyNjhZVUtZUGplZ0Eif
  X19LAogICAgIkJhc2VBdXRoZW50aWNhdGlvbiI6IHsKICAgICAgIlVkZiI6ICJ
  NQkdELUtLVFctRElaWi03RkFZLUZSM00tWlNLRS02NTYzIiwKICAgICAgIlB1Y
  mxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiA
  gICAgICAgICAiY3J2IjogIlg0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICI4R
  mgxaU03ZlExeC1jR1ZydGU5TkxCbEtHaUt0d1BoOUxWOTJNc29vUjBpUlFGWTl
  Uc291CiAgb1hlY1BkSmlRVGpKZ0oyMnJMWTM2dmFBIn19fSwKICAgICJCYXNlU
  2lnbmF0dXJlIjogewogICAgICAiVWRmIjogIk1CRTYtQVFBUC1LRDJMLUdURkI
  tVktFRi1USDNLLTJQN0MiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKI
  CAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ
  0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJvOE4zcndnVTFjTGYwUzdqTGg4S
  UtsYXhBbGxGY0hGS01pRWFpbXlCZUZNUmk5UmtBcmtKCiAgZzJkQ1hPRnJVNzB
  BMHlDTFhkaUZNa0dBIn19fX19",
        {
          "signatures": [{
              "alg": "S512",
              "kid": "MCRS-WMA4-QV32-HPLQ-4L3R-MSYA-UJXZ",
              "signature": "0KJ73DnCummOjoNB1uL5rz27YL-8goR8a2ElahHop4vkXHqAL
  oiTwORDL_f_TEuAsOCNvZ8y8F-AuShIPsf1nTCXBXeFhX5Me27d-JGApGsnGS7
  5Nbajt1-kmQ-WpJQXAZSKNihJaPIMSumVv5K_5BAA"}],
          "PayloadDigest": "hxFGMmHpzPIHZiQfgZkW0uP0cwc59XgyJqgT5GGFjEFU8
  5e3J0qKnDQ7UvDXJmjn2Jr-ebMSBvGJ3v3wYbsd0g"}],
      "EnvelopedAcknowledgeConnection": [{
          "EnvelopeID": "MC2U-BZN2-6Q4T-ZTXJ-55FK-U6WU-SSXM",
          "ContentMetaData": "ewogICJVbmlxdWVJRCI6ICJBWlFWLU5BM1ctRFRMNi0
  2RjZaLVoyS1gtVVU0SS1PUEM0IiwKICAiTWVzc2FnZVR5cGUiOiAiQWNrbm93b
  GVkZ2VDb25uZWN0aW9uIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmp
  lY3QiLAogICJDcmVhdGVkIjogIjIwMjAtMTAtMjNUMTU6MTg6NTNaIn0",
          "ContainerInfo": {
            "Index": 1,
            "TreePosition": 0},
          "Received": "2020-10-23T15:18:53Z"},
        "ewogICJBY2tub3dsZWRnZUNvbm5lY3Rpb24iOiB7CiAgICAiTW
  Vzc2FnZUlkIjogIkFaUVYtTkEzVy1EVEw2LTZGNlotWjJLWC1VVTRJLU9QQzQi
  LAogICAgIkVudmVsb3BlZFJlcXVlc3RDb25uZWN0aW9uIjogW3sKICAgICAgIC
  AiRW52ZWxvcGVJRCI6ICJNQ0xXLVNXQk0tQ1ZQNC1IWUFHLTNBT0QtTFk2Ui1W
  UFZKIiwKICAgICAgICAiQ29udGVudE1ldGFEYXRhIjogImV3b2dJQ0pWYm1seG
  RXVkpSQ0k2SUNKT1ExUkVMVXRUVWtJdFFUUlBVUzAKICB6VXpjMUxUVlJSVU10
  VGxjMU5DMWFSVE5hSWl3S0lDQWlUV1Z6YzJGblpWUjVjR1VpT2lBaVVtVnhkV1
  Z6ZAogIEVOdmJtNWxZM1JwYjI0aUxBb2dJQ0pqZEhraU9pQWlZWEJ3YkdsallY
  UnBiMjR2YlcxdEwyOWlhbVZqZENJCiAgc0NpQWdJa055WldGMFpXUWlPaUFpTW
  pBeU1DMHhNQzB5TTFReE5Ub3hPRG8xTTFvaWZRIn0sCiAgICAgICJld29nSUNK
  U1pYRjFaWE4wUTI5dWJtVmpkR2x2YmlJNklIc0tJQ0FnSUNKCiAgTlpYTnpZV2
  RsU1dRaU9pQWlUa05VUkMxTFUxSkNMVUUwVDFFdE0xTTNOUzAxVVVWRExVNVhO
  VFF0V2tVelcKICBpSXNDaUFnSUNBaVFYVjBhR1Z1ZEdsallYUmxaRVJoZEdFaU
  9pQmJld29nSUNBZ0lDQWdJQ0pGYm5abGJHOQogIHdaVWxFSWpvZ0lrMURVbE10
  VjAxQk5DMVJWak15TFVoUVRGRXRORXd6VWkxTlUxbEJMVlZLV0ZvaUxBb2dJCi
  AgQ0FnSUNBZ0lDSmthV2NpT2lBaVV6VXhNaUlzQ2lBZ0lDQWdJQ0FnSWtOdmJu
  UmxiblJOWlhSaFJHRjBZU0kKICA2SUNKbGQyOW5TVU5LVm1KdGJIaGtWMVpLVW
  tOSk5rbERTazVSTVVwVVRGWmtUbEZVVVhSVlZsbDZUV2t4QwogIGlBZ1NWVkZl
  RkpNVkZKTlRURkpkRlJXVGxwUlV6RldVMnhvWVVscGQwdEpRMEZwVkZkV2VtTX
  lSbTVhVmxJCiAgMVkwZFZhVTlwUVdsVlNFcDJXbTFzYzFvS0lDQlZVbXhrYld4
  cVdsTkpjME5wUVdkSmJVNHdaVk5KTmtsRFMKICBtaGpTRUp6WVZkT2FHUkhiSF
  ppYVRsMFlsY3dkbUl5U25GYVYwNHdTV2wzUzBsRFFRb2dJR2xSTTBwc1dWaAog
  IFNiRnBEU1RaSlEwbDVUVVJKZDB4VVJYZE1WRWw2VmtSRk1VOXFSVFJQYWxWNl
  YybEtPU0o5TEFvZ0lDQWdJCiAgQ0FpWlhkdlowbERTbEZqYlRsdFlWZDRiRkpI
  VmpKaFYwNXNTV3B2WjJWM2IyZEpRMEZuU1d4Q2VXSXlXZ28KICBnSUhCaVIxWl
  VZVmRrZFZsWVVqRmpiVlZwVDJsQ04wTnBRV2RKUTBGblNVTktWbHBIV1dsUGFV
  RnBWRlZPVQogIDFWNU1WaFVWVVV3VEZaR1YwMTZTWFJUQ2lBZ1JrSk5WVk13TU
  ZSRVRsTk1WVEZVVjFWRmRGWlZjRmxYYVVsCiAgelEybEJaMGxEUVdkSlEwcFJa
  RmRLYzJGWFRsRlpXRXBvWWxkV01GcFlTbnBKYW04S0lDQm5aWGR2WjBsRFEKIC
  BXZEpRMEZuU1VOS1VXUlhTbk5oVjA1TVdsaHNSbEV3VWtsSmFtOW5aWGR2WjBs
  RFFXZEpRMEZuU1VOQlowbAogIHRUbmxrYVVrMlNRb2dJRU5LUmxwRVVUQlBRMG
  x6UTJsQlowbERRV2RKUTBGblNVTkJhVlZJVm1saVIyeHFTCiAgV3B2WjBscmVE
  WmtSRTU0WWxSa1dXVklSazlsU0VsM1YyeGtDaUFnUTFSWVdUSlZlbEo0WkZSYV
  ZsVlhWa0oKICBsVlVaWVUwVm9kRTFXUmxWVlYyZ3dVV3Q0UkdWc2NIQmhhMmh6
  VWpKblMwbERRblJZTWpWTFRXMTBkMVFLSQogIENCWVFsSlVWa1pyVlRKNFpsSn
  VSVEpWUjNCdVVqQkZhV1pZTVRsTVFXOW5TVU5CWjBsclNtaGpNbFpHWW0xCiAg
  T2VXVllRakJoVnpsMVNXcHZaMlYzYndvZ0lHZEpRMEZuU1VOQmFWWlhVbTFKYW
  05blNXc3hSRlpHWTNSVWEKICAxWkRWRU14VlU1c2NFeE1Wa0pJVkVWcmRFNHdV
  a3RTUXpBeVZqQkdRMHhWZEZsT0NpQWdNV05wVEVGdlowbAogIERRV2RKUTBGcF
  ZVaFdhV0pIYkdwVlIwWjVXVmN4YkdSSFZubGplVWsyU1VoelMwbERRV2RKUTBG
  blNVTkJhCiAgVlZJVm1saVIyd0tJQ0JxVXpKV05WSlZUa1ZUUTBrMlNVaHpTMG
  xEUVdkSlEwRm5TVU5CWjBsRFNtcGpibGwKICBwVDJsQmFWZEVVVEJQUTBselEy
  bEJaMGxEUVdkSlEwRm5TUW9nSUVOQmFWVklWbWxpUjJ4cVNXcHZaMGxzVAogIG
  tWV1ZscFFZVWhPVTJOdVVubFVNbVJJWVcxV1NVNUdVa3RoTVVZeVRrWndjbEV3
  VWtkVldHeElWVE5PQ2lBCiAgZ2IxTXljRFJTYmxaSlZteHJNV1ZWTlZGbGFtUT
  BZVEpyUzBsRFFqVmlhMG8wVmtNeFVGZERNV3RXYkdONVQKICBtcG9XbFpWZEZw
  VlIzQnNXakJGYVdZS0lDQllNVGxNUVc5blNVTkJaMGxyU21oak1sWkNaRmhTYj
  FwWE5UQgogIGhWMDVvWkVkc2RtSnBTVFpKU0hOTFNVTkJaMGxEUVdkSmJGWnJX
  bWxKTmtsRFNnb2dJRTVSYTJSRlRGVjBUCiAgRlpHWTNSU1JXeGhWMmt3TTFKcl
  JscE1WVnBUVFRBd2RGZHNUa3hTVXpBeVRsUlpla2xwZDB0SlEwRm5TVU4KICBC
  WjBsc1FqRlpDaUFnYlhod1dURkNhR050Um5SYVdGSnNZMjVOYVU5cFFqZERhVU
  ZuU1VOQlowbERRV2RKYgogIEVJeFdXMTRjRmt3ZEd4bFZWWkVVa1ZuYVU5cFFq
  ZERhVUVLSUNCblNVTkJaMGxEUVdkSlEwRnBXVE5LTWtsCiAgcWIyZEpiR2N3VG
  tSbmFVeEJiMmRKUTBGblNVTkJaMGxEUVdkSmJFSXhXVzE0Y0ZsNVNUWkpRMGsw
  VWdvZ0kKICBHMW5lR0ZWTUROYWJFVjRaVU14YWxJeFdubGtSMVUxVkd0NFEySk
  ZkRWhoVlhRd1pERkNiMDlWZUZkUFZFcAogIE9Zekk1ZGxWcVFuQlZiRVpIVjFS
  c0NpQWdWV015T1RGRGFVRm5ZakZvYkZreFFtdFRiV3hTVmtkd1Mxb3diCiAgM2
  xOYmtwTlYxUk5NbVJ0UmtKSmJqRTVabE4zUzBsRFFXZEpRMHBEV1ZoT2JGVUtJ
  Q0F5Ykc1aWJVWXdaRmgKICBLYkVscWIyZGxkMjluU1VOQlowbERRV2xXVjFKdF
  NXcHZaMGxyTVVOU1ZGbDBVVlpHUWxWRE1VeFNSRXBOVAogIEZWa1ZWSnJTUW9n
  SUhSV2EzUkdVbWt4VlZORVRreE1WRXBSVGpCTmFVeEJiMmRKUTBGblNVTkJhVl
  ZJVm1sCiAgaVIyeHFWVWRHZVZsWE1XeGtSMVo1WTNsSk5rbEljMHRKQ2lBZ1Ew
  Rm5TVU5CWjBsRFFXbFZTRlpwWWtkc2EKICBsTXlWalZTVlU1RlUwTkpOa2xJYz
  B0SlEwRm5TVU5CWjBsRFFXZEpRMHBxWTI1WmFVOXBRV2xTVjFFS0lDQQogIHdU
  a1JuYVV4QmIyZEpRMEZuU1VOQlowbERRV2RKYkVJeFdXMTRjRmw1U1RaSlEwcD
  JUMFUwZW1OdVpHNVdWCiAgRVpxVkVkWmQxVjZaSEZVUjJjMFV3b2dJRlYwYzFs
  WWFFSmlSM2hIV1RCb1IxTXdNWEJTVjBad1lsaHNRMXAKICBWV2s1VmJXczFWVz
  EwUW1OdGRFdERhVUZuV25wS2ExRXhhRkJTYmtwV1RucENDaUFnUWsxSWJFUlVS
  bWhyWQogIFZWYVRtRXdaRUpKYmpFNVpsZ3hPU0lzQ2lBZ0lDQWdJSHNLSUNBZ0
  lDQWdJQ0FpYzJsbmJtRjBkWEpsY3lJCiAgNklGdDdDaUFnSUNBZ0lDQWdJQ0Fn
  SUNKaGJHY2lPaUFpVXpVeE1pSXNDaUFnSUNBZ0lDQWdJQ0FnSUNKcmEKICBXUW
  lPaUFpVFVOU1V5MVhUVUUwTFZGV016SXRTRkJNVVMwMFRETlNMVTFUV1VFdFZV
  cFlXaUlzQ2lBZ0lDQQogIGdJQ0FnSUNBZ0lDSnphV2R1WVhSMWNtVWlPaUFpTU
  V0S056TkVia04xYlcxUGFtOU9RakYxVERWeWVqSTNXCiAgVXd0T0dkdlVqaGhN
  a1ZzWVdoSWIzQTBkbXRZU0hGQlRBb2dJRzlwVkhkUFVrUk1YMlpmVkVWMVFYTl
  BRMDUKICAyV2poNU9FWXRRWFZUYUVsUWMyWXhibFJEV0VKWVpVWm9XRFZOWlRJ
  M1pDMUtSMEZ3UjNOdVIxTTNDaUFnTgogIFU1aVlXcDBNUzFyYlZFdFYzQktVVm
  hCV2xOTFRtbG9TbUZRU1UxVGRXMVdkalZMWHpWQ1FVRWlmVjBzQ2lBCiAgZ0lD
  QWdJQ0FnSWxCaGVXeHZZV1JFYVdkbGMzUWlPaUFpYUhoR1IwMXRTSEI2VUVsSV
  dtbFJabWRhYTFjd2QKICBWQXdZM2RqTlRsWVozbEtjV2RVTlVkSFJtcEZSbFU0
  Q2lBZ05XVXpTakJ4UzI1RVVUZFZka1JZU20xcWJqSgogIEtjaTFsWWsxVFFuWk
  hTak4yTTNkWlluTmtNR2NpZlYwc0NpQWdJQ0FpUTJ4cFpXNTBUbTl1WTJVaU9p
  QWlSCiAgRmw1VTFSU1IyaFNPVTFvZG5kVGVUQTNWRVpOZHlJc0NpQWdJQ0FpUV
  dOamIzVnVkRUZrWkhKbGMzTWlPaUEKICBpWVd4cFkyVkFaWGhoYlhCc1pTNWpi
  MjBpZlgwIl0sCiAgICAiU2VydmVyTm9uY2UiOiAiWTZpaXppT3YwYThCLTVNSG
  Qyc250QSIsCiAgICAiV2l0bmVzcyI6ICJBWlFWLU5BM1ctRFRMNi02RjZaLVoy
  S1gtVVU0SS1PUEM0In19",
        {}],
      "AccountAddress": "alice@example.com"}}}
</div>
~~~~



