

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
Alice> device accept NCSZ-HZHS-QKLF-AP52-2YAB-ZIIS-VD6K
````

Specifying the /json option returns a result of type ResultConnectProcess:

````
Alice> device accept NCSZ-HZHS-QKLF-AP52-2YAB-ZIIS-VD6K /json
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
Alice> device accept NCSZ-HZHS-QKLF-AP52-2YAB-ZIIS-VD6K
````

Specifying the /json option returns a result of type ResultConnectProcess:

````
Alice> device accept NCSZ-HZHS-QKLF-AP52-2YAB-ZIIS-VD6K /json
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
Alice> device delete NCSZ-HZHS-QKLF-AP52-2YAB-ZIIS-VD6K
ERROR - The feature has not been implemented
````

Specifying the /json option returns a result of type Result:

````
Alice> device delete NCSZ-HZHS-QKLF-AP52-2YAB-ZIIS-VD6K /json
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
Alice> device earl udf://example.com/EDN6-JLSO-BJ44-HXN7-FRCT-2S2M-A5XZ-X4
ERROR - Object reference not set to an instance of an object.
````

Specifying the /json option returns a result of type Result:

````
Alice> device earl udf://example.com/EDN6-JLSO-BJ44-HXN7-FRCT-2S2M-A5XZ-X4 /json
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
        "MessageID": "NCSZ-HZHS-QKLF-AP52-2YAB-ZIIS-VD6K",
        "EnvelopedRequestConnection": [{
            "dig": "S512",
            "Index": 0},
          "ewogICJSZXF1ZXN0Q29ubmVjdGlvbiI6IHsKICAgICJTZXJ2aWNlS
  UQiOiAiYWxpY2VAZXhhbXBsZS5jb20iLAogICAgIkVudmVsb3BlZFByb2ZpbGV
  EZXZpY2UiOiBbewogICAgICAgICJkaWciOiAiUzUxMiIsCiAgICAgICAgImN0e
  SI6ICJhcHBsaWNhdGlvbi9tbW0ifSwKICAgICAgImV3b2dJQ0pRY205bWFXeGx
  SR1YyYVdObElqb2dld29nSUNBZ0lrdGxlVTltWm14cGJtVlRhV2QKICB1WVhSM
  WNtVWlPaUI3Q2lBZ0lDQWdJQ0pWUkVZaU9pQWlUVUZJUXkwMFMxRldMVTVhU2x
  rdFIxaFNVQzFCTgogIDFSS0xUUlpTVFF0UVZaTlNpSXNDaUFnSUNBZ0lDSlFkV
  0pzYVdOUVlYSmhiV1YwWlhKeklqb2dld29nSUNBCiAgZ0lDQWdJQ0pRZFdKc2F
  XTkxaWGxGUTBSSUlqb2dld29nSUNBZ0lDQWdJQ0FnSW1OeWRpSTZJQ0pGWkRRM
  E8KICBDSXNDaUFnSUNBZ0lDQWdJQ0FpVUhWaWJHbGpJam9nSWtWVVRtbzRWa3g
  1YkRaRFJXdzRPVmRVU1VoaE1rZAogIFZZMDFwTTFKWlFWODRUWHA0V1VWcVYwe
  E1ibHBEYW5VNWExbzRWRW9LSUNCNVpWTlpVSEJqVUdoMlFUQnNiCiAgVzlrV0U
  1NmNHbDZZMEVpZlgxOUxBb2dJQ0FnSWt0bGVVVnVZM0o1Y0hScGIyNGlPaUI3Q
  2lBZ0lDQWdJQ0oKICBWUkVZaU9pQWlUVUZXVnkwMFZ6YzBMVXBCVEZBdFdVSkZ
  XUzFOVWtwYUxWWkdNMGN0TXpWWFdpSXNDaUFnSQogIENBZ0lDSlFkV0pzYVdOU
  VlYSmhiV1YwWlhKeklqb2dld29nSUNBZ0lDQWdJQ0pRZFdKc2FXTkxaWGxGUTB
  SCiAgSUlqb2dld29nSUNBZ0lDQWdJQ0FnSW1OeWRpSTZJQ0pGWkRRME9DSXNDa
  UFnSUNBZ0lDQWdJQ0FpVUhWaWIKICBHbGpJam9nSW5OQ1ZXSnNkRlJTUlZad0x
  WSXdRV2RuWldoSE9XSjNOR3N4YjB0S1NHTm5lbDlvU2pWNWEwZAogIGtTRFJGV
  2t0UFVuTmhXWE1LSUNCbGJURkNPVkUyTW5KS2NHdENabEpKU0hWWGRXNXlSVUV
  pZlgxOUxBb2dJCiAgQ0FnSWt0bGVVRjFkR2hsYm5ScFkyRjBhVzl1SWpvZ2V3b
  2dJQ0FnSUNBaVZVUkdJam9nSWsxRVFVSXRRVFIKICBUVVMwMlJEUXlMVlpRVHp
  NdFJUYzBSUzFGTWxwQkxVaFZUa1VpTEFvZ0lDQWdJQ0FpVUhWaWJHbGpVR0Z5W
  QogIFcxbGRHVnljeUk2SUhzS0lDQWdJQ0FnSUNBaVVIVmliR2xqUzJWNVJVTkV
  TQ0k2SUhzS0lDQWdJQ0FnSUNBCiAgZ0lDSmpjbllpT2lBaVJXUTBORGdpTEFvZ
  0lDQWdJQ0FnSUNBZ0lsQjFZbXhwWXlJNklDSk9lVWhVYkhOd00KICAyRTBZVkZ
  UTkdOeWRVMU5jVzEwTUc5NU5sWTNaMjFvVHkxeVprZGZaMU0yVWxGRlRHWnZTM
  VZHV1VJMUNpQQogIGdUWE5NYTJkMFowUnRSMTkxUzA5UU5FNHpNWGMyUzI5Qkl
  uMTlmWDE5IiwKICAgICAgewogICAgICAgICJzaWduYXR1cmVzIjogW3sKICAgI
  CAgICAgICAgInNpZ25hdHVyZSI6ICJnY1FvNUN5a1A3d0tqZmYzZ0xsbk4zLXJ
  DTVQxTldKR1pFVms3Y01KNncwRGx6Q3I2CiAgRHVKQ1gxMXN3Wm5GX1dmM205c
  Wp1YkMtUWFBM1JpUUw0NHFwZnJhVzA3dXdRXzE1OERLTmN0T3NELU5PZHoKICB
  sSkJvS1JPejJNX0dyTER0bzc3ZDBpY3ZMTnpBbUZXZkZpdEhCQmdJQSJ9XSwKI
  CAgICAgICAiUGF5bG9hZERpZ2VzdCI6ICJOdzB2ekVEY1p1dFg4dXBqUkRwMDR
  xS3RGN25OdFhVUFBEUjhaNUNLNmJRd2kKICBGcm9tOEJiVGJrTEhZYVN4bWFIS
  ElsU0hhMG55OF9GaFJKX1lHTkJPZyJ9XSwKICAgICJDbGllbnROb25jZSI6ICJ
  tbFZvNWk2RU4zRzBlSUNPSERiOGtnIn19",
          {
            "signatures": [{
                "signature": "hCYqHibPKDOcq59GpIuDwTqO6avIK1Y25KNswl3y8utjiDc6I
  H6CbZKenlD84vi1guCWs3t2uYEAdKDvgat9XkGNV0AkasKVqz4m1cKZBnwLQf1
  jbGEYrB5rPftO957ta1FXVrQR0V_Cg5gJ-4xsHSIA"}],
            "PayloadDigest": "joHqe5LmsS5lEmmGwWncR8ymc80ib28D-skchzX0k0beK
  oBhMCjrzAl0tl0ILNXnOAxbsSCDls2iZ1R_tAviQQ"}],
        "ServerNonce": "0559Z__D5uRW1AeiodtFhw",
        "Witness": "QRQ3-3LCG-NUN5-W7CJ-PPLB-4CAM-64AX"}]}}
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
Alice4> device pre devices@example.com /key=udf://example.com/EDN6-JLSO-BJ44-HXN7-FRCT-2S2M-A5XZ-X4
ERROR - Object reference not set to an instance of an object.
````

