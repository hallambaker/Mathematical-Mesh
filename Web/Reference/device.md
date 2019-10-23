

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
Alice> device accept ND34-CJRL-G3XJ-4MRV-RWLS-4ECL-BD3C
````

Specifying the /json option returns a result of type ResultConnectProcess:

````
Alice> device accept ND34-CJRL-G3XJ-4MRV-RWLS-4ECL-BD3C /json
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
Alice> device accept ND34-CJRL-G3XJ-4MRV-RWLS-4ECL-BD3C
````

Specifying the /json option returns a result of type ResultConnectProcess:

````
Alice> device accept ND34-CJRL-G3XJ-4MRV-RWLS-4ECL-BD3C /json
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
Alice> device delete ND34-CJRL-G3XJ-4MRV-RWLS-4ECL-BD3C
ERROR - The feature has not been implemented
````

Specifying the /json option returns a result of type Result:

````
Alice> device delete ND34-CJRL-G3XJ-4MRV-RWLS-4ECL-BD3C /json
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
Alice> device earl udf://example.com/ECIQ-Q44I-SEWB-F3R4-6KBB-NO77-HZVM-DG
ERROR - Object reference not set to an instance of an object.
````

Specifying the /json option returns a result of type Result:

````
Alice> device earl udf://example.com/ECIQ-Q44I-SEWB-F3R4-6KBB-NO77-HZVM-DG /json
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
        "MessageID": "ND34-CJRL-G3XJ-4MRV-RWLS-4ECL-BD3C",
        "EnvelopedRequestConnection": [{
            "dig": "S512"},
          "ewogICJSZXF1ZXN0Q29ubmVjdGlvbiI6IHsKICAgICJTZXJ2aWNlSUQ
  iOiAiYWxpY2VAZXhhbXBsZS5jb20iLAogICAgIkVudmVsb3BlZFByb2ZpbGVEZ
  XZpY2UiOiBbewogICAgICAgICJkaWciOiAiUzUxMiJ9LAogICAgICAiZXdvZ0l
  DSlFjbTltYVd4bFJHVjJhV05sSWpvZ2V3b2dJQ0FnSWt0bGVVOW1abXhwYm1WV
  GFXZAogIHVZWFIxY21VaU9pQjdDaUFnSUNBZ0lDSlZSRVlpT2lBaVRVUlROeTF
  YU2tNMUxUWkZSVTB0VGxGVFVDMHpVCiAgRWt6TFVSTk1sSXRXa05CV1NJc0NpQ
  WdJQ0FnSUNKUWRXSnNhV05RWVhKaGJXVjBaWEp6SWpvZ2V3b2dJQ0EKICBnSUN
  BZ0lDSlFkV0pzYVdOTFpYbEZRMFJJSWpvZ2V3b2dJQ0FnSUNBZ0lDQWdJbU55Z
  GlJNklDSkZaRFEwTwogIENJc0NpQWdJQ0FnSUNBZ0lDQWlVSFZpYkdsaklqb2d
  JbWRQYzNGVk9XcGtNV3AzZFc5VWJFczBNbmhLT0U1CiAgM1ZFb3hRemQ1VVdON
  VlVUk5WRlJ5Wlcxb2RVNXRMVnBPVUVsR2FIRUtJQ0J6VG5obVZHSktWVmRTTTN
  GeE0KICBYTjJSM0ZDVEdkalVVRWlmWDE5TEFvZ0lDQWdJa3RsZVVWdVkzSjVjS
  FJwYjI0aU9pQjdDaUFnSUNBZ0lDSgogIFZSRVlpT2lBaVRVUTBVUzFYVkZkSkx
  VMDJOall0UVZBM1FpMVlVVTVETFZSWVZrWXRURUZaV2lJc0NpQWdJCiAgQ0FnS
  UNKUWRXSnNhV05RWVhKaGJXVjBaWEp6SWpvZ2V3b2dJQ0FnSUNBZ0lDSlFkV0p
  zYVdOTFpYbEZRMFIKICBJSWpvZ2V3b2dJQ0FnSUNBZ0lDQWdJbU55ZGlJNklDS
  kZaRFEwT0NJc0NpQWdJQ0FnSUNBZ0lDQWlVSFZpYgogIEdsaklqb2dJazV3T0M
  xQmIzcDVkelZyVlcxSkxVMWxaRkpYUVdvek5rTjBOazg1V25CbVJtWjJkWGxHZ
  FRWCiAgeVFXSlViRXR3WDFCU2J6QUtJQ0JvVDJSa2RFdHZkMHQ2U25aQ00xWnd
  PRlozT0RoYWRVRWlmWDE5TEFvZ0kKICBDQWdJa3RsZVVGMWRHaGxiblJwWTJGM
  GFXOXVJam9nZXdvZ0lDQWdJQ0FpVlVSR0lqb2dJazFDUmtZdFZFSgogIE9RUzF
  MVlROSkxWbEJWRGN0VEVoVVJTMUpTVXhTTFRKVlVrSWlMQW9nSUNBZ0lDQWlVS
  FZpYkdsalVHRnlZCiAgVzFsZEdWeWN5STZJSHNLSUNBZ0lDQWdJQ0FpVUhWaWJ
  HbGpTMlY1UlVORVNDSTZJSHNLSUNBZ0lDQWdJQ0EKICBnSUNKamNuWWlPaUFpU
  ldRME5EZ2lMQW9nSUNBZ0lDQWdJQ0FnSWxCMVlteHBZeUk2SUNKcVdrWnJTbkJ
  WVQogIDBjNVpERnFRbWx4Vkd0c2VHMDRRbGMwTjBwWFZGRmhNMVJYWkRNdFdHM
  HhlV2x3T1hkMmFXZFJVbW8zQ2lBCiAgZ2EzaHViRVZTVWxSVldGSmpWVU5RZG1
  3NGJDMDVSR3RCSW4xOWZYMTkiLAogICAgICB7CiAgICAgICAgInNpZ25hdHVyZ
  XMiOiBbewogICAgICAgICAgICAiYWxnIjogIlM1MTIiLAogICAgICAgICAgICA
  ia2lkIjogIk1EUzctV0pDNS02RUVNLU5RU1AtM1BJMy1ETTJSLVpDQVkiLAogI
  CAgICAgICAgICAic2lnbmF0dXJlIjogIk5mdHFhUURHTEFRUE41d2I0ZTlRbGF
  uS0dhQjdNZHViZlZFV3ZrUnZicHNtTlRvNm8KICBjMFJPS3ZpY21idVRIcWZMb
  FhURUQyUERBMkF3amZLV3p3Y3NYV0FlM2w1WkJxV3lQTmtyTWhmTmhvQTRFZwo
  gIFJMWlAzaFo4amVweWJpbTZaZGhOOGJmWm5NSmZPTXp4R3QxVjJRaklBIn1dL
  AogICAgICAgICJQYXlsb2FkRGlnZXN0IjogIi1vejVxeHF2T3ExbXhkNGtDNUt
  jOEQ2LThfaVBabUZZaHFwOVdHaG0xQTVCWQogIExIN2tpaTIyQ1BaSC1ZZ3ZaW
  lNYT1Z5R0M3Vkg5TFVqSXVhZXJ4M2VBIn1dLAogICAgIkNsaWVudE5vbmNlIjo
  gImZCSHdPMUVjWFg5eU8yWFpNbjc3X2cifX0",
          {
            "signatures": [{
                "alg": "S512",
                "kid": "MBFF-TBNA-KU3I-YAT7-LHTE-IILR-2URB",
                "signature": "NVOESVNqyrKt573ZvtnwSjVQC8qnVVyKgbY29tPHMLmeeijCH
  jVdNgVQ8x65MclrDq3ZdPNS6IAAO7DLcsgxfI5cn4XLpVYkU9QGEUhlrx_-smL
  3_j26fPHe3l6Je78k5Xr3DfCbSCsXK-o_K7WT8DsA"}],
            "PayloadDigest": "lwLXKD8_-wEO6SdAkFI5wyqbYuZ0nywIXLQhRXZIXzYEV
  trC3bcP1yPw3f1F61guGsUXuSeyKVd-D8oaaGa17g"}],
        "ServerNonce": "96dXBR8ceqURUCdtVqzgVA",
        "Witness": "N4OW-GEOK-3TC4-VDV7-ZBDP-C5XH-UBSD"},
      {
        "MessageID": "NC4C-PWO7-2A6R-NQ3W-2RZV-SKK3-RHIN",
        "EnvelopedRequestConnection": [{
            "dig": "S512"},
          "ewogICJSZXF1ZXN0Q29ubmVjdGlvbiI6IHsKICAgICJTZXJ2aWNlSUQ
  iOiAiYWxpY2VAZXhhbXBsZS5jb20iLAogICAgIkVudmVsb3BlZFByb2ZpbGVEZ
  XZpY2UiOiBbewogICAgICAgICJkaWciOiAiUzUxMiJ9LAogICAgICAiZXdvZ0l
  DSlFjbTltYVd4bFJHVjJhV05sSWpvZ2V3b2dJQ0FnSWt0bGVVOW1abXhwYm1WV
  GFXZAogIHVZWFIxY21VaU9pQjdDaUFnSUNBZ0lDSlZSRVlpT2lBaVRVUTFSaTF
  aVlVaT0xUTkZRVFV0VlRSR1dTMVlSCiAgMDVZTFVaYU5Fc3RSMGhHVVNJc0NpQ
  WdJQ0FnSUNKUWRXSnNhV05RWVhKaGJXVjBaWEp6SWpvZ2V3b2dJQ0EKICBnSUN
  BZ0lDSlFkV0pzYVdOTFpYbEZRMFJJSWpvZ2V3b2dJQ0FnSUNBZ0lDQWdJbU55Z
  GlJNklDSkZaRFEwTwogIENJc0NpQWdJQ0FnSUNBZ0lDQWlVSFZpYkdsaklqb2d
  JbXRFTFdkS09FaHpVbDlKVUUxb1pHbzBURXRsZG1SCiAgRmIyVkxhMGhwU0hWT
  GVESmtUVmhuVm0xeE9XNUdPRkZzY210dGRYZ0tJQ0EyVFdoMGNXbFZOamxYU2p
  Cb1MKICBuZFVkR1pvWDFkTU5rRWlmWDE5TEFvZ0lDQWdJa3RsZVVWdVkzSjVjS
  FJwYjI0aU9pQjdDaUFnSUNBZ0lDSgogIFZSRVlpT2lBaVRVUlROeTFUTTA1WUx
  UWk5VRGN0U0VjeU15MURVVkkyTFVZMVVEVXRXVE5FVmlJc0NpQWdJCiAgQ0FnS
  UNKUWRXSnNhV05RWVhKaGJXVjBaWEp6SWpvZ2V3b2dJQ0FnSUNBZ0lDSlFkV0p
  zYVdOTFpYbEZRMFIKICBJSWpvZ2V3b2dJQ0FnSUNBZ0lDQWdJbU55ZGlJNklDS
  kZaRFEwT0NJc0NpQWdJQ0FnSUNBZ0lDQWlVSFZpYgogIEdsaklqb2dJbUpGYVR
  WRllrUkxjMWh1WDNOUFYyVXlUMGxUTURVd04xZGZRWE42ZEVWdFIwTk9aVVJxU
  0MxCiAgd1NIbFBaVlp1TkRoNFFYVUtJQ0EwUkdOemFXWkhTVTV3ZUhka2EzZ3l
  RVmRtWldaRlowRWlmWDE5TEFvZ0kKICBDQWdJa3RsZVVGMWRHaGxiblJwWTJGM
  GFXOXVJam9nZXdvZ0lDQWdJQ0FpVlVSR0lqb2dJazFDVFZBdFR6UQogIDJUeTF
  HVkVKVkxWUTBWMFl0UmtwRVFpMUNRbGMxTFZkR05GTWlMQW9nSUNBZ0lDQWlVS
  FZpYkdsalVHRnlZCiAgVzFsZEdWeWN5STZJSHNLSUNBZ0lDQWdJQ0FpVUhWaWJ
  HbGpTMlY1UlVORVNDSTZJSHNLSUNBZ0lDQWdJQ0EKICBnSUNKamNuWWlPaUFpU
  ldRME5EZ2lMQW9nSUNBZ0lDQWdJQ0FnSWxCMVlteHBZeUk2SUNKaVpVMW1lRTF
  XWgogIEVVMVpVRnJVbEpFUWxwcWExOVhPR2g1VTNwbGMxVjVlWGhLVGpKaGJER
  kdiRTA0UmtOcU5qSmtVMWhaQ2lBCiAgZ2QzTkJXUzFMTXpVMlNWUnVVRXRHUmx
  NNGIzSjFjelJCSW4xOWZYMTkiLAogICAgICB7CiAgICAgICAgInNpZ25hdHVyZ
  XMiOiBbewogICAgICAgICAgICAiYWxnIjogIlM1MTIiLAogICAgICAgICAgICA
  ia2lkIjogIk1ENUYtWVVGTi0zRUE1LVU0RlktWEdOWC1GWjRLLUdIRlEiLAogI
  CAgICAgICAgICAic2lnbmF0dXJlIjogImFfMU12VVFwUVR3dW9aTm5hUkpSaUZ
  0eGZhbmRzR0xDaS02QlhpMlR4WUtaN2Etd0cKICBwUUhJRGd6RW95QlFYWDhkN
  HNCQzcwbXh5TUFudkhTMWt2aWR4U0JwSlE5RzFsNFZnQ2pIQnRXMU9fUDZHZwo
  gIC03Q3IyUjZXanFubmRQd00tT3FLQ1c4VGI4Uzh3aFZ4VkFEWVVEQklBIn1dL
  AogICAgICAgICJQYXlsb2FkRGlnZXN0IjogIklEVTFJRlNyQUlNaEpGNllIQUZ
  3NTI3UmVkOFExbnV3c0NhQXF3RjdSeHR0NAogIFAyWlhEcWV0akRUMTRxcHhsN
  mxtd3BaYV9EckRNaVNHa0NTZHp1WGdnIn1dLAogICAgIkNsaWVudE5vbmNlIjo
  gIm9hTDN2LUxfTkZWc213UDAycTM5ZWcifX0",
          {
            "signatures": [{
                "alg": "S512",
                "kid": "MBMP-O46O-FTBU-T4WF-FJDB-BBW5-WF4S",
                "signature": "-YrbTY2J_9DQWlkbL5TH1mmEoy4EaFlvH1hoglz5sbPmKaztU
  r06EIA3WGUfPGc_mydOUdUIafaArVC6T8VFBM6zMHz9rpNRWg3cN_9auInMU7b
  FRKbQusc5GKTLn3_LOBvUR-4PMaFHfTZ9Sgd2cx4A"}],
            "PayloadDigest": "qSY40CNus7jvGRBRY2WI_oT-1uCKphdxiPMT8spu8Utve
  RLaber3_Spjp_3s5QWchdd00B5c2YLZsUYy5ceHGw"}],
        "ServerNonce": "qTDzmCtR2YB0SDph1N5ceg",
        "Witness": "WPRM-7ZJ6-XMJ5-RMAH-N2JS-PHUA-7ZVH"}]}}
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
Alice> device reject NC4C-PWO7-2A6R-NQ3W-2RZV-SKK3-RHIN
````

Specifying the /json option returns a result of type ResultConnectProcess:

````
Alice> device reject NC4C-PWO7-2A6R-NQ3W-2RZV-SKK3-RHIN /json
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
Alice4> device pre devices@example.com /key=udf://example.com/ECIQ-Q44I-SEWB-F3R4-6KBB-NO77-HZVM-DG
ERROR - Object reference not set to an instance of an object.
````

Specifying the /json option returns a result of type Result:

````
Alice4> device pre devices@example.com /key=udf://example.com/ECIQ-Q44I-SEWB-F3R4-6KBB-NO77-HZVM-DG /json
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
   Witness value = WPRM-7ZJ6-XMJ5-RMAH-N2JS-PHUA-7ZVH
   Personal Mesh = MDMD-6XEI-KFBS-OOCE-UJ4X-PM5J-YUC4
````

Specifying the /json option returns a result of type ResultConnect:

````
Alice2> device request alice@example.com /json
{
  "ResultConnect": {
    "Success": true,
    "CatalogedMachine": {
      "ID": "MD5F-YUFN-3EA5-U4FY-XGNX-FZ4K-GHFQ",
      "EnvelopedProfileMaster": [{
          "dig": "S512"},
        "ewogICJQcm9maWxlTWVzaCI6IHsKICAgICJLZXlPZmZsaW5lU2lnbmF
  0dXJlIjogewogICAgICAiVURGIjogIk1ETUQtNlhFSS1LRkJTLU9PQ0UtVUo0W
  C1QTTVKLVlVQzQiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICA
  gICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiL
  AogICAgICAgICAgIlB1YmxpYyI6ICJGM0JnX29SRzF0OTFWMHBNaGpXRThZMXl
  VZzFmdVlQbWhfQV83enRxMjF0RkJDR0xZSXhuCiAgeVcyYVc3Z3N0bHpYOXU5c
  WlRalJsM1dBIn19fSwKICAgICJLZXlzT25saW5lU2lnbmF0dXJlIjogW3sKICA
  gICAgICAiVURGIjogIk1EWlMtNU03Qi1GQjJOLVBVV1ctV1VTWi0yVEZGLVZON
  kwiLAogICAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICAgIlB
  1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogI
  CAgICAgICAgICAiUHVibGljIjogInNaeDNuS19FMnBEWFIxNDFBS3dCWDc4c3U
  yNlhMS0RIUW5xcUFPQjRMM0J4bVpRVWdKdDIKICA0OUhOZFNoOTlrU3NEbEhVd
  TQySEZ5OEEifX19XSwKICAgICJLZXlFbmNyeXB0aW9uIjogewogICAgICAiVUR
  GIjogIk1DQk8tTU5SVC1RRkFRLUFYVU4tWVdJNC1KV0RDLUdUNEIiLAogICAgI
  CAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNESCI
  6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAgIlB1YmxpY
  yI6ICJMdk9YcVhvM1BuSjc3VVgwcm8tY21ma3FndDd1ZTcxVHdvbmRYZ3JtTmd
  sSDBHN3RuMDlSCiAgQkJiazVsaTdVZHFwU3lfMjlKeDFfTk1BIn19fX19",
        {
          "signatures": [{
              "alg": "S512",
              "kid": "MDMD-6XEI-KFBS-OOCE-UJ4X-PM5J-YUC4",
              "signature": "HbMKopi26AQciJVY48Tsx_0CgBuru2h9roHkrqoBQ_-RA1tWE
  H4BBt1iF2W2yHtfj_fBereC6EcAzVYziBwQ1e0Kjvd6e_dYBhdKLERclM5WZbz
  7e90uN3QZITS2oa-nrB7b6EKNDoQqfssavJe-JDUA"}],
          "PayloadDigest": "kZFHX-Cunw_RoeVQKqcBz_UuA1zBMjhKVzD0liJb2TDsY
  GcJxYwW0rHw4YQSDOPSvc1RBGK1zAR0uR5eSC-Qog"}],
      "DeviceUDF": "MD5F-YUFN-3EA5-U4FY-XGNX-FZ4K-GHFQ",
      "EnvelopedProfileDevice": [{
          "dig": "S512"},
        "ewogICJQcm9maWxlRGV2aWNlIjogewogICAgIktleU9mZmxpbmVTaWd
  uYXR1cmUiOiB7CiAgICAgICJVREYiOiAiTUQ1Ri1ZVUZOLTNFQTUtVTRGWS1YR
  05YLUZaNEstR0hGUSIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICA
  gICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJFZDQ0O
  CIsCiAgICAgICAgICAiUHVibGljIjogImtELWdKOEhzUl9JUE1oZGo0TEtldmR
  Fb2VLa0hpSHVLeDJkTVhnVm1xOW5GOFFscmttdXgKICA2TWh0cWlVNjlXSjBoS
  ndUdGZoX1dMNkEifX19LAogICAgIktleUVuY3J5cHRpb24iOiB7CiAgICAgICJ
  VREYiOiAiTURTNy1TM05YLTZNUDctSEcyMy1DUVI2LUY1UDUtWTNEViIsCiAgI
  CAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJsaWNLZXlFQ0R
  IIjogewogICAgICAgICAgImNydiI6ICJFZDQ0OCIsCiAgICAgICAgICAiUHVib
  GljIjogImJFaTVFYkRLc1huX3NPV2UyT0lTMDUwN1dfQXN6dEVtR0NOZURqSC1
  wSHlPZVZuNDh4QXUKICA0RGNzaWZHSU5weHdka3gyQVdmZWZFZ0EifX19LAogI
  CAgIktleUF1dGhlbnRpY2F0aW9uIjogewogICAgICAiVURGIjogIk1CTVAtTzQ
  2Ty1GVEJVLVQ0V0YtRkpEQi1CQlc1LVdGNFMiLAogICAgICAiUHVibGljUGFyY
  W1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICA
  gICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJiZU1meE1WZ
  EU1ZUFrUlJEQlpqa19XOGh5U3plc1V5eXhKTjJhbDFGbE04RkNqNjJkU1hZCiA
  gd3NBWS1LMzU2SVRuUEtGRlM4b3J1czRBIn19fX19",
        {
          "signatures": [{
              "alg": "S512",
              "kid": "MD5F-YUFN-3EA5-U4FY-XGNX-FZ4K-GHFQ",
              "signature": "a_1MvUQpQTwuoZNnaRJRiFtxfandsGLCi-6BXi2TxYKZ7a-wG
  pQHIDgzEoyBQXX8d4sBC70mxyMAnvHS1kvidxSBpJQ9G1l4VgCjHBtW1O_P6Gg
  -7Cr2R6WjqnndPwM-OqKCW8Tb8S8whVxVADYUDBIA"}],
          "PayloadDigest": "IDU1IFSrAIMhJF6YHAFw527Red8Q1nuwsCaAqwF7Rxtt4
  P2ZXDqetjDT14qpxl6lmwpZa_DrDMiSGkCSdzuXgg"}],
      "EnvelopedMessageConnectionResponse": [{},
        "ewogICJBY2tub3dsZWRnZUNv
  bm5lY3Rpb24iOiB7CiAgICAiTWVzc2FnZUlEIjogIk5DNEMtUFdPNy0yQTZSLU
  5RM1ctMlJaVi1TS0szLVJISU4iLAogICAgIkVudmVsb3BlZFJlcXVlc3RDb25u
  ZWN0aW9uIjogW3sKICAgICAgICAiZGlnIjogIlM1MTIifSwKICAgICAgImV3b2
  dJQ0pTWlhGMVpYTjBRMjl1Ym1WamRHbHZiaUk2SUhzS0lDQWdJQ0pUWlhKMmFX
  TmxTVVEKICBpT2lBaVlXeHBZMlZBWlhoaGJYQnNaUzVqYjIwaUxBb2dJQ0FnSW
  tWdWRtVnNiM0JsWkZCeWIyWnBiR1ZFWgogIFhacFkyVWlPaUJiZXdvZ0lDQWdJ
  Q0FnSUNKa2FXY2lPaUFpVXpVeE1pSjlMQW9nSUNBZ0lDQWlaWGR2WjBsCiAgRF
  NsRmpiVGx0WVZkNGJGSkhWakpoVjA1c1NXcHZaMlYzYjJkSlEwRm5TV3QwYkdW
  Vk9XMWFiWGh3WW0xV1YKICBHRlhaQW9nSUhWWldGSXhZMjFWYVU5cFFqZERhVU
  ZuU1VOQlowbERTbFpTUlZscFQybEJhVlJWVVRGU2FURgogIGFWbFZhVDB4VVRr
  WlJWRlYwVmxSU1IxZFRNVmxTQ2lBZ01EVlpURlZhWVU1RmMzUlNNR2hIVlZOSm
  MwTnBRCiAgV2RKUTBGblNVTktVV1JYU25OaFYwNVJXVmhLYUdKWFZqQmFXRXA2
  U1dwdloyVjNiMmRKUTBFS0lDQm5TVU4KICBCWjBsRFNsRmtWMHB6WVZkT1RGcF
  liRVpSTUZKSlNXcHZaMlYzYjJkSlEwRm5TVU5CWjBsRFFXZEpiVTU1WgogIEds
  Sk5rbERTa1phUkZFd1R3b2dJRU5KYzBOcFFXZEpRMEZuU1VOQlowbERRV2xWU0
  ZacFlrZHNha2xxYjJkCiAgSmJYUkZURmRrUzA5RmFIcFZiRGxLVlVVeGIxcEhi
  ekJVUlhSc1pHMVNDaUFnUm1JeVZreGhNR2h3VTBoV1QKICBHVkVTbXRVVm1odV
  ZtMHhlRTlYTlVkUFJrWnpZMjEwZEdSWVowdEpRMEV5VkZkb01HTlhiRlpPYW14
  WVUycAogIENiMU1LSUNCdVpGVmtSMXB2V0RGa1RVNXJSV2xtV0RFNVRFRnZaMG
  xEUVdkSmEzUnNaVlZXZFZrelNqVmpTCiAgRkp3WWpJMGFVOXBRamREYVVGblNV
  TkJaMGxEU2dvZ0lGWlNSVmxwVDJsQmFWUlZVbFJPZVRGVVRUQTFXVXgKICBVV2
  s1VlJHTjBVMFZqZVUxNU1VUlZWa2t5VEZWWk1WVkVWWFJYVkU1RlZtbEpjME5w
  UVdkSkNpQWdRMEZuUwogIFVOS1VXUlhTbk5oVjA1UldWaEthR0pYVmpCYVdFcD
  ZTV3B2WjJWM2IyZEpRMEZuU1VOQlowbERTbEZrVjBwCiAgellWZE9URnBZYkVa
  Uk1GSUtJQ0JKU1dwdloyVjNiMmRKUTBGblNVTkJaMGxEUVdkSmJVNTVaR2xKTm
  tsRFMKICBrWmFSRkV3VDBOSmMwTnBRV2RKUTBGblNVTkJaMGxEUVdsVlNGWnBZ
  Z29nSUVkc2FrbHFiMmRKYlVwR1lWUgogIFdSbGxyVWt4ak1XaDFXRE5PVUZZeV
  ZYbFVNR3hVVFVSVmQwNHhaR1pSV0U0MlpFVldkRkl3VGs5YVZWSnhVCiAgME14
  Q2lBZ2QxTkliRkJhVmxwMVRrUm9ORkZZVlV0SlEwRXdVa2RPZW1GWFdraFRWVF
  YzWlVoa2EyRXpaM2wKICBSVm1SdFdsZGFSbG93UldsbVdERTVURUZ2WjBrS0lD
  QkRRV2RKYTNSc1pWVkdNV1JIYUd4aWJsSndXVEpHTQogIEdGWE9YVkphbTluWl
  hkdlowbERRV2RKUTBGcFZsVlNSMGxxYjJkSmF6RkRWRlpCZEZSNlVRb2dJREpV
  ZVRGCiAgSFZrVktWa3hXVVRCV01GbDBVbXR3UlZGcE1VTlJiR014VEZaa1IwNU
  dUV2xNUVc5blNVTkJaMGxEUVdsVlMKICBGWnBZa2RzYWxWSFJubFpDaUFnVnpG
  c1pFZFdlV041U1RaSlNITkxTVU5CWjBsRFFXZEpRMEZwVlVoV2FXSgogIEhiR3
  BUTWxZMVVsVk9SVk5EU1RaSlNITkxTVU5CWjBsRFFXZEpRMEVLSUNCblNVTkth
  bU51V1dsUGFVRnBVCiAgbGRSTUU1RVoybE1RVzluU1VOQlowbERRV2RKUTBGbl
  NXeENNVmx0ZUhCWmVVazJTVU5LYVZwVk1XMWxSVEYKICBYV2dvZ0lFVlZNVnBW
  Um5KVmJFcEZVV3h3Y1dFeE9WaFBSMmcxVlROd2JHTXhWalZsV0doTFZHcEthR0
  pFUgogIGtkaVJUQTBVbXRPY1U1cVNtdFZNV2hhUTJsQkNpQWdaMlF6VGtKWFV6
  Rk1UWHBWTWxOV1VuVlZSWFJIVW14CiAgTk5HSXpTakZqZWxKQ1NXNHhPV1pZTV
  RraUxBb2dJQ0FnSUNCN0NpQWdJQ0FnSUNBZ0luTnBaMjVoZEhWeVoKICBYTWlP
  aUJiZXdvZ0lDQWdJQ0FnSUNBZ0lDQWlZV3huSWpvZ0lsTTFNVElpTEFvZ0lDQW
  dJQ0FnSUNBZ0lDQQogIGlhMmxrSWpvZ0lrMUVOVVl0V1ZWR1RpMHpSVUUxTFZV
  MFJsa3RXRWRPV0MxR1dqUkxMVWRJUmxFaUxBb2dJCiAgQ0FnSUNBZ0lDQWdJQ0
  FpYzJsbmJtRjBkWEpsSWpvZ0ltRmZNVTEyVlZGd1VWUjNkVzlhVG01aFVrcFNh
  VVoKICAwZUdaaGJtUnpSMHhEYVMwMlFsaHBNbFI0V1V0YU4yRXRkMGNLSUNCd1
  VVaEpSR2Q2Ulc5NVFsRllXRGhrTgogIEhOQ1F6Y3diWGg1VFVGdWRraFRNV3Qy
  YVdSNFUwSndTbEU1UnpGc05GWm5RMnBJUW5SWE1VOWZVRFpIWndvCiAgZ0lDMD
  NRM0l5VWpaWGFuRnVibVJRZDAwdFQzRkxRMWM0VkdJNFV6aDNhRlo0VmtGRVdW
  VkVRa2xCSW4xZEwKICBBb2dJQ0FnSUNBZ0lDSlFZWGxzYjJGa1JHbG5aWE4wSW
  pvZ0lrbEVWVEZKUmxOeVFVbE5hRXBHTmxsSVFVWgogIDNOVEkzVW1Wa09GRXhi
  blYzYzBOaFFYRjNSamRTZUhSME5Bb2dJRkF5V2xoRWNXVjBha1JVTVRSeGNIaH
  NOCiAgbXh0ZDNCYVlWOUVja1JOYVZOSGEwTlRaSHAxV0dkbkluMWRMQW9nSUNB
  Z0lrTnNhV1Z1ZEU1dmJtTmxJam8KICBnSW05aFRETjJMVXhmVGtaV2MyMTNVRE
  F5Y1RNNVpXY2lmWDAiLAogICAgICB7CiAgICAgICAgInNpZ25hdHVyZXMiOiBb
  ewogICAgICAgICAgICAiYWxnIjogIlM1MTIiLAogICAgICAgICAgICAia2lkIj
  ogIk1CTVAtTzQ2Ty1GVEJVLVQ0V0YtRkpEQi1CQlc1LVdGNFMiLAogICAgICAg
  ICAgICAic2lnbmF0dXJlIjogIi1ZcmJUWTJKXzlEUVdsa2JMNVRIMW1tRW95NE
  VhRmx2SDFob2dsejVzYlBtS2F6dFUKICByMDZFSUEzV0dVZlBHY19teWRPVWRV
  SWFmYUFyVkM2VDhWRkJNNnpNSHo5cnBOUldnM2NOXzlhdUluTVU3YgogIEZSS2
  JRdXNjNUdLVExuM19MT0J2VVItNFBNYUZIZlRaOVNnZDJjeDRBIn1dLAogICAg
  ICAgICJQYXlsb2FkRGlnZXN0IjogInFTWTQwQ051czdqdkdSQlJZMldJX29ULT
  F1Q0twaGR4aVBNVDhzcHU4VXR2ZQogIFJMYWJlcjNfU3BqcF8zczVRV2NoZGQw
  MEI1YzJZTFpzVVl5NWNlSEd3In1dLAogICAgIlNlcnZlck5vbmNlIjogInFURH
  ptQ3RSMllCMFNEcGgxTjVjZWciLAogICAgIldpdG5lc3MiOiAiV1BSTS03Wko2
  LVhNSjUtUk1BSC1OMkpTLVBIVUEtN1pWSCJ9fQ"],
      "EnvelopedAccountAssertion": [{
          "dig": "S512"},
        "ewogICJQcm9maWxlQWNjb3VudCI6IHsKICAgICJLZXlPZmZsaW5lU2l
  nbmF0dXJlIjogewogICAgICAiVURGIjogIk1CSFotWlY1WC1MVlFaLUc1UUMtT
  UgyRS1INzY3LTc1SkEiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICA
  gICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0N
  DgiLAogICAgICAgICAgIlB1YmxpYyI6ICJDTzh3TlM1enY4bEJRUmJCWGxveng
  0SVRLT25CMjJCa2xGcU9Bak5qTHlvNTdpSnh6a2dTCiAgTlE1amRhamZ6dC01U
  zJ4RVNXeEN4bWNBIn19fSwKICAgICJLZXlzT25saW5lU2lnbmF0dXJlIjogW3s
  KICAgICAgICAiVURGIjogIk1DRlItS0pRUS0zTExZLUlPRVQtTkpOUC1RV1lZL
  UtIUzQiLAogICAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICA
  gIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAgICJjcnYiOiAiRWQ0NDgiL
  AogICAgICAgICAgICAiUHVibGljIjogIkwwWUdFekg2QU5iVjVWRkJ2SndmT2Z
  xa3h5bldoc09NdUs0MEUxSVZ1cXRFWnBid2tkbGsKICA2MkxKZlhReXpjN3NyQ
  zljajFNcUl1T0EifX19XSwKICAgICJTZXJ2aWNlSURzIjogWyJhbGljZUBleGF
  tcGxlLmNvbSJdLAogICAgIk1lc2hQcm9maWxlVURGIjogIk1ETUQtNlhFSS1LR
  kJTLU9PQ0UtVUo0WC1QTTVKLVlVQzQiLAogICAgIktleUVuY3J5cHRpb24iOiB
  7CiAgICAgICJVREYiOiAiTUFCQy1IVEJKLUkyWFgtMkVOVy0zTFNILUFZNkotN
  UZESiIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJ
  saWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJFZDQ0OCIsCiAgICAgI
  CAgICAiUHVibGljIjogImZETzBDNV9PbW9nT2U0RG9yVVl0LVNzTl9wRUYwYUF
  uY0E5UlJQN2g2Wm94Y01BLUhWbnEKICBNX1JSQS1keHEyVmRndUdiMzVjUWlnQ
  0EifX19fX0",
        {
          "signatures": [{
              "alg": "S512",
              "kid": "MDZS-5M7B-FB2N-PUWW-WUSZ-2TFF-VN6L",
              "signature": "QZ5zEAZ6L3tMc2z7aNnKgCJ6_pg5Tdaj_tI4LzkMZHhj3KD8o
  JXth9kjjKwfn8dBAM49o1xkTIMAxkvU9ngsT8eOxHdnDkdma_9lqq8BHHiFfXi
  KqafRryVBzeaMTzhzSENV2NfnUDPdzMb_gdpkywAA"}],
          "PayloadDigest": "NuTUYq_vh1Xb3x7289z8L8Q1RW8-zsXZAEpiIjnIZVw1e
  MD_byuXg6id31rR64nzt42Bx0HRCItbLuO9FI2Kdw"}]}}}
````


