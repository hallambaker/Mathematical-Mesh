

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
Alice> device accept NDGB-SFHS-673S-4BHV-VUEO-YXC6-L3HJ
````

Specifying the /json option returns a result of type ResultConnectProcess:

````
Alice> device accept NDGB-SFHS-673S-4BHV-VUEO-YXC6-L3HJ /json
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
Alice> device accept NDGB-SFHS-673S-4BHV-VUEO-YXC6-L3HJ
````

Specifying the /json option returns a result of type ResultConnectProcess:

````
Alice> device accept NDGB-SFHS-673S-4BHV-VUEO-YXC6-L3HJ /json
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
Alice> device delete NDGB-SFHS-673S-4BHV-VUEO-YXC6-L3HJ
ERROR - The feature has not been implemented
````

Specifying the /json option returns a result of type Result:

````
Alice> device delete NDGB-SFHS-673S-4BHV-VUEO-YXC6-L3HJ /json
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
Alice> device earl udf://example.com/EANG-GUFC-BYD4-CODM-FFF5-5BGP-K6DD-24
ERROR - Object reference not set to an instance of an object.
````

Specifying the /json option returns a result of type Result:

````
Alice> device earl udf://example.com/EANG-GUFC-BYD4-CODM-FFF5-5BGP-K6DD-24 /json
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
        "MessageID": "NDGB-SFHS-673S-4BHV-VUEO-YXC6-L3HJ",
        "EnvelopedRequestConnection": [{
            "dig": "S512"},
          "ewogICJSZXF1ZXN0Q29ubmVjdGlvbiI6IHsKICAgICJTZXJ2aWNlSUQ
  iOiAiYWxpY2VAZXhhbXBsZS5jb20iLAogICAgIkVudmVsb3BlZFByb2ZpbGVEZ
  XZpY2UiOiBbewogICAgICAgICJkaWciOiAiUzUxMiJ9LAogICAgICAiZXdvZ0l
  DSlFjbTltYVd4bFJHVjJhV05sSWpvZ2V3b2dJQ0FnSWt0bGVVOW1abXhwYm1WV
  GFXZAogIHVZWFIxY21VaU9pQjdDaUFnSUNBZ0lDSlZSRVlpT2lBaVRVTkJTUzF
  VVlVOWkxVTlpSRUV0V1VnMlV5MVhSCiAgVWxITFVSUlZVVXRUVmhFV2lJc0NpQ
  WdJQ0FnSUNKUWRXSnNhV05RWVhKaGJXVjBaWEp6SWpvZ2V3b2dJQ0EKICBnSUN
  BZ0lDSlFkV0pzYVdOTFpYbEZRMFJJSWpvZ2V3b2dJQ0FnSUNBZ0lDQWdJbU55Z
  GlJNklDSkZaRFEwTwogIENJc0NpQWdJQ0FnSUNBZ0lDQWlVSFZpYkdsaklqb2d
  JbWhmYmtsd01uQkNhak51TFZJNFNubGliMHhGZGxoCiAga2VHaHJSMHhZVW1JM
  lducFVZak5KU1VKQ1NtaHRXVkJtYzNKSU9Hc0tJQ0JvZFVwd1lucHBTRkJ6TWx
  aM1cKICBYbHRhamxoWTBkVmIwRWlmWDE5TEFvZ0lDQWdJa3RsZVVWdVkzSjVjS
  FJwYjI0aU9pQjdDaUFnSUNBZ0lDSgogIFZSRVlpT2lBaVRVRk9TQzFEVmtOSUx
  WVklUelF0UlZkUU15MU5XVkJKTFRSSVVFY3RNMWRFVGlJc0NpQWdJCiAgQ0FnS
  UNKUWRXSnNhV05RWVhKaGJXVjBaWEp6SWpvZ2V3b2dJQ0FnSUNBZ0lDSlFkV0p
  zYVdOTFpYbEZRMFIKICBJSWpvZ2V3b2dJQ0FnSUNBZ0lDQWdJbU55ZGlJNklDS
  kZaRFEwT0NJc0NpQWdJQ0FnSUNBZ0lDQWlVSFZpYgogIEdsaklqb2dJbkJsWTN
  SV2MxZHVNalZEV1UxQk5XTXdYM0JpT1U5MFRuTm5aVTVIUlU1SVRuSTVTRVp4W
  DFnCiAgNWQwaExTMVp6YmxJeVpESUtJQ0JLV1VGclYzRTVUME5sVVZkaGNIbGZ
  SbTF1VjNWTFdVRWlmWDE5TEFvZ0kKICBDQWdJa3RsZVVGMWRHaGxiblJwWTJGM
  GFXOXVJam9nZXdvZ0lDQWdJQ0FpVlVSR0lqb2dJazFEUTA4dFNUUgogIFNWUzF
  UUVU5Q0xVdFpSRkl0VUZGWFJDMUlObGxDTFVjMlNEY2lMQW9nSUNBZ0lDQWlVS
  FZpYkdsalVHRnlZCiAgVzFsZEdWeWN5STZJSHNLSUNBZ0lDQWdJQ0FpVUhWaWJ
  HbGpTMlY1UlVORVNDSTZJSHNLSUNBZ0lDQWdJQ0EKICBnSUNKamNuWWlPaUFpU
  ldRME5EZ2lMQW9nSUNBZ0lDQWdJQ0FnSWxCMVlteHBZeUk2SUNKak1ubHdkVUV
  0TwogIFd4WlUzRnVha0ZJYm5oR2VDMHdSbEZzUWtaWGREUlJVVGRHYUZOUWRUW
  kdNbEJ4VG1OaFJFZFpjbkJrQ2lBCiAgZ2VEQkVZMHRzYTNwQlZsRjZhVlY1V2t
  3Mk9ESkZRVXRCSW4xOWZYMTkiLAogICAgICB7CiAgICAgICAgInNpZ25hdHVyZ
  XMiOiBbewogICAgICAgICAgICAiYWxnIjogIlM1MTIiLAogICAgICAgICAgICA
  ia2lkIjogIk1DQUktVFVDWS1DWURBLVlINlMtV0VJRy1EUVVFLU1YRFoiLAogI
  CAgICAgICAgICAic2lnbmF0dXJlIjogImtmQXVYWVRyd2dHOGpkVDRIZnVGY0t
  RNVZ0OW93bjZSUmZBR1pkUmEtWThvNW9kWlQKICBsTWJVNmZ3Z3B3OXRoSGwtV
  XRHVDNUVFpwMkF2R2Q0eTh5RVFoTEJmb2k3TUxUbDZ3UVZWN3JySFhUMVhzSQo
  gIDA3YWtfQjdCMFBYT09zb1MwR1dBRThwUzBUb0pYVkhlQW1kVW1nUlVBIn1dL
  AogICAgICAgICJQYXlsb2FkRGlnZXN0IjogIlJHcWhoXzFQdWxZS09PWkpFVmt
  yc21hc05pV09wbGdiME1EVGt6NXlPTWJzOAogIFRjS0sxWDhYOURMMXhoMERBe
  DBiZnJNNm9DRjlQZVVLNnA5ZmhlS1pnIn1dLAogICAgIkNsaWVudE5vbmNlIjo
  gImtkT2ZjTHRpNUUybnhpc1E0MkNtaHcifX0",
          {
            "signatures": [{
                "alg": "S512",
                "kid": "MCCO-I4RU-SAOB-KYDR-PQWD-H6YB-G6H7",
                "signature": "PVYwovUmo5CwqmEW9kf33cA1bDBlrtOS47YHl9YGrGyzvyq-f
  WC2h_eI98ycozemJ2d7bjJXTFyARdADIgUnzIMQouL9nxxySFJ2l6vjXQXqOls
  1gY7IwkWpwh2AuErKQ7z3qbPiAJIEAc7rJqXUHiwA"}],
            "PayloadDigest": "Gvh68RnlXAo3q0A8-pR-SLNY8ALxrHmGUhR6_-f7ZomZF
  vZoBJpD69h1pt8eBdp_GFB0tf8TSti2fr2eg4Zc6Q"}],
        "ServerNonce": "YS8TnBcplOsc5dizcRJ69w",
        "Witness": "FYLI-3EVO-UEIJ-UYXQ-URUZ-RK5N-JISL"}]}}
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
Alice4> device pre devices@example.com /key=udf://example.com/EANG-GUFC-BYD4-CODM-FFF5-5BGP-K6DD-24
ERROR - Object reference not set to an instance of an object.
````