Specifying the /json option returns a result of type Result:

````
Alice4> device pre devices@example.com /key=udf://example.com/EDN6-JLSO-BJ44-HXN7-FRCT-2S2M-A5XZ-X4 /json
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
   Witness value = QRQ3-3LCG-NUN5-W7CJ-PPLB-4CAM-64AX
   Personal Mesh = MC6F-FW6P-LHO5-DS4P-QUBZ-3V7S-6QX7
````

Specifying the /json option returns a result of type ResultConnect:

````
Alice2> device request alice@example.com /json
{
  "ResultConnect": {
    "Success": true,
    "CatalogedMachine": {
      "ID": "MAHC-4KQV-NZJY-GXRP-A7TJ-4YI4-AVMJ",
      "EnvelopedProfileMaster": [{
          "dig": "S512",
          "Index": 0},
        "ewogICJQcm9maWxlUGVyc29uYWwiOiB7CiAgICAiS2V5T2ZmbGluZ
  VNpZ25hdHVyZSI6IHsKICAgICAgIlVERiI6ICJNQzZGLUZXNlAtTEhPNS1EUzR
  QLVFVQlotM1Y3Uy02UVg3IiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7C
  iAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIkV
  kNDQ4IiwKICAgICAgICAgICJQdWJsaWMiOiAiRGRqZEdxQmY0OHBscEo2ZkNSW
  kJtV0k5NGNZeWtTQzMtZ1U0UDh0Y292NFVDTzNRLXk3NgogIEQ2ZXNGdDBnVC0
  3Q2E5c0RodHFUMGxHQSJ9fX0sCiAgICAiS2V5c09ubGluZVNpZ25hdHVyZSI6I
  Ft7CiAgICAgICAgIlVERiI6ICJNQldPLVNVR0ctREtXWi1XSVlLLU43U1MtVlB
  PUi01N1FGIiwKICAgICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgI
  CAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgICAiY3J2IjogIkVkNDQ
  4IiwKICAgICAgICAgICAgIlB1YmxpYyI6ICJXeW9rNTIyeVN0aFd1WFVvVE9HM
  Xd2S293RVgzRHUzNG5NT0RrNEZ1aUNDZFZVNEtZTmRFCiAgVEthUHlWdHZVd09
  KYjQwY1ZaOU81aDRBIn19fV0sCiAgICAiS2V5RW5jcnlwdGlvbiI6IHsKICAgI
  CAgIlVERiI6ICJNRE5VLVZZWDUtUk5QVS1YT1NYLTNWUk8tSVJPTC1WNlhFIiw
  KICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tle
  UVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIkVkNDQ4IiwKICAgICAgICAgICJ
  QdWJsaWMiOiAibVhqalQxLXUzYUVaNTRKQk9OSHdvTHE1VVY4WUJHaXk1M2xpO
  DR4cVJJc3phOUp0NGtvMQogIFNRbEhQVGluZkhaaE9SNFlRdGM3eUd3QSJ9fX1
  9fQ",
        {
          "signatures": [{
              "signature": "2_keh4HvgsnGXe_j0qVsZa7b-Mf4GiJnVXXXuLGY-jmrTK6kY
  FCLbdCBDDnLYI-wSfoouMi71TeA3UkySEeFkhZIjoVey5PmSO6sAXazzYD07rU
  PQA1fNVqQDslFP-CgLoughq2n6xkksszJsFUewSYA"}],
          "PayloadDigest": "6EcyL9WDpgCkwN6WUGwSQEqPxov02LQbMAVVlX0a-JPZZ
  bvpjHKpekhsRpbHbHeyV_GFEbls70f4o-kHVmllKQ"}],
      "DeviceUDF": "MAHC-4KQV-NZJY-GXRP-A7TJ-4YI4-AVMJ",
      "EnvelopedMessageConnectionResponse": [{
          "Index": 0},
        "ewogICJBY2tub3dsZWRnZUNvbm5lY3Rpb24iOiB7CiAgICAiTWVzc
  2FnZUlEIjogIk5DU1otSFpIUy1RS0xGLUFQNTItMllBQi1aSUlTLVZENksiLAo
  gICAgIkVudmVsb3BlZFJlcXVlc3RDb25uZWN0aW9uIjogW3sKICAgICAgICAiZ
  GlnIjogIlM1MTIiLAogICAgICAgICJJbmRleCI6IDB9LAogICAgICAiZXdvZ0l
  DSlNaWEYxWlhOMFEyOXVibVZqZEdsdmJpSTZJSHNLSUNBZ0lDSlRaWEoyYVdOb
  FMKICBVUWlPaUFpWVd4cFkyVkFaWGhoYlhCc1pTNWpiMjBpTEFvZ0lDQWdJa1Z
  1ZG1Wc2IzQmxaRkJ5YjJacGJHVgogIEVaWFpwWTJVaU9pQmJld29nSUNBZ0lDQ
  WdJQ0prYVdjaU9pQWlVelV4TWlJc0NpQWdJQ0FnSUNBZ0ltTjBlCiAgU0k2SUN
  KaGNIQnNhV05oZEdsdmJpOXRiVzBpZlN3S0lDQWdJQ0FnSW1WM2IyZEpRMHBSW
  TIwNWJXRlhlR3gKICBTUjFZeVlWZE9iRWxxYjJkbGQyOW5TVU5CWjBscmRHeGx
  WVGx0V20xNGNHSnRWbFJoVjJRS0lDQjFXVmhTTQogIFdOdFZXbFBhVUkzUTJsQ
  lowbERRV2RKUTBwV1VrVlphVTlwUVdsVVZVWkpVWGt3TUZNeFJsZE1WVFZoVTJ
  4CiAgcmRGSXhhRk5WUXpGQ1Rnb2dJREZTUzB4VVVscFRWRkYwVVZaYVRsTnBTW
  E5EYVVGblNVTkJaMGxEU2xGa1YKICAwcHpZVmRPVVZsWVNtaGlWMVl3V2xoS2V
  rbHFiMmRsZDI5blNVTkJDaUFnWjBsRFFXZEpRMHBSWkZkS2MyRgogIFhUa3hhV
  0d4R1VUQlNTVWxxYjJkbGQyOW5TVU5CWjBsRFFXZEpRMEZuU1cxT2VXUnBTVFp
  KUTBwR1drUlJNCiAgRThLSUNCRFNYTkRhVUZuU1VOQlowbERRV2RKUTBGcFZVa
  FdhV0pIYkdwSmFtOW5TV3RXVlZSdGJ6UldhM2cKICAxWWtSYVJGSlhkelJQVm1
  SVlUxVm9hRTFyWkFvZ0lGWlpNREZ3VFRGS1dsRldPRFJVV0hBMFYxVldjVll3Z
  QogIEUxaWJIQkVZVzVWTldFeGJ6UldSVzlMU1VOQ05WcFdUbHBWU0VKcVZVZG9
  NbEZVUW5OaUNpQWdWemxyVjBVCiAgMU5tTkhiRFpaTUVWcFpsZ3hPVXhCYjJkS
  lEwRm5TV3QwYkdWVlZuVlpNMG8xWTBoU2NHSXlOR2xQYVVJM1EKICAybEJaMGx
  EUVdkSlEwb0tJQ0JXVWtWWmFVOXBRV2xVVlVaWFZua3dNRlo2WXpCTVZYQkNWR
  VpCZEZkVlNrWgogIFhVekZPVld0d1lVeFdXa2ROTUdOMFRYcFdXRmRwU1hORGF
  VRm5TUW9nSUVOQlowbERTbEZrVjBwellWZE9VCiAgVmxZU21oaVYxWXdXbGhLZ
  WtscWIyZGxkMjluU1VOQlowbERRV2RKUTBwUlpGZEtjMkZYVGt4YVdHeEdVVEI
  KICBTQ2lBZ1NVbHFiMmRsZDI5blNVTkJaMGxEUVdkSlEwRm5TVzFPZVdScFNUW
  kpRMHBHV2tSUk1FOURTWE5EYQogIFVGblNVTkJaMGxEUVdkSlEwRnBWVWhXYVd
  JS0lDQkhiR3BKYW05blNXNU9RMVpYU25Oa1JsSlRVbFphZDB4CiAgV1NYZFJWM
  lJ1V2xkb1NFOVhTak5PUjNONFlqQjBTMU5IVG01bGJEbHZVMnBXTldFd1pBb2d
  JR3RUUkZKR1YKICAydDBVRlZ1VG1oWFdFMUxTVU5DYkdKVVJrTlBWa1V5VFc1S
  1MyTkhkRU5hYkVwS1UwaFdXR1JYTlhsU1ZVVgogIHBabGd4T1V4QmIyZEpDaUF
  nUTBGblNXdDBiR1ZWUmpGa1IyaHNZbTVTY0ZreVJqQmhWemwxU1dwdloyVjNiC
  iAgMmRKUTBGblNVTkJhVlpWVWtkSmFtOW5TV3N4UlZGVlNYUlJWRklLSUNCVVZ
  WTXdNbEpFVVhsTVZscFJWSHAKICBOZEZKVVl6QlNVekZHVFd4d1FreFZhRlpVY
  TFWcFRFRnZaMGxEUVdkSlEwRnBWVWhXYVdKSGJHcFZSMFo1VwogIFFvZ0lGY3h
  iR1JIVm5samVVazJTVWh6UzBsRFFXZEpRMEZuU1VOQmFWVklWbWxpUjJ4cVV6S
  ldOVkpWVGtWCiAgVFEwazJTVWh6UzBsRFFXZEpRMEZuU1VOQkNpQWdaMGxEU21
  wamJsbHBUMmxCYVZKWFVUQk9SR2RwVEVGdloKICAwbERRV2RKUTBGblNVTkJaM
  GxzUWpGWmJYaHdXWGxKTmtsRFNrOWxWV2hWWWtoT2QwMEtJQ0F5UlRCWlZrWgo
  gIFVUa2RPZVdSVk1VNWpWekV3VFVjNU5VNXNXVE5hTWpGdlZIa3hlVnByWkdaY
  U1VMHlWV3hHUmxSSFduWlRNCiAgVlpIVjFWSk1VTnBRUW9nSUdkVVdFNU5ZVEp
  rTUZvd1VuUlNNVGt4VXpBNVVVNUZOSHBOV0dNeVV6STVRa2wKICB1TVRsbVdER
  TVJaXdLSUNBZ0lDQWdld29nSUNBZ0lDQWdJQ0p6YVdkdVlYUjFjbVZ6SWpvZ1c
  zc0tJQ0FnSQogIENBZ0lDQWdJQ0FnSW5OcFoyNWhkSFZ5WlNJNklDSm5ZMUZ2T
  lVONWExQTNkMHRxWm1ZeloweHNiazR6TFhKCiAgRFRWUXhUbGRLUjFwRlZtczN
  ZMDFLTm5jd1JHeDZRM0kyQ2lBZ1JIVktRMWd4TVhOM1dtNUdYMWRtTTIwNWMKI
  CBXcDFZa010VVdGQk0xSnBVVXcwTkhGd1puSmhWekEzZFhkUlh6RTFPRVJMVG1
  OMFQzTkVMVTVQWkhvS0lDQgogIHNTa0p2UzFKUGVqSk5YMGR5VEVSMGJ6YzNaR
  EJwWTNaTVRucEJiVVpYWmtacGRFaENRbWRKUVNKOVhTd0tJCiAgQ0FnSUNBZ0l
  DQWlVR0Y1Ykc5aFpFUnBaMlZ6ZENJNklDSk9kekIyZWtWRVkxcDFkRmc0ZFhCc
  VVrUndNRFIKICB4UzNSR04yNU9kRmhWVUZCRVVqaGFOVU5MTm1KUmQya0tJQ0J
  HY205dE9FSmlWR0pyVEVoWllWTjRiV0ZJUwogIEVsc1UwaGhNRzU1T0Y5R2FGS
  ktYMWxIVGtKUFp5SjlYU3dLSUNBZ0lDSkRiR2xsYm5ST2IyNWpaU0k2SUNKCiA
  gdGJGWnZOV2syUlU0elJ6QmxTVU5QU0VSaU9HdG5JbjE5IiwKICAgICAgewogI
  CAgICAgICJzaWduYXR1cmVzIjogW3sKICAgICAgICAgICAgInNpZ25hdHVyZSI
  6ICJoQ1lxSGliUEtET2NxNTlHcEl1RHdUcU82YXZJSzFZMjVLTnN3bDN5OHV0a
  mlEYzZJCiAgSDZDYlpLZW5sRDg0dmkxZ3VDV3MzdDJ1WUVBZEtEdmdhdDlYa0d
  OVjBBa2FzS1ZxejRtMWNLWkJud0xRZjEKICBqYkdFWXJCNXJQZnRPOTU3dGExR
  lhWclFSMFZfQ2c1Z0otNHhzSFNJQSJ9XSwKICAgICAgICAiUGF5bG9hZERpZ2V
  zdCI6ICJqb0hxZTVMbXNTNWxFbW1Hd1duY1I4eW1jODBpYjI4RC1za2Noelgwa
  zBiZUsKICBvQmhNQ2pyekFsMHRsMElMTlhuT0F4YnNTQ0RsczJpWjFSX3RBdml
  RUSJ9XSwKICAgICJTZXJ2ZXJOb25jZSI6ICIwNTU5Wl9fRDV1UlcxQWVpb2R0R
  mh3IiwKICAgICJXaXRuZXNzIjogIlFSUTMtM0xDRy1OVU41LVc3Q0otUFBMQi0
  0Q0FNLTY0QVgifX0"],
      "EnvelopedAccountAssertion": [{
          "dig": "S512",
          "Index": 0},
        "ewogICJQcm9maWxlQWNjb3VudCI6IHsKICAgICJTZXJ2aWNlSURzI
  jogWyJhbGljZUBleGFtcGxlLmNvbSJdLAogICAgIk1lc2hQcm9maWxlVURGIjo
  gIk1DNkYtRlc2UC1MSE81LURTNFAtUVVCWi0zVjdTLTZRWDciLAogICAgIktle
  UVuY3J5cHRpb24iOiB7CiAgICAgICJVREYiOiAiTUFDVS1MWjY3LUVFSUotTDd
  XQS1KVVVLLVVFM0otQ0cyTSIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjoge
  wogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJ
  FZDQ0OCIsCiAgICAgICAgICAiUHVibGljIjogImpDZUNSdDBOOXVVMkZOclNqZ
  m1HZDZScHJuTHlmTlhHLUEyVEY5bGFRRzhGTzZCSW96WFcKICBrS3JXRTFqYzg
  5S1pLUmJOay1aZXkxYUEifX19fX0",
        {
          "signatures": [{
              "signature": "R5CFZnt093ltxGubf4i3DkixYiEAeTYjAypuHgkm3x-VDng0E
  Vn5U5DoSlR3GGokzlUGrJO3ZqgADpIP1H0uoWJjbVjMzDRlQyJoeLV4bn43Kg4
  fAZ0LWiuz7b9IEVnqAnCuyBO3khQkiw8cJSc5OQQA"}],
          "PayloadDigest": "d5wzt_c7DHNsareinG9yceCeeRRPRPXm_GGGKWoRCdaKh
  LQdCbGyDYuPyyOjdxeAVsZKf89g5MXLWsVqGRc2TA"}]}}}
````


