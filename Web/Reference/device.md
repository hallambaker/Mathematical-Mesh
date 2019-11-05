

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
Alice> device accept NB4R-GVWN-KZRU-5EQ4-444I-3FGG-67FL
````

Specifying the /json option returns a result of type ResultConnectProcess:

````
Alice> device accept NB4R-GVWN-KZRU-5EQ4-444I-3FGG-67FL /json
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
Alice> device accept NB4R-GVWN-KZRU-5EQ4-444I-3FGG-67FL
````

Specifying the /json option returns a result of type ResultConnectProcess:

````
Alice> device accept NB4R-GVWN-KZRU-5EQ4-444I-3FGG-67FL /json
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
Alice> device delete NB4R-GVWN-KZRU-5EQ4-444I-3FGG-67FL
ERROR - The feature has not been implemented
````

Specifying the /json option returns a result of type Result:

````
Alice> device delete NB4R-GVWN-KZRU-5EQ4-444I-3FGG-67FL /json
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
Alice> device earl udf://example.com/ECX5-RCFP-OJDO-6ZBR-SORQ-P7BH-XZQS-LD
ERROR - Object reference not set to an instance of an object.
````

Specifying the /json option returns a result of type Result:

````
Alice> device earl udf://example.com/ECX5-RCFP-OJDO-6ZBR-SORQ-P7BH-XZQS-LD /json
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
        "MessageID": "NB4R-GVWN-KZRU-5EQ4-444I-3FGG-67FL",
        "EnvelopedRequestConnection": [{},
          "ewogICJSZXF1ZXN0Q29ubmVjdGlvbiI6
  IHsKICAgICJTZXJ2aWNlSUQiOiAiYWxpY2VAZXhhbXBsZS5jb20iLAogICAgIk
  VudmVsb3BlZFByb2ZpbGVEZXZpY2UiOiBbewogICAgICAgICJkaWciOiAiUzUx
  MiJ9LAogICAgICAiZXdvZ0lDSlFjbTltYVd4bFJHVjJhV05sSWpvZ2V3b2dJQ0
  FnSWt0bGVVOW1abXhwYm1WVGFXZAogIHVZWFIxY21VaU9pQjdDaUFnSUNBZ0lD
  SlZSRVlpT2lBaVRVRlhXUzB6UTFaQkxVTmFWRkF0UnpaRVZ5MVdSCiAgVVZGTF
  U1VVMxa3RXazlEV1NJc0NpQWdJQ0FnSUNKUWRXSnNhV05RWVhKaGJXVjBaWEp6
  SWpvZ2V3b2dJQ0EKICBnSUNBZ0lDSlFkV0pzYVdOTFpYbEZRMFJJSWpvZ2V3b2
  dJQ0FnSUNBZ0lDQWdJbU55ZGlJNklDSkZaRFEwTwogIENJc0NpQWdJQ0FnSUNB
  Z0lDQWlVSFZpYkdsaklqb2dJbTVIWlcxdU5WQkVVbXM1YWxad1gxVmZOWGhCWm
  5rCiAgNVFsazRWRUowVlRFM1pVNUdRemhaWHpGWFRUWnVkelV6YWpGeU1UUUtJ
  Q0JVWkZwYVZUbDVjams0VmtGWWIKICAyaG5abFpmVEVSTFYwRWlmWDE5TEFvZ0
  lDQWdJa3RsZVVWdVkzSjVjSFJwYjI0aU9pQjdDaUFnSUNBZ0lDSgogIFZSRVlp
  T2lBaVRVRldTaTFSVmxSQ0xWWkJUMDh0UjFOUFJDMVdVa3BFTFZCS1dETXRUVE
  5OVWlJc0NpQWdJCiAgQ0FnSUNKUWRXSnNhV05RWVhKaGJXVjBaWEp6SWpvZ2V3
  b2dJQ0FnSUNBZ0lDSlFkV0pzYVdOTFpYbEZRMFIKICBJSWpvZ2V3b2dJQ0FnSU
  NBZ0lDQWdJbU55ZGlJNklDSkZaRFEwT0NJc0NpQWdJQ0FnSUNBZ0lDQWlVSFZp
  YgogIEdsaklqb2dJazVHWVZGeExTMVpaakZ0VEdnMFFUWTJiMnhxZFhKSVFWOH
  hOMFpETWtNelFVbGZZV3BXU200CiAgMk1ERnFVMFExZDNSVmRXMEtJQ0JZYWpW
  TmJtaDFjMUptTUZrd1gyMVNWMWhQV1daeWQwRWlmWDE5TEFvZ0kKICBDQWdJa3
  RsZVVGMWRHaGxiblJwWTJGMGFXOXVJam9nZXdvZ0lDQWdJQ0FpVlVSR0lqb2dJ
  azFDVERVdFIwOQogIFNWeTFETTFRM0xVTmFSRlF0VUVGWlZ5MUxTa3hSTFU4el
  dsY2lMQW9nSUNBZ0lDQWlVSFZpYkdsalVHRnlZCiAgVzFsZEdWeWN5STZJSHNL
  SUNBZ0lDQWdJQ0FpVUhWaWJHbGpTMlY1UlVORVNDSTZJSHNLSUNBZ0lDQWdJQ0
  EKICBnSUNKamNuWWlPaUFpUldRME5EZ2lMQW9nSUNBZ0lDQWdJQ0FnSWxCMVlt
  eHBZeUk2SUNKUFNXUkJPV2s1UgogIDBoaVNUVjZZbUZtYTE5cE1ISnNhbGhZUj
  FOa00ydzRVa3BtTWtkclpraDZNRXRKWjFGalNteDBZa0oxQ2lBCiAgZ1MyMDVh
  SEp3YVZwR1VpMVdUbUpEYm0wd2VFOWxTR1ZCSW4xOWZYMTkiLAogICAgICB7Ci
  AgICAgICAgInNpZ25hdHVyZXMiOiBbewogICAgICAgICAgICAiYWxnIjogIlM1
  MTIiLAogICAgICAgICAgICAia2lkIjogIk1BV1ktM0NWQS1DWlRQLUc2RFctVk
  VFRS1OVEtZLVpPQ1kiLAogICAgICAgICAgICAic2lnbmF0dXJlIjogIkNBTDRY
  MEtsSDcwT0NTUTBGVUx1OVFIdlZ5SGpwcF81aG1vWHNXYVFGOW5SbU9JNmsKIC
  BwMkhxakhhUzFKaGVwX1QwcVFUNDdhd2xxU0FqYU0zVnJ2bXd6RnVVeEdySW1R
  eGtFYjQ0V0ZpdWRWOVFlWAogIElFemVSdTNRd2JKTldqYk5mVjA3dXFSUnNfam
  E4NUVGX3g0Tk5peFlBIn1dLAogICAgICAgICJQYXlsb2FkRGlnZXN0IjogInpI
  WFpSMUJvTEVNV3ZaVUVfR2VZTmwxcVI1cjQzSWEwTEZJOWRMWkZpOGVKYgogIE
  swd2Y2b3BUTGpMZ3ZNR0VzaDZHX0pCMXh5dk14azRIeWVYc3hXQk9RIn1dLAog
  ICAgIkNsaWVudE5vbmNlIjogIkJJVXhHeV84VzdCbkc1TF9PWERUaWcifX0"],
        "ServerNonce": "EFzzlc2pCIiu9yMIc5FXIQ",
        "Witness": "EGTX-LUIB-OD67-DA6O-ZYQT-OPXH-NLMR"},
      {
        "MessageID": "NBSG-GQEN-DBOT-64HY-IA6X-QI6Q-6CG6",
        "EnvelopedRequestConnection": [{},
          "ewogICJSZXF1ZXN0Q29ubmVjdGlvbiI6
  IHsKICAgICJTZXJ2aWNlSUQiOiAiYWxpY2VAZXhhbXBsZS5jb20iLAogICAgIk
  VudmVsb3BlZFByb2ZpbGVEZXZpY2UiOiBbewogICAgICAgICJkaWciOiAiUzUx
  MiJ9LAogICAgICAiZXdvZ0lDSlFjbTltYVd4bFJHVjJhV05sSWpvZ2V3b2dJQ0
  FnSWt0bGVVOW1abXhwYm1WVGFXZAogIHVZWFIxY21VaU9pQjdDaUFnSUNBZ0lD
  SlZSRVlpT2lBaVRVRk9VUzFMVWxsTkxVNUpTVmN0TWxGRlV5MUJNCiAgME5ZTF
  VkWFdFRXRRVTVZUnlJc0NpQWdJQ0FnSUNKUWRXSnNhV05RWVhKaGJXVjBaWEp6
  SWpvZ2V3b2dJQ0EKICBnSUNBZ0lDSlFkV0pzYVdOTFpYbEZRMFJJSWpvZ2V3b2
  dJQ0FnSUNBZ0lDQWdJbU55ZGlJNklDSkZaRFEwTwogIENJc0NpQWdJQ0FnSUNB
  Z0lDQWlVSFZpYkdsaklqb2dJa3gzWkVVdFdEUlVjMjFyTVZoNVVHeDJaa2RFZD
  B3CiAgM1RqSjRWRUZYTjNsa01XUlVlblJCTm5adFJ6ZHlRVE53VDJSQ1RrUUtJ
  Q0F5Y25GcldWTnFlblp0TVMxblEKICBqQmtObGMxWm5sWWMwRWlmWDE5TEFvZ0
  lDQWdJa3RsZVVWdVkzSjVjSFJwYjI0aU9pQjdDaUFnSUNBZ0lDSgogIFZSRVlp
  T2lBaVRVSkJVQzFNVWxOWUxWSkpRbEV0VWxCWVJTMDJUMEkxTFRWSk5Fd3RVRn
  BSVXlJc0NpQWdJCiAgQ0FnSUNKUWRXSnNhV05RWVhKaGJXVjBaWEp6SWpvZ2V3
  b2dJQ0FnSUNBZ0lDSlFkV0pzYVdOTFpYbEZRMFIKICBJSWpvZ2V3b2dJQ0FnSU
  NBZ0lDQWdJbU55ZGlJNklDSkZaRFEwT0NJc0NpQWdJQ0FnSUNBZ0lDQWlVSFZp
  YgogIEdsaklqb2dJbmwyVVVaaVQzbExSRWRzZEhwQ1QwWnhUbFYyV2s1dU4yVn
  RjblpTVTFKbk56WnljUzFvVkdzCiAgd2NHdGZRMk4zTFhkcE1YUUtJQ0JWU0VG
  UlpGZEhUbXhhTkMxV1pHMHRVbEJxY2kxaVIwRWlmWDE5TEFvZ0kKICBDQWdJa3
  RsZVVGMWRHaGxiblJwWTJGMGFXOXVJam9nZXdvZ0lDQWdJQ0FpVlVSR0lqb2dJ
  azFCU2tZdFJqTgogIEhUQzFSVVZKUkxVOVRSRFV0V0UxWVRTMVBTRW8yTFRWVk
  0wZ2lMQW9nSUNBZ0lDQWlVSFZpYkdsalVHRnlZCiAgVzFsZEdWeWN5STZJSHNL
  SUNBZ0lDQWdJQ0FpVUhWaWJHbGpTMlY1UlVORVNDSTZJSHNLSUNBZ0lDQWdJQ0
  EKICBnSUNKamNuWWlPaUFpUldRME5EZ2lMQW9nSUNBZ0lDQWdJQ0FnSWxCMVlt
  eHBZeUk2SUNKamFUaFVjRzU1VgogIGxsMlJEUlpabHBTYmpCS1pXbGlNVEJzZV
  ZoU01VZFplVTVOTWpacldtdERRMjFoUm0xS1QwUjZXbkkxQ2lBCiAgZ1VrcG1V
  VVJpTTBGamFEUTVVbXhLWVZkRVgwVnBla2RCSW4xOWZYMTkiLAogICAgICB7Ci
  AgICAgICAgInNpZ25hdHVyZXMiOiBbewogICAgICAgICAgICAiYWxnIjogIlM1
  MTIiLAogICAgICAgICAgICAia2lkIjogIk1BTlEtS1JZTS1OSUlXLTJRRVMtQT
  NDWC1HV1hBLUFOWEciLAogICAgICAgICAgICAic2lnbmF0dXJlIjogInRZNDBy
  bXlRaTc5Q2s4QklXZmJ6d2l1ZVhYUXMwRDdxeFcxdEIzNjMtR19ELXVKZXkKIC
  BJX0sxQWlkNXlPZllDYzU1aUVCWTJ1OENwMkFJWUNSenlkYTRfSzJaWDRQQ01L
  MldMbkdiZEVKTDBFajR3cgogIHYxX0RCekI2UzMwcHgzczgtM3BKTkRJQU5xZ1
  lRSF82UmRCVldGaFlBIn1dLAogICAgICAgICJQYXlsb2FkRGlnZXN0IjogIlZ1
  bkNxUkdZWndId3ZsN09NLS1xZFJ0ZFpOcDRmQy1taUh5UjBwbERzbmp2bwogIG
  tRZlBxanlqbWNwa2dVeHJHT21udGJqNXdMSV9sYm5wWEdlTDJreWxRIn1dLAog
  ICAgIkNsaWVudE5vbmNlIjogIkNud09FSE1qZlpOdDdjcklxU1ZWZVEifX0"],
        "ServerNonce": "s3GY8Luy35IeuYKlZ7B3Cg",
        "Witness": "42B2-7POX-GMLW-6EBC-GKAI-7NDC-7226"}]}}
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
Alice> device reject NBSG-GQEN-DBOT-64HY-IA6X-QI6Q-6CG6
````