Specifying the /json option returns a result of type Result:

````
Alice4> device pre devices@example.com /key=udf://example.com/EANG-GUFC-BYD4-CODM-FFF5-5BGP-K6DD-24 /json
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
   Witness value = FYLI-3EVO-UEIJ-UYXQ-URUZ-RK5N-JISL
   Personal Mesh = MAMM-XWMN-ZTWV-F32Q-LCDS-7TDM-VH2Y
````

Specifying the /json option returns a result of type ResultConnect:

````
Alice2> device request alice@example.com /json
{
  "ResultConnect": {
    "Success": true,
    "CatalogedMachine": {
      "ID": "MCAI-TUCY-CYDA-YH6S-WEIG-DQUE-MXDZ",
      "EnvelopedProfileMaster": [{
          "dig": "S512"},
        "ewogICJQcm9maWxlTWVzaCI6IHsKICAgICJLZXlPZmZsaW5lU2lnbmF
  0dXJlIjogewogICAgICAiVURGIjogIk1BTU0tWFdNTi1aVFdWLUYzMlEtTENEU
  y03VERNLVZIMlkiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICA
  gICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiL
  AogICAgICAgICAgIlB1YmxpYyI6ICJ6RnNrM094M2ZqQlFxb2s0S2dWaTNjcHd
  NYVpxS29SUFRINXhMZ1hONktpWkh5YVJxVk9TCiAgbTRPM3gyMXBoNXpDekdZM
  kE1eTJIcklBIn19fSwKICAgICJLZXlzT25saW5lU2lnbmF0dXJlIjogW3sKICA
  gICAgICAiVURGIjogIk1DV0MtT0RZRy1FV1hYLTZDTEUtWkpJQy1GWkpNLU1EN
  lEiLAogICAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICAgIlB
  1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogI
  CAgICAgICAgICAiUHVibGljIjogInlPNEhMOTdvV1U0dFFXWlJ1amdNWDZDTGY
  3MGVDSE5xNlQwZVluY0o0Q0V6VGczamo5MzAKICBBZkpSeDlLVG9qNXViOG0tc
  VI2ODNBNkEifX19XSwKICAgICJLZXlFbmNyeXB0aW9uIjogewogICAgICAiVUR
  GIjogIk1CRlQtWlI1Ri1CUlFDLUhKUE8tT0E1UC1XM0FOLUNXQ0siLAogICAgI
  CAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNESCI
  6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAgIlB1YmxpY
  yI6ICJmQm9CczhjUjA4T2Rxelh0aERaWlEwOUw2Q0szeXhnLUUwSl9YdEwtRHp
  4REJfV0FhN0hECiAgUmh0MExUamhTLS1aa09LWWxiX2Z1Y2dBIn19fX19",
        {
          "signatures": [{
              "alg": "S512",
              "kid": "MAMM-XWMN-ZTWV-F32Q-LCDS-7TDM-VH2Y",
              "signature": "LMg8_iAmu4eh7bHg8AtAaQrOZ_UKLwNix52NAxDtQ5JD8Z_TM
  cEdFzRmn0E1_d9lJywWHu1K-HaA1tnPXecXHijFBXx2f0UrVQGFR-rZHzvLIrR
  TvWD3GxoXhKQTx6Qc0EVQqHTTyR6d5yJuMIbSjzEA"}],
          "PayloadDigest": "kAebzWvC_wOUCpZ964oXHlZRIl1nYM5YcL9b0Sn-w_txA
  CsF-dCAysM-i4L2Qlyu1baPOXj6ncRz5l5q6IGcnQ"}],
      "DeviceUDF": "MCAI-TUCY-CYDA-YH6S-WEIG-DQUE-MXDZ",
      "EnvelopedProfileDevice": [{
          "dig": "S512"},
        "ewogICJQcm9maWxlRGV2aWNlIjogewogICAgIktleU9mZmxpbmVTaWd
  uYXR1cmUiOiB7CiAgICAgICJVREYiOiAiTUNBSS1UVUNZLUNZREEtWUg2Uy1XR
  UlHLURRVUUtTVhEWiIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICA
  gICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJFZDQ0O
  CIsCiAgICAgICAgICAiUHVibGljIjogImhfbklwMnBCajNuLVI4Snlib0xFdlh
  keGhrR0xYUmI2WnpUYjNJSUJCSmhtWVBmc3JIOGsKICBodUpwYnppSFBzMlZ3W
  XltajlhY0dVb0EifX19LAogICAgIktleUVuY3J5cHRpb24iOiB7CiAgICAgICJ
  VREYiOiAiTUFOSC1DVkNILVVITzQtRVdQMy1NWVBJLTRIUEctM1dETiIsCiAgI
  CAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJsaWNLZXlFQ0R
  IIjogewogICAgICAgICAgImNydiI6ICJFZDQ0OCIsCiAgICAgICAgICAiUHVib
  GljIjogInBlY3RWc1duMjVDWU1BNWMwX3BiOU90TnNnZU5HRU5ITnI5SEZxX1g
  5d0hLS1ZzblIyZDIKICBKWUFrV3E5T0NlUVdhcHlfRm1uV3VLWUEifX19LAogI
  CAgIktleUF1dGhlbnRpY2F0aW9uIjogewogICAgICAiVURGIjogIk1DQ08tSTR
  SVS1TQU9CLUtZRFItUFFXRC1INllCLUc2SDciLAogICAgICAiUHVibGljUGFyY
  W1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICA
  gICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJjMnlwdUEtO
  WxZU3FuakFIbnhGeC0wRlFsQkZXdDRRUTdGaFNQdTZGMlBxTmNhREdZcnBkCiA
  geDBEY0tsa3pBVlF6aVV5Wkw2ODJFQUtBIn19fX19",
        {
          "signatures": [{
              "alg": "S512",
              "kid": "MCAI-TUCY-CYDA-YH6S-WEIG-DQUE-MXDZ",
              "signature": "kfAuXYTrwgG8jdT4HfuFcKQ5Vt9own6RRfAGZdRa-Y8o5odZT
  lMbU6fwgpw9thHl-UtGT3TTZp2AvGd4y8yEQhLBfoi7MLTl6wQVV7rrHXT1XsI
  07ak_B7B0PXOOsoS0GWAE8pS0ToJXVHeAmdUmgRUA"}],
          "PayloadDigest": "RGqhh_1PulYKOOZJEVkrsmasNiWOplgb0MDTkz5yOMbs8
  TcKK1X8X9DL1xh0DAx0bfrM6oCF9PeUK6p9fheKZg"}],
      "EnvelopedMessageConnectionResponse": [{},
        "ewogICJBY2tub3dsZWRnZUNv
  bm5lY3Rpb24iOiB7CiAgICAiTWVzc2FnZUlEIjogIk5ER0ItU0ZIUy02NzNTLT
  RCSFYtVlVFTy1ZWEM2LUwzSEoiLAogICAgIkVudmVsb3BlZFJlcXVlc3RDb25u
  ZWN0aW9uIjogW3sKICAgICAgICAiZGlnIjogIlM1MTIifSwKICAgICAgImV3b2
  dJQ0pTWlhGMVpYTjBRMjl1Ym1WamRHbHZiaUk2SUhzS0lDQWdJQ0pUWlhKMmFX
  TmxTVVEKICBpT2lBaVlXeHBZMlZBWlhoaGJYQnNaUzVqYjIwaUxBb2dJQ0FnSW
  tWdWRtVnNiM0JsWkZCeWIyWnBiR1ZFWgogIFhacFkyVWlPaUJiZXdvZ0lDQWdJ
  Q0FnSUNKa2FXY2lPaUFpVXpVeE1pSjlMQW9nSUNBZ0lDQWlaWGR2WjBsCiAgRF
  NsRmpiVGx0WVZkNGJGSkhWakpoVjA1c1NXcHZaMlYzYjJkSlEwRm5TV3QwYkdW
  Vk9XMWFiWGh3WW0xV1YKICBHRlhaQW9nSUhWWldGSXhZMjFWYVU5cFFqZERhVU
  ZuU1VOQlowbERTbFpTUlZscFQybEJhVlJWVGtKVFV6RgogIFZWbFZPV2t4VlRs
  cFNSVVYwVjFWbk1sVjVNVmhTQ2lBZ1ZXeElURlZTVWxaVlZYUlVWbWhGVjJsSm
  MwTnBRCiAgV2RKUTBGblNVTktVV1JYU25OaFYwNVJXVmhLYUdKWFZqQmFXRXA2
  U1dwdloyVjNiMmRKUTBFS0lDQm5TVU4KICBCWjBsRFNsRmtWMHB6WVZkT1RGcF
  liRVpSTUZKSlNXcHZaMlYzYjJkSlEwRm5TVU5CWjBsRFFXZEpiVTU1WgogIEds
  Sk5rbERTa1phUkZFd1R3b2dJRU5KYzBOcFFXZEpRMEZuU1VOQlowbERRV2xWU0
  ZacFlrZHNha2xxYjJkCiAgSmJXaG1ZbXRzZDAxdVFrTmhhazUxVEZaSk5GTnVi
  R2xpTUhoR1pHeG9DaUFnYTJWSGFISlNNSGhaVlcxSk0KICBsZHVjRlZaYWs1S1
  UxVktRMU50YUhSWFZrSnRZek5LU1U5SGMwdEpRMEp2WkZWd2QxbHVjSEJUUmtK
  NlRXeAogIGFNMWNLSUNCWWJIUmhhbXhvV1RCa1ZtSXdSV2xtV0RFNVRFRnZaMG
  xEUVdkSmEzUnNaVlZXZFZrelNqVmpTCiAgRkp3WWpJMGFVOXBRamREYVVGblNV
  TkJaMGxEU2dvZ0lGWlNSVmxwVDJsQmFWUlZSazlUUXpGRVZtdE9TVXgKICBXVm
  tsVWVsRjBVbFprVVUxNU1VNVhWa0pLVEZSU1NWVkZZM1JOTVdSRlZHbEpjME5w
  UVdkSkNpQWdRMEZuUwogIFVOS1VXUlhTbk5oVjA1UldWaEthR0pYVmpCYVdFcD
  ZTV3B2WjJWM2IyZEpRMEZuU1VOQlowbERTbEZrVjBwCiAgellWZE9URnBZYkVa
  Uk1GSUtJQ0JKU1dwdloyVjNiMmRKUTBGblNVTkJaMGxEUVdkSmJVNTVaR2xKTm
  tsRFMKICBrWmFSRkV3VDBOSmMwTnBRV2RKUTBGblNVTkJaMGxEUVdsVlNGWnBZ
  Z29nSUVkc2FrbHFiMmRKYmtKc1dUTgogIFNWMk14WkhWTmFsWkVWMVV4UWs1WF
  RYZFlNMEpwVDFVNU1GUnVUbTVhVlRWSVVsVTFTVlJ1U1RWVFJWcDRXCiAgREZu
  Q2lBZ05XUXdhRXhUTVZwNllteEplVnBFU1V0SlEwSkxWMVZHY2xZelJUVlVNRT
  VzVlZaa2FHTkliR1oKICBTYlRGMVZqTldURmRWUldsbVdERTVURUZ2WjBrS0lD
  QkRRV2RKYTNSc1pWVkdNV1JIYUd4aWJsSndXVEpHTQogIEdGWE9YVkphbTluWl
  hkdlowbERRV2RKUTBGcFZsVlNSMGxxYjJkSmF6RkVVVEE0ZEZOVVVnb2dJRk5X
  VXpGCiAgVVVWVTVRMHhWZEZwU1JrbDBWVVpHV0ZKRE1VbE9iR3hEVEZWak1sTk
  VZMmxNUVc5blNVTkJaMGxEUVdsVlMKICBGWnBZa2RzYWxWSFJubFpDaUFnVnpG
  c1pFZFdlV041U1RaSlNITkxTVU5CWjBsRFFXZEpRMEZwVlVoV2FXSgogIEhiR3
  BUTWxZMVVsVk9SVk5EU1RaSlNITkxTVU5CWjBsRFFXZEpRMEVLSUNCblNVTkth
  bU51V1dsUGFVRnBVCiAgbGRSTUU1RVoybE1RVzluU1VOQlowbERRV2RKUTBGbl
  NXeENNVmx0ZUhCWmVVazJTVU5LYWsxdWJIZGtWVVYKICAwVHdvZ0lGZDRXbFV6
  Um5WaGEwWkpZbTVvUjJWRE1IZFNiRVp6VVd0YVdHUkVVbEpWVkdSSFlVWk9VV1
  JVVwogIGtkTmJFSjRWRzFPYUZKRlpGcGpia0pyUTJsQkNpQWdaMlZFUWtWWk1I
  UnpZVE53UWxac1JqWmhWbFkxVjJ0CiAgM01rOUVTa1pSVlhSQ1NXNHhPV1pZTV
  RraUxBb2dJQ0FnSUNCN0NpQWdJQ0FnSUNBZ0luTnBaMjVoZEhWeVoKICBYTWlP
  aUJiZXdvZ0lDQWdJQ0FnSUNBZ0lDQWlZV3huSWpvZ0lsTTFNVElpTEFvZ0lDQW
  dJQ0FnSUNBZ0lDQQogIGlhMmxrSWpvZ0lrMURRVWt0VkZWRFdTMURXVVJCTFZs
  SU5sTXRWMFZKUnkxRVVWVkZMVTFZUkZvaUxBb2dJCiAgQ0FnSUNBZ0lDQWdJQ0
  FpYzJsbmJtRjBkWEpsSWpvZ0ltdG1RWFZZV1ZSeWQyZEhPR3BrVkRSSVpuVkdZ
  MHQKICBSTlZaME9XOTNialpTVW1aQlIxcGtVbUV0V1Rodk5XOWtXbFFLSUNCc1
  RXSlZObVozWjNCM09YUm9TR3d0VgogIFhSSFZETlVWRnB3TWtGMlIyUTBlVGg1
  UlZGb1RFSm1iMmszVFV4VWJEWjNVVlpXTjNKeVNGaFVNVmh6U1FvCiAgZ0lEQT
  NZV3RmUWpkQ01GQllUMDl6YjFNd1IxZEJSVGh3VXpCVWIwcFlWa2hsUVcxa1ZX
  MW5VbFZCSW4xZEwKICBBb2dJQ0FnSUNBZ0lDSlFZWGxzYjJGa1JHbG5aWE4wSW
  pvZ0lsSkhjV2hvWHpGUWRXeFpTMDlQV2twRlZtdAogIHljMjFoYzA1cFYwOXdi
  R2RpTUUxRVZHdDZOWGxQVFdKek9Bb2dJRlJqUzBzeFdEaFlPVVJNTVhob01FUk
  JlCiAgREJpWm5KTk5tOURSamxRWlZWTE5uQTVabWhsUzFwbkluMWRMQW9nSUNB
  Z0lrTnNhV1Z1ZEU1dmJtTmxJam8KICBnSW10a1QyWmpUSFJwTlVVeWJuaHBjMU
  UwTWtOdGFIY2lmWDAiLAogICAgICB7CiAgICAgICAgInNpZ25hdHVyZXMiOiBb
  ewogICAgICAgICAgICAiYWxnIjogIlM1MTIiLAogICAgICAgICAgICAia2lkIj
  ogIk1DQ08tSTRSVS1TQU9CLUtZRFItUFFXRC1INllCLUc2SDciLAogICAgICAg
  ICAgICAic2lnbmF0dXJlIjogIlBWWXdvdlVtbzVDd3FtRVc5a2YzM2NBMWJEQm
  xydE9TNDdZSGw5WUdyR3l6dnlxLWYKICBXQzJoX2VJOTh5Y296ZW1KMmQ3YmpK
  WFRGeUFSZEFESWdVbnpJTVFvdUw5bnh4eVNGSjJsNnZqWFFYcU9scwogIDFnWT
  dJd2tXcHdoMkF1RXJLUTd6M3FiUGlBSklFQWM3ckpxWFVIaXdBIn1dLAogICAg
  ICAgICJQYXlsb2FkRGlnZXN0IjogIkd2aDY4Um5sWEFvM3EwQTgtcFItU0xOWT
  hBTHhySG1HVWhSNl8tZjdab21aRgogIHZab0JKcEQ2OWgxcHQ4ZUJkcF9HRkIw
  dGY4VFN0aTJmcjJlZzRaYzZRIn1dLAogICAgIlNlcnZlck5vbmNlIjogIllTOF
  RuQmNwbE9zYzVkaXpjUko2OXciLAogICAgIldpdG5lc3MiOiAiRllMSS0zRVZP
  LVVFSUotVVlYUS1VUlVaLVJLNU4tSklTTCJ9fQ"],
      "EnvelopedAccountAssertion": [{
          "dig": "S512"},
        "ewogICJQcm9maWxlQWNjb3VudCI6IHsKICAgICJLZXlPZmZsaW5lU2l
  nbmF0dXJlIjogewogICAgICAiVURGIjogIk1EVUktV1hGQS1GRE5NLTc1MjQtR
  zZNSy02RUdTLUNCWDIiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICA
  gICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0N
  DgiLAogICAgICAgICAgIlB1YmxpYyI6ICJMcjY0a1F2bDlJZXpxbTAtNG1aT1Z
  Gank4OFZ5MWhTdUNpRWpPaEptdjExTkJJX0xZY2lICiAgTlc2LWhPY1RFTEdMU
  kp6MnNIYkw5REdBIn19fSwKICAgICJLZXlzT25saW5lU2lnbmF0dXJlIjogW3s
  KICAgICAgICAiVURGIjogIk1BRVgtTTNUNS00UU1YLVZFSTQtRU9EVy1RMjJNL
  UtTT1UiLAogICAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICA
  gIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAgICJjcnYiOiAiRWQ0NDgiL
  AogICAgICAgICAgICAiUHVibGljIjogIjl6SXVwMHRkZWF3TjZaQjUyanRVbHZ
  CcWtXZS11S0FmTWpDLU5fVlFqNEJuYkhIamxtcXQKICA3TkZZWkhZS0tvbDZMb
  Hp1RkU1MVJmTUEifX19XSwKICAgICJTZXJ2aWNlSURzIjogWyJhbGljZUBleGF
  tcGxlLmNvbSJdLAogICAgIk1lc2hQcm9maWxlVURGIjogIk1BTU0tWFdNTi1aV
  FdWLUYzMlEtTENEUy03VERNLVZIMlkiLAogICAgIktleUVuY3J5cHRpb24iOiB
  7CiAgICAgICJVREYiOiAiTUJaMi1FWUNMLTQ3RVgtWE9USy1JUEFWLTJJM1EtV
  zdCVyIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJ
  saWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJFZDQ0OCIsCiAgICAgI
  CAgICAiUHVibGljIjogIm1xQVdzS3Jka21IYnl6ZDFYZDVPU0EzSjlESzF1TER
  xR0doZDFhSndkeDlOamRPOGY2ZHQKICBPQ3dsTnBXOHYxRkdDNVZlVmcxd19TS
  UEifX19fX0",
        {
          "signatures": [{
              "alg": "S512",
              "kid": "MCWC-ODYG-EWXX-6CLE-ZJIC-FZJM-MD6Q",
              "signature": "l2sjvGdcad1ihCFLs36X-K76AiojJL-MRQ3FZIdEm0KmKqYIO
  S4C6Um-l6GnYo7J9DMPEjaWGRIAtd-Bw8YtZzO-Ixqi-_dhdIgOaPYx9n-Js5M
  PdEPp4dYG81gEWKHRy1CveGRWO_IHbDo4cC2IVD8A"}],
          "PayloadDigest": "R93t98RD-5LBBl3PsdXg3HQqW5lo5ROEBuPCLn59ad6br
  D7N13Xc6pTMnW1Xs2RuUYaPEHYiZyG7ZSfzwjmJNA"}]}}}
````


