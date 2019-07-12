

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
Alice> device accept NBTB-ZC3R-44LZ-WRJ2-FTTP-F3K3-6TUA
````

Specifying the /json option returns a result of type ResultConnectProcess:

````
Alice> device accept NBTB-ZC3R-44LZ-WRJ2-FTTP-F3K3-6TUA /json
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
Alice> device accept NBTB-ZC3R-44LZ-WRJ2-FTTP-F3K3-6TUA
````

Specifying the /json option returns a result of type ResultConnectProcess:

````
Alice> device accept NBTB-ZC3R-44LZ-WRJ2-FTTP-F3K3-6TUA /json
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
Alice> device delete NBTB-ZC3R-44LZ-WRJ2-FTTP-F3K3-6TUA
ERROR - The feature has not been implemented
````

Specifying the /json option returns a result of type Result:

````
Alice> device delete NBTB-ZC3R-44LZ-WRJ2-FTTP-F3K3-6TUA /json
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
Alice> device earl udf://example.com/EDHA-N63D-TGO3-D6Y6-45WV-32QG-YBBZ-6A
ERROR - Object reference not set to an instance of an object.
````

Specifying the /json option returns a result of type Result:

````
Alice> device earl udf://example.com/EDHA-N63D-TGO3-D6Y6-45WV-32QG-YBBZ-6A /json
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
        "MessageID": "NBTB-ZC3R-44LZ-WRJ2-FTTP-F3K3-6TUA",
        "EnvelopedRequestConnection": [{
            "dig": "S512",
            "Index": 0},
          "ewogICJSZXF1ZXN0Q29ubmVjdGlvbiI6IHsKICAgICJTZXJ2aWNlS
  UQiOiAiYWxpY2VAZXhhbXBsZS5jb20iLAogICAgIkVudmVsb3BlZFByb2ZpbGV
  EZXZpY2UiOiBbewogICAgICAgICJkaWciOiAiUzUxMiIsCiAgICAgICAgImN0e
  SI6ICJhcHBsaWNhdGlvbi9tbW0ifSwKICAgICAgImV3b2dJQ0pRY205bWFXeGx
  SR1YyYVdObElqb2dld29nSUNBZ0lrdGxlVTltWm14cGJtVlRhV2QKICB1WVhSM
  WNtVWlPaUI3Q2lBZ0lDQWdJQ0pWUkVZaU9pQWlUVUZGUkMxUE5EUlJMVU0xU1Z
  RdFV6UlFVaTFFVgogIGpNMUxVcFJWMUF0UVVNM1NDSXNDaUFnSUNBZ0lDSlFkV
  0pzYVdOUVlYSmhiV1YwWlhKeklqb2dld29nSUNBCiAgZ0lDQWdJQ0pRZFdKc2F
  XTkxaWGxGUTBSSUlqb2dld29nSUNBZ0lDQWdJQ0FnSW1OeWRpSTZJQ0pGWkRRM
  E8KICBDSXNDaUFnSUNBZ0lDQWdJQ0FpVUhWaWJHbGpJam9nSWxsT00zaE1NVmx
  DWWxwcmNYTXpNMVpJY2taUVVXMQogIFRNRzVQVWxGRlJIZHdUMVo2WWxwME5EW
  m1MVkJIV0doeU0wbEpOMFVLSUNCcVZreGpUWE01T1Y5UGVGOWtlCiAgVEZET1Z
  saVZVTnhkVUVpZlgxOUxBb2dJQ0FnSWt0bGVVVnVZM0o1Y0hScGIyNGlPaUI3Q
  2lBZ0lDQWdJQ0oKICBWUkVZaU9pQWlUVVJYTXkweVQxRk9MVXROVWtJdFVUUkR
  TaTFhU0ZZeUxVdFFTVmN0U1RVek5pSXNDaUFnSQogIENBZ0lDSlFkV0pzYVdOU
  VlYSmhiV1YwWlhKeklqb2dld29nSUNBZ0lDQWdJQ0pRZFdKc2FXTkxaWGxGUTB
  SCiAgSUlqb2dld29nSUNBZ0lDQWdJQ0FnSW1OeWRpSTZJQ0pGWkRRME9DSXNDa
  UFnSUNBZ0lDQWdJQ0FpVUhWaWIKICBHbGpJam9nSWsxMlQxUXhTMGd0UmxaTFZ
  uZFBlVjg0V2pSeldITk1iMlJDVXpSUlpscFlVV2hpUTJsc1gxQgogIEhhR0ZwV
  G5wdWMzcERXRUVLSUNCYVdETXpNV2hRVlZvelF6SmFSemhmTmtSUkxXbFphMEV
  pZlgxOUxBb2dJCiAgQ0FnSWt0bGVVRjFkR2hsYm5ScFkyRjBhVzl1SWpvZ2V3b
  2dJQ0FnSUNBaVZVUkdJam9nSWsxQlVrOHROMHAKICBETkMxWFNrOVdMVXRVVGp
  RdE4wOWFVUzFPTmtoTkxVTlZXVllpTEFvZ0lDQWdJQ0FpVUhWaWJHbGpVR0Z5W
  QogIFcxbGRHVnljeUk2SUhzS0lDQWdJQ0FnSUNBaVVIVmliR2xqUzJWNVJVTkV
  TQ0k2SUhzS0lDQWdJQ0FnSUNBCiAgZ0lDSmpjbllpT2lBaVJXUTBORGdpTEFvZ
  0lDQWdJQ0FnSUNBZ0lsQjFZbXhwWXlJNklDSTBXalozTkVKUlkKICBXaGhXSEZ
  SV2poU1pXcEZOMlZ6T0RBeFpWQTBiMll6VjFaWFJtMVlORlpYT0hwU05reHFhS
  FpRWmtGdENpQQogIGdTRmsyUjJsTFJuVnVlbU5KWVhKdk9FOU9SMEZLZUZsQkl
  uMTlmWDE5IiwKICAgICAgewogICAgICAgICJzaWduYXR1cmVzIjogW3sKICAgI
  CAgICAgICAgInNpZ25hdHVyZSI6ICJNWExJQWRzcFVLNjMyQklwWHhPamFjU3J
  sRGZURHYyM2p2dV8xYU4zODJTZWxNZ2E1CiAgMjJsM1pnemVuam1oaEh6THRlW
  WVDWE9rQmNBQ1AyaFBMNU9rNjJBbGdLYWtpYTVHMnBTYzBHTE41cGZNQWoKICA
  wX1NPbzFmMmhLWjJHYVJ3SlJmVG5lTm9rai1OcEJjcmNoZFh5c0Q4QSJ9XSwKI
  CAgICAgICAiUGF5bG9hZERpZ2VzdCI6ICJhdlIydHg2WDdpRWpaSXJFcEVJWEZ
  hYm5LVDZmc0toNmNrelJ1Wld5QTkzNUwKICBFX1FkQVpOZ3RKNlMwMFBfeTgzb
  E1Eenc4VGk4cEdjcE5XSlg0WlJJZyJ9XSwKICAgICJDbGllbnROb25jZSI6ICJ
  IbGNsVjBIUWcxVlhXMnYwWFJmZllRIn19",
          {
            "signatures": [{
                "signature": "wenhV5tpFuJJk1X_8LDHql_rSbXn1jF5pVRTZi1l67YFWvK0r
  Til7Lz24fpXl4sE1ypgl1D_phgApNUexXJJ4IQ-diIqHx0oFD1EuhQ1uV3RjgV
  7T7jUd6Wcdn3Nhbg4b5K9kJ2leB_cZHRMocwXdxMA"}],
            "PayloadDigest": "Ahr_KG6VYEzFG0iISj_l2x0pXfGLwIgJmMceoBjhEx4o9
  umenhhslbFon5dw961FUM8qA3StcfyumcbBEVLQbA"}],
        "ServerNonce": "DSv11poeA7bUUWmn5LNhzw",
        "Witness": "6D7S-QUSO-4XUJ-FTBQ-6RGP-JBGU-CDWR"}]}}
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
Alice4> device pre devices@example.com /key=udf://example.com/EDHA-N63D-TGO3-D6Y6-45WV-32QG-YBBZ-6A
ERROR - Object reference not set to an instance of an object.
````

