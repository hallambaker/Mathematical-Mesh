

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
<cmd>Alice> device accept NCGP-WWTX-4HDR-YR2I-N5DO-TYBJ-C4X7
<rsp></div>
~~~~

Specifying the /json option returns a result of type ResultConnectProcess:

~~~~
<div="terminal">
<cmd>Alice> device accept NCGP-WWTX-4HDR-YR2I-N5DO-TYBJ-C4X7 /json
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
<cmd>Alice> device accept NCGP-WWTX-4HDR-YR2I-N5DO-TYBJ-C4X7
<rsp></div>
~~~~

Specifying the /json option returns a result of type ResultConnectProcess:

~~~~
<div="terminal">
<cmd>Alice> device accept NCGP-WWTX-4HDR-YR2I-N5DO-TYBJ-C4X7 /json
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
<cmd>Alice> device delete NCGP-WWTX-4HDR-YR2I-N5DO-TYBJ-C4X7
<rsp>ERROR - The feature has not been implemented
</div>
~~~~

Specifying the /json option returns a result of type Result:

~~~~
<div="terminal">
<cmd>Alice> device delete NCGP-WWTX-4HDR-YR2I-N5DO-TYBJ-C4X7 /json
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
<cmd>Alice> device earl udf://example.com/ECQ4-KEU2-LRMG-UUUP-FGJ2-SZTP-WF4V-XE
<rsp>ERROR - Object reference not set to an instance of an object.
</div>
~~~~

Specifying the /json option returns a result of type Result:

~~~~
<div="terminal">
<cmd>Alice> device earl udf://example.com/ECQ4-KEU2-LRMG-UUUP-FGJ2-SZTP-WF4V-XE /json
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
        "MessageID": "NCGP-WWTX-4HDR-YR2I-N5DO-TYBJ-C4X7",
        "EnvelopedRequestConnection": [{
            "dig": "SHA2"},
          "ewogICJSZXF1ZXN0Q29ubmVjdGlvbiI6IHsKICAgICJTZXJ2aWNlSUQ
  iOiAiYWxpY2VAZXhhbXBsZS5jb20iLAogICAgIkVudmVsb3BlZFByb2ZpbGVEZ
  XZpY2UiOiBbewogICAgICAgICJkaWciOiAiU0hBMiJ9LAogICAgICAiZXdvZ0l
  DSlFjbTltYVd4bFJHVjJhV05sSWpvZ2V3b2dJQ0FnSWt0bGVVOW1abXhwYm1WV
  GFXZAogIHVZWFIxY21VaU9pQjdDaUFnSUNBZ0lDSlZSRVlpT2lBaVRVUllWaTF
  XUzBjMUxWSlpVVWN0VEV3MFFTMVpVCiAgMWxTTFVnMFdGZ3RVak5DUnlJc0NpQ
  WdJQ0FnSUNKUWRXSnNhV05RWVhKaGJXVjBaWEp6SWpvZ2V3b2dJQ0EKICBnSUN
  BZ0lDSlFkV0pzYVdOTFpYbEZRMFJJSWpvZ2V3b2dJQ0FnSUNBZ0lDQWdJbU55Z
  GlJNklDSkZaRFEwTwogIENJc0NpQWdJQ0FnSUNBZ0lDQWlVSFZpYkdsaklqb2d
  JbGhVUmpWNWRucG1ZblZDZWpkUVkxVnNWSGMxU0d3CiAgM2NFaEZiVWxqUzFSS
  lpIWkpSbFJNVnpWaVZYSklabkV0UlhoaVNGSUtJQ0JwUjJOWVJ6azJOR2hUVlV
  0Q2IKICBUaERUbHBVTFZaR2NVRWlmWDE5TEFvZ0lDQWdJa3RsZVVWdVkzSjVjS
  FJwYjI0aU9pQjdDaUFnSUNBZ0lDSgogIFZSRVlpT2lBaVRVRkNXQzFHVVVvekx
  USlNVRm90Vms5R055MUVXazQyTFRSS04xZ3RWMUZHV2lJc0NpQWdJCiAgQ0FnS
  UNKUWRXSnNhV05RWVhKaGJXVjBaWEp6SWpvZ2V3b2dJQ0FnSUNBZ0lDSlFkV0p
  zYVdOTFpYbEZRMFIKICBJSWpvZ2V3b2dJQ0FnSUNBZ0lDQWdJbU55ZGlJNklDS
  kZaRFEwT0NJc0NpQWdJQ0FnSUNBZ0lDQWlVSFZpYgogIEdsaklqb2dJazl2YUd
  sUmMxVmtjV2wzY1ZWV1RtbFlSemRuWDFwamVUVmZiV3hSVFVkUlZuQXpYMVZYV
  2psCiAgQ2VGQlpaa1puYlhsSlRHd0tJQ0JDYVZOVlNWOXhjMDAwVEVaUlRrUXh
  PREozWWxkTlkwRWlmWDE5TEFvZ0kKICBDQWdJa3RsZVVGMWRHaGxiblJwWTJGM
  GFXOXVJam9nZXdvZ0lDQWdJQ0FpVlVSR0lqb2dJazFDTWtRdFJsRgogIEVSUzF
  EU2tnMExVbE1TVE10UVZvelJDMUpOamRDTFZCV05sTWlMQW9nSUNBZ0lDQWlVS
  FZpYkdsalVHRnlZCiAgVzFsZEdWeWN5STZJSHNLSUNBZ0lDQWdJQ0FpVUhWaWJ
  HbGpTMlY1UlVORVNDSTZJSHNLSUNBZ0lDQWdJQ0EKICBnSUNKamNuWWlPaUFpU
  ldRME5EZ2lMQW9nSUNBZ0lDQWdJQ0FnSWxCMVlteHBZeUk2SUNKWExUQlZTVVJ
  ETQogIFhRNWJtaERXRFJZWWkxUWEwWm1ZMVJCWVZScVRrMDBaV2gwTmpOWU1XR
  k5ZVFJpYUhCelRISnVNVFpxQ2lBCiAgZ1kxQkxTMVJrVjJ0clNqUlZaRlIwWlV
  jdE5rTjFiVUZCSW4xOWZYMTkiLAogICAgICB7CiAgICAgICAgInNpZ25hdHVyZ
  XMiOiBbewogICAgICAgICAgICAiYWxnIjogIlNIQTIiLAogICAgICAgICAgICA
  ia2lkIjogIk1EWFYtVktHNS1SWVFHLUxMNEEtWVNZUi1INFhYLVIzQkciLAogI
  CAgICAgICAgICAic2lnbmF0dXJlIjogIkNObXg5TmQyU2dSN1piYmdHQUtmMlQ
  4d0NyQWpTMkpyeWFqNzd0MDJpMF9hbUNSOWEKICA2clhfMzBPMV9vbWswRGhCU
  zc1YnNITDNXaUFPLUYxUkkxbFYzWTBEdnhzQmF1TEk0ZHZwVWloM1c2Mm1nUgo
  gIE1MamN2WmZlU2FDckNZNUtobTBINXlDSm8tNnpzbWZhMi1uY0dPQllBIn1dL
  AogICAgICAgICJQYXlsb2FkRGlnZXN0IjogIk5mQzZOcHBZQUpVbnNaZ0RTYjV
  hdGRUdXdnejFPWklZSGRXcGJsWHF0ZDh0bAogIGptTERkdGs4YTluR3E5dTdTa
  lAwVDgxem5BR2ZFbTdKX2pqTVBzakJBIn1dLAogICAgIkNsaWVudE5vbmNlIjo
  gIm1oUlgwR0plTjVxZlFtMjg1eEgwemcifX0",
          {
            "signatures": [{
                "alg": "SHA2",
                "kid": "MB2D-FQDE-CJH4-ILI3-AZ3D-I67B-PV6S",
                "signature": "1itmyoLWYuW-_XFI8_vViHS1vOYdesDgtZePG-9QNu83v9rsf
  lErxeiR23E4eKeyGQXWov7wNusAshmTWtxa8n9XV1KV6KoJb9pH2u7m2YqfmOQ
  QX2xWJ4bUBil0Uiqu-dBETCZd0prfJHnc2Y3mFxkA"}],
            "PayloadDigest": "efTAFfIezfnQKOSjBGx-Y4wbdZuss-4VThNjM0mjelXZu
  ND7Voi3EhhHCFDx0gD43FpKuSSGKE9OccHFxXy3TQ"}],
        "ServerNonce": "NpDi97ddXGcitELaAg-k2Q",
        "Witness": "2A6B-7LBB-DLYR-LA4Y-ZGMF-D4Z5-UP42"},
      {
        "MessageID": "NAJK-KX55-GHUE-JZPZ-Q5N7-QMGD-SEUH",
        "EnvelopedRequestConnection": [{
            "dig": "SHA2"},
          "ewogICJSZXF1ZXN0Q29ubmVjdGlvbiI6IHsKICAgICJTZXJ2aWNlSUQ
  iOiAiYWxpY2VAZXhhbXBsZS5jb20iLAogICAgIkVudmVsb3BlZFByb2ZpbGVEZ
  XZpY2UiOiBbewogICAgICAgICJkaWciOiAiU0hBMiJ9LAogICAgICAiZXdvZ0l
  DSlFjbTltYVd4bFJHVjJhV05sSWpvZ2V3b2dJQ0FnSWt0bGVVOW1abXhwYm1WV
  GFXZAogIHVZWFIxY21VaU9pQjdDaUFnSUNBZ0lDSlZSRVlpT2lBaVRVUTNOUzF
  GUkV0SExVeElUakl0VEZaUFRpMU1RCiAgMVZMTFRaWFdGQXRRVUpHVHlJc0NpQ
  WdJQ0FnSUNKUWRXSnNhV05RWVhKaGJXVjBaWEp6SWpvZ2V3b2dJQ0EKICBnSUN
  BZ0lDSlFkV0pzYVdOTFpYbEZRMFJJSWpvZ2V3b2dJQ0FnSUNBZ0lDQWdJbU55Z
  GlJNklDSkZaRFEwTwogIENJc0NpQWdJQ0FnSUNBZ0lDQWlVSFZpYkdsaklqb2d
  JbU5qUldWUVVuaGtVSFpEVVhsa1FWWnNjWFF5VEdGCiAgRFNIQkNVVFkzWTNCa
  1pHNTZVRVZvUjBsQlZ6Y3hVVFZvTmxsM04yMEtJQ0JtWVhGVmMydFhOM1ZzWTB
  OSEwKICBUTmhjMDAwU2xsb01rRWlmWDE5TEFvZ0lDQWdJa3RsZVVWdVkzSjVjS
  FJwYjI0aU9pQjdDaUFnSUNBZ0lDSgogIFZSRVlpT2lBaVRVUkNVaTAxUzFwSkx
  WTkVTa2t0UkZVM01pMUpWMWxRTFZCUlVFY3RTbEpETlNJc0NpQWdJCiAgQ0FnS
  UNKUWRXSnNhV05RWVhKaGJXVjBaWEp6SWpvZ2V3b2dJQ0FnSUNBZ0lDSlFkV0p
  zYVdOTFpYbEZRMFIKICBJSWpvZ2V3b2dJQ0FnSUNBZ0lDQWdJbU55ZGlJNklDS
  kZaRFEwT0NJc0NpQWdJQ0FnSUNBZ0lDQWlVSFZpYgogIEdsaklqb2dJbWxUY1R
  GdlFXVlVaRWhOVmxaUlV6Rk5hbTF4UVVWTk5GTmZSVk54T1hWTVlsTk5NRmhyW
  kRCCiAgWFJIbElRbWRRWkhsdmVrZ0tJQ0JGYldWTFgwbEJSV1p6UjB4U1dTMW1
  SM3A0VlVzelpVRWlmWDE5TEFvZ0kKICBDQWdJa3RsZVVGMWRHaGxiblJwWTJGM
  GFXOXVJam9nZXdvZ0lDQWdJQ0FpVlVSR0lqb2dJazFDUlZNdE4wMQogIEVWaTF
  MTjA1RkxUZENVMEl0VmxOQ1RpMU9NbFUzTFZSUVZrWWlMQW9nSUNBZ0lDQWlVS
  FZpYkdsalVHRnlZCiAgVzFsZEdWeWN5STZJSHNLSUNBZ0lDQWdJQ0FpVUhWaWJ
  HbGpTMlY1UlVORVNDSTZJSHNLSUNBZ0lDQWdJQ0EKICBnSUNKamNuWWlPaUFpU
  ldRME5EZ2lMQW9nSUNBZ0lDQWdJQ0FnSWxCMVlteHBZeUk2SUNKRlJGWm1UekE
  1TQogIEdWaVJVdE9XVzEyUzAwNFExVlFNak51Um5jNFdWVk1lRVUyVEMwMVZYQ
  jVSVFpwZWkxcWNERk9URkUwQ2lBCiAgZ1RGSXdWbTlOTkZGNkxXZG9lR2RTVVd
  KcE4waFZXbU5CSW4xOWZYMTkiLAogICAgICB7CiAgICAgICAgInNpZ25hdHVyZ
  XMiOiBbewogICAgICAgICAgICAiYWxnIjogIlNIQTIiLAogICAgICAgICAgICA
  ia2lkIjogIk1ENzUtRURLRy1MSE4yLUxWT04tTENVSy02V1hQLUFCRk8iLAogI
  CAgICAgICAgICAic2lnbmF0dXJlIjogIlY4QXZpYi1Da2FCOE80U0FZMHJ6Zkt
  rbUZPRnBmWU5raVhjU080b2NmeHRFcjU5S2UKICB6c3gyU04zb2xLS0NQT2pOb
  2piMlJ2TmdubUEzWERFN2VQRi14MFZOUFJrQUVtNm83d1NsZ1JwVTFFeW9SNgo
  gIGM5SmNUQlNIQjdoempxRE9yUG9MSW9rYVY0NV9IaW9KMEdwM0pkUmdBIn1dL
  AogICAgICAgICJQYXlsb2FkRGlnZXN0IjogIk8xOUNhWFRva1N6Vm9JWFRJS3J
  zOXVhTVFhMGhKZnJsZUFkS2p1MXFaM2NycgogIHVkY2xRcjE3Y0tBeUxlQ0ljV
  zJuTWlyeGFiZDU2bnRiWmhOdWRIUXhnIn1dLAogICAgIkNsaWVudE5vbmNlIjo
  gImNucWw0QjNTRFVVTS1ORE9jUVlPTHcifX0",
          {
            "signatures": [{
                "alg": "SHA2",
                "kid": "MBES-7MDV-K7NE-7BSB-VSBN-N2U7-TPVF",
                "signature": "clnBAoTTh_sc3_wu4i4VA0ptny8XIZ4Ii4Af2NKt9Yw_K3Kfc
  Rhxvr2V3jQ7MHHaNeyjBglzLewA7hDmjtZHI4aKnwcGg5vJ_bwrZntF65aF2Yj
  sBYW20HDMhAPBNWSNUyQKtBeJDlWAPKNKdiuC9zUA"}],
            "PayloadDigest": "tRsADnaaZpFi9fm5bTI2YB6UEIbyn0-UbXnSUk7Qx9hHQ
  6b0yRorF5xGyDRhWixz9LRTZosvzAkkgpPRl02NwA"}],
        "ServerNonce": "XI4xrcWdguKBpJKXVtclkA",
        "Witness": "M4J5-YPNB-2O3U-35FZ-PC6G-SP6R-4LBD"}]}}
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
<cmd>Alice> device reject NAJK-KX55-GHUE-JZPZ-Q5N7-QMGD-SEUH
<rsp></div>
~~~~

Specifying the /json option returns a result of type ResultConnectProcess:

~~~~
<div="terminal">
<cmd>Alice> device reject NAJK-KX55-GHUE-JZPZ-Q5N7-QMGD-SEUH /json
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
<cmd>Alice4> device pre devices@example.com /key=udf://example.com/ECQ4-KEU2-LRMG-UUUP-FGJ2-SZTP-WF4V-XE
<rsp>ERROR - Object reference not set to an instance of an object.
</div>
~~~~

Specifying the /json option returns a result of type Result:

~~~~
<div="terminal">
<cmd>Alice4> device pre devices@example.com /key=udf://example.com/ECQ4-KEU2-LRMG-UUUP-FGJ2-SZTP-WF4V-XE /json
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
<rsp>   Witness value = M4J5-YPNB-2O3U-35FZ-PC6G-SP6R-4LBD
   Personal Mesh = MDKD-XTUR-GFP4-QD52-STNB-Q7GS-MEWW
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
      "ID": "MD75-EDKG-LHN2-LVON-LCUK-6WXP-ABFO",
      "EnvelopedProfileMaster": [{},
        "ewogICJQcm9maWxlTWVzaCI6IHsKICAgICJL
  ZXlPZmZsaW5lU2lnbmF0dXJlIjogewogICAgICAiVURGIjogIk1ES0QtWFRVUi
  1HRlA0LVFENTItU1ROQi1RN0dTLU1FV1ciLAogICAgICAiUHVibGljUGFyYW1l
  dGVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgIC
  JjcnYiOiAiRWQ0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJZLUVZOVI0Xy1t
  R0h2SFVFSjQ4bFl0clViM3BFOTZWaWZ4SmVoRjZkWlFOWlJjMDdFR29XCiAgSW
  RrZjdqMXotMG82ZURDLVgtckJiVkNBIn19fSwKICAgICJLZXlzT25saW5lU2ln
  bmF0dXJlIjogW3sKICAgICAgICAiVURGIjogIk1BNkEtNUpFQS03UFJOLUhIRz
  YtR0NMUi1DWUhTLURSQUkiLAogICAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjog
  ewogICAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAgICJjcn
  YiOiAiRWQ0NDgiLAogICAgICAgICAgICAiUHVibGljIjogIlJkWGwweEJ4SFR0
  cnpaejRvRzRDSVlXN3RnVFMtcDRWeFZ2UmxkLXkwQVpzZ0VBNS1yLWkKICBuZG
  xTVVNlWGM3WkxhR0Z5TGl3U3IwcUEifX19XSwKICAgICJLZXlFbmNyeXB0aW9u
  IjogewogICAgICAiVURGIjogIk1ES0QtWFRVUi1HRlA0LVFENTItU1ROQi1RN0
  dTLU1FV1ciLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAi
  UHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogIC
  AgICAgICAgIlB1YmxpYyI6ICJZLUVZOVI0Xy1tR0h2SFVFSjQ4bFl0clViM3BF
  OTZWaWZ4SmVoRjZkWlFOWlJjMDdFR29XCiAgSWRrZjdqMXotMG82ZURDLVgtck
  JiVkNBIn19fX19"],
      "DeviceUDF": "MD75-EDKG-LHN2-LVON-LCUK-6WXP-ABFO",
      "EnvelopedProfileDevice": [{
          "dig": "SHA2"},
        "ewogICJQcm9maWxlRGV2aWNlIjogewogICAgIktleU9mZmxpbmVTaWd
  uYXR1cmUiOiB7CiAgICAgICJVREYiOiAiTUQ3NS1FREtHLUxITjItTFZPTi1MQ
  1VLLTZXWFAtQUJGTyIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICA
  gICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJFZDQ0O
  CIsCiAgICAgICAgICAiUHVibGljIjogImNjRWVQUnhkUHZDUXlkQVZscXQyTGF
  DSHBCUTY3Y3BkZG56UEVoR0lBVzcxUTVoNll3N20KICBmYXFVc2tXN3VsY0NHL
  TNhc000SlloMkEifX19LAogICAgIktleUVuY3J5cHRpb24iOiB7CiAgICAgICJ
  VREYiOiAiTURCUi01S1pJLVNESkktRFU3Mi1JV1lQLVBRUEctSlJDNSIsCiAgI
  CAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJsaWNLZXlFQ0R
  IIjogewogICAgICAgICAgImNydiI6ICJFZDQ0OCIsCiAgICAgICAgICAiUHVib
  GljIjogImlTcTFvQWVUZEhNVlZRUzFNam1xQUVNNFNfRVNxOXVMYlNNMFhrZDB
  XRHlIQmdQZHlvekgKICBFbWVLX0lBRWZzR0xSWS1mR3p4VUszZUEifX19LAogI
  CAgIktleUF1dGhlbnRpY2F0aW9uIjogewogICAgICAiVURGIjogIk1CRVMtN01
  EVi1LN05FLTdCU0ItVlNCTi1OMlU3LVRQVkYiLAogICAgICAiUHVibGljUGFyY
  W1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICA
  gICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJFRFZmTzA5M
  GViRUtOWW12S004Q1VQMjNuRnc4WVVMeEU2TC01VXB5RTZpei1qcDFOTFE0CiA
  gTFIwVm9NNFF6LWdoeGdSUWJpN0hVWmNBIn19fX19",
        {
          "signatures": [{
              "alg": "SHA2",
              "kid": "MD75-EDKG-LHN2-LVON-LCUK-6WXP-ABFO",
              "signature": "V8Avib-CkaB8O4SAY0rzfKkmFOFpfYNkiXcSO4ocfxtEr59Ke
  zsx2SN3olKKCPOjNojb2RvNgnmA3XDE7ePF-x0VNPRkAEm6o7wSlgRpU1EyoR6
  c9JcTBSHB7hzjqDOrPoLIokaV45_HioJ0Gp3JdRgA"}],
          "PayloadDigest": "O19CaXTokSzVoIXTIKrs9uaMQa0hJfrleAdKju1qZ3crr
  udclQr17cKAyLeCIcW2nMirxabd56ntbZhNudHQxg"}],
      "EnvelopedMessageConnectionResponse": [{
          "ContentMetaData": "ewogICJVbmlxdWVJRCI6ICJOQVdILUtKU1ctMkFMUi1
  HTzU1LUhESkQtWkZZTy1UTzJRIiwKICAiTWVzc2FnZVR5cGUiOiAiQWNrbm93b
  GVkZ2VDb25uZWN0aW9uIn0"},
        "ewogICJBY2tub3dsZWRnZUNvbm5lY3Rpb24iOiB7CiA
  gICAiTWVzc2FnZUlEIjogIk5BSkstS1g1NS1HSFVFLUpaUFotUTVONy1RTUdEL
  VNFVUgiLAogICAgIkVudmVsb3BlZFJlcXVlc3RDb25uZWN0aW9uIjogW3sKICA
  gICAgICAiZGlnIjogIlNIQTIifSwKICAgICAgImV3b2dJQ0pTWlhGMVpYTjBRM
  jl1Ym1WamRHbHZiaUk2SUhzS0lDQWdJQ0pUWlhKMmFXTmxTVVEKICBpT2lBaVl
  XeHBZMlZBWlhoaGJYQnNaUzVqYjIwaUxBb2dJQ0FnSWtWdWRtVnNiM0JsWkZCe
  WIyWnBiR1ZFWgogIFhacFkyVWlPaUJiZXdvZ0lDQWdJQ0FnSUNKa2FXY2lPaUF
  pVTBoQk1pSjlMQW9nSUNBZ0lDQWlaWGR2WjBsCiAgRFNsRmpiVGx0WVZkNGJGS
  khWakpoVjA1c1NXcHZaMlYzYjJkSlEwRm5TV3QwYkdWVk9XMWFiWGh3WW0xV1Y
  KICBHRlhaQW9nSUhWWldGSXhZMjFWYVU5cFFqZERhVUZuU1VOQlowbERTbFpTU
  lZscFQybEJhVlJWVVROT1V6RgogIEdVa1YwU0V4VmVFbFVha2wwVkVaYVVGUnB
  NVTFSQ2lBZ01WWk1URlJhV0ZkR1FYUlJWVXBIVkhsSmMwTnBRCiAgV2RKUTBGb
  lNVTktVV1JYU25OaFYwNVJXVmhLYUdKWFZqQmFXRXA2U1dwdloyVjNiMmRKUTB
  FS0lDQm5TVU4KICBCWjBsRFNsRmtWMHB6WVZkT1RGcFliRVpSTUZKSlNXcHZaM
  lYzYjJkSlEwRm5TVU5CWjBsRFFXZEpiVTU1WgogIEdsSk5rbERTa1phUkZFd1R
  3b2dJRU5KYzBOcFFXZEpRMEZuU1VOQlowbERRV2xWU0ZacFlrZHNha2xxYjJkC
  iAgSmJVNXFVbGRXVVZWdWFHdFZTRnBFVlZoc2ExRldXbk5qV0ZGNVZFZEdDaUF
  nUkZOSVFrTlZWRmt6V1ROQ2EKICAxcEhOVFpWUlZadlVqQnNRbFo2WTNoVlZGW
  nZUbXhzTTA0eU1FdEpRMEp0V1ZoR1ZtTXlkRmhPTTFaeldUQgogIE9TRXdLSUN
  CVVRtaGpNREF3VTJ4c2IwMXJSV2xtV0RFNVRFRnZaMGxEUVdkSmEzUnNaVlZXZ
  FZrelNqVmpTCiAgRkp3WWpJMGFVOXBRamREYVVGblNVTkJaMGxEU2dvZ0lGWlN
  SVmxwVDJsQmFWUlZVa05WYVRBeFV6RndTa3gKICBXVGtWVGEydDBVa1pWTTAxc
  E1VcFdNV3hSVEZaQ1VsVkZZM1JUYkVwRVRsTkpjME5wUVdkSkNpQWdRMEZuUwo
  gIFVOS1VXUlhTbk5oVjA1UldWaEthR0pYVmpCYVdFcDZTV3B2WjJWM2IyZEpRM
  EZuU1VOQlowbERTbEZrVjBwCiAgellWZE9URnBZYkVaUk1GSUtJQ0JKU1dwdlo
  yVjNiMmRKUTBGblNVTkJaMGxEUVdkSmJVNTVaR2xKTmtsRFMKICBrWmFSRkV3V
  DBOSmMwTnBRV2RKUTBGblNVTkJaMGxEUVdsVlNGWnBZZ29nSUVkc2FrbHFiMmR
  KYld4VVkxUgogIEdkbEZYVmxWYVJXaE9WbXhhVWxWNlJrNWhiVEY0VVZWV1RrN
  UdUbVpTVms1NFQxaFdUVmxzVGs1TlJtaHlXCiAga1JDQ2lBZ1dGSkliRWxSYld
  SUldraHNkbVZyWjB0SlEwSkdZbGRXVEZnd2JFSlNWMXA2VWpCNFUxZFRNVzEKI
  CBTTTNBMFZsVnplbHBWUldsbVdERTVURUZ2WjBrS0lDQkRRV2RKYTNSc1pWVkd
  NV1JIYUd4aWJsSndXVEpHTQogIEdGWE9YVkphbTluWlhkdlowbERRV2RKUTBGc
  FZsVlNSMGxxYjJkSmF6RkRVbFpOZEU0d01Rb2dJRVZXYVRGCiAgTVRqQTFSa3h
  VWkVOVk1FbDBWbXhPUTFScE1VOU5iRlV6VEZaU1VWWnJXV2xNUVc5blNVTkJaM
  GxEUVdsVlMKICBGWnBZa2RzYWxWSFJubFpDaUFnVnpGc1pFZFdlV041U1RaSlN
  ITkxTVU5CWjBsRFFXZEpRMEZwVlVoV2FXSgogIEhiR3BUTWxZMVVsVk9SVk5EU
  1RaSlNITkxTVU5CWjBsRFFXZEpRMEVLSUNCblNVTkthbU51V1dsUGFVRnBVCiA
  gbGRSTUU1RVoybE1RVzluU1VOQlowbERRV2RKUTBGblNXeENNVmx0ZUhCWmVVa
  zJTVU5LUmxKR1dtMVVla0UKICAxVFFvZ0lFZFdhVkpWZEU5WFZ6RXlVekF3TkZ
  FeFZsRk5hazUxVW01ak5GZFdWazFsUlZVeVZFTXdNVlpZUQogIGpWU1ZGcHdaV
  2t4Y1dORVJrOVVSa1V3UTJsQkNpQWdaMVJHU1hkV2JUbE9Ua1pHTmt4WFpHOWx
  SMlJUVlZkCiAgS2NFNHdhRlpYYlU1Q1NXNHhPV1pZTVRraUxBb2dJQ0FnSUNCN
  0NpQWdJQ0FnSUNBZ0luTnBaMjVoZEhWeVoKICBYTWlPaUJiZXdvZ0lDQWdJQ0F
  nSUNBZ0lDQWlZV3huSWpvZ0lsTklRVElpTEFvZ0lDQWdJQ0FnSUNBZ0lDQQogI
  GlhMmxrSWpvZ0lrMUVOelV0UlVSTFJ5MU1TRTR5TFV4V1QwNHRURU5WU3kwMlY
  xaFFMVUZDUms4aUxBb2dJCiAgQ0FnSUNBZ0lDQWdJQ0FpYzJsbmJtRjBkWEpsS
  WpvZ0lsWTRRWFpwWWkxRGEyRkNPRTgwVTBGWk1ISjZaa3QKICByYlVaUFJuQm1
  XVTVyYVZoalUwODBiMk5tZUhSRmNqVTVTMlVLSUNCNmMzZ3lVMDR6YjJ4TFMwT
  lFUMnBPYgogIDJwaU1sSjJUbWR1YlVFeldFUkZOMlZRUmkxNE1GWk9VRkpyUVV
  WdE5tODNkMU5zWjFKd1ZURkZlVzlTTmdvCiAgZ0lHTTVTbU5VUWxOSVFqZG9lb
  XB4UkU5eVVHOU1TVzlyWVZZME5WOUlhVzlLTUVkd00wcGtVbWRCSW4xZEwKICB
  Bb2dJQ0FnSUNBZ0lDSlFZWGxzYjJGa1JHbG5aWE4wSWpvZ0lrOHhPVU5oV0ZSd
  mExTjZWbTlKV0ZSSlMzSgogIHpPWFZoVFZGaE1HaEtabkpzWlVGa1MycDFNWEZ
  hTTJOeWNnb2dJSFZrWTJ4UmNqRTNZMHRCZVV4bFEwbGpWCiAgekp1VFdseWVHR
  mlaRFUyYm5SaVdtaE9kV1JJVVhobkluMWRMQW9nSUNBZ0lrTnNhV1Z1ZEU1dmJ
  tTmxJam8KICBnSW1OdWNXdzBRak5UUkZWVlRTMU9SRTlqVVZsUFRIY2lmWDAiL
  AogICAgICB7CiAgICAgICAgInNpZ25hdHVyZXMiOiBbewogICAgICAgICAgICA
  iYWxnIjogIlNIQTIiLAogICAgICAgICAgICAia2lkIjogIk1CRVMtN01EVi1LN
  05FLTdCU0ItVlNCTi1OMlU3LVRQVkYiLAogICAgICAgICAgICAic2lnbmF0dXJ
  lIjogImNsbkJBb1RUaF9zYzNfd3U0aTRWQTBwdG55OFhJWjRJaTRBZjJOS3Q5W
  XdfSzNLZmMKICBSaHh2cjJWM2pRN01ISGFOZXlqQmdsekxld0E3aERtanRaSEk
  0YUtud2NHZzV2Sl9id3JabnRGNjVhRjJZagogIHNCWVcyMEhETWhBUEJOV1NOV
  XlRS3RCZUpEbFdBUEtOS2RpdUM5elVBIn1dLAogICAgICAgICJQYXlsb2FkRGl
  nZXN0IjogInRSc0FEbmFhWnBGaTlmbTViVEkyWUI2VUVJYnluMC1VYlhuU1VrN
  1F4OWhIUQogIDZiMHlSb3JGNXhHeURSaFdpeHo5TFJUWm9zdnpBa2tncFBSbDA
  yTndBIn1dLAogICAgIlNlcnZlck5vbmNlIjogIlhJNHhyY1dkZ3VLQnBKS1hWd
  GNsa0EiLAogICAgIldpdG5lc3MiOiAiTTRKNS1ZUE5CLTJPM1UtMzVGWi1QQzZ
  HLVNQNlItNExCRCJ9fQ"],
      "EnvelopedAccountAssertion": [{
          "dig": "SHA2"},
        "ewogICJQcm9maWxlQWNjb3VudCI6IHsKICAgICJLZXlPZmZsaW5lU2l
  nbmF0dXJlIjogewogICAgICAiVURGIjogIk1CQUwtNDRZWi1YNEdYLVVTQkwtS
  kFNVS1BVzMyLVNMQlEiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICA
  gICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0N
  DgiLAogICAgICAgICAgIlB1YmxpYyI6ICItUkNVeG5RSWJDb0hnTlJWUU81TEl
  ERFVQQ3JvcjJxLU9MaDFGTlMzQVZ5QnJ3TzNCZWROCiAgYzduWHJOQ01yT1RhZ
  jFNRmUwWk1HcVlBIn19fSwKICAgICJLZXlzT25saW5lU2lnbmF0dXJlIjogW3s
  KICAgICAgICAiVURGIjogIk1BREUtSjNTRS1MT0FNLTdGNjQtU0paSy1CT05FL
  URSUEMiLAogICAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICA
  gIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAgICJjcnYiOiAiRWQ0NDgiL
  AogICAgICAgICAgICAiUHVibGljIjogIndvQW01X1hpVWtFdDA2a1Vpa1R1eGJ
  2QjdPdU1hc0lONDlTMzY0Ykpqc0o2WVMzZ3ZDM1EKICB4eDNxQUZBYVhGTjg0Z
  mNpMllOdklpeUEifX19XSwKICAgICJTZXJ2aWNlSURzIjogWyJhbGljZUBleGF
  tcGxlLmNvbSJdLAogICAgIk1lc2hQcm9maWxlVURGIjogIk1ES0QtWFRVUi1HR
  lA0LVFENTItU1ROQi1RN0dTLU1FV1ciLAogICAgIktleUVuY3J5cHRpb24iOiB
  7CiAgICAgICJVREYiOiAiTUJMUi1KQVNXLUlET1EtRFZIUS1RRjJOLVlQWVUtR
  VI0NiIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJ
  saWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJFZDQ0OCIsCiAgICAgI
  CAgICAiUHVibGljIjogInVnejk4Z3A0X3M4bnRiQ28wdlpxX1pJZU9iV25SNW1
  pZjRiclo5S2FXOXdLUWFjS0RfLWUKICBDcUdBUmg4Q2dLME1Ra0FqaXVXbG82d
  0EifX19fX0",
        {
          "signatures": [{
              "alg": "SHA2",
              "kid": "MA6A-5JEA-7PRN-HHG6-GCLR-CYHS-DRAI",
              "signature": "XOpsadhMHH_5eH8Np42s0_lp49a2Hc1tvspOIyYiHAhxwA0NZ
  VPAw1Mox6kwjfdntb3EyaHnFF2AxLrqI4GvwYjNmcuk2RDW9mCjj7uRZ38_jcX
  --9Ld_MYQucH8lankfDDRUlI6Vbglp_4Oub1oYgIA"}],
          "PayloadDigest": "woWiugDhBt-mBSTPaikozWhXk8oioq4ntulInpK9_cHr8
  vKt3PEX8rW96F5LFCGbNkd3u4Mp8cV9Lis45KJBjg"}]}}}
</div>
~~~~



