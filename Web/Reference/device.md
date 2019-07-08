

# device

````
device    Device management commands.
    accept   Accept a pending connection
    auth   Authorize device to use application
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
Alice> device accept NBPK-F7VR-TIUK-O3Z4-VD66-CDIM-TMZL
````

Specifying the /json option returns a result of type ResultConnectProcess:

````
Alice> device accept NBPK-F7VR-TIUK-O3Z4-VD66-CDIM-TMZL /json
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
Alice> device accept NBPK-F7VR-TIUK-O3Z4-VD66-CDIM-TMZL
````

Specifying the /json option returns a result of type ResultConnectProcess:

````
Alice> device accept NBPK-F7VR-TIUK-O3Z4-VD66-CDIM-TMZL /json
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
Alice> device delete NBPK-F7VR-TIUK-O3Z4-VD66-CDIM-TMZL
ERROR - The feature has not been implemented
````

Specifying the /json option returns a result of type Result:

````
Alice> device delete NBPK-F7VR-TIUK-O3Z4-VD66-CDIM-TMZL /json
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
Alice> device earl udf://example.com/EAQZ-QTRP-Z7NQ-2Y26-GFWX-FIN3-K55G-PE
ERROR - Object reference not set to an instance of an object.
````

Specifying the /json option returns a result of type Result:

````
Alice> device earl udf://example.com/EAQZ-QTRP-Z7NQ-2Y26-GFWX-FIN3-K55G-PE /json
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
        "MessageID": "NBPK-F7VR-TIUK-O3Z4-VD66-CDIM-TMZL",
        "EnvelopedMessageConnectionRequest": [{
            "dig": "S512"},
          "ewogICJSZXF1ZXN0Q29ubmVjdGlvbiI6IHsKICAgICJTZXJ2aWNlSUQ
  iOiAiYWxpY2VAZXhhbXBsZS5jb20iLAogICAgIkVudmVsb3BlZFByb2ZpbGVEZ
  XZpY2UiOiBbewogICAgICAgICJkaWciOiAiUzUxMiIsCiAgICAgICAgImN0eSI
  6ICJhcHBsaWNhdGlvbi9tbW0ifSwKICAgICAgImV3b2dJQ0pRY205bWFXeGxSR
  1YyYVdObElqb2dld29nSUNBZ0lrdGxlVk5wWjI1aGRIVnlaU0kKICA2SUhzS0l
  DQWdJQ0FnSWxWRVJpSTZJQ0pOUWtkQkxVSTNWMWN0U0RJM1RDMVRTMUJHTFVNM
  1ZVMHRXalZKVgogIFMxWE5sbFpJaXdLSUNBZ0lDQWdJbEIxWW14cFkxQmhjbUZ
  0WlhSbGNuTWlPaUI3Q2lBZ0lDQWdJQ0FnSWxCCiAgMVlteHBZMHRsZVVWRFJFZ
  2lPaUI3Q2lBZ0lDQWdJQ0FnSUNBaVkzSjJJam9nSWtWa05EUTRJaXdLSUNBZ0k
  KICBDQWdJQ0FnSUNKUWRXSnNhV01pT2lBaWExZExNMDlHTTNCUWNqUlNjMDlpV
  0Y5SVVGOWhRVVV5TnpoUFF6RgogIHdWMHgxYzA0M2FrMXVNa2xTVFRkWmJEY3p
  VMlp2UWdvZ0lHSmlUelZhVFdadldUVnZaa2MzVFVkM2MzSjZTCiAgWFpCUVNKO
  WZYMHNDaUFnSUNBaVMyVjVSVzVqY25sd2RHbHZiaUk2SUhzS0lDQWdJQ0FnSWx
  WRVJpSTZJQ0oKICBOUVVwU0xVVlBTbGN0TlVWQ1R5MVRWVFpNTFRKTE4wUXROa
  3hZUlMwelZrSldJaXdLSUNBZ0lDQWdJbEIxWQogIG14cFkxQmhjbUZ0WlhSbGN
  uTWlPaUI3Q2lBZ0lDQWdJQ0FnSWxCMVlteHBZMHRsZVVWRFJFZ2lPaUI3Q2lBC
  iAgZ0lDQWdJQ0FnSUNBaVkzSjJJam9nSWtWa05EUTRJaXdLSUNBZ0lDQWdJQ0F
  nSUNKUWRXSnNhV01pT2lBaWUKICBHWnVRalphVGtKamJIbDBiV3QzTmpGUU9FT
  jRaVGRCWldkM1NXRk9UMGg1UkZWRFVHaHVSMUZuT1dKT1IwcAogIE1NRUZzTUF
  vZ0lHaFJTekJ4V1dSV2EydHFRMEpwYVRGak5FRTJlak10UVNKOWZYMHNDaUFnS
  UNBaVMyVjVRCiAgWFYwYUdWdWRHbGpZWFJwYjI0aU9pQjdDaUFnSUNBZ0lDSlZ
  SRVlpT2lBaVRVTkpOUzFEUzFSSExVTkpTbEUKICB0VkVKVldpMVZVVmhFTFZCV
  VFVRXRWREpKTnlJc0NpQWdJQ0FnSUNKUWRXSnNhV05RWVhKaGJXVjBaWEp6SQo
  gIGpvZ2V3b2dJQ0FnSUNBZ0lDSlFkV0pzYVdOTFpYbEZRMFJJSWpvZ2V3b2dJQ
  0FnSUNBZ0lDQWdJbU55ZGlJCiAgNklDSkZaRFEwT0NJc0NpQWdJQ0FnSUNBZ0l
  DQWlVSFZpYkdsaklqb2dJbEpZTVU4d1dVSkdlRTVzY21WR2QKICAzRnJlSFprY
  lZaeGNFUjRkVTFqWkhKVGQxSkpjM1I2YXkwNWFucFNURVpYYkdsb1RrY0tJQ0J
  JV2tjM2RrYwogIDBTbk5WUzBGNFdGZzVPVU5RZERONmEwRWlmWDE5ZlgwIiwKI
  CAgICAgewogICAgICAgICJzaWduYXR1cmVzIjogW3sKICAgICAgICAgICAgInN
  pZ25hdHVyZSI6ICJRQkE3dDRBWXRMb0RUalI4MDFGcTZIZ2xacHVpUG1JODFxV
  m1vUFpuUFQ2WUlEWXJQCiAgb2xZX1p4TUZNWHZQdXY2NUFycXB5TDZZTy1BZzN
  zOEZmTDFIZEc3UDJUSHplc25ZVDVkVUs1ZUlZTzZyUHMKICByLVlDcVhVN2FtW
  kRRUUlpd3ljXzlpc3g2M01lcXlVWTNtd0tBNGcwQSJ9XSwKICAgICAgICAiUGF
  5bG9hZERpZ2VzdCI6ICI0OUVMUUI0N3R3bnBQb2NEVDRhZTdMZHV2SE5hd1oxS
  E9Ed2I3NTVyblMxY3kKICBFUnJnbWFYeDlUSm1KWk5BZlg1RHVLaFZiU09NeVU
  1SUNxMjB1U0RQZyJ9XSwKICAgICJDbGllbnROb25jZSI6ICI3Y3Z0aVdfeWc2Q
  TlNcE5uRlVPNFZBIn19",
          {
            "signatures": [{
                "signature": "Kk-n-tGjCIVFR8phLjf4I1hcqaPPCHMRsZmhU5NWO6K8kg9dS
  _XEqTyXO54dMZPsD3shCgPbyk4AjrfoN3IAAUWr2hdq8-i3JPtaP9D7rWoGa_D
  UnwZRkaWl9GU6h508KeDJmbirsfiHxjm7mCuAzhwA"}],
            "PayloadDigest": "zb7dHB5SCSC4P0QBOI5nS6RGDHIszHDfN_-qEGoSwiQGz
  UZzGDlWT5wpMqq__wDfJlaz4DZCgvIpbpjrntTqfg"}],
        "ServerNonce": "yDjmc4OWYJKMpZctsIMeqw",
        "Witness": "46J6-M7HD-VH7E-CJ7I-EGM4-PNHS-HLD6"}]}}
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
Alice> device reject tbs
````