Specifying the /json option returns a result of type Result:

````
Alice4> device pre devices@example.com /key=udf://example.com/EDHA-N63D-TGO3-D6Y6-45WV-32QG-YBBZ-6A /json
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
   Witness value = 6D7S-QUSO-4XUJ-FTBQ-6RGP-JBGU-CDWR
   Personal Mesh = MCE7-VDTJ-UIEB-6YDB-O5WX-Y747-3OF3
````

Specifying the /json option returns a result of type ResultConnect:

````
Alice2> device request alice@example.com /json
{
  "ResultConnect": {
    "Success": true,
    "CatalogedMachine": {
      "ID": "MAED-O44Q-C5IT-S4PR-DV35-JQWP-AC7H",
      "EnvelopedProfileMaster": [{
          "dig": "S512",
          "Index": 0},
        "ewogICJQcm9maWxlUGVyc29uYWwiOiB7CiAgICAiS2V5T2ZmbGluZ
  VNpZ25hdHVyZSI6IHsKICAgICAgIlVERiI6ICJNQ0U3LVZEVEotVUlFQi02WUR
  CLU81V1gtWTc0Ny0zT0YzIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7C
  iAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIkV
  kNDQ4IiwKICAgICAgICAgICJQdWJsaWMiOiAiRFBNVzA5QTgzSG0xWDBfYno1M
  nBhNllZTHpsaW5oZEozRHMxdlA2VW1NdUtJaW5xbVFDSgogIFF4dmlvd1hZaXN
  SOXVxMnl0V2NMWXJ3QSJ9fX0sCiAgICAiS2V5c09ubGluZVNpZ25hdHVyZSI6I
  Ft7CiAgICAgICAgIlVERiI6ICJNQUE1LTdYWE8tU1ZKTS1RNkRDLU42UVItQVl
  UNC1BMktXIiwKICAgICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgI
  CAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgICAiY3J2IjogIkVkNDQ
  4IiwKICAgICAgICAgICAgIlB1YmxpYyI6ICJOeFhwLUNvcENEUDZLMnlyazlHM
  VM5WTNXM2pRd2VSSFNqUGVZSXk3TDJkR2kwLW5oeDBDCiAgMVplOENhSlVXbWI
  3UUNXemFmN1BDMUdBIn19fV0sCiAgICAiS2V5RW5jcnlwdGlvbiI6IHsKICAgI
  CAgIlVERiI6ICJNQ1lULUVWRkotUFIzNy1CSzRZLTRWSUMtNkJVSy1BUENHIiw
  KICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tle
  UVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIkVkNDQ4IiwKICAgICAgICAgICJ
  QdWJsaWMiOiAibnlQS082MVlRaEJ4ZzBWc0Q4RzUxRy02UHVkaXZhM0pmX0dTV
  jRONWkxRU9vWlo0NzNhRwogIHR3SUJ5SXB3VFR3NzRCdGFFcUJsY0QyQSJ9fX1
  9fQ",
        {
          "signatures": [{
              "signature": "C2OzTqk7F3_bAuHrc118oOr3TB-YrvIHvK9q6PTAYd8KwmQ59
  PWntcejm9c8Wi5l7SMNQa5oATSA2C2jHk1Evva-8AmWmFUwC367V53-iT1_18g
  7TuoLqgKLdyFB6Hz3xxvoujfVfxmeIlaPeCPGDSkA"}],
          "PayloadDigest": "VuAdBQCNbH-XU1cRST7esFXHMWVkmicc5v4OpoQeoAH5x
  ugkMNC0Ciz9OcSP4XhvgZXLxH2rLLHeGEj3STvIfg"}],
      "DeviceUDF": "MAED-O44Q-C5IT-S4PR-DV35-JQWP-AC7H",
      "EnvelopedMessageConnectionResponse": [{
          "Index": 0},
        "ewogICJBY2tub3dsZWRnZUNvbm5lY3Rpb24iOiB7CiAgICAiTWVzc
  2FnZUlEIjogIk5CVEItWkMzUi00NExaLVdSSjItRlRUUC1GM0szLTZUVUEiLAo
  gICAgIkVudmVsb3BlZFJlcXVlc3RDb25uZWN0aW9uIjogW3sKICAgICAgICAiZ
  GlnIjogIlM1MTIiLAogICAgICAgICJJbmRleCI6IDB9LAogICAgICAiZXdvZ0l
  DSlNaWEYxWlhOMFEyOXVibVZqZEdsdmJpSTZJSHNLSUNBZ0lDSlRaWEoyYVdOb
  FMKICBVUWlPaUFpWVd4cFkyVkFaWGhoYlhCc1pTNWpiMjBpTEFvZ0lDQWdJa1Z
  1ZG1Wc2IzQmxaRkJ5YjJacGJHVgogIEVaWFpwWTJVaU9pQmJld29nSUNBZ0lDQ
  WdJQ0prYVdjaU9pQWlVelV4TWlJc0NpQWdJQ0FnSUNBZ0ltTjBlCiAgU0k2SUN
  KaGNIQnNhV05oZEdsdmJpOXRiVzBpZlN3S0lDQWdJQ0FnSW1WM2IyZEpRMHBSW
  TIwNWJXRlhlR3gKICBTUjFZeVlWZE9iRWxxYjJkbGQyOW5TVU5CWjBscmRHeGx
  WVGx0V20xNGNHSnRWbFJoVjJRS0lDQjFXVmhTTQogIFdOdFZXbFBhVUkzUTJsQ
  lowbERRV2RKUTBwV1VrVlphVTlwUVdsVVZVWkdVa014VUU1RVVsSk1WVTB4VTF
  aCiAgUmRGVjZVbEZWYVRGRlZnb2dJR3BOTVV4VmNGSldNVUYwVVZWTk0xTkRTW
  E5EYVVGblNVTkJaMGxEU2xGa1YKICAwcHpZVmRPVVZsWVNtaGlWMVl3V2xoS2V
  rbHFiMmRsZDI5blNVTkJDaUFnWjBsRFFXZEpRMHBSWkZkS2MyRgogIFhUa3hhV
  0d4R1VUQlNTVWxxYjJkbGQyOW5TVU5CWjBsRFFXZEpRMEZuU1cxT2VXUnBTVFp
  KUTBwR1drUlJNCiAgRThLSUNCRFNYTkRhVUZuU1VOQlowbERRV2RKUTBGcFZVa
  FdhV0pIYkdwSmFtOW5TV3hzVDAwemFFMU5WbXgKICBEV1d4d2NtTllUWHBOTVZ
  wSlkydGFVVlZYTVFvZ0lGUk5SelZRVld4R1JsSklaSGRVTVZvMldXeHdNRTVFV
  wogIG0xTVZrSklWMGRvZVUwd2JFcE9NRlZMU1VOQ2NWWnJlR3BVV0UwMVQxWTV
  VR1ZHT1d0bENpQWdWRVpFVDFaCiAgc2FWWlZUbmhrVlVWcFpsZ3hPVXhCYjJkS
  lEwRm5TV3QwYkdWVlZuVlpNMG8xWTBoU2NHSXlOR2xQYVVJM1EKICAybEJaMGx
  EUVdkSlEwb0tJQ0JXVWtWWmFVOXBRV2xVVlZKWVRYa3dlVlF4Ums5TVZYUk9WV
  3RKZEZWVVVrUgogIFRhVEZoVTBaWmVVeFZkRkZUVm1OMFUxUlZlazVwU1hORGF
  VRm5TUW9nSUVOQlowbERTbEZrVjBwellWZE9VCiAgVmxZU21oaVYxWXdXbGhLZ
  WtscWIyZGxkMjluU1VOQlowbERRV2RKUTBwUlpGZEtjMkZYVGt4YVdHeEdVVEI
  KICBTQ2lBZ1NVbHFiMmRsZDI5blNVTkJaMGxEUVdkSlEwRm5TVzFPZVdScFNUW
  kpRMHBHV2tSUk1FOURTWE5EYQogIFVGblNVTkJaMGxEUVdkSlEwRnBWVWhXYVd
  JS0lDQkhiR3BKYW05blNXc3hNbFF4VVhoVE1HZDBVbXhhVEZaCiAgdVpGQmxWa
  mcwVjJwU2VsZElUazFpTWxKRFZYcFNVbHBzY0ZsVlYyaHBVVEpzYzFneFFnb2d
  JRWhoUjBad1YKICBHNXdkV016Y0VSWFJVVkxTVU5DWVZkRVRYcE5WMmhSVmxad
  mVsRjZTbUZTZW1obVRtdFNVa3hYYkZwaE1FVgogIHBabGd4T1V4QmIyZEpDaUF
  nUTBGblNXdDBiR1ZWUmpGa1IyaHNZbTVTY0ZreVJqQmhWemwxU1dwdloyVjNiC
  iAgMmRKUTBGblNVTkJhVlpWVWtkSmFtOW5TV3N4UWxWck9IUk9NSEFLSUNCRVR
  rTXhXRk5yT1ZkTVZYUlZWR3AKICBSZEU0d09XRlZVekZQVG10b1RreFZUbFpYV
  mxscFRFRnZaMGxEUVdkSlEwRnBWVWhXYVdKSGJHcFZSMFo1VwogIFFvZ0lGY3h
  iR1JIVm5samVVazJTVWh6UzBsRFFXZEpRMEZuU1VOQmFWVklWbWxpUjJ4cVV6S
  ldOVkpWVGtWCiAgVFEwazJTVWh6UzBsRFFXZEpRMEZuU1VOQkNpQWdaMGxEU21
  wamJsbHBUMmxCYVZKWFVUQk9SR2RwVEVGdloKICAwbERRV2RKUTBGblNVTkJaM
  GxzUWpGWmJYaHdXWGxKTmtsRFNUQlhhbG96VGtWS1Vsa0tJQ0JYYUdoWFNFWgo
  gIFNWMnBvVTFwWGNFWk9NbFo2VDBSQmVGcFdRVEJpTWxsNlZqRmFXRkp0TVZsT
  1JscFlUMGh3VTA1cmVIRmhTCiAgRnBSV210R2RFTnBRUW9nSUdkVFJtc3lVakp
  zVEZKdVZuVmxiVTVLV1ZoS2RrOUZPVTlTTUVaTFpVWnNRa2wKICB1TVRsbVdER
  TVJaXdLSUNBZ0lDQWdld29nSUNBZ0lDQWdJQ0p6YVdkdVlYUjFjbVZ6SWpvZ1c
  zc0tJQ0FnSQogIENBZ0lDQWdJQ0FnSW5OcFoyNWhkSFZ5WlNJNklDSk5XRXhKU
  VdSemNGVkxOak15UWtsd1dIaFBhbUZqVTNKCiAgc1JHWlVSSFl5TTJwMmRWOHh
  ZVTR6T0RKVFpXeE5aMkUxQ2lBZ01qSnNNMXBuZW1WdWFtMW9hRWg2VEhSbFcKI
  CBXVkRXRTlyUW1OQlExQXlhRkJNTlU5ck5qSkJiR2RMWVd0cFlUVkhNbkJUWXp
  CSFRFNDFjR1pOUVdvS0lDQQogIHdYMU5QYnpGbU1taExXakpIWVZKM1NsSm1WR
  zVsVG05cmFpMU9jRUpqY21Ob1pGaDVjMFE0UVNKOVhTd0tJCiAgQ0FnSUNBZ0l
  DQWlVR0Y1Ykc5aFpFUnBaMlZ6ZENJNklDSmhkbEl5ZEhnMldEZHBSV3BhU1hKR
  mNFVkpXRVoKICBoWW01TFZEWm1jMHRvTm1OcmVsSjFXbGQ1UVRrek5Vd0tJQ0J
  GWDFGa1FWcE9aM1JLTmxNd01GQmZlVGd6YgogIEUxRWVuYzRWR2s0Y0VkamNFN
  VhTbGcwV2xKSlp5SjlYU3dLSUNBZ0lDSkRiR2xsYm5ST2IyNWpaU0k2SUNKCiA
  gSWJHTnNWakJJVVdjeFZsaFhNbll3V0ZKbVpsbFJJbjE5IiwKICAgICAgewogI
  CAgICAgICJzaWduYXR1cmVzIjogW3sKICAgICAgICAgICAgInNpZ25hdHVyZSI
  6ICJ3ZW5oVjV0cEZ1SkprMVhfOExESHFsX3JTYlhuMWpGNXBWUlRaaTFsNjdZR
  ld2SzByCiAgVGlsN0x6MjRmcFhsNHNFMXlwZ2wxRF9waGdBcE5VZXhYSko0SVE
  tZGlJcUh4MG9GRDFFdWhRMXVWM1JqZ1YKICA3VDdqVWQ2V2NkbjNOaGJnNGI1S
  zlrSjJsZUJfY1pIUk1vY3dYZHhNQSJ9XSwKICAgICAgICAiUGF5bG9hZERpZ2V
  zdCI6ICJBaHJfS0c2VllFekZHMGlJU2pfbDJ4MHBYZkdMd0lnSm1NY2VvQmpoR
  Xg0bzkKICB1bWVuaGhzbGJGb241ZHc5NjFGVU04cUEzU3RjZnl1bWNiQkVWTFF
  iQSJ9XSwKICAgICJTZXJ2ZXJOb25jZSI6ICJEU3YxMXBvZUE3YlVVV21uNUxOa
  Hp3IiwKICAgICJXaXRuZXNzIjogIjZEN1MtUVVTTy00WFVKLUZUQlEtNlJHUC1
  KQkdVLUNEV1IifX0"],
      "EnvelopedAccountAssertion": [{
          "dig": "S512",
          "Index": 0},
        "ewogICJQcm9maWxlQWNjb3VudCI6IHsKICAgICJTZXJ2aWNlSURzI
  jogWyJhbGljZUBleGFtcGxlLmNvbSJdLAogICAgIk1lc2hQcm9maWxlVURGIjo
  gIk1DRTctVkRUSi1VSUVCLTZZREItTzVXWC1ZNzQ3LTNPRjMiLAogICAgIktle
  UVuY3J5cHRpb24iOiB7CiAgICAgICJVREYiOiAiTUFJVC1IWDZQLUNQSUYtM0Z
  ETy1ERURGLUlTWjQtSjRHMiIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjoge
  wogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJ
  FZDQ0OCIsCiAgICAgICAgICAiUHVibGljIjogInFEX2c4cHVOaHhBXzJPVGMxc
  HZWc2JhTTJKRHltX1lOekxNdHRyeUl0Ulk1S0Qya2FtM3QKICA4LUhGcGtiV3Z
  MMVQ3SjJGQkhWR3h6VUEifX19fX0",
        {
          "signatures": [{
              "signature": "TOjK2AgpvO2UCwJILSlsYdoERcQVIneuGS8JeNCHA7gFCHlyk
  rSTfgoENeimiv3Y_q1oCi1EK3gAoXyVtOd62xWQPhG05IG9fQKXqDcTxZf6Jjv
  xrvWRhDxdyG6NeCMs019BQBWYzB4or--Czi031jIA"}],
          "PayloadDigest": "btqFIz1UpjrFfTMSMJcyLssLy1E2e3ZbiQ_kkiBtq3zSe
  3F6V8G98hpG7oQMgr_GIZCbDsx6XKdbBm1jyD5hKw"}]}}}
````


