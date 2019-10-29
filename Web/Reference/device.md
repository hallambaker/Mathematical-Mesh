

# device

````
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
````

# device accept

````
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
````

Accept a pending connection request.


````
Alice> device accept NAWO-FRYR-JFVG-EBIU-FCOZ-B7KC-KDBY
````

Specifying the /json option returns a result of type ResultConnectProcess:

````
Alice> device accept NAWO-FRYR-JFVG-EBIU-FCOZ-B7KC-KDBY /json
{
  "ResultConnectProcess": {
    "Success": true}}
````

# device auth

````
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
````

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


````
Alice> device auth Alice2 /contact
````

Specifying the /json option returns a result of type ResultAuthorize:

````
Alice> device auth Alice2 /contact /json
{
  "ResultAuthorize": {
    "Success": true}}
````

# device accept

````
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
````

The `device accept` command accepts the specified connection request.

The command must specify the connection identifier of the request 
being accepted. The connection identifier may be abbreviated provided that
this uniquely identifies the connection being accepted and that at least 
four characters are given.

The `/id` option may be used to specify a friendly name for the device.

The authorizations to be granted to the device may be specified using
the same syntax as for the `device auth` command with the default authorization
being that all authorizations are denied.


````
Alice> device accept NAWO-FRYR-JFVG-EBIU-FCOZ-B7KC-KDBY
````

Specifying the /json option returns a result of type ResultConnectProcess:

````
Alice> device accept NAWO-FRYR-JFVG-EBIU-FCOZ-B7KC-KDBY /json
{
  "ResultConnectProcess": {
    "Success": true}}
````

# device delete

````
delete   Remove device from device catalog
       Device identifier
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````

The `device delete` command removes the specified device from the catalog.

The parameter specifies the device being configured by means of either
the UDF of the device profile or the device identifier.


````
Alice> device delete NAWO-FRYR-JFVG-EBIU-FCOZ-B7KC-KDBY
ERROR - The feature has not been implemented
````

Specifying the /json option returns a result of type Result:

````
Alice> device delete NAWO-FRYR-JFVG-EBIU-FCOZ-B7KC-KDBY /json
{
  "Result": {
    "Success": false,
    "Reason": "The feature has not been implemented"}}
````

# device earl

````
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
````

The `device earl` command attempts to connect a device to a personal profile
by means of an EARL UDF.

The EARL is typically presented to the administration device in the form of
a QR code which is decoded and passed to the meshman application.

The `/id` option may be used to specify a friendly name for the device if the
connection attempt succeeds.

The authorizations to be granted to the device may be specified using
the same syntax as for the `device auth` command with the default authorization
being that all authorizations are denied.


````
Alice> device earl udf://example.com/ECVF-M7ZO-BIJT-OVPQ-BAG2-ZDTH-K4JW-EV
ERROR - Object reference not set to an instance of an object.
````

Specifying the /json option returns a result of type Result:

````
Alice> device earl udf://example.com/ECVF-M7ZO-BIJT-OVPQ-BAG2-ZDTH-K4JW-EV /json
{
  "Result": {
    "Success": false,
    "Reason": "Object reference not set to an instance of an object."}}
````

# device list

````
list   List devices in the device catalog
       Recryption group name in user@example.com format
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````

The `device list` command lists the device profiles in the device catalog.


````
Alice> device list
````

Specifying the /json option returns a result of type Result:

````
Alice> device list /json
{
  "Result": {
    "Success": true}}
````

# device pending

````
pending   Get list of pending connection requests
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````

The `device pending` command lists the pending device connection requests in
the inbound message spool.


````
Alice> device pending
````

Specifying the /json option returns a result of type ResultPending:

````
Alice> device pending /json
{
  "ResultPending": {
    "Success": true,
    "Messages": [{
        "MessageID": "NAWO-FRYR-JFVG-EBIU-FCOZ-B7KC-KDBY",
        "EnvelopedRequestConnection": [{
            "dig": "S512"},
          "ewogICJSZXF1ZXN0Q29ubmVjdGlvbiI6IHsKICAgICJTZXJ2aWNlSUQ
  iOiAiYWxpY2VAZXhhbXBsZS5jb20iLAogICAgIkVudmVsb3BlZFByb2ZpbGVEZ
  XZpY2UiOiBbewogICAgICAgICJkaWciOiAiUzUxMiJ9LAogICAgICAiZXdvZ0l
  DSlFjbTltYVd4bFJHVjJhV05sSWpvZ2V3b2dJQ0FnSWt0bGVVOW1abXhwYm1WV
  GFXZAogIHVZWFIxY21VaU9pQjdDaUFnSUNBZ0lDSlZSRVlpT2lBaVRVUlBOaTA
  xV0V0U0xVSktUVkF0VUVOWlRDMUlOCiAgMGRPTFVaR1Zsa3RRME5OUmlJc0NpQ
  WdJQ0FnSUNKUWRXSnNhV05RWVhKaGJXVjBaWEp6SWpvZ2V3b2dJQ0EKICBnSUN
  BZ0lDSlFkV0pzYVdOTFpYbEZRMFJJSWpvZ2V3b2dJQ0FnSUNBZ0lDQWdJbU55Z
  GlJNklDSkZaRFEwTwogIENJc0NpQWdJQ0FnSUNBZ0lDQWlVSFZpYkdsaklqb2d
  JbVptY2pKb0xXNXBSVkZhTWtoU1pqTm1OMjUzT0VVCiAgMlluSTFVa0UwVjJ0S
  GFEVlFkRlJwVDFOblZYcDRVblp0Wm1OcmNtd0tJQ0J0WDJkVmJqbFNYMkZEV0V
  obVcKICBYZ3hTbkJEY1d0a1YwRWlmWDE5TEFvZ0lDQWdJa3RsZVVWdVkzSjVjS
  FJwYjI0aU9pQjdDaUFnSUNBZ0lDSgogIFZSRVlpT2lBaVRVSkJOeTFaVEZSV0x
  UUlBSRTR0VFU4MFVTMURWMWRMTFZSR1Rrb3RWRFV5V0NJc0NpQWdJCiAgQ0FnS
  UNKUWRXSnNhV05RWVhKaGJXVjBaWEp6SWpvZ2V3b2dJQ0FnSUNBZ0lDSlFkV0p
  zYVdOTFpYbEZRMFIKICBJSWpvZ2V3b2dJQ0FnSUNBZ0lDQWdJbU55ZGlJNklDS
  kZaRFEwT0NJc0NpQWdJQ0FnSUNBZ0lDQWlVSFZpYgogIEdsaklqb2dJakJYUWx
  aNloxb3dhSG95T1RVd1VHUkhkR1pDUkRBd1UxRXpibTlDTXpsMVRYcElUMHBtY
  UVFCiAgMU4zVm5kemhoTUdkSlkwb0tJQ0E0U0hreFgyaHZiak56WWxoelJESnl
  WMlZ3ZDJwT05rRWlmWDE5TEFvZ0kKICBDQWdJa3RsZVVGMWRHaGxiblJwWTJGM
  GFXOXVJam9nZXdvZ0lDQWdJQ0FpVlVSR0lqb2dJazFFVWpjdE5GRgogIFRXUzF
  DVkVwS0xUTlFXbFV0VDBVM1JTMVpSRTVUTFVGSFVsUWlMQW9nSUNBZ0lDQWlVS
  FZpYkdsalVHRnlZCiAgVzFsZEdWeWN5STZJSHNLSUNBZ0lDQWdJQ0FpVUhWaWJ
  HbGpTMlY1UlVORVNDSTZJSHNLSUNBZ0lDQWdJQ0EKICBnSUNKamNuWWlPaUFpU
  ldRME5EZ2lMQW9nSUNBZ0lDQWdJQ0FnSWxCMVlteHBZeUk2SUNKcmEycERhbGx
  tYQogIEhGVGVYVkZhSFJNUjBGQ056Um5ZblJwWHpNMFJGWjNRVWg2UmxKNlNFN
  VRaREEyV1UxQmNETjVTbGRtQ2lBCiAgZ1gycE1lR1pUV0ZNMk1XVlpUbFYzUjJ
  OVFluRkVTMkZCSW4xOWZYMTkiLAogICAgICB7CiAgICAgICAgInNpZ25hdHVyZ
  XMiOiBbewogICAgICAgICAgICAiYWxnIjogIlM1MTIiLAogICAgICAgICAgICA
  ia2lkIjogIk1ETzYtNVhLUi1CSk1QLVBDWUwtSDdHTi1GRlZZLUNDTUYiLAogI
  CAgICAgICAgICAic2lnbmF0dXJlIjogImh3Q2RtZTBtN0R5b0N4YmlvWFBFQWh
  1TXJ2c0s1RTRzWFJUWS1LRktyWnI4Tnowcy0KICAzQi15WEQ3c3ZWX2stV0ZHd
  HZDVUVBUEQyd0E1d1JMR3hVaFNKVm5lbV9ERzBweGsxNVJkZUQyZ0lBTnhRTgo
  gIHFsdGczcTEzVXNvSFNORC1GTlIxQUpSQUJCSDJzQzhmOE9MTFZWUk1BIn1dL
  AogICAgICAgICJQYXlsb2FkRGlnZXN0IjogIk9kNTgteURlS3hWNDFDQ0hFVFd
  4QTR3dkNPTW9uZVFlbjVFU1hXYWl0QUUwVgogIGpjX2dvUm5hV1R5MzllenN5c
  0Vab1FpMS0yX1hsYUFYT1RsY0xrcEpRIn1dLAogICAgIkNsaWVudE5vbmNlIjo
  gIk5yVG9La0Nwbl95MElfQkNYamFQYVEifX0",
          {
            "signatures": [{
                "alg": "S512",
                "kid": "MDR7-4QSY-BTJJ-3PZU-OE7E-YDNS-AGRT",
                "signature": "G3WSiIn3y53G4PrRWfXLP6MSkYOc6fXIXfZAJJ94S4I5mY10A
  6WlhPFFOpKQVNM2SPpQ54789UAAZ555yJSxcvvw5oDt3b0VWdwoX1tc-t-DGi1
  TY4eKG0F6agyx2eFhZ0-Q3q4wXihvVXBo-EIPGi8A"}],
            "PayloadDigest": "y_8Xlftmn_lOzrXqq_6QqkO46GXuFrXYmi_N-Afa4KcSR
  yT7B3JkW7eEz0Dic0gYMu23MtY5suKmx1CLUBy4Vg"}],
        "ServerNonce": "aliIi6bROilxBQYDZzaZQw",
        "Witness": "42FH-AR5P-XEON-URO3-Q6DP-M4SX-BK6Q"},
      {
        "MessageID": "NBUA-WD3V-JRBN-POQF-BKKQ-V7PN-4GGN",
        "EnvelopedRequestConnection": [{
            "dig": "S512"},
          "ewogICJSZXF1ZXN0Q29ubmVjdGlvbiI6IHsKICAgICJTZXJ2aWNlSUQ
  iOiAiYWxpY2VAZXhhbXBsZS5jb20iLAogICAgIkVudmVsb3BlZFByb2ZpbGVEZ
  XZpY2UiOiBbewogICAgICAgICJkaWciOiAiUzUxMiJ9LAogICAgICAiZXdvZ0l
  DSlFjbTltYVd4bFJHVjJhV05sSWpvZ2V3b2dJQ0FnSWt0bGVVOW1abXhwYm1WV
  GFXZAogIHVZWFIxY21VaU9pQjdDaUFnSUNBZ0lDSlZSRVlpT2lBaVRVTkpWUzF
  IVWpkVExWZERURkl0UVRSRlFTMDNNCiAgbFJaTFV0WlJFb3RWRFpVV0NJc0NpQ
  WdJQ0FnSUNKUWRXSnNhV05RWVhKaGJXVjBaWEp6SWpvZ2V3b2dJQ0EKICBnSUN
  BZ0lDSlFkV0pzYVdOTFpYbEZRMFJJSWpvZ2V3b2dJQ0FnSUNBZ0lDQWdJbU55Z
  GlJNklDSkZaRFEwTwogIENJc0NpQWdJQ0FnSUNBZ0lDQWlVSFZpYkdsaklqb2d
  JbWh4UTAwM2JsWnFhekp2VFhGeFZtaHJORVZ3TFROCiAgS1dsOVNWV0p1WW5ac
  VlUaFhPWGhpUTNaaU0wMVVXa0ZRYTNJNFFWZ0tJQ0JFTXpoU05EQkVVVEZxWDB
  sUVIKICBVWlVVRXhOTkhOSVlVRWlmWDE5TEFvZ0lDQWdJa3RsZVVWdVkzSjVjS
  FJwYjI0aU9pQjdDaUFnSUNBZ0lDSgogIFZSRVlpT2lBaVRVTlRXaTFHU2tZMEx
  VUkRXVmN0V1RaVVR5MHpWVXBUTFRJelUwa3RUMGsxTlNJc0NpQWdJCiAgQ0FnS
  UNKUWRXSnNhV05RWVhKaGJXVjBaWEp6SWpvZ2V3b2dJQ0FnSUNBZ0lDSlFkV0p
  zYVdOTFpYbEZRMFIKICBJSWpvZ2V3b2dJQ0FnSUNBZ0lDQWdJbU55ZGlJNklDS
  kZaRFEwT0NJc0NpQWdJQ0FnSUNBZ0lDQWlVSFZpYgogIEdsaklqb2dJa3RyVFV
  nNFoyMTVVa1I2TWpkRlJuSm5NRWN0ZEdOWFJXWnFjbGt5UTJGUVJHeFFXbVpYU
  npaCiAgbWVFNWxUVjlVTkdad05GZ0tJQ0EyVEdWNWJIcHdlbVpMYlZwM2FERkJ
  NemhNYW5KaGQwRWlmWDE5TEFvZ0kKICBDQWdJa3RsZVVGMWRHaGxiblJwWTJGM
  GFXOXVJam9nZXdvZ0lDQWdJQ0FpVlVSR0lqb2dJazFFVkVvdFUxbAogIE1VeTB
  5VWxoUExWZEtORTh0U1UxV1dDMHpRbFpDTFVsT1RGY2lMQW9nSUNBZ0lDQWlVS
  FZpYkdsalVHRnlZCiAgVzFsZEdWeWN5STZJSHNLSUNBZ0lDQWdJQ0FpVUhWaWJ
  HbGpTMlY1UlVORVNDSTZJSHNLSUNBZ0lDQWdJQ0EKICBnSUNKamNuWWlPaUFpU
  ldRME5EZ2lMQW9nSUNBZ0lDQWdJQ0FnSWxCMVlteHBZeUk2SUNKbFVUaGhibGd
  0WQogIDFBM2RHRk9iSEpJTUZsVVlqRjBjRUZ1YkZWcU1FSldVVjlqVjFSbmRtN
  WhSR1pGUlZSV1ZYWkJhM0pvQ2lBCiAgZ2RsSmFhVFpQU21oS0xYUmtla3RFWjB
  0Tk9FdHZVM05CSW4xOWZYMTkiLAogICAgICB7CiAgICAgICAgInNpZ25hdHVyZ
  XMiOiBbewogICAgICAgICAgICAiYWxnIjogIlM1MTIiLAogICAgICAgICAgICA
  ia2lkIjogIk1DSVUtR1I3Uy1XQ0xSLUE0RUEtNzJUWS1LWURKLVQ2VFgiLAogI
  CAgICAgICAgICAic2lnbmF0dXJlIjogIlNDeUM4U1lxYlA3SFdWSEVZVlVFRWY
  2bjUySnhiczJ2WXp1c3dvZzFrOGV1UGhaM0QKICBvZTRNeFQtcmoyLU1MZDhmM
  UIyRzMxbXQ1SUFTVjVHUVBDZTIzeVU1eWo1cTlBak5xUXJOQ21IcW5ORi15eAo
  gIFFuNmNGaTZVU1pEWmpEeXlHdENlRmJIbWxULXYzXzUzMFpac3hEajBBIn1dL
  AogICAgICAgICJQYXlsb2FkRGlnZXN0IjogIlEzeGpSRWpJYVFnT25xdEwzTU9
  ZemtvWXZ5S2x0NDlJTkYySm4zdFhBeVJKQQogIGwtQ09ZUGdvemUxWHFRdnNRd
  0VETUVHSXFlQnhLNnVha2hQOWtiUHp3In1dLAogICAgIkNsaWVudE5vbmNlIjo
  gIlY2ZE5wS2R6VTU4NldYQVU3N1o1SGcifX0",
          {
            "signatures": [{
                "alg": "S512",
                "kid": "MDTJ-SYLS-2RXO-WJ4O-IMVX-3BVB-INLW",
                "signature": "YqmnzpzK6mKx_gwxOczA1f-vVlYj-hN3lAeHdb3FOygpItVA4
  jGguGNBCzASx6rv1hINPXwV-xAAbK-dHQpbXA6geKEjtUiMATo52GkNarihmuD
  MJwPmuuanykJt-lAAGMQ8d06Lz1mjNsfTxgFR3B8A"}],
            "PayloadDigest": "Z4xj3ov648orXkCrj4DU-NHq_KPwFlPm2hF-r-KTEAsGq
  tf9CSsO_mIyCTZeRefSq_nyzCYBqmSZpaVzVwptsw"}],
        "ServerNonce": "JuWg9nuLpgQeUK7-QB3bMw",
        "Witness": "S6SB-IQ4N-25DX-47HG-ZC77-MA2I-5QMT"}]}}
````

# device reject

````
reject   Reject a pending connection
       Fingerprint of connection to reject
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````

The `device reject` command rejects the specified connection request.

The command must specify the connection identifier of the request 
being accepted. The connection identifier may be abbreviated provided that
this uniquely identifies the connection being accepted and that at least 
four characters are given.


````
Alice> device reject NBUA-WD3V-JRBN-POQF-BKKQ-V7PN-4GGN
````

Specifying the /json option returns a result of type ResultConnectProcess:

````
Alice> device reject NBUA-WD3V-JRBN-POQF-BKKQ-V7PN-4GGN /json
{
  "ResultConnectProcess": {
    "Success": true}}
````



# device pre

````
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
````

The `device pre \<account\>` command requests connection of a device to a mesh hailing
account supporting the EARL connection profile.

The \<account\> parameter specifies the hailing account for which the connection request is
made.

The `/key` option may be used to generate the encryption key to be used.

If the `/export` option is specified, the device profile and private keys are written to
a DARE container archive under the specified encryption options rather than the device 
on which the command is issued. This allows a host machine to be used to perform 
offline initialization of device profiles in batch mode during manufacture.


````
Alice4> device pre devices@example.com /key=udf://example.com/ECVF-M7ZO-BIJT-OVPQ-BAG2-ZDTH-K4JW-EV
ERROR - Object reference not set to an instance of an object.
````

Specifying the /json option returns a result of type Result:

````
Alice4> device pre devices@example.com /key=udf://example.com/ECVF-M7ZO-BIJT-OVPQ-BAG2-ZDTH-K4JW-EV /json
{
  "Result": {
    "Success": false,
    "Reason": "Object reference not set to an instance of an object."}}
````

# device request

````
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
````

The `device request \<account\>` command requests connection of a device to a mesh profile.

The \<account\> parameter specifies the account for which the connection request is
made.

If the account holder has generated an authentication code, this is specified by means of 
the `/pin` option.




````
Alice2> device request alice@example.com
   Witness value = S6SB-IQ4N-25DX-47HG-ZC77-MA2I-5QMT
   Personal Mesh = MAZM-EQPB-Y6BY-B3W4-6QZS-CJES-QLTR
````

Specifying the /json option returns a result of type ResultConnect:

````
Alice2> device request alice@example.com /json
{
  "ResultConnect": {
    "Success": true,
    "CatalogedMachine": {
      "ID": "MCIU-GR7S-WCLR-A4EA-72TY-KYDJ-T6TX",
      "EnvelopedProfileMaster": [{
          "dig": "S512"},
        "ewogICJQcm9maWxlTWVzaCI6IHsKICAgICJLZXlPZmZsaW5lU2lnbmF
  0dXJlIjogewogICAgICAiVURGIjogIk1BWk0tRVFQQi1ZNkJZLUIzVzQtNlFaU
  y1DSkVTLVFMVFIiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICA
  gICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiL
  AogICAgICAgICAgIlB1YmxpYyI6ICJfbFpqSmoyZC0zMXd1LW5LdWFlWUoyUld
  NSmszenplWjF6MUFsMnc1czBFV0tZUVMzUDhOCiAgc1dKWGVNV1hKR3R5eldKO
  DRESGp4NXdBIn19fSwKICAgICJLZXlzT25saW5lU2lnbmF0dXJlIjogW3sKICA
  gICAgICAiVURGIjogIk1DQUQtTzRZUy1GT0s3LVRKU0ktVVBPVC1FWDZULVhIU
  zUiLAogICAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICAgIlB
  1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogI
  CAgICAgICAgICAiUHVibGljIjogIi1vb3ZwYzNJdGFhUDlwMmRZczdqcW8zUnI
  wQkp5YTg3NW11UFM4cVZIc1ppaFltTzhSdDkKICB4UjAwaVViN19BcTFUQzFXc
  zJNeG9Jb0EifX19XSwKICAgICJLZXlFbmNyeXB0aW9uIjogewogICAgICAiVUR
  GIjogIk1BTE0tTFBBNy0zNkNOLUtDWVItVFpRVC1ZMkZGLVFOT1IiLAogICAgI
  CAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNESCI
  6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAgIlB1YmxpY
  yI6ICJiUFFjVE1wVUtNUnhZUzJqemRGM1NhNmhQWnF4U05iWFh2a0dXNVowVWx
  meS0xRkF0TkdpCiAgUldHREFfY05GNGJfV00xWjg4RlBldktBIn19fX19",
        {
          "signatures": [{
              "alg": "S512",
              "kid": "MAZM-EQPB-Y6BY-B3W4-6QZS-CJES-QLTR",
              "signature": "oDS89V8WumsdjG4JCkylsIhCxV2Fi-u5rSiA6cxvNn97CUdD0
  w3FzLlo4qc_Bt51TZ0RjRc_JOaAP0eX_udrV9tRW5z85w4ULjHD8mcqTjPw--M
  JvGls5DgOFilGAtN8QFeri7OUiBipmhpScFPiAjUA"}],
          "PayloadDigest": "FX_G1V53MWl_tZHwD1o4Stfc4NJ-IcNn-2VhrO7jZ77CH
  yL71DF-skE0hiU8TgKtAhX_y8yYPKQ66bubcYBBcg"}],
      "DeviceUDF": "MCIU-GR7S-WCLR-A4EA-72TY-KYDJ-T6TX",
      "EnvelopedProfileDevice": [{
          "dig": "S512"},
        "ewogICJQcm9maWxlRGV2aWNlIjogewogICAgIktleU9mZmxpbmVTaWd
  uYXR1cmUiOiB7CiAgICAgICJVREYiOiAiTUNJVS1HUjdTLVdDTFItQTRFQS03M
  lRZLUtZREotVDZUWCIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICA
  gICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJFZDQ0O
  CIsCiAgICAgICAgICAiUHVibGljIjogImhxQ003blZqazJvTXFxVmhrNEVwLTN
  KWl9SVWJuYnZqYThXOXhiQ3ZiM01UWkFQa3I4QVgKICBEMzhSNDBEUTFqX0lQR
  UZUUExNNHNIYUEifX19LAogICAgIktleUVuY3J5cHRpb24iOiB7CiAgICAgICJ
  VREYiOiAiTUNTWi1GSkY0LURDWVctWTZUTy0zVUpTLTIzU0ktT0k1NSIsCiAgI
  CAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJsaWNLZXlFQ0R
  IIjogewogICAgICAgICAgImNydiI6ICJFZDQ0OCIsCiAgICAgICAgICAiUHVib
  GljIjogIktrTUg4Z215UkR6MjdFRnJnMEctdGNXRWZqclkyQ2FQRGxQWmZXRzZ
  meE5lTV9UNGZwNFgKICA2TGV5bHpwemZLbVp3aDFBMzhManJhd0EifX19LAogI
  CAgIktleUF1dGhlbnRpY2F0aW9uIjogewogICAgICAiVURGIjogIk1EVEotU1l
  MUy0yUlhPLVdKNE8tSU1WWC0zQlZCLUlOTFciLAogICAgICAiUHVibGljUGFyY
  W1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICA
  gICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJlUThhblgtY
  1A3dGFObHJIMFlUYjF0cEFubFVqMEJWUV9jV1Rndm5hRGZFRVRWVXZBa3JoCiA
  gdlJaaTZPSmhKLXRkektEZ0tNOEtvU3NBIn19fX19",
        {
          "signatures": [{
              "alg": "S512",
              "kid": "MCIU-GR7S-WCLR-A4EA-72TY-KYDJ-T6TX",
              "signature": "SCyC8SYqbP7HWVHEYVUEEf6n52Jxbs2vYzuswog1k8euPhZ3D
  oe4MxT-rj2-MLd8f1B2G31mt5IASV5GQPCe23yU5yj5q9AjNqQrNCmHqnNF-yx
  Qn6cFi6USZDZjDyyGtCeFbHmlT-v3_530ZZsxDj0A"}],
          "PayloadDigest": "Q3xjREjIaQgOnqtL3MOYzkoYvyKlt49INF2Jn3tXAyRJA
  l-COYPgoze1XqQvsQwEDMEGIqeBxK6uakhP9kbPzw"}],
      "EnvelopedMessageConnectionResponse": [{
          "ContentMetaData": "ewogICJVbmlxdWVJRCI6ICJOQk9QLTdVS0ctRUhXVy1
  ISTJELUczREEtNFEzRC1QTVhFIiwKICAiTWVzc2FnZVR5cGUiOiAiQWNrbm93b
  GVkZ2VDb25uZWN0aW9uIn0"},
        "ewogICJBY2tub3dsZWRnZUNvbm5lY3Rpb24iOiB7CiA
  gICAiTWVzc2FnZUlEIjogIk5CVUEtV0QzVi1KUkJOLVBPUUYtQktLUS1WN1BOL
  TRHR04iLAogICAgIkVudmVsb3BlZFJlcXVlc3RDb25uZWN0aW9uIjogW3sKICA
  gICAgICAiZGlnIjogIlM1MTIifSwKICAgICAgImV3b2dJQ0pTWlhGMVpYTjBRM
  jl1Ym1WamRHbHZiaUk2SUhzS0lDQWdJQ0pUWlhKMmFXTmxTVVEKICBpT2lBaVl
  XeHBZMlZBWlhoaGJYQnNaUzVqYjIwaUxBb2dJQ0FnSWtWdWRtVnNiM0JsWkZCe
  WIyWnBiR1ZFWgogIFhacFkyVWlPaUJiZXdvZ0lDQWdJQ0FnSUNKa2FXY2lPaUF
  pVXpVeE1pSjlMQW9nSUNBZ0lDQWlaWGR2WjBsCiAgRFNsRmpiVGx0WVZkNGJGS
  khWakpoVjA1c1NXcHZaMlYzYjJkSlEwRm5TV3QwYkdWVk9XMWFiWGh3WW0xV1Y
  KICBHRlhaQW9nSUhWWldGSXhZMjFWYVU5cFFqZERhVUZuU1VOQlowbERTbFpTU
  lZscFQybEJhVlJWVGtwV1V6RgogIElWV3BrVkV4V1pFUlVSa2wwVVZSU1JsRlR
  NRE5OQ2lBZ2JGSmFURlYwV2xKRmIzUldSRnBWVjBOSmMwTnBRCiAgV2RKUTBGb
  lNVTktVV1JYU25OaFYwNVJXVmhLYUdKWFZqQmFXRXA2U1dwdloyVjNiMmRKUTB
  FS0lDQm5TVU4KICBCWjBsRFNsRmtWMHB6WVZkT1RGcFliRVpSTUZKSlNXcHZaM
  lYzYjJkSlEwRm5TVU5CWjBsRFFXZEpiVTU1WgogIEdsSk5rbERTa1phUkZFd1R
  3b2dJRU5KYzBOcFFXZEpRMEZuU1VOQlowbERRV2xWU0ZacFlrZHNha2xxYjJkC
  iAgSmJXaDRVVEF3TTJKc1duRmhla3AyVkZoR2VGWnRhSEpPUlZaM1RGUk9DaUF
  nUzFkc09WTldWMHAxV1c1YWMKICBWbFVhRmhQV0docFVUTmFhVTB3TVZWWGEwW
  lJZVE5KTkZGV1owdEpRMEpGVFhwb1UwNUVRa1ZWVkVaeFdEQgogIHNVVklLSUN
  CVldsVlZSWGhPVGtoT1NWbFZSV2xtV0RFNVRFRnZaMGxEUVdkSmEzUnNaVlZXZ
  FZrelNqVmpTCiAgRkp3WWpJMGFVOXBRamREYVVGblNVTkJaMGxEU2dvZ0lGWlN
  SVmxwVDJsQmFWUlZUbFJYYVRGSFUydFpNRXgKICBWVWtSWFZtTjBWMVJhVlZSN
  U1IcFdWWEJVVEZSSmVsVXdhM1JVTUdzeFRsTkpjME5wUVdkSkNpQWdRMEZuUwo
  gIFVOS1VXUlhTbk5oVjA1UldWaEthR0pYVmpCYVdFcDZTV3B2WjJWM2IyZEpRM
  EZuU1VOQlowbERTbEZrVjBwCiAgellWZE9URnBZYkVaUk1GSUtJQ0JKU1dwdlo
  yVjNiMmRKUTBGblNVTkJaMGxEUVdkSmJVNTVaR2xKTmtsRFMKICBrWmFSRkV3V
  DBOSmMwTnBRV2RKUTBGblNVTkJaMGxEUVdsVlNGWnBZZ29nSUVkc2FrbHFiMmR
  KYTNSeVZGVgogIG5ORm95TVRWVmExSTJUV3BrUmxKdVNtNU5SV04wWkVkT1dGS
  lhXbkZqYkd0NVVUSkdVVkpIZUZGWGJWcFlVCiAgbnBhQ2lBZ2JXVkZOV3hVVmp
  sVlRrZGFkMDVHWjB0SlEwRXlWRWRXTldKSWNIZGxiVnBNWWxad00yRkVSa0oKI
  CBOZW1oTllXNUthR1F3UldsbVdERTVURUZ2WjBrS0lDQkRRV2RKYTNSc1pWVkd
  NV1JIYUd4aWJsSndXVEpHTQogIEdGWE9YVkphbTluWlhkdlowbERRV2RKUTBGc
  FZsVlNSMGxxYjJkSmF6RkZWa1Z2ZEZVeGJBb2dJRTFWZVRCCiAgNVZXeG9VRXh
  XWkV0T1JUaDBVMVV4VjFkRE1IcFJiRnBEVEZWc1QxUkdZMmxNUVc5blNVTkJaM
  GxEUVdsVlMKICBGWnBZa2RzYWxWSFJubFpDaUFnVnpGc1pFZFdlV041U1RaSlN
  ITkxTVU5CWjBsRFFXZEpRMEZwVlVoV2FXSgogIEhiR3BUTWxZMVVsVk9SVk5EU
  1RaSlNITkxTVU5CWjBsRFFXZEpRMEVLSUNCblNVTkthbU51V1dsUGFVRnBVCiA
  gbGRSTUU1RVoybE1RVzluU1VOQlowbERRV2RKUTBGblNXeENNVmx0ZUhCWmVVa
  zJTVU5LYkZWVWFHaGliR2QKICAwV1FvZ0lERkJNMlJIUms5aVNFcEpUVVpzVlZ
  scVJqQmpSVVoxWWtaV2NVMUZTbGRWVmpscVZqRlNibVJ0TgogIFdoU1IxcEdVb
  FpTVjFaWVdrSmhNMHB2UTJsQkNpQWdaMlJzU21GaFZGcFFVMjFvUzB4WVVtdGx
  hM1JGV2pCCiAgMFRrOUZkSFpWTTA1Q1NXNHhPV1pZTVRraUxBb2dJQ0FnSUNCN
  0NpQWdJQ0FnSUNBZ0luTnBaMjVoZEhWeVoKICBYTWlPaUJiZXdvZ0lDQWdJQ0F
  nSUNBZ0lDQWlZV3huSWpvZ0lsTTFNVElpTEFvZ0lDQWdJQ0FnSUNBZ0lDQQogI
  GlhMmxrSWpvZ0lrMURTVlV0UjFJM1V5MVhRMHhTTFVFMFJVRXROekpVV1MxTFd
  VUktMVlEyVkZnaUxBb2dJCiAgQ0FnSUNBZ0lDQWdJQ0FpYzJsbmJtRjBkWEpsS
  WpvZ0lsTkRlVU00VTFseFlsQTNTRmRXU0VWWlZsVkZSV1kKICAyYmpVeVNuaGl
  jekoyV1hwMWMzZHZaekZyT0dWMVVHaGFNMFFLSUNCdlpUUk5lRlF0Y21veUxVM
  U1aRGhtTQogIFVJeVJ6TXhiWFExU1VGVFZqVkhVVkJEWlRJemVWVTFlV28xY1R
  sQmFrNXhVWEpPUTIxSWNXNU9SaTE1ZUFvCiAgZ0lGRnVObU5HYVRaVlUxcEVXb
  XBFZVhsSGRFTmxSbUpJYld4VUxYWXpYelV6TUZwYWMzaEVhakJCSW4xZEwKICB
  Bb2dJQ0FnSUNBZ0lDSlFZWGxzYjJGa1JHbG5aWE4wSWpvZ0lsRXplR3BTUldwS
  llWRm5UMjV4ZEV3elRVOQogIFplbXR2V1haNVMyeDBORGxKVGtZeVNtNHpkRmh
  CZVZKS1FRb2dJR3d0UTA5WlVHZHZlbVV4V0hGUmRuTlJkCiAgMFZFVFVWSFNYR
  mxRbmhMTm5WaGEyaFFPV3RpVUhwM0luMWRMQW9nSUNBZ0lrTnNhV1Z1ZEU1dmJ
  tTmxJam8KICBnSWxZMlpFNXdTMlI2VlRVNE5sZFlRVlUzTjFvMVNHY2lmWDAiL
  AogICAgICB7CiAgICAgICAgInNpZ25hdHVyZXMiOiBbewogICAgICAgICAgICA
  iYWxnIjogIlM1MTIiLAogICAgICAgICAgICAia2lkIjogIk1EVEotU1lMUy0yU
  lhPLVdKNE8tSU1WWC0zQlZCLUlOTFciLAogICAgICAgICAgICAic2lnbmF0dXJ
  lIjogIllxbW56cHpLNm1LeF9nd3hPY3pBMWYtdlZsWWotaE4zbEFlSGRiM0ZPe
  WdwSXRWQTQKICBqR2d1R05CQ3pBU3g2cnYxaElOUFh3Vi14QUFiSy1kSFFwYlh
  BNmdlS0VqdFVpTUFUbzUyR2tOYXJpaG11RAogIE1Kd1BtdXVhbnlrSnQtbEFBR
  01ROGQwNkx6MW1qTnNmVHhnRlIzQjhBIn1dLAogICAgICAgICJQYXlsb2FkRGl
  nZXN0IjogIlo0eGozb3Y2NDhvclhrQ3JqNERVLU5IcV9LUHdGbFBtMmhGLXItS
  1RFQXNHcQogIHRmOUNTc09fbUl5Q1RaZVJlZlNxX255ekNZQnFtU1pwYVZ6Vnd
  wdHN3In1dLAogICAgIlNlcnZlck5vbmNlIjogIkp1V2c5bnVMcGdRZVVLNy1RQ
  jNiTXciLAogICAgIldpdG5lc3MiOiAiUzZTQi1JUTROLTI1RFgtNDdIRy1aQzc
  3LU1BMkktNVFNVCJ9fQ"],
      "EnvelopedAccountAssertion": [{
          "dig": "S512"},
        "ewogICJQcm9maWxlQWNjb3VudCI6IHsKICAgICJLZXlPZmZsaW5lU2l
  nbmF0dXJlIjogewogICAgICAiVURGIjogIk1EWDctNERNWS02RktYLU5aMlgtV
  klLRC1HTDRXLVc1UE8iLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICA
  gICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0N
  DgiLAogICAgICAgICAgIlB1YmxpYyI6ICJ1VXRkMzN4b0FyX293bXNRZm5YVGp
  pdUtsWTBvcHZfaFphdF9TU2d5N2c2a3g5Yl90cHdmCiAgcFZpNVAtTEV4eXlne
  jhRVElxOVJmUTBBIn19fSwKICAgICJLZXlzT25saW5lU2lnbmF0dXJlIjogW3s
  KICAgICAgICAiVURGIjogIk1DNkQtRUZXSy03Q0tTLVNWSzQtUk9IVi01MlhBL
  UtQRkUiLAogICAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICA
  gIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAgICJjcnYiOiAiRWQ0NDgiL
  AogICAgICAgICAgICAiUHVibGljIjogInlVR0I5bjhHclZadW4ycnZuUEdKdmU
  3T3JDejI4enlsakVDbjlycU1hVkk3VV9BNlQ3bHcKICBWUVcxcmc3UTFkVVZTa
  Hl5MFIySXVOb0EifX19XSwKICAgICJTZXJ2aWNlSURzIjogWyJhbGljZUBleGF
  tcGxlLmNvbSJdLAogICAgIk1lc2hQcm9maWxlVURGIjogIk1BWk0tRVFQQi1ZN
  kJZLUIzVzQtNlFaUy1DSkVTLVFMVFIiLAogICAgIktleUVuY3J5cHRpb24iOiB
  7CiAgICAgICJVREYiOiAiTUNDWi1aV1dSLUxQVVktR1VFSy1FQk02LVNZS1AtS
  0pIQSIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJ
  saWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJFZDQ0OCIsCiAgICAgI
  CAgICAiUHVibGljIjogIm5HMkowS0hSeENzZmJMb2JSUW9iWGZnZ1FWZVBFVjF
  vd0Vka3Y5R3RXaWhnQVR3N0Zzc1IKICBDelBHNnFfaFE0YTd4ei1NU0xqRjNTZ
  0EifX19fX0",
        {
          "signatures": [{
              "alg": "S512",
              "kid": "MCAD-O4YS-FOK7-TJSI-UPOT-EX6T-XHS5",
              "signature": "AQKCDz1mw4wRebixv3N72yz46kz-Wx_NfzEsI7kG9w5Extnvt
  rleMy8c9Y3X781uoSOf31dJKiMAdVU2RdYXyhaKohIp3ImKKmi9yIq00LH7ptZ
  jGdZsn6Mc1lx59qVwqpQwbAC__hU9ONFJYnsXUg4A"}],
          "PayloadDigest": "qB_IQ4LgFEMPdqmYTBH0ISjSXx3a2HFez3PKWO7A88wCl
  XBK2minR4PrQnCC-bfbvRrZVfm6SekjlV48Ho6gaA"}]}}}
````