Specifying the /json option returns a result of type ResultConnectProcess:

````
Alice> device reject tbs /json
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
Alice4> device pre devices@example.com /key=udf://example.com/EAQZ-QTRP-Z7NQ-2Y26-GFWX-FIN3-K55G-PE
ERROR - Object reference not set to an instance of an object.
````

Specifying the /json option returns a result of type Result:

````
Alice4> device pre devices@example.com /key=udf://example.com/EAQZ-QTRP-Z7NQ-2Y26-GFWX-FIN3-K55G-PE /json
{
  "Result": {
    "Success": false,
    "Reason": "Object reference not set to an instance of an object."}}
````

# device request

````
request   Connect to an existing profile registered at a portal
       New portal account
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
   Witness value = 46J6-M7HD-VH7E-CJ7I-EGM4-PNHS-HLD6
   Personal Mesh = MD2T-3WE6-TJAM-QU3C-CXGM-4EW4-4QDM
````

Specifying the /json option returns a result of type ResultConnect:

````
Alice2> device request alice@example.com /json
{
  "ResultConnect": {
    "Success": true,
    "CatalogedMachine": {
      "ID": "MBGA-B7WW-H27L-SKPF-C7UM-Z5IU-W6YY",
      "EnvelopedProfileMaster": [{
          "dig": "S512"},
        "ewogICJQcm9maWxlTWFzdGVyIjogewogICAgIktleVNpZ25hdHVyZSI
  6IHsKICAgICAgIlVERiI6ICJNRDJULTNXRTYtVEpBTS1RVTNDLUNYR00tNEVXN
  C00UURNIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB
  1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIkVkNDQ4IiwKICAgI
  CAgICAgICJQdWJsaWMiOiAiNnRmOEVUaVpNellVVjVqS3I3dWxhUTFDR2JqU1l
  kWDk2Y25PMlUxeDVUaDdUaTB1THhCeAogIHllLU1uZGZzRS12cFJzTFJOX1lSS
  zV3QSJ9fX0sCiAgICAiT25saW5lU2lnbmF0dXJlS2V5cyI6IFt7CiAgICAgICA
  gIlVERiI6ICJNQllaLVpERUctSkpPNS1UVDNJLUVRVzctVUhSMy1CSklDIiwKI
  CAgICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAgICJQdWJsaWN
  LZXlFQ0RIIjogewogICAgICAgICAgICAiY3J2IjogIkVkNDQ4IiwKICAgICAgI
  CAgICAgIlB1YmxpYyI6ICJWMjFzLUFubHFrakpSaHFNUHZrUDVuUVZ1aDNEdnB
  sTTVFLU1lNVlJczJkdWF0S3haX2xvCiAgM1FoRUdVd2NZNldHVWVfaG9GbVNlS
  ThBIn19fV0sCiAgICAiS2V5RW5jcnlwdGlvbiI6IHsKICAgICAgIlVERiI6ICJ
  NQ1BELUdCQkotQkQ2VC1XNktKLVZVREktTUUyWC1TVVlRIiwKICAgICAgIlB1Y
  mxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiA
  gICAgICAgICAiY3J2IjogIkVkNDQ4IiwKICAgICAgICAgICJQdWJsaWMiOiAiU
  WxpTUdCbUI2b3Z6bVIzVEgwbDRMaV9QS2dtRDRyY3BPRGhsX3RrN0lDaTVaWmZ
  weEg3egogIFZDakRkU19EcW15YUs1Q1B3Y1R3R0hPQSJ9fX19fQ",
        {
          "signatures": [{
              "signature": "4Klto3KTAQxDTbNdz6HaA2UlGaO3KdJrGLUCw43x5bHxVXsIh
  1sujh_bCmSY-SrmtPTo-Ls42PkAyQKZV8yqRNR99ipXGvwUnwKHRBJjZHGAclA
  eEBLhXy-TMRVLvDuS49xw-p6GgH1-NLh_xrLKEi4A"}],
          "PayloadDigest": "rBZuguqApbLZcZzRkN4F-awfeodWzy1W2G1Ij-hdPOJ5c
  z_O0Y_39kSqsdzjygqb0F6A23xd0Jxz32AkSqIowA"}],
      "DeviceUDF": "MBGA-B7WW-H27L-SKPF-C7UM-Z5IU-W6YY",
      "EnvelopedMessageConnectionResponse": [{},
        "ewogICJBY2tub3dsZWRnZUNv
  bm5lY3Rpb24iOiB7CiAgICAiTWVzc2FnZUlEIjogIk5CUEstRjdWUi1USVVLLU
  8zWjQtVkQ2Ni1DRElNLVRNWkwiLAogICAgIkVudmVsb3BlZE1lc3NhZ2VDb25u
  ZWN0aW9uUmVxdWVzdCI6IFt7CiAgICAgICAgImRpZyI6ICJTNTEyIn0sCiAgIC
  AgICJld29nSUNKU1pYRjFaWE4wUTI5dWJtVmpkR2x2YmlJNklIc0tJQ0FnSUNK
  VFpYSjJhV05sU1VRCiAgaU9pQWlZV3hwWTJWQVpYaGhiWEJzWlM1amIyMGlMQW
  9nSUNBZ0lrVnVkbVZzYjNCbFpGQnliMlpwYkdWRVoKICBYWnBZMlVpT2lCYmV3
  b2dJQ0FnSUNBZ0lDSmthV2NpT2lBaVV6VXhNaUlzQ2lBZ0lDQWdJQ0FnSW1OMG
  VTSQogIDZJQ0poY0hCc2FXTmhkR2x2Ymk5dGJXMGlmU3dLSUNBZ0lDQWdJbVYz
  YjJkSlEwcFJZMjA1YldGWGVHeFNSCiAgMVl5WVZkT2JFbHFiMmRsZDI5blNVTk
  JaMGxyZEd4bFZrNXdXakkxYUdSSVZubGFVMGtLSUNBMlNVaHpTMGwKICBEUVdk
  SlEwRm5TV3hXUlZKcFNUWkpRMHBPVVd0a1FreFZTVE5XTVdOMFUwUkpNMVJETV
  ZSVE1VSkhURlZOTQogIDFaVk1IUlhhbFpLVmdvZ0lGTXhXRTVzYkZwSmFYZExT
  VU5CWjBsRFFXZEpiRUl4V1cxNGNGa3hRbWhqYlVaCiAgMFdsaFNiR051VFdsUG
  FVSTNRMmxCWjBsRFFXZEpRMEZuU1d4Q0NpQWdNVmx0ZUhCWk1IUnNaVlZXUkZK
  RloKICAybFBhVUkzUTJsQlowbERRV2RKUTBGblNVTkJhVmt6U2pKSmFtOW5TV3
  RXYTA1RVVUUkphWGRMU1VOQlowawogIEtJQ0JEUVdkSlEwRm5TVU5LVVdSWFNu
  TmhWMDFwVDJsQmFXRXhaRXhOTURsSFRUTkNVV05xVWxOak1EbHBWCiAgMFk1U1
  ZWR09XaFJWVlY1VG5wb1VGRjZSZ29nSUhkV01IZ3hZekEwTTJGck1YVk5hMnhU
  VkZSa1dtSkVZM3AKICBWTWxwMlVXZHZaMGxIU21sVWVsWmhWRmRhZGxkVVZuWm
  FhMk16VkZWa00yTXpTalpUQ2lBZ1dGcENVVk5LTwogIFdaWU1ITkRhVUZuU1VO
  QmFWTXlWalZTVnpWcVkyNXNkMlJIYkhaaWFVazJTVWh6UzBsRFFXZEpRMEZuU1
  d4CiAgV1JWSnBTVFpKUTBvS0lDQk9VVlZ3VTB4VlZsQlRiR04wVGxWV1ExUjVN
  VlJXVkZwTlRGUktURTR3VVhST2EKICAzaFpVbE13ZWxaclNsZEphWGRMU1VOQl
  owbERRV2RKYkVJeFdRb2dJRzE0Y0ZreFFtaGpiVVowV2xoU2JHTgogIHVUV2xQ
  YVVJM1EybEJaMGxEUVdkSlEwRm5TV3hDTVZsdGVIQlpNSFJzWlZWV1JGSkZaMm
  xQYVVJM1EybEJDCiAgaUFnWjBsRFFXZEpRMEZuU1VOQmFWa3pTakpKYW05blNX
  dFdhMDVFVVRSSmFYZExTVU5CWjBsRFFXZEpRMEYKICBuU1VOS1VXUlhTbk5oVj
  AxcFQybEJhV1VLSUNCSFduVlJhbHBoVkd0S2FtSkliREJpVjNRelRtcEdVVTlG
  VAogIGpSYVZHUkNXbGRrTTFOWFJrOVVNR2cxVWtaV1JGVkhhSFZTTVVadVQxZE
  tUMUl3Y0FvZ0lFMU5SVVp6VFVGCiAgdlowbEhhRkpUZWtKNFYxZFNWMkV5ZEhG
  Uk1FcHdZVlJHYWs1RlJUSmxhazEwVVZOS09XWllNSE5EYVVGblMKICBVTkJhVk
  15VmpWUkNpQWdXRll3WVVkV2RXUkhiR3BaV0ZKd1lqSTBhVTlwUWpkRGFVRm5T
  VU5CWjBsRFNsWgogIFNSVmxwVDJsQmFWUlZUa3BPVXpGRVV6RlNTRXhWVGtwVG
  JFVUtJQ0IwVmtWS1ZsZHBNVlpWVm1oRlRGWkNWCiAgVkZWUlhSV1JFcEtUbmxK
  YzBOcFFXZEpRMEZuU1VOS1VXUlhTbk5oVjA1UldWaEthR0pYVmpCYVdFcDZTUW
  8KICBnSUdwdloyVjNiMmRKUTBGblNVTkJaMGxEU2xGa1YwcHpZVmRPVEZwWWJF
  WlJNRkpKU1dwdloyVjNiMmRKUQogIDBGblNVTkJaMGxEUVdkSmJVNTVaR2xKQ2
  lBZ05rbERTa1phUkZFd1QwTkpjME5wUVdkSlEwRm5TVU5CWjBsCiAgRFFXbFZT
  RlpwWWtkc2FrbHFiMmRKYkVwWlRWVTRkMWRWU2tkbFJUVnpZMjFXUjJRS0lDQX
  pSbkpsU0ZwclkKICBsWmFlR05GVWpSa1ZURnFXa2hLVkdReFNrcGpNMUkyWVhr
  d05XRnVjRk5VUlZwWVlrZHNiMVJyWTB0SlEwSgogIEpWMnRqTTJScll3b2dJRE
  JUYms1V1V6QkdORmRHWnpWUFZVNVJaRVJPTm1Fd1JXbG1XREU1Wmxnd0lpd0tJ
  CiAgQ0FnSUNBZ2V3b2dJQ0FnSUNBZ0lDSnphV2R1WVhSMWNtVnpJam9nVzNzS0
  lDQWdJQ0FnSUNBZ0lDQWdJbk4KICBwWjI1aGRIVnlaU0k2SUNKUlFrRTNkRFJC
  V1hSTWIwUlVhbEk0TURGR2NUWklaMnhhY0hWcFVHMUpPREZ4VgogIG0xdlVGcH
  VVRlEyV1VsRVdYSlFDaUFnYjJ4WlgxcDRUVVpOV0haUWRYWTJOVUZ5Y1hCNVRE
  WlpUeTFCWnpOCiAgek9FWm1UREZJWkVjM1VESlVTSHBsYzI1WlZEVmtWVXMxWl
  VsWlR6WnlVSE1LSUNCeUxWbERjVmhWTjJGdFcKICBrUlJVVWxwZDNsalh6bHBj
  M2cyTTAxbGNYbFZXVE50ZDB0Qk5HY3dRU0o5WFN3S0lDQWdJQ0FnSUNBaVVHRg
  ogIDViRzloWkVScFoyVnpkQ0k2SUNJME9VVk1VVUkwTjNSM2JuQlFiMk5FVkRS
  aFpUZE1aSFYyU0U1aGQxb3hTCiAgRTlFZDJJM05UVnlibE14WTNrS0lDQkZVbk
  puYldGWWVEbFVTbTFLV2s1QlpsZzFSSFZMYUZaaVUwOU5lVlUKICAxU1VOeE1q
  QjFVMFJRWnlKOVhTd0tJQ0FnSUNKRGJHbGxiblJPYjI1alpTSTZJQ0kzWTNaMG
  FWZGZlV2MyUQogIFRsTmNFNXVSbFZQTkZaQkluMTkiLAogICAgICB7CiAgICAg
  ICAgInNpZ25hdHVyZXMiOiBbewogICAgICAgICAgICAic2lnbmF0dXJlIjogIk
  trLW4tdEdqQ0lWRlI4cGhMamY0STFoY3FhUFBDSE1Sc1ptaFU1TldPNks4a2c5
  ZFMKICBfWEVxVHlYTzU0ZE1aUHNEM3NoQ2dQYnlrNEFqcmZvTjNJQUFVV3IyaG
  RxOC1pM0pQdGFQOUQ3cldvR2FfRAogIFVud1pSa2FXbDlHVTZoNTA4S2VESm1i
  aXJzZmlIeGptN21DdUF6aHdBIn1dLAogICAgICAgICJQYXlsb2FkRGlnZXN0Ij
  ogInpiN2RIQjVTQ1NDNFAwUUJPSTVuUzZSR0RISXN6SERmTl8tcUVHb1N3aVFH
  egogIFVaekdEbFdUNXdwTXFxX193RGZKbGF6NERaQ2d2SXBicGpybnRUcWZnIn
  1dLAogICAgIlNlcnZlck5vbmNlIjogInlEam1jNE9XWUpLTXBaY3RzSU1lcXci
  LAogICAgIldpdG5lc3MiOiAiNDZKNi1NN0hELVZIN0UtQ0o3SS1FR000LVBOSF
  MtSExENiJ9fQ"],
      "EnvelopedAccountAssertion": [{
          "dig": "S512"},
        "ewogICJQcm9maWxlQWNjb3VudCI6IHsKICAgICJTZXJ2aWNlSURzIjo
  gWyJhbGljZUBleGFtcGxlLmNvbSJdLAogICAgIk1lc2hQcm9maWxlVURGIjogI
  k1EMlQtM1dFNi1USkFNLVFVM0MtQ1hHTS00RVc0LTRRRE0iLAogICAgIkFjY29
  1bnRFbmNyeXB0aW9uS2V5IjogewogICAgICAiVURGIjogIk1CVVQtTVpQTS00T
  FhILVZWNkQtSEVGUS1MUDdVLUU1T1giLAogICAgICAiUHVibGljUGFyYW1ldGV
  ycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjc
  nYiOiAiRWQ0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJVX0VlcjJCclhXelZ
  fQnJnaEdoRjFIT201bXZEYUEyaklQWG5VekduWllVYnN0YWhaYTdsCiAgU3hkd
  FlSZkh4N201NzNPcVg1RkhyNnVBIn19fX19",
        {
          "signatures": [{
              "signature": "i4Ji_Y6zb0VY94aaxub5SwSw1cYRbJA_w7Hut1mTR8KM71hUk
  iD7pBAsznUm1eR9JIVvjlPpKIiAThp5iri61yI46YHqhiInaFf4r5wKr1XPHZm
  9hfqmzC7sNs9urFu1a7EvdFNaE5p4c2fZd4L53zkA"}],
          "PayloadDigest": "YgXmCgXLGgmrmazOX9df6TcIal_ciZtnuoej4FzbGYwX-
  YUwcfRMWpIgXHdFDuQ1vQxpOvzNYsc4y8NZYU6ZHQ"}]}}}
````