Specifying the /json option returns a result of type ResultConnectProcess:

````
Alice> device reject NBSG-GQEN-DBOT-64HY-IA6X-QI6Q-6CG6 /json
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
Alice4> device pre devices@example.com /key=udf://example.com/ECX5-RCFP-OJDO-6ZBR-SORQ-P7BH-XZQS-LD
ERROR - Object reference not set to an instance of an object.
````

Specifying the /json option returns a result of type Result:

````
Alice4> device pre devices@example.com /key=udf://example.com/ECX5-RCFP-OJDO-6ZBR-SORQ-P7BH-XZQS-LD /json
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
   Witness value = 42B2-7POX-GMLW-6EBC-GKAI-7NDC-7226
   Personal Mesh = MA2T-CF6T-DM54-P2UQ-RMYE-SB7W-M3KB
````

Specifying the /json option returns a result of type ResultConnect:

````
Alice2> device request alice@example.com /json
{
  "ResultConnect": {
    "Success": true,
    "CatalogedMachine": {
      "ID": "MANQ-KRYM-NIIW-2QES-A3CX-GWXA-ANXG",
      "EnvelopedProfileMaster": [{
          "dig": "S512"},
        "ewogICJQcm9maWxlTWVzaCI6IHsKICAgICJLZXlPZmZsaW5lU2lnbmF
  0dXJlIjogewogICAgICAiVURGIjogIk1BMlQtQ0Y2VC1ETTU0LVAyVVEtUk1ZR
  S1TQjdXLU0zS0IiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICA
  gICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiL
  AogICAgICAgICAgIlB1YmxpYyI6ICJCb2RyLWJsUHVXY3ZZTkw4cVk5RVZQajY
  4LUVEemdBV2ZvQUt6bjdXXzNKaWUtajM4SVNzCiAgY2xxX0x1YmdqeVVQLWRPb
  XFIQVpOSjRBIn19fSwKICAgICJLZXlzT25saW5lU2lnbmF0dXJlIjogW3sKICA
  gICAgICAiVURGIjogIk1DTUUtWUg2NC1PSlJCLUpVQTctU1lOUC1ORlUyLUpTT
  UUiLAogICAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICAgIlB
  1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogI
  CAgICAgICAgICAiUHVibGljIjogImtaa1JUeE1PcGlWUEVuUFV6SzVqWnFEbWZ
  0cGRLYllLdHlvclNFSEdaOFdLbDNzVkZXNFYKICBiX2lBZHZhTnhwNVg5NzFqd
  V9KcjZqd0EifX19XSwKICAgICJLZXlFbmNyeXB0aW9uIjogewogICAgICAiVUR
  GIjogIk1EWDUtSTNJMy1RQlpJLVVZS0otNlBYUi1MRlJGLVVVSFUiLAogICAgI
  CAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNESCI
  6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAgIlB1YmxpY
  yI6ICJ4bnA4VHRZZVBXTXY1clM1N09xQTAwaDExay1meDN0ZmktS1hzR1Myemt
  4aFRpNVJlUWtNCiAgU1ZodkxvUnJ2a2FXc1JuLTBmZEdzTFNBIn19fX19",
        {
          "signatures": [{
              "alg": "S512",
              "kid": "MA2T-CF6T-DM54-P2UQ-RMYE-SB7W-M3KB",
              "signature": "LQfHMxubuDumjkVp6uQgz4yeeVctoPc0MIY3K-f_4on1q9ysf
  glMjQVb_x9T1KiH55sZ7enfG4qAWId_bV2W2vIavV41ZnXu_io0-irEJOV8wG8
  FO6-VZrPe-HAf-44GAWIgYd926CPgj3ROfQYCkTQA"}],
          "PayloadDigest": "XN-RHT6lOMmgdlAGFxgz4hyFOnuvPUdLnvmuuIOLyhDXu
  BWlwiRs90pVmxxlJEANkpwN6k8WzgfyPxmIvEfNVA"}],
      "DeviceUDF": "MANQ-KRYM-NIIW-2QES-A3CX-GWXA-ANXG",
      "EnvelopedProfileDevice": [{
          "dig": "S512"},
        "ewogICJQcm9maWxlRGV2aWNlIjogewogICAgIktleU9mZmxpbmVTaWd
  uYXR1cmUiOiB7CiAgICAgICJVREYiOiAiTUFOUS1LUllNLU5JSVctMlFFUy1BM
  0NYLUdXWEEtQU5YRyIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICA
  gICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJFZDQ0O
  CIsCiAgICAgICAgICAiUHVibGljIjogIkx3ZEUtWDRUc21rMVh5UGx2ZkdEd0w
  3TjJ4VEFXN3lkMWRUenRBNnZtRzdyQTNwT2RCTkQKICAycnFrWVNqenZtMS1nQ
  jBkNlc1ZnlYc0EifX19LAogICAgIktleUVuY3J5cHRpb24iOiB7CiAgICAgICJ
  VREYiOiAiTUJBUC1MUlNYLVJJQlEtUlBYRS02T0I1LTVJNEwtUFpRUyIsCiAgI
  CAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJsaWNLZXlFQ0R
  IIjogewogICAgICAgICAgImNydiI6ICJFZDQ0OCIsCiAgICAgICAgICAiUHVib
  GljIjogInl2UUZiT3lLREdsdHpCT0ZxTlV2Wk5uN2VtcnZSU1JnNzZycS1oVGs
  wcGtfQ2N3LXdpMXQKICBVSEFRZFdHTmxaNC1WZG0tUlBqci1iR0EifX19LAogI
  CAgIktleUF1dGhlbnRpY2F0aW9uIjogewogICAgICAiVURGIjogIk1BSkYtRjN
  HTC1RUVJRLU9TRDUtWE1YTS1PSEo2LTVVM0giLAogICAgICAiUHVibGljUGFyY
  W1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICA
  gICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJjaThUcG55V
  ll2RDRZZlpSbjBKZWliMTBseVhSMUdZeU5NMjZrWmtDQ21hRm1KT0R6WnI1CiA
  gUkpmUURiM0FjaDQ5UmxKYVdEX0VpekdBIn19fX19",
        {
          "signatures": [{
              "alg": "S512",
              "kid": "MANQ-KRYM-NIIW-2QES-A3CX-GWXA-ANXG",
              "signature": "tY40rmyQi79Ck8BIWfbzwiueXXQs0D7qxW1tB363-G_D-uJey
  I_K1Aid5yOfYCc55iEBY2u8Cp2AIYCRzyda4_K2ZX4PCMK2WLnGbdEJL0Ej4wr
  v1_DBzB6S30px3s8-3pJNDIANqgYQH_6RdBVWFhYA"}],
          "PayloadDigest": "VunCqRGYZwHwvl7OM--qdRtdZNp4fC-miHyR0plDsnjvo
  kQfPqjyjmcpkgUxrGOmntbj5wLI_lbnpXGeL2kylQ"}],
      "EnvelopedMessageConnectionResponse": [{
          "ContentMetaData": "ewogICJVbmlxdWVJRCI6ICJORExCLVBPMlItQkpCWi1
  OVVFWLU5WTlgtSTRHNi1NQlhRIiwKICAiTWVzc2FnZVR5cGUiOiAiQWNrbm93b
  GVkZ2VDb25uZWN0aW9uIn0"},
        "ewogICJBY2tub3dsZWRnZUNvbm5lY3Rpb24iOiB7CiA
  gICAiTWVzc2FnZUlEIjogIk5CU0ctR1FFTi1EQk9ULTY0SFktSUE2WC1RSTZRL
  TZDRzYiLAogICAgIkVudmVsb3BlZFJlcXVlc3RDb25uZWN0aW9uIjogW3t9LAo
  gICAgICAiZXdvZ0lDSlNaWEYxWlhOMFEyOXVibVZqZEdsdmJpSTYKICBJSHNLS
  UNBZ0lDSlRaWEoyYVdObFNVUWlPaUFpWVd4cFkyVkFaWGhoYlhCc1pTNWpiMjB
  pTEFvZ0lDQWdJawogIFZ1ZG1Wc2IzQmxaRkJ5YjJacGJHVkVaWFpwWTJVaU9pQ
  mJld29nSUNBZ0lDQWdJQ0prYVdjaU9pQWlVelV4CiAgTWlKOUxBb2dJQ0FnSUN
  BaVpYZHZaMGxEU2xGamJUbHRZVmQ0YkZKSFZqSmhWMDVzU1dwdloyVjNiMmRKU
  TAKICBGblNXdDBiR1ZWT1cxYWJYaHdZbTFXVkdGWFpBb2dJSFZaV0ZJeFkyMVZ
  hVTlwUWpkRGFVRm5TVU5CWjBsRAogIFNsWlNSVmxwVDJsQmFWUlZSazlWVXpGT
  VZXeHNUa3hWTlVwVFZtTjBUV3hHUmxWNU1VSk5DaUFnTUU1WlRGCiAgVmtXRmR
  GUlhSUlZUVlpVbmxKYzBOcFFXZEpRMEZuU1VOS1VXUlhTbk5oVjA1UldWaEthR
  0pYVmpCYVdFcDYKICBTV3B2WjJWM2IyZEpRMEVLSUNCblNVTkJaMGxEU2xGa1Y
  wcHpZVmRPVEZwWWJFWlJNRkpKU1dwdloyVjNiMgogIGRKUTBGblNVTkJaMGxEU
  VdkSmJVNTVaR2xKTmtsRFNrWmFSRkV3VHdvZ0lFTkpjME5wUVdkSlEwRm5TVU5
  CCiAgWjBsRFFXbFZTRlpwWWtkc2FrbHFiMmRKYTNneldrVlZkRmRFVWxWak1qR
  nlUVlpvTlZWSGVESmFhMlJGWkQKICBCM0NpQWdNMVJxU2pSV1JVWllUak5zYTA
  xWFVsVmxibEpDVG01YWRGSjZaSGxSVkU1M1ZESlNRMVJyVVV0SgogIFEwRjVZM
  jVHY2xkV1RuRmxibHAwVFZNeGJsRUtJQ0JxUW10T2JHTXhXbTVzV1dNd1JXbG1
  XREU1VEVGdlowCiAgbERRV2RKYTNSc1pWVldkVmt6U2pWalNGSndZakkwYVU5c
  FFqZERhVUZuU1VOQlowbERTZ29nSUZaU1JWbHAKICBUMmxCYVZSVlNrSlZRekZ
  OVld4T1dVeFdTa3BSYkVWMFZXeENXVkpUTURKVU1Fa3hURlJXU2s1RmQzUlZSb
  gogIEJTVlhsSmMwTnBRV2RKQ2lBZ1EwRm5TVU5LVVdSWFNuTmhWMDVSV1ZoS2F
  HSlhWakJhV0VwNlNXcHZaMlYzCiAgYjJkSlEwRm5TVU5CWjBsRFNsRmtWMHB6W
  VZkT1RGcFliRVpSTUZJS0lDQkpTV3B2WjJWM2IyZEpRMEZuU1UKICBOQlowbER
  RV2RKYlU1NVpHbEpOa2xEU2taYVJGRXdUME5KYzBOcFFXZEpRMEZuU1VOQlowb
  ERRV2xWU0ZacAogIFlnb2dJRWRzYWtscWIyZEpibXd5VlZWYWFWUXpiRXhTUld
  SelpFaHdRMVF3V25oVWJGWXlWMnMxZFU0eVZuCiAgUmpibHBUVlRGS2JrNTZXb
  mxqVXpGdlZrZHpDaUFnZDJOSGRHWlJNazR6VEZoa2NFMVlVVXRKUTBKV1UwVkc
  KICBVbHBHWkVoVWJYaGhUa014VjFwSE1IUlZiRUp4WTJreGFWSXdSV2xtV0RFN
  VRFRnZaMGtLSUNCRFFXZEphMwogIFJzWlZWR01XUkhhR3hpYmxKd1dUSkdNR0Z
  YT1hWSmFtOW5aWGR2WjBsRFFXZEpRMEZwVmxWU1IwbHFiMmRKCiAgYXpGQ1Uyd
  FpkRkpxVGdvZ0lFaFVRekZTVlZaS1VreFZPVlJTUkZWMFYwVXhXVlJUTVZCVFJ
  XOHlURlJXVmsKICAwd1oybE1RVzluU1VOQlowbERRV2xWU0ZacFlrZHNhbFZIU
  m5sWkNpQWdWekZzWkVkV2VXTjVTVFpKU0hOTAogIFNVTkJaMGxEUVdkSlEwRnB
  WVWhXYVdKSGJHcFRNbFkxVWxWT1JWTkRTVFpKU0hOTFNVTkJaMGxEUVdkSlEwC
  iAgRUtJQ0JuU1VOS2FtTnVXV2xQYVVGcFVsZFJNRTVFWjJsTVFXOW5TVU5CWjB
  sRFFXZEpRMEZuU1d4Q01WbHQKICBlSEJaZVVrMlNVTkthbUZVYUZWalJ6VTFWZ
  29nSUd4c01sSkVVbHBhYkhCVFltcENTMXBYYkdsTlZFSnpaVgogIFpvVTAxVlp
  GcGxWVFZPVFdwYWNsZHRkRVJSTWpGb1VtMHhTMVF3VWpaWGJra3hRMmxCQ2lBZ
  1oxVnJjRzFWCiAgVlZKcFRUQkdhbUZFVVRWVmJYaExXVlprUlZnd1ZuQmxhMlJ
  DU1c0eE9XWllNVGtpTEFvZ0lDQWdJQ0I3Q2kKICBBZ0lDQWdJQ0FnSW5OcFoyN
  WhkSFZ5WlhNaU9pQmJld29nSUNBZ0lDQWdJQ0FnSUNBaVlXeG5Jam9nSWxNMQo
  gIE1USWlMQW9nSUNBZ0lDQWdJQ0FnSUNBaWEybGtJam9nSWsxQlRsRXRTMUpaV
  FMxT1NVbFhMVEpSUlZNdFFUCiAgTkRXQzFIVjFoQkxVRk9XRWNpTEFvZ0lDQWd
  JQ0FnSUNBZ0lDQWljMmxuYm1GMGRYSmxJam9nSW5SWk5EQnkKICBiWGxSYVRjN
  VEyczRRa2xYWm1KNmQybDFaVmhZVVhNd1JEZHhlRmN4ZEVJek5qTXRSMTlFTFh
  WS1pYa0tJQwogIEJKWDBzeFFXbGtOWGxQWmxsRFl6VTFhVVZDV1RKMU9FTndNa
  0ZKV1VOU2VubGtZVFJmU3pKYVdEUlFRMDFMCiAgTWxkTWJrZGlaRVZLVERCRmF
  qUjNjZ29nSUhZeFgwUkNla0kyVXpNd2NIZ3pjemd0TTNCS1RrUkpRVTV4WjEKI
  CBsUlNGODJVbVJDVmxkR2FGbEJJbjFkTEFvZ0lDQWdJQ0FnSUNKUVlYbHNiMkZ
  rUkdsblpYTjBJam9nSWxaMQogIGJrTnhVa2RaV25kSWQzWnNOMDlOTFMxeFpGS
  jBaRnBPY0RSbVF5MXRhVWg1VWpCd2JFUnpibXAyYndvZ0lHCiAgdFJabEJ4YW5
  scWJXTndhMmRWZUhKSFQyMXVkR0pxTlhkTVNWOXNZbTV3V0VkbFRESnJlV3hSS
  W4xZExBb2cKICBJQ0FnSWtOc2FXVnVkRTV2Ym1ObElqb2dJa051ZDA5RlNFMXF
  abHBPZERkamNrbHhVMVpXWlZFaWZYMCJdLAogICAgIlNlcnZlck5vbmNlIjogI
  nMzR1k4THV5MzVJZXVZS2xaN0IzQ2ciLAogICAgIldpdG5lc3MiOiAiNDJCMi0
  3UE9YLUdNTFctNkVCQy1HS0FJLTdOREMtNzIyNiJ9fQ"],
      "EnvelopedAccountAssertion": [{
          "dig": "S512"},
        "ewogICJQcm9maWxlQWNjb3VudCI6IHsKICAgICJLZXlPZmZsaW5lU2l
  nbmF0dXJlIjogewogICAgICAiVURGIjogIk1DVFotUE5FUS1FNjNKLVlDQjMtT
  FhSRy1SR1VXLUxHMzciLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICA
  gICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0N
  DgiLAogICAgICAgICAgIlB1YmxpYyI6ICJyUndkVUpzOU4tVFBuc21fdThXcDI
  xcW42REpFWDdXY1lmYUoyRkVyeUpHNGZQaXNOdnFECiAgOEZwMmt5UVlpbTFaa
  S1CbWZGRmcwN3VBIn19fSwKICAgICJLZXlzT25saW5lU2lnbmF0dXJlIjogW3s
  KICAgICAgICAiVURGIjogIk1DVkQtQ1E1SS1aM0xFLTU3U0stTTNXTy1QREFSL
  VhCNUQiLAogICAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICA
  gIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAgICJjcnYiOiAiRWQ0NDgiL
  AogICAgICAgICAgICAiUHVibGljIjogIkYtSk82YjZLbGJIQ0k3bGZkcXRZMzR
  wQXM0UTVQZFQwYTdHdFlQRm1XT1UtUHJET2FzYk0KICBRdmNqdEtUMkJ0YjlIU
  DV3Q2Mtam1QT0EifX19XSwKICAgICJTZXJ2aWNlSURzIjogWyJhbGljZUBleGF
  tcGxlLmNvbSJdLAogICAgIk1lc2hQcm9maWxlVURGIjogIk1BMlQtQ0Y2VC1ET
  TU0LVAyVVEtUk1ZRS1TQjdXLU0zS0IiLAogICAgIktleUVuY3J5cHRpb24iOiB
  7CiAgICAgICJVREYiOiAiTUEzRy1QT0pKLTRGWlAtMk1aTC01UlhKLVZFVEUtV
  DVRSiIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJ
  saWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJFZDQ0OCIsCiAgICAgI
  CAgICAiUHVibGljIjogIm9sREZZODVKOWF4NXdFQjlHakxmdDZNZEZKUkJtYTQ
  5Y0dlZVZsaWl4R1ROSk9JTE1EVGwKICBnbkNpXzNNai1ib2pCRlB6ekNSNmxfY
  0EifX19fX0",
        {
          "signatures": [{
              "alg": "S512",
              "kid": "MCME-YH64-OJRB-JUA7-SYNP-NFU2-JSME",
              "signature": "ntHO4V92lHKLOoSkhWpjKZHlYgNW0ly21Rran0PC976obvt2V
  ikg6pGac8y-191nIO-wyCL4AT0AQCE4B45Jlz_V4nwksbcvXD3l3SG_e4YQ1I0
  3Mjdez1D7UgYnL5ZTVdNZMde6glAGRj2p4gifwScA"}],
          "PayloadDigest": "8yffsDt8ez2RzPPVY_-HXfIcab_p4Tlmb5J8kFwDpAJ5T
  -DxVZ4asguK7DJ_7ee6VlfagtVOHCjKPny3UVWTbA"}]}}}
````


